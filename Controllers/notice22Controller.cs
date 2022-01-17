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
    public class notice22Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: notice22
        public ActionResult Index()
        {
            return View(db.notice22.ToList());
        }

        // GET: notice22/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice22 notice22 = db.notice22.Find(id);
            if (notice22 == null)
            {
                return HttpNotFound();
            }
            return View(notice22);
        }

        // GET: notice22/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: notice22/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(notice22 notice22)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in notice22.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Notices"), fileName);
                        file.SaveAs(filePath);
                    }

                    db.notice22.Add(notice22);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }


            return View(notice22);
        }

        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Notices"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: notice22/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice22 notice22 = db.notice22.Find(id);
            if (notice22 == null)
            {
                return HttpNotFound();
            }
            return View(notice22);
        }

        // POST: notice22/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "notice_id,notice_upload,notice_topic,published_by,publish_date,created_by,created_date,updated_by,updated_date,deadline,priority,specification")] notice22 notice22)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice22).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notice22);
        }

        // GET: notice22/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice22 notice22 = db.notice22.Find(id);
            if (notice22 == null)
            {
                return HttpNotFound();
            }
            return View(notice22);
        }

        // POST: notice22/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notice22 notice22 = db.notice22.Find(id);
            db.notice22.Remove(notice22);
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
