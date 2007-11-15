if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[<NAME>]') and objectproperty(id, N'IsTrigger') = 1)
begin
	drop trigger [dbo].[<NAME>]
end
go

/********************************************************************************************************
* <NAME>
*
* <DESCRIPTION>
********************************************************************************************************/
create trigger [dbo].[<NAME>] on [dbo].[<TABLE>]
after <OPERATIONS>
as
	<BODY>

go