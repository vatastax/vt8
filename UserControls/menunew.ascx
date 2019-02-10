<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menunew.ascx.cs" Inherits="menunew" %>
<%--<script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
--%><script src="../Menudata/script.js" type="text/javascript"></script>
<link href="../Menudata/styles.css" rel="stylesheet" type="text/css" />

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div id="cssmenu" >
<asp:Literal ID="ltMenu" runat="server">
</asp:Literal>
</div>
</ContentTemplate>
</asp:UpdatePanel>
