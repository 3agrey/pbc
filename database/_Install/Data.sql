/********************************************************************************************************
*
* Personal Budget Calculator
* Data Migration Script
*
********************************************************************************************************/

use [PBC]
go

set nocount on
go

begin transaction
go

/********************************************************************************************************
* Users & Accounts
********************************************************************************************************/
exec Users_Add 'test', '1', 'Tester', 'Testerovich', 'test@domain.net'
exec Users_Add 'codec', '1', 'Vadim', 'Yevsyukov', 'codec@zeos.net'
go

commit
go