<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="ReportByAccounts.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.ReportByAccounts" %>
<%@ Register TagPrefix="uc" TagName="Head" Src="~/Private/Controls/Head.ascx" %>
<%@ Register TagPrefix="uc" TagName="Header" Src="~/Private/Controls/Header.ascx" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="~/Private/Controls/Footer.ascx" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<html>
<uc:Head ID="ctrlHead" runat="server" PageTitle="Report by Accounts" />
<body>
    <form id="theForm" runat="server">
    <uc:Header ID="ctrlHeader" runat="server" />
    <cc:Panel runat="server" Title="Report by Transactions" Width="740" CellPadding="0" CellSpacing="0">
		<br />
		<cc:HtmlPivotGrid id="pgReport" runat="server" CellPadding="3" CellSpacing="0" Width="100%" />
		<br />
    </cc:Panel>
    <uc:Footer ID="ctrlFooter" runat="server" />
    </form>
</body>
</html>