USE [Marvel]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 6/17/2020 3:05:44 PM ******/
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
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 6/17/2020 3:05:44 PM ******/
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
/****** Object:  Table [dbo].[Status]    Script Date: 6/17/2020 3:05:44 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 6/17/2020 3:05:44 PM ******/
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
	[Password] [nvarchar](100) NOT NULL,
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
	[CNIC] [varchar](13) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Images] ON 
GO
INSERT [dbo].[Images] ([ImageID], [UserID], [ImageUrl]) VALUES (1, 1, N'Uploads/Images/user/1.jpg')
GO
SET IDENTITY_INSERT [dbo].[Images] OFF
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
INSERT [dbo].[Users] ([UserID], [UserName], [FirstName], [LastName], [Gender], [Email], [Password], [IsActive], [MobileNo], [DateOfBirth], [Country], [RoleID], [StatusID], [AddedBy], [AddedOn], [UpdatedBy], [UpdatedOn], [CNIC]) VALUES (1, N'admin', N'Usman', N'Khan', N'Male', N'usman.khi18@hotmail.com', N'?:{?s%?i??', 1, N'03363302274', CAST(N'1993-08-30T00:00:00.000' AS DateTime), N'Pakistan', 1, 2, 1, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 1, CAST(N'2020-06-16T00:00:00.000' AS DateTime), N'4220191970867')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  StoredProcedure [dbo].[proc_ChangePassword]    Script Date: 6/17/2020 3:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[proc_ChangePassword]
@UserID int,
@Password varchar(50)

as
begin
 UPDATE Users  SET Password=@Password
 where UserID = @UserID

 SELECT @UserID
 
 
end
GO
/****** Object:  StoredProcedure [dbo].[proc_CheckPassword]    Script Date: 6/17/2020 3:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[proc_CheckPassword]
@UserID int,
@Password varchar(50)

as
begin
 
 IF EXISTS (SELECT * FROM Users where UserID=@UserID and Password=@Password)
BEGIN
SELECT 'Exist' IsActive;
END
ELSE
BEGIN
SELECT 'NotExist' ISActive;
END
end
GO
/****** Object:  StoredProcedure [dbo].[proc_GetLogin]    Script Date: 6/17/2020 3:05:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[proc_GetLogin]
@Email varchar(150),
@Password varchar(150)
as
begin
	 SELECT u.UserID,u.UserName,u.FirstName,u.LastName,u.Gender,u.Email,u.CNIC
      ,u.IsActive,u.MobileNo,u.DateOfBirth,u.Country,u.RoleID,u.StatusID,i.ImageUrl, s.Status, rm.[Role] FROM Users u 
		INNER JOIN 
			Images i ON u.UserID= i.UserID
			INNER JOIN 
				dbo.[Status] s on s.StatusID = u.StatusID
				INNER JOIN 
					RoleMaster rm on rm.RoleID = u.RoleID
				WHERE u.UserName=@EMAIL AND PASSWORD = @PASSWORD AND ISACTIVE=1



      
end
GO
