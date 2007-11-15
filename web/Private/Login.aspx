<%@ Page Language="C#" AutoEventWireup="False" Inherits="AIM.PBC.Web.Private.Pages.Login" Codebehind="Login.aspx.cs" %>
<%@ Import namespace="AIM.PBC.Web"%>
<%@ Register TagPrefix="uc" TagName="Head" Src="~/Private/Controls/Head.ascx" %>
<%@ Register TagPrefix="uc" TagName="Header" Src="~/Private/Controls/Header.ascx" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="~/Private/Controls/Footer.ascx" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<html>
<uc:Head ID="ctrlHead" runat="server" PageTitle="Login" />
<body onload="FocusUsernameBox()">
    <form id="theForm" runat="server">
	<uc:Header ID="ctrlHeader" runat="server" />
	<br />
	<cc:ClientMessage ID="ctrlClientMessage" Runat="server" IsRenderNewLine="true" Width="400" />
	<cc:Panel runat="server" Title="Login" Width="400" CellPadding="0" CellSpacing="0">
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
	</cc:Panel>
	<br />
	<asp:PlaceHolder ID="phDebugLogin" runat="server" Visible='<%# Settings.IsDebug %>'>
	<cc:Panel ID="pnlDebugLogin" runat="server" Mode="Gray" Width="400">
	<a href="#" class="link" onclick="DebugLogin('codec', '1', 'on')">codec</a>
	&nbsp;|&nbsp;
	<a href="#" class="link" onclick="DebugLogin('test', '1', 'on')">test</a>
	<br />
	</cc:Panel>
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
	<uc:Footer ID="ctrlFooter" runat="server" />
    </form>
</body>
</html>
