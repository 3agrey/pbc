<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Private/MasterPages/Private.Master" CodeBehind="ReportByAccounts.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.ReportByAccounts" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>

<asp:Content ID="c" runat="server" ContentPlaceHolderID="cph">
    <aim:Panel runat="server" Title="Report by Transactions" Width="740" CellPadding="0" CellSpacing="0">
		<br />
		<cc:HtmlPivotGrid id="pgReport" runat="server" CellPadding="3" CellSpacing="0" Width="100%" />
		<br />
    </aim:Panel>
</asp:Content>