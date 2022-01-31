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
    public class nameMahinsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: nameMahins
        public ActionResult Index()
        {
            return View(db.nameMahins.ToList());
        }

        // GET: nameMahins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nameMahin nameMahin = db.nameMahins.Find(id);
            if (nameMahin == null)
            {
                return HttpNotFound();
            }
            return View(nameMahin);
        }

        // GET: nameMahins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: nameMahins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nid,Name")] nameMahin nameMahin)
        {
            if (ModelState.IsValid)
            {
                db.nameMahins.Add(nameMahin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nameMahin);
        }

        // GET: nameMahins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nameMahin nameMahin = db.nameMahins.Find(id);
            if (nameMahin == null)
            {
                return HttpNotFound();
            }
            return View(nameMahin);
        }

        // POST: nameMahins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nid,Name")] nameMahin nameMahin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nameMahin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nameMahin);
        }

        // GET: nameMahins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nameMahin nameMahin = db.nameMahins.Find(id);
            if (nameMahin == null)
            {
                return HttpNotFound();
            }
            return View(nameMahin);
        }

        // POST: nameMahins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nameMahin nameMahin = db.nameMahins.Find(id);
            db.nameMahins.Remove(nameMahin);
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
