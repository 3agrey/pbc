/********************************************************************************************************
*
* Personal Budget Calculator
* Data Deletion Script
*
********************************************************************************************************/

use [FiscalInsight]
go

delete from dbo.[Accounts]
delete from dbo.[Users]
go

dbcc checkident ('Accounts', reseed, 0)
dbcc checkident ('Users', reseed, 0)
go
