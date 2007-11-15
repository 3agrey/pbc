using System;
using System.Data.SqlClient;

namespace AIM.PBC.Core
{
	public class TransferProvider : DatabaseProvider
	{
		/// <summary>
		/// Database methods namespace
		/// </summary>
		private const string Namespace = "Transfers";

		/// <summary>
		/// Returns Transfer
		/// </summary>
		public static Transfer Get (int id)
		{
			const string procedureName = Namespace + "_" + "Get";

			Transfer entity = null;
			SqlDataReader reader = null;
			try
			{
				reader = ExecuteProcedureReader(procedureName,
					new SqlParameter("@Id", id)
				);
				if (reader.Read())
				{
					entity = new Transfer();
					entity.LoadFromReader(reader);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return entity;
		}

		/// <summary>
		/// Returns Transfer
		/// </summary>
		public static Transfer Get (int id, TransferTypes type)
		{
			string procedureName = Namespace + "_" + "Get";
			switch (type)
			{
				case TransferTypes.Single:
					procedureName += "Single";
					break;
				case TransferTypes.Periodical:
					procedureName += "Periodical";
					break;
				case TransferTypes.Percentage:
					procedureName += "Percentage";
					break;
				case TransferTypes.Deposit:
					procedureName += "Deposit";
					break;
			}
			
			Transfer entity = null;
			SqlDataReader reader = null;
			try
			{
				reader = ExecuteProcedureReader(procedureName,
					new SqlParameter("@Id", id)
				);
				if (reader.Read())
				{
					entity = TransferFactory.CreateTransfer(type);
					entity.LoadFromReader(reader);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return entity;
		}
		
		/// <summary>
		/// Returns list of transfers assigned to specified user
		/// </summary>
		public static TransferList GetListByUser (int userId)
		{
			const string procedureName = Namespace + "_" + "GetListByUser";
			TransferList list;
			SqlDataReader reader = null;
			try
			{
				reader = ExecuteProcedureReader(procedureName,
					new SqlParameter("@UserId", userId)
				);
				list = new TransferList(reader);
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return list;
		}

		/// <summary>
		/// Returns list of transfers assigned to specified account
		/// </summary>
		public static TransferList GetListByAccount(int accountId)
		{
			const string procedureName = Namespace + "_" + "GetListByAccount";
			TransferList list;
			SqlDataReader reader = null;
			try
			{
				reader = ExecuteProcedureReader(procedureName,
					new SqlParameter("@AccountId", accountId)
				);
				list = new TransferList(reader);
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return list;
		}

		/// <summary>
		/// Add new Transfer
		/// </summary>
		public static int Add (Transfer entity)
		{
			string procedureName = Namespace + "_" + "Add";
			SqlParameterList parameterList = new SqlParameterList();
			parameterList.Add(new SqlParameter("@SourceAccountId", entity.SourceAccountId.NullableValue));
			parameterList.Add(new SqlParameter("@TargetAccountId", entity.TargetAccountId.NullableValue));
			parameterList.Add(new SqlParameter("@Name", entity.Name.Value));

			Type entityType = entity.GetType();
			if (entityType == typeof(SingleTransfer))
			{
				procedureName += "Single";
				SingleTransfer actualEntity = (SingleTransfer) entity;
				parameterList.Add(new SqlParameter("@Date", actualEntity.Date.Value));
				parameterList.Add(new SqlParameter("@Amount", actualEntity.Amount.Value));
			}
			else if (entityType == typeof(PeriodicalTransfer))
			{
				procedureName += "Periodical";
				PeriodicalTransfer actualEntity = (PeriodicalTransfer) entity;
				parameterList.Add(new SqlParameter("@StartDate", actualEntity.StartDate.Value));
				parameterList.Add(new SqlParameter("@EndDate", actualEntity.EndDate.Value));
				parameterList.Add(new SqlParameter("@PeriodType", actualEntity.PeriodType.Value));
				parameterList.Add(new SqlParameter("@StandardPeriod", actualEntity.StandardPeriod.NullableValue));
				parameterList.Add(new SqlParameter("@CustomPeriod", actualEntity.CustomPeriod.NullableValue));
				parameterList.Add(new SqlParameter("@Amount", actualEntity.Amount.Value));
			}
			else if (entityType == typeof(PercentageTransfer))
			{
				procedureName += "Percentage";
				PercentageTransfer actualEntity = (PercentageTransfer) entity;
				parameterList.Add(new SqlParameter("@Amount", actualEntity.Amount.Value));
				parameterList.Add(new SqlParameter("@Percentage", actualEntity.Percentage.Value));
				parameterList.Add(new SqlParameter("@StartDate", actualEntity.StartDate.Value));
				parameterList.Add(new SqlParameter("@Period", actualEntity.Period.Value));
			}
			else if (entityType == typeof(DepositTransfer))
			{
				procedureName += "Deposit";
				DepositTransfer actualEntity = (DepositTransfer) entity;
				parameterList.Add(new SqlParameter("@BeginningAmount", actualEntity.BeginningAmount.Value));
				parameterList.Add(new SqlParameter("@Percentage", actualEntity.Percentage.Value));
				parameterList.Add(new SqlParameter("@StartDate", actualEntity.StartDate.Value));
				parameterList.Add(new SqlParameter("@Period", actualEntity.Period.Value));
				parameterList.Add(new SqlParameter("@IncrementPeriodType", actualEntity.IncrementPeriodType.Value));
				parameterList.Add(new SqlParameter("@IncrementStandardPeriod", actualEntity.IncrementStandardPeriod.NullableValue));
				parameterList.Add(new SqlParameter("@IncrementCustomPeriod", actualEntity.IncrementCustomPeriod.NullableValue));
				parameterList.Add(new SqlParameter("@IncrementAmount", actualEntity.IncrementAmount.Value));
			}

			int id = (int) ExecuteProcedureScalar(procedureName, parameterList);
			return id;
		}

		/// <summary>
		/// Updates transfer
		/// </summary>
		public static void Update (Transfer entity)
		{
			string procedureName = Namespace + "_" + "Update";
			SqlParameterList parameterList = new SqlParameterList();
			parameterList.Add(new SqlParameter("@Id", entity.Id.Value));
			parameterList.Add(new SqlParameter("@SourceAccountId", entity.SourceAccountId.NullableValue));
			parameterList.Add(new SqlParameter("@TargetAccountId", entity.TargetAccountId.NullableValue));
			parameterList.Add(new SqlParameter("@Name", entity.Name.Value));

			Type entityType = entity.GetType();
			if (entityType == typeof(SingleTransfer))
			{
				procedureName += "Single";
				SingleTransfer actualEntity = (SingleTransfer) entity;
				parameterList.Add(new SqlParameter("@Date", actualEntity.Date.Value));
				parameterList.Add(new SqlParameter("@Amount", actualEntity.Amount.Value));
			}
			else if (entityType == typeof(PeriodicalTransfer))
			{
				procedureName += "Periodical";
				PeriodicalTransfer actualEntity = (PeriodicalTransfer) entity;
				parameterList.Add(new SqlParameter("@StartDate", actualEntity.StartDate.Value));
				parameterList.Add(new SqlParameter("@EndDate", actualEntity.EndDate.Value));
				parameterList.Add(new SqlParameter("@PeriodType", actualEntity.PeriodType.Value));
				parameterList.Add(new SqlParameter("@StandardPeriod", actualEntity.StandardPeriod.NullableValue));
				parameterList.Add(new SqlParameter("@CustomPeriod", actualEntity.CustomPeriod.NullableValue));
				parameterList.Add(new SqlParameter("@Amount", actualEntity.Amount.Value));
			}
			else if (entityType == typeof(PercentageTransfer))
			{
				procedureName += "Percentage";
				PercentageTransfer actualEntity = (PercentageTransfer) entity;
				parameterList.Add(new SqlParameter("@Amount", actualEntity.Amount.Value));
				parameterList.Add(new SqlParameter("@Percentage", actualEntity.Percentage.Value));
				parameterList.Add(new SqlParameter("@StartDate", actualEntity.StartDate.Value));
				parameterList.Add(new SqlParameter("@Period", actualEntity.Period.Value));
			}
			else if (entityType == typeof(DepositTransfer))
			{
				procedureName += "Deposit";
				DepositTransfer actualEntity = (DepositTransfer) entity;
				parameterList.Add(new SqlParameter("@BeginningAmount", actualEntity.BeginningAmount.Value));
				parameterList.Add(new SqlParameter("@Percentage", actualEntity.Percentage.Value));
				parameterList.Add(new SqlParameter("@StartDate", actualEntity.StartDate.Value));
				parameterList.Add(new SqlParameter("@Period", actualEntity.Period.Value));
				parameterList.Add(new SqlParameter("@IncrementPeriodType", actualEntity.IncrementPeriodType.Value));
				parameterList.Add(new SqlParameter("@IncrementStandardPeriod", actualEntity.IncrementStandardPeriod.NullableValue));
				parameterList.Add(new SqlParameter("@IncrementCustomPeriod", actualEntity.IncrementCustomPeriod.NullableValue));
				parameterList.Add(new SqlParameter("@IncrementAmount", actualEntity.IncrementAmount.Value));
			}

			ExecuteProcedureNonQuery(procedureName, parameterList);
		}
	}
}
