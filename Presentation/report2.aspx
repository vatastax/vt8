<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report2.aspx.cs" Inherits="Presentation_report2" %>


<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %> <%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../mobilemenu2.ascx" TagPrefix="mob1" TagName="menu1" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../Presentation/MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="~/menu_header.ascx" TagName="menuheader" TagPrefix="header" %>


<!DOCTYPE html >

<html class="no-js" lang="en" >
<head id="Head1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
 <meta charset="utf-8" />
<title>Control Panel</title>
 <script src="../js/jquery.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="../scripts/menu.js"></script> 
   <script type="text/javascript" src="Scripts/common.js"></script>

 <%--<script src="../foundation-5.5.0/jquery.min.js" type="text/javascript"></script>
 <script src="../scripts/jquery.js" type="text/javascript"></script>
  <script src="../foundation-5.5.0/jquery.min.js" type="text/javascript"></script>
    <script src="../scripts/jquery-1.3.2.min.js" type="text/javascript"></script>--%>

<%--<link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />--%>

<%--<script type="text/javascript" src="../scripts/menu.js"></script> --%>

    <%--<link href="../foundation-5.5.0/css/foundation.min.css" rel="stylesheet" type="text/css" />
    <link href="../styles/StyleSheet.css" rel="stylesheet" type="text/css" />--%>
  
    <%--<script src="../foundation-5.5.0/js/foundation.min.js" type="text/javascript"></script>--%>

    <%--<link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />--%>

       <%--<script src="../js/jquery.min.js" type="text/javascript"></script>--%>

    <!--Master javascript file-->
        <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <!--Master javascript file-->

    <!--master style sheet-->
    <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->


<%--    <script type="text/javascript">
        $(document).ready(function () {

            $("#hide").click(function () {
                $("#div1").slideToggle();
            });

        });
</script>--%>
<%-- <script type="text/javascript">
     $(document).ready(function () {

         $("#btnmenu").click(function () {
             $("#divmenu").slideToggle();
         });

     });
</script>--%>
 <script src="js/jquery-1.10.0.min.js" type="text/javascript"></script>

<link rel="icon" type="image/png" href="../images/fevicon.png"/>
<link rel="shortcut icon" type="image/png" href="../images/fevicon.png"/>
<link href="../css/tooltipbox.css" rel="stylesheet" type="text/css" />
<link href="../css/box_style.css" rel="stylesheet" type="text/css" />
<link href="../css/tooltipboxdown.css" rel="stylesheet" type="text/css" />


<script language="javascript" type="text/javascript">
  //<![CDATA[
    function HandleClose() {
        //alert("Killing the session on the server!!");
        PageMethods.AbandonSession();
    }
   //]]>


</script>
<script src="../js/ie_compatibility/selectivizr-1.0.3b.js" type="text/javascript"></script>
<script src="../js/ie_compatibility/html5shiv.js" type="text/javascript"></script>
<script src="../js/ie_compatibility/es5-shim.min.js" type="text/javascript"></script>
<script src="../js/ie_compatibility/nwmatcher-1.2.5-min.js" type="text/javascript"></script>
<script src="../js/ie_compatibility/respond.min.js" type="text/javascript"></script>
</head>
<body onunload="HandleClose(0)">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>


    <%--<asp:Button ID="btnTesting" runat="server" Text="Test Here" OnClick="btnTesting_Click" />--%>

    <div class="row hide-for-small-only">
    <div class="large-12 columns">
    <%--Add by nishu for header 11/4/2015 --%>
    <header:menuheader ID="header1" runat="server" />
    </div>
    </div>
   <%-------------------Breadcrumps -----------------------%>
  <div class="row">
     <div class="large-12 columns hidden-for-small-only">
         <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
             Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" NodeStyle-Font-Bold="false" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
     </div>
   </div>
    <div class="row">
        <div class="large-12 columns hide-for-small-only">
         
          <%
    if(Session["ay"]!=null || Session["Project"].ToString()=="stax")
    {
    %>

<main:mainmenu ID="mm1" runat="server"  />
<%
    }
    else
    {
    %>

<main2:mainmenu2 ID="mm12" runat="server"  />
<%
    }
    %>
         
         
        </div>
      </div>
   
      
  <div class="row show-for-small-only" style="background-color: #F8F8F8">
  <br />
        <div class="small-9 columns">
        <a href="Default.aspx">
            <img src="../images/logo2.PNG" style="width:180px; height:auto" /></a>
        </div>
        <%----------------show username on mobile menu --------------------%>
     <div class="row show-for-small-only">     
     <div class="large-12 columns text-right">
      Welcome <span style="font-weight:bold;color:#008CBA;  text-transform:capitalize"><asp:Literal ID="ltUser" runat="server" /></span>
         
      <a href="logout.aspx">
 [Logout]
 </a>
     </div>
     </div>
     <%--show breadcrumps in all views nishu 8/4/2015--%>
    <div class="row" >
    <br />
    <div class="large-12 columns" style="margin-top:-20px">
     <asp:SiteMapPath ID="SiteMapPath3" runat="server" 
              Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" NodeStyle-Font-Bold="false" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource3" runat="server" />
    </div>
    </div>
            <%--<div class="small-3 columns text-right">
          
            <img src="../images/menu1.JPG" id="btnmenu" style="margin-top:15px;width:40px; height:40px"/>
           
        </div>--%>
  </div>

   <%-------------------Breadcrumps -----------------------%>
  <div class="row">
     <div class="large-12 columns show-for-small-only">
         <asp:SiteMapPath ID="SiteMapPath2" runat="server" 
             Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" NodeStyle-Font-Bold="false" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
     </div>
   </div>

    <div class="row show-for-small-only" id="divmenu" style="display:none">
      
      <div class="large-12 columns">
          
          <%
    if(Session["ay"]!=null)
    {
    %>

  <mob:menu ID="mob1" runat="server" />
<%
    }
    else
    {
    %>

<mob1:menu1 ID="mob11" runat="server" />
<%
    }
    %>
      </div>
      </div>
       <div class="row show-for-small-only" style="color:White" >
        <div class="large-12 columns">
          <mob2:mobmenu id="mobmenu" runat="server" />
                <%--<img src="../images/details.JPG" />--%>
            
        </div>
    </div>
    <div class="row show-for-medium-only" style="color:White" >
        <div class="large-12 columns">
           <mob3:mediummenu id="medmenu" runat="server" />
         
        </div>
    </div>

