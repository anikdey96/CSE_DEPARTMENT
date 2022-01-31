using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSE_DEPARTMENT.Models;

namespace CSE_DEPARTMENT.Controllers
{
    public class rollMahinsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: rollMahins
        public ActionResult Index()
        {
            return View(db.rollMahins.ToList());
        }

        // GET: rollMahins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rollMahin rollMahin = db.rollMahins.Find(id);
            if (rollMahin == null)
            {
                return HttpNotFound();
            }
            return View(rollMahin);
        }

        // GET: rollMahins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rollMahins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rid,Roll")] rollMahin rollMahin)
        {
            if (ModelState.IsValid)
            {
                db.rollMahins.Add(rollMahin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rollMahin);
        }

        // GET: rollMahins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rollMahin rollMahin = db.rollMahins.Find(id);
            if (rollMahin == null)
            {
                return HttpNotFound();
            }
            return View(rollMahin);
        }

        // POST: rollMahins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rid,Roll")] rollMahin rollMahin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rollMahin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rollMahin);
        }

        // GET: rollMahins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rollMahin rollMahin = db.rollMahins.Find(id);
            if (rollMahin == null)
            {
                return HttpNotFound();
            }
            return View(rollMahin);
        }

        // POST: rollMahins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rollMahin rollMahin = db.rollMahins.Find(id);
            db.rollMahins.Remove(rollMahin);
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
