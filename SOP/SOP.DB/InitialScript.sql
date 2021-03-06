USE [master]
GO
/****** Object:  Database [SOP]    Script Date: 07/21/2014 01:48:18 ******/
CREATE DATABASE [SOP] ON  PRIMARY 
( NAME = N'SOP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SOP.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SOP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SOP_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SOP] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SOP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SOP] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SOP] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SOP] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SOP] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SOP] SET ARITHABORT OFF
GO
ALTER DATABASE [SOP] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SOP] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SOP] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SOP] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SOP] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SOP] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SOP] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SOP] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SOP] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SOP] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SOP] SET  DISABLE_BROKER
GO
ALTER DATABASE [SOP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SOP] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SOP] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SOP] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SOP] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SOP] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SOP] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SOP] SET  READ_WRITE
GO
ALTER DATABASE [SOP] SET RECOVERY FULL
GO
ALTER DATABASE [SOP] SET  MULTI_USER
GO
ALTER DATABASE [SOP] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SOP] SET DB_CHAINING OFF
GO
USE [SOP]
GO
/****** Object:  Table [dbo].[SecretQuestions]    Script Date: 07/21/2014 01:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecretQuestions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_SecretQuestions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 07/21/2014 01:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubscriptionPackage]    Script Date: 07/21/2014 01:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionPackage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Package] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SubscriptionPackage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dealer]    Script Date: 07/21/2014 01:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dealer](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[PrimaryContactPersonName] [nvarchar](200) NOT NULL,
	[PrimaryContactPersonNum] [numeric](18, 0) NOT NULL,
	[SecondaryContactPersonName] [nvarchar](200) NULL,
	[SecondaryContactPersonNum] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Dealer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coupon]    Script Date: 07/21/2014 01:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coupon](
	[Id] [int] NOT NULL,
	[DiscountPercentage] [int] NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
	[TermsandCondition] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Coupon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceType]    Script Date: 07/21/2014 01:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceType](
	[Id] [int] NOT NULL,
	[ServiceType] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ServiceType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workshop]    Script Date: 07/21/2014 01:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workshop](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[PhoneNumber] [numeric](18, 0) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[MapCoordinates] [nvarchar](50) NULL,
	[GeneralManagerName] [nvarchar](200) NOT NULL,
	[GeneralManagerNum] [numeric](18, 0) NULL,
	[DelearId] [int] NOT NULL,
 CONSTRAINT [PK_Workshop] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 07/21/2014 01:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NOT NULL,
	[DealerId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NOT NULL,
	[LastModifiedBy] [int] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 07/21/2014 01:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [int] NOT NULL,
	[VehicleOwnerName] [nvarchar](200) NOT NULL,
	[VehicleOwnerDOB] [datetime] NULL,
	[VehicleNumber] [nvarchar](50) NOT NULL,
	[VehicleLocation] [nvarchar](200) NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Mobile] [numeric](18, 0) NOT NULL,
	[EmailId] [nvarchar](200) NOT NULL,
	[DelearId] [int] NOT NULL,
	[DateOfService] [datetime] NOT NULL,
	[ServiceType] [int] NOT NULL,
	[DemandedRepairs] [nvarchar](max) NULL,
	[BookingOnBehalf] [bit] NOT NULL,
	[ManufacturingYear] [int] NULL,
	[City/Town] [nvarchar](100) NULL,
	[VehicleModel] [nvarchar](50) NOT NULL,
	[SecretQuestion] [int] NULL,
	[SecretAnswer] [nvarchar](200) NULL,
	[CreatedBy] [datetime] NOT NULL,
	[LastModifiedBy] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SopUser]    Script Date: 07/21/2014 01:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SopUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Gender] [int] NOT NULL,
	[EmailId] [nvarchar](200) NOT NULL,
	[Mobile] [numeric](18, 0) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_SopUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentSummary]    Script Date: 07/21/2014 01:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentSummary](
	[WorkshopId] [int] NOT NULL,
	[PackageId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[DateOfPayment] [datetime] NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_PaymentSummary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 07/21/2014 01:48:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[Id] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[BookingId] [int] NOT NULL,
	[Feedback] [nvarchar](max) NOT NULL,
	[DealerId] [int] NOT NULL,
 CONSTRAINT [PK_Feedback_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Workshop_Dealer]    Script Date: 07/21/2014 01:48:22 ******/
