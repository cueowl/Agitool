USE [master]
GO
/****** Object:  Database [tAgi]    Script Date: 07/10/2013 13:34:31 ******/
CREATE DATABASE [tAgi] ON  PRIMARY 
( NAME = N'tAgi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\tAgi.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'tAgi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\tAgi_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [tAgi] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tAgi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tAgi] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [tAgi] SET ANSI_NULLS OFF
GO
ALTER DATABASE [tAgi] SET ANSI_PADDING OFF
GO
ALTER DATABASE [tAgi] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [tAgi] SET ARITHABORT OFF
GO
ALTER DATABASE [tAgi] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [tAgi] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [tAgi] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [tAgi] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [tAgi] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [tAgi] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [tAgi] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [tAgi] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [tAgi] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [tAgi] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [tAgi] SET  DISABLE_BROKER
GO
ALTER DATABASE [tAgi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [tAgi] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [tAgi] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [tAgi] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [tAgi] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [tAgi] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [tAgi] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [tAgi] SET  READ_WRITE
GO
ALTER DATABASE [tAgi] SET RECOVERY FULL
GO
ALTER DATABASE [tAgi] SET  MULTI_USER
GO
ALTER DATABASE [tAgi] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [tAgi] SET DB_CHAINING OFF
GO
USE [tAgi]
GO
/****** Object:  Table [dbo].[RoleGroups]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleGroups](
	[RoleGroupId] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](50) NOT NULL,
	[Description] [varchar](150) NULL,
 CONSTRAINT [PK_RoleGroups] PRIMARY KEY CLUSTERED 
(
	[RoleGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PasswordQuestions]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PasswordQuestions](
	[PassQuestionId] [int] IDENTITY(1,1) NOT NULL,
	[PassQuestion] [varchar](90) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PK_PasswordQuestions] PRIMARY KEY CLUSTERED 
(
	[PassQuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[RoleCode] [varchar](20) NULL,
	[RoleDesc] [varchar](max) NULL,
	[SettingId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReleaseInfo]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReleaseInfo](
	[ReleaseId] [int] IDENTITY(1,1) NOT NULL,
	[RelMonth] [varchar](50) NULL,
	[ReleaseYear] [nchar](10) NULL,
	[RequirementsDT] [datetime] NULL,
	[DesignDT] [datetime] NULL,
	[BuildCompleteDT] [datetime] NULL,
	[SITStartDT] [datetime] NULL,
	[SITEndDT] [datetime] NULL,
	[UATStartDT] [datetime] NULL,
	[UATEndDT] [datetime] NULL,
	[TurnDT] [datetime] NULL,
 CONSTRAINT [PK_ReleaseInfo] PRIMARY KEY CLUSTERED 
(
	[ReleaseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[SettingId] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationCD] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_OrgReg] PRIMARY KEY CLUSTERED 
(
	[SettingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Team](
	[TeamId] [int] IDENTITY(1,1) NOT NULL,
	[TeamCode] [varchar](20) NULL,
	[TeamName] [varchar](50) NULL,
	[TeamDesc] [varchar](max) NULL,
	[SettingId] [int] NOT NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RolesInGroups]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesInGroups](
	[RoleGroupId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_RolesInGroups] PRIMARY KEY CLUSTERED 
(
	[RoleGroupId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[FName] [varchar](50) NULL,
	[LName] [varchar](50) NULL,
	[IsLocked] [bit] NOT NULL,
	[IsActiveUser] [bit] NOT NULL,
	[SettingId] [int] NOT NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PK__UserProf__1788CC4C7F60ED59] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
	[Mobile] [varchar](20) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[DateBirth] [date] NULL,
	[JoinDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsersOnTeam]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersOnTeam](
	[UserId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_UsersOnTeam] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[TeamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sprints]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sprints](
	[SprintId] [int] NOT NULL,
	[SprintNum] [int] NOT NULL,
	[StartDT] [date] NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_Sprints] PRIMARY KEY CLUSTERED 
(
	[SprintId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordHistory]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PasswordHistory](
	[PasswdHistId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_PasswordHistory] PRIMARY KEY CLUSTERED 
(
	[PasswdHistId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PassQuesAnswers]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PassQuesAnswers](
	[PassAnswerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PassQuesId] [int] NOT NULL,
	[Answer] [varchar](50) NOT NULL,
	[IsValid] [bit] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PK_PassQuesAnswers] PRIMARY KEY CLUSTERED 
(
	[PassAnswerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CodeSetType]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CodeSetType](
	[CodeSetTypeId] [int] IDENTITY(1,1) NOT NULL,
	[CodeSetTypeCode] [varchar](50) NOT NULL,
	[CodeSetTypeDesc] [varchar](250) NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CodeSetType] PRIMARY KEY CLUSTERED 
(
	[CodeSetTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CodeSet]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CodeSet](
	[CodeSetId] [int] IDENTITY(1,1) NOT NULL,
	[CodeSetCode] [varchar](50) NOT NULL,
	[CodeSetDesc] [varchar](250) NOT NULL,
	[CodeSetTypeId] [int] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CodeSet] PRIMARY KEY CLUSTERED 
(
	[CodeSetId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Project]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectNum] [varchar](20) NULL,
	[ProjectName] [varbinary](100) NULL,
	[ManagerId] [int] NULL,
	[Status] [int] NOT NULL,
	[TotalBudget] [numeric](18, 4) NULL,
	[SettingId] [int] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjRelInfo]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjRelInfo](
	[ReleaseId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_ProjRelInfo] PRIMARY KEY CLUSTERED 
(
	[ReleaseId] ASC,
	[ProjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOnProject]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOnProject](
	[ProjectId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserOnProject] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeTrack]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTrack](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Hours] [int] NOT NULL,
 CONSTRAINT [PK_TimeTrack] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamOnProject]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamOnProject](
	[ProjectId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_TeamOnProject] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC,
	[TeamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MajorFeature]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MajorFeature](
	[MFId] [int] IDENTITY(1,1) NOT NULL,
	[Projectid] [int] NULL,
	[TeamId] [int] NULL,
	[MFNum] [varchar](20) NULL,
	[MFDesc] [varchar](max) NULL,
	[EffortHours] [varchar](10) NULL,
 CONSTRAINT [PK_MajorFeature] PRIMARY KEY CLUSTERED 
(
	[MFId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RFE]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RFE](
	[RFEId] [int] IDENTITY(1,1) NOT NULL,
	[MFId] [int] NULL,
	[ProjectId] [int] NULL,
	[TeamId] [int] NULL,
 CONSTRAINT [PK_RFE] PRIMARY KEY CLUSTERED 
(
	[RFEId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FunctionReq]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FunctionReq](
	[FRId] [int] IDENTITY(1,1) NOT NULL,
	[MFId] [int] NOT NULL,
	[FRNum] [varchar](20) NULL,
	[FRDesc] [varchar](max) NULL,
	[FREstimate] [numeric](5, 2) NULL,
 CONSTRAINT [PK_FunctionReq] PRIMARY KEY CLUSTERED 
(
	[FRId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HoursBreakDown]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoursBreakDown](
	[HoursBreakDownId] [int] IDENTITY(1,1) NOT NULL,
	[FRId] [int] NULL,
	[EM] [decimal](18, 2) NULL,
	[Req] [decimal](18, 2) NULL,
	[Docs] [numeric](18, 2) NULL,
	[Design] [numeric](18, 2) NULL,
	[Dev] [numeric](18, 2) NULL,
	[UnitTest] [numeric](18, 2) NULL,
	[SIT] [numeric](18, 2) NULL,
	[UAT] [numeric](18, 2) NULL,
	[Peerreview] [numeric](18, 2) NULL,
	[TurnSupport] [numeric](18, 2) NULL,
	[ProjMgmt] [numeric](18, 2) NULL,
	[Warranty] [numeric](18, 2) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_HoursBreakDown] PRIMARY KEY CLUSTERED 
(
	[HoursBreakDownId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Epics]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Epics](
	[EpicId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[EpicDesc] [varchar](max) NOT NULL,
	[Points] [int] NULL,
	[Rank] [int] NULL,
	[RFEId] [int] NOT NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Epics] PRIMARY KEY CLUSTERED 
(
	[EpicId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Stories]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stories](
	[StoryId] [int] IDENTITY(1,1) NOT NULL,
	[EpicId] [int] NOT NULL,
	[StoryDesc] [varchar](max) NULL,
	[Points] [int] NULL,
	[Rank] [int] NULL,
	[Hours] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Stories] PRIMARY KEY CLUSTERED 
(
	[StoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tasks](
	[Taskid] [int] IDENTITY(1,1) NOT NULL,
	[StoryId] [int] NULL,
	[TaskDesc] [varchar](max) NULL,
	[ConditionOfComplete] [varchar](max) NULL,
	[EstHours] [int] NULL,
	[ActualHours] [int] NULL,
	[Rank] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Taskid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ESTinSprint]    Script Date: 07/10/2013 13:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTinSprint](
	[EpicId] [int] NOT NULL,
	[StoryId] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
	[SprintId] [int] NOT NULL,
 CONSTRAINT [PK_ESTinSprint] PRIMARY KEY CLUSTERED 
(
	[EpicId] ASC,
	[StoryId] ASC,
	[TaskId] ASC,
	[SprintId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_PasswordQuestions_IsActive]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[PasswordQuestions] ADD  CONSTRAINT [DF_PasswordQuestions_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_PasswordQuestions_EntryDate]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[PasswordQuestions] ADD  CONSTRAINT [DF_PasswordQuestions_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
/****** Object:  Default [DF_webpages_Roles_OrgId]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[webpages_Roles] ADD  CONSTRAINT [DF_webpages_Roles_OrgId]  DEFAULT ((0)) FOR [SettingId]
GO
/****** Object:  Default [DF_Team_OrgId]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Team] ADD  CONSTRAINT [DF_Team_OrgId]  DEFAULT ((0)) FOR [SettingId]
GO
/****** Object:  Default [DF_UserProfile_IsLocked]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_User_IsActiveUser]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_User_IsActiveUser]  DEFAULT ((1)) FOR [IsActiveUser]
GO
/****** Object:  Default [DF_User_RegistrationCD]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_User_RegistrationCD]  DEFAULT ((0)) FOR [SettingId]
GO
/****** Object:  Default [DF__webpages___IsCon__29572725]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
/****** Object:  Default [DF__webpages___Passw__2A4B4B5E]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
/****** Object:  Default [DF_webpages_Membership_JoinDate]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  CONSTRAINT [DF_webpages_Membership_JoinDate]  DEFAULT (getdate()) FOR [JoinDate]
GO
/****** Object:  Default [DF_Sprints_SprintNum]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Sprints] ADD  CONSTRAINT [DF_Sprints_SprintNum]  DEFAULT ((1)) FOR [SprintNum]
GO
/****** Object:  Default [DF_Sprints_TeamId]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Sprints] ADD  CONSTRAINT [DF_Sprints_TeamId]  DEFAULT ((0)) FOR [TeamId]
GO
/****** Object:  Default [DF_PasswordHistory_Date]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[PasswordHistory] ADD  CONSTRAINT [DF_PasswordHistory_Date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_PassQuesAnswers_IsValid]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[PassQuesAnswers] ADD  CONSTRAINT [DF_PassQuesAnswers_IsValid]  DEFAULT ((1)) FOR [IsValid]
GO
/****** Object:  Default [DF_PassQuesAnswers_EntryDate]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[PassQuesAnswers] ADD  CONSTRAINT [DF_PassQuesAnswers_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
/****** Object:  Default [DF_CodeSetType_ModifiedDate]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[CodeSetType] ADD  CONSTRAINT [DF_CodeSetType_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
/****** Object:  Default [DF_CodeSet_ModifiedDate]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[CodeSet] ADD  CONSTRAINT [DF_CodeSet_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
/****** Object:  Default [DF_Project_Status]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [DF_Project_Status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  Default [DF_Project_OrgId]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [DF_Project_OrgId]  DEFAULT ((0)) FOR [SettingId]
GO
/****** Object:  Default [DF_HoursBreakDown_Status]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[HoursBreakDown] ADD  CONSTRAINT [DF_HoursBreakDown_Status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  Default [DF_Epics_TeamId]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Epics] ADD  CONSTRAINT [DF_Epics_TeamId]  DEFAULT ((0)) FOR [TeamId]
GO
/****** Object:  ForeignKey [FK_Team_Settings]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_Settings] FOREIGN KEY([SettingId])
REFERENCES [dbo].[Settings] ([SettingId])
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_Settings]
GO
/****** Object:  ForeignKey [FK_RolesInGroups_RoleGroups]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[RolesInGroups]  WITH CHECK ADD  CONSTRAINT [FK_RolesInGroups_RoleGroups] FOREIGN KEY([RoleGroupId])
REFERENCES [dbo].[RoleGroups] ([RoleGroupId])
GO
ALTER TABLE [dbo].[RolesInGroups] CHECK CONSTRAINT [FK_RolesInGroups_RoleGroups]
GO
/****** Object:  ForeignKey [FK_RolesInGroups_Roles]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[RolesInGroups]  WITH CHECK ADD  CONSTRAINT [FK_RolesInGroups_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[RolesInGroups] CHECK CONSTRAINT [FK_RolesInGroups_Roles]
GO
/****** Object:  ForeignKey [FK_OrgReg]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_OrgReg] FOREIGN KEY([SettingId])
REFERENCES [dbo].[Settings] ([SettingId])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_OrgReg]
GO
/****** Object:  ForeignKey [FK_webpages_OAuthMembership_UserProfile]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[webpages_OAuthMembership]  WITH CHECK ADD  CONSTRAINT [FK_webpages_OAuthMembership_UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_OAuthMembership] CHECK CONSTRAINT [FK_webpages_OAuthMembership_UserProfile]
GO
/****** Object:  ForeignKey [FK_webpages_Membership_UserProfile]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[webpages_Membership]  WITH CHECK ADD  CONSTRAINT [FK_webpages_Membership_UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_Membership] CHECK CONSTRAINT [FK_webpages_Membership_UserProfile]
GO
/****** Object:  ForeignKey [FK_Team]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[UsersOnTeam]  WITH CHECK ADD  CONSTRAINT [FK_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO
ALTER TABLE [dbo].[UsersOnTeam] CHECK CONSTRAINT [FK_Team]
GO
/****** Object:  ForeignKey [FK_User]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[UsersOnTeam]  WITH CHECK ADD  CONSTRAINT [FK_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[UsersOnTeam] CHECK CONSTRAINT [FK_User]
GO
/****** Object:  ForeignKey [fk_RoleId]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
/****** Object:  ForeignKey [fk_UserId]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
/****** Object:  ForeignKey [FK_Sprints_Team]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Sprints]  WITH CHECK ADD  CONSTRAINT [FK_Sprints_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO
ALTER TABLE [dbo].[Sprints] CHECK CONSTRAINT [FK_Sprints_Team]
GO
/****** Object:  ForeignKey [FK_PasswordHistory_UserProfile]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[PasswordHistory]  WITH CHECK ADD  CONSTRAINT [FK_PasswordHistory_UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[PasswordHistory] CHECK CONSTRAINT [FK_PasswordHistory_UserProfile]
GO
/****** Object:  ForeignKey [FK_PassQuesAnswers_PasswordQuestions]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[PassQuesAnswers]  WITH CHECK ADD  CONSTRAINT [FK_PassQuesAnswers_PasswordQuestions] FOREIGN KEY([PassQuesId])
REFERENCES [dbo].[PasswordQuestions] ([PassQuestionId])
GO
ALTER TABLE [dbo].[PassQuesAnswers] CHECK CONSTRAINT [FK_PassQuesAnswers_PasswordQuestions]
GO
/****** Object:  ForeignKey [FK_PassQuesAnswers_UserProfile]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[PassQuesAnswers]  WITH CHECK ADD  CONSTRAINT [FK_PassQuesAnswers_UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[PassQuesAnswers] CHECK CONSTRAINT [FK_PassQuesAnswers_UserProfile]
GO
/****** Object:  ForeignKey [FK_UserModified]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[CodeSetType]  WITH CHECK ADD  CONSTRAINT [FK_UserModified] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[CodeSetType] CHECK CONSTRAINT [FK_UserModified]
GO
/****** Object:  ForeignKey [FK_CodeSet_Modified]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[CodeSet]  WITH CHECK ADD  CONSTRAINT [FK_CodeSet_Modified] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[CodeSet] CHECK CONSTRAINT [FK_CodeSet_Modified]
GO
/****** Object:  ForeignKey [FK_CodeSetType]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[CodeSet]  WITH CHECK ADD  CONSTRAINT [FK_CodeSetType] FOREIGN KEY([CodeSetTypeId])
REFERENCES [dbo].[CodeSetType] ([CodeSetTypeId])
GO
ALTER TABLE [dbo].[CodeSet] CHECK CONSTRAINT [FK_CodeSetType]
GO
/****** Object:  ForeignKey [FK_Project_Manager]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Manager] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Manager]
GO
/****** Object:  ForeignKey [FK_Project_Settings]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Settings] FOREIGN KEY([SettingId])
REFERENCES [dbo].[Settings] ([SettingId])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Settings]
GO
/****** Object:  ForeignKey [FK_Project_Status]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Status] FOREIGN KEY([Status])
REFERENCES [dbo].[CodeSet] ([CodeSetId])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Status]
GO
/****** Object:  ForeignKey [FK_ProjRelInfo_Proj]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[ProjRelInfo]  WITH CHECK ADD  CONSTRAINT [FK_ProjRelInfo_Proj] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[ProjRelInfo] CHECK CONSTRAINT [FK_ProjRelInfo_Proj]
GO
/****** Object:  ForeignKey [FK_ProjRelInfo_ReleaseInfo]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[ProjRelInfo]  WITH CHECK ADD  CONSTRAINT [FK_ProjRelInfo_ReleaseInfo] FOREIGN KEY([ReleaseId])
REFERENCES [dbo].[ReleaseInfo] ([ReleaseId])
GO
ALTER TABLE [dbo].[ProjRelInfo] CHECK CONSTRAINT [FK_ProjRelInfo_ReleaseInfo]
GO
/****** Object:  ForeignKey [FK_ProjectToUser]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[UserOnProject]  WITH CHECK ADD  CONSTRAINT [FK_ProjectToUser] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[UserOnProject] CHECK CONSTRAINT [FK_ProjectToUser]
GO
/****** Object:  ForeignKey [FK_UserOnProject]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[UserOnProject]  WITH CHECK ADD  CONSTRAINT [FK_UserOnProject] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[UserOnProject] CHECK CONSTRAINT [FK_UserOnProject]
GO
/****** Object:  ForeignKey [FK_TimeTrack_Project]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[TimeTrack]  WITH CHECK ADD  CONSTRAINT [FK_TimeTrack_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[TimeTrack] CHECK CONSTRAINT [FK_TimeTrack_Project]
GO
/****** Object:  ForeignKey [FK_TimeTrack_User]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[TimeTrack]  WITH CHECK ADD  CONSTRAINT [FK_TimeTrack_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[TimeTrack] CHECK CONSTRAINT [FK_TimeTrack_User]
GO
/****** Object:  ForeignKey [FK_TeamOnProject_Project]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[TeamOnProject]  WITH CHECK ADD  CONSTRAINT [FK_TeamOnProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[TeamOnProject] CHECK CONSTRAINT [FK_TeamOnProject_Project]
GO
/****** Object:  ForeignKey [FK_TeamOnProject_Team]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[TeamOnProject]  WITH CHECK ADD  CONSTRAINT [FK_TeamOnProject_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO
ALTER TABLE [dbo].[TeamOnProject] CHECK CONSTRAINT [FK_TeamOnProject_Team]
GO
/****** Object:  ForeignKey [FK_MajorFeature_Project]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[MajorFeature]  WITH CHECK ADD  CONSTRAINT [FK_MajorFeature_Project] FOREIGN KEY([Projectid])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[MajorFeature] CHECK CONSTRAINT [FK_MajorFeature_Project]
GO
/****** Object:  ForeignKey [FK_MajorFeature_Team]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[MajorFeature]  WITH CHECK ADD  CONSTRAINT [FK_MajorFeature_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO
ALTER TABLE [dbo].[MajorFeature] CHECK CONSTRAINT [FK_MajorFeature_Team]
GO
/****** Object:  ForeignKey [FK_RFE_MF]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[RFE]  WITH CHECK ADD  CONSTRAINT [FK_RFE_MF] FOREIGN KEY([MFId])
REFERENCES [dbo].[MajorFeature] ([MFId])
GO
ALTER TABLE [dbo].[RFE] CHECK CONSTRAINT [FK_RFE_MF]
GO
/****** Object:  ForeignKey [FK_RFE_Proj]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[RFE]  WITH CHECK ADD  CONSTRAINT [FK_RFE_Proj] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[RFE] CHECK CONSTRAINT [FK_RFE_Proj]
GO
/****** Object:  ForeignKey [FK_RFE_Team]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[RFE]  WITH CHECK ADD  CONSTRAINT [FK_RFE_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO
ALTER TABLE [dbo].[RFE] CHECK CONSTRAINT [FK_RFE_Team]
GO
/****** Object:  ForeignKey [FK_FR_MF]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[FunctionReq]  WITH CHECK ADD  CONSTRAINT [FK_FR_MF] FOREIGN KEY([MFId])
REFERENCES [dbo].[MajorFeature] ([MFId])
GO
ALTER TABLE [dbo].[FunctionReq] CHECK CONSTRAINT [FK_FR_MF]
GO
/****** Object:  ForeignKey [FK_HoursBreakDown_FR]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[HoursBreakDown]  WITH CHECK ADD  CONSTRAINT [FK_HoursBreakDown_FR] FOREIGN KEY([FRId])
REFERENCES [dbo].[FunctionReq] ([FRId])
GO
ALTER TABLE [dbo].[HoursBreakDown] CHECK CONSTRAINT [FK_HoursBreakDown_FR]
GO
/****** Object:  ForeignKey [FK_HoursBreakDown_Status]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[HoursBreakDown]  WITH CHECK ADD  CONSTRAINT [FK_HoursBreakDown_Status] FOREIGN KEY([Status])
REFERENCES [dbo].[CodeSet] ([CodeSetId])
GO
ALTER TABLE [dbo].[HoursBreakDown] CHECK CONSTRAINT [FK_HoursBreakDown_Status]
GO
/****** Object:  ForeignKey [FK_Epics_CodeSet]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Epics]  WITH CHECK ADD  CONSTRAINT [FK_Epics_CodeSet] FOREIGN KEY([Status])
REFERENCES [dbo].[CodeSet] ([CodeSetId])
GO
ALTER TABLE [dbo].[Epics] CHECK CONSTRAINT [FK_Epics_CodeSet]
GO
/****** Object:  ForeignKey [FK_Epics_Proj]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Epics]  WITH CHECK ADD  CONSTRAINT [FK_Epics_Proj] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Epics] CHECK CONSTRAINT [FK_Epics_Proj]
GO
/****** Object:  ForeignKey [FK_Epics_RFE]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Epics]  WITH CHECK ADD  CONSTRAINT [FK_Epics_RFE] FOREIGN KEY([RFEId])
REFERENCES [dbo].[RFE] ([RFEId])
GO
ALTER TABLE [dbo].[Epics] CHECK CONSTRAINT [FK_Epics_RFE]
GO
/****** Object:  ForeignKey [FK_Epics_Team]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Epics]  WITH CHECK ADD  CONSTRAINT [FK_Epics_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO
ALTER TABLE [dbo].[Epics] CHECK CONSTRAINT [FK_Epics_Team]
GO
/****** Object:  ForeignKey [FK_Stories_CodeSet]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Stories]  WITH CHECK ADD  CONSTRAINT [FK_Stories_CodeSet] FOREIGN KEY([Status])
REFERENCES [dbo].[CodeSet] ([CodeSetId])
GO
ALTER TABLE [dbo].[Stories] CHECK CONSTRAINT [FK_Stories_CodeSet]
GO
/****** Object:  ForeignKey [FK_Stories_Epics]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Stories]  WITH CHECK ADD  CONSTRAINT [FK_Stories_Epics] FOREIGN KEY([EpicId])
REFERENCES [dbo].[Epics] ([EpicId])
GO
ALTER TABLE [dbo].[Stories] CHECK CONSTRAINT [FK_Stories_Epics]
GO
/****** Object:  ForeignKey [FK_Tasks_CodeSet]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_CodeSet] FOREIGN KEY([Status])
REFERENCES [dbo].[CodeSet] ([CodeSetId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_CodeSet]
GO
/****** Object:  ForeignKey [FK_Tasks_Stories]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Stories] FOREIGN KEY([StoryId])
REFERENCES [dbo].[Stories] ([StoryId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Stories]
GO
/****** Object:  ForeignKey [FK_EpicsInSprint]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[ESTinSprint]  WITH CHECK ADD  CONSTRAINT [FK_EpicsInSprint] FOREIGN KEY([EpicId])
REFERENCES [dbo].[Epics] ([EpicId])
GO
ALTER TABLE [dbo].[ESTinSprint] CHECK CONSTRAINT [FK_EpicsInSprint]
GO
/****** Object:  ForeignKey [FK_ESTinSprint_Sprints]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[ESTinSprint]  WITH CHECK ADD  CONSTRAINT [FK_ESTinSprint_Sprints] FOREIGN KEY([SprintId])
REFERENCES [dbo].[Sprints] ([SprintId])
GO
ALTER TABLE [dbo].[ESTinSprint] CHECK CONSTRAINT [FK_ESTinSprint_Sprints]
GO
/****** Object:  ForeignKey [FK_StoriesInSprint]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[ESTinSprint]  WITH CHECK ADD  CONSTRAINT [FK_StoriesInSprint] FOREIGN KEY([StoryId])
REFERENCES [dbo].[Stories] ([StoryId])
GO
ALTER TABLE [dbo].[ESTinSprint] CHECK CONSTRAINT [FK_StoriesInSprint]
GO
/****** Object:  ForeignKey [FK_TasksInSprint]    Script Date: 07/10/2013 13:34:31 ******/
ALTER TABLE [dbo].[ESTinSprint]  WITH CHECK ADD  CONSTRAINT [FK_TasksInSprint] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Taskid])
GO
ALTER TABLE [dbo].[ESTinSprint] CHECK CONSTRAINT [FK_TasksInSprint]
GO
