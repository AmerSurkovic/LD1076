using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebServis.Models;
using WebServis.SRSPS.Models;

namespace WebServis.SRSPS.Controllers
{
    public class Termin2Controller : Controller
    {
        private SRSPSDB db = new SRSPSDB();

        // GET: Termin2
        public ActionResult Index()
        {
            return View(db.Termins.ToList());
        }

        // GET: Termin2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termin termin = db.Termins.Find(id);
            if (termin == null)
            {
                return HttpNotFound();
            }
            return View(termin);
        }

        // GET: Termin2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Termin2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerminID,vrijemePocetka,vrijemeZavrsetka")] Termin termin)
        {
            if (ModelState.IsValid)
            {
                db.Termins.Add(termin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(termin);
        }

        // GET: Termin2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termin termin = db.Termins.Find(id);
            if (termin == null)
            {
                return HttpNotFound();
            }
            return View(termin);
        }

        // POST: Termin2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerminID,vrijemePocetka,vrijemeZavrsetka")] Termin termin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(termin);
        }

        // GET: Termin2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termin termin = db.Termins.Find(id);
            if (termin == null)
            {
                return HttpNotFound();
            }
            return View(termin);
        }

        // POST: Termin2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Termin termin = db.Termins.Find(id);
            db.Termins.Remove(termin);
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
