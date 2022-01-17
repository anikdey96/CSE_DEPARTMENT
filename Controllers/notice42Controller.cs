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
    public class notice42Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: notice42
        public ActionResult Index()
        {
            return View(db.notice42.ToList());
        }

        // GET: notice42/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice42 notice42 = db.notice42.Find(id);
            if (notice42 == null)
            {
                return HttpNotFound();
            }
            return View(notice42);
        }

        // GET: notice42/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: notice42/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(notice42 notice42)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in notice42.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Notices"), fileName);
                        file.SaveAs(filePath);
                    }

                    db.notice42.Add(notice42);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }


            return View(notice42);
        }



        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Notices"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }


        // GET: notice42/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice42 notice42 = db.notice42.Find(id);
            if (notice42 == null)
            {
                return HttpNotFound();
            }
            return View(notice42);
        }

        // POST: notice42/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "notice_id,notice_upload,notice_topic,published_by,publish_date,created_by,created_date,updated_by,updated_date,deadline,priority,specification")] notice42 notice42)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice42).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notice42);
        }

        // GET: notice42/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice42 notice42 = db.notice42.Find(id);
            if (notice42 == null)
            {
                return HttpNotFound();
            }
            return View(notice42);
        }

        // POST: notice42/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notice42 notice42 = db.notice42.Find(id);
            db.notice42.Remove(notice42);
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
