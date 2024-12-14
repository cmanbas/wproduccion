using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACDATA
{
    public class StockData
    {
        public string Codigo { get; set; }
        public string Agnomes { get; set; }
        public decimal StockInicial { get; set; }
        public decimal Produccion { get; set; }
        public decimal cuarentena { get; set; }
        public decimal OtrasSalidas { get; set; }
        public decimal PptoVentas { get; set; }
        public decimal StockCalculado { get; set; }

    }
}
