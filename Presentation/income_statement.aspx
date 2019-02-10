<%@ Page Language="C#" AutoEventWireup="true" CodeFile="income_statement.aspx.cs" Inherits="Presentation_income_statement" %>
<%@ Register Src="../SubUserMenu_Employer.ascx" TagName="empmenu" TagPrefix="emp" %>
<%@ Register Src="../SubUserMenu_Asset.ascx" TagName="property" TagPrefix="house" %>
<%@ Register Src="MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="../UserControls/PopupControl.ascx" TagName="pop" TagPrefix="popup" %>
<%@ Register Src="../UserControls/ImportBalanceSheet.ascx" TagName="ImpBalance" TagPrefix="usr" %>
<%@ Register Src="~/UserControls/header.ascx" TagName="menuheader" TagPrefix="header" %>
<%@ Register Src="~/UserControls/menunew.ascx" TagName="menu" TagPrefix="mm" %>
<%@ Register Src="~/Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="~/UserControls/FileUploadDirectoryCtrk.ascx" TagPrefix="fileupload" TagName="fu"  %>

<!DOCTYPE html >
<html class="no-js" lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
      <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <!--jsss-->
    <link href="gridstyle.css" rel="Stylesheet" type="text/css" />
    <title>Control Panel</title>
    <script type="text/javascript" src="Scripts/jquery_scripts.js"></script>
    <link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="../foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
    <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
    <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../ITRStylesheet/styles/tabstrip.js" type="text/javascript"></script>
    <%-- <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />--%>
 <%--   <link href="../css/new_button.css" rel="stylesheet" type="text/css" />--%>
     <link href="../css/box_style.css" rel="stylesheet" type="text/css" />

    <link rel="icon" type="image/png" href="../images/fevicon.png" />
    <link rel="shortcut icon" type="image/png" href="../images/fevicon.png" />
    <style type="text/css">
        #hrnew
        {
            height: 1px;
            background-image: -webkit-linear-gradient(left, rgba(0, 0, 0, 1), rgba(0, 0, 0, 1), rgba(0, 0, 0, 1));
            background-image: -moz-linear-gradient(left, rgba(0, 0, 0, 1), rgba(0, 0, 0, 1), rgba(0, 0, 0, 1));
            opacity: 1.0;
            margin-top: -2px;
        }
    </style>




    <%---------------------Tooltip Grid -------------------------%>
    <link href="../css/tooltip.css" rel="stylesheet" type="text/css" />
 <script type="text/javascript">
     $(document).ready(function () {
         $('#cssmenu>ul>li').eq(7).addClass('active');
         pop(); //To set Grid of popup setings
         CheckRowCheckBoxes(); //Popup Div Function
         Fileupload(); //function to provide event for "My Files" link
        $('#Details').css("display", "block");
        $('#ass').click(function () {
            //alert('salary');
            $('#Details').slideToggle();
        });
        });
        </script>
</head>
<body onload="loadPage();" style="height: 600px; ">
    <%--  onunload="HandleClose(0)">--%>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" >
    </asp:ScriptManager>
    <%--------------------nishu 14-3-2016 --------------------------%>
    <div class="row show-for-small-only" style="background-color: White; margin-top: -20px">
       
        <div class="small-9 columns">
         
            <a href="Default.aspx">
                <img src="../images/logo2.png" style="width: 180px; height: auto" /></a>
        </div>
        <div class="small-3 columns text-right">
            <img src="../images/menu1.JPG" id="btnmenu" style="margin-top: 15px; width: 40px;
                height: 40px" />
        </div>
       
        <%----------------show username on mobile menu --------------------%>
        <div class="row show-for-small-only">
            <br />
            <div class="large-12 columns text-right">
                Welcome <span style="color: Black; font-family: 'Open Sans','sans-serif'; font-size: 15px;
                    font-weight: bold; color: #008CBA; text-transform: capitalize">
                    <asp:Literal ID="ltUser" runat="server" /></span> <a href="logout.aspx">[Logout]
                </a>
            </div>
        </div>
        <%----------------show username on mobile menu --------------------%>
    </div>
     <div class="row hidden-for-large hidden-for-medium" id="divmenu" style="display: none">
            <div class="large-12 columns">
                <mob:menu ID="mob1" runat="server" />
            </div>
        </div>
    <div class="row show-for-small-only">
        <div class="large-12 columns ">
            <mob2:mobmenu ID="mobmenu" runat="server" />
        </div>
    </div>
    <header:menuheader ID="header" runat="server"></header:menuheader>
  <div>
    <div class="large-3 medium-3 columns  " style="left: 0; padding: 0; ">
        <asp:UpdatePanel ID="Upleft" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="ass" class=" show-for-large-only " style=" background-color: #3f3250;
                    -webkit-border-radius: 10px; -moz-border-radius: 10px; border-radius: 10px; padding: 10px;
                    -moz-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); -webkit-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                    box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); text-align: center; -webkit-border-radius: 4px;
                    -moz-border-radius: 10px; border-radius: 7px; padding: 5px; -moz-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                    -webkit-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                    margin-left: 3px; width:300px">
                    <span style="color: White">Assessee Details [<asp:LinkButton ID="lbtnEditProf" runat="server" Text="Edit" OnClick="lbtnEditProf_Click" ToolTip="Click this link to Change Current Profile Details" style="font-size:13px" ForeColor="White"></asp:LinkButton>]</span>
                </div>
                <div id="Details" class="hidden-for-small-only" style="font-family: 'Open Sans', sans-serif;
                    display: none">
                    <sub:submenu ID="Submenu2" runat="server" />
                </div>
                <div id="dd" style="overflow-y: auto; height: 475px; width: 300px" class="hide-for-small-only">
                    <mm:menu ID="menu1" runat="server"></mm:menu>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
          <script type="text/javascript" src="Scripts/common.js"></script>
    </div>
    <div class="large-9 medium-9 columns " style="padding-left: 0;">


   
  <div class="row">
