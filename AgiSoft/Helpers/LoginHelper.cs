using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgiSoft.Models;
using WebMatrix.WebData;

namespace AgiSoft.Helpers {
    public class LoginHelper {
        // Fields
        private CueDb cue;

        // Constructor
        public LoginHelper() {
        }

        // Properties


        // Commands
        public void SetPasswordHistory(string username, string pass) {
            using (cue = new CueDb()) {
                int uid = WebSecurity.GetUserId(username);
                PasswordHistory ph = new PasswordHistory();
                ph.UserId = uid;
                ph.Password = pass;
                cue.PasswordHistories.Add(ph);
                cue.SaveChanges();
            }
        }

        public void NewPassword(string username, string pass) {
            using (cue = new CueDb()) {
                int uid = WebSecurity.GetUserId(username);
                PasswordHistory ph = new PasswordHistory();

                // check password history for repeats


                ph.UserId = uid;
                ph.Password = pass;
                cue.PasswordHistories.Add(ph);
                cue.SaveChanges();
            }
        }

        // Queries


    }
}