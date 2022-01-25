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
    public class oldRoutinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: oldRoutines
        public ActionResult Index()
        {
            var oldRoutines = db.oldRoutines.Include(o => o.Session).Include(o => o.Subject).Include(o => o.teacher).Include(o => o.Year);
            return View(oldRoutines.ToList());
        }

        // GET: oldRoutines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine oldRoutine = db.oldRoutines.Find(id);
            if (oldRoutine == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine);
        }

        // GET: oldRoutines/Create
        public ActionResult Create()
        {
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name");
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name");
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: oldRoutines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "routine_id,Room_No,routine_upload,class_date,day,teacher_id,subject_id,session_id,year_id,start_time,end_time,duration,comment")] oldRoutine oldRoutine)
        {
            if (ModelState.IsValid)
            {
                db.oldRoutines.Add(oldRoutine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", oldRoutine.session_id);
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", oldRoutine.subject_id);
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", oldRoutine.teacher_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", oldRoutine.year_id);
            return View(oldRoutine);
        }

        // GET: oldRoutines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine oldRoutine = db.oldRoutines.Find(id);
            if (oldRoutine == null)
            {
                return HttpNotFound();
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", oldRoutine.session_id);
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", oldRoutine.subject_id);
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", oldRoutine.teacher_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", oldRoutine.year_id);
            return View(oldRoutine);
        }

        // POST: oldRoutines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "routine_id,Room_No,routine_upload,class_date,day,teacher_id,subject_id,session_id,year_id,start_time,end_time,duration,comment")] oldRoutine oldRoutine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oldRoutine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", oldRoutine.session_id);
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", oldRoutine.subject_id);
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", oldRoutine.teacher_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", oldRoutine.year_id);
            return View(oldRoutine);
        }

        // GET: oldRoutines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldRoutine oldRoutine = db.oldRoutines.Find(id);
            if (oldRoutine == null)
            {
                return HttpNotFound();
            }
            return View(oldRoutine);
        }

        // POST: oldRoutines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oldRoutine oldRoutine = db.oldRoutines.Find(id);
            db.oldRoutines.Remove(oldRoutine);
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
