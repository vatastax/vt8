<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideSubUserMenu.ascx.cs" Inherits="SideSubUserMenu" %>

<%--hide details image on showing of details --%>
<script src="../Popup/jquery.min.js" type="text/javascript"></script>
    <script src="../Popup/jquery-ui.js" type="text/javascript"></script>
    <link href="../Popup/jquery-ui.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(document).ready(function ($) {
        $('.side').hover(function () {
            $('.side-link').hide('fast');


        },
        function () {
            $('.side-link').show('fast');
        }
        );
    });

    function redirectMain2() {
        $("#popupdiv").dialog({
            title: "Error Message",
            width: 430,
            height: 250,
            modal: true,
            buttons: { Yes: function () {
                window.location = "saveAssessee.aspx?wx=1"

            },
                No: function () {
                    //$(this).dialog('close');
                    window.location = "saveAssessee.aspx"
                },
                Cancel: function () {
                    $(this).dialog('close');
                }
            }
        });
    }
</script>


<%-- <div id="bottomRight">
      <div class="row" >
    <div class="large-12 columns panel" style="padding:10px;  ">
  <a href="#"><asp:Literal ID="ltMain" runat="server"></asp:Literal></a> 
    </div>
    </div>
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
    </div>--%>
  <%--  <div id="bottomRight">--%>
  

    <div class="side-tab visible">
    
      <a href="#" title="View Accessee Details" class="side-link" style="box-shadow:none" >
     
      <span class="Accessee" style="box-shadow:none; background-image:url('../images/sidedetails.png'); width:100px; height:62px; background-repeat:no-repeat; padding:18px 0px 0px 24px; color:Red; font-size:12px;" >
       <asp:Literal ID="ltTitleMain" runat="server"></asp:Literal>
    <%--<img src="../images/sidedetails.png" />--%>
    <%--Comment by nishu 9/4/2015 --%>
    <%--  <asp:Literal ID="ltMain" runat="server" ></asp:Literal>--%>
      </span>
   
    </a>
    
     <div class="side" style=" color:#5c92fa;opacity:0.8; border-radius:10px; background:transparent">
      <div class="side-items" >
      <%-- Main Title --%>
      <div class="row " style="margin-top:5px; margin-bottom:10px;">
      <div class="large-12 columns " style="color:#ef5845; font-size:16px; font-weight:bold;">
         <asp:Literal ID="ltMain" runat="server"></asp:Literal>
      </div>
      </div>
   
   <div class="row" style="font-size:14px">
    <div class="large-4 columns" style="color:gray; font-size:14px; text-align:left">Name:</div>
    <div class="large-8 columns" style="color:Gray; text-align:left; color:black;  text-transform:uppercase ">
        <asp:Label ID="lblUser" runat="server" Font-Size="14px" Text="No Assessee"></asp:Label></div>
    </div>
    <hr style="margin:0 0 0 0;" />
     <div class="row" style="font-size:14px;">
    <div class="large-4 columns" style="color:gray;text-align:left"><asp:Literal ID="ltTitle" runat="server" Text="PAN"></asp:Literal>
    :</div>
        <div class="large-8 columns" style="text-align:left; color:black; text-transform:uppercase"> 
        <asp:Label ID="lblPAN" runat="server"  Font-Size="12px" Text="" ></asp:Label></div>
    </div>
    <hr style="margin:0 0 0 0;" />
     <div class="row" style="font-size:14px">
    <div class="large-4 columns" style="color:gray;text-align:left"><asp:Literal ID="ltAY" runat="server" Text="AY"></asp:Literal>
    :</div>
        <div class="large-8 columns" style="text-align:left; color:black">
        <asp:Label ID="lblAY" runat="server"  Font-Size="12px" Text=""></asp:Label></div>
    </div>
    <hr style="margin:0 0 0 0;" />

    <div class="row" style="font-size:14px">
   <div class="large-4 columns" style="color:Gray;text-align:left"><asp:Literal ID="ltQuarter" runat="server" Text="Quarter:" Visible="false"></asp:Literal>
    </div>
        <div class="large-8 columns" style="text-align:left; color:black"><asp:Label ID="lblQuarter" runat="server"  Visible="false" Font-Size="12px"  Text=""></asp:Label></div>
    </div>
    <div style="height:5px;">
    &nbsp;
    </div>

     <div class="row">
    <div class="large-12 columns " >
  <a id="aProfile" runat="server" onclick="redirectMain2();"  title="Click this link to see list of all users" style="color:#008CBA; font-size:14px" >
            <asp:Literal ID="ltSelect" runat="server"> </asp:Literal>
            </a>
    </div>
    </div> 
      </div>
     </div>
    </div>
 
  <div  id="popupdiv" style="display: none">
 <p>
 All Your Data will be lost for the current Assessee. Do you want to save it anyway before leaving?
 </p>
 </div>
