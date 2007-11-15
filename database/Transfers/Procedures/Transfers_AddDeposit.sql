if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_AddDeposit]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_AddDeposit]
end
go

/********************************************************************************************************
* Transfers_AddDeposit
*
* Adds deposit transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_AddDeposit]
(
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
	
	declare @Id int
	exec @Id = dbo.Transfers_Add
		@SourceAccountId,
		@TargetAccountId,
		@Name,
		4 -- Deposit Transfer
	
	insert into
		[DepositTransfers]
	(
		[Id],
		[BeginningAmount],
		[Percentage],
		[StartDate],
		[Period],
		[IncrementPeriodType],
		[IncrementStandardPeriod],
		[IncrementCustomPeriod],
		[IncrementAmount]
	)
	values
	(
		@Id,
		@BeginningAmount,
		@Percentage,
		@StartDate,
		@Period,
		@IncrementPeriodType,
		@IncrementStandardPeriod,
		@IncrementCustomPeriod,
		@IncrementAmount
	)
	
	commit transaction

	select @Id
end
go