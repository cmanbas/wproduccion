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
using static ACORACLE.ReportRepository;

namespace wproduccion.Controllers
{
    public class ReportController : Controller
    {
        private readonly string _connectionString;
        private readonly ReportRepository _repository;

        public ReportController()
        {
            _connectionString = ConfigurationManager.AppSettings.Get("SQLSERVERORA");
            _repository = new ReportRepository(_connectionString);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetReportData(int startYear = 2018, string tableName = "T_VENTASMMPPTO_PRODUCCION")
        {
            var serializer = new JavaScriptSerializer
            {
                MaxJsonLength = int.MaxValue
            };
            try
            {
                var data2 = _repository.GetMonthlyReport(
                    startYear: startYear,
                    tableName: tableName,
                    ubicacionValue: 1,
                    ubicacionDesc: "VENTAS EN MM"
                );



                var jsonResult = new JsonResult
                {
                    Data = new { success = true, Data = data2 },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = int.MaxValue
                };
                return jsonResult;

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        /* ++++++++++++++++++++++++++++++++++++++++++++++++++++ */
        [HttpGet]
        public ActionResult GetReportDatanv(int startYear = 2018, string tableName = "T_VENTASMMPPTO_PRODUCCION", string CALCULOPL="SI")
        {
          
           /*
                StockCalculo stockCalculo = new StockCalculo();



            try
            {

                List<ProductoTipoDTO> productos = stockCalculo.GetProductiosTipo("CP", _connectionString, tableName);


                foreach (var producto in productos)
                {
                    var ddd = stockCalculo.CalculateAndUpdateStock(_connectionString, producto.CodigoV, "202409", CALCULOPL);
                }
            }
            catch (OracleException ex)
            {

                return Json(new { success = false, message = ex.ErrorCode.ToString() + " " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            */


            var serializer = new JavaScriptSerializer
            {
                MaxJsonLength = int.MaxValue
            };
            try
            {
                var data2 = _repository.GetMonthlyReportnv(
                    startYear: startYear,
                    tableName: tableName,
                    ubicacionValue: 1,
                    ubicacionDesc: "VENTAS EN MM",CALCULOPL
                );



                var jsonResult = new JsonResult
                {
                    Data = new { success = true, Data = data2 },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = int.MaxValue
                };
                return jsonResult;

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}