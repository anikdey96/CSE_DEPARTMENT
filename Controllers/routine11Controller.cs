using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSE_DEPARTMENT.Models;

namespace CSE_DEPARTMENT.Controllers
{
    [Authorize]
    public class routine11Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: routine11
        public ActionResult Index()
        {
            var routine11 = db.routine11.Include(r => r.Subject).Include(r => r.Year);
            return View(routine11.ToList());
        }

        // GET: routine11/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine11 routine11 = db.routine11.Find(id);
            if (routine11 == null)
            {
                return HttpNotFound();
            }
            return View(routine11);
        }

        // GET: routine11/Create
        public ActionResult Create()
        {
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: routine11/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(routine11 routine11)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in routine11.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Routines"), fileName);
                        file.SaveAs(filePath);
                    }
                }


                db.routine11.Add(routine11);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", routine11.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", routine11.year_id);
            return View(routine11);
        }


        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Routines"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: routine11/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine11 routine11 = db.routine11.Find(id);
            if (routine11 == null)
            {
                return HttpNotFound();
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", routine11.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", routine11.year_id);
            return View(routine11);
        }

        // POST: routine11/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "materials_id,subject_id,year_id,materials_topic,arranged_by,reference,publish_date,specification")] routine11 routine11)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine11).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", routine11.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", routine11.year_id);
            return View(routine11);
        }

        // GET: routine11/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine11 routine11 = db.routine11.Find(id);
            if (routine11 == null)
            {
                return HttpNotFound();
            }
            return View(routine11);
        }

        // POST: routine11/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            routine11 routine11 = db.routine11.Find(id);
            db.routine11.Remove(routine11);
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
