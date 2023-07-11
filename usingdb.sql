USE [master]
GO
/****** Object:  Database [MyStore]    Script Date: 11-Jul-23 2:19:30 PM ******/
CREATE DATABASE [MyStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MyStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MyStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MyStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyStore] SET RECOVERY FULL 
GO
ALTER DATABASE [MyStore] SET  MULTI_USER 
GO
ALTER DATABASE [MyStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyStore] SET QUERY_STORE = OFF
GO
USE [MyStore]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11-Jul-23 2:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11-Jul-23 2:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](15) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[DOB] [date] NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](12) NULL,
	[NumberID] [nvarchar](15) NOT NULL,
	[Role] [nvarchar](40) NULL,
 CONSTRAINT [PK_emp] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fee]    Script Date: 11-Jul-23 2:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fee](
	[FeeID] [int] IDENTITY(1,1) NOT NULL,
	[RecordID] [int] NOT NULL,
	[PaymentDate] [date] NULL,
	[PaiedDate] [date] NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[Method] [nvarchar](20) NULL,
 CONSTRAINT [PK_fee] PRIMARY KEY CLUSTERED 
(
	[FeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Insurance]    Script Date: 11-Jul-23 2:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insurance](
	[InsuranceID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](10) NOT NULL,
	[PatientID] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Supplier] [nvarchar](100) NOT NULL,
	[Percent] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_insurance] PRIMARY KEY CLUSTERED 
(
	[InsuranceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 11-Jul-23 2:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[DOB] [date] NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](12) NULL,
	[NumberID] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_patient] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 11-Jul-23 2:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNumber] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[PayedDate] [date] NULL,
	[BillingInformation] [nvarchar](100) NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Record]    Script Date: 11-Jul-23 2:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Record](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[ServiceID] [int] NOT NULL,
	[RecordDate] [date] NOT NULL,
	[diagnosis] [text] NULL,
	[prescription] [text] NULL,
	[test_result] [text] NULL,
	[imaging_result] [text] NULL,
 CONSTRAINT [PK_record] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 11-Jul-23 2:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Type] [nvarchar](40) NULL,
	[Fee] [decimal](10, 2) NULL,
 CONSTRAINT [PK_service] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (1, N'Laboratory', N'Laboratory tests')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (2, N'Radiology', N'Radiology services')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (3, N'Surgery', N'Surgical procedures')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (4, N'Therapy', N'Physical therapy')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (5, N'Pharmacy', N'Medication and pharmacy services')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([EmployeeId], [UserName], [Password], [Email], [FullName], [Gender], [DOB], [Address], [Phone], [NumberID], [Role]) VALUES (1, N'duy', N'123', N'john@example.com', N'John Smith', N'Male', CAST(N'1990-05-15' AS Date), N'123 Main St', N'123-456-7890', N'1234567890', N'Staff')
