<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewErrLog.aspx.cs" Inherits="Presentation_ViewErrLog" %>
<%@ Register Src="~/UserControls/header.ascx" TagName="menuheader" TagPrefix="header" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

     <div class="row">
     <div class="large-12 columns">
         <%--<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
             AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
             <Columns>
                 <asp:CommandField ShowSelectButton="True" />
                 <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                     ReadOnly="True" SortExpression="id" />
                 <asp:BoundField DataField="ErrorMsg" HeaderText="ErrorMsg" 
                     SortExpression="ErrorMsg" />
                 <asp:BoundField DataField="methodName" HeaderText="methodName" 
                     SortExpression="methodName" />
                 <asp:BoundField DataField="className" HeaderText="className" 
                     SortExpression="className" />
                 <asp:BoundField DataField="pageName" HeaderText="pageName" 
                     SortExpression="pageName" />
                 <asp:BoundField DataField="ErrDateTime" HeaderText="ErrDateTime" 
                     SortExpression="ErrDateTime" />
             </Columns>
         </asp:GridView>--%>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
             ConnectionString="<%$ ConnectionStrings:Con_Poolable %>" 
             SelectCommand="SELECT * FROM [tbl_ErrorLog]"></asp:SqlDataSource>
     </div>
     </div>
    </form>
</body>
</html>
