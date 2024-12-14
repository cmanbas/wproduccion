using ACDATA;
using ACORACLE;
using ACVARIOS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wproduccion.Controllers
{
    
    public class UsuarioController : Controller
    {
        ErrorSpDTO respuesta = new ErrorSpDTO();
        Mensajepantalla erroracceso = new Mensajepantalla();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult vusuarios()
        {
            return View();
        }
        public ActionResult Vcambioclave()
        {
            if (Session["LastAccess"] == null)
            {
                ViewBag.Message = "Session Expirada;";
                return View("Vlogin");
            }
            return View();
        }

        public ActionResult Vlogin(string mensaje = "")
        {
            ViewBag.Message = mensaje;
            return View();
        }

        public ActionResult vkam()
        {
            erroracceso.Mensaje = "";
            erroracceso.Numero = 1;
            return View();
        }

        [HttpPost]
        public JsonResult Create(UserProduccionDTO user)
        {
            respuesta.MensajeError = "";
            respuesta.NumError = "99";

            user.usr_passwordenc = ConfigurationManager.AppSettings.Get("apppassword").ToString();
            UsuarioService._connectionstring = ConfigurationManager.AppSettings.Get("SQLSERVERORA").ToString();
            if (UsuarioService.CreateUser(user))
            {
                return Json(new { success = true, message = "KAM agregado exitosamente!" });
            }
            else
            {
                return Json(new { success = false, message = "Error al agregar KAM" });
            }
        }

        [HttpPost]
        public JsonResult Update(UserProduccionDTO user)
        {
            UsuarioService._connectionstring = ConfigurationManager.AppSettings.Get("SQLSERVERORA").ToString();
            var resultado = UsuarioService.UpdateUser(user);
            if (resultado)
            {
                return Json(new { success = true, message = "KAM actualizado exitosamente!" });
            }
            else
            {
                return Json(new { success = false, message = "Error al actualizar KAM" });
            }
        }

        [HttpPost]
        public ActionResult Reiniciar(int user)
        {
            UsuarioService._connectionstring = ConfigurationManager.AppSettings.Get("SQLSERVERORA").ToString();

            var resultado = UsuarioService.UpdateUserPassword(user, ConfigurationManager.AppSettings.Get("apppassword").ToString());
            if (resultado)
            {
                return Json(new { success = true, message = "Clave actualizada exitósamente!" });
            }
            else
            {
                return Json(new { success = false, message = "Error al reiniciar Clave" });
            }
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            UsuarioService._connectionstring = ConfigurationManager.AppSettings.Get("SQLSERVERORA").ToString();

            List<UserProduccionDTO> users = UsuarioService.GetAllUsers();
            if (users != null)
            {
                return Json(new { Tabla = users }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Tabla = users }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Delete(int usr_cod)
        {
            UsuarioService._connectionstring = ConfigurationManager.AppSettings.Get("SQLSERVERORA").ToString();
            if (UsuarioService.DeleteUser(usr_cod))
            {
                return Json(new { success = true, message = "KAM ELIMINADO exitosamente" });
            }
            else
            {
                return Json(new { success = false, message = "Error al eliminar KAM" });
            }
        }

 

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ValidaUsuario(string usuario, string password, string id)
        {
            Session["passworduser"] = password;
            string passwordencriptada = "";

            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(password))
            {
                passwordencriptada = Encriptar.EncriptarPassword(password);

                Session["usrclave"] = passwordencriptada;
                try
                {
                    UsuarioService.usuario = usuario;
                    UsuarioService.password = passwordencriptada;
                    UsuarioService._connectionstring = ConfigurationManager.AppSettings.Get("SQLSERVERORA").ToString();

                    UserProduccionDTO users = UsuarioService.GetAllUsersByusuariopassword();

                    ViewBag.Message = "";

                    if (UsuarioService.filasvalida == 0)
                    {
                        ViewBag.Message = "Email o Clave ingresada no existe";
                        return View("Vlogin");
                    }
                    if (UsuarioService.filasvalida == -1)
                    {
                        ViewBag.Message = "Problemas de Base de Datos";
                        return View("Vlogin");
                    }
                    if (users.usr_estado == "B")
                    {
                        ViewBag.Message = "Usuario ingresado \"NO\"se encuentra activo";
                        return View("Vlogin");
                    }

                    //if (passwordencriptada == ConfigurationManager.AppSettings.Get("apppassword").ToString())
                    //{
                    //    return View("vregistrarse");
                    //}

                    Session["LastAccess"] = DateTime.Now;
                    Session["usrcod"] = users.usr_cod;
                    Session["usrlogin"] = users.usr_login;
                    Session["usrpasswordenc"] = users.usr_passwordenc;
                    Session["usrnombre"] = users.usr_nombre;
                    Session["usradministrador"] = users.usr_administrador;
                    Session["usrestado"] = users.usr_estado;
                    Session["usrfechacreacion"] = users.usr_fechacreacion;
                    Session["usrobservacion"] = users.usr_observacion;
                    Session["usradministrador_desc"] = users.usr_administrador_desc;
                    Session["usrestadodesc"] = users.usr_estado_desc;
                    Session["usrkam"] = "";

                    Session["UserSession"] = users;

                    return RedirectToAction("index", "Home", ViewBag);
                }
                catch (Exception pgMsg)
                {
                    var error = pgMsg.Message.ToString();
                    ViewBag.Message = error;
                    return View("Index", ViewBag.Message);
                }
            }
            else
            {
                ViewBag.Message = "Ingrese correctamente los datos.";
                return View("Index", ViewBag.Message);
            }
        }

        public class VkamViewModel
        {
            public List<UserProduccionDTO> Users { get; set; }
            public Mensajepantalla ErrorAcceso { get; set; }
        }

        public ActionResult ValidaUsuarioCambio(string usuario, string password, string password1, string password2)
        {
            UserProduccionDTO usuario1 = new UserProduccionDTO();

            // ... (resto del código sin cambios significativos)

            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(password1))
            {
                usuario1.usr_login = usuario;
                usuario1.usr_nombre = usuario;
                usuario1.usr_passwordenc = Encriptar.EncriptarPassword(password1);
                usuario1.usr_password = password1;
                string usr_passwordoriginal = Encriptar.EncriptarPassword(password);
                UsuarioService.usuario = usuario;
                UsuarioService.password = usr_passwordoriginal;

                UsuarioService._connectionstring = ConfigurationManager.AppSettings.Get("SQLSERVERORA").ToString();

                UserProduccionDTO users = UsuarioService.GetAllUsersByusuariopassword();

                if (UsuarioService.filasvalida > 0)
                {
                    var errorSP2 = UsuarioService.UpdateUserPassword(users.usr_cod, usuario1.usr_passwordenc);

                    ViewBag.Message = "Clave actualizada";
                    return RedirectToAction("vlogin", "Usuario");
                }
                else if (UsuarioService.filasvalida <= 0)
                {
                    // ... (resto del código sin cambios)
                }
            }
            else
            {
                ViewBag.Message = "Ingrese correctamente los datos.";
                return View("vcambioclave");
            }

            return RedirectToAction("vlogin", "Usuario");
        }
   
        public ActionResult Vlogout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            return View("vlogin");
        }
    }
}