ALTER TABLE [dbo].[Workshop]  WITH CHECK ADD  CONSTRAINT [FK_Workshop_Dealer] FOREIGN KEY([DelearId])
REFERENCES [dbo].[Dealer] ([Id])
GO
ALTER TABLE [dbo].[Workshop] CHECK CONSTRAINT [FK_Workshop_Dealer]
GO
/****** Object:  ForeignKey [FK_Service_Dealer]    Script Date: 07/21/2014 01:48:22 ******/
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Dealer] FOREIGN KEY([DealerId])
REFERENCES [dbo].[Dealer] ([Id])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Dealer]
GO
/****** Object:  ForeignKey [FK_Booking_Dealer]    Script Date: 07/21/2014 01:48:22 ******/
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Dealer] FOREIGN KEY([DelearId])
REFERENCES [dbo].[Dealer] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Dealer]
GO
/****** Object:  ForeignKey [FK_Booking_SecretQuestions]    Script Date: 07/21/2014 01:48:22 ******/
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_SecretQuestions] FOREIGN KEY([SecretQuestion])
REFERENCES [dbo].[SecretQuestions] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_SecretQuestions]
GO
/****** Object:  ForeignKey [FK_Booking_ServiceType]    Script Date: 07/21/2014 01:48:22 ******/
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_ServiceType] FOREIGN KEY([ServiceType])
REFERENCES [dbo].[ServiceType] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_ServiceType]
GO
/****** Object:  ForeignKey [FK_SopUser_Roles]    Script Date: 07/21/2014 01:48:22 ******/
ALTER TABLE [dbo].[SopUser]  WITH CHECK ADD  CONSTRAINT [FK_SopUser_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[SopUser] CHECK CONSTRAINT [FK_SopUser_Roles]
GO
/****** Object:  ForeignKey [FK_PaymentSummary_SubscriptionPackage]    Script Date: 07/21/2014 01:48:22 ******/
ALTER TABLE [dbo].[PaymentSummary]  WITH CHECK ADD  CONSTRAINT [FK_PaymentSummary_SubscriptionPackage] FOREIGN KEY([PackageId])
REFERENCES [dbo].[SubscriptionPackage] ([Id])
GO
ALTER TABLE [dbo].[PaymentSummary] CHECK CONSTRAINT [FK_PaymentSummary_SubscriptionPackage]
GO
/****** Object:  ForeignKey [FK_PaymentSummary_Workshop]    Script Date: 07/21/2014 01:48:22 ******/
ALTER TABLE [dbo].[PaymentSummary]  WITH CHECK ADD  CONSTRAINT [FK_PaymentSummary_Workshop] FOREIGN KEY([WorkshopId])
REFERENCES [dbo].[Workshop] ([Id])
GO
ALTER TABLE [dbo].[PaymentSummary] CHECK CONSTRAINT [FK_PaymentSummary_Workshop]
GO
/****** Object:  ForeignKey [FK_Feedback_Booking]    Script Date: 07/21/2014 01:48:22 ******/
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Booking] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Booking] ([Id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Booking]
GO
/****** Object:  ForeignKey [FK_Feedback_Dealer]    Script Date: 07/21/2014 01:48:22 ******/
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Dealer] FOREIGN KEY([DealerId])
REFERENCES [dbo].[Dealer] ([Id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Dealer]
GO
/****** Object:  ForeignKey [FK_Feedback_SopUser]    Script Date: 07/21/2014 01:48:22 ******/
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_SopUser] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[SopUser] ([Id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_SopUser]
GO
