if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_GetPercentage]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_GetPercentage]
end
go

/********************************************************************************************************
* Transfers_GetPercentage
*
* Returns a percentage transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_GetPercentage]
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
		ct.[Amount],
		ct.[Percentage],
		ct.[StartDate],
		ct.[Period]
	from
		[Transfers] t
			inner join [PercentageTransfers] ct on
				t.[Id] = ct.[Id]
	where
		t.[Id] = @Id
end
go