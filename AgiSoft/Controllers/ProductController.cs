/***********************************************************************************************
************************************************************************************************
* <author>Ralph Bohn & Harshad Deshmukh</author>                                               *
* <email>info@cueowl.com</email>                                                               *
* <date>2013-06-01</date>                                                                      *
* <file>ProductController.cs</file>                                                            *
* <summary>Contains the Controller methods for Product in MVC framework.                       *
*      Controls the product info for AgiSoft</summary>                                         *
************************************************************************************************      
************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgiSoft.Models;
using System.Data;

namespace AgiSoft.Controllers {
    public class ProductController : Controller {
        // Fields
        CueDb db = new CueDb();


        // GET: /Product
        public ActionResult Index() {
            return View();
        }
        
        // GET: /Product/Features/
        public ActionResult Features() {
            return View();
        }

        // GET: /Product/Pricing/
        public ActionResult Pricing() {
            return View();
        }

        // GET: /Product/Support/
        public ActionResult Support() {
            return View();
        }

        // GET: /Product/Order/
        public ActionResult SignUp() {
            return View();
        }

        // GET: /Product/Admin
        [Authorize(Roles="CueOwl")]
        public ActionResult Admin() {
            return View(db.Products.ToList());
        }

        // GET: /Product/Details/5
        [Authorize(Roles = "CueOwl")]
        public ActionResult Details(int id=0) {
            Products products = db.Products.Find(id);
            if (products == null) {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: /Product/Create
        [Authorize(Roles = "CueOwl")]
        public ActionResult Create() {
            
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CueOwl")]
        public ActionResult Create(Products products) {
            if (ModelState.IsValid) {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Admin");
            }

            return View(products);
        }

        // GET: /Product/Edit/5
        [Authorize(Roles = "CueOwl")]
        public ActionResult Edit(int id) {
            Products products = db.Products.Find(id);
            if (products == null) {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: /Product/Edit/5
        [HttpPost]
        [Authorize(Roles = "CueOwl")]
        public ActionResult Edit(Products products) {
            if (ModelState.IsValid) {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(products);
        }

        // GET: /Product/Delete/5
        [Authorize(Roles = "CueOwl")]
        public ActionResult Delete(int id=0) {
            Products products = db.Products.Find(id);
            if (products == null) {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CueOwl")]
        public ActionResult DeleteConfirmed(int id) {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }

        protected override void Dispose(bool disposing) {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}