if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[<NAME>]') and xtype in (N'FN', N'IF', N'TF'))
begin
	drop function [dbo].[<NAME>]
end
go

/********************************************************************************************************
* <NAME>
*
* <DESCRIPTION>
********************************************************************************************************/
create function [dbo].[<NAME>]
(
	<PARAMS>
)
returns <DATATYPE>
as
begin
	declare @result <DATATYPE>

	...
	set @result = <VALUE>
	...

	return @result
end
go