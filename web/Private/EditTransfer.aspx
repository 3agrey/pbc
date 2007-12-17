<%@ Page Language="C#" AutoEventWireup="False" MasterPageFile="~/Private/MasterPages/Private.Master" CodeBehind="EditTransfer.aspx.cs" Inherits="AIM.PBC.Web.Private.Pages.EditTransfer" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>

<asp:Content ID="c" runat="server" ContentPlaceHolderID="cph">
    <aim:Panel runat="server" Title='<%# OperationText + " " + GetLocalString("Transfer") %>' Width="740" CellPadding="0" CellSpacing="0">
		<table border="0" cellpadding="5" cellspacing="0">
			<tr>
				<td align="right">
					<%= GetLocalString("SelectTransferType") %>:
				</td>
				<td align="left">
					<asp:RadioButtonList ID="rblType" runat="server"/>
				</td>
			</tr>
			<tr>
				<td align="center" colspan="2">
					<asp:Button ID="btnSubmit" runat="server" Text='<%# GetGlobalString("ButtonNext") %>' Width="100" />
					&nbsp;&nbsp;&nbsp;
					<asp:Button ID="btnCancel" runat="server" Text='<%# GetGlobalString("ButtonCancel") %>' Width="100" CausesValidation="false" />
				</td>
			</tr>
		</table>
	</aim:Panel>
</asp:Content>