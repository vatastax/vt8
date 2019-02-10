<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lstGrids.aspx.cs" Inherits="Presentation_lstGrids" %>

<%@ Register Assembly="controlgrid" Namespace="controlgrid" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
<%@ Register Src="../menu_header.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu.ascx" TagName="menu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../mobilemenu2.ascx" TagPrefix="mob1" TagName="menu1" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../Presentation/MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="~/UserControls/header.ascx" TagName="menuheader" TagPrefix="header" %>
<%@ Register Src="~/UserControls/menunew.ascx" TagName="menu" TagPrefix="mm" %>


<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>
<!DOCTYPE html >
<html class="no-js" lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <title>The Interactive Platform for free e-filing Income Tax Returns in India</title>
    <script src="../scripts/jquery.js" type="text/javascript"></script>
    <script src="../foundation-5.5.0/jquery.min.js" type="text/javascript"></script>
    <script src="../scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />
    <script type="text/javascript" src="../scripts/menu.js"></script>
    <link href="../foundation-5.5.0/css/foundation.min.css" rel="stylesheet" type="text/css" />
    <link href="../styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../foundation-5.5.0/js/foundation.min.js" type="text/javascript"></script>
    <link href="../StaticStylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />
    <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <link href="../css/box_style_tds.css" rel="stylesheet" type="text/css" />
    <%--<script src="Scripts/common.js" type="text/javascript"></script>--%>
    <script src="Scripts/JScript.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#div2").click(function () {
                $("#div3").slideToggle();
            });

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnmenu").click(function () {
                $("#divmenu").slideToggle();
            });

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#olditr").click(function () {
                $("#assdet1").hide();
                $("#detolditr").slideToggle();
            });

        });
    </script>
    <script type="text/javascript">
        function expandIt() {
            $(document).ready(function () {
                $("#assdet").click(function () {
                    $("#detolditr").hide();
                    $("#assdet1").slideToggle();
                });
            });
        }
        function setDDSelection(id) {
            try {
                //alert(id);
                document.getElementById('hdnDDListSelection').value = id.value;
                //alert(document.getElementById('hdnDDListSelection').value);
                window.location = 'lstGrids.aspx?vtype=3002&ml=' + id.value;

            }
            catch (e) { alert(e); }
        }
    </script>
    <style type="text/css">
        .content
        {
            overflow: hidden;
            width: 970px;
        }
        .PAN
        {
            text-transform: uppercase;
        }
    </style>

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert('Value Should Be Numeric!!');
                return false;
            }
            return true;
        }
    </script>
</head>
<body onload="expandIt()">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%-------------header ----------------%>
  <%--  <div class="row">
        <div class="large-12 columns hide-for-small-only" style="margin-top:-18px">
            <%
                if (Session["ay"] != null)
                {
            %>
            <main:mainmenu ID="mm1" runat="server" />
            <%
                }
                else
                {
            %>
            <main2:mainmenu2 ID="mm12" runat="server" />
            <%
                }
            %>
        </div>
    </div>--%>
    <asp:HiddenField ID="hdnDDListSelection" runat="server" />
    <asp:HiddenField ID="hdnFiller" runat="server" />
    <asp:HiddenField ID="hdnRegularCorrection" runat="server" />
    <asp:HiddenField ID="hdnDel" runat="server" />
    <%--show breadcrumps in all views nishu 8/4/2015--%>
  <%--  <div class="row">
        <div class="large-12 columns">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" ForeColor="#333333" CurrentNodeStyle-ForeColor="black"
                CurrentNodeStyle-Height="25px">
            </asp:SiteMapPath>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
    </div>--%>
  <%--  <div class=" hide-for-small-only">
        <main:menu ID="Mainmenu1" runat="server" />
    </div>--%>
    <%---------------show assesee detail on medium screen -------------------%>
  <%--  <div class="row show-for-medium-only">
        <div class="large-12 columns  ">
            <%
                if (Session["ay"] != null && Session["NameID"] != null)
                {
            %>
            <mob3:mediummenu ID="Mediummenu1" runat="server" />
            <%} %>
        </div>
    </div>--%>
    <%-------------show header on mobile screen --------------------------------------------------------%>
   <%-- <div class="row show-for-small-only">
        <div class="small-12 columns" style="vertical-align: top;">
            <a href="Default.aspx">
                <img src="../images/logo2.png" style="width: 240px; height: auto" />
            </a>
        </div>
    </div>--%>
    <%----------------show username on mobile menu --------------------%>
  <%--  <div class="row show-for-small-only">
        <div class="large-12 columns text-right">
            Welcome
            <asp:Literal ID="ltUser" runat="server" />
