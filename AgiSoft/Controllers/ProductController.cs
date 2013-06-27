/***********************************************************************************************
************************************************************************************************
* <author>Ralph Bohn & Harshad Deshmukh</author>                                               *
* <email>info@cueowl.com</email>                                                               *
* <date>2013-06-01</date>                                                                      *
* <file>ProductController.cs</file>                                                            *
* <summary>Contains the Controller methods for Product in MVC framework.                       *
*      Controls the product info for AgiSoft</summary>                                         *
************************************************************************************************      
************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgiSoft.Controllers {
    public class ProductController : Controller {
        
        // GET: /Product/
        public ActionResult Index() {
            return View();
        }

        // GET: /Product/Features/
        public ActionResult Features() {
            return View();
        }

        // GET: /Product/Pricing/
        public ActionResult Pricing() {
            return View();
        }

        // GET: /Product/Support/
        public ActionResult Support() {
            return View();
        }
    }
}