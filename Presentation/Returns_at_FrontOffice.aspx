<%@ Page Title="" Language="C#" MasterPageFile="MasterPage2.master" AutoEventWireup="true" CodeFile="Returns_at_FrontOffice.aspx.cs" Inherits="Presentation_Process_Returns_at_FrontOffice" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h4>Returns at Back Office</h4>
<div class="row">
<div class="large-12 columns" style="overflow: hidden; width: 100%; color:Black;">
<VATAS:VGrid ID="VGrid1" runat="server" />
</div>
</div>
<br />
<asp:Button ID="btnSend" runat="server" Text="Send" CssClass="radius button" />
</asp:Content>

