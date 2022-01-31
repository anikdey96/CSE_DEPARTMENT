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
    public class emFacultyApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: emFacultyApplications
        public ActionResult Index()
        {
            var emFacultyApplications = db.emFacultyApplications.Include(e => e.designationEm).Include(e => e.emFacultyInfo);
            return View(emFacultyApplications.ToList());
        }

        public ActionResult Success()
        {

            return View();
        }

        // GET: emFacultyApplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emFacultyApplication emFacultyApplication = db.emFacultyApplications.Find(id);
            if (emFacultyApplication == null)
            {
                return HttpNotFound();
            }
            return View(emFacultyApplication);
        }

        // GET: emFacultyApplications/Create
        public ActionResult Create()
        {
            ViewBag.did = new SelectList(db.designationEms, "did", "Designation");
            ViewBag.id = new SelectList(db.emFacultyInfoes, "id", "Name");
            return View();
        }

        // POST: emFacultyApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "application_id,id,did,name,title,Designation,NoOfLeave,description,status,Accepted_Rejected")] emFacultyApplication emFacultyApplication)
        {
            if (ModelState.IsValid)
            {
                db.emFacultyApplications.Add(emFacultyApplication);
                db.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.did = new SelectList(db.designationEms, "did", "Designation", emFacultyApplication.did);
            ViewBag.id = new SelectList(db.emFacultyInfoes, "id", "Name", emFacultyApplication.id);
            return View(emFacultyApplication);
        }

        // GET: emFacultyApplications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emFacultyApplication emFacultyApplication = db.emFacultyApplications.Find(id);
            if (emFacultyApplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.did = new SelectList(db.designationEms, "did", "Designation", emFacultyApplication.did);
            ViewBag.id = new SelectList(db.emFacultyInfoes, "id", "Designation", emFacultyApplication.id);
            return View(emFacultyApplication);
        }

        // POST: emFacultyApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "application_id,id,did,name,title,Designation,NoOfLeave,description,status,Accepted_Rejected")] emFacultyApplication emFacultyApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emFacultyApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.did = new SelectList(db.designationEms, "did", "Designation", emFacultyApplication.did);
            ViewBag.id = new SelectList(db.emFacultyInfoes, "id", "Designation", emFacultyApplication.id);
            return View(emFacultyApplication);
        }

        // GET: emFacultyApplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emFacultyApplication emFacultyApplication = db.emFacultyApplications.Find(id);
            if (emFacultyApplication == null)
            {
                return HttpNotFound();
            }
            return View(emFacultyApplication);
        }

        // POST: emFacultyApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emFacultyApplication emFacultyApplication = db.emFacultyApplications.Find(id);
            db.emFacultyApplications.Remove(emFacultyApplication);
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
