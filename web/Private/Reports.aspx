<%@ Page Language="C#" AutoEventWireup="False" MasterPageFile="~/Private/MasterPages/Private.Master" CodeBehind="Reports.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.Reports" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>

<asp:Content ID="c" runat="server" ContentPlaceHolderID="cph">
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
</asp:Content>