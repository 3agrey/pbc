if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Users_GetByCredentials]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Users_GetByCredentials]
end
go

/********************************************************************************************************
* Users_GetByCredentials
*
* Returns User by credentials
********************************************************************************************************/
create procedure [dbo].[Users_GetByCredentials]
(
	@Username varchar(32),
	@Password varchar(32)
)
as
begin
	declare @id int

	select
		@id = [Id]
	from
		[Users]
	where
		[Username] = @Username
		and [Password] = @Password

	if @id is not null
	begin
		update
			[Users]
		set
			[LastLogon] = getdate()
		where
			[Id] = @id
	end

	select
		*
	from
		[Users]
	where
		[Id] = @id
end
go