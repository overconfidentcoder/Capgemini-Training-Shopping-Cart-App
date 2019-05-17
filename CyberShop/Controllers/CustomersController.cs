using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CyberShop.Models;
using Rotativa;

namespace CyberShop.Controllers
{
    public class CustomersController : Controller
    {
        private MINIPROJECT_174772Entities db = new MINIPROJECT_174772Entities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers_174772.ToList());
        }

        // GET: Customers/Details/5
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

        // GET: Customers/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FullName,EmailId,Password,DeliveryAddress")] Customers_174772 customers_174772)
        {
            if (ModelState.IsValid)
            {
                db.Customers_174772.Add(customers_174772);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers_174772);
        }

        // GET: Customers/Edit/5
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

        // POST: Customers/Edit/5
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

        // GET: Customers/Delete/5
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

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers_174772 customers_174772 = db.Customers_174772.Find(id);
            db.Customers_174772.Remove(customers_174772);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NewCustomer()
        {
            return View(db.Customers_174772.ToList());
        }

        [HttpPost]

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult GetAll()
        //{
        //    var all = db.Customers_174772.ToList();
        //    return View(all);
        //}

        //public ActionResult printAll()
        //{
        //    var q = new ActionAsPdf("Getall")
        //        return q;
        //}

    }
}
