<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPage3.master" AutoEventWireup="true" CodeFile="lstErrors.aspx.cs" Inherits="Presentation_lstErrors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
<div class="large-12 columns">
<h2>List of Errors:</h2>
<br /><br />
<asp:GridView ID="gvError" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvError_RowDataBound">
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
            <HeaderTemplate>
            Error Description
            </HeaderTemplate>
            <ItemTemplate>
            <asp:LinkButton ID="lbtnErr" runat="server" Text='<%# Eval("particular") %>' PostBackUrl='<%# "manageLinking.aspx?VType=" + Eval("vtype") + "&tab=" + Eval("tab") %>'></asp:LinkButton>            
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            </asp:GridView>
</div>
</div>
</asp:Content>

