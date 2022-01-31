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
    public class shaFacultyApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: shaFacultyApplications
        public ActionResult Index()
        {
            var shaFacultyApplications = db.shaFacultyApplications.Include(s => s.designationSha).Include(s => s.shFacultyInfo);
            return View(shaFacultyApplications.ToList());
        }
        public ActionResult Success()
        {
           
            return View();
        }


        // GET: shaFacultyApplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shaFacultyApplication shaFacultyApplication = db.shaFacultyApplications.Find(id);
            if (shaFacultyApplication == null)
            {
                return HttpNotFound();
            }
            return View(shaFacultyApplication);
        }


        // GET: shaFacultyApplications/Create
        public ActionResult Create()
        {
            ViewBag.did = new SelectList(db.designationShas, "did", "Designation");
            ViewBag.id = new SelectList(db.shFacultyInfoes, "id", "Name");
            return View();
        }

        // POST: shaFacultyApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "application_id,id,did,name,title,Designation,NoOfLeave,description,status,Accepted_Rejected")] shaFacultyApplication shaFacultyApplication)
        {
            if (ModelState.IsValid)
            {
                db.shaFacultyApplications.Add(shaFacultyApplication);
                db.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.did = new SelectList(db.designationShas, "did", "Designation", shaFacultyApplication.did);
            ViewBag.id = new SelectList(db.shFacultyInfoes, "id", "Name", shaFacultyApplication.id);
            return View(shaFacultyApplication);
        }

        // GET: shaFacultyApplications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shaFacultyApplication shaFacultyApplication = db.shaFacultyApplications.Find(id);
            if (shaFacultyApplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.did = new SelectList(db.designationShas, "did", "Designation", shaFacultyApplication.did);
            ViewBag.id = new SelectList(db.shFacultyInfoes, "id", "Designation", shaFacultyApplication.id);
            return View(shaFacultyApplication);
        }

        // POST: shaFacultyApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "application_id,id,did,name,title,Designation,NoOfLeave,description,status,Accepted_Rejected")] shaFacultyApplication shaFacultyApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shaFacultyApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.did = new SelectList(db.designationShas, "did", "Designation", shaFacultyApplication.did);
            ViewBag.id = new SelectList(db.shFacultyInfoes, "id", "Designation", shaFacultyApplication.id);
            return View(shaFacultyApplication);
        }

        // GET: shaFacultyApplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shaFacultyApplication shaFacultyApplication = db.shaFacultyApplications.Find(id);
            if (shaFacultyApplication == null)
            {
                return HttpNotFound();
            }
            return View(shaFacultyApplication);
        }

        // POST: shaFacultyApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            shaFacultyApplication shaFacultyApplication = db.shaFacultyApplications.Find(id);
            db.shaFacultyApplications.Remove(shaFacultyApplication);
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
