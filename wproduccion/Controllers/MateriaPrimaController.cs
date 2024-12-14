using ACDATA;
using ACORACLE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static ACORACLE.ReportRepository;

namespace wproduccion.Controllers
{
    public class MateriaPrimaController : Controller
    {
 

        private readonly MateriasPrimasRepository _repository;
        private readonly string connectionString;
        private Mensajepantalla erroracceso;

        public MateriaPrimaController()
        {
            connectionString = ConfigurationManager.AppSettings.Get("SQLSERVERORA");
            _repository = new MateriasPrimasRepository(connectionString);
            erroracceso = new Mensajepantalla();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetMateriasPrimas()
        {
    
            try
            {
                List<MateriasPrimasDTO> materiasprimas = await Task.Run(() => _repository.GetMaterialesCPFN());
                return Json(new { success = true, data = materiasprimas }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Log the exception here
 
                return Json(new { success = false, message = "Error al obtener las líneas: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}