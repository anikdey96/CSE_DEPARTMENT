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
    public class rollAniksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: rollAniks
        public ActionResult Index()
        {
            return View(db.rollAniks.ToList());
        }

        // GET: rollAniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rollAnik rollAnik = db.rollAniks.Find(id);
            if (rollAnik == null)
            {
                return HttpNotFound();
            }
            return View(rollAnik);
        }

        // GET: rollAniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rollAniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rid,Roll")] rollAnik rollAnik)
        {
            if (ModelState.IsValid)
            {
                db.rollAniks.Add(rollAnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rollAnik);
        }

        // GET: rollAniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rollAnik rollAnik = db.rollAniks.Find(id);
            if (rollAnik == null)
            {
                return HttpNotFound();
            }
            return View(rollAnik);
        }

        // POST: rollAniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rid,Roll")] rollAnik rollAnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rollAnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rollAnik);
        }

        // GET: rollAniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rollAnik rollAnik = db.rollAniks.Find(id);
            if (rollAnik == null)
            {
                return HttpNotFound();
            }
            return View(rollAnik);
        }

        // POST: rollAniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rollAnik rollAnik = db.rollAniks.Find(id);
            db.rollAniks.Remove(rollAnik);
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
