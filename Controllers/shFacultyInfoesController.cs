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
    public class shFacultyInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: shFacultyInfoes
        public ActionResult Index()
        {
            return View(db.shFacultyInfoes.ToList());
        }

        // GET: shFacultyInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shFacultyInfo shFacultyInfo = db.shFacultyInfoes.Find(id);
            if (shFacultyInfo == null)
            {
                return HttpNotFound();
            }
            return View(shFacultyInfo);
        }

        // GET: shFacultyInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: shFacultyInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Designation,Name,TotalLeave,LeaveTaken")] shFacultyInfo shFacultyInfo)
        {
            if (ModelState.IsValid)
            {
                db.shFacultyInfoes.Add(shFacultyInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shFacultyInfo);
        }

        // GET: shFacultyInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shFacultyInfo shFacultyInfo = db.shFacultyInfoes.Find(id);
            if (shFacultyInfo == null)
            {
                return HttpNotFound();
            }
            return View(shFacultyInfo);
        }

        // POST: shFacultyInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Designation,Name,TotalLeave,LeaveTaken")] shFacultyInfo shFacultyInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shFacultyInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shFacultyInfo);
        }

        // GET: shFacultyInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shFacultyInfo shFacultyInfo = db.shFacultyInfoes.Find(id);
            if (shFacultyInfo == null)
            {
                return HttpNotFound();
            }
            return View(shFacultyInfo);
        }

        // POST: shFacultyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            shFacultyInfo shFacultyInfo = db.shFacultyInfoes.Find(id);
            db.shFacultyInfoes.Remove(shFacultyInfo);
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
