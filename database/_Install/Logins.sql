/********************************************************************************************************
*
* Personal Budget Calculator
* Logins Installation Script
*
********************************************************************************************************/

use [PBC]
go

-- add logins
exec sp_addlogin
	@loginame = N'pbcadmin',
	@passwd = N'6rUchaDEsuxAy34exUtu',
	@defdb = N'PBC'
go

exec sp_addlogin
	@loginame = N'pbcweb',
	@passwd = N'fathabadr3w7d8ASWAFr',
	@defdb = N'PBC'
go

-- grant access to database
exec sp_grantdbaccess
	@loginame = N'pbcadmin',
	@name_in_db = N'pbcadmin'
go

exec sp_grantdbaccess
	@loginame = N'pbcweb',
	@name_in_db = N'pbcweb'
go

-- assign roles to logins
exec sp_addrolemember
	@rolename = N'db_owner',
	@membername = N'pbcadmin'
go