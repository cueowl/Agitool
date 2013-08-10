using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgiSoft.Models;
using AgiSoft.Helpers;

namespace AgiSoft.Controllers {
    [Authorize]
    public class ProjectController : Controller {
        private AgiSoftDb db = new AgiSoftDb();
        //
        // GET: /Project/

        public ActionResult Index() {
            return View();
        }

        // GET: /Project/Projects
        public ActionResult Projects() {
            return View(db.Projects.ToList());
        }

        // GET: /Admin/RolesDetails
        public ActionResult ProjectsDetails(int id = 0) {
            Projects projects = db.Projects.Find(id);

            if (projects == null) {
                return HttpNotFound();
            }
            if (projects != null) {
                ViewBag.Type = "project";
            }

            return View(projects);
        }

        // GET: /Project/ProjectsCreate
        public ActionResult ProjectsCreate() {
            Projects model = new Models.Projects();
            RoleHelper rh = new RoleHelper();
            int settingId = rh.CurrentUserSettingId(User.Identity.Name);

            var mgrrol = from r in db.Roles
                         where r.RoleCode == "mngr" || r.RoleCode == "bizown" || r.RoleCode == "prodspons" || r.RoleCode == "projown"
                         select r;

            var item = (from p in db.UsersInRoles
                       join r in db.Roles on p.RoleId equals r.RoleId into temp
                       from r in temp.DefaultIfEmpty()
                       where r.RoleCode == "mngr" || r.RoleCode == "bizown" || r.RoleCode == "prodspons" || r.RoleCode == "projown"
                       select new { p.UserProfile}).ToList();

            // Get list of users that would have business owner or product sponsor or business sponsor roles
            //  **NOTE** query needs to tie to particular "SettingId"
            List<UserProfile> managers = new List<UserProfile>();
            foreach (var u in item) {
                if (u.UserProfile.SettingId == settingId) {
                    managers.Add(u.UserProfile);
                }
            }

            ViewBag.ManagerId = new SelectList(managers, "UserId", "UserName", model.ManagerId);

            var statusid = (from CodeSet pt in db.CodeSet
                            join CodeSetType p in db.CodeSetType on pt.CodeSetTypeId equals p.CodeSetTypeId into temp
                            from p in temp.DefaultIfEmpty()
                            where p.CodeSetTypeDesc == "ProjectType"
                            select new { pt.CodeSetDesc, pt.CodeSetId }).ToList();

            List<CodeSet> codeset = new List<CodeSet>();
            foreach (var item2 in statusid) {
                CodeSet codeset1 = new CodeSet() { CodeSetId = item2.CodeSetId, CodeSetDesc = item2.CodeSetDesc.ToString() };
                codeset.Add(codeset1);
            }

            ViewBag.Status = new SelectList(codeset, "CodeSetId", "CodeSetDesc", model.Status);
            ViewBag.ManagerId = new SelectList(managers, "UserId", "UserName", model.ManagerId);

            return View(model);
        }

        // POST: /Project/ProjectsCreate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectsCreate(Projects project) {
            if (ModelState.IsValid) {
                project.SettingId = 0;
                db.Projects.Add(project);
                db.SaveChanges();

                return RedirectToAction("Projects");
            }
            return View(project);
        }

        // GET: /Project/ProjectsEdit
        public ActionResult ProjectsEdit(int id) {
            Projects projects = db.Projects.Find(id);
            
            if (projects == null) {
                return HttpNotFound();
            }

            if (projects != null) {
                ViewBag.Type = "project";
            }

            return View(projects);
        }

