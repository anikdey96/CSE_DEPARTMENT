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
    public class notice12Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: notice12
        public ActionResult Index()
        {
            return View(db.notice12.ToList());
        }

        // GET: notice12/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice12 notice12 = db.notice12.Find(id);
            if (notice12 == null)
            {
                return HttpNotFound();
            }
            return View(notice12);
        }

        // GET: notice12/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: notice12/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(notice12 notice12)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in notice12.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Notices"), fileName);
                        file.SaveAs(filePath);
                    }

                    db.notice12.Add(notice12);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }

            return View(notice12);
        }

        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Notices"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }


        // GET: notice12/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice12 notice12 = db.notice12.Find(id);
            if (notice12 == null)
            {
                return HttpNotFound();
            }
            return View(notice12);
        }

        // POST: notice12/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "notice_id,notice_upload,notice_topic,published_by,publish_date,created_by,created_date,updated_by,updated_date,deadline,priority,specification")] notice12 notice12)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice12).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notice12);
        }

        // GET: notice12/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice12 notice12 = db.notice12.Find(id);
            if (notice12 == null)
            {
                return HttpNotFound();
            }
            return View(notice12);
        }

        // POST: notice12/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notice12 notice12 = db.notice12.Find(id);
            db.notice12.Remove(notice12);
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
