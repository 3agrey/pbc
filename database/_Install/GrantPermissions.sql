/********************************************************************************************************
*
* Personal Budget Calculator
* Grants Installation Script
*
********************************************************************************************************/

use [PBC]
go

-- procedures
grant execute on dbo.[Reports_GetReportByTransactions] to [pbcweb]
grant execute on dbo.[Reports_GetReportByAccounts] to [pbcweb]
go