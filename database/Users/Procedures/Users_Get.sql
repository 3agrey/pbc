if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Users_Get]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Users_Get]
end
go

/********************************************************************************************************
* Users_Get
*
* Returns User
********************************************************************************************************/
create procedure [dbo].[Users_Get]
(
	@Id int
)
as
begin
	select
		*
	from
		[Users]
	where
		[Id] = @Id
end
go