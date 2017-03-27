using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Entity;

namespace Bebidas.Controllers
{
    public class PresentacionController : Controller
    {
        private Entity_tallerBebidasEntities db = new Entity_tallerBebidasEntities();

        // GET: /Presentacion/
        public ActionResult Index()
        {
            return View(db.presentacion.ToList());
        }

        // GET: /Presentacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            presentacion presentacion = db.presentacion.Find(id);
            if (presentacion == null)
            {
                return HttpNotFound();
            }
            return View(presentacion);
        }

        // GET: /Presentacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Presentacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nombre,mililitros,valor_presentacion")] presentacion presentacion)
        {
            if (ModelState.IsValid)
            {
                db.presentacion.Add(presentacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(presentacion);
        }

        // GET: /Presentacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            presentacion presentacion = db.presentacion.Find(id);
            if (presentacion == null)
            {
                return HttpNotFound();
            }
            return View(presentacion);
        }

        // POST: /Presentacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nombre,mililitros,valor_presentacion")] presentacion presentacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presentacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(presentacion);
        }

        // GET: /Presentacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            presentacion presentacion = db.presentacion.Find(id);
            if (presentacion == null)
            {
                return HttpNotFound();
            }
            return View(presentacion);
        }

        // POST: /Presentacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            presentacion presentacion = db.presentacion.Find(id);
            db.presentacion.Remove(presentacion);
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
