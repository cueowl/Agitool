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
        public int CurrentUserSettingId(string uname) {
            using (db = new AgiSoftDb()) {
                UserProfile up = db.UserProfiles.First(x => x.UserName == uname);
                return up.SettingId;
            }
        }

        public bool IsUserInRole() {
            using (db=new AgiSoftDb()) {
                UsersInRoles uir = db.UsersInRoles.Find(RolesID, UsersID);

                return (uir != null);
            }
        }

        public UsersInRoles GetUserInRole(string role) {
            return (UsersInRoles)db.UsersInRoles.Where(x => x.Roles.RoleCode == role);
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