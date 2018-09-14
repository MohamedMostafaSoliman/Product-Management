alter proc GET_LAST_ORDER_ID
as 
select isnull(max(ID_ORDER)+ 1 , 1)from ORDERS