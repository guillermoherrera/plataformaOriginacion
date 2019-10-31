using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace plataformaOriginacion.Controllers
{
    public class BandejaController : Controller
    {
        public const string SessionKeyNombre = "_Nombre";
        // GET: Bandeja
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

        // GET: Bandeja/Details/5
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
        }
    }
}