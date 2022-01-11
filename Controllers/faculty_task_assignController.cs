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
    public class faculty_task_assignController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: faculty_task_assign
        public ActionResult Index()
        {
            var faculty_task_assign = db.faculty_task_assign.Include(f => f.teacher);
            return View(faculty_task_assign.ToList());
        }

        // GET: faculty_task_assign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faculty_task_assign faculty_task_assign = db.faculty_task_assign.Find(id);
            if (faculty_task_assign == null)
            {
                return HttpNotFound();
            }
            return View(faculty_task_assign);
        }

        // GET: faculty_task_assign/Create
        public ActionResult Create()
        {
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name");
            return View();
        }

        // POST: faculty_task_assign/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "task_id,teacher_id,title,description,deadline,priority,status,feedback")] faculty_task_assign faculty_task_assign)
        {
            if (ModelState.IsValid)
            {
                db.faculty_task_assign.Add(faculty_task_assign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", faculty_task_assign.teacher_id);
            return View(faculty_task_assign);
        }

        // GET: faculty_task_assign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faculty_task_assign faculty_task_assign = db.faculty_task_assign.Find(id);
            if (faculty_task_assign == null)
            {
                return HttpNotFound();
            }
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", faculty_task_assign.teacher_id);
            return View(faculty_task_assign);
        }

        // POST: faculty_task_assign/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "task_id,teacher_id,title,description,deadline,priority,status,feedback")] faculty_task_assign faculty_task_assign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty_task_assign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "teacher_name", faculty_task_assign.teacher_id);
            return View(faculty_task_assign);
        }

        // GET: faculty_task_assign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faculty_task_assign faculty_task_assign = db.faculty_task_assign.Find(id);
            if (faculty_task_assign == null)
            {
                return HttpNotFound();
            }
            return View(faculty_task_assign);
        }

        // POST: faculty_task_assign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            faculty_task_assign faculty_task_assign = db.faculty_task_assign.Find(id);
            db.faculty_task_assign.Remove(faculty_task_assign);
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
