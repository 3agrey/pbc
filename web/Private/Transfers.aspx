<%@ Page Language="C#" AutoEventWireup="False" MasterPageFile="~/Private/MasterPages/Private.Master" CodeBehind="Transfers.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.Transfers" %>
<%@ Import namespace="AIM.PBC.Web.Private.Pages"%>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>

<asp:Content ID="c" runat="server" ContentPlaceHolderID="cph">
    <cc:Panel runat="server" Title="Transfers" Width="740" CellPadding="0" CellSpacing="0">
		<table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%">
		<asp:Repeater ID="rpTransfers" runat="server">
			<ItemTemplate>
			<tr>
				<td>
					<a href="EditTransfer.aspx?<%= EditTransfer.PageParameters.TransferId %>=<%# Eval("Id") %>" class="link"><%# Eval("Name") %></a>
				</td>
			</tr>
			</ItemTemplate>
		</asp:Repeater>
		<asp:PlaceHolder ID="phEmpty" runat="server" Visible="false">
			<tr>
				<td>
					<span class="message">No transfers founded. Please press 'Add New Transfer' to start.</span>
				</td>
			</tr>
		</asp:PlaceHolder>
			<tr>
				<td align="center">
					<asp:Button ID="btnAdd" runat="server" Text="Add New Transfer" Width="200" CausesValidation="false" />
					&nbsp;&nbsp;&nbsp;
					<asp:Button ID="btnGoHome" runat="server" Text="Back to Home Page" Width="200" CausesValidation="false" />
				</td>
			</tr>
		</table>
    </cc:Panel>
</asp:Content>