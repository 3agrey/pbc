/********************************************************************************************************
*
* Personal Budget Calculator
* Triggers Installation Script
*
********************************************************************************************************/

use [PBC]
go

/********************************************************************************************************
* Users
********************************************************************************************************/
create trigger dbo.[itg_Users_Delete] on dbo.[Users]
instead of delete
as	
	-- 1. accounts
	delete
		a
	from
		[Accounts] a
			inner join [deleted] d on
				a.[UserId] = d.[Id]

	-- perform users deletion
	delete
		u
	from
		[Users] u
			inner join [deleted] d on
				u.[Id] = d.[Id]
go

/********************************************************************************************************
* Accounts
********************************************************************************************************/
create trigger dbo.[itg_Accounts_Delete] on dbo.[Accounts]
instead of delete
as	
	-- 1. transfers
	delete
		t
	from
		[Transfers] t
			inner join [deleted] d on
				t.[SourceAccountId] = d.[Id] or t.[TargetAccountId] = d.[Id]

	-- perform accounts deletion
	delete
		a
	from
		[Accounts] a
			inner join [deleted] d on
				a.[Id] = d.[Id]
go

/********************************************************************************************************
* Transfers
********************************************************************************************************/
create trigger dbo.[itg_Transfers_Delete] on dbo.[Transfers]
instead of delete
as	
	-- 1. single transfers
	delete
		st
	from
		[SingleTransfers] st
			inner join [deleted] d on
				st.[Id] = d.[Id]

	-- 2. periodical transfers
	delete
		pt
	from
		[PeriodicalTransfers] pt
			inner join [deleted] d on
				pt.[Id] = d.[Id]

	-- 3. percentage transfers
	delete
		pt
	from
		[PercentageTransfers] pt
			inner join [deleted] d on
				pt.[Id] = d.[Id]

	-- 4. deposit transfers
	delete
		dt
	from
		[DepositTransfer] dt
			inner join [deleted] d on
				dt.[Id] = d.[Id]

	-- 4. transactions
	delete
		t
	from
		[Transactions] t
			inner join [deleted] d on
				t.[TransferId] = d.[Id]

	-- perform users deletion
	delete
		t
	from
		[Transfers] t
			inner join [deleted] d on
				t.[Id] = d.[Id]
go