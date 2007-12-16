using System;
using AIM.PBC.Core.BusinessObjects;

namespace AIM.PBC.Core
{
	public static class TransferFactory
	{
		public static Transfer CreateTransfer (TransferTypes type)
		{
			Transfer entity;
			switch (type)
			{
				case TransferTypes.Single:
					entity = new SingleTransfer();
					break;
				case TransferTypes.Periodical:
					entity = new PeriodicalTransfer();
					break;
				case TransferTypes.Percentage:
					entity = new PercentageTransfer();
					break;
				default:
					throw new NotSupportedException("Transfer Type is not supported");
			}
			return entity;
		}

		public static Type GetTransferType(TransferTypes type)
		{
			switch (type)
			{
				case TransferTypes.Single:
					return typeof(SingleTransfer);
				case TransferTypes.Periodical:
					return typeof(PeriodicalTransfer);
				case TransferTypes.Percentage:
					return typeof(PercentageTransfer);
				default:
					throw new NotSupportedException("Transfer Type is not supported");
			}
		}
	}
}
