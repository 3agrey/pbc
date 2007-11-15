<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="ReportByTransactions.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.ReportByTransactions" %>
<%@ Register TagPrefix="uc" TagName="Head" Src="~/Private/Controls/Head.ascx" %>
<%@ Register TagPrefix="uc" TagName="Header" Src="~/Private/Controls/Header.ascx" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="~/Private/Controls/Footer.ascx" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<html>
<uc:Head ID="ctrlHead" runat="server" PageTitle='<%# GetLocalString("Title") %>' />
<body>
    <form id="theForm" runat="server">
    <uc:Header ID="ctrlHeader" runat="server" />
    <cc:Panel runat="server" Title='<%# GetLocalString("ReportPanelTitle") %>' Width="740" CellPadding="0" CellSpacing="0">
		<br />
		<asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" CellPadding="3" CellSpacing="0" Width="100%">
			<RowStyle HorizontalAlign="center" />
		</asp:GridView>
		<br />
    </cc:Panel>
    <uc:Footer ID="ctrlFooter" runat="server" />
    </form>
</body>
</html>