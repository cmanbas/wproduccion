using System;
using System.Web.Mvc;
using ACDATA;
using ACORACLE;
using System.Configuration;

namespace wproduccion.Controllers
{
    public class WProduccionController : Controller
    {
        private readonly ProductionDataRepository _repository;

        public WProduccionController()
        {
            string connectionString = ConfigurationManager.AppSettings.Get("SQLSERVERORA");
            _repository = new ProductionDataRepository(connectionString);
        }

        public ActionResult VProductionData()
        {
            return View();
        }
        public ActionResult VProductionDatav2(int agnoInicio = 2023, int agnoFin = 2024)
        {
            var productData = _repository.GetAllProductDatav2(agnoInicio, agnoFin);
            return View(productData);
        }
        [HttpGet]
        public JsonResult GetProductionData()
        {
            var data = _repository.GetProductionData();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

 
    }
}