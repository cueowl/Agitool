using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgiSoft.Models;
using System.ComponentModel.DataAnnotations;

namespace AgiSoft.Models {

    public class AgiRegisterModel {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email: ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "First Name: ")]
        public string FName { get; set; }

        [Display(Name = "Last Name: ")]
        public string LName { get; set; }

        public bool IsLocked { get; set; }        
    }

    public class AgiUser {
        // Fields
        private AgiSoftDb db = new AgiSoftDb();
        private string userName = "";
        private string uEmail = "";
        private string uFname = "";
        private string uLname = "";
        private bool locked = false;

        // Constructor
        public AgiUser(AgiRegisterModel Model) {
            userName = Model.UserName;
            uEmail = Model.Email;
            uFname = Model.FName;
            uLname = Model.LName;
        }

        // Commands
        public bool AddUser() {
            UserProfile up = new UserProfile();
            up.UserName = userName;
            up.FName = uFname;
            up.LName = uLname;
            up.Email = uEmail;
            up.IsLocked = locked;
            up.IsActiveUser = false;
            up.SettingId = 1;
            up.ChangeDate = DateTime.Now;
            try {

                db.UserProfiles.Add(up);
                db.SaveChanges();

                return true;

            } catch (Exception e) {
                e.ToString();
                
                throw;
            }
        }

        // Queries

    }
}