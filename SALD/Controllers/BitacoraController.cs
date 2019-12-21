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
    public class BitacoraController : Controller
    {
        private SALDContext db = new SALDContext();

        // GET: Bitacora
        public ActionResult Index()
        {
            var bitacoras = db.Bitacoras.Include(b => b.Planificacion)/*.Include(b => b.Sala)*/;
            return View(bitacoras.ToList());
        }

        // GET: Bitacora/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora bitacora = db.Bitacoras.Find(id);
            if (bitacora == null)
            {
                return HttpNotFound();
            }
            return View(bitacora);
        }

        // GET: Bitacora/Create
        public ActionResult Create()
        {
            ViewBag.PlanificacionID = new SelectList(db.Planificaciones, "ID", "ID");
            //ViewBag.SalaID = new SelectList(db.Salas, "ID", "NivelID");
            return View();
        }

        // POST: Bitacora/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Novedades,PlanificacionID")] Bitacora bitacora)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Bitacoras.Add(bitacora);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.PlanificacionID = new SelectList(db.Planificaciones, "ID", "ID", bitacora.PlanificacionID);
                //ViewBag.SalaID = new SelectList(db.Salas, "ID", "NivelID", bitacora.SalaID);
                return View(bitacora);
            }
            catch (Exception)
            {

                return View("ErrorBitacoraPK");
            }
            
        }

        // GET: Bitacora/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora bitacora = db.Bitacoras.Find(id);
            if (bitacora == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlanificacionID = new SelectList(db.Planificaciones, "ID", "ID", bitacora.PlanificacionID);
            //ViewBag.SalaID = new SelectList(db.Salas, "ID", "NivelID", bitacora.SalaID);
            return View(bitacora);
        }

        // POST: Bitacora/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Novedades,PlanificacionID")] Bitacora bitacora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bitacora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlanificacionID = new SelectList(db.Planificaciones, "ID", "ID", bitacora.PlanificacionID);
            //ViewBag.SalaID = new SelectList(db.Salas, "ID", "NivelID", bitacora.SalaID);
            return View(bitacora);
        }

        // GET: Bitacora/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora bitacora = db.Bitacoras.Find(id);
            if (bitacora == null)
            {
                return HttpNotFound();
            }
            return View(bitacora);
        }

        // POST: Bitacora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                Bitacora bitacora = db.Bitacoras.Find(id);
                db.Bitacoras.Remove(bitacora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("ErrorBitacora");
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
