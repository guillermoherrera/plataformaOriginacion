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
        public const string SessionKeyId = "_Id";
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
                List<CatEstado> catEstados = new List<CatEstado>();
                catEstados = CatEstado.fillEstados();
                ViewBag.usuario = HttpContext.Session.GetString(SessionKeyNombre);
                string execeptionMsg;
                try {
                    solicitud = await FireStore.GetSolicitudFromFireStore(_ID);
                    if (solicitud.mesaControlID == null && solicitud.grupoID == null)
                    {
                        if (await FireStore.SetControlId(_ID, HttpContext.Session.GetString(SessionKeyId), HttpContext.Session.GetString(SessionKeyNombre), false)){
                            solicitud.mesaControlID = HttpContext.Session.GetString(SessionKeyId);
                        }
                    }
                    else if (solicitud.mesaControlID != HttpContext.Session.GetString(SessionKeyId) && solicitud.dictamen == null)
                    {
                        execeptionMsg = solicitud.mesaControlID == null ? "" : "Esta solicitud ya esta siendo atendida por " + solicitud.mesaControlUsuario + ".";
                        throw new Exception(execeptionMsg);
                    }
                    catDocumentos = await FireStore.GetCatDocumentosFromFirestore();
                    if (solicitud.documentos.Find(x => x.solicitudCambio == true) != null && solicitud.status != 6)
                    {
                        await FireStore.CambioEstado(_ID, 6, null, 0, null);
                        return RedirectToAction("Detalle", new { _ID = _ID });
                    }
                    if (solicitud.solicitudID != null){
                        ViewBag.solicitud = solicitud;
                        ViewBag.catDocumentos = catDocumentos;
                        ViewBag.catEstados = catEstados;
                        ViewBag.estado = catEstados.Find(x => x.clave == solicitud.direccion.estado).estado;
                        //mensaje notice
                        ViewBag.result = result;
                        ViewBag.mensaje = mensaje;
                        ViewBag.liberable = solicitud.documentos.Where(doc => doc.version != 1).Count() > 0 ? false : true;
                    }
                    else {
                        ViewBag.error = solicitud.grupoNombre;//Auxiliar para mostrar un mensaje de error
                    }
                }
                catch (Exception ex) {
                    ViewBag.error = "Error al obtener datos. \n"+ex.Message;
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
                GrupoDetalle grupoDetalle = new GrupoDetalle();
                //List<Solicitud> solicitudes = new List<Solicitud>();
                ViewBag.usuario = HttpContext.Session.GetString(SessionKeyNombre);
                try
                {
                    grupoDetalle = await FireStore.GetGrupoFromFireStore(_ID);
                    if (grupoDetalle.grupo.mesaControlID == null)
                    {
                        await FireStore.SetControlId(_ID, HttpContext.Session.GetString(SessionKeyId), HttpContext.Session.GetString(SessionKeyNombre), true);
                    }
                    else if (grupoDetalle.grupo.mesaControlID != HttpContext.Session.GetString(SessionKeyId) && grupoDetalle.grupo.status == 2)
                    {
                        throw new Exception("Este grupo ya esta siendo atendido por " + grupoDetalle.grupo.mesaControlUsuario + ".");
                    }
                    if (grupoDetalle.solicitudes.Count > 0){
                        ViewBag.grupo = grupoDetalle.grupo;
                        ViewBag.solicitudes = grupoDetalle.solicitudes;
                        ViewBag.importeTotal = grupoDetalle.solicitudes.Sum(item => item.importe);
                        ViewBag.dictaminable = true;
                        ViewBag.liberable = true;
                        ViewBag.dictamen = grupoDetalle.solicitudes[0].dictamen;
                        foreach (Solicitud solicitud in grupoDetalle.solicitudes)
                        {
                            if (solicitud.status != 2 && solicitud.status != 3){
                                ViewBag.dictaminable = false;
                            }
                            if(solicitud.documentos.Where(doc => doc.version != 1).Count() > 0) { ViewBag.liberable = false; }
                        }
                        if (grupoDetalle.solicitudes.Where(sol => sol.status != 1).Count() > 0) { ViewBag.liberable = false; }
                        if (grupoDetalle.solicitudes.Where(sol => sol.mesaControlID == null).Count() > 0) { await FireStore.SetControlId(_ID, HttpContext.Session.GetString(SessionKeyId), HttpContext.Session.GetString(SessionKeyNombre), true); }
                    }
                    else{
                        ViewBag.error = "Grupo sin Integrantes X_X";
                    }
                }catch(Exception ex){
                    ViewBag.error = ex.Message;
                    Log.Information("*****Error Exception DetalleGrupo: {0}", ex.Message);
                }
                return View();
            }
        }

        public async Task<IActionResult> Integrantes(String _ID) {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyNombre)))
            {
                return PartialView("_Mensaje");
            }
            else
            {
                GrupoDetalle grupoDetalle = new GrupoDetalle();
                //List<Solicitud> solicitudes = new List<Solicitud>();
                try
                {
                    grupoDetalle = await FireStore.GetGrupoFromFireStore(_ID);
                    if (grupoDetalle.solicitudes.Count > 0)
                    {
                        ViewBag.grupo = grupoDetalle.grupo;
                        ViewBag.solicitudes = grupoDetalle.solicitudes;
                        ViewBag.importeTotal = grupoDetalle.solicitudes.Sum(item => item.importe);
                        ViewBag.dictaminable = true;
                        ViewBag.liberable = true;
                        ViewBag.dictamen = grupoDetalle.solicitudes[0].dictamen;
                        foreach (Solicitud solicitud in grupoDetalle.solicitudes)
                        {
                            if (solicitud.status != 2 && solicitud.status != 3)
                            {
                                ViewBag.dictaminable = false;
                            }
                            else
                            {
                                ViewBag.liberable = false;
                            }
                        }
                    }
                    else
                    {
                        ViewBag.error = "Grupo sin Integrantes X_X";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.ToString();
                    Log.Information("*****Error Exception DetalleGrupo: {0}", ex.Message);
                }
                return PartialView("_Integrantes");
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
            bool result = await FireStore.CambioEstado(_ID, status, grupo, 0, null);
            String mensaje;
            mensaje = result ? "" : "NO ";
            switch (status) {
                case 7:
                    mensaje += "SE HA AUTORIZADO LA CONSULTA DE BURÓ PARA ESTA SOLICITUD.";
                    break;
                case 3:
                    mensaje += "SE HA RECHAZADO LA SOLICITUD.";
                    break;
                case 2:
                    mensaje += "SE HA DICTAMINADO LA SOLICITUD.";
                    break;
                default:
                    mensaje += "SE REALIZO ALGUNA ACCIÓN.";
                    break;
            }
            return RedirectToAction("Detalle", new { _ID = _ID, result = result, mensaje = mensaje });
        }

        public async Task<IActionResult> grupoDictamen(string _ID, int aut) {
            if (aut != 1)
            {
                //BAD REQUEST
                return RedirectToAction("DetalleGrupo", new { _ID = _ID });
            }
            else
            {
                bool result = await FireStore.DictamenGrupo(_ID, aut, null);
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
                return RedirectToAction("DetalleGrupo", new { _ID = _ID });
            }
        }

        [HttpPost]
        public async Task<JsonResult> RechazarGrupo(Dictamen dictamen){
            bool result = await FireStore.DictamenGrupo(dictamen.grupoID, 0, dictamen.motivoRechazo);
            if (result)
            {
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { Success = false });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Dictaminar(Dictamen dictamen)
        {
            string resultado = "";
            bool result = await FireStore.CambioEstado(dictamen.idDocumento, int.Parse(dictamen.status), dictamen.grupoID, double.Parse(dictamen.monto), dictamen.motivoRechazo);
            if (result)
            {
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { Success = false });
            }
            
        }

        [HttpPost]
        public async Task<JsonResult> Liberar(Dictamen dictamen)
        {
            string id = dictamen.grupoID == null ? dictamen.idDocumento : dictamen.grupoID;
            bool grupo = dictamen.grupoID == null ? false : true;
            bool result = await FireStore.SetControlId(id, null, null, grupo);
            if (result)
            {
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { Success = false });
            }
        }

        [HttpPost]
        public async Task<JsonResult> CambioDocumento(CambioDoc cambioDoc)
        {
            string resultado = "";
            if (await FireStore.solicitarCambioDoc(cambioDoc))
            {
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { Success = false });
            }

        }

        [HttpPost]
        public async Task<JsonResult> ActualizaInformacion(ActualizaInformacion actualizaInformacion)
        {
            if (await FireStore.ActualizaIdentificacion(actualizaInformacion))
            {
                return Json(new { Success = true });
            }
            else {
                return Json(new { Success = false });
            }
        }

        [HttpPost]
        public async Task<JsonResult> ActualizaUbicacion(ActualizaUbicacion actualizaUbicacion)
        {
            if (await FireStore.ActualizaUbicacion(actualizaUbicacion))
            {
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { Success = false });
            }
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