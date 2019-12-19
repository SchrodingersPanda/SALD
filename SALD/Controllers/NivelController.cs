using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SALD.DAL;
using SALD.Models;

namespace SALD.Controllers
{
    public class NivelController : Controller
    {
        private SALDContext db = new SALDContext();

        // GET: Nivel
        public ActionResult Index()
        {
            return View(db.Niveles.ToList());
        }

        // GET: Nivel/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Niveles.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // GET: Nivel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nivel/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RangoEdad,CantAlumnos,Año,Periodo,Nombre")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                db.Niveles.Add(nivel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivel);
        }

        // GET: Nivel/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Niveles.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // POST: Nivel/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RangoEdad,CantAlumnos,Año,Periodo,Nombre")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivel);
        }

        // GET: Nivel/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Niveles.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // POST: Nivel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Nivel nivel = db.Niveles.Find(id);
            db.Niveles.Remove(nivel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
