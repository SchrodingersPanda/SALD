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
    public class AlumnoController : Controller
    {
        private SALDContext db = new SALDContext();

        // GET: Alumno
        public ActionResult Index()
        {
            var alumnos = db.Alumnos.Include(a => a.Nivel);
            return View(alumnos.ToList());
        }

        // GET: Alumno/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            ViewBag.NivelID = new SelectList(db.Niveles, "ID", "ID");
            return View();
        }

        // POST: Alumno/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Apellido,FechaNAc,HojaVida,AdultoID,NivelID")] Alumno alumno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Alumnos.Add(alumno);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.NivelID = new SelectList(db.Niveles, "ID", "ID", alumno.NivelID);
                return View(alumno);
            }
            catch (Exception)
            {

                return View("ErrorAlumnoPK");
            }
            
        }

        // GET: Alumno/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.NivelID = new SelectList(db.Niveles, "ID", "ID", alumno.NivelID);
            return View(alumno);
        }

        // POST: Alumno/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Apellido,FechaNAc,HojaVida,AdultoID,NivelID")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NivelID = new SelectList(db.Niveles, "ID", "ID", alumno.NivelID);
            return View(alumno);
        }

        // GET: Alumno/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumnos.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                Alumno alumno = db.Alumnos.Find(id);
                db.Alumnos.Remove(alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("ErrorAlumno");
            }
            
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
