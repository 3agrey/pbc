If exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[<NAME>]') and objectproperty(id, N'IsView') = 1)
begin
	drop view [dbo].[<NAME>]
end
go

/********************************************************************************************************
* <NAME>
*
* <DESCRIPTION>
********************************************************************************************************/
create view [dbo].[<NAME>]
as
	<BODY>