[Logout] </a>
        </div>
    </div>--%>

  
  
  
   
    <%-- <sub:submenu ID="sub1" runat="server" />--%>
    <%--details on side ---%>
   <%-- <div class="show-for-large-only">
        <%
            if (Session["ay"] != null && Session["NameID"] != null)
            {
        %>
        <menu:side ID="Sidemenu" runat="server" />
        <%} %>
    </div>--%>
    <%----nishu ------%>
     <div class="row show-for-small-only" style="background-color: White; margin-top: -20px">
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
                Welcome <span style="color: Black; font-family: 'Open Sans','sans-serif'; font-size: 15px;
                    font-weight: bold; color: #008CBA; text-transform: capitalize">
                    <asp:Literal ID="Literal2" runat="server" /></span> <a href="logout.aspx">[Logout]
                </a>
            </div>
        </div>
        <%----------------show username on mobile menu --------------------%>
    </div>
    <div class="row show-for-small-only">
        <div class="large-12 columns ">
            <mob2:mobmenu ID="mobmenu" runat="server" />
        </div>
    </div>
    <header:menuheader ID="header" runat="server"></header:menuheader>
      <div class="large-3 medium-3 columns  " style="left: 0; padding: 0; width: 300px">
        <asp:UpdatePanel ID="Upleft" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="ass" class="show-for-large-only" style="width: 242px; background-color: #565656;
                    -webkit-border-radius: 4px; -moz-border-radius: 4px; border-radius: 4px; padding: 3px;
                    -moz-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); -webkit-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                    box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); text-align: center; -webkit-border-radius: 4px;
                    -moz-border-radius: 4px; border-radius: 4px; padding: 3px; -moz-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                    -webkit-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                    margin-left: 3px">
                    <span style="color: White">Assessee Details</span>
                </div>
                <div id="Details" class="hidden-for-small-only" style="font-family: 'Open Sans', sans-serif;
                    width: 290px; display: none">
                    <sub:submenu ID="Submenu2" runat="server" />
                </div>
                <div id="dd" style="overflow-y: auto; height: 475px; width: 265px" class="hide-for-small-only">
                    <mm:menu ID="menu1" runat="server"></mm:menu>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="large-9 medium-9 columns " style="padding-left: 0;">
        <asp:UpdatePanel ID="Upright" runat="server">
          <ContentTemplate>
          <%if (Request.QueryString["vtype"] != null)
            {%>
            <div class="hide-for-small-only hide-for-medium">
            <div class="large-12 columns" style="background-color: #494e6b; color: White; padding: 4px;font-weight:bold; font-size:15px;">
               <% if (Request.QueryString["vtype"].ToString() == "3002")
                  {
                 %>
                Deductee Details
                <%}
                  else if (Request.QueryString["vtype"].ToString() == "3003")
                  {
                   %>
                   Salary Details
                   <%}
                     else if (Request.QueryString["vtype"].ToString() == "3001")
                  {
                      %>
                      Challan Details
                      <%} %>
            </div>
            </div>
            <%
            } %>
            <br /><br />
            <div class="row">
    <div class="large-12 columns">
        <%
            if (Request.QueryString["vtype"].ToString() == "3002")
            { %>
            <center>
         <asp:Label ID="lblChallanNo" runat="server" Text="Select Challan Number"></asp:Label>
        <asp:DropDownList ID="ddTDSList" Width="250px" runat="server"  AutoPostBack="false"
            onchange="setDDSelection(this);" 
            onselectedindexchanged="ddTDSList_SelectedIndexChanged">
        </asp:DropDownList>
        </center>
        <%} %>
    </div>
    </div>
 
    <%--<div class="row">
        <div class="large-12 columns">
            <div class="large-12 columns" style="overflow: auto;">
               
                        <div id="ControlGrid" runat="server">
                            <cc1:DynamicControl ID="dny_Grd_Returns2" runat="server" />
                        </div>
               
            </div>
        </div>
    </div>--%>
    <%--Div to show empty records message- jaipal--%>
    <div class="row">
        <div class="large-12 columns ">
            <asp:Panel ID="pnlNoRecord" runat="server" Visible="false ">
                <div class="login-wrap" style="margin-top: 50px; float: left">
                    <span style="font-size: xx-large">Empty Records</span>
                    <div class="form">
                        <div>
                            Note:</div>
                        <div>
                            Click Back!</div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
    <%--Div to show empty records message--%>
      <div class="row">
        <div class="large-12 columns text-right" style="overflow:auto;">
        <VATAS:VGrid ID="VGrid1" runat="server" />
        <br />          
        </div>         
    </div>

    <div class="row">
    <div class="large-12 columns text-right">
      <asp:Button ID="btnback" runat="server" CausesValidation="false" CssClass="radius button"
                Text="Back" OnClick="btnback_Click" />
                <asp:Button ID="btnAdd" runat="server" CausesValidation="false" CssClass="radius button"
                Text="Add Challan" OnClick="btnAdd_Click" />
                <% if (Session["Project"].ToString() == "tds2")
                   { %>
                   <asp:Button ID="btnPay" runat="server" CausesValidation="false" CssClass="radius button"
                Text="Pay" OnClick="btnPay_Click" />
                <%} %>
    </div>
    </div>
          </ContentTemplate>
        </asp:UpdatePanel>
    </div>
     <div class="row">
        <div class="large-12 columns">
           
            <hr />
            <span>© 2015 Vatas Infotech Pvt.Ltd.</span>
        </div>
    </div>
    </form>
</body>
</html>
