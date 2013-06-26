/***********************************************************************************************
************************************************************************************************
* <author>Ralph Bohn & Harshad Deshmukh</author>                                               *
* <email>info@cueowl.com</email>                                                               *
* <date>2013-06-01</date>                                                                      *
* <file>ObstacleController.cs</file>                                                           *
* <summary>Contains the Controller methods for Obstacle in MVC framework.                      *
*      Obstacle is general term used to identify "Issues" and "Defects"</summary>              *
************************************************************************************************      
************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgiSoft.Controllers {
    public class ObstacleController : Controller {
        
        // GET: /Obstacle/
        public ActionResult Index() {
            return View();
        }

    }
}
