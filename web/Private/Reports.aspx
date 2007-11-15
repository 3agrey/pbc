<%@ Page Language="C#" AutoEventWireup="False" CodeBehind="Reports.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.Reports" %>
<%@ Register TagPrefix="uc" TagName="Head" Src="~/Private/Controls/Head.ascx" %>
<%@ Register TagPrefix="uc" TagName="Header" Src="~/Private/Controls/Header.ascx" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="~/Private/Controls/Footer.ascx" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<html>
<uc:Head ID="ctrlHead" runat="server" PageTitle='<%# GetLocalString("Title") %>' />
<body>
	<form id="theForm" runat="server">
	<uc:Header ID="ctrlHeader" runat="server" />
	<cc:Panel runat="server" Title='<%# GetLocalString("ReportsPanelTitle") %>' Width="740" CellPadding="0" CellSpacing="0">
		<table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%">
			<tr>
				<td>
					<a href="ReportByTransactions.aspx" class="link"><img src="Images/ReportByTransactions.png" class="middleImage"/><%= GetLocalResourceObject("TransactionsReportLink") %></a>
				</td>
				<td>
					<a href="ReportByAccounts.aspx" class="link"><img src="Images/ReportByAccounts.png" class="middleImage"/><%= GetLocalResourceObject("AccountsReportLink") %></a>
				</td>
			</tr>
		</table>
    </cc:Panel>
    <uc:Footer ID="ctrlFooter" runat="server" />
    </form>
</body>
</html>