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
    public class book31Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: book31
        public ActionResult Index()
        {
            var book31 = db.book31.Include(b => b.Subject).Include(b => b.Year);
            return View(book31.ToList());
        }

        // GET: book31/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book31 book31 = db.book31.Find(id);
            if (book31 == null)
            {
                return HttpNotFound();
            }
            return View(book31);
        }

        // GET: book31/Create
        public ActionResult Create()
        {
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: book31/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(book31 book31)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in book31.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Books"), fileName);
                        file.SaveAs(filePath);
                    }

                    db.book31.Add(book31);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }

            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", book31.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", book31.year_id);
            return View(book31);
        }


        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Books"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: book31/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book31 book31 = db.book31.Find(id);
            if (book31 == null)
            {
                return HttpNotFound();
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", book31.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", book31.year_id);
            return View(book31);
        }

        // POST: book31/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "book_id,year_id,book_name,book_author,specification,edition,subject_id")] book31 book31)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book31).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", book31.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", book31.year_id);
            return View(book31);
        }

        // GET: book31/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book31 book31 = db.book31.Find(id);
            if (book31 == null)
            {
                return HttpNotFound();
            }
            return View(book31);
        }

        // POST: book31/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book31 book31 = db.book31.Find(id);
            db.book31.Remove(book31);
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
