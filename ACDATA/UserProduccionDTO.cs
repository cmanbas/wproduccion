using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACDATA
{
    public class UserProduccionDTO
    {
        public int usr_cod { get; set; }
        public string usr_login { get; set; }
        public string usr_alias { get; set; }
        public string usr_passwordenc { get; set; }
        public string usr_password { get; set; }
        public string usr_nombre { get; set; }
        public string usr_administrador { get; set; }
        public string usr_estado { get; set; }
        public DateTime usr_fechacreacion { get; set; }
        public string usr_observacion { get; set; }
        public string usr_administrador_desc { get; set; }
        public string usr_estado_desc { get; set; }
    }
}
