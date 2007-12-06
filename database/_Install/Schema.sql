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
	[Created] datetime not null default(getdate()),
	[LastLogon] datetime null,
	[HasTransactionCache] bit not null default(0),
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

alter table dbo.[Accounts] add constraint
	FK_Accounts_Users foreign key (UserId) references dbo.[Users] (Id)
	on update  cascade 
	on delete  cascade
GO

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

alter table dbo.[Transfers] add constraint
	FK_Transfers_AccountsSource foreign key (SourceAccountId) references dbo.[Accounts] (Id)
	on update no action
	on delete no action
go

alter table dbo.[Transfers] add constraint
	FK_Transfers_AccountsTarget foreign key (TargetAccountId) references dbo.[Accounts] (Id)
	on update no action
	on delete no action
go

alter table dbo.[Transfers] add constraint
	CK_Transfers_SourceOrTargetNotNull check ((isnull(SourceAccountId,TargetAccountId) is not null))
go

create table dbo.[SingleTransfers]
(
	[Id] int not null,
	[Date] datetime not null,
	[Amount] money not null,
	constraint PK_SingleTransfers primary key ([Id])
)
go

alter table dbo.[SingleTransfers] add constraint
	FK_SingleTransfers_Transfers foreign key (Id) references dbo.[Transfers] (Id)
	on update cascade 
	on delete cascade 
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

alter table dbo.[PeriodicalTransfers] add constraint
	FK_PeriodicalTransfers_Transfers foreign key (Id) references dbo.[Transfers] (Id)
	on update cascade 
	on delete cascade 
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

alter table dbo.[PercentageTransfers] add constraint
	FK_PercentageTransfers_Transfers foreign key (Id) references dbo.[Transfers] (Id)
	on update cascade 
	on delete cascade 
go

/********************************************************************************************************
* Table: Transactions
********************************************************************************************************/
create table dbo.[Transactions]
(
	[Id] int not null identity(1, 1),
	[TransferId] int not null,
	[Date] datetime not null,
	[Amount] money not null,
	constraint PK_Transactions primary key ([Id])
)
go

alter table dbo.[Transactions] add constraint
	FK_Transactions_Transfers foreign key (TransferId) references dbo.[Transfers] (Id)
	on update cascade 
	on delete cascade 
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

alter table dbo.[AccountStates] add constraint
	FK_AccountStates_Accounts foreign key (AccountId) references dbo.[Accounts] (Id)
	on update cascade 
	on delete cascade 
go