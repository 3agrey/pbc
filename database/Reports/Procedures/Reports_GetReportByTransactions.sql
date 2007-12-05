if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Reports_GetReportByTransactions]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Reports_GetReportByTransactions]
end
go

/********************************************************************************************************
* Reports_GetReportByTransactions
*
* Returns data for report by transactions
********************************************************************************************************/
create procedure [dbo].[Reports_GetReportByTransactions]
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
		tr.[TransferName],
		case
			when sa.[Id] is null then 'External'
			else sa.[Name] 
		end as [SourceAccountName],
		case
			when ta.[Id] is null then 'External'
			else ta.[Name]
		end as [TargetAccountName],
		tr.[Date] as [TransactionDate],
		tr.[Amount] as [TransactionAmount]
	from
		[v_Transactions] tr
			left join [Accounts] sa on
				tr.[SourceAccountId] = sa.[Id]
			left join [Accounts] ta on
				tr.[TargetAccountId] = ta.[Id]
	where
		tr.[UserId] = @UserId
	order by
		tr.[Date]
end
go