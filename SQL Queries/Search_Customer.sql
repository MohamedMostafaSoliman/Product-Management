Create proc Search_Customer
@Criterion varchar(50) 
as
SELECT [ID_CUSTOMER]
      ,[FIRST_NAME]as '«·≈”„ «·‘Œ’Ï'
      ,[LAST_NAME]as '«·≈”„ «·⁄«∆·Ï'
      ,[TEL]as '«·Â« ›'
      ,[EMAIL]as '«·»—Ìœ «·≈·ﬂ —Ê‰Ï'
      ,[IMAGE_CUSTOMER]
  FROM [Product_DB].[dbo].[CUSTOMERS]
where [FIRST_NAME] + [LAST_NAME] + [TEL] + [EMAIL] like '%' + @Criterion + '%'