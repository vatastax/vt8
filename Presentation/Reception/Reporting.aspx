<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/Reception/MasterPage.master" AutoEventWireup="true" CodeFile="Reporting.aspx.cs" Inherits="Presentation_Reception_Reporting" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../Scripts/JScript.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="large-12 columns" style="width: 100%;">
    <VATAS:VGrid ID="VGrid1" runat="server" Width="100%" CssClass="VGrid" />
</div>

</asp:Content>