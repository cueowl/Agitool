using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgiSoft.Models;

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

            var item = from p in db.UserProfiles
                       select p;

            List<UserProfile> managers = new List<UserProfile>();
            foreach (var item1 in item) {
                UserProfile user = new UserProfile() { UserId = item1.UserId, UserName = item1.UserName };
                managers.Add(user);
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
    }
}
