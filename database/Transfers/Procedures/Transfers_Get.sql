if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_Get]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_Get]
end
go

/********************************************************************************************************
* Transfers_Get
*
* Returns a transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_Get]
(
	@Id int
)
as
begin
	select
		*
	from
		[Transfers]
	where
		[Id] = @Id
end
go