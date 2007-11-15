<%@ Page Language="C#" AutoEventWireup="False" CodeBehind="EditDepositTransfer.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.EditDepositTransfer" %>
<%@ Register TagPrefix="uc" TagName="Head" Src="~/Private/Controls/Head.ascx" %>
<%@ Register TagPrefix="uc" TagName="Header" Src="~/Private/Controls/Header.ascx" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="~/Private/Controls/Footer.ascx" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadCalendar.NET2" %>
<html>
<uc:Head ID="ctrlHead" runat="server" PageTitle='<%# OperationText + " " + GetGlobalString("TransferDeposit") %>'/>
<body>
    <form id="theForm" runat="server">
    <uc:Header ID="ctrlHeader" runat="server" />
    <cc:ClientMessage ID="ctrlClientMessage" Runat="server" IsRenderNewLine="true" Width="740" />
	<asp:CustomValidator ID="cvPage" runat="server" Display="None" />
	<cc:Panel runat="server" Title='<%# OperationText + " " + GetGlobalString("TransferDeposit") %>' Width="740" CellPadding="0" CellSpacing="0">
		<table border="0" cellpadding="5" cellspacing="0">
			<tr>
				<td align="right">
					<%= GetLocalString("SourceAccount") %>:
				</td>
				<td align="left">
					<cc:AccountDropDownList ID="ddlSourceAccount" runat="server" Width="200" CssClass="input" ShowEmptyLine="true" />
				</td>
			</tr>
			<tr>
				<td align="right">
					<%= GetLocalString("TargetAccount") %>:
				</td>
				<td align="left">
					<cc:AccountDropDownList ID="ddlTargetAccount" runat="server" Width="200" CssClass="input" ShowEmptyLine="true" />
				</td>
			</tr>
			<tr>
				<td align="right">
					<%= GetLocalString("TransferName") %>:
				</td>
				<td align="left">
					<asp:TextBox ID="tbName" runat="server" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="right">
					<%= GetLocalString("BeginningAmount") %>:
				</td>
				<td align="left">
					<asp:TextBox ID="tbBeginningAmount" runat="server" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="right"><%= GetLocalString("TransferPercentage")%>:</td>
				<td>
					<asp:TextBox ID="tbPercentage" runat="server" Width="200" CssClass="input"/>
				</td>
			</tr>
			<tr>
				<td align="right">
					<%= GetLocalString("TransferStartDate")%>:
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
				<td align="right"><%= GetLocalString("TransferPeriod") %>:</td>
				<td>
					<asp:TextBox ID="tbPeriod" runat="server" Width="200" CssClass="input"/>
				</td>
			</tr>
			<tr>
				<td align="right">
					<%= GetLocalString("IncrementAmount") %>:
				</td>
				<td align="left">
					<asp:TextBox ID="tbIncrementAmount" runat="server" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="right"><%= GetLocalString("IncrementPeriodType") %>:</td>
				<td>
					<asp:RadioButtonList ID="rblIncrementPeriodType" runat="server"/>
				</td>
			</tr>
			<tr id="trStandardPeriod" runat="server">
				<td align="right"><%= GetLocalString("IncrementStandardPeriod") %>:</td>
				<td>
					<asp:RadioButtonList ID="rblIncrementStandardPeriod" runat="server"/>
				</td>
			</tr>
			<tr id="trCustomPeriod" runat="server">
				<td align="right"><%= GetLocalString("IncrementCustomPeriod") %>:</td>
				<td>
					<asp:TextBox ID="tbIncrementCustomPeriod" runat="server" Width="200" CssClass="input"/>
				</td>
			</tr>
			<asp:PlaceHolder ID="phAddMode" runat="server">
			<tr>
				<td align="center" colspan="2">
					<asp:Button ID="btnAddSubmit" runat="server" Text='<%# GetGlobalString("ButtonAdd") %>' Width="100" />
					&nbsp;&nbsp;&nbsp;
					<asp:Button ID="btnAddCancel" runat="server" Text='<%# GetGlobalString("ButtonCancel") %>' Width="100" CausesValidation="false" />
				</td>
			</tr>
			</asp:PlaceHolder>
			<asp:PlaceHolder ID="phEditMode" runat="server">
			<tr>
				<td align="center" colspan="2">
					<asp:Button ID="btnUpdateSubmit" runat="server" Text='<%# GetGlobalString("ButtonUpdate") %>' Width="100" />
					&nbsp;&nbsp;&nbsp;
					<asp:Button ID="btnUpdateCancel" runat="server" Text='<%# GetGlobalString("ButtonCancel") %>' Width="100" CausesValidation="false" />
				</td>
			</tr>
			</asp:PlaceHolder>
		</table>
	</cc:Panel>
    <uc:Footer ID="ctrlFooter" runat="server" />
    </form>
    <script language="javascript" >
		function SelectCustomPeriod()
		{
			var oRowStandardPeriod = document.getElementById("trStandardPeriod");
			var oRowCustomPeriod = document.getElementById("trCustomPeriod");
			oRowStandardPeriod.style.display = "none";
			oRowCustomPeriod.style.display = "";
		}
		
		function SelectStandardPeriod()
		{
			var oRowStandardPeriod = document.getElementById("trStandardPeriod");
			var oRowCustomPeriod = document.getElementById("trCustomPeriod");
			oRowCustomPeriod.style.display = "none";
			oRowStandardPeriod.style.display = "";
		}
    </script>
</body>
</html>