<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmGenerateXML.aspx.cs" Inherits="frmGenerateXML" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript">
    window.onload = function () {
        var seconds = 5;
        setTimeout(function () {
           document.getElementById("<%=lblmsg.ClientID %>").style.display = "none";
        }, seconds * 1000);
    };
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        <asp:Label ID="lblmsg" runat="server" Visible="False"></asp:Label>
    </div>
    </form>
</body>
</html>
