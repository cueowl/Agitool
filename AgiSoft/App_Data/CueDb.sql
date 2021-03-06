USE [master]
GO
/****** Object:  Database [CueDb]    Script Date: 07/29/2013 14:18:23 ******/
CREATE DATABASE [CueDb] ON  PRIMARY 
( NAME = N'CueDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\CueDb.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CueDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\CueDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CueDb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CueDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CueDb] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [CueDb] SET ANSI_NULLS OFF
GO
ALTER DATABASE [CueDb] SET ANSI_PADDING OFF
GO
ALTER DATABASE [CueDb] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [CueDb] SET ARITHABORT OFF
GO
ALTER DATABASE [CueDb] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [CueDb] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [CueDb] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [CueDb] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [CueDb] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [CueDb] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [CueDb] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [CueDb] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [CueDb] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [CueDb] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [CueDb] SET  DISABLE_BROKER
GO
ALTER DATABASE [CueDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [CueDb] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [CueDb] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [CueDb] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [CueDb] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [CueDb] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [CueDb] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [CueDb] SET  READ_WRITE
GO
ALTER DATABASE [CueDb] SET RECOVERY FULL
GO
ALTER DATABASE [CueDb] SET  MULTI_USER
GO
ALTER DATABASE [CueDb] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [CueDb] SET DB_CHAINING OFF
GO
USE [CueDb]
GO
/****** Object:  Table [dbo].[User]    Script Date: 07/29/2013 14:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](128) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Registrations]    Script Date: 07/29/2013 14:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrations](
	[RegId] [int] IDENTITY(1,1) NOT NULL,
	[RegCode] [nvarchar](128) NOT NULL,
	[RegDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Registrations] PRIMARY KEY CLUSTERED 
(
	[RegId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 07/29/2013 14:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ProdId] [int] IDENTITY(1,1) NOT NULL,
	[ProdName] [varchar](50) NULL,
	[ProdDesc] [varchar](256) NULL,
	[Message] [varchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProdId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PasswordQuestions]    Script Date: 07/29/2013 14:18:23 ******/
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
/****** Object:  Table [dbo].[Clients]    Script Date: 07/29/2013 14:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[Company] [varchar](50) NULL,
	[ContactFName] [varchar](50) NULL,
	[ContactLName] [varchar](50) NULL,
	[Address] [varchar](256) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[CompSize] [int] NULL,
	[JoinDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 07/29/2013 14:18:23 ******/
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
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 07/29/2013 14:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_webpages_UsersInRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 07/29/2013 14:18:23 ******/
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
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 07/29/2013 14:18:23 ******/
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
	[ConfirmationDate] [datetime] NULL,
	[IsFirstLogin] [bit] NOT NULL,
 CONSTRAINT [PK__webpages__1788CC4C25869641] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersWithClients]    Script Date: 07/29/2013 14:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersWithClients](
	[ClientId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UsersWithClient] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientProdRegs]    Script Date: 07/29/2013 14:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientProdRegs](
	[ClientId] [int] NOT NULL,
	[ProdId] [int] NOT NULL,
	[RegId] [int] NOT NULL,
 CONSTRAINT [PK_ClientProducts] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[ProdId] ASC,
	[RegId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordHistory]    Script Date: 07/29/2013 14:18:23 ******/
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
/****** Object:  Table [dbo].[PassQuesAnswers]    Script Date: 07/29/2013 14:18:23 ******/
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
/****** Object:  Table [dbo].[CodeSetType]    Script Date: 07/29/2013 14:18:23 ******/
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
/****** Object:  Table [dbo].[CodeSet]    Script Date: 07/29/2013 14:18:23 ******/
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
/****** Object:  Default [DF_Registrations_RegDate]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[Registrations] ADD  CONSTRAINT [DF_Registrations_RegDate]  DEFAULT (getdate()) FOR [RegDate]
GO
/****** Object:  Default [DF_PasswordQuestions_IsActive]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[PasswordQuestions] ADD  CONSTRAINT [DF_PasswordQuestions_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_PasswordQuestions_EntryDate]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[PasswordQuestions] ADD  CONSTRAINT [DF_PasswordQuestions_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
/****** Object:  Default [DF_Client_JoinDate]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[Clients] ADD  CONSTRAINT [DF_Client_JoinDate]  DEFAULT (getdate()) FOR [JoinDate]
GO
/****** Object:  Default [DF__webpages___IsCon__286302EC]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  CONSTRAINT [DF__webpages___IsCon__286302EC]  DEFAULT ((0)) FOR [IsConfirmed]
GO
/****** Object:  Default [DF__webpages___Passw__29572725]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  CONSTRAINT [DF__webpages___Passw__29572725]  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
/****** Object:  Default [DF_webpages_Membership_IsFirstLogin]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  CONSTRAINT [DF_webpages_Membership_IsFirstLogin]  DEFAULT ((1)) FOR [IsFirstLogin]
GO
/****** Object:  Default [DF_PasswordHistory_Date]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[PasswordHistory] ADD  CONSTRAINT [DF_PasswordHistory_Date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_PassQuesAnswers_IsValid]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[PassQuesAnswers] ADD  CONSTRAINT [DF_PassQuesAnswers_IsValid]  DEFAULT ((1)) FOR [IsValid]
GO
/****** Object:  Default [DF_PassQuesAnswers_EntryDate]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[PassQuesAnswers] ADD  CONSTRAINT [DF_PassQuesAnswers_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
/****** Object:  Default [DF_CodeSetType_ModifiedDate]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[CodeSetType] ADD  CONSTRAINT [DF_CodeSetType_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
/****** Object:  Default [DF_CodeSet_ModifiedDate]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[CodeSet] ADD  CONSTRAINT [DF_CodeSet_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
/****** Object:  ForeignKey [FK_RoleId]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [FK_RoleId]
GO
/****** Object:  ForeignKey [FK_UserId]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [FK_UserId]
GO
/****** Object:  ForeignKey [FK_webpages_OAuthMembership_UserProfile]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[webpages_OAuthMembership]  WITH CHECK ADD  CONSTRAINT [FK_webpages_OAuthMembership_UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[webpages_OAuthMembership] CHECK CONSTRAINT [FK_webpages_OAuthMembership_UserProfile]
GO
/****** Object:  ForeignKey [FK_webpages_Membership_UserProfile]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[webpages_Membership]  WITH CHECK ADD  CONSTRAINT [FK_webpages_Membership_UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[webpages_Membership] CHECK CONSTRAINT [FK_webpages_Membership_UserProfile]
GO
/****** Object:  ForeignKey [FK_UsersWithClient_Clients]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[UsersWithClients]  WITH CHECK ADD  CONSTRAINT [FK_UsersWithClient_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[UsersWithClients] CHECK CONSTRAINT [FK_UsersWithClient_Clients]
GO
/****** Object:  ForeignKey [FK_UsersWithClient_User]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[UsersWithClients]  WITH CHECK ADD  CONSTRAINT [FK_UsersWithClient_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UsersWithClients] CHECK CONSTRAINT [FK_UsersWithClient_User]
GO
/****** Object:  ForeignKey [FK_ClientProd_Client]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[ClientProdRegs]  WITH CHECK ADD  CONSTRAINT [FK_ClientProd_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[ClientProdRegs] CHECK CONSTRAINT [FK_ClientProd_Client]
GO
/****** Object:  ForeignKey [FK_ClientProd_Products]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[ClientProdRegs]  WITH CHECK ADD  CONSTRAINT [FK_ClientProd_Products] FOREIGN KEY([ProdId])
REFERENCES [dbo].[Products] ([ProdId])
GO
ALTER TABLE [dbo].[ClientProdRegs] CHECK CONSTRAINT [FK_ClientProd_Products]
GO
/****** Object:  ForeignKey [FK_ClientProducts_Registrations]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[ClientProdRegs]  WITH CHECK ADD  CONSTRAINT [FK_ClientProducts_Registrations] FOREIGN KEY([RegId])
REFERENCES [dbo].[Registrations] ([RegId])
GO
ALTER TABLE [dbo].[ClientProdRegs] CHECK CONSTRAINT [FK_ClientProducts_Registrations]
GO
/****** Object:  ForeignKey [FK_PasswordHistory_User]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[PasswordHistory]  WITH CHECK ADD  CONSTRAINT [FK_PasswordHistory_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[PasswordHistory] CHECK CONSTRAINT [FK_PasswordHistory_User]
GO
/****** Object:  ForeignKey [FK_PassQuesAnswers_PasswordQuestions]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[PassQuesAnswers]  WITH CHECK ADD  CONSTRAINT [FK_PassQuesAnswers_PasswordQuestions] FOREIGN KEY([PassQuesId])
REFERENCES [dbo].[PasswordQuestions] ([PassQuestionId])
GO
ALTER TABLE [dbo].[PassQuesAnswers] CHECK CONSTRAINT [FK_PassQuesAnswers_PasswordQuestions]
GO
/****** Object:  ForeignKey [FK_PassQuesAnswers_UserProfile]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[PassQuesAnswers]  WITH CHECK ADD  CONSTRAINT [FK_PassQuesAnswers_UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[PassQuesAnswers] CHECK CONSTRAINT [FK_PassQuesAnswers_UserProfile]
GO
/****** Object:  ForeignKey [FK_UserModified]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[CodeSetType]  WITH CHECK ADD  CONSTRAINT [FK_UserModified] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[CodeSetType] CHECK CONSTRAINT [FK_UserModified]
GO
/****** Object:  ForeignKey [FK_CodeSet_Modified]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[CodeSet]  WITH CHECK ADD  CONSTRAINT [FK_CodeSet_Modified] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[CodeSet] CHECK CONSTRAINT [FK_CodeSet_Modified]
GO
/****** Object:  ForeignKey [FK_CodeSetType]    Script Date: 07/29/2013 14:18:23 ******/
ALTER TABLE [dbo].[CodeSet]  WITH CHECK ADD  CONSTRAINT [FK_CodeSetType] FOREIGN KEY([CodeSetTypeId])
REFERENCES [dbo].[CodeSetType] ([CodeSetTypeId])
GO
ALTER TABLE [dbo].[CodeSet] CHECK CONSTRAINT [FK_CodeSetType]
GO
