if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Accounts_GetList]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Accounts_GetList]
end
go

/********************************************************************************************************
* Accounts_GetList
*
* Returns user's account list
********************************************************************************************************/
create procedure [dbo].[Accounts_GetList]
(
	@UserId int
)
as
begin
	select
		*
	from
		[Accounts]
	where
		[UserId] = @UserId
end
go