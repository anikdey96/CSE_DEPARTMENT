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
    public class moFacultyApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: moFacultyApplications
        public ActionResult Index()
        {
            var moFacultyApplications = db.moFacultyApplications.Include(m => m.designationMo).Include(m => m.moFacultyInfo);
            return View(moFacultyApplications.ToList());
        }

        public ActionResult Success()
        {

            return View();
        }

        // GET: moFacultyApplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            moFacultyApplication moFacultyApplication = db.moFacultyApplications.Find(id);
            if (moFacultyApplication == null)
            {
                return HttpNotFound();
            }
            return View(moFacultyApplication);
        }

        // GET: moFacultyApplications/Create
        public ActionResult Create()
        {
            ViewBag.did = new SelectList(db.designationMoes, "did", "Designation");
            ViewBag.id = new SelectList(db.moFacultyInfoes, "id", "Name");
            return View();
        }

        // POST: moFacultyApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "application_id,id,did,title,NoOfLeave,description,status,Accepted_Rejected")] moFacultyApplication moFacultyApplication)
        {
            if (ModelState.IsValid)
            {
                db.moFacultyApplications.Add(moFacultyApplication);
                db.SaveChanges();
                return RedirectToAction("Success");
            }

            ViewBag.did = new SelectList(db.designationMoes, "did", "Designation", moFacultyApplication.did);
            ViewBag.id = new SelectList(db.moFacultyInfoes, "id", "Name", moFacultyApplication.id);
            return View(moFacultyApplication);
        }

        // GET: moFacultyApplications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            moFacultyApplication moFacultyApplication = db.moFacultyApplications.Find(id);
            if (moFacultyApplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.did = new SelectList(db.designationMoes, "did", "Designation", moFacultyApplication.did);
            ViewBag.id = new SelectList(db.moFacultyInfoes, "id", "Designation", moFacultyApplication.id);
            return View(moFacultyApplication);
        }

        // POST: moFacultyApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "application_id,id,did,title,NoOfLeave,description,status,Accepted_Rejected")] moFacultyApplication moFacultyApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moFacultyApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.did = new SelectList(db.designationMoes, "did", "Designation", moFacultyApplication.did);
            ViewBag.id = new SelectList(db.moFacultyInfoes, "id", "Designation", moFacultyApplication.id);
            return View(moFacultyApplication);
        }

        // GET: moFacultyApplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            moFacultyApplication moFacultyApplication = db.moFacultyApplications.Find(id);
            if (moFacultyApplication == null)
            {
                return HttpNotFound();
            }
            return View(moFacultyApplication);
        }

        // POST: moFacultyApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            moFacultyApplication moFacultyApplication = db.moFacultyApplications.Find(id);
            db.moFacultyApplications.Remove(moFacultyApplication);
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
