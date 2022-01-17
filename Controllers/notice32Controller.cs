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
    public class notice32Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: notice32
        public ActionResult Index()
        {
            return View(db.notice32.ToList());
        }

        // GET: notice32/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice32 notice32 = db.notice32.Find(id);
            if (notice32 == null)
            {
                return HttpNotFound();
            }
            return View(notice32);
        }

        // GET: notice32/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: notice32/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(notice32 notice32)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in notice32.files)
                {

                    if (file.ContentLength < 5000000)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Notices"), fileName);
                        file.SaveAs(filePath);
                    }

                    db.notice32.Add(notice32);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }


            return View(notice32);
        }



        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Notices"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // GET: notice32/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice32 notice32 = db.notice32.Find(id);
            if (notice32 == null)
            {
                return HttpNotFound();
            }
            return View(notice32);
        }

        // POST: notice32/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "notice_id,notice_upload,notice_topic,published_by,publish_date,created_by,created_date,updated_by,updated_date,deadline,priority,specification")] notice32 notice32)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice32).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notice32);
        }

        // GET: notice32/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notice32 notice32 = db.notice32.Find(id);
            if (notice32 == null)
            {
                return HttpNotFound();
            }
            return View(notice32);
        }

        // POST: notice32/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notice32 notice32 = db.notice32.Find(id);
            db.notice32.Remove(notice32);
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
