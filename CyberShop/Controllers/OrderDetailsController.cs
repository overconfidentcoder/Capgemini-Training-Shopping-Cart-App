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
    public class OrderDetailsController : Controller
    {
        private MINIPROJECT_174772Entities db = new MINIPROJECT_174772Entities();

        // GET: OrderDetails
        public ActionResult Index()
        {
            var orderDetails_174772 = db.OrderDetails_174772.Include(o => o.Products_174772);
            return View(orderDetails_174772.ToList());
        }

        // GET: OrderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetails_174772 orderDetails_174772 = db.OrderDetails_174772.Find(id);
            if (orderDetails_174772 == null)
            {
                return HttpNotFound();
            }
            return View(orderDetails_174772);
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products_174772, "ProductId", "ModelNumber");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,ProductId,Quantity,UnitCost")] OrderDetails_174772 orderDetails_174772)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails_174772.Add(orderDetails_174772);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products_174772, "ProductId", "ModelNumber", orderDetails_174772.ProductId);
            return View(orderDetails_174772);
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetails_174772 orderDetails_174772 = db.OrderDetails_174772.Find(id);
            if (orderDetails_174772 == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products_174772, "ProductId", "ModelNumber", orderDetails_174772.ProductId);
            return View(orderDetails_174772);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,ProductId,Quantity,UnitCost")] OrderDetails_174772 orderDetails_174772)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetails_174772).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products_174772, "ProductId", "ModelNumber", orderDetails_174772.ProductId);
            return View(orderDetails_174772);
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetails_174772 orderDetails_174772 = db.OrderDetails_174772.Find(id);
            if (orderDetails_174772 == null)
            {
                return HttpNotFound();
            }
            return View(orderDetails_174772);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetails_174772 orderDetails_174772 = db.OrderDetails_174772.Find(id);
            db.OrderDetails_174772.Remove(orderDetails_174772);
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
