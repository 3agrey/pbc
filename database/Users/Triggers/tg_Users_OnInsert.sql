if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tg_Users_OnInsert]') and objectproperty(id, N'IsTrigger') = 1)
begin
	drop trigger [dbo].[tg_Users_OnInsert]
end
go

/********************************************************************************************************
* tg_Users_OnInsert
*
* Creates default account for inserted user
********************************************************************************************************/
create trigger [dbo].[tg_Users_OnInsert] on [dbo].[Users]
after insert
as
	declare @userId int
	declare userCursor cursor local fast_forward for
		select
			[Id]
		from
			[inserted]

	open userCursor
	fetch next from userCursor into @userId
	while @@fetch_status = 0
	begin

		insert into
			[Accounts]
		(
			[UserId],
			[Name],
			[BeginningBalance],
			[BeginningBalanceDate]
		)
		values
		(
			@userId,
			'Cash',
			0,
			getdate()
		)

		fetch next from userCursor into @userId
	end
	close userCursor
	deallocate userCursor
go