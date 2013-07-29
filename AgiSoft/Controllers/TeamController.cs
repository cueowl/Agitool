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
        private int uid = 0;
        private int usetting = 0;


        // GET: /Team/
        public ActionResult Index() {
            return View(db.Teams.ToList());
        }

        // GET: /Team/Member
        public ActionResult Member() {
            uid = WebSecurity.GetUserId(User.Identity.Name);

            Teams t = db.Teams.Find(uid);
            
            return View(db.UsersOnTeam.Where(x=>x.TeamId == t.TeamId).ToList());
        }

        // GET: /Team/MemberTeams
        public ActionResult MemberTeams(int id) {
            Teams t = db.Teams.Find(id);
            TeamViewModel tvm = new TeamViewModel(t);


            return View(tvm);
        }

        // GET: /Team/TeamProject/
        public ActionResult TeamProject() {
            
            return View();
        }

        // POST: /Team/TeamProject
        [HttpPost]
        public ActionResult TeamProject(int id, TeamOnProject model) {
            model.ProjectId = id;
            db.TeamOnProject.Add(model);
            db.SaveChanges();

            return View("Index");
            //return RedirectToAction("Project", "Projects");
        }

        // GET: /Team/Admin/
        public ActionResult Admin() {
            uid = WebSecurity.GetUserId(User.Identity.Name);
            usetting = db.UserProfiles.First(x => x.UserId == uid).SettingId;

            var proj = db.Projects.Where(x => x.Status == 3).Where(v=>v.SettingId == usetting);
            
            Projects prj = new Projects() { ProjectId = 0, ProjectNum = "0", ProjectName = "--Select--" };
            
            List<Projects> ProjList = new List<Projects>();
            ProjList.Add(prj);

            foreach (var pr in proj) {
                prj = new Projects() { ProjectId = pr.ProjectId, ProjectNum = pr.ProjectNum, ProjectName = pr.ProjectName };
                ProjList.Add(prj);
            }

            ViewBag.ProjectId = new SelectList(ProjList, "ProjectId", "ProjectName");

            var teamitem = from p in db.Teams
                           select p;

            TeamOnProject modelteam = new TeamOnProject();
            List<Teams> team = new List<Teams>();

            Teams team1 = new Teams() { TeamId = 0, TeamName = "--Select--" };
            team.Add(team1);
            foreach (var item1 in teamitem) {
                team1 = new Teams() { TeamId = item1.TeamId, TeamName = item1.TeamName };
                team.Add(team1);
            }

            ViewBag.teamId = new SelectList(team, "TeamId", "TeamName", modelteam.TeamId);

            return View();
        }

        // POST: /Team/Admin
        [HttpPost]
        public ActionResult Admin(TeamOnProject model) {
            TeamOnProject t = new TeamOnProject();
            t.ProjectId = model.ProjectId;
            t.TeamId = model.TeamId;
            db.TeamOnProject.Add(t);
            db.SaveChanges();

            return View("Index");
            //return RedirectToAction("Project", "Projects");
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