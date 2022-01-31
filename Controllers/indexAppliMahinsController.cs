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
    public class indexAppliMahinsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: indexAppliMahins
        public ActionResult Index()
        {
            return View(db.indexAppliMahins.ToList());
        }

        // GET: indexAppliMahins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indexAppliMahin indexAppliMahin = db.indexAppliMahins.Find(id);
            if (indexAppliMahin == null)
            {
                return HttpNotFound();
            }
            return View(indexAppliMahin);
        }

        // GET: indexAppliMahins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: indexAppliMahins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Roll,LeaveTaken")] indexAppliMahin indexAppliMahin)
        {
            if (ModelState.IsValid)
            {
                db.indexAppliMahins.Add(indexAppliMahin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(indexAppliMahin);
        }

        // GET: indexAppliMahins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indexAppliMahin indexAppliMahin = db.indexAppliMahins.Find(id);
            if (indexAppliMahin == null)
            {
                return HttpNotFound();
            }
            return View(indexAppliMahin);
        }

        // POST: indexAppliMahins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Roll,LeaveTaken")] indexAppliMahin indexAppliMahin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indexAppliMahin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(indexAppliMahin);
        }

        // GET: indexAppliMahins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            indexAppliMahin indexAppliMahin = db.indexAppliMahins.Find(id);
            if (indexAppliMahin == null)
            {
                return HttpNotFound();
            }
            return View(indexAppliMahin);
        }

        // POST: indexAppliMahins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            indexAppliMahin indexAppliMahin = db.indexAppliMahins.Find(id);
            db.indexAppliMahins.Remove(indexAppliMahin);
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
