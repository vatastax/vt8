<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mobilemenu.ascx.cs" Inherits="Presentation_mobilemenu" %>
<div class="row">
<div class="large-12 columns">

 Welcome <asp:Label ID="lblUser" runat="server" Font-Bold="true"></asp:Label>

</div>
</div>
<div class="row" id="menuwrapper">
<div class="large-12 columns " id="p7menubar" >
<asp:Literal ID="ltMenu" runat="server">
</asp:Literal>
</div>
</div>
<br class="clearit"/>
