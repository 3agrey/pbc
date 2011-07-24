<%@ Page Language="C#" AutoEventWireup="False" MasterPageFile="~/Private/MasterPages/Private.Master" CodeBehind="Accounts.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.Accounts" %>
<%@ Import namespace="AIM.PBC.Web.Private.Pages"%>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>

<asp:Content ID="c" runat="server" ContentPlaceHolderID="cph">
    <aim:Panel runat="server" Title='<%# GetLocalString("AccountsPanelTitle") %>' Width="740" CellPadding="0" CellSpacing="0">
		<table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%">
		<asp:Repeater ID="rpAccounts" runat="server">
			<ItemTemplate>
			<tr>
				<td>
					<a href="EditAccount.aspx?<%= EditAccount.PageParameters.AccountId %>=<%# Eval("Id") %>" class="link"><%# Eval("Name") %></a>
				</td>
			</tr>		
			</ItemTemplate>
		</asp:Repeater>
		<asp:PlaceHolder ID="phEmpty" runat="server" Visible="false">
			<tr>
				<td>
					<span class="message"><%= GetLocalString("NoAccounts") %></span>
				</td>
			</tr>
		</asp:PlaceHolder>
			<tr>
				<td align="center">
					<asp:Button ID="btnAdd" runat="server" Text='<%# GetGlobalString("ButtonAdd") %>' Width="200" CausesValidation="false" />
					&nbsp;&nbsp;&nbsp;
					<asp:Button ID="btnGoHome" runat="server" Text='<%# GetGlobalString("ButtonCancel") %>' Width="200" CausesValidation="false" />
				</td>
			</tr>
		</table>
    </aim:Panel>
</asp:Content>