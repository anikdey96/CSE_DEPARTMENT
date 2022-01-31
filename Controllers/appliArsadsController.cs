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
    public class appliArsadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: appliArsads
        public ActionResult Index()
        {
            var appliArsads = db.appliArsads.Include(a => a.nameArsad);
            return View(appliArsads.ToList());
        }

        public ActionResult Success()
        {

            return View();
        }

        // GET: appliArsads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appliArsad appliArsad = db.appliArsads.Find(id);
            if (appliArsad == null)
            {
                return HttpNotFound();
            }
            return View(appliArsad);
        }

        // GET: appliArsads/Create
        public ActionResult Create()
        {
            ViewBag.nid = new SelectList(db.nameArsads, "nid", "Name");
            return View();
        }

        // POST: appliArsads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aid,nid,title,requiredLeave,description")] appliArsad appliArsad)
        {
            if (ModelState.IsValid)
            {
                db.appliArsads.Add(appliArsad);
                db.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.nid = new SelectList(db.nameArsads, "nid", "Name", appliArsad.nid);
            return View(appliArsad);
        }

        // GET: appliArsads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appliArsad appliArsad = db.appliArsads.Find(id);
            if (appliArsad == null)
            {
                return HttpNotFound();
            }
            ViewBag.nid = new SelectList(db.nameArsads, "nid", "Name", appliArsad.nid);
            return View(appliArsad);
        }

        // POST: appliArsads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aid,nid,title,requiredLeave,description")] appliArsad appliArsad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appliArsad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nid = new SelectList(db.nameArsads, "nid", "Name", appliArsad.nid);
            return View(appliArsad);
        }

        // GET: appliArsads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appliArsad appliArsad = db.appliArsads.Find(id);
            if (appliArsad == null)
            {
                return HttpNotFound();
            }
            return View(appliArsad);
        }

        // POST: appliArsads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            appliArsad appliArsad = db.appliArsads.Find(id);
            db.appliArsads.Remove(appliArsad);
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
