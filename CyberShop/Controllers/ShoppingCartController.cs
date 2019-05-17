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
    public class ShoppingCartController : Controller
    {
        private MINIPROJECT_174772Entities db = new MINIPROJECT_174772Entities();

        

        // GET: ShoppingCart
        public ActionResult Index()
        {
            List<Products_174772> cart = (List<Products_174772>)Session["cart"];
            var shoppingCart_174772 = db.ShoppingCart_174772.Include(s => s.Products_174772);
            //return View(shoppingCart_174772.ToList());
            return View(cart.ToList());
        }

        public ActionResult Index1()
        {
            var shoppingCart_174772 = db.ShoppingCart_174772.Include(s => s.Products_174772);
            return View(shoppingCart_174772.ToList());
        }

        // GET: ShoppingCart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCart_174772 shoppingCart_174772 = db.ShoppingCart_174772.Find(id);
            if (shoppingCart_174772 == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart_174772);
        }

        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products_174772, "ProductId", "ModelNumber");
            return View();
        }

        // POST: ShoppingCart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordId,CartId,Quantity,ProductId,DateCreated")] ShoppingCart_174772 shoppingCart_174772)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingCart_174772.Add(shoppingCart_174772);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products_174772, "ProductId", "ModelNumber", shoppingCart_174772.ProductId);
            return View(shoppingCart_174772);
        }

        // GET: ShoppingCart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCart_174772 shoppingCart_174772 = db.ShoppingCart_174772.Find(id);
            if (shoppingCart_174772 == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products_174772, "ProductId", "ModelNumber", shoppingCart_174772.ProductId);
            return View(shoppingCart_174772);
        }

        // POST: ShoppingCart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordId,CartId,Quantity,ProductId,DateCreated")] ShoppingCart_174772 shoppingCart_174772)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingCart_174772).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products_174772, "ProductId", "ModelNumber", shoppingCart_174772.ProductId);
            return View(shoppingCart_174772);
        }

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCart_174772 shoppingCart_174772 = db.ShoppingCart_174772.Find(id);
            if (shoppingCart_174772 == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart_174772);
        }

        // POST: ShoppingCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingCart_174772 shoppingCart_174772 = db.ShoppingCart_174772.Find(id);
            db.ShoppingCart_174772.Remove(shoppingCart_174772);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Adding to shopping Cart

        public ActionResult AddCart(Products_174772 pd)
        {
            if (Session["cart"] == null)
            {
                //List<Item> cart = new List<Item>();
                //cart.Add(new Item(db.Products_174772.Find(productId),1));
                //Session["cart"] = cart;
                //Session["count"] = 1;

                List<Products_174772> cart = new List<Products_174772>();

                cart.Add(pd);
                Session["cart"] = cart;
                ViewBag.cart = cart.Count();


                Session["count"] = 1;

            }

            else
            {
                List<Products_174772> cart = (List<Products_174772>)Session["cart"];
                cart.Add(pd);
                Session["cart"] = cart;
                ViewBag.cart = cart.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }

            return RedirectToAction("Index1", "ShoppingCart");
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
