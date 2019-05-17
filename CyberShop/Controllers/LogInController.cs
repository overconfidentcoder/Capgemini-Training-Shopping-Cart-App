using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CyberShop.Models;

namespace CyberShop.Controllers
{
    public class LogInController : Controller
    {
        private MINIPROJECT_174772Entities db = new MINIPROJECT_174772Entities();

        // GET: LogIn
        public ActionResult Index()
        {
            return View(db.Customers_174772.ToList());
        }

        // GET: LogIn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers_174772 customers_174772 = db.Customers_174772.Find(id);
            if (customers_174772 == null)
            {
                return HttpNotFound();
            }
            return View(customers_174772);
        }

        // GET: LogIn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogIn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FullName,EmailId,Password,DeliveryAddress")] Customers_174772 customers_174772)
        {
            if (ModelState.IsValid)
            {
                db.Customers_174772.Add(customers_174772);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers_174772);
        }

        // GET: LogIn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers_174772 customers_174772 = db.Customers_174772.Find(id);
            if (customers_174772 == null)
            {
                return HttpNotFound();
            }
            return View(customers_174772);
        }

        // POST: LogIn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FullName,EmailId,Password,DeliveryAddress")] Customers_174772 customers_174772)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers_174772).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers_174772);
        }

        // GET: LogIn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers_174772 customers_174772 = db.Customers_174772.Find(id);
            if (customers_174772 == null)
            {
                return HttpNotFound();
            }
            return View(customers_174772);
        }

        // POST: LogIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers_174772 customers_174772 = db.Customers_174772.Find(id);
            db.Customers_174772.Remove(customers_174772);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customers_174772 objUser)
        {
            if(ModelState.IsValid)
            {
                using (db)
                {
                    var obj = db.Customers_174772.Where(a => a.EmailId.Equals(objUser.EmailId) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if(obj != null)
                    {
                        Session["CustomerId"] = obj.CustomerId.ToString();
                        Session["EmailId"] = obj.EmailId.ToString();
                        return RedirectToAction("index","Home");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult Home()
        {
            if(Session["CustomerId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
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
