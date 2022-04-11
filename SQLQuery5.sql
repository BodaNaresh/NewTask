USE [TODO]
GO
/****** Object:  Table [dbo].[Boards]    Script Date: 11-04-2022 18:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boards](
	[BoardID] [int] NOT NULL,
	[BoardName] [varchar](100) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Board] PRIMARY KEY CLUSTERED 
(
	[BoardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginUser]    Script Date: 11-04-2022 18:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginUser](
	[LoginID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_LoginUser] PRIMARY KEY CLUSTERED 
(
	[LoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Register]    Script Date: 11-04-2022 18:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Register](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](100) NOT NULL,
	[Gender] [varchar](100) NULL,
	[Mobile] [varchar](100) NULL,
	[Location] [varchar](100) NULL,
 CONSTRAINT [PK_Register] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusInfo]    Script Date: 11-04-2022 18:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusInfo](
	[StatusId] [int] NOT NULL,
	[StatusName] [varchar](100) NULL,
 CONSTRAINT [PK_StatusInfo] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Todo]    Script Date: 11-04-2022 18:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Todo](
	[TodoId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TodoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LoginUser] ON 
GO
INSERT [dbo].[LoginUser] ([LoginID], [Email], [password], [UserID]) VALUES (2, N'a@gmail.com', N'321', NULL)
GO
INSERT [dbo].[LoginUser] ([LoginID], [Email], [password], [UserID]) VALUES (3, N'n@gmail.com', N'123', NULL)
GO
INSERT [dbo].[LoginUser] ([LoginID], [Email], [password], [UserID]) VALUES (4, N'na@gmail.com', N'456', NULL)
GO
INSERT [dbo].[LoginUser] ([LoginID], [Email], [password], [UserID]) VALUES (5, N'n@gmail.com', N'1234', NULL)
GO
INSERT [dbo].[LoginUser] ([LoginID], [Email], [password], [UserID]) VALUES (6, N'a@gmail.com', N'456', NULL)
GO
SET IDENTITY_INSERT [dbo].[LoginUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Register] ON 
GO
INSERT [dbo].[Register] ([UserID], [Name], [Email], [Gender], [Mobile], [Location]) VALUES (11, N'Naresh', N'n@gmail.com', N'Male', N'987654568', N'Hyderabad')
GO
INSERT [dbo].[Register] ([UserID], [Name], [Email], [Gender], [Mobile], [Location]) VALUES (12, N'Anu', N'v@gmail.com', N'Female', N'3456787654', N'mumbai')
GO
INSERT [dbo].[Register] ([UserID], [Name], [Email], [Gender], [Mobile], [Location]) VALUES (13, N'Anu', N'a@gmail.com', N'Female', N'3456787654', N'mumbai')
GO
INSERT [dbo].[Register] ([UserID], [Name], [Email], [Gender], [Mobile], [Location]) VALUES (14, N'Anu', N'a@gmail.com', N'Female', N'98765456', N'mumbai')
GO

SET IDENTITY_INSERT [dbo].[Register] OFF
GO
SET IDENTITY_INSERT [dbo].[Todo] ON 
GO
INSERT [dbo].[Todo] ([TodoId], [Title], [Description], [UserID]) VALUES (130, N'rertfyuik', N'', NULL)
GO
INSERT [dbo].[Todo] ([TodoId], [Title], [Description], [UserID]) VALUES (131, N'sdfghjkl', N'', NULL)
GO
INSERT [dbo].[Todo] ([TodoId], [Title], [Description], [UserID]) VALUES (132, N'dfghj', N'', NULL)
GO
INSERT [dbo].[Todo] ([TodoId], [Title], [Description], [UserID]) VALUES (133, N'sdfghjklcvbhnjm,.', N'', NULL)
GO
INSERT [dbo].[Todo] ([TodoId], [Title], [Description], [UserID]) VALUES (134, N'sdfghjklcvbhnjm', N'', NULL)
GO
SET IDENTITY_INSERT [dbo].[Todo] OFF
GO
ALTER TABLE [dbo].[Boards]  WITH CHECK ADD  CONSTRAINT [FK_Boards_Register] FOREIGN KEY([UserID])
REFERENCES [dbo].[Register] ([UserID])
GO
ALTER TABLE [dbo].[Boards] CHECK CONSTRAINT [FK_Boards_Register]
GO
ALTER TABLE [dbo].[LoginUser]  WITH CHECK ADD  CONSTRAINT [FK_LoginUser_Register] FOREIGN KEY([UserID])
REFERENCES [dbo].[Register] ([UserID])
GO
ALTER TABLE [dbo].[LoginUser] CHECK CONSTRAINT [FK_LoginUser_Register]
GO
ALTER TABLE [dbo].[Todo]  WITH CHECK ADD  CONSTRAINT [FK_Todo_Register] FOREIGN KEY([UserID])
REFERENCES [dbo].[Register] ([UserID])
GO
ALTER TABLE [dbo].[Todo] CHECK CONSTRAINT [FK_Todo_Register]
GO
/****** Object:  StoredProcedure [dbo].[createUser]    Script Date: 11-04-2022 18:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[createUser](
     
     @Name Varchar(100)  
    ,@Email varchar(100) 
    ,@Gender varchar(100)
	,@Mobile varchar(100)
    ,@Location  varchar(100) 
	,@password varchar(100)
 
 
 )
 As
 Begin

 
   INSERT INTO dbo.Register
                        (
                         Name,
                         Email,
                         Gender,
                         Mobile,
						 Location)
               VALUES  ( 
			           
                         @Name,
                         @Email,
						 @Gender,
                         @Mobile,
                         @Location
						)

insert into dbo.LoginUser(
                      Email,
					  password)
					  
					  values(
					  @Email,
					  @password)
					  
	end				  
GO
/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 11-04-2022 18:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UserLogin](
 @Email varchar(100) ,
 @Password varchar(100)
 )
 as
 begin

 insert into dbo.LoginUser(
                      Email,
					  password)
					  
					  values(
					  @Email,
					  @password)

 end
GO
/****** Object:  StoredProcedure [dbo].[UserRegister]    Script Date: 11-04-2022 18:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UserRegister](
     @Name Varchar(100)  
    ,@Email varchar(100) 
    ,@Gender varchar(100)
	,@Mobile varchar(100)
    ,@Location  varchar(100) 
         
                 )

				 as 
				 begin
				  INSERT INTO dbo.Register
                        (
                         Name,
                         Email,
                         Gender,
                         Mobile,
						 Location)
               VALUES  ( 
			            
                         @Name,
                         @Email,
						 @Gender,
                         @Mobile,
                         @Location
						)
 end
GO
/****** Object:  StoredProcedure [dbo].[Users]    Script Date: 11-04-2022 18:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Users](

@Email varchar(100),
@Password varchar(100))

 As
 begin



  select * from LoginUser where  Email=@Email AND Password=@Password

 End
GO
