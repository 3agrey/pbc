if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_GetListByUser]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_GetListByUser]
end
go

/********************************************************************************************************
* Transfers_GetListByUser
*
* Returns list of transfers assigned to specified user
********************************************************************************************************/
create procedure [dbo].[Transfers_GetListByUser]
(
	@UserId int
)
as
begin
	select
		t.*
	from
		[Transfers] t
			inner join dbo.fn_Transfers_GetListByUser(@UserId) ti on
				t.[Id] = ti.[Id]
end
go