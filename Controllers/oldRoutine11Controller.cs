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
    public class oldRoutine11Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: oldRoutine11
        public ActionResult Index()
        {
            return View(db.oldRoutine11.ToList());
        }

        // GET: oldRoutine11/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine11 oldRoutine11 = db.oldRoutine11.Find(id);
            if (oldRoutine11 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine11);
        }

        // GET: oldRoutine11/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: oldRoutine11/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,day,box1,box2,box3,box4,box5,box6,box7,box8,box9")] oldRoutine11 oldRoutine11)
        {
            if (ModelState.IsValid)
            {
                db.oldRoutine11.Add(oldRoutine11);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oldRoutine11);
        }

        // GET: oldRoutine11/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine11 oldRoutine11 = db.oldRoutine11.Find(id);
            if (oldRoutine11 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine11);
        }

        // POST: oldRoutine11/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,day,box1,box2,box3,box4,box5,box6,box7,box8,box9")] oldRoutine11 oldRoutine11)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oldRoutine11).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oldRoutine11);
        }

        // GET: oldRoutine11/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine11 oldRoutine11 = db.oldRoutine11.Find(id);
            if (oldRoutine11 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine11);
        }

        // POST: oldRoutine11/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oldRoutine11 oldRoutine11 = db.oldRoutine11.Find(id);
            db.oldRoutine11.Remove(oldRoutine11);
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
