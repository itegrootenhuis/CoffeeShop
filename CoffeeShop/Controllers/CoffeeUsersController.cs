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
    public class CoffeeUsersController : Controller
    {
        private CoffeeShopDBEntities db = new CoffeeShopDBEntities();

        // GET: CoffeeUsers
        public ActionResult Index()
        {
            return View(db.CoffeeUsers.ToList());
        }

        // GET: CoffeeUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeUser coffeeUser = db.CoffeeUsers.Find(id);
            if (coffeeUser == null)
            {
                return HttpNotFound();
            }
            return View(coffeeUser);
        }

        // GET: CoffeeUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoffeeUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email")] CoffeeUser coffeeUser)
        {
            if (ModelState.IsValid)
            {
                db.CoffeeUsers.Add(coffeeUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coffeeUser);
        }

        // GET: CoffeeUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeUser coffeeUser = db.CoffeeUsers.Find(id);
            if (coffeeUser == null)
            {
                return HttpNotFound();
            }
            return View(coffeeUser);
        }

        // POST: CoffeeUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email")] CoffeeUser coffeeUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffeeUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffeeUser);
        }

        // GET: CoffeeUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeUser coffeeUser = db.CoffeeUsers.Find(id);
            if (coffeeUser == null)
            {
                return HttpNotFound();
            }
            return View(coffeeUser);
        }

        // POST: CoffeeUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoffeeUser coffeeUser = db.CoffeeUsers.Find(id);
            db.CoffeeUsers.Remove(coffeeUser);
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