<%--Layout for Large Only --%>
<div class="row hide-for-small-only hide-for-medium-only">
<div class="large-12 columns" > 

<div class="row">
   <div class="large-4 columns">
   
     <%--<asp:GridView ID="gv1" runat="server">
    </asp:GridView>--%>
    <asp:Literal ID="ltReport" runat="server"></asp:Literal>
   <br />
   </div>
   <div class="large-4 columns" >
   <%--<div class="login-wrap" style="margin-left:-22px">
       <asp:Label ID="lblText" runat="server" Text="" style="font-size:20px"></asp:Label>
   <%--<h2 style="font-size:20px">Continue with ITR Process</h2>--%>
   <hr />
   
   <div class="form" style="margin-top:-115px;margin-left:80px">   
   <asp:Button ID="btnContinue" runat="server" style="border-radius:10px;margin-top:105px;margin-left:-35px" Text="Proceed" CssClass="button" PostBackUrl="Salary.aspx?VType=40" />
   </div>
   </div>
   </div>
   <div class="large-4 columns">&nbsp;</div>
   </div>
   </div>
   </div>
<%--Layout for Medium Only --%>
<div class="row show-for-medium-only">
<br />

   <div class="medium-12 columns">
   <a class="tooltipssmall">
   
    <span style="border-radius:10px;margin-left:235px;font-size:16px;"> Using this application for the first time ?</span></a>
   <br />
   </div>
  </div>
   <div class="row show-for-medium-only ">

   <%--<div class="medium-12 columns" >
   <div class="login-wrap" style="width:280px;margin-top:52px;margin-left:245px">
   <h2 style="font-size:20px">Continue with ITR Process</h2>
   <hr />
   
   <div class="form">
   <asp:Button ID="Button2" runat="server" style="border-radius:10px;" Text="Proceed" CssClass="button" PostBackUrl="Salary.aspx?VType=40" />
   </div>
   </div>
   </div>--%>
   </div>
   


      
<%--Layout for Small Only --%>

      
    <div class="row hidden-for-large hidden-for-medium" id="div1" style="display:none">
     <div class="large-12 columns" >
       <sub:submenu ID="Submenu1" runat="server" />
     </div>

     </div>
    <div class="row">
    
   <%-- <div class="large-3 columns show-for-large-only">
        <sub:submenu ID="sub1" runat="server" />
        </div>
     --%>
        <div class="large-12 columns" >   
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                         <%--<mob3:mediummenu id="Mediummenu1" runat="server" />--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
     
        </div>
         
      </div>
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
    <div class="row" style="bottom:0;  margin-left: auto;margin-right: auto;margin-top: 100px;" >
      <hr/>       
      <div class="large-12 columns" >
        <div class="large-6 columns" >
     
          © 2015 Vatas Infotech Pvt.Ltd.
          </div>
        <%--<div class="large-6 columns text-right">
            
                <a href="https://www.facebook.com/echarteredaccountants" target="_blank"><img src="../images/fb.png"></a>
                <a href="http://www.twitter.com/ECAccountant" target="_blank"><img src="../images/twitter.png"></a>
                <a href="https://in.linkedin.com/pub/vatas-infotech/b9/264/a82" target="_blank"><img src="../images/LINKEDIN1.PNG"></a>
                <a href="https://plus.google.com/u/0/b/108616341946641442746/108616341946641442746" target="_blank"><img src="../images/google.png"></a>
             
            </div>--%>
           </div>     
     </div>
  <div class="hide-for-small-only hide-for-medium-only">
 <menu:side ID="Sidemenu" runat="server" />
 </div>
  </form>
</body>
</html>
