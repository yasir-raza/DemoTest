USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[sp_Test]    Script Date: 1/6/2020 10:51:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Test] 
@Name NVARCHAR(50) = '',
@Password NVARCHAR(50) = ''
AS
BEGIN
	--DECLARE @FirstName NVARCHAR(50) = ''
	--DECLARE @LastName NVARCHAR(50) = ''
	INSERT INTO [User] ( Name, [Password] )
	VALUES ( @Name, @Password )
END


GO
/****** Object:  Table [dbo].[Location]    Script Date: 1/6/2020 10:51:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[L_ID] [int] IDENTITY(1,1) NOT NULL,
	[Longitude] [nvarchar](50) NULL,
	[Latitude] [nvarchar](50) NULL,
	[U_ID] [int] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[L_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 1/6/2020 10:51:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[U_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[U_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([U_ID], [Name], [Password]) VALUES (1, N'Yasir', N'a')
INSERT [dbo].[User] ([U_ID], [Name], [Password]) VALUES (2, N'kamran', N'abc')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_User] FOREIGN KEY([U_ID])
REFERENCES [dbo].[User] ([U_ID])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_User]
GO
