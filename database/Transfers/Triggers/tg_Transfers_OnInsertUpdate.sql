if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tg_Transfers_OnInsertUpdate]') and objectproperty(id, N'IsTrigger') = 1)
begin
	drop trigger [dbo].[tg_Transfers_OnInsertUpdate]
end
go

/********************************************************************************************************
* tg_Transfers_OnInsertUpdate
*
* Removes transaction cache for transfer owner
********************************************************************************************************/
create trigger [dbo].[tg_Transfers_OnInsertUpdate] on [dbo].[Transfers]
after insert, update
as
	declare @userId int

	-- invalidate transaction cache for user, who owned source account of transfer
	declare userCursor cursor local fast_forward for
		select distinct
			sa.[UserId]
		from
			[inserted] t
				inner join [Accounts] sa on
					t.[SourceAccountId] = sa.[Id]

	open userCursor
	fetch next from userCursor into @userId
	while @@fetch_status = 0
	begin

		update
			[Users]
		set
			[HasTransactionCache] = 0
		where
			[Id] = @userId

		delete from
			[Transactions]
		where
			[UserId] = @userId

		delete
			ast
		from
			[AccountStates] ast
				inner join [Accounts] a on
					ast.[AccountId] = a.[Id]
		where
			a.[UserId] = @userId

		fetch next from userCursor into @userId
	end
	close userCursor
	deallocate userCursor

	-- invalidate transaction cache for user, who owned target account of transfer
	declare userCursor cursor local fast_forward for
		select distinct
			ta.[UserId]
		from
			[inserted] t
				inner join [Accounts] ta on
					t.[TargetAccountId] = ta.[Id]

	open userCursor
	fetch next from userCursor into @userId
	while @@fetch_status = 0
	begin

		update
			[Users]
		set
			[HasTransactionCache] = 0
		where
			[Id] = @userId

		delete from
			[Transactions]
		where
			[UserId] = @userId

		delete
			ast
		from
			[AccountStates] ast
				inner join [Accounts] a on
					ast.[AccountId] = a.[Id]
		where
			a.[UserId] = @userId

		fetch next from userCursor into @userId
	end
	close userCursor
	deallocate userCursor
go