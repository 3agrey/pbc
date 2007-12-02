using System;
using AIM.PBC.Core;
using AIM.PBC.Web.UI.Controls;

namespace AIM.PBC.Web.Private.Pages
{
	public partial class Register : BasePage
	{
		protected override void OnInit (EventArgs e)
		{
			base.OnInit(e);
			RegisterEventHandlers();
		}


		public override string PageTitle
		{
			get { return "Register new user"; }
		}

		private void RegisterEventHandlers ()
		{
			cvPage.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(cvPage_ServerValidate);
			btnSubmit.Click += new EventHandler(btnSubmit_Click);
			btnCancel.Click += new EventHandler(btnCancel_Click);
		}

		private void cvPage_ServerValidate (object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			// username
			if (tbUsername.Text.Length == 0)
			{
				ctrlClientMessage.Messages.Add("Username is required");
			}

			// password and confirm
			if (tbUsername.Text.Length == 0)
			{
				ctrlClientMessage.Messages.Add("Password is required");
			}
			if (tbConfirm.Text.Length == 0)
			{
				ctrlClientMessage.Messages.Add("Confirm is required");
			}
			if (tbPassword.Text != tbConfirm.Text)
			{
				ctrlClientMessage.Messages.Add("Password and Confirm should be equal");
			}

			bool isValid = (ctrlClientMessage.Messages.Count == 0);
			if (!isValid)
			{
				ctrlClientMessage.ShowListMessages("There are some errors in the form:", ClientMessageTypes.Error);
			}
			args.IsValid = isValid;
		}
		
		private void btnSubmit_Click (object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				User entity = new User();
				entity.Username = tbUsername.Text;
				entity.Password = tbPassword.Text;
				entity.Firstname = tbFirstname.Text;
				entity.Lastname = tbLastname.Text;
				entity.Email = tbEmail.Text;
				int id = UserProvider.Add(entity);
				if (id == 0)
				{
					// username already exists
					ctrlClientMessage.ShowSingleMessage("Username you choosen is in use", ClientMessageTypes.Error);
				}
				else
				{
					SessionManager.Login(entity.Username, entity.Password, false, true);
				}
			}
		}

		private void btnCancel_Click (object sender, EventArgs e)
		{
			Response.Redirect("Login.aspx");
		}
	}
}
