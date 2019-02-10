<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" EnableSessionState="True" EnableViewState="true" CodeFile="Main.aspx.cs" Inherits="Presentation_Main" Theme="incometax"%>

<%@ Register Assembly="controlgrid" Namespace="controlgrid" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
<%@ Register Src="../menu_header.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../mobilemenu2.ascx" TagPrefix="mob1" TagName="menu1" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %><%@ Register Src="MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>
<%@ Register Src="~/SubUserMenu.ascx" TagPrefix="sum" TagName="ss" %>

<!DOCTYPE html >
<html class="no-js" lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <title>Control Panel</title>
     <!--Master javascript file-->
        <%--<script src="../js/MasterJScript.js" type="text/javascript"></script>--%>
         <script src="Scripts/JScript.js" type="text/javascript"></script>
        <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <!--Master javascript file-->

     <!--master style sheet-->
    <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />   
    <link href="../css/new_button.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        // $(document).ready(function () {
        $('.ui-dialog-titlebar span').click(function () {
            disablebackground();
        });
        $(document).ready(function () {
            //alert('gg');
            //disablebackground();
           
            $("#dny_Grd_ITRInfo_Dynamic_Gridview_ctl01_txt_Name_hdr").bind("keypress", function (e) {
                if (e.keyCode == 13) {
                    return e.keyCode = 9;
                }
            });

            $("#dny_Grd_ITRInfo_Dynamic_Gridview_ctl01_txt_Name_hdr").bind("keypress", function (e) {
                if (e.keyCode == 13) {
                    return e.keyCode = 9;
                }
            });


            //});
        });
    </script>
    <!--master style sheet-->
   <%-- <script type="text/javascript">
        $(document).ready(function () {

            $("#hide").click(function () {
                $("#div1").slideToggle();
            });

        });
    </script>--%>
  <%--  <script type="text/javascript">
        $(document).ready(function () {
            $("table th").css(
        { "color": "black", "background-color": "#c1dbfa" }

        )
            $("table tr:even").css("background-color", "#F9F9F9");
            $("table tr:odd").css("background-color", "White");

            $('#dny_Grd_ITRInfo_Dynamic_Gridview').css(
          { "width": "100%" }
          )
            $('#dny_Grd_ITRInfo_Dynamic_Gridview_ctl03_Btn_Cancel_Search').css(
            { "border-radius": "3", "top": "-3", "left": "2", "background-color": "#007095","color":"White" }
            )

        });
    </script>--%>
    <script type="text/javascript">
        function getPopup() {
            $(document).ready(function () {
                $("#a2").click();
            });
        }

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
                //alert('show it');
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

        var IsNewBtnClicked = 'false';
        //To show back the controls
        function ShowExtras() {
            try {
                document.getElementById('row_AY').style.display = 'block';
                document.getElementById('row_DD').style.display = 'block';
                document.getElementById('row_ITR').style.display = 'block';
                document.getElementById('divEmployer').style.display = 'block';
                IsNewBtnClicked = 'true';
            }
            catch (e) { alert(e); }
        }

        //To Show Previous Returns Listing
        function showIt() {
            $(document).ready(function () {
                $("#assdet1").hide();
                $("#detolditr").slideToggle();
            });
        }
        function showListing() {
            $("#olditr").click();
        }
        //To Show Assessment Details
        function hideIt() {
            $(document).ready(function () {
                //alert('hide it');
                $("#detolditr").hide();
                $("#assdet1").slideToggle();

                if (IsNewBtnClicked != 'true') {
                    document.getElementById('ddlWhichSection').selectedIndex = 6;
                    setSection();


                }
            });
        }

        function hideIt_Original() {
            $(document).ready(function () {
                $("#detolditr").hide();
                $("#assdet1").slideToggle();

                //                if (IsNewBtnClicked != 'true') {
                document.getElementById('ddlWhichSection').selectedIndex = 0;
                removeIt();
                //                  setSection();
                //                }
            });
            }            

            function removeIt() {
                document.getElementById("ddlWhichSection").remove(6);
            }

    </script>
    <script src="../Popup/jquery.min.js" type="text/javascript"></script>
    <script src="../Popup/jquery-ui.js" type="text/javascript"></script>
    <link href="../Popup/jquery-ui.css" rel="stylesheet" type="text/css" />
     <script src="Scripts/jquery_scripts.js" type="text/javascript"></script>
     <script type="text/javascript">
        $(document).ready(function () {
            $('#a2').click(function () {
                alert_custom('You can not have multiple returns within same Assessment Year',1,'Error','','','',['OK'],'200','100px');
//                $('.ui-dialog-content').css('height', '80px');
//                $('.ui-dialog').css('top', '100px');
            });
        });
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
        #divdisable
      {display:none;
       background-color: #101010; 
    filter: alpha(opacity=70); 
    opacity: .30;
    width:100%;
    height:800px;
    z-index:400;
    position:absolute;
    top:0;
    left:0;
      }   
   
    .hrnew
    {
        height:2px;
        background-image:-webkit-linear-gradient(left, rgba(0, 0, 0, 1), rgba(0, 0, 0, 1), rgba(0, 0, 0, 1));
        opacity:1.0;
        margin-top:4px;
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
        function setHdn(id) {
            
            //alert('hdnActiveIndx : ' +  document.getElementById('<%= hdnActiveIndx.ClientID %>').value);
            document.getElementById('hdn2').value = id.id;
            //alert(document.getElementById('hdn2').value);
            //document.getElementById('butSubmit').click();
        }

        
    </script>
    
    <script src="Scripts/jquery.min.js"  type="text/javascript" ></script>
    <link href="../ITRStylesheet/styles/responsive-tables.css" rel="stylesheet" type="text/css" />
    <script src="../ITRStylesheet/styles/responsive-tables.js" type="text/javascript"></script>
 <%--   <script type="text/javascript">
        $(document).ready(function ($) {
            $("table").addclass('responsive');
        });
    </script>--%>
    <link rel="icon" type="image/png" href="../images/fevicon.png"/>
<link rel="shortcut icon" type="image/png" href="../images/fevicon.png"/>

<%--StyleSheets for information box - jaipal--%>
<script src="../js/jquery-1.10.0.min.js" type="text/javascript"></script>

<link href="../css/box_style.css" rel="stylesheet" type="text/css" />
    <script src="../js/ie_compatibility/es5-shim.min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/html5shiv.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/nwmatcher-1.2.5-min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/respond.min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/selectivizr-1.0.3b.js" type="text/javascript"></script>
    <script type="text/javascript">
        function showDataDD(id) {
            if (id.value == '2015-2016') {
                document.getElementById('txtDueDate').value = '07/09/' + id.value.substring(0, 4);
                document.getElementById('ddlWhichSection').selectedIndex = "1";
            }
            else if (id.value == '2016-2017') {
                document.getElementById('txtDueDate').value = '05/08/' + id.value.substring(0, 4);
                document.getElementById('ddlWhichSection').selectedIndex = "0";
            }
            else {
                document.getElementById('txtDueDate').value = '31/07/' + id.value.substring(0, 4);
                document.getElementById('ddlWhichSection').selectedIndex = "1";
            }
        }

        function setTRP(id) {
            try {
                if (document.getElementById('chkTRP').checked) {
                    document.getElementById('divTRP').style.display = 'block';
                    document.getElementById('divTRPName').style.display = 'block';
                    document.getElementById('divTRPPaid').style.display = 'block';
                }
                else {
                    document.getElementById('divTRP').style.display = 'none';
                    document.getElementById('divTRPName').style.display = 'none';
                    document.getElementById('divTRPPaid').style.display = 'none';
                }
            }
            catch (e) { alert(e); }
        }

        function setSection() {
            try {
                if (document.getElementById('ddlWhichSection').value == '17') {
                    document.getElementById('ddlReturnType').selectedIndex = 1;                    
                }
                else {
                    document.getElementById('ddlReturnType').selectedIndex = 0;
                }
                document.getElementById('ddlReturnType').disabled = 'true';
                if (document.getElementById('ddlWhichSection').value == '17')
                    document.getElementById('ddlWhichSection').disabled = 'true';

                if (document.getElementById('ddlReturnType').selectedIndex == 1 || document.getElementById('ddlWhichSection').value == '18') {                    
                    document.getElementById('lblRecieptNO').style.display = 'block';                    
                    document.getElementById('txtRecieptNo').style.display = 'block';                    
                    document.getElementById('lblOrigionalReturn').style.display = 'block';                    
                    document.getElementById('divNotice').style.display = 'block';                    
                    document.getElementById('txtDateofReturn').style.display = 'block';                    
                    if (document.getElementById('reqq1') != null)
                        document.getElementById('reqq1').style.display = 'block';
                    
                    //document.getElementById('RequiredFieldValidator1').style.display = 'block';
                    //  reqq1.ControlToValidate = "txtRecieptNo";
                    //                RequiredFieldValidator1.ControlToValidate = "txtDateofReturn";

                    if (document.getElementById('ddlWhichSection').value == '18') {
                        document.getElementById('divNotice').style.display = 'block';
                        //  document.getElementById('RequiredFieldValidator2').style.display = 'block';
                        //                    RequiredFieldValidator2.ControlToValidate = "txtNotice";
                    }
                }
                else if (document.getElementById('ddlReturnType').selectedIndex == 0) {
                    document.getElementById('lblRecieptNO').style.display = 'none';
                    document.getElementById('txtRecieptNo').style.display = 'none';
                    document.getElementById('lblOrigionalReturn').style.display = 'none';
                    document.getElementById('divNotice').style.display = 'none';
                    document.getElementById('txtDateofReturn').style.display = 'none';
                    if (document.getElementById('reqq1') != null) {
                        document.getElementById('reqq1').style.display = 'none';
                        ValidatorEnable(document.getElementById('reqq1'), false);
                    }                    
                    document.getElementById('divNotice').style.display = 'none';
                    //document.getElementById('RequiredFieldValidator2').style.display = 'none';
                    //ValidatorEnable(document.getElementById('RequiredFieldValidator2'), false);
                }
                else {
                    document.getElementById('divNotice').style.display = 'none';
                }
                if (document.getElementById('ddlWhichSection').value == '18' || document.getElementById('ddlWhichSection').value == '13' || document.getElementById('ddlWhichSection').value == '14' || document.getElementById('ddlWhichSection').value == '15' || document.getElementById('ddlWhichSection').value == '16') {
                    document.getElementById('divDON').style.display = 'block';
                    //document.getElementById('RequiredFieldValidator3').style.display = 'block';
                    //ValidatorEnable(document.getElementById('RequiredFieldValidator3'), false);
                }
                else {
                    document.getElementById('divDON').style.display = 'none';
                    if (document.getElementById('ddlWhichSection').value == '17')
                        document.getElementById('divNotice').style.display = 'none';
                    //document.getElementById('RequiredFieldValidator3').style.display = 'none';
                    //ValidatorEnable(document.getElementById('RequiredFieldValidator3'), false);
                }
            }
            catch (e) { alert(e); }
        }

        function setPortugese() {
            try {
                if (document.getElementById('ddCivilCode').value == 'N') {
                    document.getElementById('divSpouse').style.display = 'none';
                    document.getElementById('divSpousePAN').style.display = 'none';
                    document.getElementById('txtSpouse').value = '';
                    document.getElementById('txtPAN').value = '';
//                    document.getElementById('req2').style.display = 'none';
//                    document.getElementById('req3').style.display = 'none';
//                    ValidatorEnable(document.getElementById('req2'), false);
//                    ValidatorEnable(document.getElementById('req3'), false);
                }
                else {
                    document.getElementById('divSpouse').style.display = 'block';
                    document.getElementById('divSpousePAN').style.display = 'block';
//                    document.getElementById('req2').style.display = 'block';
//                    document.getElementById('req3').style.display = 'block';
                }
            }
            catch (e) { alert(e); }
        }

        function setReturnType() {
            if (document.getElementById('ddlWhichSection').value == '17')
                document.getElementById('ddlWhichSection').selectedIndex = 1;

            if (document.getElementById('ddlReturnType').selectedIndex == 0) {
                document.getElementById('lblRecieptNO').style.display = 'none';
                document.getElementById('txtRecieptNo').style.display = 'none';
                document.getElementById('lblOrigionalReturn').style.display = 'none';
                document.getElementById('divNotice').style.display = 'none';
                
                document.getElementById('txtDateofReturn').style.display = 'none';
                document.getElementById('reqq1').style.display = 'none';
            }
            else if (document.getElementById('ddlReturnType').selectedIndex == 1) {
                document.getElementById('lblRecieptNO').style.display = 'block';
                document.getElementById('txtRecieptNo').style.display = 'block';
                document.getElementById('lblOrigionalReturn').style.display = 'block';
                document.getElementById('divNotice').style.display = 'block';
                document.getElementById('txtDateofReturn').style.display = 'block';
                document.getElementById('reqq1').style.display = 'block';
            }
            
            //            if (ddlReturnType.SelectedIndex == 0) {
            //                lblRecieptNO.Visible = false;
            //                txtRecieptNo.Visible = false;
            //                lblOrigionalReturn.Visible = false;
            //                txtDateofReturn.Visible = false;
            //                reqq1.Visible = false;
            //            }
            //            else if (ddlReturnType.SelectedIndex == 1) {
            //                reqq1.Visible = true;
            //                lblRecieptNO.Visible = true;
            //                txtRecieptNo.Visible = true;
            //                lblOrigionalReturn.Visible = true;
            //                txtDateofReturn.Visible = true;
            //            }
        }

        function validateFileUpload() {
            var fupload = document.getElementById('<%= fup1.ClientID %>');
            if (fupload.value.substring(fupload.value.toString().lastIndexOf('.')) != '.xml') {
                alert('Invalid File Format');
                fupload.value = '';
                return false;
            }
            else
                return true;
        }
    </script>
    <script type="text/javascript">
        //Auto Trigger while User Idle Function to prompt for Logout

        var timeoutID;
        function setup() {

            this.addEventListener("mousemove", resetTimer, false);
            this.addEventListener("mousedown", resetTimer, false);
            this.addEventListener("keypress", resetTimer, false);
            this.addEventListener("DOMMouseScroll", resetTimer, false);
            this.addEventListener("mousewheel", resetTimer, false);
            this.addEventListener("touchmove", resetTimer, false);
            this.addEventListener("MSPointerMove", resetTimer, false);
            startTimer();
        }
        setup();
        function startTimer() {
            // wait 2 seconds before calling goInactive
            timeoutID = window.setTimeout(goInactive, 500000);
        }
        function resetTimer(e) {
            window.clearTimeout(timeoutID);
            //    TimerStopBit = 0;
            //    TimerValMain = 1;
            //    TimerValDetail = 60;
            goActive();
        }
        function goInactive() {
            //openDialog2();
            $(document).ready(function () {
                if ($("div").hasClass('ui-widget-overlay')) {

                }
                else {
                    document.getElementById('aLogout').click();
                    document.getElementById('stimer').innerHTML = '02:00';
                    TimerStopBit = 0;
                    TimerValMain = 1;
                    TimerValDetail = 60;
                    showTimer();
                }
            });

            //alert('You are going to logout');
            // do something
        }
        function goActive() {
            // do something
            startTimer();
        }

        var TimerValMain = 1;
        var TimerValDetail = 60;
        var TimerStopBit = 0;
        function showTimer() {
            //    alert(TimerStopBit);
            //    alert(TimerValMain);
            //    alert(TimerStopBit);
            if (TimerStopBit == 0) {
                if (TimerValDetail > 1) {
                    TimerValDetail = TimerValDetail - 1;
                    document.getElementById('stimer').innerHTML = '0' + TimerValMain + ':' + ((TimerValDetail.toString().length > 1) ? TimerValDetail.toString() : '0' + TimerValDetail.toString());
                    setTimeout(showTimer, 1000);
                }
                else {
                    if (TimerValMain == 1) {
                        TimerValMain = 0;
                        TimerValDetail = 60;
                        setTimeout(showTimer, 1000);
                    }
                    else {
                        //alert('Time Out');
                        window.location = 'Logout.aspx';
                    }
                }
            }
        }
        var IsValidate = 'true';
        function validateForm() {
            document.getElementById('hdnButton').value = '1';
            IsValidate = 'true';
            if (document.getElementById('ddCivilCode').value == 'Y') {
                if (document.getElementById('txtSpouse').value == '' || document.getElementById('txtPAN').value == '') {
                    alert_custom('Please Fill Spouse and PAN correctly', 1, 'Error', '', '', '', ['OK'], '200', '100px');
                    disablebackground();
//                    $('.ui-dialog-content').css('height', '80px');
//                    $('.ui-dialog').css('top', '100px');
                    //alert('Please Fill Spouse and PAN correctly');
                    return false;
                }
                else {
                    if (document.getElementById('RegularExpressionValidator1').style.visibility == 'visible')
                        return false;
                }
            }
            else {
                if (document.getElementById('txtRecieptNo').style.display == 'block' && document.getElementById('txtRecieptNo').value == '')
                    IsValidate = 'false';
                if (document.getElementById('divNotice').style.display == 'block') {
                    if (document.getElementById('txtNotice').value == '' || document.getElementById('txtDON').value == '')
                        IsValidate = 'false';
                }
                if (document.getElementById('txtDateofReturn').style.display == 'block' && document.getElementById('txtDateofReturn').value == '')
                    IsValidate = 'false';

                if(document.getElementById('divDON').style.display == 'block') {
                    if (document.getElementById('txtDON').value == '')
                        IsValidate = 'false';
                }
                if (document.getElementById('RegularExpressionValidator1').style.visibility == 'visible' || document.getElementById('RegularExpressionValidator2').style.visibility == 'visible')
                    IsValidate = 'false';
            }
            if (IsValidate == 'true')
                return true;
            else {
                alert_custom('Please Fill All Required Fields', 1, 'Incomplete Data', '', '', '', ['OK'], '200', '100px');
                disablebackground();
                return false;
            }
        }

        function validatePAN() {
            if (/[a-z]{3}[cphfatbljg][a-z]\d{4}[a-z]/i.test(document.getElementById('txtPAN').value) == false && document.getElementById('txtPAN').value != 'PANNOTAVBL') {
                IsValidate = 'false';
            }
        }

        function showTxt() {
            $(document).ready(function () {
                alert($("#VGrid2_GV_VGrid2 tr:nth-child(3)").find('td:nth-child(4)').text());
            });
        }

    </script>
    <script type="text/javascript" src="Scripts/common.js"></script>
</head>
<body onload="expandIt()"><%--  onunload="HandleClose(0)">--%>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <input type="button" id="bb112" value="Check" onclick="showTxt()" style="display:none" />
    <asp:HiddenField ID="hdnButton" runat="server" />
    <asp:HiddenField ID="hdnID" runat="server" />
    <asp:HiddenField ID="hdnAY" runat="server" />
    <div style="display:none">
    <sum:ss ID="aa1" runat="server" />
    </div>
    <%-------------header ----------------%>
    <div class="row" >
        <div class="large-12 columns hide-for-small-only">
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
    </div>
   

    <%---------------show assesee detail on medium screen -------------------%>
     <div class="row show-for-medium-only">
  
     <div class="large-12 columns  "> <%
        if (Session["ay"] != null && Session["NameID"] != null)
        {
            %>
      <mob3:mediummenu id="Mediummenu1" runat="server" />
      <%} %>
      <br />
     </div>
     </div>
     <%-------------show header on mobile screen --------------------------------------------------------%>
    <div class="row show-for-small-only ">
    <br />
        <div class="small-12 columns" style="vertical-align:top; ">
        <a href="Default.aspx">
            <img src="../images/logo2.png" style="width:180px; height:auto" alt="logo" />    </a>        
    </div>    
    </div>
    <%----------------show username on mobile menu --------------------%>
     <div class="row show-for-small-only">     
     <div class="large-12 columns text-right">
      Welcome <span style="color:Black;font-family:'Open Sans','sans-serif';font-size:15px;font-weight:bold;color:#008CBA;  text-transform:capitalize"><asp:Literal ID="ltUser" runat="server" /></span>
         
      <a href="logout.aspx">
 [Logout]
 </a>
     </div>
     </div>

    
     <%--show breadcrumps in all views nishu 8/4/2015--%>
    <div class="row" >
    
    <div class="large-6 columns text-left">
     <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
              Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" NodeStyle-Font-Bold="false" ForeColor="#333333" RootNodeStyle-ForeColor="#19b99a">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </div>
    <div class="large-6 columns text-right">
       <%-- <a href="itr1.aspx"><input type="button" value=" Back to Home " class="newbtn" /></a>--%>
       <%---nishu 8/3/2015 ------%>
       
       <asp:Button ID="btnBacKMain" runat="server" Text=" Back to Home " class="newbtn" OnClick="btnBackMain_Click" /> 
    
    </div>
    </div>
    
    <div class="row">
    <div class="large-12 columns "><b>Hello!  Welcome to <span style="color:#e14658;font-size:20px">E-Chartered Accountants.com</span>.</b>
    <%--Div to show empty records message- jaipal--%>

    <asp:Panel ID="pnlNoRecord" runat="server" Visible="false">
    <div class="login-wrap" style="margin-top:50px; float:left">
    <span style="font-size:xx-large">Empty Records</span>
    <div class="form">
    <div>Note:</div>
    <div>To create Assessees, click the below button</div>        
    </div>
    </div>
    </asp:Panel>
    <%--Div to show empty records message--%>
    </div>
    </div>
    
    <div class="row">
        <div class="large-12 columns">
        <div class="row">
        <div class="large-6 columns">
          <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OnSelecting="ObjectDataSource1_Selecting"
                SelectMethod="GetAssesseeList" TypeName="Taxation.BusinessLogic.bllMain">
                <SelectParameters>
                    <asp:Parameter Name="UserName" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
         <div class="large-6 columns">
           <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="GetTANList"
                TypeName="Taxation.BusinessLogic.bllMain">
                <SelectParameters>
                    <asp:Parameter Name="UserName" Type="String" DefaultValue="abc" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        </div>
          
          
            <div class="row" style="height:auto;">
            <div class="large-12 columns">
            <%--<asp:UpdatePanel ID="upd22" runat="server">
            <ContentTemplate>--%>
            <asp:MultiView ID="mltView" ActiveViewIndex="0" runat="server">
                <asp:View ID="viewList" runat="server">
                    <div class="row " style="margin-top: 13px;">
                        <div class="large-12 columns">
                        <%--<%if (GridView1.Rows.Count > 0) %>--%>
                        <%{ %>
                            <div style="margin:auto; color:#e14658; font-size:17px; font-weight:bold">
                                   <asp:Literal ID="lblMainTitle" runat="server" />
                            </div>
                            
                            <%} %>
                            <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                                AllowPaging="true" PageSize="20" Width="100%" SkinID="grdstateskin" style="margin:0; padding:0; line-height:9px">
                              <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6492C3"></HeaderStyle>
                                        <FooterStyle Font-Bold="True" ForeColor="White" BackColor="#6492C3"></FooterStyle>
                                        <PagerStyle CssClass="cssPager" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            #.</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSNO" runat="server"></asp:Label>                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Name</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkName" Font-Bold="true" runat="server" OnClick="lnkName_Click"><%#DataBinder.Eval(Container.DataItem, "CombinedName")%></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PAN" HeaderText="PAN" SortExpression="PAN" >
                                    <ItemStyle CssClass="PAN" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DispStatus" HeaderText="Status" SortExpression="DispStatus" />
                                    <%--<asp:TemplateField>
                                                   <HeaderStyle CssClass="" />
                                                        <ItemStyle CssClass="" />
                                                        <ItemTemplate>
                                                        <asp:Label ID="Status" runat="server" ></asp:Label>
                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Status">
                                        <ControlStyle CssClass="hiddencol" />
                                        <ItemStyle CssClass="hiddencol" />
                                        <HeaderStyle CssClass="hiddencol" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NameID">
                                        <ControlStyle CssClass="hiddencol" />
                                        <ItemStyle CssClass="hiddencol" />
                                        <HeaderStyle CssClass="hiddencol" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DateofBirth">
                                        <ControlStyle CssClass="hiddencol" />
                                        <ItemStyle CssClass="hiddencol" />
                                        <HeaderStyle CssClass="hiddencol" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnEdit" runat="server" Text="Edit" CommandName="edt" CommandArgument='<%# Eval("PAN") + "~" + Eval("Status") + "~" + Eval("NameID") %>' ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" Visible="false" ControlStyle-CssClass="hidden_col" />
                                                    <asp:BoundField DataField="NameID" HeaderText="NameID" SortExpression="Status" Visible="false" ControlStyle-CssClass="hidden_col" />
                                </Columns>
                            </asp:GridView>--%>
                            <%--<asp:GridView ID="gvTDS" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gvTDS_PageIndexChanging"
                                PageSize="20" Width="100%" SkinID="grdstateskin">
                                <Columns>
                                 <asp:TemplateField>
                                        <HeaderTemplate>
                                            #.</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSNO" runat="server"></asp:Label>                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Name</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkName2" Font-Bold="true" runat="server" OnClick="lnkName2_Click" Text='<%# Eval("AName") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TAN" HeaderText="TAN" SortExpression="TAN" />
                                    <asp:BoundField DataField="PAN" HeaderText="PAN" SortExpression="PAN" />
                                    <asp:BoundField DataField="ID">
                                        <ControlStyle CssClass="hiddencol" />
                                        <ItemStyle CssClass="hiddencol" />
                                        <HeaderStyle CssClass="hiddencol" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>--%>
                            <asp:HiddenField ID="hdnPageState" runat="server" />
                            <div id="ControlGrid" runat="server">
                            <asp:UpdatePanel ID="upd22" runat="server">
                            <ContentTemplate>
                            
                            <asp:HiddenField ID="hdn2" runat="server" />                            
                            <asp:HiddenField ID="hdnActiveIndx" runat="server" />
                            <div onclick="setHdn(this);">
                            <cc1:DynamicControl ID="dny_Grd_ITRInfo" runat="server" Ongrd_EditIndex="dny_Grd_ITRInfo_grd_EditIndex" Ongrd_SelectedIndexChanged="dny_Grd_ITRInfo_grd_SelectedIndexChanged" Ongrd_SelectedIndexChanging="dny_Grd_ITRInfo_grd_SelectedIndexChanging"  />
                            </div>
                            <asp:HiddenField ID="hdn1" runat="server" />
                            <div style="display:none;">
                                <asp:Button ID="btTest" runat="server" Text="Click Me" OnClick="btTest_Click" OnClientClick= "setHdn(this);" />
                            </div>
                            </ContentTemplate>
                            </asp:UpdatePanel>

                                    <div style="display: none">
                            <asp:Button ID="butSubmit" runat="server" OnClick="butSubmit_Click" Text="Submit" /></div>
                            </div>
                            
                            <%--<cc1:DynamicControl ID="dny_Grd_TANInfo" runat="server" />--%>
                      </div>                      
                       <%-- <div class="large-1 columns">
                            <asp:LinkButton ID="lnkLogout" runat="server" ForeColor="#C00000" OnClick="lnkLogout_Click"
                                Style="display: none;">LogOut</asp:LinkButton>
                        </div>--%>
                    </div>
                    <br />
                    <%--nishu --%>
                    <div class="row ">
                     <%--<div class="large-3 columns">
                            <asp:Button ID="btnBack2" runat="server" OnClick="btnBack2_Click" Font-Bold="true" Text="Back" class="radius button" style="width:190px; height:53px; " Visible="false" />
                        </div>--%>
                        <div class="large-12 columns text-center  " style="margin-bottom:0">
                        <asp:Button ID="btnBackToRec" runat="server" Text="Back To Records" OnClick="btnBackToRec_Click" Visible="false"
                                class="radius button" Font-Bold="true" style=" height:53px" />
                            <asp:Button ID="btnAddAssessee" runat="server" OnClick="btnAddAssessee_Click" Text="Add New Assessee"
                                class="radius button" Font-Bold="true" style=" height:53px" />
                        </div>
                        <%-- hide upload xml nishu 11/4/2015 --%>
                        <div class="large-3 columns " style="display:none">
                          <% if (Session["project"].ToString() == "vt")
                                       { %>
                                        <asp:LinkButton ID="LinkButton1"  runat="server" 
                                            Text="Upload XML" PostBackUrl="XMLRestore.aspx?mode=res" class="radius button" style="width:190px; height:53px" />
                                            <%} %>
                        </div>
                        
                       
                    </div>
                </asp:View>
                <asp:View ID="AssessmentYear" runat="server">
                    <%--<asp:UpdatePanel ID="upd1" runat="server">
                        <ContentTemplate>--%>
                   
                    <%--<div class="row" id="assdet">
                        <div  style="padding: 10px; font-size:15px; font-weight:bold;">
                            <a href="#" style="color:#EC5739">&nbsp;</a>
                            <hr class= "hrnew" />
                        </div>
                    </div>--%>
                    
                   <%-- <asp:UpdatePanel ID="updd3" runat="server">
                    <ContentTemplate>--%>
                     
                    <div id="assdet1" style="display:none;">
                     <div class="row" id="Div3">
                        <div  style="padding: 10px; font-size:15px; font-weight:bold;">
                            <a href="#" style="color:#E14658">Assessment Details</a>
                        </div>
                    </div>

                        <div class="row" id="row_AY" runat="server">
                            <div class="large-8 columns">
                                <asp:Label ID="Label3" runat="server" Text="Assessment Year"></asp:Label>
                            </div>
                            <div class="large-4 column">
                            <%--<asp:UpdatePanel ID="upd2221" runat="server" UpdateMode="Always">
                            <ContentTemplate>--%>
                            <asp:DropDownList ID="DropDownList2" runat="server" 
                                    DataTextField="AssYear" DataValueField="AssYear" OnPreRender="DropDownList2_PreRender" onchange="showDataDD(this);">
                                    <%--AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"--%>
                                    <asp:ListItem Text="2016-2017" Value="2016-2017" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="2015-2016" Value="2015-2016"></asp:ListItem>
                                    <asp:ListItem Text="2014-2015" Value="2014-2015"></asp:ListItem>
                                    <%--<asp:ListItem>Select Date</asp:ListItem>--%>
                                </asp:DropDownList>
                           <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
                                
                            </div>
                        </div>
                        <div class="row" id="row_ITR" runat="server">
                            <div class="large-8 columns">
                                <asp:Label ID="Label4" runat="server" Text="Income Tax Return"></asp:Label>
                            </div>
                            <div class="large-4 column">
                                <asp:DropDownList ID="ddITR" runat="server">
                                   <%-- <asp:ListItem Text="ITR-1" Value="1">ITR-1</asp:ListItem>
                                    <asp:ListItem Text="ITR-2" Value="2">ITR-2</asp:ListItem>
                                    <asp:ListItem Text="ITR-3" Value="3">ITR-3</asp:ListItem>
                                    <asp:ListItem Text="ITR-4" Value="4">ITR-4</asp:ListItem>
                                    <asp:ListItem Text="ITR-5" Value="5">ITR-5</asp:ListItem>
                                    <asp:ListItem Text="ITR-6" Value="6">ITR-6</asp:ListItem>
                                    <asp:ListItem Text="ITR-7" Value="7">ITR-7</asp:ListItem>
                                    <asp:ListItem Text="ITR-4S" Value="8">ITR-4S</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="divEmployer" runat="server" class="row">
                            <div class="large-8 columns" style="color:Black;font-family:'Open Sans','sans-serif';font-size:15px;">
                                Employer Category (If in Employment)
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddEmployer" ErrorMessage="*" ForeColor="Red"
                                  InitialValue="-1"></asp:RequiredFieldValidator>
                                </div>
                            <div class="large-4 column">
                               <asp:DropDownList ID="ddEmployer" runat="server">
                              <%--  <asp:ListItem Text="  -- Select -- " Value="-1"></asp:ListItem>--%>
                                    <asp:ListItem Text="Not Applicable" Value="NA"></asp:ListItem>
                                    <asp:ListItem Text="Government" Value="GOV"></asp:ListItem>
                                    <asp:ListItem Text="Public Sector Unit" Value="PSU"></asp:ListItem>
                                    <asp:ListItem Text="Others" Value="OTH"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%--<asp:UpdatePanel ID="update2" runat="server" UpdateMode="Always">
                        <ContentTemplate>--%>
                        <div class="row" id="row_DD" runat="server">
                            <div class="large-8 columns">
                                <asp:Label ID="Label5" runat="server" Text="Due Date"></asp:Label>
                            </div>
                            <div class="large-4 column">
                                <asp:TextBox ID="txtDueDate" runat="server" type="text" ReadOnly="true" style="width:312px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="Label1" runat="server" Text="Section under which return is being filed"></asp:Label>
                            </div>
                            <div class="large-4 column">
                                <asp:DropDownList ID="ddlWhichSection" runat="server" onchange="setSection();"> <%--AutoPostBack="true" OnSelectedIndexChanged="ddlWhichSection_SelectedIndexChanged">--%>
                                    <asp:ListItem Text="On or Before Due Date 139(1)" Value="11" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="After Due Date 139(4)" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="u/s 142(1)" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="u/s 148" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="u/s 153 A" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="u/s 153C r/w 153A" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="Revised Return -139(5)" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="u/s 139(9)" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="u/s 119(2)(b)" Value="20"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%-- </ContentTemplate>
                       <%-- <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DropDownList2" EventName="SelectedIndexChanged" />
                        </Triggers>
                        </asp:UpdatePanel>--%>
                        <%--<div class="row">
                  <div class="large-8 columns">
                   <asp:Label ID="Label2" runat="server" Text="Return of Income"></asp:Label>
                  </div>
                  <div class="large-4 column">
                  <asp:DropDownList ID="ddlROI" runat="server" >
                                                        <asp:ListItem>Return of income u/s 139</asp:ListItem>
                                                        <asp:ListItem>Return of income u/s 142</asp:ListItem>
                                                        <asp:ListItem>Return of income u/s 148</asp:ListItem>
                                                    </asp:DropDownList>
                  </div>
                  </div>--%>
                        <div class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="Label7" runat="server" Text="Return Type"></asp:Label>
                            </div>
                            <div class="large-4 column">
                                <asp:DropDownList ID="ddlReturnType" runat="server" onchange="setReturnType();" Enabled="false">  <%--AutoPostBack="true" OnSelectedIndexChanged="ddlReturnType_SelectedIndexChanged">--%>
                                    <asp:ListItem Selected="True" Value="O">Original</asp:ListItem>
                                    <asp:ListItem Value="R">Revised</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="lblRecieptNO" runat="server" Text="Original Acknowledgement No." style="display:none"></asp:Label>
                                <asp:RequiredFieldValidator ValidationGroup="gg1" Visible="false" ID="reqq1" ControlToValidate="txtRecieptNO" runat="server" ErrorMessage="*" ForeColor="Red" Enabled="false"></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-4 column">
                                <asp:TextBox ID="txtRecieptNo" runat="server" style="display:none" type="text" MaxLength="15" onkeypress="return isNumberKey(event);" Width="312px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Valid Acknowledgement No" ControlToValidate="txtRecieptNo" 
                                ValidationExpression="[0-9]{15}" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="lblOrigionalReturn" runat="server" Text="Date of Filing of Original Return"
                                     style="display:none"></asp:Label>
                                <asp:RequiredFieldValidator ValidationGroup="gg1" Visible="false" ID="RequiredFieldValidator1"  
                                 Enabled="false" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-4 column">
                                <asp:TextBox ID="txtDateofReturn" runat="server" style="display:none" type="text" placeholder="dd/mm/yyyy" AutoPostBack="true" OnTextChanged="txtDateofReturn_TextChanged" onchange="return validateAY_Date(this,'true');" Width="312px"></asp:TextBox>
                                <asp:Label ID="lblDateErr" runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div id="divNotice" runat="server" style="display:none" class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="Label11" runat="server" Text="Notice Number"
                                    ></asp:Label>
                                <asp:RequiredFieldValidator Enabled="false" ValidationGroup="gg1" Visible="false" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-4 column">
                                <asp:TextBox ID="txtNotice" runat="server" type="text" MaxLength="23" Width="312px"></asp:TextBox>                                
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Valid Notice Number" ControlToValidate="txtNotice" 
                                ValidationExpression="[a-zA-Z0-9/]{0,23}" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                             <div class="large-8 columns" style="display:none;">
                                <asp:Label ID="Label22" runat="server" Text="Date of Notice"
                                    ></asp:Label>
                                <asp:RequiredFieldValidator Enabled="false" ValidationGroup="gg1" Visible="false" ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-4 column" style="display:none;">
                                <asp:TextBox ID="txtNoticeDate" runat="server" placeholder="dd/mm/yyyy" type="text" MaxLength="23" onchange="return validateAY_Date(this,'true');" Width="312px"></asp:TextBox>                                
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter Valid Notice Number" ControlToValidate="txtNoticeDate" 
                                ValidationExpression="[a-zA-Z0-9/]{0,23}" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div id="divDON" runat="server" style="display:none;" class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="Label12" runat="server" Text="If Filed in Response to notice u/s 139(9)/142(1)/148/153A/153C, Enter the Date of Such Notice"
                                    ></asp:Label>
                                <asp:RequiredFieldValidator Enabled="false" ValidationGroup="gg1" Visible="false" ControlToValidate="txtDON" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-4 column">
                                <asp:TextBox ID="txtDON" runat="server" type="text" MaxLength="23" placeholder="dd/mm/yyyy" onchange="validateAY_Date(this, true)" Width="312px"></asp:TextBox>                                
                            </div>
                        </div>

                        <div class="row" id="divGovernedPortugese" runat="server">
                            <div class="large-8 columns" style="color:Black;font-family:'Open Sans','sans-serif';font-size:15px;">
                                Are you Governed by Portugese Civil Code under Section 5A?</div>
                            <div class="large-4 column">
                                <asp:DropDownList ID="ddCivilCode" runat="server" onchange="setPortugese();">  <%--AutoPostBack="true" OnSelectedIndexChanged="ddCivilCode_SelectedIndexChanged">--%>
                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="divSpouse" runat="server" class="row" style="display:none">
                            <div class="large-8 columns">
                                Name of Spouse
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="req2" runat="server" ControlToValidate="txtSpouse" ErrorMessage="*" Visible="false" 
                                  Enabled="false" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            <div class="large-4 column">
                                <asp:TextBox ID="txtSpouse" runat="server" MaxLength="125" Width="312px"></asp:TextBox>
                                
                            </div>
                        </div>
                        <div id="divSpousePAN" runat="server" class="row" style="display:none">
                            <div class="large-8 columns">
                                PAN of Spouse
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="req3" runat="server" Enabled="false" ControlToValidate="txtPAN" ErrorMessage="*" Visible="false" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            <div class="large-4 column">
                              <asp:TextBox ID="txtPAN" runat="server" MaxLength="10" CssClass="PAN" Width="312px" style="text-transform:uppercase;"  ></asp:TextBox>
                              <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPAN" Visible="false"
                                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid PAN" ControlToValidate="txtPAN"
                                                 ValidationExpression="^[\w]{3}(p|P|c|C|h|H|f|F|a|A|t|T|b|B|l|L|j|J|g|G)[\w][\d]{4}[\w]$" ValidationGroup="gg1"></asp:RegularExpressionValidator>
                                
                            </div>
                        </div>
                        
                        
                        <%-- Is Account Audited Commented for ITR-1 --%>
                        <div class="row" style="display:none;">
                            <div class="large-8 columns">
                                <asp:CheckBox ID="chkAccountAudited" runat="server" Text="Is Account Audited" AutoPostBack="True"
                                    OnCheckedChanged="chkAccountAudited_CheckedChanged" />
                            </div>
                            <div class="large-4 column">
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="lblSection" runat="server" Text="Section" Visible="False"></asp:Label>
                            </div>
                            <div class="large-4 column">
                                <asp:DropDownList ID="ddlSection" runat="server" Visible="False">
                                    <asp:ListItem>Select Section</asp:ListItem>
                                    <asp:ListItem>44AA</asp:ListItem>
                                    <asp:ListItem>44AB(a)/(b)</asp:ListItem>
                                    <asp:ListItem>44AB(c)</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="lblAuditor" runat="server" Text="Auditor Name" Visible="False"></asp:Label>
                            </div>
                            <div class="large-4 column">
                                <asp:DropDownList ID="ddlAuditor" runat="server" Visible="False" DataSourceID="ObjectDataSource4"
                                    DataTextField="AuditorName" DataValueField="AuditorName">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row" style="display:none;">
                            <div class="large-8 columns">
                                <asp:CheckBox ID="chkFirstReturn" runat="server" Text="Is this your first return?" TextAlign="Left" /></div>
                            <div class="large-4 column">
                            </div>
                        </div>
                       <%-- <asp:UpdatePanel ID="upd2" runat="server">
                        <ContentTemplate>--%>
                        
                        <div class="row" style="display:none">
                            <div class="large-12 columns" style="font-size:15px; font-family:'Open Sans', 'sans-serif'; color:black">
                                <asp:CheckBox ID="chkTRP" runat="server" Text="Is Return Prepared by a TRP?" TextAlign="Right" onchange="setTRP(this);" />
                                 <%--AutoPostBack="True" OnCheckedChanged="chkTRP_CheckedChanged" />--%>
                                 </div>
                        </div>
                        <div id="divTRP" runat="server" style="display:none" class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="Label13" runat="server" Text="TRP PIN"></asp:Label>
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="reqTRP1" runat="server" ControlToValidate="txtTRP_PIN" ErrorMessage="*" Visible="false" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                                
                            </div>
                            <div class="large-4 column">
                                <asp:TextBox ID="txtTRP_PIN" runat="server" MaxLength="10" Width="312px"></asp:TextBox>                                
                                <asp:RegularExpressionValidator ID="rdg2" runat="server" ControlToValidate="txtTRP_PIN" ValidationExpression="[T][0-9]{9}|[0-9]{6}" ErrorMessage="Invalid PIN">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div id="divTRPName" runat="server" style="display:none" class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="Label14" runat="server" Text="Name of TRP"></asp:Label>
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTRPName" ErrorMessage="*" Visible="false" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="large-4 column">
                                <asp:TextBox ID="txtTRPName" runat="server" MaxLength="125"></asp:TextBox>
                                 
                            </div>
                        </div>
                        <div id="divTRPPaid" runat="server" style="display:none" class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="Label18" runat="server" Text="Amount to be paid to TRP"></asp:Label>
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTRPPaid" ErrorMessage="*" Visible="false" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="large-4 column">
                                <asp:TextBox ID="txtTRPPaid" runat="server" MaxLength="14" onkeypress="return isNumberKey(event);"></asp:TextBox>                                
                            </div>
                        </div>
                      <%--  </ContentTemplate>
                        </asp:UpdatePanel>--%>
                       
                        <br />
                        <div id="rowAmt" runat="server" visible="false" class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="Label20" runat="server" Text="Amount Received"></asp:Label>
                            </div>
                            <div class="large-4 column" style="margin:0 0 1rem 0;">
                                <asp:TextBox ID="txtAmtRec" runat="server" ></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row" style="margin-top: -25px;">
                            <div class="large-6 columns">&nbsp;</div>
                            <div class="large-3 columns text-right">
                                
                                <asp:Button ID="btnBack" runat="server" OnClick="Button4_Click" Font-Bold="true" Text="Back" class="radius button" style="width:162px; height:53px;"
                                OnClientClick="showListTDS();return false;"                                 />
                            </div>
                            <div class="large-3 column text-right">
                                <asp:Button ValidationGroup="gg1" ID="Button2" runat="server" Font-Bold="true" Text="Submit" class="radius button" OnClientClick="return validateForm();"
                                    OnClick="Button2_Click" style="width:162px; height:53px" />
                            </div>
                            
                        </div>
                        
                        <div class="row">
                            <div class="large-4 columns">
                            </div>
                            <div class="large-8 column">
                                <%-- <asp:Button ID="btnReadOnly" runat="server" Enabled="False" Text="Submit" class="button" /></div>--%>
                            </div>
                        </div>
                    </div>
                   <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                  
                     
                    <div class="row" style="overflow: hidden; display: none" id="detolditr">                    
                        <div class=" large-12 columns panel" style="padding: 10px;font-size:15px; font-weight:bold; background-color:White; color:rgba(25, 185, 154, 0.97); border:none">
                            <a href="#" style="color:rgba(25, 185, 154, 0.97)">List of Returns</a>
                            <%--<span style="float:right;display:none"><a href="XMLRestore.aspx?mode=res">Import XML</a></span>--%>
                            <span style="float:right;display:none"><a href="#">Import XML</a></span>
                        </div>
                        <div class="large-12 columns" style="overflow: hidden; width: 970px;">
                                  <%--  <asp:UpdatePanel ID="too" runat="server">
                                        <ContentTemplate>--%>
                                            <%--<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>--%>
                                            <VATAS:VGrid ID="VGrid1" runat="server" Width="100%" />
                                            <%--<cc1:DynamicControl ID="dny_Grd_Returns2" runat="server"  />--%>
                                      <%--  </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                        </div>
                        <br />
                       <center>
                       <asp:Literal ID="lblErrMsg" runat="server"></asp:Literal><br />
                       <%             if (Session["Account_Type"] != null)
                                      {
                                          if (Session["Account_Type"].ToString() != "S" && Session["Account_Type"].ToString() != "E")
                                          { %>
                                          
                       <asp:Button ID="Button6" runat="server" OnClick="Button4_Click" Font-Bold="true" Text="Back" class="radius button" style="width:152px; height:53px" />
                       <%}
                                      } %>
                        &nbsp;&nbsp;
                        <input type="button" id="btnAddRet" runat="server" class="radius button" value="New Return" onclick="ShowExtras();hideIt();" style="font-weight:bold;" />
                        &nbsp;&nbsp;
                        <input type="button" id="btnImportReturn" runat="server" class="radius button" value="Import Return" onclick="openPop();" style="font-weight:bold;" />
                        </center>
                    </div>
                    <br />
                    <div class="row">
                    <div class="large-12 columns text-center"> </div>
                    </div>
                    
                    <div class="row">
                        <div>
                        </div>
                        <div>
                            <%-- <asp:Button ID="btnReadOnly" runat="server" Enabled="False" Text="Submit" class="button" /></div>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-4 columns">
                        </div>
                        <div class="large-8 column">
                            <asp:Label ID="lblMsg" runat="server" Visible="false" Text="We couldn't find your PAN Details"
                                Font-Size="Large" ForeColor="Red" Style="text-decoration: blink;"></asp:Label>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAssYear"
                                TypeName="Taxation.BusinessLogic.bllMain"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetAuditor"
                                TypeName="Taxation.BusinessLogic.bllMain"></asp:ObjectDataSource>
                        </div>
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </asp:View>
                <asp:View ID="viewCountryDetail" runat="server">
                    <div class="row">
                        <div class="large-4 columns">
                            <asp:Label ID="lblStateName" runat="server" Text="State Name :" AssociatedControlID="txtStateName"></asp:Label>
                        </div>
                        <div class="large-8 columns">
                            <asp:TextBox ID="txtStateName" runat="server" type="text" TabIndex="1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-4 columns">
                            <asp:Label ID="lblCountryName" runat="server" Text="Country Name :" AssociatedControlID="txtCountryName"></asp:Label>
                        </div>
                        <div class="large-8 columns">
                            <asp:TextBox ID="txtCountryName" runat="server" Style="vertical-align: middle; text-align: left"
                                type="text"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-4 columns">
                        </div>
                        <div class="large-8 columns">
                            <asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="False" TabIndex="9"
                                CausesValidation="true"  Class="button"></asp:Button>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CausesValidation="False"
                                UseSubmitBehavior="False" TabIndex="10" class="button"></asp:Button>&nbsp;<asp:Button
                                    ID="btnGoBack" runat="server" Font-Bold="true" Text="Go Back" CausesValidation="False" UseSubmitBehavior="False"
                                    TabIndex="11" class="button"></asp:Button></div>
                    </div>
                    <div class="row">
                        <div class="large-4 columns">
                        </div>
                        <div class="large-8 columns">
                            <asp:RequiredFieldValidator ValidationGroup="gg1" ID="rfvName" runat="server" ErrorMessage="Enter State Name"
                                ControlToValidate="txtStateName" Display="None" ></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ValidationGroup="gg1" ID="rfvCode" runat="server" ControlToValidate="txtCountryName"
                                Display="None" ErrorMessage="Enter Country Name" TabIndex="5" ></asp:RequiredFieldValidator>
                            <asp:ValidationSummary ID="vlsUserGrp" runat="server" ></asp:ValidationSummary>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="viewMessage" runat="server">
                    <div class="row">
                        <div class="large-12 columns">
                            <asp:Label ID="lblMessage" runat="server" Height="36px" Font-Bold="True" Font-Size="Large"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-12 columns">
                            <asp:Button ID="btnGoBackM" TabIndex="10" runat="server" UseSubmitBehavior="False" Font-Bold="true"
                                Text="Go Back" CausesValidation="False" class="button"></asp:Button>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View1" runat="server">                    
                <asp:UpdatePanel ID="updTDS" runat="server">
                <ContentTemplate>
                <script type="text/javascript">
                    function gotoMain() {
                        try {
                            window.location = document.URL.toString();
                        }
                        catch (e) { alert(e); }
                    }
                </script>
                <asp:HiddenField ID="hdnCG" runat="server" />
                  <div class="row" style="overflow: hidden;" id="divTDS">
                        <div class="large-12 columns" style="overflow: hidden; width: 970px;">
                            <VATAS:VGrid ID="VGrid2" runat="server" Width="100%" />
                        </div>
                        <div class=" large-12 columns panel" style="padding: 10px;font-size:15px; font-weight:bold; background-color:White; color:rgba(25, 185, 154, 0.97); border:none; text-align:center;">
                        <input type="button" value="Back" class="radius button" onclick="gotoMain();" />
                        <%--<asp:Button ID="btnTDS_Back" runat="server" CssClass="radius button" Text="Back" style="font-weight:bold;" OnClientClick="gotoMain();" />--%>
                        <input type="button" id="Button7" runat="server" class="radius button" value="New Return" onclick="showDetTDS();" style="font-weight:bold;" />
                        
                        </div>
                    </div>
                    <div class="row" style="overflow: hidden; display:none; " id="divTDS_Det">
                         <div class="row" id="Div6">
                        <div class=" panel" style="padding: 10px;">
                            <a href="#">DETAILS</a>
                        </div>
                    </div>
                      <%--  <div id="Div7">--%>
                        <div class="row" style="display:none;">
                            <div class="large-6 columns">
                                <asp:Label ID="Label6" runat="server" Text="TAN Number"></asp:Label>
                            </div>
                            <div class="large-6 columns" style="margin:0 0 1rem 0;">
                                <asp:Label ID="lblTAN" runat="server" style="text-transform: uppercase; "></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="display:none;">
                            <div class="large-6 columns">
                                <asp:Label ID="Label16" runat="server" Text="Name"></asp:Label>
                            </div>
                            <div class="large-6 columns" style="margin:0 0 1rem 0;">
                                <asp:Label ID="lblTDSName" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="display:none;">
                            <div class="large-6 columns">
                                <asp:Label ID="Label17" runat="server" Text="PAN Number"></asp:Label>
                            </div>
                            <div class="large-6 columns" style="margin:0 0 1rem 0;">
                                <asp:Label ID="lblTDSPAN" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label10" runat="server" Text="Form Type"></asp:Label>
                            </div>
                            <div class="large-6 columns">
                                <asp:DropDownList ID="ddFormType" runat="server">
                                    <asp:ListItem Text="Form24Q" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Form26Q" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Form27Q" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Form27EQ" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Form15G" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="Form15H" Value="51"></asp:ListItem>
                                    <asp:ListItem Text="Form24G" Value="53"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label2" runat="server" Text="Financial Year"></asp:Label>
                                <asp:RequiredFieldValidator ID="rrq1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="*" ValidationGroup="vgTDS" InitialValue="-1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-6 columns">
                                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                 <%--   <asp:ListItem> -- Select --</asp:ListItem>
                                    <asp:ListItem Text="2016-2017" Value="2016-2017"></asp:ListItem>
                                    <asp:ListItem Text="2015-2016" Value="2015-2016"></asp:ListItem>
                                    <asp:ListItem Text="2014-2015" Value="2014-2015"></asp:ListItem>
                                    <asp:ListItem Text="2013-2014" Value="2013-2014"></asp:ListItem>
                                    <asp:ListItem Text="2012-2013" Value="2012-2013"></asp:ListItem>
                                    <asp:ListItem Text="2011-2012" Value="2011-2012"></asp:ListItem>
                                    <asp:ListItem Text="2010-2011" Value="2010-2011"></asp:ListItem>
                                    <asp:ListItem Text="2009-2010" Value="2009-2010"></asp:ListItem>
                                    <asp:ListItem Text="2008-2009" Value="2008-2009"></asp:ListItem>
                                    <asp:ListItem Text="2007-2008" Value="2007-2008"></asp:ListItem>
                                    <asp:ListItem Text="2006-2007" Value="2006-2007"></asp:ListItem>
                                    <asp:ListItem Text="2005-2006" Value="2005-2006"></asp:ListItem>
                                    <asp:ListItem Text="2004-2005" Value="2004-2005"></asp:ListItem>--%>
                                </asp:DropDownList>                                
                            </div>
                        </div>
                        <%--<div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label8" runat="server" Text="Assessment Year"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTDSAY" ErrorMessage="*" ValidationGroup="vgTDS" ></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-6 columns">
                              <asp:TextBox ID="txtTDSAY" runat="server" style="width:100%;"></asp:TextBox>
                            </div>
                        </div>--%>
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label9" runat="server" Text="Quarter"></asp:Label>                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DropDownList3" ErrorMessage="*" ValidationGroup="vgTDS" InitialValue="-1" ></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-6 columns">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                    <asp:ListItem Text="-- Select --" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Quarter-1" Value="Q1"></asp:ListItem>
                                    <asp:ListItem Text="Quarter-2" Value="Q2"></asp:ListItem>
                                    <asp:ListItem Text="Quarter-3" Value="Q3"></asp:ListItem>
                                    <asp:ListItem Text="Quarter-4" Value="Q4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label24" runat="server" Text="Return Type"></asp:Label>                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddRetType" ErrorMessage="*" ValidationGroup="vgTDS" InitialValue="-1" ></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-6 columns">
                                <asp:DropDownList ID="ddRetType" runat="server">
                                    <asp:ListItem Text="-- Select --" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Regular" Value="Regular"></asp:ListItem>
                                    <asp:ListItem Text="Correction" Value="Correction"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br>
                        </br>
                        
                        <div class="row">
                             <div class="large-6 columns">&nbsp;</div>
                            <div class="large-3 columns text-right">
                                <%--<input type="button" class="radius button" value="Back" style="width:162px; height:53px" onclick="showListTDS();" />--%>
                                <asp:Button ID="Button1" runat="server" OnClick="Button4_Click" Font-Bold="true" Text="Back" class="radius button" Width="162px" Height="53px" OnClientClick="showListTDS(); return false;" />
                            </div>
                            <div class="large-3 columns text-right">
                                <asp:Button ID="Button3" runat="server" Font-Bold="true" Text="Submit" class="radius button"
                                    OnClick="Button3_Click" Width="162px" Height="53px"  ValidationGroup="vgTDS" />
                            </div>
                             <%-- <div class="large-3 columns">&nbsp;</div>--%>
                        </div>
                        <div class="row">
                            <div class="large-4 columns">
                            </div>
                            <div class="large-8 column">
                                <%-- <asp:Button ID="btnReadOnly" runat="server" Enabled="False" Text="Submit" class="button" /></div>--%>
                            </div>
                        </div>
                 <%--   </div>--%>
                    <div class="row">
                        <div>
                        </div>
                        <div>
                            <%-- <asp:Button ID="btnReadOnly" runat="server" Enabled="False" Text="Submit" class="button" /></div>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-4 columns">
                        </div>
                        <div class="large-8 column">
                            <asp:Label ID="Label15" runat="server" Visible="false" Text="We couldn't find your PAN Details"
                                Font-Size="Large" ForeColor="Red" Style="text-decoration: blink;"></asp:Label>
                            <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" SelectMethod="GetAssYear"
                                TypeName="Taxation.BusinessLogic.bllMain"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjectDataSource7" runat="server"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" SelectMethod="GetAuditor"
                                TypeName="Taxation.BusinessLogic.bllMain"></asp:ObjectDataSource>
                        </div>
                    </div>
                    </div>
                </ContentTemplate>
                </asp:UpdatePanel>
                
                </asp:View>
                <asp:View ID="View2" runat="server">                    
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row" id="Div1">
                        <div style="padding: 10px;">
                            <a href="#" style="color: #EC5739;font-size: 15px;font-weight: bold;font-family: 'Open Sans', 'sans-serif';">DETAILS</a>
                        </div>
                        <hr class="hrnew"  style="margin-top:-8px"/>
                    </div>
                    <div id="Div2">
                    <div class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="Label19" runat="server" Text="Financial Year"></asp:Label>
                            </div>
                            <div class="large-4 column">
                            <asp:DropDownList ID="ddFY" runat="server" />
                                
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="Label21" runat="server" Text="Return Period"></asp:Label>
                            </div>
                            <div class="large-4 column" >
                              <asp:DropDownList ID="ddReturnPeriod_1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddReturnPeriod_1_SelectedIndexChanged">
                              <asp:ListItem Text="April-September" Value="April-September"></asp:ListItem>
                              <asp:ListItem Text="October-March" Value="October-March"></asp:ListItem>
                              </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="Label23" runat="server" Text="Due Date"></asp:Label>
                            </div>
                            <div class="large-4 column" >
                                <asp:TextBox ID="txtDueDate2" runat="server" Enabled="false" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-8 columns">
                                <asp:Label ID="Label25" runat="server" Text="Return Type"></asp:Label>
                            </div>
                            <div class="large-4 column">
                               <asp:DropDownList ID="ddReturnType" runat="server">
                               <asp:ListItem Text="Original" Value="Original"></asp:ListItem>
                               <asp:ListItem Text="Revised" Value="Revised"></asp:ListItem>
                               </asp:DropDownList>
                            </div>
                        </div>
                                                
                        <div class="row">
                            <div class="large-12 columns text-right">
                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Font-Bold="true"
                                    Text="Back" class="radius button" />
                                <asp:Button ID="Button5" runat="server" Font-Bold="true" Text="Submit" class="radius button"
                                    OnClick="Button5_Click" />
                            </div>
                            
                        </div>
                        <div class="row">
                            <div class="large-4 columns">
                            </div>
                            <div class="large-8 column">
                                <%-- <asp:Button ID="btnReadOnly" runat="server" Enabled="False" Text="Submit" class="button" /></div>--%>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div>
                        </div>
                        <div>
                            <%-- <asp:Button ID="btnReadOnly" runat="server" Enabled="False" Text="Submit" class="button" /></div>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-4 columns">
                        </div>
                        <div class="large-8 column">
                            <asp:Label ID="Label29" runat="server" Visible="false" Text="We couldn't find your PAN Details"
                                Font-Size="Large" ForeColor="Red" Style="text-decoration: blink;"></asp:Label>
                            <asp:ObjectDataSource ID="ObjectDataSource9" runat="server" SelectMethod="GetAssYear"
                                TypeName="Taxation.BusinessLogic.bllMain"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjectDataSource10" runat="server"></asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjectDataSource11" runat="server" SelectMethod="GetAuditor"
                                TypeName="Taxation.BusinessLogic.bllMain"></asp:ObjectDataSource>
                        </div>
                    </div>
                </ContentTemplate>
                </asp:UpdatePanel>
                
                </asp:View>
            </asp:MultiView>
         <%--   </ContentTemplate>
            </asp:UpdatePanel>--%>
             
            </div>
            </div>
           
        </div>
    </div>
    
    <div class="row" style="margin-top:0; margin-bottom:0; padding-top:0; padding-bottom:0"  >
    
        <div class="large-12 columns" style="margin-top:0; margin-bottom:0; padding-top:0; padding-bottom:0" >
          <hr/>        
          © 2016 Vatas Infotech Pvt.Ltd.
        </div>
     </div>
   <%-- <sub:submenu ID="sub1" runat="server" />--%>
   <%--details on side ---%>
   <%--<div class="hide-for-small-only hide-for-medium-only">
   <%
       if (Session["ay"] != null && Session["NameID"] != null)
       {
            %>
 <menu:side ID="Sidemenu" runat="server" />
 <%} %>
 </div>--%>
 <asp:UpdatePanel>
 <ContentTemplate>
 <asp:HiddenField ID="hdn3" runat="server" />
 <asp:HiddenField ID="hdnIsEdit" runat="server" />
 </ContentTemplate>
 </asp:UpdatePanel>

<script type="text/javascript">
     function openPop() {
         document.getElementById('btnPop').click();
     }
</script>

  <asp:Panel ID="pnlPopup" runat="server">
     <div class="login-wrap" style="margin-top: 30px;height:140px; background-color:White;" >
     <asp:Panel ID="pnlRestore" runat="server" Width="400px">
                <span style="color: Black; font-family: 'Open Sans','sans-serif'; margin-left: -72px;
                    font-size: xx-large; font-size: 15px; font-weight: bold; text-transform: uppercase;
                    color: #ef5845; text-decoration: underline">
                    <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                </span>
                <div class="form large-12 columns text-center">
                    <asp:FileUpload ID="fup1" runat="server" />
                    <asp:RequiredFieldValidator ID="reqFUp" runat="server" ErrorMessage="*" ControlToValidate="fup1" Display="Dynamic" ValidationGroup="gg2">
                    </asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="re1" runat="server" ValidationExpression="^.*\.(xml|XML)$" ControlToValidate="reqFUp">
                    </asp:RegularExpressionValidator>--%>
                    <asp:Button ID="btnSubmit" runat="server" Font-Bold="true" Text="Import" CssClass="radius button" ValidationGroup="gg2" OnClientClick="return validateFileUpload();"
                        OnClick="btnSubmit_Click" formnovalidate Style="left: -66px; border-radius: 4px" />
                        &nbsp;
                    <asp:Button ID="btnClose" runat="server" Font-Bold="true" Text="Cancel" CssClass="radius button"
                     Style="left: -66px; border-radius: 4px" />
                </div>
            </asp:Panel>
     </div>
    </asp:Panel>
    <asp:Button ID="btnPop" runat="server" Text="popup" style="display:none;" />
    <%--<ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" TargetControlID="btnPop" PopupControlID="pnlPopup">
    </ajaxToolkit:PopupControlExtender>--%>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlPopup" TargetControlID="btnPop" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
    </ajaxToolkit:ModalPopupExtender>

<div id="msg1" style="height:20px">
        <asp:Label ID="lblMsg2" runat="server"></asp:Label>
    </div>  
    <a id="a2" runat="server" style="display:none;">click</a>  
    <div id="divdisable"  ></div>
    
    </form>
</body>
<script language="javascript" type="text/javascript">
    function showListTDS() {
        document.getElementById('divTDS_Det').style.display = 'none';
        document.getElementById('divTDS').style.display = 'block';
    }
    function showDetTDS() {
        try {
            document.getElementById('ddFormType').disabled = false;
            document.getElementById('DropDownList1').disabled = false;
            document.getElementById('DropDownList3').disabled = false;
            document.getElementById('ddRetType').disabled = false;

            document.getElementById('divTDS_Det').style.display = 'block';
            document.getElementById('divTDS').style.display = 'none';
        }
        catch (e) { alert(e); }
    }
    //alert('asd');
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(erh);
    
    function erh(sender, args) {

        try {
            if (document.getElementById('hdnCG').value != '') {
                //alert(document.getElementById('hdnCG').value);
                //document.getElementById('hdnCG').value = '';
                document.getElementById('divTDS_Det').style.display = 'block';
                document.getElementById('divTDS').style.display = 'none';
            }
            //alert(document.getElementById('hdn3').value);
            var dataItems = args.get_dataItems()['<%= hdn3.ClientID %>'];
            if (dataItems != undefined) {
                //alert(dataItems);
                if (dataItems != '') {
                    dataItems = '';                    
                    document.getElementById('butSubmit').click();
                }
//                var arr = new Array();
//                arr = dataItems.toString().split('~');
//                document.getElementById('txtDueDate').value = arr[0];
            }
        }
        catch (e) { alert(e); }
        //alert(document.getElementById('hdn2').value);
        
        //alert("HDN:-"+document.getElementById('hdn2').value);
//        if (document.getElementById('hdn2').value == '' || document.getElementById('hdn2').value == '0') {
//            //alert("BBBBBB");
//            document.getElementById('btTest').click();
//        }
//        else if (document.getElementById('hdn2').value == 'btTest') {
//        //alert("AAAA");
//            var dataItems2 = args.get_dataItems()['<%= hdnActiveIndx.ClientID %>'];
//            if (dataItems2 != 'testing') {
//                document.getElementById('hdnID').value = dataItems2;
//                document.getElementById('butSubmit').click();
//            }
//        }
    }

    function getVal(args) {

    }

</script>
</html>
