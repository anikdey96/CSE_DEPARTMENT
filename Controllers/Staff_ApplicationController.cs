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
    public class Staff_ApplicationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Staff_Application
        public ActionResult Index()
        {
            return View(db.Staff_Application.ToList());
        }

        public ActionResult Success()
        {
            return View();
        }
        // GET: Staff_Application/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff_Application staff_Application = db.Staff_Application.Find(id);
            if (staff_Application == null)
            {
                return HttpNotFound();
            }
            return View(staff_Application);
        }

        // GET: Staff_Application/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff_Application/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Staff_Application staff_Application)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("SuperAdmin"))
                {
                    db.Staff_Application.Add(staff_Application);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    db.Staff_Application.Add(staff_Application);
                    db.SaveChanges();
                    return RedirectToAction("Success");
                }
            }

            return View(staff_Application);
        }

        // GET: Staff_Application/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff_Application staff_Application = db.Staff_Application.Find(id);
            if (staff_Application == null)
            {
                return HttpNotFound();
            }
            return View(staff_Application);
        }

        // POST: Staff_Application/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Staff_Application staff_Application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff_Application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff_Application);
        }

        // GET: Staff_Application/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff_Application staff_Application = db.Staff_Application.Find(id);
            if (staff_Application == null)
            {
                return HttpNotFound();
            }
            return View(staff_Application);
        }

        // POST: Staff_Application/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff_Application staff_Application = db.Staff_Application.Find(id);
            db.Staff_Application.Remove(staff_Application);
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
