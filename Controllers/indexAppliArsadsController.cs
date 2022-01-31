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
    public class indexAppliArsadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: indexAppliArsads
        public ActionResult Index()
        {
            return View(db.indexAppliArsads.ToList());
        }

        // GET: indexAppliArsads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indexAppliArsad indexAppliArsad = db.indexAppliArsads.Find(id);
            if (indexAppliArsad == null)
            {
                return HttpNotFound();
            }
            return View(indexAppliArsad);
        }

        // GET: indexAppliArsads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: indexAppliArsads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,TotalLeave,LeaveTaken")] indexAppliArsad indexAppliArsad)
        {
            if (ModelState.IsValid)
            {
                db.indexAppliArsads.Add(indexAppliArsad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(indexAppliArsad);
        }

        // GET: indexAppliArsads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indexAppliArsad indexAppliArsad = db.indexAppliArsads.Find(id);
            if (indexAppliArsad == null)
            {
                return HttpNotFound();
            }
            return View(indexAppliArsad);
        }

        // POST: indexAppliArsads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,TotalLeave,LeaveTaken")] indexAppliArsad indexAppliArsad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indexAppliArsad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(indexAppliArsad);
        }

        // GET: indexAppliArsads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indexAppliArsad indexAppliArsad = db.indexAppliArsads.Find(id);
            if (indexAppliArsad == null)
            {
                return HttpNotFound();
            }
            return View(indexAppliArsad);
        }

        // POST: indexAppliArsads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            indexAppliArsad indexAppliArsad = db.indexAppliArsads.Find(id);
            db.indexAppliArsads.Remove(indexAppliArsad);
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
