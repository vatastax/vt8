<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DirectorAddress.aspx.cs" Inherits="Presentation_DirectorAddress" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %> 
<%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Address Details</title>
</head>
<body onload="window.resizeTo(400,400)">
    <form id="form1" runat="server">
    <div>
        <table style="width: 349px">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Flat"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtFlat" runat="server"></asp:TextBox></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Premises"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPremises" runat="server"></asp:TextBox></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Road"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtRoad" runat="server"></asp:TextBox></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Area"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtArea" runat="server"></asp:TextBox></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="City"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="State"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlStates" runat="server" DataSourceID="ObjectDataSource1"
                        DataTextField="StateName" DataValueField="StateCode" Width="153px">
                    </asp:DropDownList></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="PIN"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPIN" runat="server"></asp:TextBox></td>
                <td>
                </td>
            </tr>
        </table>
    </div>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getStates"
            TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
    </form>
</body>
</html>
