<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BrowserClose.aspx.cs" Inherits="BrowserClose" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script language="javascript" type="text/javascript">
  //<![CDATA[
    function HandleClose() {
       alert("Killing the session on the server!!");
       //PageMethods.AbandonSession();
    }
   //]]>
</script>
<head runat="server">
    <title></title>
</head>
<body onunload="HandleClose(0)">
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div>
        <asp:HiddenField ID="hdnSession" runat="server"></asp:HiddenField>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
