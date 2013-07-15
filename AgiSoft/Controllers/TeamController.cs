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
using AgiSoft.Models;

namespace AgiSoft.Controllers
{
    public class TeamController : Controller
    {
        private AgiSoftDb db = new AgiSoftDb();

        // GET: /Team/
        public ActionResult Index() {
            return View();
        }

        // GET: /Team/Member
        public ActionResult Member() {
            return View();
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
        public ActionResult Teams()
        {
            return View(db.Teams.ToList());
        }

        // GET: /Admin/RolesDetails
        public ActionResult TeamsDetails(int id = 0)
        {
            Teams teams = db.Teams.Find(id);            

            if (teams == null)
            {
                return HttpNotFound();
            }
            if (teams != null)
            {
                ViewBag.Type = "team";                
            }

            return View(teams);
        }

        // GET: /Admin/RolesCreate
        public ActionResult TeamsCreate()
        {
            return View();
        }

        // POST: /Admin/RolesCreate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeamsCreate(Teams teams)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(teams);
                db.SaveChanges();

                return RedirectToAction("Teams");
            }
            return View(teams);
        }

        // GET: /Admin/RolesEdit
        public ActionResult TeamsEdit(int id)
        {            
            Teams teams = db.Teams.Find(id);
            teams.TeamCode = "";
            List<Teams> rlist = null;
            
            if (teams == null)
            {
                return HttpNotFound();
            }

            if (teams != null)
            {
                ViewBag.Type = "team";
            }

            return View(teams);
        }

        // POST: /Admin/RolesEdit/5
        [HttpPost]
        public ActionResult TeamsEdit(Teams teams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Teams");
            }

            return View(teams);
        }

        // GET: /Admin/RolesDelete
        public ActionResult Delete(int id = 0)
        {
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return HttpNotFound();
            }/*
            else
            {
                db.Team.Remove(teams);
                db.SaveChanges();
                return RedirectToAction("Teams");
            }*/
            return View(teams);
        }

        // POST: /Admin/RolesDelete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teams teams = db.Teams.Find(id);
            db.Teams.Remove(teams);
            db.SaveChanges();
            return RedirectToAction("Teams");
        }
    }
}
