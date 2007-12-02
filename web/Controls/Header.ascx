<%@ Control Language="C#" AutoEventWireup="false" Inherits="AIM.PBC.Web.Controls.Header" Codebehind="Header.ascx.cs" %>
<%@ Import namespace="AIM.PBC.Web"%>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
	<tr>
		<td align="center">
			<table width="780" cellpadding="0" cellspacing="0" border="0">
				<tr>
					<td class="pageEdge_UL"><img runat="server" src="~/Images/spacer.gif" /></td>
					<td class="pageEdge_U"><img runat="server" src="~/Images/spacer.gif" /></td>
					<td class="pageEdge_UR"><img runat="server" src="~/Images/spacer.gif" /></td>
				</tr>
				<tr>
					<td class="pageEdge_L"></td>
					<td class="pageEdge_C" style="height: 100px" align="right" valign="top">
						<cc:MenuBar ID="mbMainMenu" runat="server">
							<Items>
								<cc:MenuItem Text="Home" Url="Default.aspx" />
								<cc:MenuItem Text="Help" Url="Help.aspx" />
								<cc:MenuItem Text="About Us" Url="AboutUs.aspx" />
								<cc:MenuItem Text="Login" Url="Private/Login.aspx" />
							</Items>
						</cc:MenuBar>
					</td>
					<td class="pageEdge_R"></td>
				</tr>
				<tr>
					<td class="pageEdge_L"></td>
					<td class="pageEdge_C" align="center">