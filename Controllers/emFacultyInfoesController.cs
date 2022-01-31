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
    public class emFacultyInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: emFacultyInfoes
        public ActionResult Index()
        {
            return View(db.emFacultyInfoes.ToList());
        }

        // GET: emFacultyInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emFacultyInfo emFacultyInfo = db.emFacultyInfoes.Find(id);
            if (emFacultyInfo == null)
            {
                return HttpNotFound();
            }
            return View(emFacultyInfo);
        }

        // GET: emFacultyInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: emFacultyInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Designation,Name,TotalLeave,LeaveTaken")] emFacultyInfo emFacultyInfo)
        {
            if (ModelState.IsValid)
            {
                db.emFacultyInfoes.Add(emFacultyInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emFacultyInfo);
        }

        // GET: emFacultyInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emFacultyInfo emFacultyInfo = db.emFacultyInfoes.Find(id);
            if (emFacultyInfo == null)
            {
                return HttpNotFound();
            }
            return View(emFacultyInfo);
        }

        // POST: emFacultyInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Designation,Name,TotalLeave,LeaveTaken")] emFacultyInfo emFacultyInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emFacultyInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emFacultyInfo);
        }

        // GET: emFacultyInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emFacultyInfo emFacultyInfo = db.emFacultyInfoes.Find(id);
            if (emFacultyInfo == null)
            {
                return HttpNotFound();
            }
            return View(emFacultyInfo);
        }

        // POST: emFacultyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emFacultyInfo emFacultyInfo = db.emFacultyInfoes.Find(id);
            db.emFacultyInfoes.Remove(emFacultyInfo);
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
