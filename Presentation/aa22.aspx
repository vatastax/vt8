<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPage3.master" AutoEventWireup="true" CodeFile="aa22.aspx.cs" Inherits="Presentation_aa22" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<VGrid:VGrid id="VGrid1" runat="server" />
<br />
<div class="row">
<div class="large-12 columns hide-for-small-only">
<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
</div>
</div>
</asp:Content>