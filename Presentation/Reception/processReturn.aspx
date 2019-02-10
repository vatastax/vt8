<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/Reception/MasterPage.master" AutoEventWireup="true" CodeFile="processReturn.aspx.cs" Inherits="Presentation_Reception_processReturn" %>

<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="large-12 columns" style="overflow: hidden; width: 970px;">
        <VATAS:VGrid ID="VGrid1" runat="server" Width="100%" />
    </div>
</asp:Content>

