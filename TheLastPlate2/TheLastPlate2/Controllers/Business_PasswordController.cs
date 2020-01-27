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
    public class Business_PasswordController : Controller
    {
        private LastPlate2Context db = new LastPlate2Context();

        // GET: Business_Password
        public ActionResult Index()
        {
            return View(db.Business_Passwords.ToList());
        }

        // GET: Business_Password/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business_Password business_Password = db.Business_Passwords.Find(id);
            if (business_Password == null)
            {
                return HttpNotFound();
            }
            return View(business_Password);
        }

        // GET: Business_Password/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Business_Password/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Business_Password business_Password)
        {
            if (ModelState.IsValid)
            {

                db.Businesses.Add(business_Password.Business);
               // db.SaveChanges();


                List<Business> businesses = db.Businesses.ToList();

                business_Password.Business_ID = db.Businesses.Max(x => x.Business_ID);
                business_Password.Business = null;
                
                db.Business_Passwords.Add(business_Password);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(business_Password);
        }

        // GET: Business_Password/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business_Password business_Password = db.Business_Passwords.Find(id);
            if (business_Password == null)
            {
                return HttpNotFound();
            }
            return View(business_Password);
        }

        // POST: Business_Password/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Business_ID,Password")] Business_Password business_Password)
        {
            if (ModelState.IsValid)
            {
                db.Entry(business_Password).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(business_Password);
        }

        // GET: Business_Password/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business_Password business_Password = db.Business_Passwords.Find(id);
            if (business_Password == null)
            {
                return HttpNotFound();
            }
            return View(business_Password);
        }

        // POST: Business_Password/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Business_Password business_Password = db.Business_Passwords.Find(id);
            db.Business_Passwords.Remove(business_Password);
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
