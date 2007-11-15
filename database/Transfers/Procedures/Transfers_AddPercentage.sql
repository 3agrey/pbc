if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_AddPercentage]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_AddPercentage]
end
go

/********************************************************************************************************
* Transfers_AddPercentage
*
* Adds percentage transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_AddPercentage]
(
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
	
	declare @Id int
	exec @Id = dbo.Transfers_Add
		@SourceAccountId,
		@TargetAccountId,
		@Name,
		3 -- Percentage Transfer
	
	insert into
		[PercentageTransfers]
	(
		[Id],
		[Amount],
		[Percentage],
		[StartDate],
		[Period]
	)
	values
	(
		@Id,
		@Amount,
		@Percentage,
		@StartDate,
		@Period
	)
	
	commit transaction

	select @Id
end
go