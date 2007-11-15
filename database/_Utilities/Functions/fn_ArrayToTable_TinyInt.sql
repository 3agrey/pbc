if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_ArrayToTable_TinyInt]') and xtype in (N'FN', N'IF', N'TF'))
begin
	drop function [dbo].[fn_ArrayToTable_TinyInt]
end
go

/********************************************************************************************************
* fn_ArrayToTable_TinyInt
*
* Converts string array of tinyint numbers to table
********************************************************************************************************/
create function [dbo].[fn_ArrayToTable_TinyInt]
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
		cast(value as tinyint) as value
	from
		dbo.fn_ArrayToTable(@array, @itemLen)
)
go
