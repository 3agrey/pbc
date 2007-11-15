if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_GetPeriodical]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_GetPeriodical]
end
go

/********************************************************************************************************
* Transfers_GetPeriodical
*
* Returns a periodical transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_GetPeriodical]
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
		pt.[StartDate],
		pt.[EndDate],
		pt.[PeriodType],
		pt.[StandardPeriod],
		pt.[CustomPeriod],
		pt.[Amount]
	from
		[Transfers] t
			inner join [PeriodicalTransfers] pt on
				t.[Id] = pt.[Id]
	where
		t.[Id] = @Id
end
go