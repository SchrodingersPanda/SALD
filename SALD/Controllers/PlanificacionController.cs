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
    public class PlanificacionController : Controller
    {
        private SALDContext db = new SALDContext();

        // GET: Planificacion
        public ActionResult Index()
        {
            //var planificaciones = db.Planificaciones.Include(p => p.Nivel).Include(p => p.Usuario);
            var planificaciones = db.Planificaciones.Include(p => p.Nivel);
            return View(planificaciones.ToList());
        }

        // GET: Planificacion/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planificacion planificacion = db.Planificaciones.Find(id);
            if (planificacion == null)
            {
                return HttpNotFound();
            }
            return View(planificacion);
        }

        // GET: Planificacion/Create
        public ActionResult Create()
        {
            ViewBag.NivelID = new SelectList(db.Niveles, "ID", "ID");
            //ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "ID");
            return View();
        }

        // POST: Planificacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Inicio,Termino,Encargado,Objetivos_prop,Objetivos_cump,Actividades_prop,Actividades_cump,NivelID,SalaID,NumeroR,Novedades,ListaAp")] Planificacion planificacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Planificaciones.Add(planificacion);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.NivelID = new SelectList(db.Niveles, "ID", "ID", planificacion.NivelID);
                //ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "ID", planificacion.UsuarioID);
                return View(planificacion);
            }
            catch (Exception)
            {

                return View("ErrorPlanificacionPK");
            }
            
        }

        // GET: Planificacion/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planificacion planificacion = db.Planificaciones.Find(id);
            if (planificacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.NivelID = new SelectList(db.Niveles, "ID", "ID", planificacion.NivelID);
            //ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "ID", planificacion.UsuarioID);
            return View(planificacion);
        }

        // POST: Planificacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Inicio,Termino,Encargado,Objetivos_prop,Objetivos_cump,Actividades_prop,Actividades_cump,NivelID,SalaID,NumeroR,Novedades,ListaAp")] Planificacion planificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NivelID = new SelectList(db.Niveles, "ID", "ID", planificacion.NivelID);
            //ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "ID", planificacion.UsuarioID);
            return View(planificacion);
        }

        // GET: Planificacion/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planificacion planificacion = db.Planificaciones.Find(id);
            if (planificacion == null)
            {
                return HttpNotFound();
            }
            return View(planificacion);
        }

        // POST: Planificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                Planificacion planificacion = db.Planificaciones.Find(id);
                db.Planificaciones.Remove(planificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("ErrorPlanificacion");
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
