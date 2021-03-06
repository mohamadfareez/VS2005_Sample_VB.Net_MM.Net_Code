USE [master]
GO
/****** Object:  Database [TestProject]    Script Date: 11/06/2012 17:58:49 ******/
CREATE DATABASE [TestProject] ON  PRIMARY 
( NAME = N'TestProject', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\TestProject.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestProject_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\TestProject_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestProject] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestProject].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [TestProject] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [TestProject] SET ANSI_NULLS OFF
GO
ALTER DATABASE [TestProject] SET ANSI_PADDING OFF
GO
ALTER DATABASE [TestProject] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [TestProject] SET ARITHABORT OFF
GO
ALTER DATABASE [TestProject] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [TestProject] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [TestProject] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [TestProject] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [TestProject] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [TestProject] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [TestProject] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [TestProject] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [TestProject] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [TestProject] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [TestProject] SET  DISABLE_BROKER
GO
ALTER DATABASE [TestProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [TestProject] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [TestProject] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [TestProject] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [TestProject] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [TestProject] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [TestProject] SET  READ_WRITE
GO
ALTER DATABASE [TestProject] SET RECOVERY SIMPLE
GO
ALTER DATABASE [TestProject] SET  MULTI_USER
GO
ALTER DATABASE [TestProject] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TestProject] SET DB_CHAINING OFF
GO
USE [TestProject]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/06/2012 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[RolePK] [int] IDENTITY(1,1) NOT NULL,
	[Description] [char](128) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RolePK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Security]    Script Date: 11/06/2012 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Security](
	[SecurityPK] [varchar](50) NOT NULL,
	[Description] [varchar](256) NULL,
 CONSTRAINT [PK_Security] PRIMARY KEY CLUSTERED 
(
	[SecurityPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/06/2012 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserPK] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [varchar](128) NOT NULL,
	[Password] [char](10) NULL,
	[FirstName] [char](40) NOT NULL,
	[LastName] [char](40) NOT NULL,
	[LanguageFK] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Negeri]    Script Date: 11/06/2012 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Negeri](
	[PK_Negeri] [bigint] IDENTITY(1,1) NOT NULL,
	[KodNegeri] [nvarchar](10) NULL,
	[Deskripsi] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Negeri] PRIMARY KEY CLUSTERED 
(
	[PK_Negeri] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 11/06/2012 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRolesPK] [int] IDENTITY(1,1) NOT NULL,
	[UserFK] [int] NOT NULL,
	[RoleFK] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserRolesPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleSecurity]    Script Date: 11/06/2012 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleSecurity](
	[RoleSecurityPK] [int] IDENTITY(1,1) NOT NULL,
	[RoleFK] [int] NOT NULL,
	[SecurityFK] [varchar](50) NOT NULL,
	[AccessLevel] [smallint] NULL,
 CONSTRAINT [PK_RoleSecurity] PRIMARY KEY CLUSTERED 
(
	[RoleSecurityPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserSecurity]    Script Date: 11/06/2012 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserSecurity](
	[UserSecurityPK] [int] IDENTITY(1,1) NOT NULL,
	[UserFK] [int] NOT NULL,
	[SecurityFK] [varchar](50) NOT NULL,
	[AccessLevel] [smallint] NOT NULL,
 CONSTRAINT [PK_UserSecurity] PRIMARY KEY CLUSTERED 
(
	[UserSecurityPK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Individu]    Script Date: 11/06/2012 17:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Individu](
	[PK_Individu] [bigint] IDENTITY(1,1) NOT NULL,
	[Nama] [nvarchar](250) NULL,
	[NoMyKad] [numeric](12, 0) NULL,
	[TkhLahir] [datetime] NULL,
	[Alamat] [nvarchar](max) NULL,
	[Poskod] [numeric](5, 0) NULL,
	[FK_Negeri] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Security_SecurityPK]    Script Date: 11/06/2012 17:58:50 ******/
ALTER TABLE [dbo].[Security] ADD  CONSTRAINT [DF_Security_SecurityPK]  DEFAULT (newid()) FOR [SecurityPK]
GO
/****** Object:  Default [DF__Users__LanguageF__1A14E395]    Script Date: 11/06/2012 17:58:50 ******/
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [LanguageFK]
GO
/****** Object:  ForeignKey [FK_UserRoles_Roles]    Script Date: 11/06/2012 17:58:50 ******/
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleFK])
REFERENCES [dbo].[Roles] ([RolePK])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
/****** Object:  ForeignKey [FK_UserRoles_Users]    Script Date: 11/06/2012 17:58:50 ******/
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserFK])
REFERENCES [dbo].[Users] ([UserPK])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
/****** Object:  ForeignKey [FK_RoleSecurity_Roles]    Script Date: 11/06/2012 17:58:50 ******/
ALTER TABLE [dbo].[RoleSecurity]  WITH CHECK ADD  CONSTRAINT [FK_RoleSecurity_Roles] FOREIGN KEY([RoleFK])
REFERENCES [dbo].[Roles] ([RolePK])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleSecurity] CHECK CONSTRAINT [FK_RoleSecurity_Roles]
GO
/****** Object:  ForeignKey [FK_RoleSecurity_Security]    Script Date: 11/06/2012 17:58:50 ******/
ALTER TABLE [dbo].[RoleSecurity]  WITH CHECK ADD  CONSTRAINT [FK_RoleSecurity_Security] FOREIGN KEY([SecurityFK])
REFERENCES [dbo].[Security] ([SecurityPK])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleSecurity] CHECK CONSTRAINT [FK_RoleSecurity_Security]
GO
/****** Object:  ForeignKey [FK_UserSecurity_Security]    Script Date: 11/06/2012 17:58:50 ******/
ALTER TABLE [dbo].[UserSecurity]  WITH CHECK ADD  CONSTRAINT [FK_UserSecurity_Security] FOREIGN KEY([SecurityFK])
REFERENCES [dbo].[Security] ([SecurityPK])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSecurity] CHECK CONSTRAINT [FK_UserSecurity_Security]
GO
/****** Object:  ForeignKey [FK_UserSecurity_Users]    Script Date: 11/06/2012 17:58:50 ******/
ALTER TABLE [dbo].[UserSecurity]  WITH CHECK ADD  CONSTRAINT [FK_UserSecurity_Users] FOREIGN KEY([UserFK])
REFERENCES [dbo].[Users] ([UserPK])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSecurity] CHECK CONSTRAINT [FK_UserSecurity_Users]
GO
/****** Object:  ForeignKey [FK_Individu_Negeri]    Script Date: 11/06/2012 17:58:50 ******/
ALTER TABLE [dbo].[Individu]  WITH CHECK ADD  CONSTRAINT [FK_Individu_Negeri] FOREIGN KEY([FK_Negeri])
REFERENCES [dbo].[Negeri] ([PK_Negeri])
GO
ALTER TABLE [dbo].[Individu] CHECK CONSTRAINT [FK_Individu_Negeri]
GO
