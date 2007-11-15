if  exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Transfers_GetListByAccount]') and objectproperty(id,N'IsProcedure') = 1)
begin
	drop procedure [dbo].[Transfers_GetListByAccount]
end
go

/********************************************************************************************************
* Transfers_GetListByAccount
*
* Returns list of transfers assigned to specified account
********************************************************************************************************/
create procedure [dbo].[Transfers_GetListByAccount]
(
	@AccountId int
)
as
begin
	select
		*
	from
		[Transfers]
	where
		[SourceAccountId] = @AccountId
		or [TargetAccountId] = @AccountId
end
go