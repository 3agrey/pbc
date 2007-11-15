using System;
using System.Web.UI.WebControls;

namespace AIM.PBC.Web.UI.Controls
{
	public class AccountDropDownList : DropDownList
	{
		private bool _showEmptyLine = false;
		private int _emptyValue = -1;
		private string _emptyText = "-- Select --";
		private bool _showExternalAccountLine = true;
		private int _externalAccountValue = 0;
		private string _externalAccountText = "External Account";

		public bool ShowEmptyLine
		{
			get { return _showEmptyLine; }
			set { _showEmptyLine = value; }
		}

		public int EmptyValue
		{
			get { return _emptyValue; }
			set { _emptyValue = value; }
		}

		public string EmptyText
		{
			get { return _emptyText; }
			set { _emptyText = value; }
		}

		public bool ShowExternalAccountLine
		{
			get { return _showExternalAccountLine; }
			set { _showExternalAccountLine = value; }
		}

		public int ExternalAccountValue
		{
			get { return _externalAccountValue; }
			set { _externalAccountValue = value; }
		}

		public string ExternalAccountText
		{
			get { return _externalAccountText; }
			set { _externalAccountText = value; }
		}
		
		public int SelectedAccountValue
		{
			get
			{
				int result = _emptyValue;
				if (SelectedIndex != -1)
				{
					result = int.Parse(SelectedValue);
				}
				return result;
			}
		}

		protected override void OnDataBinding (EventArgs e)
		{
			base.OnDataBinding(e);
			if (_showExternalAccountLine)
			{
				Items.Insert(0, new ListItem(_externalAccountText, _externalAccountValue.ToString()));
			}
			if (_showEmptyLine)
			{
				Items.Insert(0, new ListItem(_emptyText, _emptyValue.ToString()));
			}
		}
	}
}
