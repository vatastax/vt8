<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signatoryDetails.aspx.cs"
    Inherits="Presentation_signatoryDetails"  %>
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
    <title>The Interactive Platform for free e-filing Income Tax Returns in India</title>
   
    <link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="../foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
    <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
    <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../ITRStylesheet/styles/tabstrip.js" type="text/javascript"></script>
    <%-- <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />--%>
 <%--   <link href="../css/new_button.css" rel="stylesheet" type="text/css" />--%>
     <link href="../css/box_style.css" rel="stylesheet" type="text/css" />
      <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery_scripts.js" type="text/javascript"></script>
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
 
   
      <style type="text/css">
           .btnstyle:hover
           {
               background-color:#e14658;
           }
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
            background: rgba(167, 57, 70, 0.86);
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
            background:rgba(167, 57, 70, 0.86);
            border: 1px solid rgba(167, 57, 70, 0.86);
        }
    </style>
    <%--<script type='text/javascript'>       function scriptsAll() { try { alert('scripts all'); showhideLinkBtn(document.getElementById('grdState_ctl12_ddl1')); } catch (e) { alert(e) } }</script>--%>
     <script type="text/javascript">
         function ShowPopup(message) {
             $(function ($) {
                 $("#msg1").dialog({
                     title: "Save Message",
                     buttons: {
                         Ok: function () {
                             window.location = 'XMLRestore.aspx'
                         },
                         Close: function () {
                             $(this).dialog('close');
                         }
                     },
                     modal: true
                 });
                 //              return false;
             });
         };
    </script>

    <script type="text/javascript">
        $(document).ready(function ($) {
            $('#cssmenu>ul>li').eq(8).addClass('active');
            Fileupload(); //function to provide event for "My Files" link
            $('#Details').css("display", "block");
            $('#ass').click(function () {
                //alert('salary');
                $('#Details').slideToggle();
            });
            $("#btnmenu").click(function () {
                $("#divmenu").slideToggle();
            });

        });

        function handleIt() {
            alert('ulo');
        }
    </script>
    
        <script type="text/javascript">
    function chgData(id) {
        try {
            if (id.value == '1') {
                document.getElementById('<%= txtSignatory.ClientID %>').disabled = true;
                document.getElementById('<%= txtFatherSignatory.ClientID %>').disabled = true;
                document.getElementById('<%= txtPANSignatory.ClientID %>').disabled = true;
                //document.getElementById('<%= txtPlace.ClientID %>').disabled = true;
                //document.getElementById('<%= txtDateofReturn.ClientID %>').disabled = true;
            }
            else {
                document.getElementById('<%= txtSignatory.ClientID %>').disabled = false;
                document.getElementById('<%= txtFatherSignatory.ClientID %>').disabled = false;
                document.getElementById('<%= txtPANSignatory.ClientID %>').disabled = false;
                //document.getElementById('<%= txtPlace.ClientID %>').disabled = false;
                //document.getElementById('<%= txtDateofReturn.ClientID %>').disabled = false;
            }
        }
        catch (e) {
            alert(e);
        }
    }

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
    <script type="text/javascript">
        var IsDDChange = 'false';
        var TimerVal = 10;
        function pageLoad() {
            if (document.getElementById('hdnTaxStatus').value == 'TP') {
                document.getElementById('Button16').click();
            }
        }
        function enableButton(id) {
            try {
                if (id.checked) {
                    document.getElementById('btnSubmitSignatory').removeAttribute('disabled');
                    //$(document).ready(function () {
                    $("btnSubmitSignatory").click(function () {
//                        alert(IsDDChange);
//                        if (IsDDChange == 'false')
//                            showTimer();
//                        showSpinner();
                    });
                    //});
                }
                else
                    document.getElementById('btnSubmitSignatory').setAttribute('disabled', true);
            }
            catch (e) { alert(e); }
        }

        function showSpinner() {
            //alert(IsDDChange);
            if (IsDDChange == 'false') {
                showTimer22();
                setTimeout(hideSpinner, 10000);
                document.getElementById('divSpinner').style.display = 'block';                
            }
            else
                IsDDChange = 'false';
        }
        function showTimer22() {
            //alert('showTimer');
            if (TimerVal > 0) {
                //alert(TimerVal.toString());
                document.getElementById('spinTime').innerHTML = TimerVal.toString();
                TimerVal = TimerVal - 1;
                setTimeout(showTimer22, 1000);
            }
            else
                TimerVal = 10;
        }
        function hideSpinner() {
            //alert('hide it');
            document.getElementById('divSpinner').style.display = 'none';
        }
        function setIt() {
            IsDDChange = 'true';
        }
        function loadPage() {
            //alert('page loaded');
        }
    </script>
    
