if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_GetSingle]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_GetSingle]
end
go

/********************************************************************************************************
* Transfers_GetSingle
*
* Returns a single transfer
********************************************************************************************************/
create procedure [dbo].[Transfers_GetSingle]
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
		st.[Date],
		st.[Amount]
	from
		[Transfers] t
			inner join [SingleTransfers] st on
				t.[Id] = st.[Id]
	where
		t.[Id] = @Id
end
go