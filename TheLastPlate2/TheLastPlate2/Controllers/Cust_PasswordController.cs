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
    public class Cust_PasswordController : Controller
    {
        private LastPlate2Context db = new LastPlate2Context();

        // GET: Cust_Password
        public ActionResult Index()
        {
            return View(db.Cust_Passwords.ToList());
        }

        // GET: Cust_Password/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_Password cust_Password = db.Cust_Passwords.Find(id);
            if (cust_Password == null)
            {
                return HttpNotFound();
            }
            return View(cust_Password);
        }

        // GET: Cust_Password/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cust_Password/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cust_ID,Password")] Cust_Password cust_Password)
        {
            if (ModelState.IsValid)
            {
                db.Cust_Passwords.Add(cust_Password);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cust_Password);
        }

        // GET: Cust_Password/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_Password cust_Password = db.Cust_Passwords.Find(id);
            if (cust_Password == null)
            {
                return HttpNotFound();
            }
            return View(cust_Password);
        }

        // POST: Cust_Password/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cust_ID,Password")] Cust_Password cust_Password)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cust_Password).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cust_Password);
        }

        // GET: Cust_Password/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_Password cust_Password = db.Cust_Passwords.Find(id);
            if (cust_Password == null)
            {
                return HttpNotFound();
            }
            return View(cust_Password);
        }

        // POST: Cust_Password/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cust_Password cust_Password = db.Cust_Passwords.Find(id);
            db.Cust_Passwords.Remove(cust_Password);
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
