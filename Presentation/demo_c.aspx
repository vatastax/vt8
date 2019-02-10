<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="demo_c.aspx.cs" Inherits="demo_c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:Label ID="lblmsg" runat="server" Font-Bold="True" 
	ForeColor="Red" Text=""></asp:Label>
         <br />
    </div>
    <asp:TextBox ID="txtimgcode" runat="server"></asp:TextBox>
    <br />
    <asp:Image ID="Image1" runat="server" ImageUrl="CImage.aspx"/>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
