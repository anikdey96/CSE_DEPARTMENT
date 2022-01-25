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
    public class oldRoutine_21Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: oldRoutine_21
        public ActionResult Index()
        {
            return View(db.oldRoutine_21.ToList());
        }

        // GET: oldRoutine_21/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine_21 oldRoutine_21 = db.oldRoutine_21.Find(id);
            if (oldRoutine_21 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine_21);
        }

        // GET: oldRoutine_21/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: oldRoutine_21/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,day,box1,box2,box3,box4,box5,box6,box7,box8,box9")] oldRoutine_21 oldRoutine_21)
        {
            if (ModelState.IsValid)
            {
                db.oldRoutine_21.Add(oldRoutine_21);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oldRoutine_21);
        }

        // GET: oldRoutine_21/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine_21 oldRoutine_21 = db.oldRoutine_21.Find(id);
            if (oldRoutine_21 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine_21);
        }

        // POST: oldRoutine_21/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,day,box1,box2,box3,box4,box5,box6,box7,box8,box9")] oldRoutine_21 oldRoutine_21)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oldRoutine_21).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oldRoutine_21);
        }

        // GET: oldRoutine_21/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine_21 oldRoutine_21 = db.oldRoutine_21.Find(id);
            if (oldRoutine_21 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine_21);
        }

        // POST: oldRoutine_21/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oldRoutine_21 oldRoutine_21 = db.oldRoutine_21.Find(id);
            db.oldRoutine_21.Remove(oldRoutine_21);
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
