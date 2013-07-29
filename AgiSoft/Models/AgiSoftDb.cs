/***********************************************************************************************
************************************************************************************************
* <author>Ralph Bohn & Harshad Deshmukh</author>                                               *
* <email>info@cueowl.com</email>                                                               *
* <date>2013-06-01</date>                                                                      *
* <file>AgiSoftDb.cs</file>                                                                    *
* <summary>not sure if really need this file as-is need change?</summary>                      *
************************************************************************************************      
************************************************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AgiSoft.Models {
    public class AgiSoftDb : DbContext {

        public AgiSoftDb()
            : base("name=AgiConnect") {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<CodeSet> CodeSet { get; set; }
        public DbSet<CodeSetType> CodeSetType { get; set; }
        public DbSet<Epics> Epics { get; set; }
        public DbSet<ESTinSprint> ESTinSprint { get; set; }
        public DbSet<FunctionReq> FunctionReq { get; set; }
        public DbSet<HoursBreakDown> HoursBreakDown { get; set; }
        public DbSet<MajorFeature> MajorFeature { get; set; }
        public DbSet<PassQuesAnswers> PassQuesAnswers { get; set; }
        public DbSet<PasswordHistory> PasswordHistory { get; set; }
        public DbSet<PasswordQuestions> PasswordQuestions { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<ProjRelInfo> ProjRelInfo { get; set; }
        public DbSet<ReleaseInfo> ReleaseInfo { get; set; }
        public DbSet<RFE> RFE { get; set; }
        public DbSet<RoleGroups> RoleGroups { get; set; }
        public DbSet<RolesInGroups> RolesInGroups { get; set; }
        public DbSet<Sprints> Sprints { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Stories> Stories { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<TeamOnProject> TeamOnProject { get; set; }
        public DbSet<TimeTrack> TimeTrack { get; set; }
        public DbSet<UserOnProject> UserOnProject { get; set; }
        public DbSet<UsersInRoles> UsersInRoles { get; set; }
        public DbSet<UsersOnTeam> UsersOnTeam { get; set; }
        public DbSet<webRoles> Roles { get; set; }
        public DbSet<webpages_Membership> Membership { get; set; }
        public DbSet<WorkGroupPercentage> WorkGroupPercentages { get; set; }

        public DbSet<ClientProdReg> ClientProdRegs { get; set; }

        public DbSet<Clients> Clients { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Registrations> Registrations { get; set; }
    }

    public class Epics {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EpicId { get; set; }

        [ForeignKey("Projects")]
        public int ProjectId { get; set; }

        [ForeignKey("Teams")]
        public int TeamId { get; set; }

        public string EpicDesc { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }

        [ForeignKey("RFE")]
        public int RFEId { get; set; }

        [ForeignKey("CodeSet")]
        public int Status { get; set; }

        public virtual Projects Projects { get; set; }
        public virtual Teams Teams { get; set; }
        public virtual RFE RFE { get; set; }
        public virtual CodeSet CodeSet { get; set; }
    }

    public class ESTinSprint {
        [Key, ForeignKey("Sprints")]
        [Column(Order = 1)]
        public int SprintId { get; set; }

        [Key, ForeignKey("Epics")]
        [Column(Order=2)]
        public int EpicId { get; set; }

        [Key, ForeignKey("Stories")]
        [Column(Order=3)]
        public int StoryId { get; set; }

        [Key, ForeignKey("Tasks")]
        [Column(Order=4)]
        public int TaskId { get; set; }

        public virtual Sprints Sprints { get; set; }
        public virtual Epics Epics { get; set; }
        public virtual Stories Stories { get; set; }
        public virtual Tasks Tasks { get; set; }
    }

    public class FunctionReq {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int FRId { get; set; }

        [ForeignKey("MajorFeature")]
        public int MFId { get; set; }

        public string FRNum { get; set; }
        public string FRDesc { get; set; }
        public double FREstimate { get; set; }

        public virtual MajorFeature MajorFeature { get; set; }
    }

    public class HoursBreakDown {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int HoursBreakDownId { get; set; }

        [ForeignKey("FunctionReq")]
        public int FRId { get; set; }

        public double EM { get; set; }
        public double Req { get; set; }
        public double Docs { get; set; }
        public double Design { get; set; }
        public double Dev { get; set; }
        public double UnitTest { get; set; }
        public double SIT { get; set; }
        public double UAT { get; set; }
        public double Peerreview { get; set; }
        public double TurnSupport { get; set; }
        public double ProjMgmt { get; set; }
        public double warranty { get; set; }

        [ForeignKey("CodeSet")]
        public int Status { get; set; }

        public virtual FunctionReq FunctionReq { get; set; }
        public virtual CodeSet CodeSet { get; set; }
    }

    public class MajorFeature {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MFId { get; set; }

        [ForeignKey("Projects")]
        public int ProjectId { get; set; }

        [ForeignKey("Teams")]
        public int TeamId { get; set; }

        public string MFNum { get; set; }
        public string MFDesc { get; set; }
        public double EffortHours { get; set; }

        public virtual Projects Projects { get; set; }
        public virtual Teams Teams { get; set; }
    }

    public class Projects {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        public string ProjectNum { get; set; }
        public string ProjectName { get; set; }

        [ForeignKey("UserProfile")]
        public int ManagerId { get; set; }

        [ForeignKey("CodeSet")]
        public int Status { get; set; }

        public double? TotalBudget { get; set; }

        [ForeignKey("Settings")]
        public int SettingId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual CodeSet CodeSet { get; set; }
        public virtual Settings Settings { get; set; }
    }

    public class ProjRelInfo {
        [Key, ForeignKey("ReleaseInfo")]
        [Column(Order=2)]
        public int ReleaseId { get; set; }

        [Key,ForeignKey("Projects")]
        [Column(Order=1)]
        public int ProjectId { get; set; }

        public virtual ReleaseInfo ReleaseInfo { get; set; }
        public virtual Projects Projects { get; set; }
    }

    public class ReleaseInfo {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ReleaseId { get; set; }

        public string RelMonth { get; set; }
        public int ReleaseYear { get; set; }
        public DateTime RequirementsDT { get; set; }
        public DateTime DesignDT { get; set; }
        public DateTime BuildCompleteDT { get; set; }
        public DateTime SITStartDT { get; set; }
        public DateTime SITEndDT { get; set; }
        public DateTime UATStartDT { get; set; }
        public DateTime UATEndDT { get; set; }
        public DateTime TurnDT { get; set; }
    }

    public class RFE {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RFEId { get; set; }

        [ForeignKey("MajorFeature")]
        public int MFId { get; set; }

        [ForeignKey("Projects")]
        public int ProjectId { get; set; }

        [ForeignKey("Teams")]
        public int TeamId { get; set; }

        public virtual MajorFeature MajorFeature { get; set; }
        public virtual Projects Projects { get; set; }
        public virtual Teams Teams { get; set; }
    }

    public class RoleGroups {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RoleGroupId { get; set; }

        public string GroupName { get; set; }
        public string Description { get; set; }
    }

    public class RolesInGroups {
        [Key,ForeignKey("Roles")]
        [Column(Order=2)]
        public int RoleId { get; set; }

        [Key,ForeignKey("RoleGroups")]
        [Column(Order=1)]
        public int RoleGroupId { get; set; }

        public virtual RoleGroups RoleGroups { get; set; }
        public virtual webRoles Roles { get; set; }
    }

    public class Settings {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SettingId { get; set; }
        public string RegistrationCD { get; set; }
    }

    public class Sprints {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SprintId { get; set; }
        public int SprintNum { get; set; }
        public DateTime StartDT { get; set; }

        [ForeignKey("Teams")]
        public int TeamId { get; set; }

        public virtual Teams Teams { get; set; }
    }

    public class Stories {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StoryId { get; set; }
        public int EpicId { get; set; }
        public string StoryDesc { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }
        public int Hours { get; set; }
        public int Status { get; set; }
    }

    public class Tasks {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        public int StoryId { get; set; }
        public string TaskDesc { get; set; }
        public string ConditionOfComplete { get; set; }
        public int EstHours { get; set; }
        public int ActualHours { get; set; }
        public int Rank { get; set; }
        public int Status { get; set; }
    }

    public class Teams {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        public string TeamCode { get; set; }
        public string TeamName { get; set; }
        public string TeamDesc { get; set; }
        public int SettingId { get; set; }
    }

    public class TeamOnProject {
        [Key,ForeignKey("Projects")]
        [Column(Order=1)]
        public int ProjectId { get; set; }

        [Key, ForeignKey("Teams")]
        [Column(Order=2)]
        public int TeamId { get; set; }

        public virtual Projects Projects { get; set; }
        public virtual Teams Teams { get; set; }
    }

    public class TimeTrack {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserProfile")]
        public int UserId { get; set; }
        [ForeignKey("Projects")]
        public int ProjectId { get; set; }

        public int Hours { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual Projects Projects { get; set; }
    }

    public class UserOnProject {
        [Key, ForeignKey("Projects")]
        [Column(Order = 1)]
        public int ProjectId { get; set; }

        [Key, ForeignKey("UserProfile")]
        [Column(Order = 2)]
        public int UserId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual Projects Projects { get; set; }
    }

    public class UsersInRoles {
        [Key, ForeignKey("UserProfile")]
        [Column(Order = 2)]
        public int UserId { get; set; }

        [Key, ForeignKey("Roles")]
        [Column(Order = 1)]
        public int RoleId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual webRoles Roles { get; set; }
    }

    public class UsersOnTeam {
        [Key, ForeignKey("UserProfile")]
        [Column(Order=2)]
        public int UserId { get; set; }

        [Key,ForeignKey("Teams")]
        [Column(Order=1)]
        public int TeamId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual Teams Teams { get; set; }
    }

    [Table("webpages_Roles")]
    public class webRoles {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public string RoleDesc { get; set; }
    }

    public class WorkGroupPercentage {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int WorkGroupId { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public double EM { get; set; }
        public double Req { get; set; }
        public double Docs { get; set; }
        public double Design { get; set; }
        public double Dev { get; set; }
        public double UnitTest { get; set; }
        public double SIT { get; set; }
        public double UAT { get; set; }
        public double Peerreview { get; set; }
        public double TurnSupport { get; set; }
        public double ProjMgmt { get; set; }
        public double Warranty { get; set; }

        public virtual Teams Team { get; set; }
        public virtual Projects Project { get; set; }
    }
}