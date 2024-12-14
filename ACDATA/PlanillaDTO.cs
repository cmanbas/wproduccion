using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACDATA
{
    public class PlanillaDTO
    {
        public string CODPROD { get; set; }
        public string NOMPROD { get; set; }
        public int UBICACION { get; set; }
        public string tipo { get; set; }
        public Dictionary<string, decimal> Meses { get; set; } = new Dictionary<string, decimal>();
    }
}
