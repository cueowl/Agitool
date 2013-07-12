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
using WebMatrix.WebData;
using System.Web.Security;

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
            webRoles roles = db.Roles.Find(id);
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
        public ActionResult RolesCreate(webRoles roles) {
            if (ModelState.IsValid) {
                db.Roles.Add(roles);
                db.SaveChanges();
                return RedirectToAction("Roles");
            }
            return View(roles);
        }

        // GET: /Admin/GroupsCreate
        public ActionResult GroupsCreate() {

            return View();
        }

        // POST: /Admin/GroupsCreate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GroupsCreate(RoleGroups groups) {
            if (ModelState.IsValid) {
                db.RoleGroups.Add(groups);
                db.SaveChanges();
                return RedirectToAction("Roles");
            }
            return View(groups);
        }

        // GET: /Admin/RolesEdit
        public ActionResult RolesEdit(int id) {
            webRoles roles = db.Roles.Find(id);
            List<webRoles> rlist = null;
            RoleGroups groups = db.RoleGroups.Find(id);
            List<RolesInGroups> rig = null;

            if (roles == null && groups == null) {
                return HttpNotFound();
            }
            
            if (roles != null) {
                ViewBag.Type = "role";
                groups = null;
            }
            if (groups != null) {
                ViewBag.Type = "group";
                rig = db.RolesInGroups.ToList();
                rlist = db.Roles.ToList();
                roles = null;
            }

            return View(Tuple.Create(roles,groups,rig,rlist));
        }

        // POST: /Admin/RolesEdit/5
        [HttpPost]
        public ActionResult RolesEdit(webRoles roles,RoleGroups grp, RolesInGroups rg, string type) {
            if (type == "role") {
                if (ModelState.IsValid) {
                    db.Entry(roles).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Roles");
                }
            }
            if (type == "grp") {
                if (ModelState.IsValid) {
                    db.Entry(grp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Roles");
                }
            }
            if (type == "rg") {
                if (ModelState.IsValid) {
                    db.Entry(rg).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Roles");
                }
            }

            return View(roles);
        }

        // GET: /Admin/RolesDelete
        public ActionResult RolesDelete(int id = 0) {
            webRoles roles = db.Roles.Find(id);
            if (roles == null) {
                return HttpNotFound();
            }
            return View(roles);
        }

        // POST: /Admin/RolesDelete/5
        [HttpPost, ActionName("RolesDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            webRoles roles = db.Roles.Find(id);
            db.Roles.Remove(roles);
            db.SaveChanges();
            return RedirectToAction("Roles");
        }

        // GET: /Admin/ToolUsers
        public ActionResult ToolUsers() {

            return View(db.UserProfiles.ToList());
        }

        // GET: /Admin/AddToolUsers
        public ActionResult AddToolUsers() {

            return View();
        }

        // POST: /Admin/AddToolUsers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToolUsers(AgiRegisterModel model) {
            if (ModelState.IsValid) {
                // Attempt to register the user
                try {
                    /*
                    model.Password = "temppass";
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    WebSecurity.Login(model.UserName, model.Password);
                    */
                    AgiUser u = new AgiUser(model);
                    u.AddUser();

                    return RedirectToAction("Index", "Home");
                } catch (MembershipCreateUserException e) {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus) {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus) {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}
