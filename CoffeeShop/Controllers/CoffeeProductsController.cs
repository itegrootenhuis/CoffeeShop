using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class CoffeeProductsController : Controller
    {
        private CoffeeShopDBEntities db = new CoffeeShopDBEntities();

        // GET: CoffeeProducts
        public ActionResult Index()
        {
            return View(db.CoffeeProducts.ToList());
        }

        // GET: CoffeeProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeProduct coffeeProduct = db.CoffeeProducts.Find(id);
            if (coffeeProduct == null)
            {
                return HttpNotFound();
            }
            return View(coffeeProduct);
        }

        // GET: CoffeeProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoffeeProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Image,price,ID")] CoffeeProduct coffeeProduct)
        {
            if (ModelState.IsValid)
            {
                db.CoffeeProducts.Add(coffeeProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coffeeProduct);
        }

        // GET: CoffeeProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeProduct coffeeProduct = db.CoffeeProducts.Find(id);
            if (coffeeProduct == null)
            {
                return HttpNotFound();
            }
            return View(coffeeProduct);
        }

        // POST: CoffeeProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Description,Image,price,ID")] CoffeeProduct coffeeProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffeeProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffeeProduct);
        }

        // GET: CoffeeProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeProduct coffeeProduct = db.CoffeeProducts.Find(id);
            if (coffeeProduct == null)
            {
                return HttpNotFound();
            }
            return View(coffeeProduct);
        }

        // POST: CoffeeProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoffeeProduct coffeeProduct = db.CoffeeProducts.Find(id);
            db.CoffeeProducts.Remove(coffeeProduct);
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
