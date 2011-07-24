<%@ Page Language="C#" AutoEventWireup="False" MasterPageFile="~/Private/MasterPages/Private.Master" CodeBehind="Register.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.Register" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>

<asp:Content ID="c" runat="server" ContentPlaceHolderID="cph">
	<cc:ClientMessage ID="ctrlClientMessage" Runat="server" IsRenderNewLine="true" Width="740" />
	<asp:CustomValidator ID="cvPage" runat="server" Display="None" />
    <aim:Panel runat="server" Title="Register new user" Width="740" CellPadding="0" CellSpacing="0">
		<table border="0" cellpadding="5" cellspacing="0">
			<tr>
				<td align="right">
					Username:
				</td>
				<td class="required">*</td>
				<td align="left">
					<asp:TextBox ID="tbUsername" runat="server" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="right">
					Password:
				</td>
				<td class="required">*</td>
				<td align="left">
					<asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="right">
					Confirm:
				</td>
				<td class="required">*</td>
				<td align="left">
					<asp:TextBox ID="tbConfirm" runat="server" TextMode="Password" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="right">
					Firstname:
				</td>
				<td>&nbsp;</td>
				<td align="left">
					<asp:TextBox ID="tbFirstname" runat="server" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="right">
					Lastname:
				</td>
				<td>&nbsp;</td>
				<td align="left">
					<asp:TextBox ID="tbLastname" runat="server" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="right">
					Email:
				</td>
				<td>&nbsp;</td>
				<td align="left">
					<asp:TextBox ID="tbEmail" runat="server" Width="200" CssClass="input" />
				</td>
			</tr>
			<tr>
				<td align="center" colspan="3">
					<asp:Button ID="btnSubmit" runat="server" Text="Register" Width="100" />
					&nbsp;&nbsp;&nbsp;
					<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100" CausesValidation="false" />
				</td>
			</tr>
		</table>
    </aim:Panel>
</asp:Content>