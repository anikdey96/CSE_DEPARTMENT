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
    public class oldRoutine_42Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: oldRoutine_42
        public ActionResult Index()
        {
            return View(db.oldRoutine_42.ToList());
        }

        // GET: oldRoutine_42/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine_42 oldRoutine_42 = db.oldRoutine_42.Find(id);
            if (oldRoutine_42 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine_42);
        }

        // GET: oldRoutine_42/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: oldRoutine_42/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,day,box1,box2,box3,box4,box5,box6,box7,box8,box9")] oldRoutine_42 oldRoutine_42)
        {
            if (ModelState.IsValid)
            {
                db.oldRoutine_42.Add(oldRoutine_42);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oldRoutine_42);
        }

        // GET: oldRoutine_42/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine_42 oldRoutine_42 = db.oldRoutine_42.Find(id);
            if (oldRoutine_42 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine_42);
        }

        // POST: oldRoutine_42/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,day,box1,box2,box3,box4,box5,box6,box7,box8,box9")] oldRoutine_42 oldRoutine_42)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oldRoutine_42).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oldRoutine_42);
        }

        // GET: oldRoutine_42/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine_42 oldRoutine_42 = db.oldRoutine_42.Find(id);
            if (oldRoutine_42 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine_42);
        }

        // POST: oldRoutine_42/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oldRoutine_42 oldRoutine_42 = db.oldRoutine_42.Find(id);
            db.oldRoutine_42.Remove(oldRoutine_42);
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
