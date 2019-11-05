using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using plataformaOriginacion.Models;
using Serilog;

namespace plataformaOriginacion.Controllers
{
    public class HomeController : Controller
    {

        public const string SessionKeyNombre = "_Nombre";
        public const string SessionKeyId = "_Id";

        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyNombre)))
            {

                return RedirectToAction("Index", "Bandeja");
            }
            else {
                ViewBag.usuario = HttpContext.Session.GetString(SessionKeyNombre);
                ViewBag.session = false;
                return View();
            }
            
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            ViewBag.session = false;
            if (ModelState.IsValid)
            {
                HttpStatusCode res_code = HttpStatusCode.InternalServerError;
                string resultado = "error";

                try
                {
                    LoginRequestApp datos = new LoginRequestApp(model.input.User, model.input.Password);
                    Usuario usuario = new Usuario();
                    //if (SolicitudesController.LoginApp(datos, ref resultado, usuario))
                    if(Session.LoginApp(datos, ref resultado, usuario))
                    {
                        
                        res_code = HttpStatusCode.Created;
                        if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyNombre)))
                        {
                            HttpContext.Session.SetString(SessionKeyNombre, usuario.nombre);
                            HttpContext.Session.SetString(SessionKeyId, usuario.id);

                            Log.Information("usuario logueado: {0}", usuario.nombre);

                            return RedirectToAction("Index", "Bandeja");
                        }
                        else
                        {
                            HttpContext.Session.Remove(SessionKeyNombre);
                            ModelState.AddModelError("Error", "Ha ocurrido un error al iniciar sesión, vuelva a intentarlo porfavor.");
                            return View(model);
                        }
                    }
                    else
                    {
                        res_code = HttpStatusCode.OK;
                        ModelState.AddModelError("Error", resultado);
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    res_code = HttpStatusCode.InternalServerError;
                    ModelState.AddModelError("Error", "Ha ocurrido un error al iniciar sesión, vuelva a intentarlo porfavor.");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult cerrarSesion()
        {
            HttpContext.Session.Remove(SessionKeyNombre);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            ViewBag.usuario = HttpContext.Session.GetString(SessionKeyNombre);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
