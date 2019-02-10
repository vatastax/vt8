<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu2.ascx.cs" Inherits="Menu" %>
<link href="../Stylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../sliderengine/jquery.js" type="text/javascript"></script>
<script src="../sliderengine/amazingslider.js" type="text/javascript"></script>
<link href="../sliderengine/amazingslider-1.css" rel="stylesheet" type="text/css" />
<link href="../Stylesheet/buttonstyle.css" rel="stylesheet" type="text/css" />
<script src="../js/modernizr.custom.34978.js" type="text/javascript"></script>
<script src="../sliderengine/initslider-1.js" type="text/javascript"></script>
<link href="../Stylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />
<br class="clearit" />
<div class="row" style="margin-top: -20px; margin-bottom: -22px">
    <div class="large-3 columns" style="background-color: white; color: black; height: 80px;
        vertical-align: top;">
        <%--<p class="headline"  > E-Chartered &nbsp;&nbsp;Accountants<p>Your Pocket <b>TAX</b> Manager</p> </p>--%>
        <a href="../Default.aspx">
            <img src="../images/logo2.PNG" alt="logo" style="width: 240px; height: auto" />
        </a>
    </div>
        <%--<div class="large-9 columns">
          <ul class="right button-group">
          <li><a href="Default.aspx" class="button">HOME</a></li>
          <li><a href="about.aspx" class="button">ABOUT US</a></li>
          <li><a href="contact.aspx" class="button">CONTACT US</a></li>
           <li><a href="#" class="button">LOGIN</a></li>
          </ul>
         </div>--%>
    <div class="large-6 columns text-right">
        <img src="male3.jpg" alt="" height="25px" />
        <br />
        Welcome
        <asp:Label ID="lblUser" runat="server" Font-Bold="true" Style="color: #008CBA; text-transform: capitalize"></asp:Label>
        <p>
            <a href="logout.aspx">[Logout] </a>
        </p>
    </div>
</div>
       
<div class="row" id="menuwrapper"">
<div class="large-12 columns ">

<%--<ul id="p7menubar" class="right">
<li>
<a href="../Presentation/logout.aspx">LogOut</a>
</li>
</ul>--%>


</div>
</div>
