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
    public class staff_task_assignController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: staff_task_assign
        public ActionResult Index()
        {
            var staff_task_assign = db.staff_task_assign.Include(s => s.Staff);
            return View(staff_task_assign.ToList());
        }


        // GET: staff_task_assign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff_task_assign staff_task_assign = db.staff_task_assign.Find(id);
            if (staff_task_assign == null)
            {
                return HttpNotFound();
            }
            return View(staff_task_assign);
        }

        // GET: staff_task_assign/Create
        public ActionResult Create()
        {
            ViewBag.staff_id = new SelectList(db.Staffs, "staff_id", "staff_name");
            return View();
        }

        // POST: staff_task_assign/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "task_id,staff_id,title,description,deadline,priority,status,feedback")] staff_task_assign staff_task_assign)
        {
            if (ModelState.IsValid)
            {
                db.staff_task_assign.Add(staff_task_assign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.staff_id = new SelectList(db.Staffs, "staff_id", "staff_name", staff_task_assign.staff_id);
            return View(staff_task_assign);
        }

        // GET: staff_task_assign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff_task_assign staff_task_assign = db.staff_task_assign.Find(id);
            if (staff_task_assign == null)
            {
                return HttpNotFound();
            }
            ViewBag.staff_id = new SelectList(db.Staffs, "staff_id", "staff_name", staff_task_assign.staff_id);
            return View(staff_task_assign);
        }

        // POST: staff_task_assign/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "task_id,staff_id,title,description,deadline,priority,status,feedback")] staff_task_assign staff_task_assign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff_task_assign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.staff_id = new SelectList(db.Staffs, "staff_id", "staff_name", staff_task_assign.staff_id);
            return View(staff_task_assign);
        }

        // GET: staff_task_assign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff_task_assign staff_task_assign = db.staff_task_assign.Find(id);
            if (staff_task_assign == null)
            {
                return HttpNotFound();
            }
            return View(staff_task_assign);
        }

        // POST: staff_task_assign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            staff_task_assign staff_task_assign = db.staff_task_assign.Find(id);
            db.staff_task_assign.Remove(staff_task_assign);
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
