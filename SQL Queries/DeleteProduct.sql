create proc DeleteProduct
@ID varchar(50)
as 
Delete From PRODUCTS where ID_PRODUCT = @ID