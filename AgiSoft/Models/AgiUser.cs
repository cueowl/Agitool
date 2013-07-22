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
        private CueDb cue = new CueDb();
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
        public AgiUser() {

        }

        // Commands
        public string AddUser(string creator) {
            UserProfile up = new UserProfile();
            UserProfile c = db.UserProfiles.First(x => x.UserName == creator);
            Users cUser = cue.Users.First(x => x.UserName == creator);
            Users noob = cue.Users.First(x => x.UserName == userName);
            UsersWithClient uwc = new UsersWithClient();
            string result = "";

            up.UserName = userName;
            up.FName = uFname;
            up.LName = uLname;
            up.Email = uEmail;
            up.IsLocked = locked;
            up.IsActiveUser = false;
            up.SettingId = c.SettingId;
            up.ChangeDate = DateTime.Now;

            uwc.ClientId = cue.UsersWithClient.First(x => x.UserId == cUser.UserId).ClientId;
            uwc.UserId = noob.UserId;

            try {

                db.UserProfiles.Add(up);
                db.SaveChanges();

                cue.UsersWithClient.Add(uwc);
                cue.SaveChanges();

                result = "success";

            } catch (Exception e) {
                e.ToString();

                throw;
            }

            return result;
        }

        public void DeleteUser(UserProfile up) {
            Users u = cue.Users.First(f => f.UserName == up.UserName);
            Membership m = cue.Membership.Find(u.UserId);
            UserProfile t = db.UserProfiles.Find(up.UserId);
            try {
                
                cue.Membership.Remove(m);
                cue.Users.Remove(u);
                cue.SaveChanges();
                
                db.UserProfiles.Remove(t);
                db.SaveChanges();
            } catch (Exception e) {

                throw;
            }
        }

        // Queries

    }

}