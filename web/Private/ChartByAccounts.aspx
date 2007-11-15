<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="ChartByAccounts.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.ChartByAccounts" %>
<%@ Register TagPrefix="uc" TagName="Head" Src="~/Private/Controls/Head.ascx" %>
<%@ Register TagPrefix="uc" TagName="Header" Src="~/Private/Controls/Header.ascx" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="~/Private/Controls/Footer.ascx" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadChart.Net2" %>
<html>
<uc:Head ID="ctrlHead" runat="server" PageTitle="Report by Accounts" />
<body>
    <form id="theForm" runat="server">
    <uc:Header ID="ctrlHeader" runat="server" />
    <cc:Panel runat="server" Title="Chart by Accounts" Width="740" CellPadding="0" CellSpacing="0">
		<br />
		<rad:RadChart id="rcReport" runat="server" Width="720" Height="540" />
		<br />
    </cc:Panel>
    <uc:Footer ID="ctrlFooter" runat="server" />
    </form>
</body>
</html>