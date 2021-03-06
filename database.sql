USE [master]
GO
/****** Object:  Database [ChurchMemberProfile]    Script Date: 02/09/2015 5:45:59 PM ******/
CREATE DATABASE [ChurchMemberProfile]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChurchMemberProfile', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\ChurchMemberProfile.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ChurchMemberProfile_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\ChurchMemberProfile_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ChurchMemberProfile] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChurchMemberProfile].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChurchMemberProfile] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ChurchMemberProfile] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChurchMemberProfile] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChurchMemberProfile] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChurchMemberProfile] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChurchMemberProfile] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ChurchMemberProfile] SET  MULTI_USER 
GO
ALTER DATABASE [ChurchMemberProfile] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChurchMemberProfile] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChurchMemberProfile] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChurchMemberProfile] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ChurchMemberProfile]
GO
/****** Object:  Table [dbo].[MemberProfile]    Script Date: 02/09/2015 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberProfile](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[MI] [nvarchar](50) NULL,
	[Nickname] [nvarchar](50) NULL,
	[Birthdate] [date] NOT NULL,
	[LeaderId] [int] NULL,
	[Address] [nvarchar](150) NULL,
 CONSTRAINT [PK_MemberProfile] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MemberProfilePropertyDefinition]    Script Date: 02/09/2015 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberProfilePropertyDefinition](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[TemplateID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Enabled] [tinyint] NOT NULL,
 CONSTRAINT [PK_MemberProfileProperties] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MemberProfilePropertyValue]    Script Date: 02/09/2015 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberProfilePropertyValue](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[PropertyID] [int] NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_MemberProfilePropertyValue] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Template]    Script Date: 02/09/2015 5:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Template](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[TemplateName] [nvarchar](50) NOT NULL,
	[TemplateDescription] [nvarchar](150) NULL,
 CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [ChurchMemberProfile] SET  READ_WRITE 
GO
