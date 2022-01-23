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
    public class rou11Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: rou11
        public ActionResult Index()
        {
            var rou11 = db.rou11.Include(r => r.Session).Include(r => r.Year);
            return View(rou11.ToList());
        }

        // GET: rou11/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rou11 rou11 = db.rou11.Find(id);
            if (rou11 == null)
            {
                return HttpNotFound();
            }
            return View(rou11);
        }

        // GET: rou11/Create
        public ActionResult Create()
        {
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name");
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name");
            return View();
        }

        // POST: rou11/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(rou11 rou11)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in rou11.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Routines"), fileName);
                        file.SaveAs(filePath);
                    }
                }


                db.rou11.Add(rou11);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", rou11.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", rou11.year_id);
            return View(rou11);
        }


        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Routines"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        // GET: rou11/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rou11 rou11 = db.rou11.Find(id);
            if (rou11 == null)
            {
                return HttpNotFound();
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", rou11.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", rou11.year_id);
            return View(rou11);
        }

        // POST: rou11/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "routine_id,year_id,session_id,comment")] rou11 rou11)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rou11).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.session_id = new SelectList(db.Sessions, "session_id", "session_name", rou11.session_id);
            ViewBag.year_id = new SelectList(db.Years, "year_id", "year_name", rou11.year_id);
            return View(rou11);
        }

        // GET: rou11/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rou11 rou11 = db.rou11.Find(id);
            if (rou11 == null)
            {
                return HttpNotFound();
            }
            return View(rou11);
        }

        // POST: rou11/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rou11 rou11 = db.rou11.Find(id);
            db.rou11.Remove(rou11);
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
