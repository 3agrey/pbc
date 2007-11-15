if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Accounts_Get]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Accounts_Get]
end
go

/********************************************************************************************************
* Accounts_Get
*
* Returns account
********************************************************************************************************/
create procedure [dbo].[Accounts_Get]
(
	@Id int
)
as
begin
	select
		*
	from
		[Accounts]
	where
		[Id] = @Id
end
go