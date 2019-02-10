<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="developer_Default" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<VATAS:VGrid ID="VGrid1" runat="server" Width="100%" />
</asp:Content>

