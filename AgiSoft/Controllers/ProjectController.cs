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

            List<Projects> rlist = null;

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
    }
}
