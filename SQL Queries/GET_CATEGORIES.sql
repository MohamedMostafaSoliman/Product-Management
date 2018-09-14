create proc ADD_PRODUCT
@ID_CAT int , 
@ID_PRODUCT varchar(30),
@Label varchar(30),
@Qte int,
@PRICE varchar(50),
@Img Image
as
INSERT INTO [PRODUCTS]
           ([ID_PRODUCT]
           ,[LABEL_PRODUCT]
           ,[QTE_IN_STOCK]
           ,[PRICE]
           ,[IMAGE_PRODUCT]
           ,[ID_CAT])
     VALUES
           (@ID_PRODUCT
           ,@Label
           ,@Qte
           ,@PRICE
           ,@Img
           ,@ID_CAT)
GO
