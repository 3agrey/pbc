if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Accounts_GetStatistic]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Accounts_GetStatistic]
end
go

/********************************************************************************************************
* Accounts_GetStatistic
*
* Returns accounts staticstic of user
********************************************************************************************************/
create procedure [dbo].[Accounts_GetStatistic]
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