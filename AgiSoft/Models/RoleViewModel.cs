using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AgiSoft.Models {
    public class RoleViewModel {
        // Fields
        private AgiSoftDb db = new AgiSoftDb();
        private List<webRoles> wrlList = new List<webRoles>();

        // Constructor
        public RoleViewModel() { }

        // Properties
        //RoleGroup- Group Name
        [Display(Name = "Group name")]
        public string GroupName { get; set; }

        //RoleGroup - Group Description
        [Display(Name = "Group Description")]
        public string GrpDesc { get; set; }

        //Role - Role Name
        [Display(Name = "Role name")]
        public string RoleName { get; set; }

        //Role - Role Desc
        [Display(Name = "Role Description")]
        public string RoleDesc { get; set; }

        //RoleInGroup - Role List
        public List<webRoles> RoleList { get; set; }

        //RoleInGroup - Role List
        public webRoles WebRoles { get; set; }     


        // Commands
        public void AddGroup() {
            RoleGroups rg = new RoleGroups();
            rg.GroupName = GroupName;
            rg.Description = GrpDesc;

            try {
                db.RoleGroups.Add(rg);
                db.SaveChanges();
            }
            catch (Exception) {

                throw;
            }
        }

        public void AddRole() {
            webRoles rl = new webRoles();
            rl.RoleName = RoleName;
            rl.RoleDesc = RoleDesc;

            try {
                db.Roles.Add(rl);
                db.SaveChanges();
            }
            catch (Exception e) {
                e.ToString();
                throw;
            }
        }

        public void AddRoleToGroup(RoleGroups rg) {
            
            foreach (var role in RoleList) {
                RolesInGroups rig = new RolesInGroups();
                rig.RoleGroupId = rg.RoleGroupId;
                rig.RoleId = role.RoleId;
                try {
                    db.RolesInGroups.Add(rig);
                    db.SaveChanges();
                }
                catch (Exception e) {
                    e.ToString();

                    throw;
                }
            }
        }

        public void EditGroup() {
            RoleGroups rg = new RoleGroups();


            try {
                db.Entry(rg).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e) {
                e.ToString();
                throw;
            }
        }

        public void EditRole(webRoles rl) {
            try {
                db.Entry(rl).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e) {
                e.ToString();
                throw;
            }
        }

        public void DeleteGroup(RoleGroups rg) {
            RoleGroups r = db.RoleGroups.Find(rg.RoleGroupId);
            try {
                db.RoleGroups.Remove(r);
                db.SaveChanges();
            }
            catch (Exception e) {
                e.ToString();
                throw;
            }
        }

        public void DeleteRole(webRoles rl) {
            webRoles r = db.Roles.Find(rl.RoleId);
            try {
                db.Roles.Remove(r);
                db.SaveChanges();
            }
            catch (Exception e) {
                e.ToString();
                throw;
            }
        }

        public void DeleteRoleFromGroup(RoleGroups rg, List<webRoles> rl) {
            foreach (var role in rl) {
                RolesInGroups rig = db.RolesInGroups.Find(rg.RoleGroupId, role.RoleId);
                try {
                    db.RolesInGroups.Remove(rig);
                    db.SaveChanges();
                }
                catch (Exception e) {
                    e.ToString();
                    throw;
                }
            }
        }
    }
}