if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_UpdateDeposit]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_UpdateDeposit]
end
go

/********************************************************************************************************
* Transfers_UpdatePercentage
*
* Updates deposit transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_UpdateDeposit]
(
	@Id int,
	@SourceAccountId int,
	@TargetAccountId int,
	@Name nvarchar(64),
	@BeginningAmount money,
	@Percentage real,
	@StartDate datetime,
	@Period int,
	@IncrementPeriodType tinyint,
	@IncrementStandardPeriod tinyint,
	@IncrementCustomPeriod int,
	@IncrementAmount money
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
		[DepositTransfers]
	set
		[BeginningAmount] = @BeginningAmount,
		[Percentage] = @Percentage,
		[StartDate] = @StartDate,
		[Period] = @Period,
		[IncrementPeriodType] = @IncrementPeriodType,
		[IncrementStandardPeriod] = @IncrementStandardPeriod,
		[IncrementCustomPeriod] = @IncrementCustomPeriod,
		[IncrementAmount] = @IncrementAmount
	where
		[Id] = @Id
	
	commit transaction

	select @Id
end
go