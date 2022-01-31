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
    public class nameImrulsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: nameImruls
        public ActionResult Index()
        {
            return View(db.nameImruls.ToList());
        }

        // GET: nameImruls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nameImrul nameImrul = db.nameImruls.Find(id);
            if (nameImrul == null)
            {
                return HttpNotFound();
            }
            return View(nameImrul);
        }

        // GET: nameImruls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: nameImruls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nid,Name")] nameImrul nameImrul)
        {
            if (ModelState.IsValid)
            {
                db.nameImruls.Add(nameImrul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nameImrul);
        }

        // GET: nameImruls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nameImrul nameImrul = db.nameImruls.Find(id);
            if (nameImrul == null)
            {
                return HttpNotFound();
            }
            return View(nameImrul);
        }

        // POST: nameImruls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nid,Name")] nameImrul nameImrul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nameImrul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nameImrul);
        }

        // GET: nameImruls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nameImrul nameImrul = db.nameImruls.Find(id);
            if (nameImrul == null)
            {
                return HttpNotFound();
            }
            return View(nameImrul);
        }

        // POST: nameImruls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nameImrul nameImrul = db.nameImruls.Find(id);
            db.nameImruls.Remove(nameImrul);
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
