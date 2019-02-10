<%@ Control Language="C#" AutoEventWireup="true" CodeFile="responsivemobilemenu.ascx.cs" Inherits="responsivemobilemenu" %>
<%--<div class="rmm">
<asp:Literal ID="ltMenu" runat="server">
</asp:Literal>
</div>--%>
 <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"/>
   <%--  <script src="../scripts/jquery.js" type="text/javascript"></script>--%>
<%--<script src="menu/js/jquery.js" type="text/javascript"></script>--%>
 
    <link href="../menu/flexnav.css" rel="stylesheet" type="text/css" />
    <link href="../menu/page.css" rel="stylesheet" type="text/css" />
  
    <script src="../menu/js/flexnav.js" type="text/javascript"></script>

<script type="text/javascript">
    var $jq = jQuery.noConflict();
    $jq(document).ready(function ($jq) {
        $jq(".flexnav").flexNav();
        event.preventDefault();
    });
</script>
    
<div class="menu-button">Menu</div>
        <nav>
          <asp:Literal ID="ltMenu" runat="server"></asp:Literal>
        </nav>
           