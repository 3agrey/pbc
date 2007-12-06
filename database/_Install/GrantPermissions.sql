/********************************************************************************************************
*
* Personal Budget Calculator
* Grants Installation Script
*
********************************************************************************************************/

use [PBC]
go

-- procedures
grant execute on dbo.[Accounts_Get] to [pbcweb]
grant execute on dbo.[Accounts_GetList] to [pbcweb]
grant execute on dbo.[Accounts_GetStatistic] to [pbcweb]
grant execute on dbo.[Accounts_Add] to [pbcweb]
grant execute on dbo.[Accounts_Update] to [pbcweb]

grant execute on dbo.[Transfers_Get] to [pbcweb]
grant execute on dbo.[Transfers_GetListByAccount] to [pbcweb]
grant execute on dbo.[Transfers_GetListByUser] to [pbcweb]
grant execute on dbo.[Transfers_GetSingle] to [pbcweb]
grant execute on dbo.[Transfers_GetPeriodical] to [pbcweb]
grant execute on dbo.[Transfers_GetPercentage] to [pbcweb]
grant execute on dbo.[Transfers_GetDeposit] to [pbcweb]
grant execute on dbo.[Transfers_AddSingle] to [pbcweb]
grant execute on dbo.[Transfers_AddPeriodical] to [pbcweb]
grant execute on dbo.[Transfers_AddPercentage] to [pbcweb]
grant execute on dbo.[Transfers_AddDeposit] to [pbcweb]
grant execute on dbo.[Transfers_UpdateSingle] to [pbcweb]
grant execute on dbo.[Transfers_UpdatePeriodical] to [pbcweb]
grant execute on dbo.[Transfers_UpdatePercentage] to [pbcweb]
grant execute on dbo.[Transfers_UpdateDeposit] to [pbcweb]

grant execute on dbo.[Reports_GetReportByTransactions] to [pbcweb]
grant execute on dbo.[Reports_GetReportByAccounts] to [pbcweb]
go