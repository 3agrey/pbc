<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/Private/MasterPages/Private.Master" CodeBehind="ReportByTransactions.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.ReportByTransactions" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>

<asp:Content ID="c" runat="server" ContentPlaceHolderID="cph">
    <cc:Panel runat="server" Title='<%# GetLocalString("ReportPanelTitle") %>' Width="740" CellPadding="0" CellSpacing="0">
		<br />
		<asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" CellPadding="3" CellSpacing="0" Width="100%">
			<RowStyle HorizontalAlign="center" />
		</asp:GridView>
		<br />
    </cc:Panel>
</asp:Content>