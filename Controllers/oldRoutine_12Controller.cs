﻿using System;
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
    public class oldRoutine_12Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: oldRoutine_12
        public ActionResult Index()
        {
            return View(db.oldRoutine_12.ToList());
        }

        // GET: oldRoutine_12/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine_12 oldRoutine_12 = db.oldRoutine_12.Find(id);
            if (oldRoutine_12 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine_12);
        }

        // GET: oldRoutine_12/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: oldRoutine_12/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,day,box1,box2,box3,box4,box5,box6,box7,box8,box9")] oldRoutine_12 oldRoutine_12)
        {
            if (ModelState.IsValid)
            {
                db.oldRoutine_12.Add(oldRoutine_12);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oldRoutine_12);
        }

        // GET: oldRoutine_12/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine_12 oldRoutine_12 = db.oldRoutine_12.Find(id);
            if (oldRoutine_12 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine_12);
        }

        // POST: oldRoutine_12/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,day,box1,box2,box3,box4,box5,box6,box7,box8,box9")] oldRoutine_12 oldRoutine_12)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oldRoutine_12).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oldRoutine_12);
        }

        // GET: oldRoutine_12/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine_12 oldRoutine_12 = db.oldRoutine_12.Find(id);
            if (oldRoutine_12 == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine_12);
        }

        // POST: oldRoutine_12/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oldRoutine_12 oldRoutine_12 = db.oldRoutine_12.Find(id);
            db.oldRoutine_12.Remove(oldRoutine_12);
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
