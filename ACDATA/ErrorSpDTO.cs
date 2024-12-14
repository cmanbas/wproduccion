using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACDATA
{
   
        public class ErrorSpDTO
        {

            public string NumError { get; set; }
            public string MensajeError { get; set; }
            public string Respuesta { get; set; }
            public int Id { get; set; }
            public int IdDepartamento { get; set; }
            public string Departamento { get; set; }
            public int tipo { get; set; }
            public int tipousuario { get; set; }
            public int Nombre { get; set; }

            public int filas { get; set; }
            public string activo { get; set; }
            public string app { get; set; }
            public string ruts { get; set; }

            public string essupervisor { get; set; }

            public string eskam { get; set; }
            public string esfa { get; set; }
            public string esco { get; set; }

            public string nombreresponsable { get; set; }
            public string nombrepersona { get; set; }



        }
        public class Mensajepantalla
        {
            public string Mensaje { get; set; }
            public int Numero { get; set; }
        }
    
}
