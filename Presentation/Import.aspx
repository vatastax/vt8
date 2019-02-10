<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import.aspx.cs" Inherits="Presentation_Import" %>
<%@ Register Src="../UserControls/Import.ascx" TagName="import" TagPrefix="imp" %>
<%@ Register Src="../menu_header.ascx" TagName="menuheader" TagPrefix="header" %>
<%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../mobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html class="no-js" lang="en">
<head id="Head1" runat="server">
    <script type="text/javascript">
    

    function get_PB()
    {

    }
    function submitIt() {
        try
        {
            window.location = 'http://192.168.1.202/Presentation/Salary.aspx?VType=40&sd=dn';// window.URL.toString() + "&sd=dn";
        }
        catch (e) { alert(e);}
        <%--document.getElementById('<%= hdnSD_Data.ClientID %>').value = 'done';
        document.getElementById('form1').submit();--%>
        //document.getElementById('btnSubmitSignatory').click();
    }
        function backIt() {
        try
        {
            window.location = 'http://192.168.1.202/Presentation/Salary.aspx?VType=40';// window.URL.toString() + "&sd=dn";
        }
        catch (e) { alert(e);}
</script>
<link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="Scripts/common.js"></script>
    <script type="text/javascript" src="jquery.min.js"></script>
    <!--jsss-->

    <link href="gridstyle.css" rel="Stylesheet" type="text/css" />
    <title>Control Panel</title>
  
   <!--Master javascript file-->
        <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <!--Master javascript file-->

     <!--master style sheet-->
    <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->


    <!-- Following code is for Tab Controls -->

  <%--  <link href="StyleSheet2.css" rel="stylesheet" type="text/css" />--%>
    
    <link rel="icon" type="image/png" href="../images/fevicon.png"/>
<link rel="shortcut icon" type="image/png" href="../images/fevicon.png"/>
<script src="../Presentation/jquery.min.js" type="text/javascript"></script>
           <%--<script src="../js/jquery.ui.min.js" type="text/javascript"></script>--%>
  
    <%--<link href="../ITRStylesheet/styles/jquery-ui.css" rel="stylesheet" type="text/css" />--%>

    <%------------------------------Jquery Validation ------------------------------%>
     <%--<link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />--%>
 <script type="text/javascript">
     $(document).ready(function ($) {

         $("#btnmenu").click(function () {
             $("#divmenu").slideToggle();
         });

     });
    </script>

<style type="text/css">
    #hrnew
    {
        height: 2px;
        background-image: -webkit-linear-gradient(left, rgba(0, 0, 0, 1), rgba(0, 0, 0, 1), rgba(0, 0, 0, 1));
        opacity: 1.0;
        margin-top: 1px;
    }
    
    .headsize
    {
        font-size: 15px;
    }
    
    
    .btnstyle
    {
        background: #25A6E1;
        background: -moz-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
        background: -webkit-gradient(linear,left top,left bottom,color-stop(0%,#25A6E1),color-stop(100%,#188BC0));
        background: -webkit-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
        background: -o-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
        background: -ms-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
        background: linear-gradient(top,#25A6E1 0%,#188BC0 100%);
        filter: progid: DXImageTransform.Microsoft.gradient( startColorstr='#25A6E1',endColorstr='#188BC0',GradientType=0);
        padding: 8px 13px;
        color: #fff;
        font-family: 'Helvetica Neue' ,sans-serif;
        font-size: 17px;
        border-radius: 4px;
        -moz-border-radius: 4px;
        -webkit-border-radius: 4px;
        border: 1px solid #1A87B9;
    }
</style>

<%--StyleSheets for information box - jaipal--%>

<script src="../js/jquery-1.10.0.min.js" type="text/javascript"></script>
<script src="js/index.js"></script>
<link href="../css/box_style.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  <div class="row hide-for-small-only">
    <div class="large-12 columns" style="margin-bottom:-20px">
   
    <header:menuheader ID="header1" runat="server" />
    </div>
    </div>
     <!--sitemap nishu8/3/2015 and menu-->
      <div class="row ">
        <div class="large-12 columns  hidden-for-small-only" >
          
             <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
             Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" NodeStyle-Font-Bold="false" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
    </div>
    <div class="row">
      <div class="large-12 columns hide-for-small-only" >
      
            <main:mainmenu ID="mm1" runat="server" />
       
       </div>
    </div>
    <div class="row show-for-small-only" style="background-color: White">
    <br />
        <div class="small-9 columns">
            <a href="Default.aspx">
                <img src="../images/logo2.png" style="width: 180px; height: auto" /></a>
        </div>
        <div class="small-3 columns text-right">
            <img src="../images/menu1.JPG" id="btnmenu" style="margin-top: 15px; width: 40px;
                height: 40px" />
        </div>
        <div class="row hidden-for-large hidden-for-medium" id="divmenu" style="display: none">
        <div class="large-12 columns">
            <mob:menu ID="mob1" runat="server" />
        </div>
    </div>
            <%----------------show username on mobile menu --------------------%>
     <div class="row show-for-small-only"> 
     <br />    
     <div class="large-12 columns text-right">
      Welcome <span style="color:Black;font-family:'Open Sans','sans-serif';font-size:15px;font-weight:bold;color:#008CBA;  text-transform:capitalize"><asp:Literal ID="ltUser" runat="server" /></span>
         
      <a href="logout.aspx">
 [Logout]
 </a>
     </div>
     </div>
  <%----------------show username on mobile menu --------------------%>
            
  </div>

    <br />
     <div class="row ">
    <div class="large-12 columns">
   
     <imp:Import ID="imp" runat="server" />
    </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    
        <div class="row"  >
        <div class="large-12 columns" >
          <hr/>        
          <p>© 2015 Vatas Infotech Pvt.Ltd.</p>
        </div>
     </div>
  
    </form>
</body>
</html>
