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
    public class namesAniksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: namesAniks
        public ActionResult Index()
        {
            return View(db.namesAniks.ToList());
        }

        // GET: namesAniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            namesAnik namesAnik = db.namesAniks.Find(id);
            if (namesAnik == null)
            {
                return HttpNotFound();
            }
            return View(namesAnik);
        }

        // GET: namesAniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: namesAniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nid,Name")] namesAnik namesAnik)
        {
            if (ModelState.IsValid)
            {
                db.namesAniks.Add(namesAnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(namesAnik);
        }

        // GET: namesAniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            namesAnik namesAnik = db.namesAniks.Find(id);
            if (namesAnik == null)
            {
                return HttpNotFound();
            }
            return View(namesAnik);
        }

        // POST: namesAniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nid,Name")] namesAnik namesAnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(namesAnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(namesAnik);
        }

        // GET: namesAniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            namesAnik namesAnik = db.namesAniks.Find(id);
            if (namesAnik == null)
            {
                return HttpNotFound();
            }
            return View(namesAnik);
        }

        // POST: namesAniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            namesAnik namesAnik = db.namesAniks.Find(id);
            db.namesAniks.Remove(namesAnik);
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
