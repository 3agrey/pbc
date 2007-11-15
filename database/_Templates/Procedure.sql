if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[<NAME>]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[<NAME>]
end
go

/********************************************************************************************************
* <NAME>
*
* <DESCRIPTION>
********************************************************************************************************/
create procedure [dbo].[<NAME>]
(
	<PARAMS>
)
as
begin
	<BODY>
end
go