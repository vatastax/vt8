<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiptNo.aspx.cs" Inherits="Presentation_ReceiptNo" %>
<%@ Register Assembly="controlgrid" Namespace="controlgrid" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
<%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../mobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../mobilemenu2.ascx" TagPrefix="mob1" TagName="menu1" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagName="resmob" TagPrefix="resmenu" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../Presentation/MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="~/menu_header.ascx" TagName="menuheader" TagPrefix="header" %>
<%@ Register Src="../UserControls/ReceiptNo.ascx" TagName="receipt" TagPrefix="rec" %>
<%@ Register Src="~/UserControls/Messagebox.ascx" TagName="mm" TagPrefix="msg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html class="no-js" lang="en">
<head id="Head1" runat="server">
    <script type="text/javascript">

////    $(document).ready(function () {
//////        alert('document ready');
////        $("#rec1_btn_Submit").click(function () {
//////        alert('clicked');
//////            setTimeout(CSI_Download, 10000);
////        document.getElementById('hdnRec').value='rec';
////        });
////    });

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
        catch (e) { alert(e);
        }
       
</script>
<script type="text/javascript">
      
//    function CSI_Download() {        
//        document.getElementById('msg_CsiFileDownload_btn_Ok').click();
//    }
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

         function startProcess() {
             try {
                 document.getElementById('divProcess').style.display = 'block';
                 //document.getElementById('rec1_btn_Submit').setAttribute('disabled', 'true');
                 //document.getElementById('rec1_btnback').setAttribute('disabled', 'true');
                 document.getElementById('rec1_rdl_PreviousReceiptNo_1').setAttribute('disabled', 'true');
             }
             catch (e) { alert(e); }
         }
         function endProcess() {
             document.getElementById('divProcess').style.display = 'none';
             document.getElementById('rec1_btn_Submit').removeAttribute('disabled');
             document.getElementById('rec1_btnback').removeAttribute('disabled');
             document.getElementById('rec1_rdl_PreviousReceiptNo_1').removeAttribute('disabled');
         }
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

<script src="js/jquery-1.10.0.min.js" type="text/javascript"></script>
<script src="js/index.js"></script>
<link href="../css/box_style.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="divProcess" style="background-color:White; position:absolute; z-index:1; left:400px; width:332px; top:400px; display:none;">
    <img src="images/processing.gif" />
    </div>
  <div class="row hide-for-small-only">
    <div class="large-12 columns" style="margin-bottom: -20px;">
   
    <header:menuheader ID="header1" runat="server" />
    </div>
    </div>

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
  <div class="login-wrap2" style="display:none;">
    <div>
    <br />
    Press Button below to Generate and copy all three files(txt,csi,fvu)
        <br /><br />
        <center>
        <input type="button" value="Generate Files" onclick="SaveCSI();" class="radius button" />
        &nbsp;
        <asp:Button ID="btnFVU" runat="server" OnClick="btnFVU_Click" />
        </center>
    </div>
    </div>

     <div class="row " >
    <div class="large-12 columns">   
     <rec:receipt ID="rec1" runat="server" />
    </div>
    </div>
    <br />
    <br />
     <div class="row " style="display:none;">
    <div class="large-12 columns">
    <msg:mm ID="msg_CsiFileDownload" runat="server" SelectNoButtons="Two" OkButtonText="Yes" onclick="alert('asd');" CancelButtonText="No" message="Do you want to Download the Csi File!" />
    </div>
    </div>
    <br />
    <br />
    <br />
    <div class="row"  >
        <div class="large-12 columns" >
          <hr style="margin-top:1px"/>        
          <p>© 2015 Vatas Infotech Pvt.Ltd.</p>
        </div>
     </div>
  
    </form>
</body>
</html>
