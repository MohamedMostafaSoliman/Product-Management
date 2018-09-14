create proc SearchProduct
@ID varchar(50)
as
SELECT [ID_PRODUCT] as '—ﬁ„ «·„‰ Ã' 
      ,[LABEL_PRODUCT]as 'Ê’› «·„‰ Ã'
      ,[QTE_IN_STOCK]as '«·ﬂ„ÌÂ «·„Œ“‰Â'
      ,[PRICE] as '«·”⁄—'
      ,DESCRIPTION_CAT as '«·’‰›'
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
