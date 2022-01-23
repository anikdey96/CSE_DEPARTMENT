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
    public class routine21Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: routine21
        public ActionResult Index()
        {
            var routine21 = db.routine21.Include(r => r.Session).Include(r => r.Year);
            return View(routine21.ToList());
        }

        // GET: routine21/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine21 routine21 = db.routine21.Find(id);
            if (routine21 == null)
            {
                return HttpNotFound();
            }
            return View(routine21);
        }

        // GET: routine21/Create
        public ActionResult Create()
        {
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: routine21/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(routine21 routine21)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in routine21.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Routines"), fileName);
                        file.SaveAs(filePath);
                    }
                }


                db.routine21.Add(routine21);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine21.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", routine21.year_id);
            return View(routine21);
        }

        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Routines"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: routine21/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine21 routine21 = db.routine21.Find(id);
            if (routine21 == null)
            {
                return HttpNotFound();
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine21.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", routine21.year_id);
            return View(routine21);
        }

        // POST: routine21/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "routine_id,session_id,comment")] routine21 routine21)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine21).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine21.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", routine21.year_id);
            return View(routine21);
        }

        // GET: routine21/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine21 routine21 = db.routine21.Find(id);
            if (routine21 == null)
            {
                return HttpNotFound();
            }
            return View(routine21);
        }

        // POST: routine21/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            routine21 routine21 = db.routine21.Find(id);
            db.routine21.Remove(routine21);
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
