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
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjRelInfo> ProjRelInfo { get; set; }
        public DbSet<ReleaseInfo> ReleaseInfo { get; set; }
        public DbSet<RFE> RFE { get; set; }
        public DbSet<RoleGroups> RoleGroups { get; set; }
        public DbSet<RolesInGroups> RolesInGroups { get; set; }
        public DbSet<Sprints> Sprints { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Stories> Stories { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamOnProject> TeamOnProject { get; set; }
        public DbSet<TimeTrack> TimeTrack { get; set; }
        public DbSet<UserOnProject> UserOnProject { get; set; }
        public DbSet<UsersInRoles> UsersInRoles { get; set; }
        public DbSet<UsersOnTeam> UsersOnTeam { get; set; }
    }

    public class Epics {
        public int EpicId { get; set; }
        public int ProjectId { get; set; }
        public int TeamId { get; set; }
        public string EpicDesc { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }
        public int RFEId { get; set; }
        public int Status { get; set; }
    }

    public class ESTinSprint {
        public int SprintId { get; set; }
        public int EpicId { get; set; }
        public int StoryId { get; set; }
        public int TaskId { get; set; }
    }

    public class FunctionReq {
        public int FRId { get; set; }
        public int MFId { get; set; }
        public string FRNum { get; set; }
        public string FRDesc { get; set; }
        public double FREstimate { get; set; }
    }

    public class HoursBreakDown {
        public int HoursBreakDownId { get; set; }
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
        public int Status { get; set; }
    }

    public class MajorFeature {
        public int MFId { get; set; }
        public int ProjectId { get; set; }
        public int TeamId { get; set; }
        public string MFNum { get; set; }
        public string MFDesc { get; set; }
        public double EffortHours { get; set; }
    }

    public class Project {
        public int ProjectId { get; set; }
        public string ProjectNum { get; set; }
        public string ProjectName { get; set; }
        public int ManagerId { get; set; }
        public int Status { get; set; }
        public double TotalBudget { get; set; }
        public int SettingId { get; set; }
    }

    public class ProjRelInfo {
        public int ReleaseId { get; set; }
        public int ProjectId { get; set; }
    }

    public class ReleaseInfo {
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
        public int RFEId { get; set; }
        public int MFId { get; set; }
        public int ProjectId { get; set; }
        public int TeamId { get; set; }
    }

    public class RoleGroups {
        public int RoleGroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
    }

    public class RolesInGroups {
        public int RoleId { get; set; }
        public int RoleGroupId { get; set; }
    }

    public class Settings {
        public int SettingId { get; set; }
        public string RegistrationCD { get; set; }
    }

    public class Sprints {
        public int SprintId { get; set; }
        public int SprintNum { get; set; }
        public DateTime StartDT { get; set; }
        public int TeamId { get; set; }
    }

    public class Stories {
        public int StoryId { get; set; }
        public int EpicId { get; set; }
        public string StoryDesc { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }
        public int Hours { get; set; }
        public int Status { get; set; }
    }

    public class Tasks {
        public int TaskId { get; set; }
        public int StoryId { get; set; }
        public string TaskDesc { get; set; }
        public string ConditionOfComplete { get; set; }
        public int EstHours { get; set; }
        public int ActualHours { get; set; }
        public int Rank { get; set; }
        public int Status { get; set; }
    }

    public class Team {
        public int TeamId { get; set; }
        public string TeamCode { get; set; }
        public string TeamName { get; set; }
        public string TeamDesc { get; set; }
        public int SettingId { get; set; }
    }

    public class TeamOnProject {
        public int ProjectId { get; set; }
        public int TeamId { get; set; }
    }

    public class TimeTrack {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int Hours { get; set; }
    }

    public class UserOnProject {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }

    public class UsersInRoles {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }

    public class UsersOnTeam {
        public int UserId { get; set; }
        public int TeamId { get; set; }
    }
}