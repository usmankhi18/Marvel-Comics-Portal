USE [Marvel]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 6/16/2020 3:16:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ImageUrl] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 6/16/2020 3:16:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMaster](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RoleMaster] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 6/16/2020 3:16:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/16/2020 3:16:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[MobileNo] [varchar](11) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Country] [varchar](100) NOT NULL,
	[RoleID] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[AddedBy] [int] NOT NULL,
	[AddedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RoleMaster] ON 
GO
INSERT [dbo].[RoleMaster] ([RoleID], [Role]) VALUES (1, N'admin')
GO
INSERT [dbo].[RoleMaster] ([RoleID], [Role]) VALUES (2, N'user')
GO
SET IDENTITY_INSERT [dbo].[RoleMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 
GO
INSERT [dbo].[Status] ([StatusID], [Status]) VALUES (1, N'Pending')
GO
INSERT [dbo].[Status] ([StatusID], [Status]) VALUES (2, N'Approved')
GO
INSERT [dbo].[Status] ([StatusID], [Status]) VALUES (3, N'Declined')
GO
INSERT [dbo].[Status] ([StatusID], [Status]) VALUES (4, N'Cancelled')
GO
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [UserName], [FirstName], [LastName], [Gender], [Email], [Password], [IsActive], [MobileNo], [DateOfBirth], [Country], [RoleID], [StatusID], [AddedBy], [AddedOn], [UpdatedBy], [UpdatedOn]) VALUES (1, N'admin', N'Usman', N'Khan', N'Male', N'usman.khi18@hotmail.com', N'123456', 1, N'03363302274', CAST(N'1993-08-30T00:00:00.000' AS DateTime), N'Pakistan', 1, 2, 1, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 1, CAST(N'2020-06-16T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
