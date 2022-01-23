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
    public class routine41Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: routine41
        public ActionResult Index()
        {
            var routine41 = db.routine41.Include(r => r.Session).Include(r => r.Year);
            return View(routine41.ToList());
        }

        // GET: routine41/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine41 routine41 = db.routine41.Find(id);
            if (routine41 == null)
            {
                return HttpNotFound();
            }
            return View(routine41);
        }

        // GET: routine41/Create
        public ActionResult Create()
        {
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: routine41/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(routine41 routine41)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in routine41.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Routines"), fileName);
                        file.SaveAs(filePath);
                    }
                }


                db.routine41.Add(routine41);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine41.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", routine41.year_id);
            return View(routine41);
        }
        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Routines"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: routine41/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine41 routine41 = db.routine41.Find(id);
            if (routine41 == null)
            {
                return HttpNotFound();
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine41.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", routine41.year_id);
            return View(routine41);
        }

        // POST: routine41/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "routine_id,session_id,comment")] routine41 routine41)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine41).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine41.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", routine41.year_id);
            return View(routine41);
        }

        // GET: routine41/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine41 routine41 = db.routine41.Find(id);
            if (routine41 == null)
            {
                return HttpNotFound();
            }
            return View(routine41);
        }

        // POST: routine41/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            routine41 routine41 = db.routine41.Find(id);
            db.routine41.Remove(routine41);
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