GO
INSERT [dbo].[Employee] ([EmployeeId], [UserName], [Password], [Email], [FullName], [Gender], [DOB], [Address], [Phone], [NumberID], [Role]) VALUES (2, N'johnsmith', N'password1', N'john@example.com', N'John Smith', N'Male', CAST(N'1990-05-15' AS Date), N'123 Main St', N'123-456-7890', N'1234567890', N'Admin')
GO
INSERT [dbo].[Employee] ([EmployeeId], [UserName], [Password], [Email], [FullName], [Gender], [DOB], [Address], [Phone], [NumberID], [Role]) VALUES (3, N'janedoe', N'password2', N'jane@example.com', N'Jane Doe', N'Female', CAST(N'1988-10-20' AS Date), N'456 Elm St', N'987-654-3210', N'0987654321', N'Staff')
GO
INSERT [dbo].[Employee] ([EmployeeId], [UserName], [Password], [Email], [FullName], [Gender], [DOB], [Address], [Phone], [NumberID], [Role]) VALUES (4, N'mikesmith', N'password3', N'mike@example.com', N'Mike Smith', N'Male', CAST(N'1992-03-25' AS Date), N'789 Oak St', N'555-555-5555', N'9876543210', N'Staff')
GO
INSERT [dbo].[Employee] ([EmployeeId], [UserName], [Password], [Email], [FullName], [Gender], [DOB], [Address], [Phone], [NumberID], [Role]) VALUES (5, N'sarahjones', N'password4', N'sarah@example.com', N'Sarah Jones', N'Female', CAST(N'1995-07-08' AS Date), N'321 Pine St', N'111-222-3333', N'0123456789', N'Staff')
GO
INSERT [dbo].[Employee] ([EmployeeId], [UserName], [Password], [Email], [FullName], [Gender], [DOB], [Address], [Phone], [NumberID], [Role]) VALUES (6, N'markwilson', N'password5', N'mark@example.com', N'Mark Wilson', N'Male', CAST(N'1991-12-01' AS Date), N'567 Maple St', N'444-444-4444', N'5678901234', N'Staff')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Fee] ON 
GO
INSERT [dbo].[Fee] ([FeeID], [RecordID], [PaymentDate], [PaiedDate], [Amount], [Method]) VALUES (1, 1, CAST(N'2023-06-16' AS Date), CAST(N'2023-06-16' AS Date), CAST(100 AS Decimal(18, 0)), N'Cash')
GO
INSERT [dbo].[Fee] ([FeeID], [RecordID], [PaymentDate], [PaiedDate], [Amount], [Method]) VALUES (2, 2, CAST(N'2023-06-17' AS Date), CAST(N'2023-06-17' AS Date), CAST(80 AS Decimal(18, 0)), N'Credit Card')
GO
INSERT [dbo].[Fee] ([FeeID], [RecordID], [PaymentDate], [PaiedDate], [Amount], [Method]) VALUES (3, 3, CAST(N'2023-06-18' AS Date), NULL, CAST(150 AS Decimal(18, 0)), N'Health Insurance')
GO
INSERT [dbo].[Fee] ([FeeID], [RecordID], [PaymentDate], [PaiedDate], [Amount], [Method]) VALUES (4, 4, CAST(N'2023-06-19' AS Date), NULL, CAST(2000 AS Decimal(18, 0)), N'Credit Card')
GO
INSERT [dbo].[Fee] ([FeeID], [RecordID], [PaymentDate], [PaiedDate], [Amount], [Method]) VALUES (5, 5, CAST(N'2023-06-20' AS Date), CAST(N'2023-06-20' AS Date), CAST(120 AS Decimal(18, 0)), N'Cash')
GO
SET IDENTITY_INSERT [dbo].[Fee] OFF
GO
SET IDENTITY_INSERT [dbo].[Insurance] ON 
GO
INSERT [dbo].[Insurance] ([InsuranceID], [Number], [PatientID], [Type], [Supplier], [Percent]) VALUES (1, N'INS001', 1, N'Health', N'ABC Insurance', CAST(80 AS Decimal(18, 0)))
GO
INSERT [dbo].[Insurance] ([InsuranceID], [Number], [PatientID], [Type], [Supplier], [Percent]) VALUES (2, N'INS002', 2, N'Dental', N'XYZ Insurance', CAST(50 AS Decimal(18, 0)))
GO
INSERT [dbo].[Insurance] ([InsuranceID], [Number], [PatientID], [Type], [Supplier], [Percent]) VALUES (3, N'INS003', 3, N'Health', N'ABC Insurance', CAST(70 AS Decimal(18, 0)))
GO
INSERT [dbo].[Insurance] ([InsuranceID], [Number], [PatientID], [Type], [Supplier], [Percent]) VALUES (4, N'INS004', 4, N'Vision', N'XYZ Insurance', CAST(90 AS Decimal(18, 0)))
GO
INSERT [dbo].[Insurance] ([InsuranceID], [Number], [PatientID], [Type], [Supplier], [Percent]) VALUES (5, N'INS005', 5, N'Health', N'ABC Insurance', CAST(75 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Insurance] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 
GO
INSERT [dbo].[Patient] ([PatientID], [FullName], [Gender], [DOB], [Address], [Phone], [NumberID]) VALUES (1, N'Emily Johnson', N'Female', CAST(N'1992-08-12' AS Date), N'789 Elm St', N'111-111-1111', N'123456789012345')
GO
INSERT [dbo].[Patient] ([PatientID], [FullName], [Gender], [DOB], [Address], [Phone], [NumberID]) VALUES (2, N'Michael Davis', N'Male', CAST(N'1985-06-25' AS Date), N'456 Oak St', N'222-222-2222', N'234567890123456')
GO
INSERT [dbo].[Patient] ([PatientID], [FullName], [Gender], [DOB], [Address], [Phone], [NumberID]) VALUES (3, N'Sophia Martinez', N'Female', CAST(N'1990-03-18' AS Date), N'123 Maple St', N'333-333-3333', N'345678901234567')
GO
INSERT [dbo].[Patient] ([PatientID], [FullName], [Gender], [DOB], [Address], [Phone], [NumberID]) VALUES (4, N'Daniel Thompson', N'Male', CAST(N'1988-12-05' AS Date), N'567 Pine St', N'444-444-4444', N'456789012345678')
GO
INSERT [dbo].[Patient] ([PatientID], [FullName], [Gender], [DOB], [Address], [Phone], [NumberID]) VALUES (5, N'Olivia Rodriguez', N'Female', CAST(N'1994-02-20' AS Date), N'321 Cedar St', N'555-555-5555', N'567890123456789')
GO
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 
GO
INSERT [dbo].[Payment] ([PaymentID], [InvoiceNumber], [CategoryID], [PayedDate], [BillingInformation], [Amount], [status]) VALUES (1, 1001, 1, CAST(N'2023-06-16' AS Date), N'ABC Labs', CAST(100 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[Payment] ([PaymentID], [InvoiceNumber], [CategoryID], [PayedDate], [BillingInformation], [Amount], [status]) VALUES (2, 1002, 3, CAST(N'2023-06-17' AS Date), N'XYZ Imaging', CAST(150 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[Payment] ([PaymentID], [InvoiceNumber], [CategoryID], [PayedDate], [BillingInformation], [Amount], [status]) VALUES (3, 1003, 2, NULL, N'ABC Labs', CAST(80 AS Decimal(18, 0)), 0)
GO
INSERT [dbo].[Payment] ([PaymentID], [InvoiceNumber], [CategoryID], [PayedDate], [BillingInformation], [Amount], [status]) VALUES (4, 1004, 4, NULL, N'Hospital Surgery Department', CAST(2000 AS Decimal(18, 0)), 0)
GO
INSERT [dbo].[Payment] ([PaymentID], [InvoiceNumber], [CategoryID], [PayedDate], [BillingInformation], [Amount], [status]) VALUES (5, 1005, 5, CAST(N'2023-06-20' AS Date), N'Pharmacy Inc.', CAST(120 AS Decimal(18, 0)), 1)
GO
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Record] ON 
GO
INSERT [dbo].[Record] ([RecordID], [PatientID], [ServiceID], [RecordDate], [diagnosis], [prescription], [test_result], [imaging_result]) VALUES (1, 1, 1, CAST(N'2023-06-15' AS Date), N'Fever and headache', N'Take rest and drink fluids', NULL, NULL)
GO
INSERT [dbo].[Record] ([RecordID], [PatientID], [ServiceID], [RecordDate], [diagnosis], [prescription], [test_result], [imaging_result]) VALUES (2, 2, 3, CAST(N'2023-06-16' AS Date), N'High cholesterol', N'Prescribed statins', N'Normal', NULL)
GO
INSERT [dbo].[Record] ([RecordID], [PatientID], [ServiceID], [RecordDate], [diagnosis], [prescription], [test_result], [imaging_result]) VALUES (3, 3, 2, CAST(N'2023-06-17' AS Date), N'Suspected fracture', N'Referred to orthopedic specialist', NULL, N'Fracture confirmed on X-ray')
GO
INSERT [dbo].[Record] ([RecordID], [PatientID], [ServiceID], [RecordDate], [diagnosis], [prescription], [test_result], [imaging_result]) VALUES (4, 4, 4, CAST(N'2023-06-18' AS Date), N'Appendicitis', N'Emergency appendectomy required', NULL, NULL)
GO
INSERT [dbo].[Record] ([RecordID], [PatientID], [ServiceID], [RecordDate], [diagnosis], [prescription], [test_result], [imaging_result]) VALUES (5, 5, 5, CAST(N'2023-06-19' AS Date), N'Muscle strain', N'Prescribed physical therapy', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Record] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 
GO
INSERT [dbo].[Service] ([ServiceID], [Name], [Type], [Fee]) VALUES (1, N'General Examination', N'Examination', CAST(100.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Service] ([ServiceID], [Name], [Type], [Fee]) VALUES (2, N'X-Ray', N'Imaging', CAST(150.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Service] ([ServiceID], [Name], [Type], [Fee]) VALUES (3, N'Blood Test', N'Test', CAST(80.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Service] ([ServiceID], [Name], [Type], [Fee]) VALUES (4, N'Appendectomy', N'Surgery', CAST(2000.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Service] ([ServiceID], [Name], [Type], [Fee]) VALUES (5, N'Physical Therapy', N'Treatment', CAST(120.00 AS Decimal(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Employee__C9F28456166F020E]    Script Date: 11-Jul-23 2:19:30 PM ******/
ALTER TABLE [dbo].[Employee] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Fee]  WITH CHECK ADD FOREIGN KEY([RecordID])
REFERENCES [dbo].[Record] ([RecordID])
GO
ALTER TABLE [dbo].[Insurance]  WITH CHECK ADD FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Record]  WITH CHECK ADD FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[Record]  WITH CHECK ADD FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD CHECK  (([Gender]='Female' OR [Gender]='Male'))
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD CHECK  (([Role]='Staff' OR [Role]='Admin'))
GO
ALTER TABLE [dbo].[Fee]  WITH CHECK ADD CHECK  (([Method]='Other' OR [Method]='Health Insurance' OR [Method]='Credit Card' OR [Method]='Cash'))
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD CHECK  (([Gender]='Female' OR [Gender]='Male'))
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD CHECK  (([Type]='Other' OR [Type]='EEG' OR [Type]='ECG' OR [Type]='Imaging' OR [Type]='Test' OR [Type]='Medicine' OR [Type]='Surgery' OR [Type]='Treatment' OR [Type]='Diagnosis' OR [Type]='Examination'))
GO
USE [master]
GO
ALTER DATABASE [MyStore] SET  READ_WRITE 
GO
