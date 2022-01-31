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
    public class nameArsadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: nameArsads
        public ActionResult Index()
        {
            return View(db.nameArsads.ToList());
        }

        // GET: nameArsads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nameArsad nameArsad = db.nameArsads.Find(id);
            if (nameArsad == null)
            {
                return HttpNotFound();
            }
            return View(nameArsad);
        }

        // GET: nameArsads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: nameArsads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nid,Name")] nameArsad nameArsad)
        {
            if (ModelState.IsValid)
            {
                db.nameArsads.Add(nameArsad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nameArsad);
        }

        // GET: nameArsads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nameArsad nameArsad = db.nameArsads.Find(id);
            if (nameArsad == null)
            {
                return HttpNotFound();
            }
            return View(nameArsad);
        }

        // POST: nameArsads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nid,Name")] nameArsad nameArsad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nameArsad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nameArsad);
        }

        // GET: nameArsads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nameArsad nameArsad = db.nameArsads.Find(id);
            if (nameArsad == null)
            {
                return HttpNotFound();
            }
            return View(nameArsad);
        }

        // POST: nameArsads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nameArsad nameArsad = db.nameArsads.Find(id);
            db.nameArsads.Remove(nameArsad);
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
