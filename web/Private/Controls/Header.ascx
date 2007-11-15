<%@ Control Language="C#" AutoEventWireup="false" Inherits="AIM.PBC.Web.Private.Controls.Header" Codebehind="Header.ascx.cs" %>
<%@ Import namespace="AIM.PBC.Web"%>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
	<tr>
		<td align="center">
			<table width="780" cellpadding="0" cellspacing="0" border="0">
				<tr>
					<td class="pageEdge_UL"><img src="Images/spacer.gif" /></td>
					<td class="pageEdge_U"><img src="Images/spacer.gif" /></td>
					<td class="pageEdge_UR"><img src="Images/spacer.gif" /></td>
				</tr>
				<tr>
					<td class="pageEdge_L"></td>
					<td class="pageEdge_C" style="height: 65px" align="right" valign="top">
						<cc:MenuBar ID="mbPrivateMenu" runat="server" Visible='<%# SessionManager.IsAuthenticated %>'>
							<Items>
								<cc:MenuItem Text="Home Page" Url="Default.aspx" />
								<cc:MenuItem Text="Logout" Url="Logout.aspx" />
							</Items>
						</cc:MenuBar>
						<cc:MenuBar ID="mbPublicMenu" runat="server" Visible='<%# !SessionManager.IsAuthenticated %>'>
							<Items>
								<cc:MenuItem Text="Home" Url="../Default.aspx" />
								<cc:MenuItem Text="Help" Url="../Help.aspx" />
								<cc:MenuItem Text="About Us" Url="../AboutUs.aspx" />
								<cc:MenuItem Text="Login" Url="Private/Login.aspx" />
							</Items>
						</cc:MenuBar>
						<asp:PlaceHolder ID="phWelcome" runat="server" Visible='<%# SessionManager.IsAuthenticated %>'>
						<br />
						<b>Welcome, <%= UserFullname%></b>
						</asp:PlaceHolder>
					</td>
					<td class="pageEdge_R"></td>
				</tr>
				<tr>
					<td class="pageEdge_L"></td>
					<td class="pageEdge_C" align="center">