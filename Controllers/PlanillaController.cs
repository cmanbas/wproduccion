using ACORACLE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wproduccion.Controllers
{
    public class PlanillaController : Controller
    {
        // GET: Planilla
        public ActionResult vPlanilla()
        {
 

 
            return View( );
        }
        [HttpGet]
        public JsonResult ObtenerDatosPlanillaJson()
        {
            PlanillaRepository planilla = new PlanillaRepository();
            planilla._connectionString = ConfigurationManager.AppSettings.Get("SQLSERVERORA");

            var datos = planilla.ObtenerDatosPlanilla();
            var jsonResult = Json(datos, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}