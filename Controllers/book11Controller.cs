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
    public class book11Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: book11
        public ActionResult Index()
        {
            var book11 = db.book11.Include(b => b.Subject).Include(b => b.Year);
            return View(book11.ToList());
        }

        // GET: book11/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book11 book11 = db.book11.Find(id);
            if (book11 == null)
            {
                return HttpNotFound();
            }
            return View(book11);
        }

        // GET: book11/Create
        public ActionResult Create()
        {
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: book11/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(book11 book11)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in book11.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Books"), fileName);
                        file.SaveAs(filePath);
                    }

                    db.book11.Add(book11);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }

            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", book11.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", book11.year_id);
            return View(book11);
        }


        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Books"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        // GET: book11/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book11 book11 = db.book11.Find(id);
            if (book11 == null)
            {
                return HttpNotFound();
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", book11.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", book11.year_id);
            return View(book11);
        }

        // POST: book11/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "book_id,year_id,book_name,book_author,specification,edition,subject_id")] book11 book11)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book11).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subject_id = new SelectList(db.Subjects, "subject_id", "Subject_Name", book11.subject_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", book11.year_id);
            return View(book11);
        }

        // GET: book11/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book11 book11 = db.book11.Find(id);
            if (book11 == null)
            {
                return HttpNotFound();
            }
            return View(book11);
        }

        // POST: book11/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book11 book11 = db.book11.Find(id);
            db.book11.Remove(book11);
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
