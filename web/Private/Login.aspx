<%@ Page Language="C#" AutoEventWireup="False" MasterPageFile="~/Private/MasterPages/Private.Master" Inherits="AIM.PBC.Web.Private.Pages.Login" Codebehind="Login.aspx.cs" %>
<%@ Import namespace="AIM.PBC.Web"%>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>

<asp:Content ID="c" runat="server" ContentPlaceHolderID="cph">
	<cc:ClientMessage ID="ctrlClientMessage" Runat="server" IsRenderNewLine="true" Width="400" />
	<aim:Panel runat="server" Title="Login" Width="400" CellPadding="0" CellSpacing="0">
		<br />
		<img src="Images/Locked.png" />
		<br /><br />
		<table border="0">
			<tr>
				<td align="right">Username:</td>
				<td align="left"><asp:TextBox ID="tbUsername" runat="server" Width="200" CssClass="input" /></td>
			</tr>
			<tr>
				<td align="right">Password:</td>
				<td align="left"><asp:TextBox ID="tbPassword" runat="server" Width="200" TextMode="password" CssClass="input" /></td>
			</tr>
			<tr>
				<td colspan="2" align="center">
					<asp:CheckBox ID="cbPersistent" runat="server" Text="Remember me" />
				</td>
			</tr>
			<tr>
				<td colspan="2" align="center">
					<asp:Button ID="btnSubmit" runat="server" Text="Submit" />
					<br /><br />
				</td>
			</tr>
			<tr>
				<td colspan="2" align="right">
					<a href="Register.aspx" class="link">Have not got an account yet?</a>
				</td>
			</tr>
			<tr>
				<td colspan="2" align="right">
					<a href="ForgotPassword.aspx" class="link">Forgot password?</a>
				</td>
			</tr>
		</table>
	</aim:Panel>
	<br />
	<asp:PlaceHolder ID="phDebugLogin" runat="server" Visible='<%# Settings.IsDebug %>'>
	<aim:Panel ID="pnlDebugLogin" runat="server" Mode="Gray" Width="400">
	<a href="#" class="link" onclick="DebugLogin('test', '1', 'on')">test</a>
	<br />
	</aim:Panel>
	</asp:PlaceHolder>
<script language="javascript">
function FocusUsernameBox ()
{
	var oUsername = document.getElementById("<%= tbUsername.ClientID %>");
	oUsername.focus();
}
function DebugLogin (username, password, persistent)
{
	var oUsername = document.getElementById("<%= tbUsername.ClientID %>");
	var oPassword = document.getElementById("<%= tbPassword.ClientID %>");
	var oPersistent = document.getElementById("<%= cbPersistent.ClientID %>");
	var oSubmit = document.getElementById("<%= btnSubmit.ClientID %>");
	
	oUsername.value = username;
	oPassword.value = password;
	oPersistent.checked = persistent;
	oSubmit.click();
}
</script>
</asp:Content>