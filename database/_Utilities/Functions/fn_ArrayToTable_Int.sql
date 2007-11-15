if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_ArrayToTable_Int]') and xtype in (N'FN', N'IF', N'TF'))
begin
	drop function [dbo].[fn_ArrayToTable_Int]
end
go

/********************************************************************************************************
* fn_ArrayToTable_Int
*
* Converts string array of int numbers to table
********************************************************************************************************/
create function [dbo].[fn_ArrayToTable_Int]
(
	@array text,
	@itemLen tinyint
)
returns table
as
return
(
	select
		position,
		cast(value as int) as value
	from
		dbo.fn_ArrayToTable(@array, @itemLen)
)
go
