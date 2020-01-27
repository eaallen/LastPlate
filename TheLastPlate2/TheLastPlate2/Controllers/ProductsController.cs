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

    public class ProductsController : Controller
    {
        private LastPlate2Context db = new LastPlate2Context();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFile(HttpPostedFileBase file, Product product)
        {

            if (file != null && file.ContentLength > 0)
                try
                {

                    string name = file.FileName;
                    name = Convert.ToString(product.Product_ID) + ".png";

                    string path = Path.Combine(Server.MapPath("~/Content/Images"),
                                               Path.GetFileName(name));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    return RedirectToAction("Product2ListingCreate","Listings",product.Product_ID);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Description");
                    return View("Create");
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
                ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Description");
                return View("Create");
            }
            
        }



        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Description");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_ID,Price,Description,Instructions,Street,City,State,Zip,Date_Posted,Key_Words,Business_ID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Description");
                return View(product);
            }
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Description");
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_ID,Price,Description,Instructions,Street,City,State,Zip,Date_Posted,Key_Words,Business_ID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
