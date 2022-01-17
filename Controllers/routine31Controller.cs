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
    public class routine31Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: routine31
        public ActionResult Index()
        {
            var routine31 = db.routine31.Include(r => r.Session);
            return View(routine31.ToList());
        }

        // GET: routine31/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine31 routine31 = db.routine31.Find(id);
            if (routine31 == null)
            {
                return HttpNotFound();
            }
            return View(routine31);
        }

        // GET: routine31/Create
        public ActionResult Create()
        {
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name");
            return View();
        }

        // POST: routine31/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(routine31 routine31)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in routine31.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Routines"), fileName);
                        file.SaveAs(filePath);
                    }
                }


                db.routine31.Add(routine31);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine31.session_id);
            return View(routine31);
        }


        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Materials"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: routine31/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine31 routine31 = db.routine31.Find(id);
            if (routine31 == null)
            {
                return HttpNotFound();
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine31.session_id);
            return View(routine31);
        }

        // POST: routine31/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "routine_id,session_id,comment")] routine31 routine31)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine31).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine31.session_id);
            return View(routine31);
        }

        // GET: routine31/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine31 routine31 = db.routine31.Find(id);
            if (routine31 == null)
            {
                return HttpNotFound();
            }
            return View(routine31);
        }

        // POST: routine31/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            routine31 routine31 = db.routine31.Find(id);
            db.routine31.Remove(routine31);
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
