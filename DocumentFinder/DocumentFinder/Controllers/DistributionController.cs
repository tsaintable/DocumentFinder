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
    public class DistributionController : Controller
    {
        private DBModel db = new DBModel();

        // GET: Distribution
        public ActionResult Index()
        {
            return View(db.DOCUMENT_DISTRIBUTION.ToList());
        }

        // GET: Distribution/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT_DISTRIBUTION dOCUMENT_DISTRIBUTION = db.DOCUMENT_DISTRIBUTION.Find(id);
            if (dOCUMENT_DISTRIBUTION == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT_DISTRIBUTION);
        }

        // GET: Distribution/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distribution/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UniqueDistrID,UDocIDDistribution,DistributionOwner,DistributionLocation,DistributionAmount,DistributionDateAssigned")] DOCUMENT_DISTRIBUTION dOCUMENT_DISTRIBUTION)
        {
            if (ModelState.IsValid)
            {
                dOCUMENT_DISTRIBUTION.UniqueDistrID = Guid.NewGuid();
                db.DOCUMENT_DISTRIBUTION.Add(dOCUMENT_DISTRIBUTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dOCUMENT_DISTRIBUTION);
        }

        // GET: Distribution/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT_DISTRIBUTION dOCUMENT_DISTRIBUTION = db.DOCUMENT_DISTRIBUTION.Find(id);
            if (dOCUMENT_DISTRIBUTION == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT_DISTRIBUTION);
        }

        // POST: Distribution/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniqueDistrID,UDocIDDistribution,DistributionOwner,DistributionLocation,DistributionAmount,DistributionDateAssigned")] DOCUMENT_DISTRIBUTION dOCUMENT_DISTRIBUTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCUMENT_DISTRIBUTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dOCUMENT_DISTRIBUTION);
        }

        // GET: Distribution/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENT_DISTRIBUTION dOCUMENT_DISTRIBUTION = db.DOCUMENT_DISTRIBUTION.Find(id);
            if (dOCUMENT_DISTRIBUTION == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENT_DISTRIBUTION);
        }

        // POST: Distribution/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DOCUMENT_DISTRIBUTION dOCUMENT_DISTRIBUTION = db.DOCUMENT_DISTRIBUTION.Find(id);
            db.DOCUMENT_DISTRIBUTION.Remove(dOCUMENT_DISTRIBUTION);
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