</head>
<body onload="loadPage();" onunload="alert('unload');" style="overflow:hidden" >
    <%--  onunload="HandleClose(0)">--%>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" >
    </asp:ScriptManager>
    <div id="divSpinner" style=" display:none; position:absolute; width:100%; text-align:center; padding-top:295px; z-index:111; background-color:White; height:100%; background-image:url('../images/spinner.gif'); background-repeat:no-repeat; background-position:center center;">
    <center><span id="spinTime" style="font-weight:bold; font-size:larger; color:#e14658">10</span><br />
    File Generation in Progress...
    </center>
    <%--<img src="../images/spinner.gif" />--%>
    </div>
    <script type="text/javascript" language="javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            showSpinner();
        }
        //following event is being used as the last event after page loaded for updatepanel asynchronous events
        function EndRequestHandler(sender, args) {
            try {
                Remove();
                Removeplusimage_menu();
                Remove();
                //alert('ended');
            }
            catch (e) { alert('error in EndRequestHandler : ' + e); }
        }
    </script>
    <asp:UpdatePanel ID="updHiddens" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnTaxStatus" runat="server" />

         <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender6" runat="server" CancelControlID="btn123"
                                            DynamicServicePath="" Enabled="True" PopupControlID="pnlChallan" TargetControlID="Button16"
                                            BackgroundCssClass="ModalPopupBG">
                                        </ajaxToolkit:ModalPopupExtender>

 <asp:Button ID="Button16" runat="server" Text="Remove" class="button" formnovalidate
                                            Height="53px" Width="162px" Style="border-radius: 3px; display:none;" />


    </ContentTemplate>
    </asp:UpdatePanel>

    <asp:Panel ID="pnlChallan" runat="server" Style="display: none; border: 0px solid #a6c9e2;
        height: 180px; background-color: White;width:540px;padding:10px">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix"
                    style="border-radius: 0px">
                    <span class="ui-dialog-title" style="font-size: 20px">Confirmation</span>
                </div>
                <p style="padding: 10px">
                    Please Select an Action to Resume Further</p>
                <p style="text-align: center">
                    <asp:Button ID="btnPDF" runat="server" class="button radius" formnovalidate="" Height="53px"
                                                OnClientClick="javascript:window.open('ChallanPDF.aspx');"  Text="Print Challan" />
                                                <a href="https://onlineservices.tin.egov-nsdl.com/etaxnew/tdsnontds.jsp" class="button radius" target="_blank" style="cursor:pointer; text-decoration:none;">Online Deposit</a>
                    <%--<asp:Button ID="Button15" runat="server" Text="Online Deposit" class="button radius" PostBackUrl="https://onlineservices.tin.egov-nsdl.com/etaxnew/tdsnontds.jsp" formnovalidate />--%>
                    <asp:Button ID="Button6" runat="server" Text="Remind Me Later" class="button radius" PostBackUrl="~/Presentation/manageLinking.aspx?VType=104" formnovalidate /></p>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="btn123" runat="server" style="display:none;" />
    <%--------------------nishu 14-3-2016 --------------------------%>
    <div class="row show-for-small-only" style="background-color: White; margin-top: -20px">
       
        <div class="small-9 columns">
         
            <a href="Default.aspx">
                <img src="../images/logo2.png" style="width: 180px; height: auto" alt="logo" /></a>
        </div>
        <div class="small-3 columns text-right">
            <img src="../images/menu1.JPG" id="btnmenu" style="margin-top: 15px; width: 40px;
                height: 40px" alt="menu" />
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
                    <asp:Literal ID="ltUser" runat="server" /></span> <a href="logout.aspx">[Logout]
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
  <div>
    <div class="large-3 medium-3 columns  " style="left: 0; padding: 0; ">
        <asp:UpdatePanel ID="Upleft" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="ass" class="show-for-large-only" style="width: 300px; background-color: #565656;
                    -webkit-border-radius: 4px; -moz-border-radius: 4px; border-radius: 4px; padding: 3px;
                    -moz-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); -webkit-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                    box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); text-align: center; -webkit-border-radius: 4px;
                    -moz-border-radius: 4px; border-radius: 4px; padding: 3px; -moz-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                    -webkit-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                    margin-left: 3px">
                    <span style="color: White">Assessee Details [<asp:LinkButton ID="lbtnEditProf" runat="server" Text="Edit" OnClick="lbtnEditProf_Click" ToolTip="Click this link to Change Current Profile Details" style="font-size:13px" ForeColor="White"></asp:LinkButton>]</span>
                </div>
                <div id="Details" class="hidden-for-small-only" style="font-family: 'Open Sans', sans-serif;
                    width: 300px; display: none">
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
    <div class="large-12">
        <div style="margin-top: -25px">
            <center>
                <span style="font-size: 20px"><b>
                <asp:Literal ID="ltTitle" runat="server" Text="Verify & Submit ITR"></asp:Literal>
                </b></span>
            </center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="login-wrap">
                    <div class="row">
                        <div class="large-12 columns" style="margin-bottom: -10px;">
                            <span class="headsize"><b>Self/Represenatative</b></span>
                            <asp:DropDownList ID="ddRepSelf" runat="server" ssClass="login-ddl" OnSelectedIndexChanged="ddRepSelf_SelectedIndexChanged"
                                AutoPostBack="true" onchange="setIt();">
                                <asp:ListItem Text="Self" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Representative" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%--<div style="margin-top: -8px;">--%>
                        <div class="large-12 columns" style="margin-bottom: -10px;">
                            <span class="headsize"><b>Name of Signatory</b></span>
                            <asp:TextBox required ID="txtSignatory" runat="server" Enabled="false" placeholder="Enter Name of Signatory" Width="320px"></asp:TextBox>
                        </div>
                        <%--<div style="margin-top: -8px;">--%>
                        <div class="large-12 columns" style="margin-bottom: -10px;">
                            <span class="headsize"><b>Father Name of Signatory</b></span>
                            <asp:TextBox required ID="txtFatherSignatory" runat="server" placeholder="Enter Father Name of Signatory" Width="320px"></asp:TextBox>
                        </div>
                        <%--<div style="margin-top: -8px;">--%>
                        <div class="large-12 columns" style="margin-bottom: -10px;">
                            <span class="headsize"><b>PAN of Signatory</b></span>
                            <asp:TextBox required ID="txtPANSignatory" placeholder="Enter PAN of Signatory" runat="server"
                                Enabled="false" Width="320px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="txtPANRepvalid" runat="server" Display="Dynamic"
                                ControlToValidate="txtPANSignatory" ErrorMessage="Please Fill Correct PAN" ValidationExpression="^[\w]{3}(p|P|c|C|h|H|f|F|a|A|t|T|b|B|l|L|j|J|g|G)[\w][\d]{4}[\w]$"></asp:RegularExpressionValidator>
                        </div>
                        <%--<div style="margin-top: -8px;">--%>
                        <div class="large-12 columns" style="margin-bottom: -10px;">
                            <span class="headsize"><b>Place of Filing of Return</b></span>
                            <asp:TextBox required ID="txtPlace" placeholder="Enter Place of Filing" runat="server" Width="320px"></asp:TextBox>
                        </div>
                        <%--<div style="margin-top: -8px;">--%>
                        <div class="large-12 columns" style="margin-bottom: -10px;">
                            <span class="headsize"><b>Date
                                <asp:TextBox required ID="txtDateofReturn" onchange="validateDate(this,'01/01/2006');" placeholder="DD/MM/YYYY" runat="server" Width="320px"></asp:TextBox>
                        </div>
                        <div class="large-12 columns" style="color:#494E6B;font-size:12px;font-weight:bold; font-size:12px; color:#494E6B; font-weight:bold; margin-top:-35px; ">
                        <input type="checkbox" id="chk1" style=" " onclick="enableButton(this);" >I agree, data is correct and complete as per rules & regulation under Income Tax Act 1961</input>
                        <%--<asp:CheckBox ID="chkAcceptance" runat="server" Text="I agree, data is correct and complete as per rules & regulation under Income Tax Act 1961" />--%>
                        </div>
                        
                        <div class="large-12 columns">
                            <center>
                                <asp:Button ID="btnSubmitSignatory" Style="border-radius: 5px; font-size: 14px;" Enabled="false" OnClientClick="showSpinner();"
                                    runat="server" CssClass="btnstyle" Text="Submit" OnClick="btnSubmitSignatory_Click"  />
                                <asp:Button ID="btnback" runat="server" Style="border-radius: 5px; font-size: 14px;"
                                    CssClass="btnstyle" Text="  Back  " OnClick="btnback_Click" OnClientClick="backIt();"
                                    formnovalidate />
                            </center>
                        </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        
    </div>
    
    </div>
      </div>
      </div>
        <div id="msg1" style="display: none; max-height: 80px;">
        ITR XML saved successfully.<br />
        To upload XML please click on below link
    </div>

    <%-- Files Popup --%>
