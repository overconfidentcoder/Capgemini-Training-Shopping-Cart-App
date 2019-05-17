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
    public class CategoriesController : Controller
    {
        private MINIPROJECT_174772Entities db = new MINIPROJECT_174772Entities();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories_174772.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories_174772 categories_174772 = db.Categories_174772.Find(id);
            if (categories_174772 == null)
            {
                return HttpNotFound();
            }
            return View(categories_174772);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,Description")] Categories_174772 categories_174772)
        {
            if (ModelState.IsValid)
            {
                db.Categories_174772.Add(categories_174772);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(categories_174772);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories_174772 categories_174772 = db.Categories_174772.Find(id);
            if (categories_174772 == null)
            {
                return HttpNotFound();
            }
            return View(categories_174772);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,Description")] Categories_174772 categories_174772)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categories_174772).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categories_174772);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories_174772 categories_174772 = db.Categories_174772.Find(id);
            if (categories_174772 == null)
            {
                return HttpNotFound();
            }
            return View(categories_174772);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories_174772 categories_174772 = db.Categories_174772.Find(id);
            db.Categories_174772.Remove(categories_174772);
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
