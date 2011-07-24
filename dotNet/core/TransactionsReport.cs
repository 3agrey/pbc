using System;
using System.Collections.Generic;
using System.Data;

namespace AIM.PBC.Core
{
	public class TransactionsReport : List<TransactionsReportItem>
	{
		private static class SchemaInfo
		{
			public const string TransferName = "TransferName";
			public const string SourceAccountName = "SourceAccountName";
			public const string TargetAccountName = "TargetAccountName";
			public const string TransactionDate = "TransactionDate";
			public const string TransactionAmount = "TransactionAmount";
		}

		public void LoadReportData (DataTable reportData)
		{
			ValidateSchema(reportData);

			try
			{
				foreach (DataRow reportRow in reportData.Rows)
				{
					TransactionsReportItem item = new TransactionsReportItem();
					item.TransferName = (string) reportRow[SchemaInfo.TransferName];
					item.SourceAccountName = (string) reportRow[SchemaInfo.SourceAccountName];
					item.TargetAccountName = (string) reportRow[SchemaInfo.TargetAccountName];
					item.TransactionDate = (DateTime) reportRow[SchemaInfo.TransactionDate];
					item.TransactionAmount = (decimal) reportRow[SchemaInfo.TransactionAmount];
					Add(item);
				}
			}
			catch
			{
				throw new ApplicationException("Report data has invalid value(s)");
			}
		}

		private void ValidateSchema (DataTable reportData)
		{
			const string missedColumnMessageFormat = "Column '{0}' is missed";
			const string invalidTypeMessageFormat = "Column '{0}' has invalid data format";

			DataColumn transferNameColumn = reportData.Columns[SchemaInfo.TransferName];
			DataColumn sourceAccountNameColumn = reportData.Columns[SchemaInfo.SourceAccountName];
			DataColumn targetAccountNameColumn = reportData.Columns[SchemaInfo.TargetAccountName];
			DataColumn transactionDateColumn = reportData.Columns[SchemaInfo.TransactionDate];
			DataColumn transactionAmountColumn = reportData.Columns[SchemaInfo.TransactionAmount];

			// validate columns
			if (transferNameColumn == null)
			{
				string message = string.Format(missedColumnMessageFormat, SchemaInfo.TransferName);
				throw new ApplicationException(message);
			}
			if (sourceAccountNameColumn == null)
			{
				string message = string.Format(missedColumnMessageFormat, SchemaInfo.SourceAccountName);
				throw new ApplicationException(message);
			}
			if (targetAccountNameColumn == null)
			{
				string message = string.Format(missedColumnMessageFormat, SchemaInfo.TargetAccountName);
				throw new ApplicationException(message);
			}
			if (transactionDateColumn == null)
			{
				string message = string.Format(missedColumnMessageFormat, SchemaInfo.TransactionDate);
				throw new ApplicationException(message);
			}
			if (transactionAmountColumn == null)
			{
				string message = string.Format(missedColumnMessageFormat, SchemaInfo.TransactionAmount);
				throw new ApplicationException(message);
			}

			// validate data types
			if (transferNameColumn.DataType != typeof(string))
			{
				string message = string.Format(invalidTypeMessageFormat, SchemaInfo.TransferName);
				throw new ApplicationException(message);
			}
			if (sourceAccountNameColumn.DataType != typeof(string))
			{
				string message = string.Format(invalidTypeMessageFormat, SchemaInfo.SourceAccountName);
				throw new ApplicationException(message);
			}
			if (targetAccountNameColumn.DataType != typeof(string))
			{
				string message = string.Format(invalidTypeMessageFormat, SchemaInfo.TargetAccountName);
				throw new ApplicationException(message);
			}
			if (transactionDateColumn.DataType != typeof(DateTime))
			{
				string message = string.Format(invalidTypeMessageFormat, SchemaInfo.TransactionDate);
				throw new ApplicationException(message);
			}
			if (transactionAmountColumn.DataType != typeof(decimal))
			{
				string message = string.Format(invalidTypeMessageFormat, SchemaInfo.TransactionAmount);
				throw new ApplicationException(message);
			}
		}
	}
}