<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubUserMenu_Employer.ascx.cs" Inherits="SubUserMenu_Employer" %>



    <table>
    <tr>
    <td colspan="2" class="panel">
    Select 
               <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
    </td>
    </tr>
    <tr>
    <td>
    <asp:GridView ID="gvEmp" runat="server" AutoGenerateColumns="false"  OnRowDataBound="gvEmp_RowDataBound" OnRowCommand="gvEmp_RowCommand"
          EmptyDataText="<b> Default Employer </b>">
          <Columns>
          <asp:TemplateField>
          <HeaderTemplate>
          SNo.
          </HeaderTemplate>
          <ItemTemplate>
           <asp:Label ID="lblSNO" runat="server" ></asp:Label>          
          </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField>        
          <ItemTemplate>
          <asp:LinkButton ID="lbtnEmp" runat="server" Text='<%# Eval("Name") %>' CommandName="sel1" CommandArgument='<%# Eval("EmpID") %>' ></asp:LinkButton>
          <asp:Label ID="lblEmpID" runat="server" Text='<%# Eval("EmpID") %>' style="display:none;" ></asp:Label>
          </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField>
          <HeaderTemplate>
          PAN
          </HeaderTemplate>
          <ItemTemplate>          
           <asp:Label ID="Label1" runat="server" Text='<%# Eval("PAN") %>' ></asp:Label>
          </ItemTemplate>
          </asp:TemplateField>
          </Columns>
          </asp:GridView>
    </td>
    </tr>
    <tr>
    <td colspan="2" align="center" class="panel">
     <a id="aLnk" runat="server" style="font-family:Verdana; font-size:11px;" title="Click this link to see list of all users">
            Add/Manage <asp:Literal ID="ltTitle2" runat="server"></asp:Literal>            
            </a>
    </td>
    </tr>
    </table>