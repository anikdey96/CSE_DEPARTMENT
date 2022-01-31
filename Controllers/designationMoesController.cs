using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSE_DEPARTMENT.Models;

namespace CSE_DEPARTMENT.Controllers
{
    public class designationMoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: designationMoes
        public ActionResult Index()
        {
            return View(db.designationMoes.ToList());
        }

        // GET: designationMoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            designationMo designationMo = db.designationMoes.Find(id);
            if (designationMo == null)
            {
                return HttpNotFound();
            }
            return View(designationMo);
        }

        // GET: designationMoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: designationMoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "did,Designation")] designationMo designationMo)
        {
            if (ModelState.IsValid)
            {
                db.designationMoes.Add(designationMo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designationMo);
        }

        // GET: designationMoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            designationMo designationMo = db.designationMoes.Find(id);
            if (designationMo == null)
            {
                return HttpNotFound();
            }
            return View(designationMo);
        }

        // POST: designationMoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "did,Designation")] designationMo designationMo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designationMo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designationMo);
        }

        // GET: designationMoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            designationMo designationMo = db.designationMoes.Find(id);
            if (designationMo == null)
            {
                return HttpNotFound();
            }
            return View(designationMo);
        }

        // POST: designationMoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            designationMo designationMo = db.designationMoes.Find(id);
            db.designationMoes.Remove(designationMo);
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
