using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
 

    namespace ACDATA
    {
        public class ProductionData
        {
            public string Tipo { get; set; }
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
            public string Anomes { get; set; }
        public string Agno { get; set; }
        public decimal Valor { get; set; }
        }
    public class productdto
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
    public class ProductData
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
        public int? Agno { get; set; }
        public int? Mes { get; set; }
        public decimal? StockIniMes { get; set; }
        public decimal? Entregas { get; set; }
        public decimal? OtrasSalidas { get; set; }
        public decimal? Cuarentena { get; set; }
        public decimal? PptoVentas { get; set; }
        public decimal? VtasReales { get; set; }
        public int? DiasStock { get; set; }
        public decimal? Produccion { get; set; }
        public string TipoProduccion { get; set; }
    }
    public class ProductViewModel
    {
        public int MP { get; set; }
        public List<ProductRowViewModel> Rows { get; set; }
    }

    public class ProductRowViewModel
    {
        public int ORDEN { get; set; }
        public string PRODUCTO { get; set; }
        public string ANOMES { get; set; }
        public Dictionary<string, decimal?> MonthlyData { get; set; } = new Dictionary<string, decimal?>();
    }
}
 