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
    public class oldRoutine_32Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: oldRoutine_32
        public ActionResult Index()
        {
            return View(db.oldRoutine_32.ToList());
        }

        // GET: oldRoutine_32/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine_32 oldRoutine_32 = db.oldRoutine_32.Find(id);
            if (oldRoutine_32 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine_32);
        }

        // GET: oldRoutine_32/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: oldRoutine_32/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,day,box1,box2,box3,box4,box5,box6,box7,box8,box9")] oldRoutine_32 oldRoutine_32)
        {
            if (ModelState.IsValid)
            {
                db.oldRoutine_32.Add(oldRoutine_32);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oldRoutine_32);
        }

        // GET: oldRoutine_32/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine_32 oldRoutine_32 = db.oldRoutine_32.Find(id);
            if (oldRoutine_32 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine_32);
        }

        // POST: oldRoutine_32/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,day,box1,box2,box3,box4,box5,box6,box7,box8,box9")] oldRoutine_32 oldRoutine_32)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oldRoutine_32).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oldRoutine_32);
        }

        // GET: oldRoutine_32/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine_32 oldRoutine_32 = db.oldRoutine_32.Find(id);
            if (oldRoutine_32 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine_32);
        }

        // POST: oldRoutine_32/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oldRoutine_32 oldRoutine_32 = db.oldRoutine_32.Find(id);
            db.oldRoutine_32.Remove(oldRoutine_32);
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
