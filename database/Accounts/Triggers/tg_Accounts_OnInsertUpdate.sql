if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tg_Accounts_OnInsertUpdate]') and objectproperty(id, N'IsTrigger') = 1)
begin
	drop trigger [dbo].[tg_Accounts_OnInsertUpdate]
end
go

/********************************************************************************************************
* tg_Accounts_OnInsertUpdate
*
* Removes transaction cache for account owner
********************************************************************************************************/
create trigger [dbo].[tg_Accounts_OnInsertUpdate] on [dbo].[Accounts]
after insert, update
as
	declare @userId int
	declare userCursor cursor local fast_forward for
		select distinct
			[UserId]
		from
			[inserted]

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