<div id="popupdiv1" style="display: none;position: absolute;top: 15%;
        left: 25%;
        width: 50%;
        height: 100%;
        padding: 16px;
        border: 1px solid #e54658;
        background-color:white;
        z-index:1002;
        overflow: auto;">
      <div style="border: 1px solid rgba(25, 185, 154, 0.97);
    background: rgba(60, 63, 83, 0.62) url(images/ui-bg_gloss-wave_75_2191c0_500x100.png) 50% 50% repeat-x;
    color: #eaf5f7;
    font-weight: bold; padding:7px;"><span style="
    margin: .1em 16px .1em 0; width:700px">  Upload Files<a href="#" id="close" style=" margin-left:450px"><span style="color:White; text-align:right; font-weight:bold"> X</span></a></span> <br />
 </div>

 
    <div id="popup_Files"  >
    <% if (!Request.Url.ToString().Contains("Profile"))
       {  %>
<fileupload:fu ID="fu1" runat="server" />
<%} %>
</div>
        </div>
<div  id="BlackContent" style="display:none;background-color: #101010; 
    filter: alpha(opacity=70); 
    opacity: .30;
    width:100%;
    height:800px;
    z-index:400;
    position:absolute;
    top:0;
    left:0;  "></div>
    </form>
</body>
</html>