/********************************************************************************************************
*
* Personal Budget Calculator
* Database Schema Installation Script
*
********************************************************************************************************/

use [PBC]
go

/********************************************************************************************************
* Numbers
********************************************************************************************************/
select top 65536
	[Number] = identity(int, 1, 1)
into
	dbo.[Numbers]
from
	sysobjects t1, sysobjects t2, sysobjects t3, sysobjects t4, sysobjects t5
go

/********************************************************************************************************
* Table: Users
********************************************************************************************************/
create table dbo.[Users]
(
	[Id] int not null identity(1, 1),
	[Username] nvarchar(64) not null,
	[Password] nvarchar(64) not null,
	[Firstname] nvarchar(32) null,
	[Lastname] nvarchar(32) null,
	[Email] nvarchar(128) null,
	[Created] datetime not null,
	[LastLogin] datetime null,
	[HasTransactionCache] bit not null,
	constraint PK_Users primary key ([Id])
)
go

create unique index IU_Username on dbo.[Users] ([Username] asc)
go

/********************************************************************************************************
* Table: Accounts
********************************************************************************************************/
create table dbo.[Accounts]
(
	[Id] int not null identity(1, 1),
	[UserId] int not null,
	[Name] nvarchar(64) not null,
	[BeginningBalance] money not null,
	[BeginningBalanceDate] datetime not null,
	constraint PK_Accounts primary key ([Id])
)
go

/********************************************************************************************************
* Table: Transfers
********************************************************************************************************/
create table dbo.[Transfers]
(
	[Id] int not null identity(1, 1),
	[SourceAccountId] int null,
	[TargetAccountId] int null,
	[Name] nvarchar(64) not null,
	[Type] tinyint not null,
	/*
		1 - Single Transfer
		2 - Periodical Transfer
		3 - Percentage Transfer
		4 - Deposit Transfer
	*/
	constraint PK_Transfers primary key ([Id])
)
go

create table dbo.[SingleTransfers]
(
	[Id] int not null,
	[Date] datetime not null,
	[Amount] money not null,
	constraint PK_SingleTransfers primary key ([Id])
)
go

create table dbo.[PeriodicalTransfers]
(
	[Id] int not null,
	[StartDate] datetime not null,
	[EndDate] datetime not null,
	[PeriodType] tinyint not null,
	/*
		1 - Standard Period
		2 - Custom Period
	*/
	[StandardPeriod] tinyint null,
	/*
		1 - Daily
		2 - Weekly
		3 - Monthly
		4 - Yearly
	*/
	[CustomPeriod] int null,
	[Amount] money not null,
	constraint PK_PeriodicalTransfers primary key ([Id])
)
go

create table dbo.[PercentageTransfers]
(
	[Id] int not null,
	[Amount] money not null,
	[Percentage] real not null,
	[StartDate] datetime not null,
	[Period] int not null
)
go

create table dbo.[DepositTransfers]
(
	[Id] int not null,
	[BeginningAmount] money not null,
	[Percentage] real not null,
	[StartDate] datetime not null,
	[Period] int not null,
	[IncrementPeriodType] tinyint not null,
	/*
		1 - Standard Period
		2 - Custom Period
	*/
	[IncrementStandardPeriod] tinyint null,
	/*
		1 - Daily
		2 - Weekly
		3 - Monthly
		4 - Yearly
	*/
	[IncrementCustomPeriod] int null,
	[IncrementAmount] money not null
)
go

/********************************************************************************************************
* Table: Transactions
********************************************************************************************************/
create table dbo.[Transactions]
(
	[Id] int not null identity(1, 1),
	[UserId] int not null,
	[TransferId] int not null,
	[SourceAccountId] int null,
	[TargetAccountId] int null,
	[Date] datetime not null,
	[Amount] money not null,
	constraint PK_Transactions primary key ([Id])
)
go

/********************************************************************************************************
* Table: AccountStates
********************************************************************************************************/
create table dbo.[AccountStates]
(
	[AccountId] int not null,
	[Date] datetime not null,
	[Balance] money not null,
	constraint PK_AccountStates primary key([AccountId], [Date])
)
go