<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PANLIST.aspx.cs" Inherits="PANLIST" %>

<%@ Register Assembly="controlgrid" Namespace="controlgrid" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="tool1" runat="server"></ajaxToolkit:ToolkitScriptManager>
    <div>
    <asp:UpdatePanel ID="too" runat="server">
    <ContentTemplate>
    <cc1:DynamicControl ID="dny_Grd_PAN" runat="server" GridName="grd_PAN" Page_ID="532" Page_SubModule_ID="58"/>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
