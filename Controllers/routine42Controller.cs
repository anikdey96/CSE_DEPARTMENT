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
    public class routine42Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: routine42
        public ActionResult Index()
        {
            var routine42 = db.routine42.Include(r => r.Session);
            return View(routine42.ToList());
        }

        // GET: routine42/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine42 routine42 = db.routine42.Find(id);
            if (routine42 == null)
            {
                return HttpNotFound();
            }
            return View(routine42);
        }

        // GET: routine42/Create
        public ActionResult Create()
        {
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name");
            return View();
        }

        // POST: routine42/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(routine42 routine42)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in routine42.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Routines"), fileName);
                        file.SaveAs(filePath);
                    }
                }


                db.routine42.Add(routine42);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine42.session_id);
            return View(routine42);
        }

        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Materials"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }


        // GET: routine42/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine42 routine42 = db.routine42.Find(id);
            if (routine42 == null)
            {
                return HttpNotFound();
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine42.session_id);
            return View(routine42);
        }

        // POST: routine42/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "routine_id,session_id,comment")] routine42 routine42)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine42).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine42.session_id);
            return View(routine42);
        }

        // GET: routine42/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine42 routine42 = db.routine42.Find(id);
            if (routine42 == null)
            {
                return HttpNotFound();
            }
            return View(routine42);
        }

        // POST: routine42/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            routine42 routine42 = db.routine42.Find(id);
            db.routine42.Remove(routine42);
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
