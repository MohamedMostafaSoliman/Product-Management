USE [Product_DB]
GO
/****** Object:  StoredProcedure [dbo].[ADD_CUSTOMER]    Script Date: 08/18/2017 22:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc		[dbo].[EDIT_CUSTOMER]
@First_Name varchar(25) ,
@Last_Name  varchar(25) ,
@Tel nchar(15),
@Email varchar(25),
@Picture image,
@Criterion varchar(50),
@ID int 
as
if @Criterion='with_image'
begin
UPDATE [CUSTOMERS]
   SET [FIRST_NAME] = @FIRST_NAME
      ,[LAST_NAME] = @LAST_NAME
      ,[TEL] = @TEL
      ,[EMAIL] = @EMAIL
      ,[IMAGE_CUSTOMER] = @Picture
 WHERE ID_CUSTOMER = @ID
end

if @Criterion='without_image'
begin
UPDATE [CUSTOMERS]
   SET [FIRST_NAME] = @FIRST_NAME
      ,[LAST_NAME] = @LAST_NAME
      ,[TEL] = @TEL
      ,[EMAIL] = @EMAIL
       WHERE ID_CUSTOMER = @ID
end