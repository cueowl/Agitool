/***********************************************************************************************
************************************************************************************************
* <author>Ralph Bohn & Harshad Deshmukh</author>                                               *
* <email>info@cueowl.com</email>                                                               *
* <date>2013-06-01</date>                                                                      *
* <file>AssignmentController.cs</file>                                                         *
* <summary>Contains the Controller methods for Assignment in MVC framework.                    *
*      Used to [CRUD] assignments and assign to users and track status</summary>               *
************************************************************************************************      
************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgiSoft.Controllers {
    public class AssignmentController : Controller {
        
        // GET: /Assignment/
        public ActionResult Index() {
            return View();
        }

        // GET: /Assignment/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: /Assignment/Create
        public ActionResult Create() {
            return View();
        }

        // POST: /Assignment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: /Assignment/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: /Assignment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: /Assignment/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: /Assignment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}