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
    public class ProductsController : Controller
    {
        private MINIPROJECT_174772Entities db = new MINIPROJECT_174772Entities();

        // GET: Products
        public ActionResult Index()
        {
            var products_174772 = db.Products_174772.Include(p => p.Categories_174772);
            return View(products_174772.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products_174772 products_174772 = db.Products_174772.Find(id);
            if (products_174772 == null)
            {
                return HttpNotFound();
            }
            return View(products_174772);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories_174772, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,CategoryId,ModelNumber,ModelName,UnitCost,Description")] Products_174772 products_174772)
        {
            if (ModelState.IsValid)
            {
                db.Products_174772.Add(products_174772);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories_174772, "CategoryId", "CategoryName", products_174772.CategoryId);
            return View(products_174772);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products_174772 products_174772 = db.Products_174772.Find(id);
            if (products_174772 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories_174772, "CategoryId", "CategoryName", products_174772.CategoryId);
            return View(products_174772);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,CategoryId,ModelNumber,ModelName,UnitCost,Description")] Products_174772 products_174772)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products_174772).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories_174772, "CategoryId", "CategoryName", products_174772.CategoryId);
            return View(products_174772);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products_174772 products_174772 = db.Products_174772.Find(id);
            if (products_174772 == null)
            {
                return HttpNotFound();
            }
            return View(products_174772);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products_174772 products_174772 = db.Products_174772.Find(id);
            db.Products_174772.Remove(products_174772);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Search for Products
        public ActionResult SearchProduct()
        {
            return View(db.Products_174772.ToList());
        }

        
        [HttpPost]
        
        public ActionResult SearchProduct(string @ModelName)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            //var query = MINIP ROJECT_174772Model.SearchProduct.

            return View();
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
