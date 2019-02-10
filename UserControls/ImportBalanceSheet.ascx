<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImportBalanceSheet.ascx.cs" Inherits="UserControls_ImportBalanceSheet" %>
<style type="text/css">
   
</style>
<table >
    <tr>
        <td  align="center" style="background-color:#215DC6;color:White">
            Import Balance Sheet</td>
       
    </tr>
    <tr>
        <td>
            &nbsp;</td>
       
    </tr>
    <tr>
        <td >
            <asp:FileUpload ID="fupl" runat="server" />
        </td>
       
    </tr>
    <tr>
        <td >
            <asp:Button ID="btnC" runat="server" OnClick="btnC_Click" Text="Import XML" />
        </td>
      
    </tr>
</table>

