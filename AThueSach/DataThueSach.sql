USE [master]
GO
/****** Object:  Database [DataThueSach]    Script Date: 7/23/2023 12:07:39 PM ******/
CREATE DATABASE [DataThueSach]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataThueSach', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DataThueSach.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DataThueSach_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DataThueSach_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DataThueSach] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataThueSach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataThueSach] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataThueSach] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataThueSach] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataThueSach] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataThueSach] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataThueSach] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DataThueSach] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataThueSach] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataThueSach] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataThueSach] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataThueSach] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataThueSach] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataThueSach] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataThueSach] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataThueSach] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DataThueSach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataThueSach] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataThueSach] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataThueSach] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataThueSach] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataThueSach] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DataThueSach] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataThueSach] SET RECOVERY FULL 
GO
ALTER DATABASE [DataThueSach] SET  MULTI_USER 
GO
ALTER DATABASE [DataThueSach] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataThueSach] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataThueSach] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataThueSach] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DataThueSach] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DataThueSach] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DataThueSach', N'ON'
GO
ALTER DATABASE [DataThueSach] SET QUERY_STORE = ON
GO
ALTER DATABASE [DataThueSach] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DataThueSach]
GO
/****** Object:  Table [dbo].[AdminUser]    Script Date: 7/23/2023 12:07:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IDNV] [nvarchar](20) NOT NULL,
	[NameNV] [nvarchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/23/2023 12:07:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IDCate] [nvarchar](20) NOT NULL,
	[NameCate] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/23/2023 12:07:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[IDCus] [int] IDENTITY(1,1) NOT NULL,
	[NameCus] [nvarchar](500) NULL,
	[AccountCus] [nvarchar](250) NULL,
	[PassCus] [nvarchar](250) NULL,
	[Gender] [bit] NULL,
	[PhoneCus] [nvarchar](15) NULL,
	[EmailCus] [nvarchar](250) NULL,
	[Address] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 7/23/2023 12:07:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDProduct] [int] NULL,
	[NamePro] [nvarchar](max) NULL,
	[IDOrder] [int] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderPro]    Script Date: 7/23/2023 12:07:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderPro](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateOrder] [date] NULL,
	[IDCus] [int] NULL,
	[NameCus] [nvarchar](250) NULL,
	[PhoneCus] [nvarchar](15) NULL,
	[DatePay] [date] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/23/2023 12:07:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[NamePro] [nvarchar](max) NULL,
	[DecriptionPro] [nvarchar](max) NULL,
	[Category] [nvarchar](20) NULL,
	[Price] [decimal](19, 4) NULL,
	[PriceHire] [decimal](19, 4) NULL,
	[ImagePro] [nvarchar](max) NULL,
	[Quantity] [int] NULL,
	[Status] [nvarchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AdminUser] ON 

INSERT [dbo].[AdminUser] ([Id], [IDNV], [NameNV], [Username], [Password], [Department]) VALUES (1, N'NV01', N'Nhi', N'NV01_N', N'123', N'Quản lý')
INSERT [dbo].[AdminUser] ([Id], [IDNV], [NameNV], [Username], [Password], [Department]) VALUES (2, N'NV02', N'Yến', N'NV02_Y', N'123', N'Nhân viên')
SET IDENTITY_INSERT [dbo].[AdminUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [IDCate], [NameCate]) VALUES (1, N'MDS01', N'Cây Cam Ngọt Của Tôi')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([ID], [IDProduct], [NamePro], [IDOrder], [Quantity], [UnitPrice]) VALUES (9, 2, N'Hành Tinh Của Một Kẻ Nghĩ Nhiều', 10, 1, 68800)
INSERT [dbo].[OrderDetail] ([ID], [IDProduct], [NamePro], [IDOrder], [Quantity], [UnitPrice]) VALUES (10, 2, N'Hành Tinh Của Một Kẻ Nghĩ Nhiều', 11, 1, 68800)
INSERT [dbo].[OrderDetail] ([ID], [IDProduct], [NamePro], [IDOrder], [Quantity], [UnitPrice]) VALUES (11, 1, N'Cây Cam Ngọt Của Tôi', 12, 1, 75600)
INSERT [dbo].[OrderDetail] ([ID], [IDProduct], [NamePro], [IDOrder], [Quantity], [UnitPrice]) VALUES (12, 2, N'Hành Tinh Của Một Kẻ Nghĩ Nhiều', 13, 3, 68800)
INSERT [dbo].[OrderDetail] ([ID], [IDProduct], [NamePro], [IDOrder], [Quantity], [UnitPrice]) VALUES (13, 2, N'Hành Tinh Của Một Kẻ Nghĩ Nhiều', 15, 1, 68800)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderPro] ON 

INSERT [dbo].[OrderPro] ([ID], [DateOrder], [IDCus], [NameCus], [PhoneCus], [DatePay], [Status]) VALUES (10, CAST(N'2023-07-23' AS Date), NULL, N'Quyễn Lam', N'0342240544', NULL, 1)
INSERT [dbo].[OrderPro] ([ID], [DateOrder], [IDCus], [NameCus], [PhoneCus], [DatePay], [Status]) VALUES (11, CAST(N'2023-07-23' AS Date), NULL, N'Cam Cam', N'0342240544', NULL, 1)
INSERT [dbo].[OrderPro] ([ID], [DateOrder], [IDCus], [NameCus], [PhoneCus], [DatePay], [Status]) VALUES (12, CAST(N'2023-07-23' AS Date), NULL, N'Tuyết Nhi', N'0342240544', NULL, 1)
INSERT [dbo].[OrderPro] ([ID], [DateOrder], [IDCus], [NameCus], [PhoneCus], [DatePay], [Status]) VALUES (13, CAST(N'2023-07-23' AS Date), NULL, N'Cam Cam', N'0342240544', NULL, 1)
INSERT [dbo].[OrderPro] ([ID], [DateOrder], [IDCus], [NameCus], [PhoneCus], [DatePay], [Status]) VALUES (14, CAST(N'2023-07-23' AS Date), NULL, N'Cam Cam', N'0342240544', NULL, 1)
INSERT [dbo].[OrderPro] ([ID], [DateOrder], [IDCus], [NameCus], [PhoneCus], [DatePay], [Status]) VALUES (15, CAST(N'2023-07-23' AS Date), NULL, N'Cam Cam', N'0342240544', NULL, 1)
SET IDENTITY_INSERT [dbo].[OrderPro] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [PriceHire], [ImagePro], [Quantity], [Status]) VALUES (1, N'Cây Cam Ngọt Của Tôi', N'Có hề gì đâu bao nhiêu là hắt hủi, đánh mắng, vì Zezé đã có một người bạn đặc biệt để trút nỗi lòng: cây cam ngọt nơi vườn sau. Và cả một người bạn nữa, bằng xương bằng thịt, một ngày kia xuất hiện, cho cậu bé nhạy cảm khôn sớm biết thế nào là trìu mến, thế nào là nỗi đau, và mãi mãi thay đổi cuộc đời cậu.', N'MDS01', CAST(75600.0000 AS Decimal(19, 4)), CAST(38000.0000 AS Decimal(19, 4)), N'5.jpg', 14, NULL)
INSERT [dbo].[Products] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [PriceHire], [ImagePro], [Quantity], [Status]) VALUES (2, N'Hành Tinh Của Một Kẻ Nghĩ Nhiều', N'Hành tinh của một kẻ nghĩ nhiều là hành trình khám phá thế giới nội tâm của một người trẻ. Đó là một hành tinh đầy hỗn loạn của những suy nghĩ trăn trở, những dằn vặt, những cuộc chiến nội tâm, những cảm xúc vừa phức tạp cũng vừa rất đỗi con người. Một thế giới quen thuộc với tất cả chúng ta. ', N'MDS01', CAST(68800.0000 AS Decimal(19, 4)), CAST(34000.0000 AS Decimal(19, 4)), N'6.jpg', 11, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([IDOrder])
REFERENCES [dbo].[OrderPro] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([IDProduct])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[OrderPro]  WITH CHECK ADD FOREIGN KEY([IDCus])
REFERENCES [dbo].[Customer] ([IDCus])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Pro_Category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([IDCate])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Pro_Category]
GO
USE [master]
GO
ALTER DATABASE [DataThueSach] SET  READ_WRITE 
GO
