using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using ACDATA;
using ACORACLE;

public class PeriodoEficaciaController : Controller
{
    private readonly string _connectionString;

    public PeriodoEficaciaController()
    {
        _connectionString = ConfigurationManager.AppSettings["SQLSERVERORA"];
    }

    private ActionResult CheckSession()
    {
        if (Session["LastAccess"] == null)
        {
            return Json(new { success = false, message = "Sesión finalizada. Por favor, inicie sesión nuevamente." }, JsonRequestBehavior.AllowGet);
        }
        return null;
    }

    public ActionResult Vperiodoseficacia()
    {
        var sessionCheck = CheckSession();
        if (sessionCheck != null) return sessionCheck;

        return View();
    }

    [HttpPost]
    public JsonResult Create(PeriodoEficaciaDTO periodo)
    {
        var sessionCheck = CheckSession();
        if (sessionCheck != null) return Json(new { success = false, message = ((JsonResult)sessionCheck).Data });

        PeriodoEficaciaService._connectionstring = _connectionString;
        if (PeriodoEficaciaService.CreatePeriodoEficacia(periodo))
        {
            return Json(new { success = true, message = "Periodo de eficacia agregado exitosamente." });
        }
        else
        {
            return Json(new { success = false, message = "Error al agregar periodo de eficacia: " + PeriodoEficaciaService.mensaje });
        }
    }

    [HttpPost]
    public JsonResult Update(PeriodoEficaciaDTO periodo)
    {
        var sessionCheck = CheckSession();
        if (sessionCheck != null) return Json(new { success = false, message = ((JsonResult)sessionCheck).Data });

        PeriodoEficaciaService._connectionstring = _connectionString;
        if (PeriodoEficaciaService.UpdatePeriodoEficacia(periodo))
        {
            return Json(new { success = true, message = "Periodo de eficacia actualizado exitosamente." });
        }
        else
        {
            return Json(new { success = false, message = "Error al actualizar periodo de eficacia: " + PeriodoEficaciaService.mensaje });
        }
    }

    [HttpGet]
    public ActionResult GetAllPeriodosEficacia()
    {
        var sessionCheck = CheckSession();
        if (sessionCheck != null) return sessionCheck;

        PeriodoEficaciaService._connectionstring = _connectionString;
        List<PeriodoEficaciaDTO> periodos = PeriodoEficaciaService.GetAllPeriodosEficacia();
        return Json(new { Tabla = periodos, success = true }, JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public JsonResult Delete(int codinternope)
    {
        var sessionCheck = CheckSession();
        if (sessionCheck != null) return Json(new { success = false, message = ((JsonResult)sessionCheck).Data });

        PeriodoEficaciaService._connectionstring = _connectionString;
        if (PeriodoEficaciaService.DeletePeriodoEficacia(codinternope))
        {
            return Json(new { success = true, message = "Periodo de eficacia eliminado exitosamente." });
        }
        else
        {
            return Json(new { success = false, message = "Error al eliminar periodo de eficacia: " + PeriodoEficaciaService.mensaje });
        }
    }

    [HttpGet]
    public ActionResult GetPeriodoEficaciaById(int codinternope)
    {
        var sessionCheck = CheckSession();
        if (sessionCheck != null) return sessionCheck;

        PeriodoEficaciaService._connectionstring = _connectionString;
        var periodo = PeriodoEficaciaService.GetPeriodoEficaciaById(codinternope);
        if (periodo != null)
        {
            return Json(new { success = true, data = periodo }, JsonRequestBehavior.AllowGet);
        }
        else
        {
            return Json(new { success = false, message = "Periodo de eficacia no encontrado." }, JsonRequestBehavior.AllowGet);
        }
    }
}