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
    public class TipoCervezaController : Controller
    {
        private Entity_tallerBebidasEntities db = new Entity_tallerBebidasEntities();

        // GET: /TipoCerveza/
        public ActionResult Index()
        {
            return View(db.tipo_cerveza.ToList());
        }

        // GET: /TipoCerveza/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_cerveza tipo_cerveza = db.tipo_cerveza.Find(id);
            if (tipo_cerveza == null)
            {
                return HttpNotFound();
            }
            return View(tipo_cerveza);
        }

        // GET: /TipoCerveza/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoCerveza/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,nombre,descripcion,alcohol")] tipo_cerveza tipo_cerveza)
        {
            if (ModelState.IsValid)
            {
                db.tipo_cerveza.Add(tipo_cerveza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_cerveza);
        }

        // GET: /TipoCerveza/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_cerveza tipo_cerveza = db.tipo_cerveza.Find(id);
            if (tipo_cerveza == null)
            {
                return HttpNotFound();
            }
            return View(tipo_cerveza);
        }

        // POST: /TipoCerveza/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,nombre,descripcion,alcohol")] tipo_cerveza tipo_cerveza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_cerveza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_cerveza);
        }

        // GET: /TipoCerveza/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_cerveza tipo_cerveza = db.tipo_cerveza.Find(id);
            if (tipo_cerveza == null)
            {
                return HttpNotFound();
            }
            return View(tipo_cerveza);
        }

        // POST: /TipoCerveza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipo_cerveza tipo_cerveza = db.tipo_cerveza.Find(id);
            db.tipo_cerveza.Remove(tipo_cerveza);
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
