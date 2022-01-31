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
    public class designationShasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: designationShas
        public ActionResult Index()
        {
            return View(db.designationShas.ToList());
        }

        // GET: designationShas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            designationSha designationSha = db.designationShas.Find(id);
            if (designationSha == null)
            {
                return HttpNotFound();
            }
            return View(designationSha);
        }

        // GET: designationShas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: designationShas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "did,Designation")] designationSha designationSha)
        {
            if (ModelState.IsValid)
            {
                db.designationShas.Add(designationSha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designationSha);
        }

        // GET: designationShas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            designationSha designationSha = db.designationShas.Find(id);
            if (designationSha == null)
            {
                return HttpNotFound();
            }
            return View(designationSha);
        }

        // POST: designationShas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "did,Designation")] designationSha designationSha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designationSha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designationSha);
        }

        // GET: designationShas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            designationSha designationSha = db.designationShas.Find(id);
            if (designationSha == null)
            {
                return HttpNotFound();
            }
            return View(designationSha);
        }

        // POST: designationShas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            designationSha designationSha = db.designationShas.Find(id);
            db.designationShas.Remove(designationSha);
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
