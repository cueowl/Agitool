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
