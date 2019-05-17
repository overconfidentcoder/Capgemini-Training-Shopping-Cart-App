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
    public class OrdersController : Controller
    {
        private MINIPROJECT_174772Entities db = new MINIPROJECT_174772Entities();

        // GET: Orders
        public ActionResult Index()
        {
            var orders_174772 = db.Orders_174772.Include(o => o.Customers_174772);
            return View(orders_174772.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders_174772 orders_174772 = db.Orders_174772.Find(id);
            if (orders_174772 == null)
            {
                return HttpNotFound();
            }
            return View(orders_174772);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers_174772, "CustomerId", "FullName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,CustomerId,OrderDate,ShipDate")] Orders_174772 orders_174772)
        {
            if (ModelState.IsValid)
            {
                db.Orders_174772.Add(orders_174772);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers_174772, "CustomerId", "FullName", orders_174772.CustomerId);
            return View(orders_174772);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders_174772 orders_174772 = db.Orders_174772.Find(id);
            if (orders_174772 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers_174772, "CustomerId", "FullName", orders_174772.CustomerId);
            return View(orders_174772);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerId,OrderDate,ShipDate")] Orders_174772 orders_174772)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders_174772).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers_174772, "CustomerId", "FullName", orders_174772.CustomerId);
            return View(orders_174772);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders_174772 orders_174772 = db.Orders_174772.Find(id);
            if (orders_174772 == null)
            {
                return HttpNotFound();
            }
            return View(orders_174772);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders_174772 orders_174772 = db.Orders_174772.Find(id);
            db.Orders_174772.Remove(orders_174772);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Myorder()
        {

            return View((List<Products_174772>)Session["cart"]);

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
