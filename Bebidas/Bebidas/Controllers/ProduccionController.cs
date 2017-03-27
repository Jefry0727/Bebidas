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
    public class ProduccionController : Controller
    {
        private Entity_tallerBebidasEntities db = new Entity_tallerBebidasEntities();

        // GET: /Produccion/
        public ActionResult Index()
        {
            var produccion = db.produccion.Include(p => p.presentacion).Include(p => p.tipo_cerveza);
            return View(produccion.ToList());
        }

        // GET: /Produccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produccion produccion = db.produccion.Find(id);
            if (produccion == null)
            {
                return HttpNotFound();
            }
            return View(produccion);
        }

        // GET: /Produccion/Create
        public ActionResult Create()
        {
            ViewBag.presentacion_id = new SelectList(db.presentacion, "id", "nombre");
            ViewBag.tipo_cerveza_id = new SelectList(db.tipo_cerveza, "id", "nombre");
            return View();
        }

        // POST: /Produccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,codigo_lote,fecha,comentarios,cantidad,presentacion_id,tipo_cerveza_id")] produccion produccion)
        {
            if (ModelState.IsValid)
            {
                db.produccion.Add(produccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.presentacion_id = new SelectList(db.presentacion, "id", "nombre", produccion.presentacion_id);
            ViewBag.tipo_cerveza_id = new SelectList(db.tipo_cerveza, "id", "nombre", produccion.tipo_cerveza_id);
            return View(produccion);
        }

        // GET: /Produccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produccion produccion = db.produccion.Find(id);
            if (produccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.presentacion_id = new SelectList(db.presentacion, "id", "nombre", produccion.presentacion_id);
            ViewBag.tipo_cerveza_id = new SelectList(db.tipo_cerveza, "id", "nombre", produccion.tipo_cerveza_id);
            return View(produccion);
        }

        // POST: /Produccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,codigo_lote,fecha,comentarios,cantidad,presentacion_id,tipo_cerveza_id")] produccion produccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.presentacion_id = new SelectList(db.presentacion, "id", "nombre", produccion.presentacion_id);
            ViewBag.tipo_cerveza_id = new SelectList(db.tipo_cerveza, "id", "nombre", produccion.tipo_cerveza_id);
            return View(produccion);
        }

        // GET: /Produccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produccion produccion = db.produccion.Find(id);
            if (produccion == null)
            {
                return HttpNotFound();
            }
            return View(produccion);
        }

        // POST: /Produccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produccion produccion = db.produccion.Find(id);
            db.produccion.Remove(produccion);
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
