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
    public class AdultoController : Controller
    {
        private SALDContext db = new SALDContext();

        // GET: Adulto
        public ActionResult Index()
        {
            var adultos = db.Adultos.Include(a => a.Alumno);
            return View(adultos.ToList());
        }

        // GET: Adulto/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adulto adulto = db.Adultos.Find(id);
            if (adulto == null)
            {
                return HttpNotFound();
            }
            return View(adulto);
        }

        // GET: Adulto/Create
        public ActionResult Create()
        {
            ViewBag.AlumnoID = new SelectList(db.Alumnos, "ID", "Nombre");
            return View();
        }

        // POST: Adulto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Apellido,Telefono,Email,AlumnoID")] Adulto adulto)
        {
            if (ModelState.IsValid)
            {
                db.Adultos.Add(adulto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlumnoID = new SelectList(db.Alumnos, "ID", "Nombre", adulto.AlumnoID);
            return View(adulto);
        }

        // GET: Adulto/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adulto adulto = db.Adultos.Find(id);
            if (adulto == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlumnoID = new SelectList(db.Alumnos, "ID", "Nombre", adulto.AlumnoID);
            return View(adulto);
        }

        // POST: Adulto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Apellido,Telefono,Email,AlumnoID")] Adulto adulto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adulto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlumnoID = new SelectList(db.Alumnos, "ID", "Nombre", adulto.AlumnoID);
            return View(adulto);
        }

        // GET: Adulto/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adulto adulto = db.Adultos.Find(id);
            if (adulto == null)
            {
                return HttpNotFound();
            }
            return View(adulto);
        }

        // POST: Adulto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Adulto adulto = db.Adultos.Find(id);
            db.Adultos.Remove(adulto);
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
