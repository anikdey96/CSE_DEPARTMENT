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
    public class appliMahinsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: appliMahins
        public ActionResult Index()
        {
            var appliMahins = db.appliMahins.Include(a => a.nameMahin).Include(a => a.rollMahin);
            return View(appliMahins.ToList());
        }

        public ActionResult Success()
        {

            return View();
        }

        // GET: appliMahins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appliMahin appliMahin = db.appliMahins.Find(id);
            if (appliMahin == null)
            {
                return HttpNotFound();
            }
            return View(appliMahin);
        }

        // GET: appliMahins/Create
        public ActionResult Create()
        {
            ViewBag.nid = new SelectList(db.nameMahins, "nid", "Name");
            ViewBag.rid = new SelectList(db.rollMahins, "rid", "Roll");
            return View();
        }

        // POST: appliMahins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(appliMahin appliMahin)
        {
            if (ModelState.IsValid)
            {
                db.appliMahins.Add(appliMahin);
                db.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.nid = new SelectList(db.nameMahins, "nid", "Name", appliMahin.nid);
            ViewBag.rid = new SelectList(db.rollMahins, "rid", "Roll", appliMahin.rid);
            return View(appliMahin);
        }

        // GET: appliMahins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appliMahin appliMahin = db.appliMahins.Find(id);
            if (appliMahin == null)
            {
                return HttpNotFound();
            }
            ViewBag.nid = new SelectList(db.nameMahins, "nid", "Name", appliMahin.nid);
            ViewBag.rid = new SelectList(db.rollMahins, "rid", "Roll", appliMahin.rid);
            return View(appliMahin);
        }

        // POST: appliMahins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aid,nid,rid,title,requiredLeave,description")] appliMahin appliMahin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appliMahin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nid = new SelectList(db.nameMahins, "nid", "Name", appliMahin.nid);
            ViewBag.rid = new SelectList(db.rollMahins, "rid", "Roll", appliMahin.rid);
            return View(appliMahin);
        }

        // GET: appliMahins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appliMahin appliMahin = db.appliMahins.Find(id);
            if (appliMahin == null)
            {
                return HttpNotFound();
            }
            return View(appliMahin);
        }

        // POST: appliMahins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            appliMahin appliMahin = db.appliMahins.Find(id);
            db.appliMahins.Remove(appliMahin);
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
