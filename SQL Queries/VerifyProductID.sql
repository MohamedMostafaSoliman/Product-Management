CREATE PROC VerifyProductID
@ID varchar(50)
as
select * From PRODUCTS where ID_PRODUCT = @ID