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
    public class DocumentController : Controller
    {
        private DBModel db = new DBModel();

        // GET: Document
        public ActionResult Index()
        {
            return View(db.DOCUMENTs.ToList());
        }

        // GET: Document/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT dOCUMENT = db.DOCUMENTs.Find(id);
            if (dOCUMENT == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT);
        }

        // GET: Document/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Document/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UniqueDocID,DocID,DocType,DocName,DocManuf,DocCatg,DocWONum,DocPONum,DocDate,DocProjMgr,DocEqpAmt,DocDescr")] DOCUMENT dOCUMENT)
        {
            if (ModelState.IsValid)
            {
                dOCUMENT.UniqueDocID = Guid.NewGuid();
                db.DOCUMENTs.Add(dOCUMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dOCUMENT);
        }

        // GET: Document/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT dOCUMENT = db.DOCUMENTs.Find(id);
            if (dOCUMENT == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT);
        }

        // POST: Document/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniqueDocID,DocID,DocType,DocName,DocManuf,DocCatg,DocWONum,DocPONum,DocDate,DocProjMgr,DocEqpAmt,DocDescr")] DOCUMENT dOCUMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCUMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dOCUMENT);
        }

        // GET: Document/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT dOCUMENT = db.DOCUMENTs.Find(id);
            if (dOCUMENT == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT);
        }

        // POST: Document/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DOCUMENT dOCUMENT = db.DOCUMENTs.Find(id);
            db.DOCUMENTs.Remove(dOCUMENT);
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
