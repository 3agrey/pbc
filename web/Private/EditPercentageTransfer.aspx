<%@ Page Language="C#" AutoEventWireup="False" MasterPageFile="~/Private/MasterPages/Private.Master" CodeBehind="EditPercentageTransfer.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.EditPercentageTransfer" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadCalendar.NET2" %>

<asp:Content ID="c" runat="server" ContentPlaceHolderID="cph">
    <cc:ClientMessage ID="ctrlClientMessage" Runat="server" IsRenderNewLine="true" Width="740" />
	<asp:CustomValidator ID="cvPage" runat="server" Display="None" />
	<cc:Panel runat="server" Title='<%# OperationText + " Percentage Transfer"%>' Width="740" CellPadding="0" CellSpacing="0">
		<table border="0" cellpadding="5" cellspacing="0">
			<tr>
				<td align="right">
					Source Account (From):
				</td>
				<td align="left">
					<cc:AccountDropDownList ID="ddlSourceAccount" runat="server" Width="200" CssClass="input" ShowEmptyLine="true" />
				</td>
			</tr>
			<tr>
				<td align="right">
					Target Account (To):
				</td>
				<td align="left">
					<cc:AccountDropDownList ID="ddlTargetAccount" runat="server" Width="200" CssClass="input" ShowEmptyLine="true" />
				</td>
			</tr>
			<tr>
				<td align="right">
					Transfer Name:
				</td>
				<td align="left">
					<asp:TextBox ID="tbName" runat="server" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="right">
					Transfer Amount:
				</td>
				<td align="left">
					<asp:TextBox ID="tbAmount" runat="server" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="right">Transfer Percentage (in Year):</td>
				<td>
					<asp:TextBox ID="tbPercentage" runat="server" Width="200" CssClass="input"/>
				</td>
			</tr>
			<tr>
				<td align="right">
					Start Date:
				</td>
				<td align="left">
					<rad:RadDatePicker ID="dpStartDate" runat="server">
						<DateInput Skin="Outlook" SkinsPath="~/RadControls/Input"
							Width="200"
						/>
						<Calendar Skin="Outlook" SkinsPath="~/RadControls/Calendar"
							UseWeekNumbersAsSelectors="false"
						/>
					</rad:RadDatePicker>
				</td>
			</tr>
			<tr>
				<td align="right">Transfer Period (Months):</td>
				<td>
					<asp:TextBox ID="tbPeriod" runat="server" Width="200" CssClass="input"/>
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
</asp:Content>