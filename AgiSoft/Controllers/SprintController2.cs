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

        public ActionResult FRAdd() {
            return View();
        }

        [HttpPost]
        public ActionResult FRAdd(FormCollection frm) {
            int count = 0;
            if (Session["FRAdd"] != null) {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["FRAdd"];
                count = dt.Rows.Count;
                dt.Rows.Add();
                dt.Rows[count][0] = frm["frnum"].ToString();
                dt.Rows[count][1] = frm["frdesc"].ToString();
                dt.Rows[count][2] = frm["em_mf"].ToString();
                Session["FRAdd"] = dt;
            }
            else {
                DataTable dt = new DataTable();
                dt.Columns.Add("FRNum");
                dt.Columns.Add("FRDesc");
                dt.Columns.Add("EM_MF");

                count = dt.Rows.Count;
                dt.Rows.Add();
                dt.Rows[count][0] = frm["frnum"].ToString();
                dt.Rows[count][1] = frm["frdesc"].ToString();
                dt.Rows[count][2] = frm["em_mf"].ToString();
                Session["FRAdd"] = dt;
            }
            return View();
        }

        public ActionResult RFE() {
            return View();
        }

        [HttpPost]
        public ActionResult RFE(FormCollection frm) {
            return View();
        }

        public ActionResult RFECreate() {

            return View();
        }

        public ActionResult ListofMajorFeatures() {
            var statusid = (from MajorFeature pt in db.MajorFeature
                            join Projects p in db.Projects on pt.ProjectId equals p.ProjectId into temp
                            from p in temp.DefaultIfEmpty()
                            join Teams p1 in db.Teams on pt.TeamId equals p1.TeamId into temp1
                            from p1 in temp1.DefaultIfEmpty()
                            select new { pt.MFId, p.ProjectNum, p.ProjectName, pt.MFNum, pt.MFDesc, p1.TeamName, pt.EffortHours }).ToList();

            Teams model = new Teams();
            model.majorfeature = new List<SprintMajorFeatures>();
            foreach (var item in statusid) {
                SprintMajorFeatures obj = new SprintMajorFeatures();
                obj.MFDesc = item.MFDesc;
                obj.MFId = item.MFId;
                obj.MFNum = item.MFNum;
                obj.MFTeamName = item.TeamName;
                obj.ProjectName = item.ProjectName;
                obj.ProjectNum = item.ProjectNum;
                obj.TotalEfforts = item.EffortHours;
                model.majorfeature.Add(obj);
            }

            return View(model);
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