<%@ Page Language="C#" AutoEventWireup="False" MasterPageFile="~/Private/MasterPages/Private.Master" CodeBehind="Charts.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.Charts" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>

<asp:Content ID="c" runat="server" ContentPlaceHolderID="cph">
	<cc:Panel runat="server" Title="Charts" Width="740" CellPadding="0" CellSpacing="0">
		<table border="0" cellpadding="5" cellspacing="0" style="width: 100%; height: 100%">
			<tr>
				<td>
					<a href="ChartByAccounts.aspx" class="link"><img src="Images/ChartByAccounts.png" class="middleImage"/>View Chart by Accounts</a>
				</td>
			</tr>
		</table>
    </cc:Panel>
</asp:Content>