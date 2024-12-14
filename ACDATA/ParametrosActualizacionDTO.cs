using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACDATA
{
    public class ParametrosActualizacionDTO
    {
        public string Codigo { get; set; }
        public string MateriaPrima { get; set; }
        public string Periodo { get; set; }
        public int Ubicacion { get; set; }
        public decimal NuevoValor { get; set; }
        public string Comentario { get; set; }
    }
}
