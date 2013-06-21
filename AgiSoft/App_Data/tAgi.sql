USE [master]
GO
/****** Object:  Database [tAgi]    Script Date: 06/21/2013 12:43:24 ******/
CREATE DATABASE [tAgi] ON  PRIMARY 
( NAME = N'tAgi.mdf', FILENAME = N'C:\VS2012\Projects\AgiSoft\AgiSoft\App_Data\tAgi.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'tAgi_log.ldf', FILENAME = N'C:\VS2012\Projects\AgiSoft\AgiSoft\App_Data\tAgi_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [tAgi] SET  ENABLE_BROKER
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
/****** Object:  Table [dbo].[RoleGroups]    Script Date: 06/21/2013 12:43:25 ******/
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
/****** Object:  Table [dbo].[PasswordQuestions]    Script Date: 06/21/2013 12:43:25 ******/
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
/****** Object:  Table [dbo].[UserProfile]    Script Date: 06/21/2013 12:43:25 ******/
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
	[Mobile] [varchar](20) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[IsLocked] [bit] NOT NULL,
 CONSTRAINT [PK__UserProf__1788CC4C7F60ED59] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 06/21/2013 12:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NULL,
	[ShipName] [varchar](50) NULL,
	[ShipCity] [varchar](50) NULL,
	[Freight] [varchar](20) NULL,
	[ShipPostalCode] [varchar](20) NULL,
	[ShipCountry] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 06/21/2013 12:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 06/21/2013 12:43:25 ******/
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
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 06/21/2013 12:43:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 06/21/2013 12:43:25 ******/
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
/****** Object:  Table [dbo].[RolesInGroups]    Script Date: 06/21/2013 12:43:25 ******/
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
/****** Object:  Table [dbo].[PasswordHistory]    Script Date: 06/21/2013 12:43:25 ******/
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
/****** Object:  Table [dbo].[PassQuesAnswers]    Script Date: 06/21/2013 12:43:25 ******/
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
/****** Object:  Default [DF_PasswordQuestions_IsActive]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[PasswordQuestions] ADD  CONSTRAINT [DF_PasswordQuestions_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_PasswordQuestions_EntryDate]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[PasswordQuestions] ADD  CONSTRAINT [DF_PasswordQuestions_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
/****** Object:  Default [DF_UserProfile_IsLocked]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF__webpages___IsCon__628FA481]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
/****** Object:  Default [DF__webpages___Passw__6383C8BA]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
/****** Object:  Default [DF_PasswordHistory_Date]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[PasswordHistory] ADD  CONSTRAINT [DF_PasswordHistory_Date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_PassQuesAnswers_IsValid]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[PassQuesAnswers] ADD  CONSTRAINT [DF_PassQuesAnswers_IsValid]  DEFAULT ((1)) FOR [IsValid]
GO
/****** Object:  Default [DF_PassQuesAnswers_EntryDate]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[PassQuesAnswers] ADD  CONSTRAINT [DF_PassQuesAnswers_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
/****** Object:  ForeignKey [FK_webpages_OAuthMembership_UserProfile]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[webpages_OAuthMembership]  WITH CHECK ADD  CONSTRAINT [FK_webpages_OAuthMembership_UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_OAuthMembership] CHECK CONSTRAINT [FK_webpages_OAuthMembership_UserProfile]
GO
/****** Object:  ForeignKey [FK_webpages_Membership_UserProfile]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[webpages_Membership]  WITH CHECK ADD  CONSTRAINT [FK_webpages_Membership_UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_Membership] CHECK CONSTRAINT [FK_webpages_Membership_UserProfile]
GO
/****** Object:  ForeignKey [fk_RoleId]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
/****** Object:  ForeignKey [fk_UserId]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
/****** Object:  ForeignKey [FK_RolesInGroups_RoleGroups]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[RolesInGroups]  WITH CHECK ADD  CONSTRAINT [FK_RolesInGroups_RoleGroups] FOREIGN KEY([RoleGroupId])
REFERENCES [dbo].[RoleGroups] ([RoleGroupId])
GO
ALTER TABLE [dbo].[RolesInGroups] CHECK CONSTRAINT [FK_RolesInGroups_RoleGroups]
GO
/****** Object:  ForeignKey [FK_RolesInGroups_Roles]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[RolesInGroups]  WITH CHECK ADD  CONSTRAINT [FK_RolesInGroups_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[RolesInGroups] CHECK CONSTRAINT [FK_RolesInGroups_Roles]
GO
/****** Object:  ForeignKey [FK_PasswordHistory_UserProfile]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[PasswordHistory]  WITH CHECK ADD  CONSTRAINT [FK_PasswordHistory_UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[PasswordHistory] CHECK CONSTRAINT [FK_PasswordHistory_UserProfile]
GO
/****** Object:  ForeignKey [FK_PassQuesAnswers_PasswordQuestions]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[PassQuesAnswers]  WITH CHECK ADD  CONSTRAINT [FK_PassQuesAnswers_PasswordQuestions] FOREIGN KEY([PassQuesId])
REFERENCES [dbo].[PasswordQuestions] ([PassQuestionId])
GO
ALTER TABLE [dbo].[PassQuesAnswers] CHECK CONSTRAINT [FK_PassQuesAnswers_PasswordQuestions]
GO
/****** Object:  ForeignKey [FK_PassQuesAnswers_UserProfile]    Script Date: 06/21/2013 12:43:25 ******/
ALTER TABLE [dbo].[PassQuesAnswers]  WITH CHECK ADD  CONSTRAINT [FK_PassQuesAnswers_UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[PassQuesAnswers] CHECK CONSTRAINT [FK_PassQuesAnswers_UserProfile]
GO
