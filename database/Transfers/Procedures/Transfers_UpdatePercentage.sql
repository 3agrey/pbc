if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_UpdatePercentage]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_UpdatePercentage]
end
go

/********************************************************************************************************
* Transfers_UpdatePercentage
*
* Updates percentage transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_UpdatePercentage]
(
	@Id int,
	@SourceAccountId int,
	@TargetAccountId int,
	@Name nvarchar(64),
	@Amount money,
	@Percentage real,
	@StartDate datetime,
	@Period int
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
		[PercentageTransfers]
	set
		[Amount] = @Amount,
		[Percentage] = @Percentage,
		[StartDate] = @StartDate,
		[Period] = @Period
	where
		[Id] = @Id
	
	commit transaction

	select @Id
end
go