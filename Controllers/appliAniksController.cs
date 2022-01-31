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
    public class appliAniksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: appliAniks
        public ActionResult Index()
        {
            var appliAniks = db.appliAniks.Include(a => a.namesAnik).Include(a => a.rollAnik);
            return View(appliAniks.ToList());
        }

        public ActionResult Success()
        {
           
            return View();
        }

        // GET: appliAniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appliAnik appliAnik = db.appliAniks.Find(id);
            if (appliAnik == null)
            {
                return HttpNotFound();
            }
            return View(appliAnik);
        }

        // GET: appliAniks/Create
        public ActionResult Create()
        {
            ViewBag.nid = new SelectList(db.namesAniks, "nid", "Name");
            ViewBag.rid = new SelectList(db.rollAniks, "rid", "Roll");
            return View();
        }

        // POST: appliAniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aid,nid,rid,title,requiredLeave,description")] appliAnik appliAnik)
        {
            if (ModelState.IsValid)
            {
                db.appliAniks.Add(appliAnik);
                db.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.nid = new SelectList(db.namesAniks, "nid", "Name", appliAnik.nid);
            ViewBag.rid = new SelectList(db.rollAniks, "rid", "Roll", appliAnik.rid);
            return View(appliAnik);
        }

        // GET: appliAniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appliAnik appliAnik = db.appliAniks.Find(id);
            if (appliAnik == null)
            {
                return HttpNotFound();
            }
            ViewBag.nid = new SelectList(db.namesAniks, "nid", "Name", appliAnik.nid);
            ViewBag.rid = new SelectList(db.rollAniks, "rid", "Roll", appliAnik.rid);
            return View(appliAnik);
        }

        // POST: appliAniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aid,nid,rid,title,requiredLeave,description")] appliAnik appliAnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appliAnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nid = new SelectList(db.namesAniks, "nid", "Name", appliAnik.nid);
            ViewBag.rid = new SelectList(db.rollAniks, "rid", "Roll", appliAnik.rid);
            return View(appliAnik);
        }

        // GET: appliAniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appliAnik appliAnik = db.appliAniks.Find(id);
            if (appliAnik == null)
            {
                return HttpNotFound();
            }
            return View(appliAnik);
        }

        // POST: appliAniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            appliAnik appliAnik = db.appliAniks.Find(id);
            db.appliAniks.Remove(appliAnik);
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
