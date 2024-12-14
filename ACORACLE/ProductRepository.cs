using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACORACLE
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ProductGroupData> GetGroupedProductData(int agnoInicio, int agnoFin)
        {
            var products = new List<productdata>();

            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                var command = new OracleCommand
                {
                    Connection = connection,
                    CommandText = @"
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
                        NVL(d.STOCKINIMES, 0) AS STOCK_INI_MES,
                        NVL(pm.VALOR, 0) AS PRODUCCION,
                        tp.NOMBRE AS TIPO_PRODUCCION,
                        NVL(d.ENTREGAS, 0) AS ENTREGAS,
                        NVL(d.OTRASSALIDAS, 0) AS OTRAS_SALIDAS,
                        NVL(d.CUARENTENA, 0) AS CUARENTENA,
                        NVL(d.PPTOVENTAS, 0) AS PPTO_VENTAS,
                        NVL(d.VTASREALES, 0) AS VTAS_REALES,
                        NVL(d.DIASSTOCK, 0) AS DIAS_STOCK
                    FROM 
                        TP_PRODUCTOS p
                    LEFT JOIN 
                        TP_DATOSMENSUALES d ON p.PRODUCTOID = d.PRODUCTOID AND d.AGNO BETWEEN :AgnoInicio AND :AgnoFin
                    LEFT JOIN
                        TP_PRODUCCIONMENSUAL pm ON p.PRODUCTOID = pm.PRODUCTOID AND pm.AGNO = d.AGNO AND pm.MES = d.MES
                    LEFT JOIN
                        TP_TIPOSPRODUCCION tp ON pm.TIPOPRODUCCIONID = tp.TIPOPRODUCCIONID
                    ORDER BY 
                        p.PRODUCTOID, d.AGNO, d.MES"
                };

                command.Parameters.Add(":AgnoInicio", OracleType.Number).Value = agnoInicio;
                command.Parameters.Add(":AgnoFin", OracleType.Number).Value = agnoFin;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new productdata
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

            return products.GroupBy(p => p.productoid)
                           .Select(g => new ProductGroupData
                           {
                               ProductoId = g.Key,
                               Nombre = g.First().nombre,
                               CodigoProducto = g.First().codigoproducto,
                               CodigoPedido = g.First().codigopedido,
                               PeriodoEficacia = g.First().periodoeficacia,
                               TamanoLote = g.First().tamanolote,
                               UnidadLote = g.First().unidadlote,
                               PesoLote = g.First().pesolote,
                               TipoEmpaque = g.First().tipoempaque,
                               UnidadesPorEmpaque = g.First().unidadesporempaque,
                               TipoProduccion = g.First().tipoproduccion,
                               DatosMensuales = g.ToDictionary(
                                   p => $"{p.agno}-{p.mes.ToString().PadLeft(2, '0')}",
                                   p => new DatoMensual
                                   {
                                       StockIniMes = p.stockinimes,
                                       Produccion = p.produccion,
                                       Entregas = p.entregas,
                                       OtrasSalidas = p.otrassalidas,
                                       Cuarentena = p.cuarentena,
                                       PptoVentas = p.pptoventas,
                                       VtasReales = p.vtasreales,
                                       DiasStock = p.diasstock
                                   }
                               )
                           })
                           .ToList();
        }
    }
    public class ProductGroupData
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string CodigoProducto { get; set; }
        public string CodigoPedido { get; set; }
        public int PeriodoEficacia { get; set; }
        public int TamanoLote { get; set; }
        public string UnidadLote { get; set; }
        public decimal PesoLote { get; set; }
        public string TipoEmpaque { get; set; }
        public int UnidadesPorEmpaque { get; set; }
        public string TipoProduccion { get; set; }
        public Dictionary<string, DatoMensual> DatosMensuales { get; set; }
    }

    public class DatoMensual
    {
        public int StockIniMes { get; set; }
        public decimal Produccion { get; set; }
        public decimal Entregas { get; set; }
        public decimal OtrasSalidas { get; set; }
        public int Cuarentena { get; set; }
        public int PptoVentas { get; set; }
        public int VtasReales { get; set; }
        public int DiasStock { get; set; }
    }
    public class productdata
    {
        public int productoid { get; set; }
        public string nombre { get; set; }
        public string codigoproducto { get; set; }
        public string codigopedido { get; set; }
        public int periodoeficacia { get; set; }
        public int tamanolote { get; set; }
        public string unidadlote { get; set; }
        public decimal pesolote { get; set; }
        public string tipoempaque { get; set; }
        public int unidadesporempaque { get; set; }
        public int agno { get; set; }
        public int mes { get; set; }
        public int stockinimes { get; set; }
        public decimal produccion { get; set; }
        public string tipoproduccion { get; set; }
        public decimal entregas { get; set; }
        public decimal otrassalidas { get; set; }
        public int cuarentena { get; set; }
        public int pptoventas { get; set; }
        public int vtasreales { get; set; }
        public int diasstock { get; set; }
    }

}