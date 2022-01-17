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
    public class routine32Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: routine32
        public ActionResult Index()
        {
            var routine32 = db.routine32.Include(r => r.Session);
            return View(routine32.ToList());
        }

        // GET: routine32/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine32 routine32 = db.routine32.Find(id);
            if (routine32 == null)
            {
                return HttpNotFound();
            }
            return View(routine32);
        }

        // GET: routine32/Create
        public ActionResult Create()
        {
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name");
            return View();
        }

        // POST: routine32/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(routine32 routine32)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in routine32.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Routines"), fileName);
                        file.SaveAs(filePath);
                    }
                }


                db.routine32.Add(routine32);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine32.session_id);
            return View(routine32);
        }


        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Materials"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: routine32/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine32 routine32 = db.routine32.Find(id);
            if (routine32 == null)
            {
                return HttpNotFound();
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine32.session_id);
            return View(routine32);
        }

        // POST: routine32/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "routine_id,session_id,comment")] routine32 routine32)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine32).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", routine32.session_id);
            return View(routine32);
        }

        // GET: routine32/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            routine32 routine32 = db.routine32.Find(id);
            if (routine32 == null)
            {
                return HttpNotFound();
            }
            return View(routine32);
        }

        // POST: routine32/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            routine32 routine32 = db.routine32.Find(id);
            db.routine32.Remove(routine32);
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
