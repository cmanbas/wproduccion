using ACORACLE;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                var data = data2.OrderBy(x => x.Codigo)
                          .ThenBy(x => x.Ubicacion)
                          .ToList();


                return new JsonResult
                {
                    Data = new { success = true, data },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = int.MaxValue
                };

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportDatanv(int startYear = 2018, string tableName = "T_VENTASMMPPTO_PRODUCCION")
        {
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
                    ubicacionDesc: "VENTAS EN MM"
                );
                var data = data2.OrderBy(x => x.Codigo)
                          .ThenBy(x => x.Ubicacion)
                          .ToList();


                return new JsonResult
                {
                    Data = new { success = true, data },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = int.MaxValue
                };

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}