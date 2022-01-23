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
    public class routine22Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: routine22
        public ActionResult Index()
        {
            var routine22 = db.routine22.Include(r => r.Session).Include(r => r.Year);
            return View(routine22.ToList());
        }

        // GET: routine22/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine22 routine22 = db.routine22.Find(id);
            if (routine22 == null)
            {
                return HttpNotFound();
            }
            return View(routine22);
        }

        // GET: routine22/Create
        public ActionResult Create()
        {
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: routine22/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(routine22 routine22)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in routine22.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Routines"), fileName);
                        file.SaveAs(filePath);
                    }
                }


                db.routine22.Add(routine22);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine22.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", routine22.year_id);
            return View(routine22);
        }

        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Routines"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: routine22/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine22 routine22 = db.routine22.Find(id);
            if (routine22 == null)
            {
                return HttpNotFound();
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine22.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", routine22.year_id);
            return View(routine22);
        }

        // POST: routine22/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "routine_id,session_id,comment")] routine22 routine22)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine22).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine22.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", routine22.year_id);
            return View(routine22);
        }

        // GET: routine22/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine22 routine22 = db.routine22.Find(id);
            if (routine22 == null)
            {
                return HttpNotFound();
            }
            return View(routine22);
        }

        // POST: routine22/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            routine22 routine22 = db.routine22.Find(id);
            db.routine22.Remove(routine22);
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
