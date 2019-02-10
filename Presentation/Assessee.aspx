<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Assessee.aspx.cs" Inherits="Presentation_Assessee" %>

<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %> 
<%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Control Panel</title>
    <link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />
    <script type="text/javascript" src="../scripts/menu.js"></script>
    <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 00px;
	margin-bottom: 00px;
}
a
{
text-decoration:none;
color: #215DC6;
}

a:hover
{
text-decoration:none;
color: #40ACF4;
}
.style1 {
	color: #215DC6;
	font-family: Arial, Helvetica, sans-serif;
	font-weight: bold;
	font-size: 12px;
}
-->

</style>

 <link href="../foundation/css/foundation.min.css" rel="stylesheet" />
    <script src="../foundation/js/foundation.min.js"></script>
</head>
<body onload="P7_ExpMenu()">
    <table width="100%" border="0" cellspacing="00" cellpadding="00">
        <tr>
            <td colspan="2">
                <%
    if(Session["ay"]!=null)
    {
    %>

<main:mainmenu ID="mm1" runat="server" />
<%
    }
    else
    {
    %>

<main2:mainmenu2 ID="mm12" runat="server" />
<%
    }
    %>
            </td>
        </tr>
        <tr>
            <td width="21%" height="650" valign="top" bgcolor="#6D89DD">
                <sub:submenu ID="sub1" runat="server" />
            </td>
            <td width="79%" valign="top">
                <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div>
                            &nbsp;
                        </div>
                        <asp:MultiView ID="mltView" ActiveViewIndex="0" runat="server">
                            <asp:View ID="viewList" runat="server">
                                <table cellspacing="3" cellpadding="0" style="width: 780; height: 147" align="center"
                                    border="0">
                                    <tr>
                                        <td valign="top" align="center" bgcolor="#ffffff" height="478px" style="width: 581px">
                                            <p class="heading">
                                                <table id="Table3" cellspacing="1" cellpadding="2" border="0" style="width: 135%">
                                                    <tr>
                                                        <td bgcolor="#ffffff" style="height: 19px; width: 809px;" colspan="1">
                                                            <font>&nbsp;</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 22px; width: 809px;" align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 809px; height: 22px">
                                                            &nbsp;<br />
                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        </div>
                                                        <tr>
                                                            <td valign="top" align="left" bgcolor="#ffffff" colspan="1" style="width: 581px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                        </td>
                                    </tr>
                                </table>
                                </table> </p> </td> </tr>
                            </asp:View>
                        </asp:MultiView>
                        &nbsp;&nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
                &nbsp; &nbsp;
                </form>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</body>
</html>
