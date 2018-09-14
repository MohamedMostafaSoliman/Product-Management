create proc GET_SINGLE_CATEGORY
@id int 
as
select ID_CAT , DESCRIPTION_CAT from CATEGORIES
where ID_CAT = @id