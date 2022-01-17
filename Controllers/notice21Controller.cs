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
    public class notice21Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: notice21
        public ActionResult Index()
        {
            return View(db.notice21.ToList());
        }

        // GET: notice21/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice21 notice21 = db.notice21.Find(id);
            if (notice21 == null)
            {
                return HttpNotFound();
            }
            return View(notice21);
        }

        // GET: notice21/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: notice21/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(notice21 notice21)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in notice21.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Notices"), fileName);
                        file.SaveAs(filePath);
                    }

                    db.notice21.Add(notice21);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }


            return View(notice21);
        }


        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Notices"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: notice21/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice21 notice21 = db.notice21.Find(id);
            if (notice21 == null)
            {
                return HttpNotFound();
            }
            return View(notice21);
        }

        // POST: notice21/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "notice_id,notice_upload,notice_topic,published_by,publish_date,created_by,created_date,updated_by,updated_date,deadline,priority,specification")] notice21 notice21)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice21).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notice21);
        }

        // GET: notice21/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice21 notice21 = db.notice21.Find(id);
            if (notice21 == null)
            {
                return HttpNotFound();
            }
            return View(notice21);
        }

        // POST: notice21/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notice21 notice21 = db.notice21.Find(id);
            db.notice21.Remove(notice21);
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
