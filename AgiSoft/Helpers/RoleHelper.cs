using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgiSoft.Models;


namespace AgiSoft.Helpers {
    public class RoleHelper {
        // Fields
        private AgiSoftDb db;

        // Constructor
        public RoleHelper() {
        }

        // Properties
        public int UsersID { get; set; }
        public int RolesID { get; set; }


        // Commands


        // Queries
        public bool IsUserInRole() {
            using (db=new AgiSoftDb()) {
                UsersInRoles uir = db.UsersInRoles.Find(RolesID, UsersID);

                return (uir != null);
            }
        }

        public bool UserHasPermission() {
            // TODO: implement the permissions table(s)

            return false;
        }

    }

    // class to utilize for checking role permissions - & define Attribute
    public class RoleCheckFilter : ActionFilterAttribute, IActionFilter {
        // Fields

        
        // Constructor


        // Properties


        // Implements
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext) {
            
            this.OnActionExecuting(filterContext);
        }

        // Commands


        // Queries

    }
}