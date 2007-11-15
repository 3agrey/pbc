<%@ Page Language="C#" AutoEventWireup="False" CodeBehind="EditAccount.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.EditAccount" %>
<%@ Register TagPrefix="uc" TagName="Head" Src="~/Private/Controls/Head.ascx" %>
<%@ Register TagPrefix="uc" TagName="Header" Src="~/Private/Controls/Header.ascx" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="~/Private/Controls/Footer.ascx" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadCalendar.NET2" %>
<html>
<uc:Head ID="ctrlHead" runat="server" PageTitle='<%# OperationText + " Account" %>' />
<body>
    <form id="theForm" runat="server">
    <uc:Header ID="ctrlHeader" runat="server" />
	<cc:ClientMessage ID="ctrlClientMessage" Runat="server" IsRenderNewLine="true" Width="740" />
	<asp:CustomValidator ID="cvPage" runat="server" Display="None" />
	<cc:Panel runat="server" Title='<%# OperationText + " Account"%>' Width="740" CellPadding="0" CellSpacing="0">
		<table border="0" cellpadding="5" cellspacing="0">
			<tr>
				<td align="right">
					Name:
				</td>
				<td align="left">
					<asp:TextBox ID="tbName" runat="server" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="right">
					Beginning Balance:
				</td>
				<td align="left">
					<asp:TextBox ID="tbBeginningBalance" runat="server" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="right">
					Beginning Balance Date:
				</td>
				<td align="left">
					<rad:RadDatePicker ID="dpBeginningBalanceDate" runat="server">
						<DateInput Skin="Outlook" SkinsPath="~/RadControls/Input"
							Width="200"
						/>
						<Calendar Skin="Outlook" SkinsPath="~/RadControls/Calendar"
							UseWeekNumbersAsSelectors="false"
						/>
					</rad:RadDatePicker>
				</td>
			</tr>
			<asp:PlaceHolder ID="phAddMode" runat="server">
			<tr>
				<td align="center" colspan="2">
					<asp:Button ID="btnAddSubmit" runat="server" Text="Add" Width="100" />
					&nbsp;&nbsp;&nbsp;
					<asp:Button ID="btnAddCancel" runat="server" Text="Cancel" Width="100" CausesValidation="false" />
				</td>
			</tr>
			</asp:PlaceHolder>
			<asp:PlaceHolder ID="phEditMode" runat="server">
			<tr>
				<td align="center" colspan="2">
					<asp:Button ID="btnEditSubmit" runat="server" Text="Update" Width="100" />
					&nbsp;&nbsp;&nbsp;
					<asp:Button ID="btnEditCancel" runat="server" Text="Cancel" Width="100" CausesValidation="false" />
				</td>
			</tr>
			</asp:PlaceHolder>
		</table>
	</cc:Panel>
    <uc:Footer ID="ctrlFooter" runat="server" />
    </form>
</body>
</html>