        // POST: /Project/ProjectsEdit/5
        [HttpPost]
        public ActionResult ProjectsEdit(Projects projects) {
            if (ModelState.IsValid) {
                db.Entry(projects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Projects");
            }

            return View(projects);
        }

        // GET: /Admin/ProjectsDelete
        public ActionResult ProjectsDelete(int id = 0) {
            Projects projects = db.Projects.Find(id);
            if (projects == null) {
                return HttpNotFound();
            }

            return View(projects);
        }

        // POST: /Admin/ProjectsDelete
        [HttpPost, ActionName("ProjectsDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectsConfDelete(int id) {
            Projects projects = db.Projects.Find(id);
                db.Projects.Remove(projects);
                db.SaveChanges();
                return RedirectToAction("Projects");            
        }

        // GET: Projects/HoursBreakDown
        public ActionResult HoursBreakDown(int Id = 0) {
            WorkGroupPercentage model = new WorkGroupPercentage();

            WorkGroupPercentage percentageexist = (from e in db.WorkGroupPercentages
                                                   where e.ProjectId == Id
                                                   select e).First();

            if (percentageexist != null) {
                model.Design = percentageexist.Design;
                model.Dev = percentageexist.Dev;
                model.Docs = percentageexist.Docs;
                model.EM = percentageexist.EM;
                model.Peerreview = percentageexist.Peerreview;
                model.ProjMgmt = percentageexist.ProjMgmt;
                model.Req = percentageexist.Req;
                model.SIT = percentageexist.SIT;
                model.TurnSupport = percentageexist.TurnSupport;
                model.UAT = percentageexist.UAT;
                model.UnitTest = percentageexist.UnitTest;
                model.Warranty = percentageexist.Warranty;
                model.WorkGroupId = percentageexist.WorkGroupId;
            }
            model.ProjectId = Id;
            return View(model);
        }

        // POST: Projects/HoursBreakDown
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HoursBreakDown(WorkGroupPercentage percentage, int Id = 0) {
            percentage.ProjectId = Id;
            var teamid = (from pt in db.Projects
                          join TeamOnProject p in db.TeamOnProject on pt.ProjectId equals p.ProjectId into temp
                          from p in temp.DefaultIfEmpty()
                          where pt.ProjectId == Id
                          select new { p.TeamId }).First();

            percentage.TeamId = teamid.TeamId;
            db.WorkGroupPercentages.Add(percentage);
            db.SaveChanges();


            return RedirectToAction("Projects");
        }

        // GET: /Project/RFE
        public ActionResult RFE() {
            var context = new AgiSoftDb();
            RFE model = new Models.RFE();
            var rfe = context.RFE;

            List<RFE> objrfe = new List<RFE>();

            foreach (var r in rfe) {
                model = new Models.RFE();
                model.Projects = new Projects();
                model.Teams = new Teams();
                model.MajorFeature = new MajorFeature();

                var team = (from t in db.Teams
                            where t.TeamId == r.TeamId
                            select t).ToList();

                Projects project = db.Projects.SingleOrDefault(a => a.ProjectId == r.ProjectId);
                MajorFeature mf = db.MajorFeature.SingleOrDefault(a => a.MFId == r.MFId);

                var mfcount = db.MajorFeature.Count(a => a.MFId == r.MFId);

                model.RFEId = r.RFEId;
                model.Projects.ProjectNum = project.ProjectNum;
                model.Projects.ProjectName = project.ProjectName;
                model.Teams.TeamName = team[0].TeamName;
                model.MajorFeature.MFNum = mf.MFNum;
                model.MajorFeature.MFDesc = mf.MFDesc;
                model.MajorFeature.MFId = mfcount;
                objrfe.Add(model);
            }
            return View(objrfe);
        }

        // GET: /Project/RFECreate
        public ActionResult RFECreate() {
            RFE model = new Models.RFE();

            var teambind = from p in db.Teams
                           select p;

            List<Teams> teamname = new List<Teams>();
            Teams team = new Teams() { TeamId = 0, TeamName = "--Select--" };
            teamname.Add(team);
            foreach (var item1 in teambind) {
                team = new Teams() { TeamId = item1.TeamId, TeamName = item1.TeamName };
                teamname.Add(team);
            }

            ViewBag.teamid = new SelectList(teamname, "TeamId", "TeamName", model.TeamId);

            var projectbind = from p in db.Projects
                              select p;

            List<Projects> projectname = new List<Projects>();
            Projects project = new Projects() { ProjectId = 0, ProjectNum = "--Select--" };
            projectname.Add(project);
            foreach (var item1 in projectbind) {
                project = new Projects() { ProjectId = item1.ProjectId, ProjectNum = item1.ProjectNum };
                projectname.Add(project);
            }

            ViewBag.projectid = new SelectList(projectname, "ProjectId", "ProjectNum", model.ProjectId);

            return View(model);
        }

        // POST: /Project/RFECreate
        [HttpPost]
        public ActionResult RFECreate(FormCollection frm, RFE model) {
            string[] frnum = frm["FRNum"].Split(',');
            string[] frdesc = frm["FRDesc"].Split(',');
            string[] frestimate = frm["FREstimate"].Split(',');

            if (frnum.Length > 0) {
                model.MFId = 1;
                db.RFE.Add(model);
                db.SaveChanges();

                var item = (from e in db.RFE
                            select e.RFEId).Max();

                FunctionReq model1 = new FunctionReq();
                for (int i = 0; i < frnum.Length; i++) {
                    model1.RFEId = item;
                    model1.FRNum = frnum[i];
                    model1.FRDesc = frdesc[i];
                    model1.EM_MF = Convert.ToDouble(frestimate[i].ToString());
                    db.FunctionReq.Add(model1);
                    db.SaveChanges();

                    var itemfr = (from e in db.FunctionReq
                                  select e.FRId).Max();

                    double EM = (double)(model1.EM_MF * 3 / 100);
                    double Req = (double)(model1.EM_MF * 3 / 100);
                    double docs = (double)(model1.EM_MF * 2 / 100);
                    double design = (double)(model1.EM_MF * 4 / 100);
                    double dev = (double)(model1.EM_MF * 60 / 100);
                    double peerreview = (double)(model1.EM_MF * 3 / 100);
                    double sit = (double)(model1.EM_MF * 4 / 100);
                    double uat = (double)(model1.EM_MF * 3 / 100);
                    double unittest = (double)(model1.EM_MF * 3 / 100);
                    double warranty = (double)(model1.EM_MF * 2 / 100);

                    HoursBreakDown obj = new HoursBreakDown();
                    obj.FRId = itemfr;
                    obj.EM = EM;
                    obj.Req = Req;
                    obj.Docs = docs;
                    obj.Design = design;
                    obj.Dev = dev;
                    obj.Peerreview = peerreview;
                    obj.SIT = sit;
                    obj.UAT = uat;
                    obj.UnitTest = unittest;
                    obj.warranty = warranty;
                    obj.Status = 1;

                    db.HoursBreakDown.Add(obj);
                    db.SaveChanges();

                    //return View("RFE");
                }
            }
            return View("RFE");
        }

        // GET: /Project/FRDetail
        public ActionResult FRDetail(int RFEId) {
            var context = new AgiSoftDb();
            FunctionReq model = new Models.FunctionReq();

            var fr = (from e in db.FunctionReq
                      where e.RFEId == RFEId
                      select new { e.FRNum, e.FRDesc, e.EM_MF }).ToList();

            List<FunctionReq> objfr = new List<FunctionReq>();

            foreach (var r in fr) {
                model = new Models.FunctionReq();

                model.FRNum = r.FRNum;
                model.FRDesc = r.FRDesc;
                model.EM_MF = r.EM_MF;
                objfr.Add(model);
            }
            return View(objfr);
        }

        // GET: /Project/ListofMajorFeatures
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
                obj.TotalEfforts = item.EffortHours.ToString();
                model.majorfeature.Add(obj);
            }

            return View(model);
        }

        // GET: /Project/MajorFeature
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

        // POST: /Project/MajorFeature
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

                return RedirectToAction("Projects");
            }
            return View(majorfeature);
        }
    }
}
