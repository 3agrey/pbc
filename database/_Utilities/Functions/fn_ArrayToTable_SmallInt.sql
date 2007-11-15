if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_ArrayToTable_SmallInt]') and xtype in (N'FN', N'IF', N'TF'))
begin
	drop function [dbo].[fn_ArrayToTable_SmallInt]
end
go

/********************************************************************************************************
* fn_ArrayToTable_SmallInt
*
* Converts string array of smallint numbers to table
********************************************************************************************************/
create function [dbo].[fn_ArrayToTable_SmallInt]
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
		cast(value as smallint) as value
	from
		dbo.fn_ArrayToTable(@array, @itemLen)
)
go
