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
        private int passIterations = 5;

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

        public string NewPassword(string username, string pass) {
            using (cue = new CueDb()) {
                int uid = WebSecurity.GetUserId(username);
                PasswordHistory ph = new PasswordHistory();

                // check password history for repeats (5 iterations)
                List<PasswordHistory> phList = cue.PasswordHistories.Where(x => x.UserId == uid).OrderByDescending(u => u.Date).Take(passIterations).ToList();
                int result = IsRepeatPassword(phList, pass);

                if (result == 0) {
                    try {
                        ph.UserId = uid;
                        ph.Password = pass;
                        cue.PasswordHistories.Add(ph);
                        cue.SaveChanges();

                        return "Success";
                    }
                    catch(Exception e){
                        e.ToString();

                        throw e;
                    }
                }
                else if (result == -1) {
                    return "Repeat";
                }
                else {
                    return "Error";
                }
            }
        }

        // Queries
        private int IsRepeatPassword(List<PasswordHistory> phList, string pass) {

            foreach (PasswordHistory p in phList) {
                if (p.Password == pass) {
                    return -1;
                }
            }

            return 0;
        }

    }
}