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
    public class Faculty_ApplicationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Faculty_Application
        public ActionResult Index()
        {
            return View(db.Faculty_Application.ToList());
        }

        public ActionResult Success()
        {
            return View();
        }

        // GET: Faculty_Application/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty_Application faculty_Application = db.Faculty_Application.Find(id);
            if (faculty_Application == null)
            {
                return HttpNotFound();
            }
            return View(faculty_Application);
        }

        // GET: Faculty_Application/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faculty_Application/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faculty_Application faculty_Application)
        {

            if (ModelState.IsValid)
            {
                if (User.IsInRole("SuperAdmin"))
                {
                    db.Faculty_Application.Add(faculty_Application);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    db.Faculty_Application.Add(faculty_Application);
                    db.SaveChanges();
                    return RedirectToAction("Success");
                }
            }
            return View(faculty_Application);
        }

        // GET: Faculty_Application/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty_Application faculty_Application = db.Faculty_Application.Find(id);
            if (faculty_Application == null)
            {
                return HttpNotFound();
            }
            return View(faculty_Application);
        }

        // POST: Faculty_Application/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Faculty_Application faculty_Application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty_Application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faculty_Application);
        }

        // GET: Faculty_Application/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty_Application faculty_Application = db.Faculty_Application.Find(id);
            if (faculty_Application == null)
            {
                return HttpNotFound();
            }
            return View(faculty_Application);
        }

        // POST: Faculty_Application/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculty_Application faculty_Application = db.Faculty_Application.Find(id);
            db.Faculty_Application.Remove(faculty_Application);
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
