<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Private/MasterPages/Private.Master" CodeBehind="ChartByAccounts.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.ChartByAccounts" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadChart.Net2" %>

<asp:Content ID="c" runat="server" ContentPlaceHolderID="cph">
    <cc:Panel runat="server" Title="Chart by Accounts" Width="740" CellPadding="0" CellSpacing="0">
		<br />
		<rad:RadChart id="rcReport" runat="server" Width="720" Height="540" />
		<br />
    </cc:Panel>
</asp:Content>