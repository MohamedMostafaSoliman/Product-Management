create proc SearchProduct
@ID varchar(50)
as
SELECT [ID_PRODUCT] as '��� ������' 
      ,[LABEL_PRODUCT]as '��� ������'
      ,[QTE_IN_STOCK]as '������ �������'
      ,[PRICE] as '�����'
      ,DESCRIPTION_CAT as '�����'
From [PRODUCT_DB].[dbo].[PRODUCTS]   
INNER JOIN CATEGORIES
ON CATEGORIES.ID_CAT = PRODUCTS.ID_CAT  
where
[ID_PRODUCT] + 
[LABEL_PRODUCT] +
convert(varchar , [QTE_IN_STOCK]) +
[PRICE] + 
DESCRIPTION_CAT
LIKE '%'+@ID+'%'
