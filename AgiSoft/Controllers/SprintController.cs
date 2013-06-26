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

namespace AgiSoft.Controllers
{
    public class SprintController : Controller
    {
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
    }
}
