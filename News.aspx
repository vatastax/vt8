<%@ Page Title="" Language="C#" MasterPageFile="~/VatasMaster.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript">
     $(document).ready(function () {
         var pathname = document.URL;
         pathname = pathname.substring(pathname.lastIndexOf("/"));
         pathname = pathname.substring(1);
         // alert(pathname);
         $('ul>li').each(function () {
             $(this).find('a').removeClass('activebutton');
             if ($(this).find('a').attr('href') == pathname) {

                 $(this).addClass('activebutton');
                 // alert('done');
             }

         })
         // $(this).addClass('active');
     });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200; ">
                  News
             </div>
<%-- <asp:DataList ID="dlst" runat="server">
    <ItemTemplate>
    <table>
    <tr>
    <td>
   
    </td>
    <td>
    
    </td>
    <td>
      
    </td>
    <td>
       
    </td>
    </tr>
    </table>
    </ItemTemplate>
    </asp:DataList>--%>
<div style="display:none">
    <asp:GridView ID="grdNews" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" Width="500px" BackColor="White" BorderColor="#CCCCCC" 
        BorderStyle="None" BorderWidth="1px">
        <Columns>
            <asp:TemplateField HeaderText="S.No" >
            
            <ItemTemplate>
             <asp:Label ID="lblSNO" runat="server"  Text='<%#Eval("SNo") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Service">
            <ItemTemplate>
               <asp:Label ID="Label1" runat="server"  Text='<%#Eval("Service") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date">
            <ItemTemplate>
             <asp:Label ID="Label2" runat="server"  Text='<%#Eval("Date") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
            <ItemTemplate>
            <asp:Label ID="Label3" runat="server"  Text='<%#Eval("Description") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    
    </asp:GridView>
  </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" Runat="Server">
<div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200; ">
                  News
             </div>
    
</asp:Content>

