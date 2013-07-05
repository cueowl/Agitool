/***********************************************************************************************
************************************************************************************************
* <author>Ralph Bohn & Harshad Deshmukh</author>                                               *
* <email>info@cueowl.com</email>                                                               *
* <date>2013-06-01</date>                                                                      *
* <file>AdminController.cs</file>                                                              *
* <summary>Contains the Controller methods for Admin in MVC framework. </summary>              *
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
    public class AdminController : Controller {
        // Fields
        private AgiSoftDb db = new AgiSoftDb();
        

        // GET: /Admin/
        public ActionResult Index() {
            return View();
        }

        // GET: /Admin/Roles
        public ActionResult Roles() {

            return View(Tuple.Create(db.Roles.ToList(), db.RoleGroups.ToList(), db.RolesInGroups.ToList()));
        }

        // GET: /Admin/RolesDetails
        public ActionResult RolesDetails(int id = 0) {
            webpages_Roles roles = db.Roles.Find(id);
            RoleGroups rg = db.RoleGroups.Find(id);

            if (roles == null && rg == null) {
                return HttpNotFound();
            }
            if (roles != null) {
                ViewBag.Type = "role";
                rg = null;
            }
            if (rg != null) {
                ViewBag.Type = "group";
                roles = null;
            }

            return View(Tuple.Create(roles, rg));
        }

        // GET: /Admin/RolesCreate
        public ActionResult RolesCreate() {

            return View();
        }

        // POST: /Admin/RolesCreate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RolesCreate(webpages_Roles roles) {
            if (ModelState.IsValid) {
                db.Roles.Add(roles);
                db.SaveChanges();
                RedirectToAction("Roles");
            }

            return View(roles);
        }

        // GET: /Admin/RolesEdit
        public ActionResult RolesEdit(int id) {
            webpages_Roles roles = db.Roles.Find(id);
            if (roles == null) {
                return HttpNotFound();
            }

            return View(roles);
        }

        // POST: /Admin/RolesEdit/5
        [HttpPost]
        public ActionResult RolesEdit(webpages_Roles roles) {
            if (ModelState.IsValid) {
                db.Entry(roles).State = EntityState.Modified;
                db.SaveChanges();
                RedirectToAction("Roles");
            }

            return View(roles);
        }

        // GET: /Admin/RolesDelete
        public ActionResult RolesDelete(int id = 0) {
            webpages_Roles roles = db.Roles.Find(id);
            if (roles == null) {
                return HttpNotFound();
            }
            return View(roles);
        }

        // POST: /Admin/RolesDelete/5
        [HttpPost, ActionName("RolesDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            webpages_Roles roles = db.Roles.Find(id);
            db.Roles.Remove(roles);
            db.SaveChanges();
            return RedirectToAction("Roles");
        }
    }
}
