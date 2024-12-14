using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACDATA
{
    public class TipoProduccionDTO
    {
        public int CODINTERNO { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(100, ErrorMessage = "La descripción no puede exceder los 100 caracteres")]
        public string DESCRIPCION { get; set; }

 

        [DataType(DataType.Date)]
        public DateTime FECHACREACION { get; set; }
    }
}
