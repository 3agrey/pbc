if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_AddSingle]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_AddSingle]
end
go

/********************************************************************************************************
* Transfers_AddSingle
*
* Returns a single transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_AddSingle]
(
	@SourceAccountId int,
	@TargetAccountId int,
	@Name nvarchar(64),
	@Date datetime,
	@Amount money
)
as
begin
	begin transaction
	
	declare @Id int
	exec @Id = dbo.Transfers_Add
		@SourceAccountId,
		@TargetAccountId,
		@Name,
		1 -- Single Transfer
	
	insert into
		[SingleTransfers]
	(
		[Id],
		[Date],
		[Amount]
	)
	values
	(
		@Id,
		@Date,
		@Amount
	)
	
	commit transaction

	select @Id
end
go