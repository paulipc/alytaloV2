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
    public class TaloesController : Controller
    {
        private alytaloEntities db = new alytaloEntities();

        // GET: Taloes
        public ActionResult Index()
        {
            return View(db.Talo.ToList());
        }

        // GET: Taloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talo talo = db.Talo.Find(id);
            if (talo == null)
            {
                return HttpNotFound();
            }
            return View(talo);
        }

        // GET: Taloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Taloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaloId,Kuvaus,NykyLampo,TavoiteLampo")] Talo talo)
        {
            if (ModelState.IsValid)
            {
                db.Talo.Add(talo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talo);
        }

        // GET: Taloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talo talo = db.Talo.Find(id);
            if (talo == null)
            {
                return HttpNotFound();
            }
            return View(talo);
        }

        // POST: Taloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaloId,Kuvaus,NykyLampo,TavoiteLampo")] Talo talo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talo);
        }

        // GET: Taloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talo talo = db.Talo.Find(id);
            if (talo == null)
            {
                return HttpNotFound();
            }
            return View(talo);
        }

        // POST: Taloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Talo talo = db.Talo.Find(id);
            db.Talo.Remove(talo);
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
