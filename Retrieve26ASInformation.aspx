<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Retrieve26ASInformation.aspx.cs" Inherits="Retrieve26ASInformation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Retrieve 26AS Information</title>
</head>
<body>
    <form id="form1" runat="server">
     <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
    <div>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
    <ContentTemplate>
    <asp:Label ID="Label3" runat="server" Text="PAN : "></asp:Label>
    <asp:TextBox ID="TxtPAN" runat="server" placeholder="PAN Number" required="" Width="214px"></asp:TextBox><br />
    <asp:Label ID="Label4" runat="server" Text="DOB : "></asp:Label>
    <asp:TextBox ID="TxtDOB" runat="server" placeholder="YYYY-MM-DD" required="" Width="214px"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtDOB" Format="yyyy-MM-dd" >
        </ajaxToolkit:CalendarExtender>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Assessment Year : "></asp:Label>
    <asp:DropDownList ID="DDLYear" runat="server">
    </asp:DropDownList><br /><br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Retrieve Data" onclick="Button1_Click" /><br />
    

    
    
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbl_TAN" runat="server" Text=""></asp:Label>
        <asp:Label ID="lbl_TAN_Name" runat="server" Text=""></asp:Label>
    <b>TDS on Salary</b> <br /><br />
    <asp:GridView ID="GrdVw_TDSonSal" runat="server" EmptyDataText="No Transaction Present" ShowHeaderWhenEmpty="true"></asp:GridView>
    <br />
    
    <b>TDS Other Than Salary</b> <br /><br />
    <asp:GridView ID="GrdVw_TDSOnOthSal" runat="server" EmptyDataText="No Transaction Present" ShowHeaderWhenEmpty="true"></asp:GridView>
    <b>TCS</b> <br /><br />
    <asp:GridView ID="GrdVw_TCS" runat="server" EmptyDataText="No Transaction Present" ShowHeaderWhenEmpty="true"></asp:GridView>
    <b>Tax Payments</b> <br /><br />
    <asp:GridView ID="GrdVw_TaxPayments" runat="server" EmptyDataText="No Transaction Present" ShowHeaderWhenEmpty="true" ></asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
