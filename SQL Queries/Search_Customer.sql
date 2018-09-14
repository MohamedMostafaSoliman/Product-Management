Create proc Search_Customer
@Criterion varchar(50) 
as
SELECT [ID_CUSTOMER]
      ,[FIRST_NAME]as '����� ������'
      ,[LAST_NAME]as '����� �������'
      ,[TEL]as '������'
      ,[EMAIL]as '������ ����������'
      ,[IMAGE_CUSTOMER]
  FROM [Product_DB].[dbo].[CUSTOMERS]
where [FIRST_NAME] + [LAST_NAME] + [TEL] + [EMAIL] like '%' + @Criterion + '%'