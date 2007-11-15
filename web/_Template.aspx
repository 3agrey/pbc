<%@ Page Language="C#" AutoEventWireup="False" CodeBehind="_Template.aspx.cs" Inherits="AIM.PBC.Web.Pages._Template" %>
<%@ Register TagPrefix="uc" TagName="Head" Src="~/Controls/Head.ascx" %>
<%@ Register TagPrefix="uc" TagName="Header" Src="~/Controls/Header.ascx" %>
<%@ Register TagPrefix="uc" TagName="Footer" Src="~/Controls/Footer.ascx" %>
<%@ Register TagPrefix="cc" Namespace="AIM.PBC.Web.UI.Controls" Assembly="AIM.PBC.Web" %>
<html>
<uc:Head ID="ctrlHead" runat="server" PageTitle="TITLE" />
<body>
    <form id="theForm" runat="server">
    <uc:Header ID="ctrlHeader" runat="server" />
    <uc:Footer ID="ctrlFooter" runat="server" />
    </form>
</body>
</html>