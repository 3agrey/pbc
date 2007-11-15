if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_Update]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_Update]
end
go

/********************************************************************************************************
* Transfers_Update
*
* Updates transfer
* INTERNAL ONLY
********************************************************************************************************/
create procedure [dbo].[Transfers_Update]
(
	@Id int,
	@SourceAccountId int,
	@TargetAccountId int,
	@Name nvarchar(64)
)
as
begin
	update
		[Transfers]
	set
		[SourceAccountId] = @SourceAccountId,
		[TargetAccountId] = @TargetAccountId,
		[Name] = @Name
	where
		[Id] = @Id
end
go