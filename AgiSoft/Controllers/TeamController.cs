/***********************************************************************************************
************************************************************************************************
* <author>Ralph Bohn & Harshad Deshmukh</author>                                               *
* <email>info@cueowl.com</email>                                                               *
* <date>2013-06-01</date>                                                                      *
* <file>TeamController.cs</file>                                                               *
* <summary>Contains the Controller methods for Team in MVC framework.                          *
*      [CRUD] for team members and other functions at team level</summary>                     *
************************************************************************************************      
************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using AgiSoft.Models;

namespace AgiSoft.Controllers {
    [Authorize]
    public class TeamController : Controller {
        private AgiSoftDb db = new AgiSoftDb();

        // GET: /Team/
        public ActionResult Index() {
            return View(db.Teams.ToList());
        }

        // GET: /Team/Member
        public ActionResult Member() {
            int uid = WebSecurity.GetUserId(User.Identity.Name);
            Teams t = db.Teams.Find(uid);
            
            return View(db.UsersOnTeam.Where(x=>x.TeamId == t.TeamId).ToList());
        }

        // GET: /Team/MemberTeams
        public ActionResult MemberTeams(int id) {
            Teams t = db.Teams.Find(id);
            TeamViewModel tvm = new TeamViewModel(t);


            return View(tvm);
        }

        // GET: /Team/TeamProject
        public ActionResult TeamProject() {
            return View();
        }

        // GET: /Team/Assignment
        public ActionResult Assignment() {
            return View();
        }

        // GET: /Team/Teams
        public ActionResult Teams() {
            return View(db.Teams.ToList());
        }

        // GET: /Team/TeamsDetails
        public ActionResult TeamsDetails(int id = 0) {
            Teams teams = db.Teams.Find(id);

            if (teams == null) {
                return HttpNotFound();
            }
            if (teams != null) {
                ViewBag.Type = "team";
            }

            return View(teams);
        }

        // GET: /Team/TeamsCreate
        public ActionResult TeamsCreate() {
            return View();
        }

        // POST: /Team/TeamsCreate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeamsCreate(Teams teams) {
            if (ModelState.IsValid) {
                var u = db.UserProfiles.First(x=>x.UserName == User.Identity.Name);
                teams.SettingId = u.SettingId;
                db.Teams.Add(teams);
                db.SaveChanges();

                return RedirectToAction("Teams");
            }
            return View(teams);
        }

        // GET: /Team/TeamsEdit
        public ActionResult TeamsEdit(int id) {
            Teams teams = db.Teams.Find(id);
            teams.TeamCode = "";

            if (teams == null) {
                return HttpNotFound();
            }

            if (teams != null) {
                ViewBag.Type = "team";
            }

            return View(teams);
        }

        // POST: /Team/TeamsEdit/5
        [HttpPost]
        public ActionResult TeamsEdit(Teams teams) {
            if (ModelState.IsValid) {
                db.Entry(teams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Teams");
            }

            return View(teams);
        }

        // GET: /Team/Delete
        public ActionResult Delete(int id = 0) {
            Teams teams = db.Teams.Find(id);
            if (teams == null) {
                return HttpNotFound();
            }
            else {
                db.Teams.Remove(teams);
                db.SaveChanges();
                return RedirectToAction("Teams");
            }
            return View(teams);
        }

        // POST: /Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Teams teams = db.Teams.Find(id);
            db.Teams.Remove(teams);
            db.SaveChanges();
            return RedirectToAction("Teams");
        }
    }
}