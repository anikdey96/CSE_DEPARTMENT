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
    public class student_task_assignController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: student_task_assign
        public ActionResult Index()
        {
            var student_task_assign = db.student_task_assign.Include(s => s.student).Include(s => s.Year);
            return View(student_task_assign.ToList());
        }

        // GET: student_task_assign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student_task_assign student_task_assign = db.student_task_assign.Find(id);
            if (student_task_assign == null)
            {
                return HttpNotFound();
            }
            return View(student_task_assign);
        }

        // GET: student_task_assign/Create
        public ActionResult Create()
        {
            ViewBag.student_id = new SelectList(db.students, "student_id", "Name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: student_task_assign/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "task_id,student_id,year_id,roll,title,description,deadline,priority,status,feedback")] student_task_assign student_task_assign)
        {
            if (ModelState.IsValid)
            {
                db.student_task_assign.Add(student_task_assign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.student_id = new SelectList(db.students, "student_id", "Name", student_task_assign.student_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", student_task_assign.year_id);
            return View(student_task_assign);
        }

        // GET: student_task_assign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student_task_assign student_task_assign = db.student_task_assign.Find(id);
            if (student_task_assign == null)
            {
                return HttpNotFound();
            }
            ViewBag.student_id = new SelectList(db.students, "student_id", "Name", student_task_assign.student_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", student_task_assign.year_id);
            return View(student_task_assign);
        }

        // POST: student_task_assign/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "task_id,student_id,year_id,roll,title,description,deadline,priority,status,feedback")] student_task_assign student_task_assign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_task_assign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.student_id = new SelectList(db.students, "student_id", "Name", student_task_assign.student_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", student_task_assign.year_id);
            return View(student_task_assign);
        }

        // GET: student_task_assign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student_task_assign student_task_assign = db.student_task_assign.Find(id);
            if (student_task_assign == null)
            {
                return HttpNotFound();
            }
            return View(student_task_assign);
        }

        // POST: student_task_assign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student_task_assign student_task_assign = db.student_task_assign.Find(id);
            db.student_task_assign.Remove(student_task_assign);
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
