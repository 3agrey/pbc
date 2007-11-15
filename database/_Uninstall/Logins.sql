/********************************************************************************************************
*
* Personal Budget Calculator
* Logins Uninstallation Script
*
********************************************************************************************************/

use [master]
go

-- drop logins
exec sp_droplogin
	@loginame = N'pbcweb'
go

exec sp_droplogin
	@loginame = N'pbcadmin'
go