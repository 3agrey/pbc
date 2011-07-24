/********************************************************************************************************
*
* Personal Budget Calculator
* Database Installation Script
*
* for Microsoft SQL Server 2000
*
********************************************************************************************************/

-- create database
create database [PBC]
on
primary
(
	name = 'PBC',
	filename = 'C:\Databases\PBC\PBC.mdf',
	size = 10mb,
	filegrowth = 10mb
)
log on
(
	name = 'PBC_Log',
	filename = 'C:\Databases\PBC\PBC_Log.ldf',
	size = 10mb,
	filegrowth = 10mb
)
go