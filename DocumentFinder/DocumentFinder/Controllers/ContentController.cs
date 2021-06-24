using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DocumentFinder.Models;

namespace DocumentFinder.Controllers
{
    public class ContentController : Controller
    {
        private DBModel db = new DBModel();

        // GET: Content
        public ActionResult Index()
        {
            return View(db.DOCUMENT_CONTENT.ToList());
        }

        // GET: Content/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT_CONTENT dOCUMENT_CONTENT = db.DOCUMENT_CONTENT.Find(id);
            if (dOCUMENT_CONTENT == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT_CONTENT);
        }

        // GET: Content/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Content/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UniqueContentID,UDocIDContact,ContentNumber,ContentDescription,ContentVersion,ContentDateAssigned")] DOCUMENT_CONTENT dOCUMENT_CONTENT)
        {
            if (ModelState.IsValid)
            {
                dOCUMENT_CONTENT.UniqueContentID = Guid.NewGuid();
                db.DOCUMENT_CONTENT.Add(dOCUMENT_CONTENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dOCUMENT_CONTENT);
        }

        // GET: Content/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT_CONTENT dOCUMENT_CONTENT = db.DOCUMENT_CONTENT.Find(id);
            if (dOCUMENT_CONTENT == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT_CONTENT);
        }

        // POST: Content/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniqueContentID,UDocIDContact,ContentNumber,ContentDescription,ContentVersion,ContentDateAssigned")] DOCUMENT_CONTENT dOCUMENT_CONTENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCUMENT_CONTENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dOCUMENT_CONTENT);
        }

        // GET: Content/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT_CONTENT dOCUMENT_CONTENT = db.DOCUMENT_CONTENT.Find(id);
            if (dOCUMENT_CONTENT == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT_CONTENT);
        }

        // POST: Content/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DOCUMENT_CONTENT dOCUMENT_CONTENT = db.DOCUMENT_CONTENT.Find(id);
            db.DOCUMENT_CONTENT.Remove(dOCUMENT_CONTENT);
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
