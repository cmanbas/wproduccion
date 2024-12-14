using ACORACLE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wproduccion.Controllers
{


    public class CargaDatosPlanilla : Controller
    { 
    public ActionResult vCargaDatosPlanilla()
    {
        PlanillaRepository planilla = new PlanillaRepository();
            planilla._connectionString = ConfigurationManager.AppSettings.Get("SQLSERVERORA");

            var datos = planilla.ObtenerDatosPlanilla();
            ViewBag.JsonData = JsonConvert.SerializeObject(datos);
            return View(datos);
    }
}
}