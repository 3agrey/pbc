if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Accounts_Update]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Accounts_Update]
end
go

/********************************************************************************************************
* Accounts_Update
*
* Updates account
********************************************************************************************************/
create procedure [dbo].[Accounts_Update]
(
	@Id int,
	@Name nvarchar(64),
	@BeginningBalance money,
	@BeginningBalanceDate datetime
)
as
begin
	update
		[Accounts]
	set
		[Name] = @Name,
		[BeginningBalance] = @BeginningBalance,
		[BeginningBalanceDate] = @BeginningBalanceDate
	where
		[Id] = @Id
end
go