<%@ Page Language="C#" AutoEventWireup="False" CodeBehind="Default.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.Default" %>
<%@ Register TagPrefix="uc" TagName="Head" Src="~/Private/Controls/Head.ascx" %>
<%@ Register TagPrefix="uc" TagName="Header" Src="~/Private/Controls/Header.ascx" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="~/Private/Controls/Footer.ascx" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<html>
<uc:Head id="ctrlHead" runat="server" PageTitle='<%# GetLocalString("Title") %>' />
<body>
    <form id="theForm" runat="server">
    <uc:Header ID="ctrlHeader" runat="server" />
	<cc:Panel runat="server" Title='<%# GetLocalString("ActionsPanelTitle") %>' Width="740" CellPadding="0" CellSpacing="0">
		<table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%">
			<tr>
				<td>
					<a href="Accounts.aspx" class="link"><img src="Images/Accounts.png" class="middleImage"/><%= GetLocalString("AccountsLink") %></a>
				</td>
				<td>
					<a href="Reports.aspx" class="link"><img src="Images/Reports.png" class="middleImage"/><%= GetLocalString("ReportsLink") %></a>
				</td>
			</tr>
			<tr>
				<td>
					<a href="Transfers.aspx" class="link"><img src="Images/Transfers.png" class="middleImage"/><%= GetLocalString("TransfersLink") %></a>
				</td>
				<td>
					<a href="Charts.aspx" class="link"><img src="Images/Charts.png" class="middleImage"/><%= GetLocalString("ChartsLink") %></a>
				</td>
			</tr>
		</table>
	</cc:Panel>
    <uc:Footer ID="ctrlFooter" runat="server" />
    </form>
</body>
</html>