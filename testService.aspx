<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testService.aspx.cs" Inherits="testService" EnableViewState="false" %>
<%@ Register Src="~/testing.ascx" TagName="aa" TagPrefix="bb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="btn1" runat="server" Text="Call Service" OnClick="btn1_Click" />
    </div>
    <br />
    
    <asp:GridView ID="gv1" runat="server">
    <Columns>
    <asp:TemplateField>
    <ItemTemplate>
    <asp:Label ID="asd" runat="server" Text='<%# Eval("NameID") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btn11" runat="server" OnClick="btn11_Click" />
    <br /><br />
    <bb:aa ID="asd" runat="server" EnableViewState="false" />
    </form>
</body>
</html>
