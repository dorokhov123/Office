USE [master]
GO
/****** Object:  Database [Dorokhov]    Script Date: 28.11.2019 5:18:49 ******/
CREATE DATABASE [Dorokhov]
 CONTAINMENT = NONE
 COLLATE Cyrillic_General_CS_AS
GO
ALTER DATABASE [Dorokhov] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dorokhov].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dorokhov] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dorokhov] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dorokhov] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dorokhov] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dorokhov] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dorokhov] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dorokhov] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dorokhov] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dorokhov] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dorokhov] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dorokhov] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dorokhov] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dorokhov] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dorokhov] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dorokhov] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dorokhov] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dorokhov] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dorokhov] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dorokhov] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dorokhov] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dorokhov] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dorokhov] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dorokhov] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Dorokhov] SET  MULTI_USER 
GO
ALTER DATABASE [Dorokhov] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dorokhov] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dorokhov] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dorokhov] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Dorokhov] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Dorokhov] SET QUERY_STORE = OFF
GO
USE [Dorokhov]
GO
/****** Object:  Table [dbo].[Accounting]    Script Date: 28.11.2019 5:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounting](
	[IdAccounting] [int] IDENTITY(1,1) NOT NULL,
	[IdEmployee] [int] NOT NULL,
	[CodeEquipment] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
	[NumberOfRoom] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
	[DateOfRegistration] [date] NOT NULL,
 CONSTRAINT [PK_Accounting] PRIMARY KEY CLUSTERED 
(
	[IdAccounting] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 28.11.2019 5:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[IdBrand] [int] IDENTITY(1,1) NOT NULL,
	[NameBrand] [nchar](10) COLLATE Cyrillic_General_CS_AS NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[IdBrand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 28.11.2019 5:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[IdEmployee] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
	[Name] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
	[Patronymic] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
	[RoomOfEmployee] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
	[PhoneNumber] [nvarchar](17) COLLATE Cyrillic_General_CS_AS NOT NULL,
	[IdPost] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[IdEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 28.11.2019 5:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[CodeEquipment] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
	[IdModel] [int] NOT NULL,
	[DeliveryDate] [date] NOT NULL,
	[WriteOffDate] [date] NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[CodeEquipment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Model]    Script Date: 28.11.2019 5:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Model](
	[IdModel] [int] IDENTITY(1,1) NOT NULL,
	[IdBrand] [int] NOT NULL,
	[NameModel] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[IdModel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 28.11.2019 5:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[IdPost] [int] IDENTITY(1,1) NOT NULL,
	[NameOfPost] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[IdPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repair]    Script Date: 28.11.2019 5:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repair](
	[IdRepair] [int] IDENTITY(1,1) NOT NULL,
	[IdEmployee] [int] NOT NULL,
	[CodeEquipment] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
	[Reason] [text] COLLATE Cyrillic_General_CS_AS NOT NULL,
	[Cost] [money] NOT NULL,
 CONSTRAINT [PK_Repair] PRIMARY KEY CLUSTERED 
(
	[IdRepair] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 28.11.2019 5:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[NumberOfRoom] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[NumberOfRoom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 28.11.2019 5:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Login] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE Cyrillic_General_CS_AS NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounting] ON 

INSERT [dbo].[Accounting] ([IdAccounting], [IdEmployee], [CodeEquipment], [NumberOfRoom], [DateOfRegistration]) VALUES (1, 1, N'3213213', N'1', CAST(N'2019-08-21' AS Date))
SET IDENTITY_INSERT [dbo].[Accounting] OFF
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([IdBrand], [NameBrand]) VALUES (1, N'Canon     ')
SET IDENTITY_INSERT [dbo].[Brand] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([IdEmployee], [Surname], [Name], [Patronymic], [RoomOfEmployee], [PhoneNumber], [IdPost]) VALUES (1, N'Петров', N'Петя', N'ва', N'1', N'34567', 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
INSERT [dbo].[Equipment] ([CodeEquipment], [IdModel], [DeliveryDate], [WriteOffDate]) VALUES (N'3213213', 1, CAST(N'2019-08-29' AS Date), CAST(N'2019-08-31' AS Date))
SET IDENTITY_INSERT [dbo].[Model] ON 

INSERT [dbo].[Model] ([IdModel], [IdBrand], [NameModel]) VALUES (1, 1, N'Laserjet 2898')
SET IDENTITY_INSERT [dbo].[Model] OFF
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([IdPost], [NameOfPost]) VALUES (1, N'Техник')
SET IDENTITY_INSERT [dbo].[Post] OFF
SET IDENTITY_INSERT [dbo].[Repair] ON 

INSERT [dbo].[Repair] ([IdRepair], [IdEmployee], [CodeEquipment], [Reason], [Cost]) VALUES (1, 1, N'3213213', N'ыфв', 2323.0000)
SET IDENTITY_INSERT [dbo].[Repair] OFF
INSERT [dbo].[Room] ([NumberOfRoom]) VALUES (N'1')
INSERT [dbo].[User] ([Login], [Password]) VALUES (N'1', N'1')
ALTER TABLE [dbo].[Accounting]  WITH CHECK ADD  CONSTRAINT [FK_Accounting_Employee] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([IdEmployee])
GO
ALTER TABLE [dbo].[Accounting] CHECK CONSTRAINT [FK_Accounting_Employee]
GO
ALTER TABLE [dbo].[Accounting]  WITH CHECK ADD  CONSTRAINT [FK_Accounting_Equipment] FOREIGN KEY([CodeEquipment])
REFERENCES [dbo].[Equipment] ([CodeEquipment])
GO
ALTER TABLE [dbo].[Accounting] CHECK CONSTRAINT [FK_Accounting_Equipment]
GO
ALTER TABLE [dbo].[Accounting]  WITH CHECK ADD  CONSTRAINT [FK_Accounting_Room] FOREIGN KEY([NumberOfRoom])
REFERENCES [dbo].[Room] ([NumberOfRoom])
GO
ALTER TABLE [dbo].[Accounting] CHECK CONSTRAINT [FK_Accounting_Room]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Post] FOREIGN KEY([IdPost])
REFERENCES [dbo].[Post] ([IdPost])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Post]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Room] FOREIGN KEY([RoomOfEmployee])
REFERENCES [dbo].[Room] ([NumberOfRoom])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Room]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_Model] FOREIGN KEY([IdModel])
REFERENCES [dbo].[Model] ([IdModel])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_Model]
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Model_Brand] FOREIGN KEY([IdBrand])
REFERENCES [dbo].[Brand] ([IdBrand])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Model_Brand]
GO
ALTER TABLE [dbo].[Repair]  WITH CHECK ADD  CONSTRAINT [FK_Repair_Employee] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([IdEmployee])
GO
ALTER TABLE [dbo].[Repair] CHECK CONSTRAINT [FK_Repair_Employee]
GO
ALTER TABLE [dbo].[Repair]  WITH CHECK ADD  CONSTRAINT [FK_Repair_Equipment] FOREIGN KEY([CodeEquipment])
REFERENCES [dbo].[Equipment] ([CodeEquipment])
GO
ALTER TABLE [dbo].[Repair] CHECK CONSTRAINT [FK_Repair_Equipment]
GO
USE [master]
GO
ALTER DATABASE [Dorokhov] SET  READ_WRITE 
GO
