<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Retrieve_ITR_V_Status.aspx.cs" Inherits="Retrieve_ITR_V_Status" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Retrieve ITR V Status</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="Enter PAN Number : "></asp:Label>
            <asp:TextBox ID="Txt_PAN" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="Label2" runat="server" Text="Enter Assessment Year : "></asp:Label>
            <asp:DropDownList ID="DDLYear" runat="server">
            </asp:DropDownList><br /><br />
            <asp:Button ID="Button1" runat="server" Text="Retreive Data" 
                onclick="Button1_Click" /><br /><br />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label><br /><br />
            <asp:Label ID="lbl_status" runat="server" Text=""></asp:Label><br /><br />
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
