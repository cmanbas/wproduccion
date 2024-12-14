using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace wproduccion.UtilsSite
{
    public class Utils
    {

        public bool CheckSessionconexion(string valor)
        {
            if (valor == null)
            {
                return true;
            }
            return false;
        }

        public static class ConnectionManager
        {
            public static string GetConnectionString()
            {
                return ConfigurationManager.AppSettings.Get("SQLSERVERORA");
            }
        }
    }
}