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
    public class SalaController : Controller
    {
        private SALDContext db = new SALDContext();

        // GET: Sala
        public ActionResult Index()
        {
            var salas = db.Salas.Include(s => s.Nivel);
            return View(salas.ToList());
        }

        // GET: Sala/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // GET: Sala/Create
        public ActionResult Create()
        {
            ViewBag.NivelID = new SelectList(db.Niveles, "ID", "ID");
            return View();
        }

        // POST: Sala/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Horario,NivelID,Ast,Educ")] Sala sala)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Salas.Add(sala);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.NivelID = new SelectList(db.Niveles, "ID", "ID", sala.NivelID);
                return View(sala);
            }
            catch (Exception)
            {

                return View("ErrorSalaPK");
            }
           
        }

        // GET: Sala/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            ViewBag.NivelID = new SelectList(db.Niveles, "ID", "ID", sala.NivelID);
            return View(sala);
        }

        // POST: Sala/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Horario,NivelID,Ast,Educ")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NivelID = new SelectList(db.Niveles, "ID", "ID", sala.NivelID);
            return View(sala);
        }

        // GET: Sala/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // POST: Sala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                Sala sala = db.Salas.Find(id);
                db.Salas.Remove(sala);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("ErrorSala");
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
