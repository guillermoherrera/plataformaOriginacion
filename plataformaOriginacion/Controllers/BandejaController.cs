using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using plataformaOriginacion.Models;
using Serilog;

namespace plataformaOriginacion.Controllers
{
    public class BandejaController : Controller
    {
        public const string SessionKeyNombre = "_Nombre";
        List<Solicitud> solicitudes = new List<Solicitud>();
        
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyNombre)))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.usuario = HttpContext.Session.GetString(SessionKeyNombre);
                return View();
            }
        }

        [HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
        {
            solicitudes.Clear();
            solicitudes = await FireStore.GetSolicitudesFromFireStore();
            return DataSourceLoader.Load(solicitudes, loadOptions);
        }

        public ActionResult PartialViews()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyNombre)))
            {
                return PartialView("_Mensaje");
            }
            else
            {
                return PartialView("_Solicitudes");
            }
        }

        public async Task<IActionResult> Detalle(String _ID, bool result, String mensaje) {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyNombre)))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Solicitud solicitud = new Solicitud();
                List<catDocumento> catDocumentos = new List<catDocumento>();
                ViewBag.usuario = HttpContext.Session.GetString(SessionKeyNombre);
                try{
                    solicitud = await FireStore.GetSolicitudFromFireStore(_ID);
                    catDocumentos = await FireStore.GetCatDocumentosFromFirestore();
                    if (solicitud.solicitudID != null){
                        ViewBag.solicitud = solicitud;
                        ViewBag.catDocumentos = catDocumentos;
                        //mensaje notice
                        ViewBag.result = result;
                        ViewBag.mensaje = mensaje;
                    }
                    else {
                        ViewBag.error = solicitud.grupoNombre;//Auxiliar para mostrar un mensaje de error
                    }
                }
                catch (Exception ex) {
                    ViewBag.error = ex.ToString();
                    Log.Information("*****Error Exception Detalle: {0}", ex.Message);
                }
                return View();
            }
        }

        public async Task<IActionResult> DetalleGrupo(String _ID) {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyNombre)))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<Solicitud> solicitudes = new List<Solicitud>();
                try{
                    solicitudes = await FireStore.GetGrupoFromFireStore(_ID);
                    if (solicitudes.Count > 0){
                        ViewBag.solicitudes = solicitudes;
                        ViewBag.importeTotal = solicitudes.Sum(item => item.importe);
                        ViewBag.dictaminable = true;
                        ViewBag.dictamen = solicitudes[0].dictamen;
                        foreach (Solicitud solicitud in solicitudes)
                        {
                            if (solicitud.status != 2 && solicitud.status != 3){
                                ViewBag.dictaminable = false;
                            }
                        }
                    }
                    else{
                        ViewBag.error = "Grupo sin Integrantes X_X";
                    }
                }catch(Exception ex){
                    ViewBag.error = ex.ToString();
                    Log.Information("*****Error Exception DetalleGrupo: {0}", ex.Message);
                }
                return View();
            }
        }

        public IActionResult Documento(string documentoUrlBase64) {
            ViewBag.noNadvar = true;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyNombre)))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var base64EncodedBytes = System.Convert.FromBase64String(documentoUrlBase64);
                ViewBag.imagen = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                return View();
            }
        }

        public async Task<IActionResult> cambioEstado(String _ID, int status, String grupo) {
            bool result = await FireStore.CambioEstado(_ID, status, grupo);
            String mensaje;
            mensaje = result ? "" : "NO ";
            switch (status) {
                case 7:
                    mensaje += "SE HA AUTORIZADO LA CONSULTA DE BURÓ PARA ESTA SOLICITUD.";
                    break;
                case 3:
                    mensaje += "SE HA DENEGADO LA SOLICITUD.";
                    break;
                default:
                    mensaje += "SE REALIZO ALGUNA ACCIÓN.";
                    break;
            }
            return RedirectToAction("Detalle", new { _ID = _ID, result = result, mensaje = mensaje });
        }

        public async Task<IActionResult> grupoDictamen(string _ID, int aut) {
            bool result = await FireStore.DictamenGrupo(_ID, aut);
            String mensaje;
            mensaje = result ? "" : "NO ";
            switch (aut)
            {
                case 0:
                    mensaje += "SE HA DENEGADO EL GRUPO.";
                    break;
                case 1:
                    mensaje += "SE HA AUTORIZADO EL GRUPO.";
                    break;
                default:
                    mensaje += "SE REALIZO ALGUNA ACCIÓN.";
                    break;
            }
            Log.Information("*****INFORMATION grupoDictamen: {0}", mensaje);
            return RedirectToAction("DetalleGrupo", new {_ID = _ID});
        }

        /* GET: Bandeja/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bandeja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bandeja/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bandeja/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bandeja/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bandeja/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bandeja/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}