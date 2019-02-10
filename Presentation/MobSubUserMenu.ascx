<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MobSubUserMenu.ascx.cs" Inherits="Presentation_MobSubUserMenu" %>
<%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js" type="text/javascript"></script>--%>
 <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(document).ready(function ($) {

         $("#hide").click(function () {
             $("#div1").slideToggle();
         });

     });
    </script>
    
 <div class="row" id="hide" style="background-color:#f2f2f2" >
    <div class="small-6 columns " style="padding:10px;  ">
  <a href="#"><span style="font-size:14px"><asp:Literal ID="ltMain" runat="server"></asp:Literal></span></a> 
    </div>
    <div class="small-6 columns text-right">
    <img style="  margin-top: 12px; margin-right: 5px;" src="../images/submenu.JPG"  />
    </div>
    </div>
    
    <div id="div1" style="display:none">
    <div class="row" style="font-size:small;">
    <div class="large-6 columns">Name:</div>
    <div class="large-6 columns">
        <asp:Label ID="lblUser" runat="server" Font-Bold="true" Font-Size="12px" ForeColor="Red" Text="No Assessee"></asp:Label></div>
    </div>
    <hr style="margin:0 0 0 0;" />
     <div class="row" style="font-size:small;">
    <div class="large-6 columns"><asp:Literal ID="ltTitle" runat="server" Text="PAN"></asp:Literal>
    :</div>
        <div class="large-6 columns"> <asp:Label ID="lblPAN" runat="server" Font-Bold="true" Font-Size="12px" Text=""></asp:Label></div>
    </div>
    <hr style="margin:0 0 0 0;" />
     <div class="row" style="font-size:small;">
    <div class="large-6 columns">AY:</div>
        <div class="large-6 columns"><asp:Label ID="lblAY" runat="server" Font-Bold="true" Font-Size="12px" Text=""></asp:Label></div>
    </div>
    <div style="height:5px;">
    &nbsp;
    </div>

     <div class="row">
    <div class="large-12 columns panel" style="padding:10px">
  <a href="Main.aspx"  title="Click this link to see list of all users">
            <asp:Literal ID="ltSelect" runat="server"> </asp:Literal>
            </a>
    </div>
    </div> 
  </div>