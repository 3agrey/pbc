if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_UpdateSingle]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_UpdateSingle]
end
go

/********************************************************************************************************
* Transfers_UpdateSingle
*
* Updates single transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_UpdateSingle]
(
	@Id int,
	@SourceAccountId int,
	@TargetAccountId int,
	@Name nvarchar(64),
	@Date datetime,
	@Amount money
)
as
begin
	begin transaction
	
	exec dbo.Transfers_Update
		@Id,
		@SourceAccountId,
		@TargetAccountId,
		@Name
	
	update
		[SingleTransfers]
	set
		[Date] = @Date,
		[Amount] = @Amount
	where
		[Id] = @Id
	
	commit transaction
end
go