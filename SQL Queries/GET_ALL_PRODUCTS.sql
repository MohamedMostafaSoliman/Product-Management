alter proc GET_ALL_PRODUCTS
as
SELECT [ID_PRODUCT] as '��� ������' 
      ,[LABEL_PRODUCT]as '��� ������'
      ,[QTE_IN_STOCK]as '������ �������'
      ,[PRICE] as '�����'
      ,DESCRIPTION_CAT as '�����'
From [PRODUCT_DB].[dbo].[PRODUCTS]   
INNER JOIN CATEGORIES
ON CATEGORIES.ID_CAT = PRODUCTS.ID_CAT   