using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using ACDATA;

namespace ACORACLE
{
    public class ProductionDataRepository
    {
        private readonly string _connectionString;

        public ProductionDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ProductionData> GetProductionData()
        {
            var result = new List<ProductionData>();

            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT 
                            'SALIDAS' AS tipo,
                             CODIGO ||'-'||DESCRIPCION PRODUCTO,
                            ANOMES,
                            MOVIMIENTO as VALOR, agno Agno, 0 UBICACION 
                        FROM 
                            FACTURAS.T_SALIDAS_PRODUCCION 
                        UNION ALL
                        SELECT  
                           'VENTAS' AS tipo,
                            CODIGO ||'-'||DESCRIPCION PRODUCTO,
                            ANOMES,
                            VALOR, agno Agno,0 UBICACION
                        FROM 
                            FACTURAS.T_VENTAS_PRODUCCION 
                         UNION ALL 
                     SELECT
                           'STOCK REAL' AS tipo,
                            CODIGO ||'-'||DESCRIPCION PRODUCTO,
                            ANOMES,
                            VALOR, agno Agno, UBICACION
                        FROM 
                            FACTURAS.T_STOCKREAL_PRODUCCION
                            
                            order by PRODUCTO   , tipo,UBICACION,ANOMES ";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new ProductionData
                            {
                                Tipo = reader.GetString(0),
                                Codigo = reader.GetString(1),
                                //  Descripcion = reader.GetString(2),
                                Anomes = reader.GetString(2),
                                Valor = reader.GetDecimal(3),
                                Agno = reader.GetDecimal(4).ToString()
                            }); ;
                        }
                    }
                }
            }

            return result;
        }

      
        public List<productdto> GetAllProductDatav2(int agnoInicio, int agnoFin)
            {
                var products = new List<productdto>();

                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                WITH TODOSLOSMESES AS (
                    SELECT LEVEL + :AgnoInicio - 1 AS AGNO, 
                           MOD(LEVEL - 1, 12) + 1 AS MES
                    FROM DUAL
                    CONNECT BY LEVEL <= (:AgnoFin - :AgnoInicio + 1) * 12
                )
                SELECT 
                    p.PRODUCTOID,
                    p.NOMBRE,
                    p.CODIGOPRODUCTO,
                    p.CODIGOPEDIDO,
                    p.PERIODOEFICACIA,
                    p.TAMANOLOTE,
                    p.UNIDADLOTE,
                    p.PESOLOTE,
                    p.TIPOEMPAQUE,
                    p.UNIDADESPOREMPAQUE,
                    tm.AGNO,
                    tm.MES,
                    NVL(d.STOCKINIMES, 0) AS STOCK_INI_MES,
                    NVL(pm.VALOR, 0) AS PRODUCCION,
                    NVL(tp.NOMBRE, '') AS TIPO_PRODUCCION,
                    NVL(d.ENTREGAS, 0) AS ENTREGAS,
                    NVL(d.OTRASSALIDAS, 0) AS OTRAS_SALIDAS,
                    NVL(d.CUARENTENA, 0) AS CUARENTENA,
                    NVL(d.PPTOVENTAS, 0) AS PPTO_VENTAS,
                    NVL(d.VTASREALES, 0) AS VTAS_REALES,
                    NVL(d.DIASSTOCK, 0) AS DIAS_STOCK
                FROM 
                    TP_PRODUCTOS p
                CROSS JOIN
                    TODOSLOSMESES tm
                LEFT JOIN 
                    TP_DATOSMENSUALES d ON p.PRODUCTOID = d.PRODUCTOID AND tm.AGNO = d.AGNO AND tm.MES = d.MES
                LEFT JOIN
                    TP_PRODUCCIONMENSUAL pm ON p.PRODUCTOID = pm.PRODUCTOID AND tm.AGNO = pm.AGNO AND tm.MES = pm.MES
                LEFT JOIN
                    TP_TIPOSPRODUCCION tp ON pm.TIPOPRODUCCIONID = tp.TIPOPRODUCCIONID
                ORDER BY 
                    p.PRODUCTOID, tm.AGNO, tm.MES";

                    command.Parameters.Add(":AgnoInicio", OracleType.Int32).Value = agnoInicio;
                    command.Parameters.Add(":AgnoFin", OracleType.Int32).Value = agnoFin;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new productdto
                            {
                                productoid = Convert.ToInt32(reader["PRODUCTOID"]),
                                nombre = reader["NOMBRE"].ToString(),
                                codigoproducto = reader["CODIGOPRODUCTO"].ToString(),
                                codigopedido = reader["CODIGOPEDIDO"].ToString(),
                                periodoeficacia = Convert.ToInt32(reader["PERIODOEFICACIA"]),
                                tamanolote = Convert.ToInt32(reader["TAMANOLOTE"]),
                                unidadlote = reader["UNIDADLOTE"].ToString(),
                                pesolote = Convert.ToDecimal(reader["PESOLOTE"]),
                                tipoempaque = reader["TIPOEMPAQUE"].ToString(),
                                unidadesporempaque = Convert.ToInt32(reader["UNIDADESPOREMPAQUE"]),
                                agno = Convert.ToInt32(reader["AGNO"]),
                                mes = Convert.ToInt32(reader["MES"]),
                                stockinimes = Convert.ToInt32(reader["STOCK_INI_MES"]),
                                produccion = Convert.ToDecimal(reader["PRODUCCION"]),
                                tipoproduccion = reader["TIPO_PRODUCCION"].ToString(),
                                entregas = Convert.ToDecimal(reader["ENTREGAS"]),
                                otrassalidas = Convert.ToDecimal(reader["OTRAS_SALIDAS"]),
                                cuarentena = Convert.ToInt32(reader["CUARENTENA"]),
                                pptoventas = Convert.ToInt32(reader["PPTO_VENTAS"]),
                                vtasreales = Convert.ToInt32(reader["VTAS_REALES"]),
                                diasstock = Convert.ToInt32(reader["DIAS_STOCK"])
                            });
                        }
                    }
                }

                return products;
            }
    }
}