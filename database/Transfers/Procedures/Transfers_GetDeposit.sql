if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_GetDeposit]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_GetDeposit]
end
go

/********************************************************************************************************
* Transfers_GetDeposit
*
* Returns a deposit transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_GetDeposit]
(
	@Id int
)
as
begin
	select
		t.[Id],
		t.[SourceAccountId],
		t.[TargetAccountId],
		t.[Name],
		t.[Type],
		dt.[BeginningAmount],
		dt.[Percentage],
		dt.[StartDate],
		dt.[Period],
		dt.[IncrementPeriodType],
		dt.[IncrementStandardPeriod],
		dt.[IncrementCustomPeriod],
		dt.[IncrementAmount]
	from
		[Transfers] t
			inner join [DepositTransfers] dt on
				t.[Id] = dt.[Id]
	where
		t.[Id] = @Id
end
go