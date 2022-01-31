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
    public class indexAppliAniksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: indexAppliAniks
        public ActionResult Index()
        {
            return View(db.indexAppliAniks.ToList());
        }

        // GET: indexAppliAniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indexAppliAnik indexAppliAnik = db.indexAppliAniks.Find(id);
            if (indexAppliAnik == null)
            {
                return HttpNotFound();
            }
            return View(indexAppliAnik);
        }

        // GET: indexAppliAniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: indexAppliAniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Roll,LeaveTaken")] indexAppliAnik indexAppliAnik)
        {
            if (ModelState.IsValid)
            {
                db.indexAppliAniks.Add(indexAppliAnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(indexAppliAnik);
        }

        // GET: indexAppliAniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indexAppliAnik indexAppliAnik = db.indexAppliAniks.Find(id);
            if (indexAppliAnik == null)
            {
                return HttpNotFound();
            }
            return View(indexAppliAnik);
        }

        // POST: indexAppliAniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Roll,LeaveTaken")] indexAppliAnik indexAppliAnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indexAppliAnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(indexAppliAnik);
        }

        // GET: indexAppliAniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indexAppliAnik indexAppliAnik = db.indexAppliAniks.Find(id);
            if (indexAppliAnik == null)
            {
                return HttpNotFound();
            }
            return View(indexAppliAnik);
        }

        // POST: indexAppliAniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            indexAppliAnik indexAppliAnik = db.indexAppliAniks.Find(id);
            db.indexAppliAniks.Remove(indexAppliAnik);
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
