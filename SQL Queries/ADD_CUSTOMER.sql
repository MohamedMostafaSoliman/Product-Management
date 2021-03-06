USE [Product_DB]
GO
/****** Object:  StoredProcedure [dbo].[ADD_CUSTOMER]    Script Date: 08/18/2017 20:15:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc		[dbo].[ADD_CUSTOMER]
@First_Name varchar(25) ,
@Last_Name  varchar(25) ,
@Tel nchar(15),
@Email varchar(25),
@Picture image,
@Criterion varchar(50)
as
if @Criterion='with_image'
begin
INSERT INTO [CUSTOMERS]
           ([FIRST_NAME]
           ,[LAST_NAME]
           ,[TEL]
           ,[EMAIL]
           ,[IMAGE_CUSTOMER])
     VALUES
           (@FIRST_NAME
           ,@LAST_NAME
           ,@TEL
           ,@EMAIL
           ,@Picture)
end

if @Criterion='without_image'
begin
INSERT INTO [CUSTOMERS]
           ([FIRST_NAME]
           ,[LAST_NAME]
           ,[TEL]
           ,[EMAIL])
     VALUES
           (@FIRST_NAME
           ,@LAST_NAME
           ,@TEL
           ,@EMAIL)
end
