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
    public class appliImrulsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: appliImruls
        public ActionResult Index()
        {
            var appliImruls = db.appliImruls.Include(a => a.nameImrul);
            return View(appliImruls.ToList());
        }

        public ActionResult Success()
        {

            return View();
        }

        // GET: appliImruls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appliImrul appliImrul = db.appliImruls.Find(id);
            if (appliImrul == null)
            {
                return HttpNotFound();
            }
            return View(appliImrul);
        }

        // GET: appliImruls/Create
        public ActionResult Create()
        {
            ViewBag.nid = new SelectList(db.nameImruls, "nid", "Name");
            return View();
        }

        // POST: appliImruls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aid,nid,title,requiredLeave,description")] appliImrul appliImrul)
        {
            if (ModelState.IsValid)
            {
                db.appliImruls.Add(appliImrul);
                db.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.nid = new SelectList(db.nameImruls, "nid", "Name", appliImrul.nid);
            return View(appliImrul);
        }

        // GET: appliImruls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appliImrul appliImrul = db.appliImruls.Find(id);
            if (appliImrul == null)
            {
                return HttpNotFound();
            }
            ViewBag.nid = new SelectList(db.nameImruls, "nid", "Name", appliImrul.nid);
            return View(appliImrul);
        }

        // POST: appliImruls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aid,nid,title,requiredLeave,description")] appliImrul appliImrul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appliImrul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nid = new SelectList(db.nameImruls, "nid", "Name", appliImrul.nid);
            return View(appliImrul);
        }

        // GET: appliImruls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appliImrul appliImrul = db.appliImruls.Find(id);
            if (appliImrul == null)
            {
                return HttpNotFound();
            }
            return View(appliImrul);
        }

        // POST: appliImruls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            appliImrul appliImrul = db.appliImruls.Find(id);
            db.appliImruls.Remove(appliImrul);
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
