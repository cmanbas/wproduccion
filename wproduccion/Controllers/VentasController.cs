using ACORACLE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wproduccion.Controllers
{
    public class VentasController : Controller
    {
        private VentasRepository _repository;

        public VentasController()
        {

            string connectionString = ConfigurationManager.AppSettings.Get("SQLSERVERORA").ToString();
            _repository = new VentasRepository(connectionString);
        }

        [HttpGet]
        public JsonResult GetVentasData()
        {
 

            if (Session["LastAccess"] == null)
            {
                return Json(new { success = false, message = "Sesión finalizada. Por favor, inicie sesión nuevamente." }, JsonRequestBehavior.AllowGet);
            }
 

            var ventasData = _repository.ObtenerVentas();
            return Json(ventasData, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult vVentasData()

        { 
                var sessionCheck = CheckSession();
                if (sessionCheck != null) return sessionCheck;

                return View();


       }

        private ActionResult CheckSession()
        {
            if (Session["LastAccess"] == null)
            {
                return Json(new { success = false, message = "Sesión finalizada. Por favor, inicie sesión nuevamente." }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }


    }
}
 