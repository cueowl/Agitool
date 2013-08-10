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
using System.Data;
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
            var context = new AgiSoftDb();
            Epics model = new Models.Epics();
            var rfe = context.Epics;

            List<Epics> objepic = new List<Epics>();

            foreach (var r in rfe) {
                model = new Models.Epics();
                model.Projects = new Projects();
                model.Teams = new Teams();

                Projects project = db.Projects.SingleOrDefault(a => a.ProjectId == r.ProjectId);
                Teams team = db.Teams.SingleOrDefault(a => a.TeamId == r.TeamId);

                model.EpicId = r.EpicId;
                model.Projects.ProjectNum = project.ProjectNum;
                model.Projects.ProjectName = project.ProjectName;
                model.Teams.TeamName = team.TeamName;
                model.EpicDesc = r.EpicDesc;
                model.Points = r.Points;
                model.Rank = r.Rank;
                objepic.Add(model);
            }
            return View(objepic);
        }

        // GET: /Sprint/EpicCreate/
        public ActionResult EpicCreate(int RFEId) {
            Epics model = new Epics();

            var codebind = from p in db.CodeSet
                           select p;

            List<CodeSet> codesetname = new List<CodeSet>();
            CodeSet code = new CodeSet() { CodeSetId = 0, CodeSetDesc = "--Select--" };
            codesetname.Add(code);
            foreach (var item1 in codebind) {
                code = new CodeSet() { CodeSetId = item1.CodeSetId, CodeSetDesc = item1.CodeSetDesc };
                codesetname.Add(code);
            }

            ViewBag.codesetid = new SelectList(codesetname, "CodeSetId", "CodeSetDesc", model.Status);

            return View();
        }

        // POST: /Sprint/EpicCreate/
        [HttpPost]
        public ActionResult EpicCreate(Epics model, int RFEId) {
            RFE project = db.RFE.SingleOrDefault(a => a.RFEId == RFEId);

            model.ProjectId = project.ProjectId;
            model.TeamId = project.TeamId;
            model.Status = 1;

            db.Epics.Add(model);
            db.SaveChanges();

            return View();
        }

        // GET: /Sprint/Story/
        public ActionResult Story() {
            var context = new AgiSoftDb();
            Stories model = new Models.Stories();
            var story = context.Stories;

            List<Stories> objstory = new List<Stories>();

            foreach (var r in story) {
                model = new Models.Stories();

                model.StoryId = r.StoryId;
                model.StoryDesc = r.StoryDesc;
                model.Hours = r.Hours;
                model.Points = r.Points;
                model.Rank = r.Rank;
                model.ProjectId = r.ProjectId;
                model.TeamId = r.TeamId;
                objstory.Add(model);
            }
            return View(objstory);
        }

        // GET: /Sprint/StoryCreate/
        public ActionResult StoryCreate(int EpicId) {
            Stories model = new Stories();
            var codebind = from p in db.CodeSet
                           select p;

            List<CodeSet> codesetname = new List<CodeSet>();
            CodeSet code = new CodeSet() { CodeSetId = 0, CodeSetDesc = "--Select--" };
            codesetname.Add(code);
            foreach (var item1 in codebind) {
                code = new CodeSet() { CodeSetId = item1.CodeSetId, CodeSetDesc = item1.CodeSetDesc };
                codesetname.Add(code);
            }

            ViewBag.codesetid = new SelectList(codesetname, "CodeSetId", "CodeSetDesc", model.Status);

            return View(model);
        }

        // POST: /Sprint/StoryCreate/
        [HttpPost]
        public ActionResult StoryCreate(Stories model, int EpicId) {
            model.EpicId = EpicId;
            db.Stories.Add(model);
            db.SaveChanges();

            var codebind = from p in db.CodeSet
                           select p;

            List<CodeSet> codesetname = new List<CodeSet>();
            CodeSet code = new CodeSet() { CodeSetId = 0, CodeSetDesc = "--Select--" };
            codesetname.Add(code);
            foreach (var item1 in codebind) {
                code = new CodeSet() { CodeSetId = item1.CodeSetId, CodeSetDesc = item1.CodeSetDesc };
                codesetname.Add(code);
            }

            ViewBag.codesetid = new SelectList(codesetname, "CodeSetId", "CodeSetDesc", model.Status);

            return View(model);
        }

        // GET: /Sprint/Task/
        public ActionResult Task() {
            return View();
        }

        // GET: /Sprint/TaskCreate/
        public ActionResult TaskCreate(int StoryId) {
            var context = new AgiSoftDb();
            Stories model = new Models.Stories();
            var story = context.Stories;

            List<Stories> objstory = new List<Stories>();

            foreach (var r in story) {
                Projects project = db.Projects.SingleOrDefault(a => a.ProjectId == r.ProjectId);
                Teams team = db.Teams.SingleOrDefault(a => a.TeamId == r.TeamId);

            }
            return View();
        }

        // POST: /Sprint/TaskCreate/
        [HttpPost]
        public ActionResult TaskCreate(Tasks model, int StoryId) {
            Stories story = db.Stories.SingleOrDefault(a => a.StoryId == StoryId);

            model.ProjectId = story.ProjectId;
            model.TeamId = story.TeamId;

            db.Tasks.Add(model);
            db.SaveChanges();

            return View();
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

        // GET: /Sprint/Plan/
        public ActionResult Plan() {
            return View();
        }

        // GET: /Sprint/Reports/
        public ActionResult Reports() {
            return View();
        }
    }
}