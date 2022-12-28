USE [PersonelDb]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 28.12.2022 11:34:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[PaymentDescription] [nvarchar](50) NULL,
	[PaymentAmount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personel]    Script Date: 28.12.2022 11:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[TCKN] [nvarchar](11) NULL,
	[Gsm] [nvarchar](12) NULL,
	[Email] [nvarchar](50) NULL,
	[PermissionDays] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Personel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonelCategory]    Script Date: 28.12.2022 11:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonelCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CategoryName] [nvarchar](50) NULL,
	[WeeklyWorkTime] [int] NULL,
 CONSTRAINT [PK_PersonelCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonelPermission]    Script Date: 28.12.2022 11:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonelPermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[PermissionHour] [int] NULL,
	[Description] [nvarchar](150) NULL,
 CONSTRAINT [PK_PersonelPermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 28.12.2022 11:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seizures]    Script Date: 28.12.2022 11:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seizures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[seizuresDate] [datetime] NULL,
	[seizuresStartDate] [time](7) NULL,
	[seizuresEndDate] [time](7) NULL,
	[Location] [nvarchar](100) NULL,
 CONSTRAINT [PK_Seizures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 28.12.2022 11:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([Id], [UserId], [PaymentDescription], [PaymentAmount]) VALUES (1, 1, N'Fazla Mesai', CAST(160.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[Personel] ON 

INSERT [dbo].[Personel] ([Id], [Name], [Surname], [TCKN], [Gsm], [Email], [PermissionDays], [Title], [Username], [Password]) VALUES (1, N'Ali', N'Veli', N'11111111', N'53484547852', N'ali@gmail.com', N'Pazartesi,Pazar', N'Memur1', N'm', N'1')
INSERT [dbo].[Personel] ([Id], [Name], [Surname], [TCKN], [Gsm], [Email], [PermissionDays], [Title], [Username], [Password]) VALUES (2, N'Veli', N'Ali', N'22222222', N'5354585412', N'veli@gmail.com', N'Perşembe', N'İşçi2', N'v', N'1')
INSERT [dbo].[Personel] ([Id], [Name], [Surname], [TCKN], [Gsm], [Email], [PermissionDays], [Title], [Username], [Password]) VALUES (3, N'Ahmet', N'Aktaş', N'33333333', N'5354585412', N'ahmet@gmail.com', N'Çarşamba', N'işçi3', N'a', N'1')
INSERT [dbo].[Personel] ([Id], [Name], [Surname], [TCKN], [Gsm], [Email], [PermissionDays], [Title], [Username], [Password]) VALUES (4, N'Ömer', N'Çetin', N'44444444', N'5354585412', N'omer@gmail.com', N'Salı', N'işçi4', N'ö', N'1')
INSERT [dbo].[Personel] ([Id], [Name], [Surname], [TCKN], [Gsm], [Email], [PermissionDays], [Title], [Username], [Password]) VALUES (5, N'Faruk', N'Kaya', N'55555555', N'5354585412', N'faruk@gmail.com', N'Cuma,Salı', N'Memur2', N'f', N'1')
SET IDENTITY_INSERT [dbo].[Personel] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonelCategory] ON 

INSERT [dbo].[PersonelCategory] ([Id], [UserId], [CategoryName], [WeeklyWorkTime]) VALUES (1, 1, N'Memur', 40)
INSERT [dbo].[PersonelCategory] ([Id], [UserId], [CategoryName], [WeeklyWorkTime]) VALUES (2, 2, N'İşçi', 45)
SET IDENTITY_INSERT [dbo].[PersonelCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonelPermission] ON 

INSERT [dbo].[PersonelPermission] ([Id], [UserId], [PermissionHour], [Description]) VALUES (1, 1, 8, N'Fazla Mesai')
SET IDENTITY_INSERT [dbo].[PersonelPermission] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Id], [RoleName]) VALUES (2, N'Personel')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Seizures] ON 

INSERT [dbo].[Seizures] ([Id], [UserId], [seizuresDate], [seizuresStartDate], [seizuresEndDate], [Location]) VALUES (1, 1, CAST(N'2022-12-25T15:53:00.000' AS DateTime), CAST(N'00:00:00' AS Time), CAST(N'08:00:00' AS Time), NULL)
INSERT [dbo].[Seizures] ([Id], [UserId], [seizuresDate], [seizuresStartDate], [seizuresEndDate], [Location]) VALUES (2, 1, CAST(N'2022-12-25T15:53:00.000' AS DateTime), CAST(N'08:00:00' AS Time), CAST(N'16:00:00' AS Time), NULL)
INSERT [dbo].[Seizures] ([Id], [UserId], [seizuresDate], [seizuresStartDate], [seizuresEndDate], [Location]) VALUES (3, 1, CAST(N'2022-12-28T15:53:00.000' AS DateTime), CAST(N'00:00:00' AS Time), CAST(N'08:00:00' AS Time), N'Kampüs İçi')
INSERT [dbo].[Seizures] ([Id], [UserId], [seizuresDate], [seizuresStartDate], [seizuresEndDate], [Location]) VALUES (4, 2, CAST(N'2022-12-28T15:53:00.000' AS DateTime), CAST(N'08:00:00' AS Time), CAST(N'16:00:00' AS Time), N'Kampüs İçi')
INSERT [dbo].[Seizures] ([Id], [UserId], [seizuresDate], [seizuresStartDate], [seizuresEndDate], [Location]) VALUES (5, 1, CAST(N'2022-12-25T15:53:00.000' AS DateTime), CAST(N'09:00:00' AS Time), CAST(N'17:00:00' AS Time), N'Kampüs İçi')
SET IDENTITY_INSERT [dbo].[Seizures] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (1, 1, 1)
INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (2, 2, 2)
INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (3, 3, 2)
INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (4, 4, 2)
INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (5, 5, 1)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Personel] FOREIGN KEY([UserId])
REFERENCES [dbo].[Personel] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Personel]
GO
ALTER TABLE [dbo].[PersonelCategory]  WITH CHECK ADD  CONSTRAINT [FK_PersonelCategory_Personel] FOREIGN KEY([UserId])
REFERENCES [dbo].[Personel] ([Id])
GO
ALTER TABLE [dbo].[PersonelCategory] CHECK CONSTRAINT [FK_PersonelCategory_Personel]
GO
ALTER TABLE [dbo].[PersonelPermission]  WITH CHECK ADD  CONSTRAINT [FK_PersonelPermission_Personel] FOREIGN KEY([UserId])
REFERENCES [dbo].[Personel] ([Id])
GO
ALTER TABLE [dbo].[PersonelPermission] CHECK CONSTRAINT [FK_PersonelPermission_Personel]
GO
ALTER TABLE [dbo].[Seizures]  WITH CHECK ADD  CONSTRAINT [FK_Seizures_Personel] FOREIGN KEY([UserId])
REFERENCES [dbo].[Personel] ([Id])
GO
ALTER TABLE [dbo].[Seizures] CHECK CONSTRAINT [FK_Seizures_Personel]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Personel] FOREIGN KEY([UserId])
REFERENCES [dbo].[Personel] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Personel]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Role]
GO
