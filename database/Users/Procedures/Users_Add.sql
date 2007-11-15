if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Users_Add]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Users_Add]
end
go

/********************************************************************************************************
* Users_Add
*
* Adds new user
********************************************************************************************************/
create procedure [dbo].[Users_Add]
(
	@Username nvarchar(64),
	@Password nvarchar(64),
	@Firstname nvarchar(32),
	@Lastname nvarchar(32),
	@Email nvarchar(128)
)
as
begin
	if not exists
	(
		select
			*
		from
			[Users]
		where
			[Username] = @Username
	)
	begin
		insert into
			[Users]
		(
			[Username],
			[Password],
			[Firstname],
			[Lastname],
			[Email],
			[Created],
			[LastLogin],
			[HasTransactionCache]
		)
		values
		(
			@Username,
			@Password,
			@Firstname,
			@Lastname,
			@Email,
			getdate(),
			null,
			0
		)
		
		select
			cast(scope_identity() as int)
	end
	else
	begin
		select
			cast(0 as int)
	end
end
go