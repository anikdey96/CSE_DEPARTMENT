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
    public class materials42Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: materials42
        public ActionResult Index()
        {
            var materials42 = db.materials42.Include(m => m.Subject).Include(m => m.Year);
            return View(materials42.ToList());
        }

        // GET: materials42/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materials42 materials42 = db.materials42.Find(id);
            if (materials42 == null)
            {
                return HttpNotFound();
            }
            return View(materials42);
        }

        // GET: materials42/Create
        public ActionResult Create()
        {
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: materials42/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(materials42 materials42)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in materials42.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Materials"), fileName);
                        file.SaveAs(filePath);
                    }

                    db.materials42.Add(materials42);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }

            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", materials42.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", materials42.year_id);
            return View(materials42);
        }

        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Materials"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: materials42/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materials42 materials42 = db.materials42.Find(id);
            if (materials42 == null)
            {
                return HttpNotFound();
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", materials42.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", materials42.year_id);
            return View(materials42);
        }

        // POST: materials42/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "materials_id,subject_id,year_id,materials_topic,arranged_by,reference,publish_date,specification")] materials42 materials42)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materials42).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", materials42.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", materials42.year_id);
            return View(materials42);
        }

        // GET: materials42/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materials42 materials42 = db.materials42.Find(id);
            if (materials42 == null)
            {
                return HttpNotFound();
            }
            return View(materials42);
        }

        // POST: materials42/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            materials42 materials42 = db.materials42.Find(id);
            db.materials42.Remove(materials42);
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
