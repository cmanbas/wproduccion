using ACDATA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace wproduccion.Controllers
{
   
        public class TipoProduccionController : Controller
        {
            private readonly TipoProduccionRepository _repository;
            private readonly string connectionString;
            private Mensajepantalla erroracceso;

            public TipoProduccionController()
            {
                connectionString = ConfigurationManager.AppSettings.Get("SQLSERVERORA");
                _repository = new TipoProduccionRepository(connectionString);
                erroracceso = new Mensajepantalla();
            }

            public ActionResult vTipoProduccion()
            {
                erroracceso.Mensaje = "";
                erroracceso.Numero = 0;
                return View(erroracceso);
            }

            [HttpPost]
            public async Task<ActionResult> AddTipoProduccion(TipoProduccionDTO tipoProduccion)
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Modelo inválido", errors = ModelState });
                }

                try
                {
                    await Task.Run(() => _repository.InsertTipoProduccion(tipoProduccion));
                    return Json(new { success = true, message = "Tipo de producción agregado exitosamente" });
                }
                catch (Exception ex)
                {
                    // Log the exception here
                    return Json(new { success = false, message = "Error al agregar el tipo de producción: " + ex.Message });
                }
            }

            [HttpGet]
            public async Task<ActionResult> GetTiposProduccion()
            {
                try
                {
                    List<TipoProduccionDTO> tiposProduccion = await Task.Run(() => _repository.GetTiposProduccion());
                    return Json(new { success = true, data = tiposProduccion }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    // Log the exception here
                    return Json(new { success = false, message = "Error al obtener los tipos de producción: " + ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }

            [HttpPost]
            public async Task<ActionResult> UpdateTipoProduccion(TipoProduccionDTO tipoProduccion)
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Modelo inválido", errors = ModelState });
                }

                try
                {
                    await Task.Run(() => _repository.UpdateTipoProduccion(tipoProduccion));
                    return Json(new { success = true, message = "Tipo de producción actualizado exitosamente" });
                }
                catch (Exception ex)
                {
                    // Log the exception here
                    return Json(new { success = false, message = "Error al actualizar el tipo de producción: " + ex.Message });
                }
            }

            [HttpPost]
            public async Task<ActionResult> DeleteTipoProduccion(int codinterno)
            {
                try
                {
                    await Task.Run(() => _repository.DeleteTipoProduccion(codinterno));
                    return Json(new { success = true, message = "Tipo de producción eliminado exitosamente" });
                }
                catch (Exception ex)
                {
                    // Log the exception here
                    return Json(new { success = false, message = "Error al eliminar el tipo de producción: " + ex.Message });
                }
            }
        }
    
}