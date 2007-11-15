if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_AddPeriodical]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_AddPeriodical]
end
go

/********************************************************************************************************
* Transfers_AddPeriodical
*
* Adds periodical transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_AddPeriodical]
(
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
	
	declare @Id int
	exec @Id = dbo.Transfers_Add
		@SourceAccountId,
		@TargetAccountId,
		@Name,
		2 -- Periodical Transfer
	
	insert into
		[PeriodicalTransfers]
	(
		[Id],
		[StartDate],
		[EndDate],
		[PeriodType],
		[StandardPeriod],
		[CustomPeriod],
		[Amount]
	)
	values
	(
		@Id,
		@StartDate,
		@EndDate,
		@PeriodType,
		@StandardPeriod,
		@CustomPeriod,
		@Amount
	)
	
	commit transaction

	select @Id
end
go