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
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgiSoft.Controllers
{
    public class TeamController : Controller
    {
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
    }
}
