<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Presentation_Index" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
 <%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Launching Page.</title>
</head>

<body>
<form runat="server">
    <asp:LinkButton ID="lnlTest" runat="server" PostBackUrl="../Presentation/Login.aspx" Text="Click To Test"></asp:LinkButton>
<p><a href="javascript:void(0)" onclick="javascript:window.open('Login.aspx','WinApp','channelmode=yes,fullscreen=yes')">Click to launch application</a></p>
<p>&nbsp;</p>
</form>
</body>
</html>
