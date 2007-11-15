<%@ Page Language="C#" AutoEventWireup="False" CodeBehind="AccessDenied.aspx.cs" Inherits="AIM.PBC.Web.Pages.CustomErrors.AccessDenied" %>
<%@ Register TagPrefix="uc" TagName="Head" Src="~/Controls/Head.ascx" %>
<%@ Register TagPrefix="uc" TagName="Header" Src="~/Controls/Header.ascx" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="~/Controls/Footer.ascx" %>
<html>
<uc:Head ID="ctrlHead" runat="server" PageTitle="Access Denied" />
<body>
    <form id="theForm" runat="server">
    <uc:Header ID="ctrlHeader" runat="server" />
    <span class="error">Sorry. You do not have permissions to view this page.</span>
    <uc:Footer ID="ctrlFooter" runat="server" />
    </form>
</body>
</html>