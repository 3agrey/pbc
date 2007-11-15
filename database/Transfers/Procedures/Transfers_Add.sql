if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_Add]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_Add]
end
go

/********************************************************************************************************
* Transfers_Add
*
* Adds a transfer
* INTERNAL ONLY
********************************************************************************************************/
create procedure [dbo].[Transfers_Add]
(
	@SourceAccountId int,
	@TargetAccountId int,
	@Name nvarchar(64),
	@Type tinyint
)
as
begin
	insert into
		[Transfers]
	(
		[SourceAccountId],
		[TargetAccountId],
		[Name],
		[Type]
	)
	values
	(
		@SourceAccountId,
		@TargetAccountId,
		@Name,
		@Type
	)

	return cast(scope_identity() as int)
end
go