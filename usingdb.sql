USE [master]
GO
/****** Object:  Database [MyStore]    Script Date: 10/26/2022 8:38:04 PM ******/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'MyStore')
BEGIN
	ALTER DATABASE [MyStore] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [MyStore] SET ONLINE;
	DROP DATABASE [MyStore];
END
GO
CREATE DATABASE [MyStore]
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
EXEC sys.sp_db_vardecimal_storage_format N'MyStore', N'ON'
GO
ALTER DATABASE [MyStore] SET QUERY_STORE = OFF
GO
USE [MyStore]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Staff] (
  [StaffID] [INT] IDENTITY(1,1) NOT NULL,
  [UserName] [NVARCHAR](15) NOT NULL UNIQUE,
  [Password] [NVARCHAR](20) NOT NULL,
  [Email] [NVARCHAR](100) NOT NULL,
  [FullName] [NVARCHAR](50),
  [Gender] NVARCHAR(10) CHECK (Gender IN ('Male', 'Female')),
  [DOB] [Date] NOT NULL,
  [Address] [NVARCHAR](100),
  [Phone] [NVARCHAR](12),
  [NumberID] [NVARCHAR](15) NOT NULL,
  [Role] NVARCHAR(40) CHECK ([Role] IN ('Admin', 'Staff')),
CONSTRAINT [PK_staff] PRIMARY KEY CLUSTERED
    (
        [StaffID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient] (
  [PatientID] [INT] IDENTITY(1,1) NOT NULL,
  [FullName] [NVARCHAR](50),
  [Gender] NVARCHAR(10) CHECK ([Gender] IN ('Male', 'Female')),
  [DOB] [Date] NOT NULL,
  [Address] [NVARCHAR](100),
  [Phone] [NVARCHAR](12),
  [NumberID] [NVARCHAR](15) NOT NULL,
CONSTRAINT [PK_patient] PRIMARY KEY CLUSTERED
    (
        [PatientID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service] (
  [ServiceID] [INT] IDENTITY(1,1) NOT NULL,
  [Name] [NVARCHAR](100),
  [Type] NVARCHAR(40) CHECK ([Type] IN ('Examination', 'Diagnosis', 'Treatment', 'Surgery', 'Medicine', 'Test', 'Imaging', 'ECG', 'EEG', 'Other')),
  [Fee] DECIMAL(10, 2)
CONSTRAINT [PK_service] PRIMARY KEY CLUSTERED
    (
        [ServiceID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Record] (
  [RecordID] [INT] IDENTITY(1,1) NOT NULL,
  [PatientID] [INT] NOT NULL,
  [ServiceID] [INT] NOT NULL,
  [RecordDate] [Date] NOT NULL,
  [diagnosis] TEXT,
  [prescription] TEXT,
  [test_result] TEXT,
  [imaging_result] TEXT,
CONSTRAINT [PK_record] PRIMARY KEY CLUSTERED
    (
        [RecordID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fee] (
  [FeeID] [INT] IDENTITY(1,1) NOT NULL,
  [RecordID] [INT] NOT NULL,
  [PaymentDate] DATE,
  [PaiedDate] DATE,
  [Amount] [DECIMAL] NOT NULL,
  [Method] NVARCHAR(20) CHECK ([Method] IN ('Cash', 'Credit Card', 'Health Insurance', 'Other')),
 CONSTRAINT [PK_fee] PRIMARY KEY CLUSTERED
    (
	    [FeeID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category] (
  [CategoryID] [INT] IDENTITY(1,1) NOT NULL,
  [CategoryName] [NVARCHAR](20) NOT NULL,
  [Description] [NVARCHAR](100) NOT NULL,
CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED
    (
        [CategoryID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment] (
  [PaymentID] [INT] IDENTITY(1,1) NOT NULL,
  [InvoiceNumber] [INT] NOT NULL,
  [CategoryID] [INT] NOT NULL,
  [RequiredDate] DATE,
  [PayedDate] DATE,
  [Partner] [NVARCHAR](100), 
  [DepartmentID] [INT], 
  [Amount] [DECIMAL] NOT NULL,
  [status] [BIT],
 CONSTRAINT [PK_payment] PRIMARY KEY CLUSTERED
    (
	    [PaymentID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insurance] (
  [InsuranceID] [INT] IDENTITY(1,1) NOT NULL,
  [Number] [NVARCHAR](10) NOT NULL,
  [PatientID] [INT] NOT NULL,
  [Type] [NVARCHAR](50) NOT NULL,
  [Supplier] [NVARCHAR](100) NOT NULL,
  [Percent] [DECIMAL] NOT NULL,
  CONSTRAINT [PK_insurance] PRIMARY KEY CLUSTERED
    (
	    [InsuranceID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



ALTER TABLE [dbo].[Record]  WITH CHECK ADD FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])


ALTER TABLE [dbo].[Record]  WITH CHECK ADD FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])


ALTER TABLE [dbo].[Fee]  WITH CHECK ADD FOREIGN KEY([RecordID])
REFERENCES [dbo].[Record] ([RecordID])




ALTER TABLE [dbo].[Insurance]  WITH CHECK ADD FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO

ALTER TABLE [dbo].[Payment]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO

INSERT INTO [dbo].[Staff] ([UserName], [Password], [Email], [FullName], [Gender], [DOB], [Address], [Phone], [NumberID], [Role])
VALUES
  ('duy', '123', 'john@example.com', 'John Smith', 'Male', '1990-05-15', '123 Main St', '123-456-7890', '1234567890', 'Staff'),
  ('johnsmith', 'password1', 'john@example.com', 'John Smith', 'Male', '1990-05-15', '123 Main St', '123-456-7890', '1234567890', 'Admin'),
  ('janedoe', 'password2', 'jane@example.com', 'Jane Doe', 'Female', '1988-10-20', '456 Elm St', '987-654-3210', '0987654321', 'Staff'),
  ('mikesmith', 'password3', 'mike@example.com', 'Mike Smith', 'Male', '1992-03-25', '789 Oak St', '555-555-5555', '9876543210', 'Staff'),
  ('sarahjones', 'password4', 'sarah@example.com', 'Sarah Jones', 'Female', '1995-07-08', '321 Pine St', '111-222-3333', '0123456789', 'Staff'),
  ('markwilson', 'password5', 'mark@example.com', 'Mark Wilson', 'Male', '1991-12-01', '567 Maple St', '444-444-4444', '5678901234', 'Staff');

INSERT INTO [dbo].[Patient] ([FullName], [Gender], [DOB], [Address], [Phone], [NumberID])
VALUES
  ('Emily Johnson', 'Female', '1992-08-12', '789 Elm St', '111-111-1111', '123456789012345'),
  ('Michael Davis', 'Male', '1985-06-25', '456 Oak St', '222-222-2222', '234567890123456'),
  ('Sophia Martinez', 'Female', '1990-03-18', '123 Maple St', '333-333-3333', '345678901234567'),
  ('Daniel Thompson', 'Male', '1988-12-05', '567 Pine St', '444-444-4444', '456789012345678'),
  ('Olivia Rodriguez', 'Female', '1994-02-20', '321 Cedar St', '555-555-5555', '567890123456789');

INSERT INTO [dbo].[Service] ([Name], [Type], [Fee])
VALUES
  ('General Examination', 'Examination', 100.00),
  ('X-Ray', 'Imaging', 150.00),
  ('Blood Test', 'Test', 80.00),
  ('Appendectomy', 'Surgery', 2000.00),
  ('Physical Therapy', 'Treatment', 120.00);

INSERT INTO [dbo].[Record] ([PatientID], [ServiceID], [RecordDate], [diagnosis], [prescription], [test_result], [imaging_result])
VALUES
  (1, 1, '2023-06-15', 'Fever and headache', 'Take rest and drink fluids', NULL, NULL),
  (2, 3, '2023-06-16', 'High cholesterol', 'Prescribed statins', 'Normal', NULL),
  (3, 2, '2023-06-17', 'Suspected fracture', 'Referred to orthopedic specialist', NULL, 'Fracture confirmed on X-ray'),
  (4, 4, '2023-06-18', 'Appendicitis', 'Emergency appendectomy required', NULL, NULL),
  (5, 5, '2023-06-19', 'Muscle strain', 'Prescribed physical therapy', NULL, NULL);

INSERT INTO [dbo].[Fee] ([RecordID], [PaymentDate], [PaiedDate], [Amount], [Method])
VALUES
  (1, '2023-06-16', '2023-06-16', 100.00, 'Cash'),
  (2, '2023-06-17', '2023-06-17', 80.00, 'Credit Card'),
  (3, '2023-06-18', NULL, 150.00, 'Health Insurance'),
  (4, '2023-06-19', NULL, 2000.00, 'Credit Card'),
  (5, '2023-06-20', '2023-06-20', 120.00, 'Cash');

INSERT INTO [dbo].[Category] ([CategoryName], [Description])
VALUES
  ('Laboratory', 'Laboratory tests'),
  ('Radiology', 'Radiology services'),
  ('Surgery', 'Surgical procedures'),
  ('Therapy', 'Physical therapy'),
  ('Pharmacy', 'Medication and pharmacy services');

INSERT INTO [dbo].[Payment] ([InvoiceNumber], [CategoryID], [RequiredDate], [PayedDate], [Partner], [DepartmentID], [Amount], [status])
VALUES
  (1001, 1, '2023-06-15', '2023-06-16', 'ABC Labs', NULL, 100.00, 1),
  (1002, 3, '2023-06-16', '2023-06-17', 'XYZ Imaging', NULL, 150.00, 1),
  (1003, 2, '2023-06-17', NULL, 'ABC Labs', NULL, 80.00, 0),
  (1004, 4, '2023-06-18', NULL, 'Hospital Surgery Department', 1, 2000.00, 0),
  (1005, 5, '2023-06-19', '2023-06-20', 'Pharmacy Inc.', NULL, 120.00, 1);

INSERT INTO [dbo].[Insurance] ([Number], [PatientID], [Type], [Supplier], [Percent])
VALUES
  ('INS001', 1, 'Health', 'ABC Insurance', 80.00),
  ('INS002', 2, 'Dental', 'XYZ Insurance', 50.00),
  ('INS003', 3, 'Health', 'ABC Insurance', 70.00),
  ('INS004', 4, 'Vision', 'XYZ Insurance', 90.00),
  ('INS005', 5, 'Health', 'ABC Insurance', 75.00);


USE [master]
GO
ALTER DATABASE [MyStore] SET  READ_WRITE 
GO




