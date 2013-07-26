/***********************************************************************************************
************************************************************************************************
* <author>Ralph Bohn & Harshad Deshmukh</author>                                               *
* <email>info@cueowl.com</email>                                                               *
* <date>2013-06-01</date>                                                                      *
* <file>SprintController.cs</file>                                                             *
* <summary>Contains the Controller methods for Sprint in MVC framework.                        *
*      Sprint functions like backlog, E-S-T tracking, planning, etc</summary>                  *
************************************************************************************************      
************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgiSoft.Models;

namespace AgiSoft.Controllers {
    [Authorize]
    public class SprintController : Controller {
        private AgiSoftDb db = new AgiSoftDb();

        // GET: /Sprint/
        public ActionResult Index() {
            return View();
        }

        // GET: /Sprint/Backlog/
        public ActionResult Backlog() {
            return View();
        }

        // GET: /Sprint/Epic/
        public ActionResult Epic() {
            return View();
        }

        // GET: /Sprint/Story/
        public ActionResult Story() {
            return View();
        }

        // GET: /Sprint/Task/
        public ActionResult Task() {
            return View();
        }

        // GET: /Sprint/Plan/
        public ActionResult Plan() {
            return View();
        }

        // GET: /Sprint/Reports/
        public ActionResult Reports() {
            return View();
        }

        public ActionResult MajorFeature() {
            MajorFeature model = new Models.MajorFeature();

            var teambind = from p in db.Teams
                           select p;

            List<Teams> teamname = new List<Teams>();

            foreach (var item1 in teambind) {
                Teams team = new Teams() { TeamId = item1.TeamId, TeamName = item1.TeamName };
                teamname.Add(team);
            }

            ViewBag.teamid = new SelectList(teamname, "TeamId", "TeamName", model.TeamId);

            var projectbind = from p in db.Projects
                              select p;

            List<Projects> projectname = new List<Projects>();

            foreach (var item1 in projectbind) {
                Projects project = new Projects() { ProjectId = item1.ProjectId, ProjectNum = item1.ProjectNum };
                projectname.Add(project);
            }

            ViewBag.projectid = new SelectList(projectname, "ProjectId", "ProjectNum", model.ProjectId);

            return View(model);
        }

        // GET: /Sprint/SprintCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MajorFeature(MajorFeature majorfeature) {
            if (ModelState.IsValid) {
                db.MajorFeature.Add(majorfeature);
                db.SaveChanges();

                var teambind = (from p in db.MajorFeature
                                select p.MFId).Max();

                RFE rfe = new RFE();
                rfe.MFId = teambind;
                rfe.ProjectId = majorfeature.ProjectId;
                rfe.TeamId = majorfeature.TeamId;
                db.RFE.Add(rfe);
                db.SaveChanges();

                return RedirectToAction("../Project/Projects");
            }
            return View(majorfeature);
        }

        // GET: /Sprint/SprintCreate
        public ActionResult SprintCreate() {
            Sprints model = new Models.Sprints();

            var teambind = from p in db.Teams
                           select p;

            List<Teams> teamname = new List<Teams>();

            foreach (var item1 in teambind) {
                Teams team = new Teams() { TeamId = item1.TeamId, TeamName = item1.TeamName };
                teamname.Add(team);
            }

            ViewBag.teamid = new SelectList(teamname, "TeamId", "TeamName", model.TeamId);

            return View(model);
        }

        // POST: /Admin/RolesCreate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SprintCreate(Sprints sprints) {
            if (ModelState.IsValid) {
                db.Sprints.Add(sprints);
                db.SaveChanges();

                return RedirectToAction("Sprints");
            }
            return View(sprints);
        }
    }
}