<%--Nishu7/4/2015 --%>
<%--<div class="col-xs-3 col-sm-3 col-md-3 col-lg-3 hide-for-small"><sub:submenu ID="Submenu1" runat="server"  /></div>--%>
<%--<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">--%>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
     
        <div class="row  bg-primary hide-for-small-only">
        <center>
        <div class="large-12 columns" style=" color:white; font-size:17px; font-weight:bold; background:#494e6b; text-align:left ">
      Computation of Income and Tax Thereon
        </div>
        </center>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        
<div class="row">
<div class="large-12 columns text-center">
<asp:Button ID="btnSendMail" runat="server" Text="Send EMail" onclick="btnSendMail_Click" class="radius button"  style="width:223px" />
&nbsp;
<asp:Button ID="btnPDF" runat="server" Text="Print Computation" onclick="btnPDF_Click" class="radius button"  style="width:223px" />
&nbsp;
<asp:Button ID="btnCA" runat="server" Text="Get Reviewed By CA?" onclick="btnCA_Click" class="radius button"  style="width:223px" />
<%--<asp:Button ID="Button1" runat="server" Text="Get Reviewed By CA?" PostBackUrl="~/Pricings.aspx" class="radius button"  />--%>
<br />
<asp:Literal ID="ltStatement" runat="server">
</asp:Literal>
 
<%-- <asp:Literal ID="ltDesc" runat="server" ></asp:Literal>--%>
 <asp:HiddenField ID="hdnNameID" runat="server" />
</div>
</div>


<%--</div>--%>
      </div>
    

 <input type="button" value="click me" id="btn1" style="display:none;" />
    <div  id="divPop" style="display: none">                          
<p>You have <span id="divAmt"></span> . Do you want to proceed?</p>
<asp:Label ID="Label8" runat="server" ForeColor="Red" Font-Bold="True" Text="You have 25000 amount payable. Do you want to proceed? "
    Visible="False"></asp:Label>
    <div style="display:none">
    <asp:Button ID="Button12" runat="server" Text=" Yes " />
    &nbsp;
    <asp:Button ID="Button13" runat="server" Text=" No " />
    </div>   
    </div>
 
   
</div>
</div>
<%-- Files Popup --%>
 <div id="popupdiv1" style="width: auto; display:none; min-height: 0px; height: 62.04px;position: fixed;top: 15%;
        left: 25%;
        width: 52%;
        height: 45%;
        padding: 16px;
       
        background-color:white;
        z-index:1002; " class="ui-dialog-content ui-widget-content ui-corner-all">
<%--  <div class="ui-dialog ui-widget ui-widget-content ui-corner-all">--%>
 <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix" style="    padding: .2em 1em;
    position: relative;">
 <span class="ui-dialog-title" style="    font-weight: bold;
    font-size: 19px;">Upload Files &nbsp;<span style="color:white; font-size:12px;">(Extensions allowed: pdf,jpg,gif,png,doc,docx,xls,xlsx,xml,csv,txt,zip,rar)</span></span><a id="close" href="#"><span style="    font-weight: bold;
    font-size: 19px;">X</span></a>
 </div>

 <p>
 <% if (!Request.Url.ToString().Contains("Profile"))
       {  %>
<fileupload:fu ID="fu1" runat="server" />
<%} %>
 </p>
 <%--</div>--%>
 
 </div>
<div  id="BlackContent" style="display:none;background-color: #101010; 
    filter: alpha(opacity=70); 
    opacity: .30;
    width:200%;
    height:800px;
    z-index:400;
    position:absolute;
    top:0;
    left:0;  "></div>
 
    </form>
</body>
</html>