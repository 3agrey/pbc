if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_ArrayToTable]') and xtype in (N'FN', N'IF', N'TF'))
begin
	drop function [dbo].[fn_ArrayToTable]
end
go

/********************************************************************************************************
* fn_ArrayToTable
*
* Converts string array to table
********************************************************************************************************/
create function [dbo].[fn_ArrayToTable]
(
	@array text,
	@itemLen tinyint
)
returns table
as
return
(
	select
		position = n.Number,
		value = substring(@array, @itemLen * (n.Number - 1) + 1, @itemLen)
	from
		Numbers n
	where
		n.Number <= datalength(@array) / @itemLen + 
		case datalength(@array) % @itemLen
			when 0 then 0
			else 1
		end
)
go
