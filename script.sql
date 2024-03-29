USE [SuSatis]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10.11.2019 22:33:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10.11.2019 22:33:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[price] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [Phone], [Address], [CreateDate]) VALUES (1, N'Nagihan', N'Ballıoğlu', N'(535) 559-6547', N'Güneşli', CAST(N'2019-11-09T15:51:02.887' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [Phone], [Address], [CreateDate]) VALUES (2, N'Kaan', N'Demirci', N'(534) 654-9514', N'Bahçelievler', CAST(N'2019-11-09T15:57:37.197' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [Phone], [Address], [CreateDate]) VALUES (3, N'Ahmet', N'Kanlıca', N'(547) 852-1212', N'Bakırköy', CAST(N'2019-11-09T16:29:38.617' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [Phone], [Address], [CreateDate]) VALUES (4, N'Burcu', N'Yıldırım', N'(212) 446-5923', N'Demirkapı', CAST(N'2019-11-09T16:59:10.363' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [Phone], [Address], [CreateDate]) VALUES (5, N'Elif', N'Kuzey', N'(545) 625-1414', N'Beşiktaş', CAST(N'2019-11-09T20:47:03.073' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [Phone], [Address], [CreateDate]) VALUES (9, N'ali', N'yılmaz', N'(555) 555-5555', N'esenleer', CAST(N'2019-11-10T17:25:10.987' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Status], [price], [CreateDate]) VALUES (7, 1, N'Teslim Edildi', N'15', CAST(N'2019-11-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Status], [price], [CreateDate]) VALUES (8, 2, N'Yola Çıktı', N'15', CAST(N'2019-11-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Status], [price], [CreateDate]) VALUES (10, 1, N'Hazırlanıyor', N'15', CAST(N'2019-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Status], [price], [CreateDate]) VALUES (11, 2, N'Teslim Edildi', N'15', CAST(N'2019-11-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Status], [price], [CreateDate]) VALUES (12, 3, N'Teslim Edildi', N'15', CAST(N'2019-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Status], [price], [CreateDate]) VALUES (13, 3, N'Yola Çıktı', N'15', CAST(N'2019-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Status], [price], [CreateDate]) VALUES (14, 4, N'Teslim Edildi', N'30', CAST(N'2019-11-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Status], [price], [CreateDate]) VALUES (15, 5, N'Yola Çıktı', N'45', CAST(N'2019-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Status], [price], [CreateDate]) VALUES (25, 9, N'Yola Çıktı', N'15', CAST(N'2019-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Status], [price], [CreateDate]) VALUES (26, 1, N'Teslim Edildi', N'15', CAST(N'2019-11-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Orders] OFF
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
