using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheLastPlate2.Models;

namespace TheLastPlate2.Controllers
{
    public class ListingsController : Controller
    {
        private LastPlate2Context db = new LastPlate2Context();


        public ActionResult Product2ListingCreate(int? product_ID)
        {
            ViewBag.product_ID = product_ID;
            return View();
        }


        // GET: Listings
        public ActionResult Index()
        {
            var listings = db.Listings.Include(l => l.Product);
            return View(listings.ToList());
        }

        // GET: Listings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // GET: Listings/Create
        public ActionResult Create()
        {
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Description");
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Listing listing, HttpPostedFileBase file)
        {


            if (ModelState.IsValid)
            {

                db.Products.Add(listing.Product);

                listing.Product_ID = db.Products.Max(x => x.Product_ID); //this is bad logic because if more than one person is posting a product then we cannot control how the id is assignded

                db.Listings.Add(listing);
                db.SaveChanges();
                /*
                string name = file.FileName;
                name = Convert.ToString(db.Products.Max(x => x.Product_ID)) + ".png";  //this is bad logic because if more than one person is posting a product then we cannot control how the id is assignded

                string path = Path.Combine(Server.MapPath("~/Content/Images"),
                                           Path.GetFileName(name));
                file.SaveAs(path);*/
                return RedirectToAction("Index");
            }

            
            return View(listing);
        }

        public ActionResult UploadFile()
        {
            return View();
        }

       

        // GET: Listings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Description", listing.Product_ID);
            return View(listing);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Listing_ID,Product_ID,Start_Date,End_Date,Auto_Recreate,Product_Quantity")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Description", listing.Product_ID);
            return View(listing);
        }

        // GET: Listings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Listing listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
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
