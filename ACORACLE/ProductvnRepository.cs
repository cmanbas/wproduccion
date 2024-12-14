using ACDATA;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACORACLE
{
    public class ProductvnRepository 
    {
        private readonly string _connectionString;

        public ProductvnRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ProductData> GetAllProductDatavn()
        {
            var products = new List<ProductData>();

            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
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
                        d.AGNO,
                        d.MES,
                        d.STOCKINIMES,
                        d.ENTREGAS,
                        d.OTRASSALIDAS,
                        d.CUARENTENA,
                        d.PPTOVENTAS,
                        d.VTASREALES,
                        d.DIASSTOCK,
                        pm.VALOR AS PRODUCCION,
                        tp.NOMBRE AS TIPOPRODUCCION
                    FROM 
                        TP_PRODUCTOS p
                    LEFT JOIN 
                        TP_DATOSMENSUALES d ON p.PRODUCTOID = d.PRODUCTOID
                    LEFT JOIN
                        TP_PRODUCCIONMENSUAL pm ON p.PRODUCTOID = pm.PRODUCTOID AND d.AGNO = pm.AGNO AND d.MES = pm.MES
                    LEFT JOIN
                        TP_TIPOSPRODUCCION tp ON pm.TIPOPRODUCCIONID = tp.TIPOPRODUCCIONID where  d.AGNO >=2022
                    ORDER BY 
                        p.PRODUCTOID, d.AGNO, d.MES";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new ProductData
                            {
                                ProductoId = Convert.ToInt32(reader["PRODUCTOID"]),
                                Nombre = reader["NOMBRE"].ToString(),
                                CodigoProducto = reader["CODIGOPRODUCTO"].ToString(),
                                CodigoPedido = reader["CODIGOPEDIDO"].ToString(),
                                PeriodoEficacia = Convert.ToInt32(reader["PERIODOEFICACIA"]),
                                TamanoLote = Convert.ToInt32(reader["TAMANOLOTE"]),
                                UnidadLote = reader["UNIDADLOTE"].ToString(),
                                PesoLote = Convert.ToDecimal(reader["PESOLOTE"]),
                                TipoEmpaque = reader["TIPOEMPAQUE"].ToString(),
                                UnidadesPorEmpaque = Convert.ToInt32(reader["UNIDADESPOREMPAQUE"]),
                                Agno = reader["AGNO"] != DBNull.Value ? Convert.ToInt32(reader["AGNO"]) : (int?)null,
                                Mes = reader["MES"] != DBNull.Value ? Convert.ToInt32(reader["MES"]) : (int?)null,
                                StockIniMes = reader["STOCKINIMES"] != DBNull.Value ? Convert.ToDecimal(reader["STOCKINIMES"]) : (decimal?)null,
                                Entregas = reader["ENTREGAS"] != DBNull.Value ? Convert.ToDecimal(reader["ENTREGAS"]) : (decimal?)null,
                                OtrasSalidas = reader["OTRASSALIDAS"] != DBNull.Value ? Convert.ToDecimal(reader["OTRASSALIDAS"]) : (decimal?)null,
                                Cuarentena = reader["CUARENTENA"] != DBNull.Value ? Convert.ToDecimal(reader["CUARENTENA"]) : (decimal?)null,
                                PptoVentas = reader["PPTOVENTAS"] != DBNull.Value ? Convert.ToDecimal(reader["PPTOVENTAS"]) : (decimal?)null,
                                VtasReales = reader["VTASREALES"] != DBNull.Value ? Convert.ToDecimal(reader["VTASREALES"]) : (decimal?)null,
                                DiasStock = reader["DIASSTOCK"] != DBNull.Value ? Convert.ToInt32(reader["DIASSTOCK"]) : (int?)null,
                                Produccion = reader["PRODUCCION"] != DBNull.Value ? Convert.ToDecimal(reader["PRODUCCION"]) : (decimal?)null,
                                TipoProduccion = reader["TIPOPRODUCCION"].ToString()
                            });
                        }
                    }
                }
            }

            return products;
        }
    }

}
