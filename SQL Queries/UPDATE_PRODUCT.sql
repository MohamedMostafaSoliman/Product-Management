create proc UPDATE_PRODUCT
@ID_CAT int , 
@ID_PRODUCT varchar(30),
@Label varchar(30),
@Qte int,
@PRICE varchar(50),
@Img Image
AS
UPDATE PRODUCTS
SET ID_CAT = @ID_CAT,
LABEL_PRODUCT = @Label,
QTE_IN_STOCK = @Qte,
PRICE = @PRICE,
IMAGE_PRODUCT = @Img
WHERE 
ID_PRODUCT = @ID_PRODUCT
