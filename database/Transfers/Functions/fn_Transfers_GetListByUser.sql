if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fn_Transfers_GetListByUser]') and xtype in (N'FN', N'IF', N'TF'))
begin
	drop function [dbo].[fn_Transfers_GetListByUser]
end
go

/********************************************************************************************************
* fn_Transfers_GetListByUser
*
* Return list of transfers id by user id
********************************************************************************************************/
create function [dbo].[fn_Transfers_GetListByUser]
(
	@UserId int
)
returns table
as
return
	select
		t.[Id]
	from
		[Transfers] t
			left join [Accounts] sa on
				t.[SourceAccountId] = sa.[Id]
			left join [Accounts] ta on
				t.[TargetAccountId] = ta.[Id]
	where
		sa.[UserId] = @UserId or ta.[UserId] = @UserId
go
