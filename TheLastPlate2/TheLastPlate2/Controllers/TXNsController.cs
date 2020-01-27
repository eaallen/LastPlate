using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheLastPlate2.Models;

namespace TheLastPlate2.Controllers
{
    public class TXNsController : Controller
    {
        private LastPlate2Context db = new LastPlate2Context();

        // GET: TXNs
        public ActionResult Index()
        {
            var tXNs = db.TXNs.Include(t => t.Customer).Include(t => t.Listing);
            return View(tXNs.ToList());
        }

        // GET: TXNs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TXN tXN = db.TXNs.Find(id);
            if (tXN == null)
            {
                return HttpNotFound();
            }
            return View(tXN);
        }

        // GET: TXNs/Create
        public ActionResult Create()
        {
            ViewBag.Cust_ID = new SelectList(db.Customers, "Cust_ID", "Cust_Email");
            ViewBag.Listing_ID = new SelectList(db.Listings, "Listing_ID", "Listing_ID");
            return View();
        }

        // POST: TXNs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TXN_ID,Cust_ID,Listing_ID,Purchased_Quantity,Total_Price,Date_of_Transaction")] TXN tXN)
        {
            if (ModelState.IsValid)
            {
                db.TXNs.Add(tXN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cust_ID = new SelectList(db.Customers, "Cust_ID", "Cust_Email", tXN.Cust_ID);
            ViewBag.Listing_ID = new SelectList(db.Listings, "Listing_ID", "Listing_ID", tXN.Listing_ID);
            return View(tXN);
        }

        // GET: TXNs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TXN tXN = db.TXNs.Find(id);
            if (tXN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cust_ID = new SelectList(db.Customers, "Cust_ID", "Cust_Email", tXN.Cust_ID);
            ViewBag.Listing_ID = new SelectList(db.Listings, "Listing_ID", "Listing_ID", tXN.Listing_ID);
            return View(tXN);
        }

        // POST: TXNs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TXN_ID,Cust_ID,Listing_ID,Purchased_Quantity,Total_Price,Date_of_Transaction")] TXN tXN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tXN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cust_ID = new SelectList(db.Customers, "Cust_ID", "Cust_Email", tXN.Cust_ID);
            ViewBag.Listing_ID = new SelectList(db.Listings, "Listing_ID", "Listing_ID", tXN.Listing_ID);
            return View(tXN);
        }

        // GET: TXNs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TXN tXN = db.TXNs.Find(id);
            if (tXN == null)
            {
                return HttpNotFound();
            }
            return View(tXN);
        }

        // POST: TXNs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TXN tXN = db.TXNs.Find(id);
            db.TXNs.Remove(tXN);
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
