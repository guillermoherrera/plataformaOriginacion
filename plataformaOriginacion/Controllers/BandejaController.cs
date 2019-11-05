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
        // GET: Bandeja
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyNombre)))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //GetFromFireStore();
                ViewBag.usuario = HttpContext.Session.GetString(SessionKeyNombre);
                return View();
            }
        }

        [HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
        {
            solicitudes.Clear();
            await GetFromFireStore();
            return DataSourceLoader.Load(solicitudes, loadOptions);
        }

        public async Task GetFromFireStore(){
            try
            {
                List<Solicitud> solicitudesAll = new List<Solicitud>();
                var credential = GoogleCredential.FromFile("C:\\Users\\gherr\\Downloads\\SGCC-d42386a165af.json"); ;
                Channel channel = new Channel(FirestoreClient.DefaultEndpoint.Host, FirestoreClient.DefaultEndpoint.Port, credential.ToChannelCredentials());
                FirestoreClient client = FirestoreClient.Create(channel);

                FirestoreDb db = FirestoreDb.Create("sgcc-57fde", client);
                CollectionReference collection = db.Collection("Solicitudes");
                
                QuerySnapshot allSolicitudes = await collection.GetSnapshotAsync();
                
                foreach (DocumentSnapshot document in allSolicitudes.Documents) {
                    Solicitud solicitud = document.ConvertTo<Solicitud>();
                    solicitud.solicitudID = document.Id;
                    solicitud.fechaCaputra = solicitud.fechaCaputra;//.AddHours(-6);
                    solicitud.persona.fechaNacimiento = solicitud.persona.fechaNacimiento;//.AddHours(-6);
                    solicitudesAll.Add(solicitud);
                }

                foreach (Solicitud solicitud in solicitudesAll) {
                    if (solicitud.grupoID == null) {
                        solicitudes.Add(solicitud);
                    }
                    else {
                        var res = solicitudes.Find(s => s.grupoID == solicitud.grupoID);
                        if (res == null){
                            solicitudes.Add(solicitud);
                        }
                        else {
                            double importe = solicitudes.Find(s => s.grupoID == solicitud.grupoID).importe;
                            solicitudes.Find(s => s.grupoID == solicitud.grupoID).importe = importe + solicitud.importe;
                        }
                    }
                }
            }
            catch (Exception e) {
                Log.Information("**Error Exception {0}", e.Message);
                ViewBag.errores = "Error en conexión a FSBD";
            }
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