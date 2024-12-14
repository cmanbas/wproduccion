using ACDATA;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACORACLE
{
    public class StockCalculo
    {

        public class OperationResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public List<StockData> Data { get; set; }
            public Exception Exception { get; set; }
        }

        public OperationResult CalculateAndUpdateStock(string connectionString, string codigo, string mesInicio,string calculo)
        {
            if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(mesInicio))
            {
                throw new  Exception("Código de producto y mes de inicio son requeridos");
         
            }

            OracleConnection connection = null;
            OracleTransaction transaction = null;

            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
        

                List<StockData> stockDataList = GetProductData(connection, codigo, mesInicio);

                if (stockDataList.Count == 0)
                {

                    throw new Exception(string.Format("No se encontraron datos para el código {0}", codigo));
    
                }
             
                List<StockData> calculatedData = CalculateStock(stockDataList);  
                transaction = connection.BeginTransaction();
                UpdateStockValues(connection, calculatedData, transaction);

                transaction.Commit();

                return new OperationResult
                {
                    Success = true,
                    Message = "Proceso completado exitosamente",
                    Data = calculatedData
                };
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }

                return new OperationResult
                {
                    Success = false,
                    Message = "Error en el proceso de cálculo",
                    Exception = ex
                };
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                }
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        private List<StockData> GetProductData(OracleConnection connection, string codigo, string mesInicio)
        {
            List<StockData> stockDataList = new List<StockData>();
            OracleCommand command = null;
            OracleDataReader reader = null;

            try
            {
                string sql = @"
					SELECT 
					CODIGO,
					AGNOMES,
					SUM(CASE WHEN UBICACION = 1 THEN NVL(VALOR, 0) ELSE 0 END) as STOCK_INI,
					SUM(CASE WHEN UBICACION = 2 THEN NVL(VALOR, 0) ELSE 0 END) as PRODUCCION,
					SUM(CASE WHEN UBICACION = 5 THEN NVL(VALOR, 0) ELSE 0 END) as OTRAS_SALIDAS,

					SUM(CASE WHEN UBICACION = 6 THEN NVL(VALOR, 0) ELSE 0 END) as PPTO_VENTAS,
		            SUM(CASE WHEN UBICACION = 4 THEN NVL(VALOR, 0) ELSE 0 END) as CUARENTENA 
					FROM T_PRODUCCION_DATOS 
					WHERE CODIGO = :codigo  
					AND AGNOMES >= :mesInicio 
					GROUP BY CODIGO, AGNOMES order by CODIGO, AGNOMES ";

                command = new OracleCommand(sql, connection);
                command.Parameters.Add(new OracleParameter("codigo", codigo));
                command.Parameters.Add(new OracleParameter("mesInicio", mesInicio));

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    stockDataList.Add(new StockData
                    {
                        Codigo = reader.GetString(0),
                        Agnomes = reader.GetString(1),
                        StockInicial = reader.GetDecimal(2),
                        Produccion = reader.GetDecimal(3),
                        OtrasSalidas = reader.GetDecimal(4),
                        PptoVentas = reader.GetDecimal(5),
                        cuarentena = reader.GetDecimal(6),
                        StockCalculado = reader.GetDecimal(2)
                    });
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                }
                if (command != null)
                {
                    command.Dispose();
                }
            }

            return stockDataList;
        }

        private List<StockData> CalculateStock(List<StockData> stockDataList)
        {
            for (int i = 0; i < stockDataList.Count - 1; i++)
            {
                StockData currentMonth = stockDataList[i];
                StockData nextMonth = stockDataList[i + 1];

                nextMonth.StockCalculado = currentMonth.StockInicial + 
                                         currentMonth.Produccion + currentMonth.cuarentena - (
                                         currentMonth.OtrasSalidas +
                                         currentMonth.PptoVentas);

                nextMonth.StockInicial = nextMonth.StockCalculado;
            }

            return stockDataList;
        }

        private void UpdateStockValues(OracleConnection connection, List<StockData> calculatedData, OracleTransaction transaction)
        {
            OracleCommand command = null;

            try
            {
                string updateSql = @"
                UPDATE T_PRODUCCION_DATOS 
                SET VALOR = :stockCalculado
                WHERE CODIGO = :codigo 
                AND AGNOMES = :agnomes 
                AND UBICACION = 1";

                command = new OracleCommand(updateSql, connection, transaction);

                for (int i = 1; i < calculatedData.Count; i++)
                {
                    StockData data = calculatedData[i];
                    command.Parameters.Clear();
                    command.Parameters.Add(new OracleParameter("stockCalculado", data.StockCalculado));
                    command.Parameters.Add(new OracleParameter("codigo", data.Codigo));
                    command.Parameters.Add(new OracleParameter("agnomes", data.Agnomes));
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                }
            }
        }


        public List<ProductoTipoDTO> GetProductiosTipo(string tipoRod, string connectionString,string materiaprima)
        {
            var result = new List<ProductoTipoDTO>();

            const string query = @"
            SELECT DISTINCT
                CODIGO AS CODIGOV,
                TIPROD
            FROM 
                t_produccion_datos, FOPRTE
            WHERE 
                codigo = SUBSTR(codterm, 1, INSTR(codterm, '-') - 1)
                AND NOMTERM NOT LIKE '%[D]%'
                AND NVL(CODIGO, 'X') <> 'X'
                AND TIPROD = :TIPROPOD
                AND  CODIGO IN ( SELECT SUBSTR(MATNR, 3) FROM SAP_BOM WHERE IDNRK=:MATERIAPRIMA OR :MATERIAPRIMA='0' )
            GROUP BY 
                CODIGO, TIPROD
            ORDER BY 
                CODIGO";

            try
            {
                using (var connection = new OracleConnection(  connectionString))
                {
                    connection.Open();
                    using (var command = new OracleCommand(query, connection))
                    {
                        // Add parameter
                        command.Parameters.Add(":TIPROPOD", OracleType.VarChar).Value = tipoRod;
                        command.Parameters.Add(":MATERIAPRIMA", OracleType.VarChar).Value = materiaprima;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    var model = new ProductoTipoDTO
                                    {
                                        CodigoV = reader["CODIGOV"]?.ToString(),
                                        TipRod = reader["TIPROD"]?.ToString()
                                    };

                                    result.Add(model);
                                }
                                catch (Exception ex)
                                {
           
           
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
 
                throw; // Re-throw the exception to be handled by the calling method
            }

            return result;
        }



        public List<ProductoTipoDTO> GetProductiosTipoByCodigo(string tipoRod, string connectionString, string materiaprima, string codprod)
        {
            var result = new List<ProductoTipoDTO>();

            const string query = @"
            SELECT DISTINCT
                CODIGO AS CODIGOV,
                TIPROD
            FROM 
                t_produccion_datos, FOPRTE
            WHERE 
                codigo = SUBSTR(codterm, 1, INSTR(codterm, '-') - 1)
                AND NOMTERM NOT LIKE '%[D]%'
                AND NVL(CODIGO, 'X') <> 'X'
                AND TIPROD = :TIPROPOD
                AND  CODIGO IN ( SELECT SUBSTR(MATNR, 3) FROM SAP_BOM WHERE IDNRK=:MATERIAPRIMA OR :MATERIAPRIMA='0' )
                codigo  =:CODIGOPROD
            GROUP BY 
                CODIGO, TIPROD
            ORDER BY 
                CODIGO";

            try
            {
                using (var connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new OracleCommand(query, connection))
                    {
                        // Add parameter
                        command.Parameters.Add(":TIPROPOD", OracleType.VarChar).Value = tipoRod;
                        command.Parameters.Add(":MATERIAPRIMA", OracleType.VarChar).Value = materiaprima;
                        command.Parameters.Add(":CODIGOPROD", OracleType.VarChar).Value = codprod;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    var model = new ProductoTipoDTO
                                    {
                                        CodigoV = reader["CODIGOV"]?.ToString(),
                                        TipRod = reader["TIPROD"]?.ToString()
                                    };

                                    result.Add(model);
                                }
                                catch (Exception ex)
                                {


                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw; // Re-throw the exception to be handled by the calling method
            }

            return result;
        }
    }
}

