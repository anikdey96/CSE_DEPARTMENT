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
    public class book41Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: book41
        public ActionResult Index()
        {
            var book41 = db.book41.Include(b => b.Subject).Include(b => b.Year);
            return View(book41.ToList());
        }

        // GET: book41/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book41 book41 = db.book41.Find(id);
            if (book41 == null)
            {
                return HttpNotFound();
            }
            return View(book41);
        }

        // GET: book41/Create
        public ActionResult Create()
        {
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: book41/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(book41 book41)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in book41.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Books"), fileName);
                        file.SaveAs(filePath);
                    }

                    db.book41.Add(book41);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }

            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", book41.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", book41.year_id);
            return View(book41);
        }


        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Books"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: book41/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book41 book41 = db.book41.Find(id);
            if (book41 == null)
            {
                return HttpNotFound();
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", book41.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", book41.year_id);
            return View(book41);
        }

        // POST: book41/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "book_id,year_id,book_name,book_author,specification,edition,subject_id")] book41 book41)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book41).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", book41.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", book41.year_id);
            return View(book41);
        }

        // GET: book41/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book41 book41 = db.book41.Find(id);
            if (book41 == null)
            {
                return HttpNotFound();
            }
            return View(book41);
        }

        // POST: book41/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book41 book41 = db.book41.Find(id);
            db.book41.Remove(book41);
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
