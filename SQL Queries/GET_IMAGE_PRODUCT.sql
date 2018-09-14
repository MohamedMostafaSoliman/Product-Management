create proc	GET_IMAGE_PRODUCT
@ID varchar(50)
as
select IMAGE_PRODUCT
From PRODUCTS
where ID_PRODUCT = @ID
