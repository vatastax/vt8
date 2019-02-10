<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubUserMenu_Asset.ascx.cs" Inherits="SubUserMenu_Asset" %>


    <table>
    <tr>
    <td colspan="2">
    Select <asp:Literal ID="ltAssetType" runat="server"></asp:Literal> </a>
    </td>
    </tr>
    <tr>
    <td>
    <asp:GridView ID="gvAsset" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="gvAsset_RowDataBound" OnRowCommand="gvAsset_RowCommand">
          <Columns>
          <asp:TemplateField>
          <HeaderTemplate>
          SNo.
          </HeaderTemplate>
          <ItemTemplate>
          <asp:Label ID="lblSNO" runat="server"></asp:Label>
          </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField>         
         <%-- <HeaderTemplate>
          <asp:Label ID="lblHead" runat="server"></asp:Label>
          </HeaderTemplate> --%>
          <ItemTemplate>
          <asp:LinkButton ID="lbtnEmp" runat="server" Text='<%# Eval("CompanyName") %>' CommandName="sel1" CommandArgument='<%# Eval("AssetID") %>' ></asp:LinkButton>
          <asp:Label ID="lblAssetID" runat="server" Text='<%# Eval("AssetID") %>' style="display:none;" ></asp:Label>
          </ItemTemplate>
          </asp:TemplateField>
          </Columns>
          </asp:GridView>
    </td>
    </tr>
    <tr>
    <td class="panel">
     <a href="Presentation/AssetMaster.aspx" style="font-family:Verdana; font-size:11px;" title="Click this link to see list of all users">
            Add/Manage <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </a>
    </td>
    </tr>
    </table>