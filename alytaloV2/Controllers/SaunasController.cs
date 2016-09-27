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
    public class SaunasController : Controller
    {
        private alytaloEntities db = new alytaloEntities();

        // GET: Saunas
        public ActionResult Index()
        {
            var sauna = db.Sauna.Include(s => s.Talo);
            return View(sauna.ToList());
        }

        // GET: Saunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sauna sauna = db.Sauna.Find(id);
            if (sauna == null)
            {
                return HttpNotFound();
            }
            return View(sauna);
        }

        // GET: Saunas/Create
        public ActionResult Create()
        {
            ViewBag.TaloId = new SelectList(db.Talo, "TaloId", "Kuvaus");
            return View();
        }

        // POST: Saunas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaunaId,Kuvaus,TaloId,Lampotila,SaunaPaalla")] Sauna sauna)
        {
            if (ModelState.IsValid)
            {
                db.Sauna.Add(sauna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaloId = new SelectList(db.Talo, "TaloId", "Kuvaus", sauna.TaloId);
            return View(sauna);
        }

        // GET: Saunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sauna sauna = db.Sauna.Find(id);
            if (sauna == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaloId = new SelectList(db.Talo, "TaloId", "Kuvaus", sauna.TaloId);
            return View(sauna);
        }

        // POST: Saunas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaunaId,Kuvaus,TaloId,Lampotila,SaunaPaalla")] Sauna sauna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sauna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaloId = new SelectList(db.Talo, "TaloId", "Kuvaus", sauna.TaloId);
            return View(sauna);
        }

        // GET: Saunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sauna sauna = db.Sauna.Find(id);
            if (sauna == null)
            {
                return HttpNotFound();
            }
            return View(sauna);
        }

        // POST: Saunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sauna sauna = db.Sauna.Find(id);
            db.Sauna.Remove(sauna);
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
