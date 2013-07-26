using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AgiSoft.Models {
    public class TeamViewModel {
        // Fields
        private AgiSoftDb db;

        // Constructor
        public TeamViewModel(Teams team) {
            Team = team;
            SetMemberList(Team.SettingId);
            TeamNm = Team.TeamName;
        }

        public TeamViewModel() {

        }

        // Properties
        [Required]
        [Display(Name="Team Name: ")]
        public string TeamNm { get; set; }

        [Required]
        [Display(Name="Member Name: ")]
        public string MemNm { get; set; }

        public Teams Team { get; set; }
        public List<UserProfile> Member { get; set; }

        // Commands
        public void AddMemberToTeam() {
            using (db = new AgiSoftDb()) {

                Teams t = db.Teams.First(x => x.TeamName == TeamNm);
                UserProfile member = db.UserProfiles.First(x => x.UserName == MemNm);
                UsersOnTeam uot = new UsersOnTeam();

                uot.TeamId = t.TeamId;
                uot.UserId = member.UserId;


                try {
                    db.UsersOnTeam.Add(uot);
                    db.SaveChanges();
                } catch (Exception e) {
                    e.ToString();
                    throw e;
                }
            }

        }

        private void SetMemberList(int id) {
            using (db = new AgiSoftDb()) {
                if (Member == null) {
                    Member = new List<UserProfile>();
                }
                Member = db.UserProfiles.Where(x => x.SettingId == id).ToList();
            }
        }

        // Queries
        public List<Teams> GetTeams(int settingId) {
            using (db=new AgiSoftDb()){
                return db.Teams.Where(x=>x.SettingId==settingId).ToList();
            }
        }
        public List<UserProfile> GetMembers(int settingId) {
            //TODO: modify this to only return members belonging to team level and child teams

            using (db = new AgiSoftDb()) {
                return db.UserProfiles.Where(x => x.SettingId == settingId).ToList();
            }
        }
    }
}