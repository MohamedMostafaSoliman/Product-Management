create proc SP_LOGIN
@ID varchar(50) , @PWD varchar(50)

As
select * From USERS WHERE ID = @ID AND Password = @PWD