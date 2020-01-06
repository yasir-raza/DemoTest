USE [Test]
GO

/****** Object:  StoredProcedure [dbo].[sp_Test]    Script Date: 1/6/2020 12:38:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_Test] 
@Type INT = 0,
@Name NVARCHAR(50) = '',
@Password NVARCHAR(50) = ''
AS
IF(@Type = 1)
BEGIN
	--DECLARE @FirstName NVARCHAR(50) = ''
	--DECLARE @LastName NVARCHAR(50) = ''
	INSERT INTO [User] ( Name, [Password] )
	VALUES ( @Name, @Password )
END
IF(@Type = 2)
BEGIN
	--DECLARE @Name NVARCHAR(50) = ''
	--DECLARE @Password NVARCHAR(50) = ''
	SELECT * FROM [User] u
	WHERE u.Name = @Name AND u.[Password] = @Password
END

GO


