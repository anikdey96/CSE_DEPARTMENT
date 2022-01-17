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
    public class materials12Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: materials12
        public ActionResult Index()
        {
            var materials12 = db.materials12.Include(m => m.Subject).Include(m => m.Year);
            return View(materials12.ToList());
        }

        // GET: materials12/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materials12 materials12 = db.materials12.Find(id);
            if (materials12 == null)
            {
                return HttpNotFound();
            }
            return View(materials12);
        }

        // GET: materials12/Create
        public ActionResult Create()
        {
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: materials12/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(materials12 materials12)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in materials12.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Materials"), fileName);
                        file.SaveAs(filePath);
                    }

                    db.materials12.Add(materials12);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }

            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", materials12.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", materials12.year_id);
            return View(materials12);
        }


        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Materials"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: materials12/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materials12 materials12 = db.materials12.Find(id);
            if (materials12 == null)
            {
                return HttpNotFound();
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", materials12.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", materials12.year_id);
            return View(materials12);
        }

        // POST: materials12/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "materials_id,subject_id,year_id,materials_topic,arranged_by,reference,publish_date,specification")] materials12 materials12)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materials12).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", materials12.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", materials12.year_id);
            return View(materials12);
        }

        // GET: materials12/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materials12 materials12 = db.materials12.Find(id);
            if (materials12 == null)
            {
                return HttpNotFound();
            }
            return View(materials12);
        }

        // POST: materials12/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            materials12 materials12 = db.materials12.Find(id);
            db.materials12.Remove(materials12);
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
