using ACDATA;
using ACORACLE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static ACORACLE.AgnoMesrepository;
using static ACORACLE.ReportRepository;

namespace wproduccion.Controllers
{
    public class AgnoMesUbicacionController : Controller
    {
        private readonly string _connectionString;
        private readonly AgnoMesrepository _repository;

        public AgnoMesUbicacionController()
        {
            _connectionString = ConfigurationManager.AppSettings.Get("SQLSERVERORA");
            _repository = new AgnoMesrepository(_connectionString);
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ActualizaCeldaGrilla(ParametrosActualizacionDTO parametrosActualizacionDTO)
        {
            try
            {
           

                UpdateResult result = _repository.SetCellValue(parametrosActualizacionDTO, _connectionString);

                if (result.Success)
                {


                
                     StockCalculo stockCalculo = new StockCalculo();



                     try
                     {

                           var ddd = stockCalculo.CalculateAndUpdateStock(_connectionString, parametrosActualizacionDTO.Codigo, "202409", " ");
                        
                     }
                     catch (OracleException ex)
                     {

                         return Json(new { success = false, message = ex.ErrorCode.ToString() + " " + ex.Message }, JsonRequestBehavior.AllowGet);
                     }
                     catch (Exception ex)
                     {
                         return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                     }

                    



                    return Json(new { success = true, message = result.Message, newValue = result.NewValue });
                }
                else
                {
                    return Json(new { success = false, message = result.Message });
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult ObtenerCeldaGrilla(ParametrosActualizacionDTO parametrosActualizacionDTO)
        {
            try
            {


                CellValueResult result = _repository.GetCellValue(parametrosActualizacionDTO  );

                if (result.Success)
                {
 
                    return Json(new { data = result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    result.Comentario = "Error al Grabar";
                    return Json(new { data = result }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex) { 
                CellValueResult result2 = new CellValueResult();
            result2.Comentario = ex.Message.ToString(); result2.Success = false;
                return Json(new { data = result2 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}