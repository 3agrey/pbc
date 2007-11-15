if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Accounts_Add]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Accounts_Add]
end
go

/********************************************************************************************************
* Accounts_Add
*
* Adds new account
********************************************************************************************************/
create procedure [dbo].[Accounts_Add]
(
	@UserId int,
	@Name nvarchar(64),
	@BeginningBalance money,
	@BeginningBalanceDate datetime
)
as
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
		@UserId,
		@Name,
		@BeginningBalance,
		@BeginningBalanceDate
	)

	select
		cast(scope_identity() as int)
end
go