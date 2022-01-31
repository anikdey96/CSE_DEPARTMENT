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
    public class moFacultyInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: moFacultyInfoes
        public ActionResult Index()
        {
            return View(db.moFacultyInfoes.ToList());
        }

        // GET: moFacultyInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            moFacultyInfo moFacultyInfo = db.moFacultyInfoes.Find(id);
            if (moFacultyInfo == null)
            {
                return HttpNotFound();
            }
            return View(moFacultyInfo);
        }

        // GET: moFacultyInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: moFacultyInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Designation,Name,TotalLeave,LeaveTaken")] moFacultyInfo moFacultyInfo)
        {
            if (ModelState.IsValid)
            {
                db.moFacultyInfoes.Add(moFacultyInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moFacultyInfo);
        }

        // GET: moFacultyInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            moFacultyInfo moFacultyInfo = db.moFacultyInfoes.Find(id);
            if (moFacultyInfo == null)
            {
                return HttpNotFound();
            }
            return View(moFacultyInfo);
        }

        // POST: moFacultyInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Designation,Name,TotalLeave,LeaveTaken")] moFacultyInfo moFacultyInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moFacultyInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moFacultyInfo);
        }

        // GET: moFacultyInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            moFacultyInfo moFacultyInfo = db.moFacultyInfoes.Find(id);
            if (moFacultyInfo == null)
            {
                return HttpNotFound();
            }
            return View(moFacultyInfo);
        }

        // POST: moFacultyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            moFacultyInfo moFacultyInfo = db.moFacultyInfoes.Find(id);
            db.moFacultyInfoes.Remove(moFacultyInfo);
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
