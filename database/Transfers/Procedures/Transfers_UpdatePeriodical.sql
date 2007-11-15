if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_UpdatePeriodical]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_UpdatePeriodical]
end
go

/********************************************************************************************************
* Transfers_UpdatePeriodical
*
* Updates periodical transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_UpdatePeriodical]
(
	@Id int,
	@SourceAccountId int,
	@TargetAccountId int,
	@Name nvarchar(64),
	@StartDate datetime,
	@EndDate datetime,
	@PeriodType tinyint,
	@StandardPeriod tinyint,
	@CustomPeriod int,
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
		[PeriodicalTransfers]
	set
		[StartDate] = @StartDate,
		[EndDate] = @EndDate,
		[PeriodType] = @PeriodType,
		[StandardPeriod] = @StandardPeriod,
		[CustomPeriod] = @CustomPeriod,
		[Amount] = @Amount
	where
		[Id] = @Id
	
	commit transaction

	select @Id
end
go