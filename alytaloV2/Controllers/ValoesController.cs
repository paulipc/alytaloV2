using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using alytaloV2.Models;

namespace alytaloV2.Controllers
{
    public class ValoesController : Controller
    {
        private alytaloEntities db = new alytaloEntities();

        // GET: Valoes
        public ActionResult Index()
        {
            var valo = db.Valo.Include(v => v.Talo);
            return View(valo.ToList());
        }

        // GET: Valoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valo valo = db.Valo.Find(id);
            if (valo == null)
            {
                return HttpNotFound();
            }
            return View(valo);
        }

        // GET: Valoes/Create
        public ActionResult Create()
        {
            ViewBag.TaloId = new SelectList(db.Talo, "TaloId", "Kuvaus");
            return View();
        }

        // POST: Valoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ValoId,Kuvaus,TaloId,ValonMaara,ValoPaalla")] Valo valo)
        {
            if (ModelState.IsValid)
            {
                db.Valo.Add(valo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaloId = new SelectList(db.Talo, "TaloId", "Kuvaus", valo.TaloId);
            return View(valo);
        }

        // GET: Valoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valo valo = db.Valo.Find(id);
            if (valo == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaloId = new SelectList(db.Talo, "TaloId", "Kuvaus", valo.TaloId);
            return View(valo);
        }

        // POST: Valoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ValoId,Kuvaus,TaloId,ValonMaara,ValoPaalla")] Valo valo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaloId = new SelectList(db.Talo, "TaloId", "Kuvaus", valo.TaloId);
            return View(valo);
        }

        // GET: Valoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valo valo = db.Valo.Find(id);
            if (valo == null)
            {
                return HttpNotFound();
            }
            return View(valo);
        }

        // POST: Valoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valo valo = db.Valo.Find(id);
            db.Valo.Remove(valo);
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
