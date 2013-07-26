using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgiSoft.Models;

namespace AgiSoft.Controllers {
    [Authorize]
    public class TimeTrackController : Controller {
        private AgiSoftDb db = new AgiSoftDb();

        //
        // GET: /TimeTrack/

        public ActionResult AddHours() {
            TimeTrack model = new TimeTrack();

            var userbind = (from p in db.UserProfiles
                            select p).ToList();

            List<UserProfile> username = new List<UserProfile>();

            foreach (var item1 in userbind) {
                UserProfile user = new UserProfile() { UserId = item1.UserId, UserName = item1.UserName };
                username.Add(user);
            }

            ViewBag.userid = new SelectList(username, "UserId", "UserName", model.UserId);

            var projectbind = from p in db.Projects
                              select p;

            List<Projects> projectname = new List<Projects>();

            foreach (var item1 in projectbind) {
                Projects project = new Projects() { ProjectId = item1.ProjectId, ProjectNum = item1.ProjectNum };
                projectname.Add(project);
            }

            ViewBag.projectid = new SelectList(projectname, "ProjectId", "ProjectNum", model.ProjectId);
            return View();
        }

        // POST: /Project/ProjectsCreate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHours(TimeTrack timetrack) {
            if (ModelState.IsValid) {
                db.TimeTrack.Add(timetrack);
                db.SaveChanges();

                return RedirectToAction("Projects");
            }
            return View(timetrack);
        }

    }
}