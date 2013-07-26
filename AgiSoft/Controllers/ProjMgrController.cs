/***********************************************************************************************
************************************************************************************************
* <author>Ralph Bohn & Harshad Deshmukh</author>                                               *
* <email>info@cueowl.com</email>                                                               *
* <date>2013-06-01</date>                                                                      *
* <file>ProjMgrController.cs</file>                                                            *
* <summary>Contains the Controller methods for Project Manager in MVC framework.               *
*      All the Project Manager Functionality 'controlled' thru here</summary>                  *
************************************************************************************************      
************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgiSoft.Controllers {
    [Authorize]
    public class ProjMgrController : Controller {
        //
        // GET: /ProjMgr/

        public ActionResult Index() {
            return View();
        }

    }
}