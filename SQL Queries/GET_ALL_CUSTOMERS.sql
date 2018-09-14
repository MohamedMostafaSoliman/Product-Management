USE [Product_DB]
GO
/****** Object:  StoredProcedure [dbo].[GET_ALL_CUSTOMERS]    Script Date: 08/18/2017 21:37:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GET_ALL_CUSTOMERS]
as 
SELECT [ID_CUSTOMER]
      ,[FIRST_NAME]as 'الإسم الشخصى'
      ,[LAST_NAME]as 'الإسم العائلى'
      ,[TEL]as 'الهاتف'
      ,[EMAIL]as 'البريد الإلكترونى'
      ,[IMAGE_CUSTOMER]
  FROM [Product_DB].[dbo].[CUSTOMERS]
GO

