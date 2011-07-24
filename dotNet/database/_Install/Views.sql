/********************************************************************************************************
*
* Personal Budget Calculator
* Views Installation Script
*
********************************************************************************************************/

use [PBC]
go

/*
	Transactions view
*/

CREATE VIEW [dbo].[v_Transactions]
AS
SELECT
	transact.Id,
	usr.Id AS UserId,
	transf.SourceAccountId,
	transf.TargetAccountId,
	transact.TransferId,
	transf.Name as TransferName,
	transact.Date,
    transact.Amount
FROM
	[Transactions] transact
		INNER JOIN [Transfers] transf ON transact.TransferId = transf.Id 
		INNER JOIN [Accounts] acc ON isnull(transf.SourceAccountId, transf.TargetAccountId) = acc.Id 
		INNER JOIN [Users] usr ON acc.UserId = usr.Id
GO