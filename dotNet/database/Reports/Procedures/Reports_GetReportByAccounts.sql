if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Reports_GetReportByAccounts]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Reports_GetReportByAccounts]
end
go

/********************************************************************************************************
* Reports_GetReportByAccounts
*
* Returns data for report by accounts
********************************************************************************************************/
create procedure [dbo].[Reports_GetReportByAccounts]
(
	@UserId int
)
as
begin
	if
	(
		select
			[HasTransactionCache]
		from
			[Users]
		where
			[Id] = @UserId
	) = 0
	begin
		exec dbo.Users_UpdateTransactionCache @UserId
	end

	select
		ast.[AccountId] as [AccountId],
		a.[Name] as [AccountName],
		ast.[Date] as [Date],
		ast.[Balance] as [Balance]
	from
		[AccountStates] ast
			inner join [Accounts] a on
				a.[Id] = ast.[AccountId]
	order by
		ast.[AccountId],
		ast.[Date]
end
go