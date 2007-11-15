<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="AIM.PBC.Web.Pages.Default" %>
<%@ Register TagPrefix="uc" TagName="Head" Src="~/Controls/Head.ascx" %>
<%@ Register TagPrefix="uc" TagName="Header" Src="~/Controls/Header.ascx" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="~/Controls/Footer.ascx" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<html>
<uc:Head id="ctrlHead" runat="server" PageTitle="Home Page" />
<body>
    <form id="theForm" runat="server">
    <uc:Header ID="ctrlHeader" runat="server" />
    <uc:Footer ID="ctrlFooter" runat="server" />
    </form>
</body>
</html>