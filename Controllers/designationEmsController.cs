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
    public class designationEmsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: designationEms
        public ActionResult Index()
        {
            return View(db.designationEms.ToList());
        }

        // GET: designationEms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            designationEm designationEm = db.designationEms.Find(id);
            if (designationEm == null)
            {
                return HttpNotFound();
            }
            return View(designationEm);
        }

        // GET: designationEms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: designationEms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "did,Designation")] designationEm designationEm)
        {
            if (ModelState.IsValid)
            {
                db.designationEms.Add(designationEm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designationEm);
        }

        // GET: designationEms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            designationEm designationEm = db.designationEms.Find(id);
            if (designationEm == null)
            {
                return HttpNotFound();
            }
            return View(designationEm);
        }

        // POST: designationEms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "did,Designation")] designationEm designationEm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designationEm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designationEm);
        }

        // GET: designationEms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            designationEm designationEm = db.designationEms.Find(id);
            if (designationEm == null)
            {
                return HttpNotFound();
            }
            return View(designationEm);
        }

        // POST: designationEms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            designationEm designationEm = db.designationEms.Find(id);
            db.designationEms.Remove(designationEm);
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
