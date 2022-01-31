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
    public class indexAppliImrulsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: indexAppliImruls
        public ActionResult Index()
        {
            return View(db.indexAppliImruls.ToList());
        }

        // GET: indexAppliImruls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indexAppliImrul indexAppliImrul = db.indexAppliImruls.Find(id);
            if (indexAppliImrul == null)
            {
                return HttpNotFound();
            }
            return View(indexAppliImrul);
        }

        // GET: indexAppliImruls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: indexAppliImruls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,TotalLeave,LeaveTaken")] indexAppliImrul indexAppliImrul)
        {
            if (ModelState.IsValid)
            {
                db.indexAppliImruls.Add(indexAppliImrul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(indexAppliImrul);
        }

        // GET: indexAppliImruls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indexAppliImrul indexAppliImrul = db.indexAppliImruls.Find(id);
            if (indexAppliImrul == null)
            {
                return HttpNotFound();
            }
            return View(indexAppliImrul);
        }

        // POST: indexAppliImruls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,TotalLeave,LeaveTaken")] indexAppliImrul indexAppliImrul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indexAppliImrul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(indexAppliImrul);
        }

        // GET: indexAppliImruls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indexAppliImrul indexAppliImrul = db.indexAppliImruls.Find(id);
            if (indexAppliImrul == null)
            {
                return HttpNotFound();
            }
            return View(indexAppliImrul);
        }

        // POST: indexAppliImruls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            indexAppliImrul indexAppliImrul = db.indexAppliImruls.Find(id);
            db.indexAppliImruls.Remove(indexAppliImrul);
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
