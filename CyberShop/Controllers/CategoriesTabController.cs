using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CyberShop.Models;
using System.Collections.ObjectModel;

namespace CyberShop.Controllers
{
    public class CategoriesTabController : Controller
    {
        private MINIPROJECT_174772Entities db = new MINIPROJECT_174772Entities();

        // GET: CategoriesTab
        public ActionResult Index()
        {
            return View(db.Categories_174772.ToList());
        }
        public ActionResult IndexElectronicsNew()
        {
            return View(db.Categories_174772.Where(X => X.CategoryId == 1).ToList());
        }
        // GET: CategoriesTab/Details/5
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

        // GET: CategoriesTab/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesTab/Create
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

        // GET: CategoriesTab/Edit/5
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

        // POST: CategoriesTab/Edit/5
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

        // GET: CategoriesTab/Delete/5
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

        // POST: CategoriesTab/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories_174772 categories_174772 = db.Categories_174772.Find(id);
            db.Categories_174772.Remove(categories_174772);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Electronics Tab
        public ActionResult IndexElectronics()
        {
            return View(db.Categories_174772);
        }

        [HttpPost]
        public ActionResult IndexElectronics(string Electronics)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Categories_174772.ToList()
                        where cat.CategoryName == Electronics
                        select cat;
            return View(query);
        }

        // GET: Apparels Tab
        public ActionResult IndexApparels()
        {
            return View(db.Categories_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexApparels(string Apparels)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Categories_174772.ToList()
                        where cat.CategoryName == Apparels
                        select cat;
            return View(query);
        }

        // GET: Furniture Tab
        public ActionResult IndexFurniture()
        {
            return View(db.Categories_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexFurniture(string Furniture)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Categories_174772.ToList()
                        where cat.CategoryName == Furniture
                        select cat;
            return View(query);
        }

        // GET: Books Tab
        public ActionResult IndexBooks()
        {
            return View(db.Categories_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexBooks(string Books)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Categories_174772.ToList()
                        where cat.CategoryName == Books
                        select cat;
            return View(query);
        }

        // GET: Art Tab
        public ActionResult IndexArt()
        {
            return View(db.Categories_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexArt(string Art)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Categories_174772.ToList()
                        where cat.CategoryName == Art
                        select cat;
            return View(query);
        }

        // GET: Samsung Galaxy S10 Tab
        public ActionResult IndexSamsungGalaxy()
        {
            return View(db.Products_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexSamsungGalaxy(string S10)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Products_174772.ToList()
                        where cat.ModelNumber == S10
                        select cat;
            return View(query);
        }

        // GET: MiA2
        public ActionResult IndexMiA2()
        {
            return View(db.Products_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexMiA2(string A2)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Products_174772.ToList()
                        where cat.ModelNumber == A2
                        select cat;
            return View(query);
        }

        // GET: Puma Men Shoes
        public ActionResult IndexPuma()
        {
            return View(db.Products_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexPuma(string Netfit)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Products_174772.ToList()
                        where cat.ModelNumber == Netfit
                        select cat;
            return View(query);
        }

        // GET: Converse
        public ActionResult IndexConverse()
        {
            return View(db.Products_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexConverse(string CUS)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Products_174772.ToList()
                        where cat.ModelNumber == CUS
                        select cat;
            return View(query);
        }

        // GET: Sofa Set
        public ActionResult IndexSofaSet()
        {
            return View(db.Products_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexSofaSet(string ABC)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Products_174772.ToList()
                        where cat.ModelNumber == ABC
                        select cat;
            return View(query);
        }

        // GET: Black Table
        public ActionResult IndexBlackTable()
        {
            return View(db.Products_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexBlackTable(string DEF)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Products_174772.ToList()
                        where cat.ModelNumber == DEF
                        select cat;
            return View(query);
        }

        // GET: Harry Potter
        public ActionResult IndexHarryPotter()
        {
            return View(db.Products_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexHarryPotter(string HP)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Products_174772.ToList()
                        where cat.ModelNumber == HP
                        select cat;
            return View(query);
        }

        // GET: Half gf
        public ActionResult IndexHalfgf()
        {
            return View(db.Products_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexHalfgf(string HG)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Products_174772.ToList()
                        where cat.ModelNumber == HG
                        select cat;
            return View(query);
        }

        // GET: Monalisa
        public ActionResult IndexMonalisa()
        {
            return View(db.Products_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexMonalisa(string M3)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Products_174772.ToList()
                        where cat.ModelNumber == M3
                        select cat;
            return View(query);
        }

        // GET: Piccasso
        public ActionResult IndexPiccasso()
        {
            return View(db.Products_174772.ToList());
        }

        [HttpPost]
        public ActionResult IndexPiccasso(string P3)
        {
            MINIPROJECT_174772Entities MINIPROJECT_174772Model = new MINIPROJECT_174772Entities();
            var query = from cat in MINIPROJECT_174772Model.Products_174772.ToList()
                        where cat.ModelNumber == P3
                        select cat;
            return View(query);
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
