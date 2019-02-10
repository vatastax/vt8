<%@ Page Language="C#" AutoEventWireup="true" CodeFile="2HUF.aspx.cs" Inherits="Presentation_HUF" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %> <%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../mobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../mobilemenu2.ascx" TagPrefix="mob1" TagName="menu1" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagName="resmob" TagPrefix="resmenu" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../Presentation/MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="~/menu_header.ascx" TagName="menuheader" TagPrefix="header" %>
<!DOCTYPE html >

<html class="no-js" lang="en" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />

<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
<title>Control Panel</title>
<%--<link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />--%>

<%--<script type="text/javascript" src="../scripts/menu.js"></script> --%>

    <%--<link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>

     <%--<script src="../js/jquery.min.js" type="text/javascript"></script>
      <script src="../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../js/tab.js" type="text/javascript"></script>--%>
   
    <%--<link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />--%>

   <%-- <script src="../foundation-5.5.0/js/foundation.min.js" type="text/javascript"></script>--%>

         <%--<link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
     
        <link href="../StaticStylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />
    <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />--%>


     <!--master javascript file-->
    <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <!--master javascript file-->

     <!--master style sheet-->
    <link href="../style_folder/ItrSoftwareCompanyStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
    <!--------Jquery Validation ------>
   

<script type="text/javascript">
    $(document).ready(function () {

        $("#btnmenu").click(function () {
            $("#divmenu").slideToggle();
        });

    });
</script>
<%--<script type="text/javascript">
    $(document).ready(function () {

        $("#hide").click(function () {
            $("#div1").slideToggle();
        });

    });</script> 
--%>
    <script type="text/javascript">
        function enableIt(id) {
            try {
                //alert(id.id);
                var i = new Number();
                var j = new Number();
                var k = new Number();
                var ddName = new String();
                ddName = id.id.toString();
                ddName = ddName.substring((ddName.length - 1), ddName.length);
                //alert(ddName);
                if (ddName == '2') {
                    i = 11;
                    j = 22;
                    k = 33;
                }
                else if (ddName == '3') {
                    i = 111;
                    j = 222;
                    k = 333;
                }
                else {
                    i = 1;
                    j = 2;
                    k = 3;
                }

                if (id.value == 0) {
                    document.getElementById('txtTrade' + i.toString()).setAttribute('disabled', 'disabled');
                    document.getElementById('txtTrade' + j.toString()).setAttribute('disabled', 'disabled');
                    document.getElementById('txtTrade' + k.toString()).setAttribute('disabled', 'disabled');
                }
                else {
                    document.getElementById('txtTrade' + i.toString()).removeAttribute('disabled');
                    document.getElementById('txtTrade' + j.toString()).removeAttribute('disabled');
                    document.getElementById('txtTrade' + k.toString()).removeAttribute('disabled');
                }
            }
            catch (e) { alert(e); }
        }
    </script>
</head>


<body onload="P7_ExpMenu()">
<form id="form1" runat="server" role="form">
<BR />
<div class="container-fluid">
   <%--<div class="row ">
        <div class="small-6 columns" style="vertical-align:top; ">
        <a href="Default.aspx">
            <img src="../images/logo2.PNG" style="width:220px; height:83px" />    </a>        
    </div>   
     <div class="small-6 columns text-right">
      Welcome <span style="font-weight:bold"><asp:Literal ID="ltUser" runat="server">   </asp:Literal></span>
   
      <br />
      <a href="logout.aspx">
      [Logout]
      </a>
     </div> 
    </div> --%>
     
         <div class="row show-for-small-only ">
        <div class="small-6 columns" style="vertical-align:top; ">
        <a href="Default.aspx">
            <img src="../images/logo2.PNG" style="width:220px; height:83px" />    </a>        
    </div>   
     <div class="small-6 columns text-right">
      Welcome <span style="font-weight:bold"><asp:Literal ID="ltUser" runat="server">   </asp:Literal></span>
   
      <br />
      <a href="logout.aspx">
      [Logout]
      </a>
     </div> 
    </div> 
         <%-------------header ----------------%>

    <div class="row hide-for-small-only">
    <div class="large-12 columns">
    <%--Add by nishu for header 11/4/2015 --%>
    <header:menuheader ID="header1" runat="server" />
    </div>
    </div>
     <div class="row">
     <BR />
     <div class="large-12 columns">
         <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
            Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" NodeStyle-Font-Bold="false" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
     </div>
     </div>

</div>
<br />
  <%--<div class="row hide-for-small-only">
  
     <div class="large-12 columns  ">
      <mob3:mediummenu id="Mediummenu2" runat="server" />
     </div>
     </div>--%>
      
      <div class="row hidden-for-large hidden-for-medium" id="divmenu" style="display:none">
      
      <div class="large-12 columns">
          
          <%
    if(Session["ay"]!=null)
    {
    %>

  <resmenu:resmob ID="mob1" runat="server" />
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
        <div class="row show-for-small-only" >
        <div class="large-12 columns">
          <mob2:mobmenu id="mobmenu" runat="server" />
                <%--<img src="../images/details.JPG" />--%>
            
        </div>
    </div>
    <br />
  
<div class="container-fluid">
<div class="row">
<%--<div class="col-xs-3 col-sm-3 col-md-3 col-lg-3 show-for-large-only"><sub:submenu ID="Submenu1" runat="server"  /></div>--%>
<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
      <%--  <div class="row hide-for-small-only">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <p class="bg-primary"><asp:Label ID="lblHeading" runat="server" 
                                                Text="Assessee Details" class="bg-primary"></asp:Label></p>
        </div>
        </div>--%>
     <%--   <div class="row  bg-primary hide-for-small-only">
        <div class="large-6 columns"><asp:Label ID="Label1" runat="server" Font-Bold="true"
                                                Text="Assessee Type" ></asp:Label>&nbsp; <asp:Label ID="lblAssesseeType" runat="server"  Text="Label" Width="66px"></asp:Label></div>
        <div class="large-6 columns">
        <asp:Label ID="Label3" runat="server"  Text="Pan Number" Font-Bold="true"  ></asp:Label>&nbsp;
                            <asp:Label ID="lblPan" runat="server"  Text="Label" ></asp:Label>
        </div>
        </div>--%>
        </ContentTemplate>
        </asp:UpdatePanel>
        <br />
<div class="container-fluid">

<ul class="nav nav-tabs" role="tablist" id="mytab">
<li class="active"><a  href="#SectionA" data-toggle="tab">Personal Details</a></li>
<li><a  href="#sectionB" data-toggle="tab" click="show();">Address</a></li>
<li><a  href="#sectionc"  data-toggle="tab">Bank Details</a></li>
<li><a  href="#sectiond"  data-toggle="tab">Other Information</a></li>
<%--<li><a  href="#sectione"  data-toggle="tab">Signatory</a></li>--%>
</ul>




 
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getStates"
                    TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getStates"
                    TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
</div>
<br />
<div class="tab-content">
<div id="SectionA"  class="tab-pane fade in active">
<br />
<div class="row">
<div class="large-4 columns">
 <asp:Label ID="Label16" runat="server" Text="Name"></asp:Label><span style="color:Red;">*</span>
</div>
<div class="large-4 columns">
<asp:TextBox ID="txtNameHUF" runat="server" Height="38px" Width="200px" style="text-transform:capitalize;" ></asp:TextBox>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtNameHUF"
                    ErrorMessage="Name (Personal Tab)" Display="None"></asp:RequiredFieldValidator>
</div>
<div class="large-4 columns"></div>
</div>
<BR />
<div class="row">
<div class="large-4 columns">
 <asp:Label ID="Label21" runat="server" Text="Date of Formation"></asp:Label><span style="color:Red;">*</span>
</div>
<div class="large-4 columns">
 <asp:TextBox ID="txtDateHUF" runat="server" Height="38px" Width="200px"  MaxLength="12" placeholder="DD/MM/YYYY" onchange="javascript:validateAY_DOB(this, true);"
  ></asp:TextBox> <div  id="errorOrganizer1" style="color:Red" ></div>
  <asp:MaskedEditExtender ID="txtdob_MaskedEditExtender" runat="server"
                        Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" UserDateFormat="DayMonthYear"
                        Mask="99/99/9999" MaskType="Date" TargetControlID="txtDateHUF">
                    </asp:MaskedEditExtender>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtDateHUF"
                                        ErrorMessage="Date of Formation (Personal Tab)" Display="None"></asp:RequiredFieldValidator>
</div>
<div class="large-4 columns"></div>
</div>
<br />
<div class="row">
<div class="large-4 columns">
 <asp:Label ID="Label20" runat="server" Text="TAN"></asp:Label>
</div>
<div class="large-4 columns">
<asp:TextBox ID="txtTANHUF" runat="server" style="text-transform:uppercase" Height="38px" Width="200px" MaxLength="10" ></asp:TextBox>
 <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ErrorMessage="Invalid TAN" ControlToValidate="txtTANHUF" ValidationExpression="^[\w]{4}[\d]{5}[\w]" 
                                    runat="server" />
</div>
<div class="large-4 columns"></div>
</div>

<div class="row">
<div class="large-4 columns">
<asp:Label ID="Label22" runat="server" Text="Residential Status" ></asp:Label>
</div>
<div class="large-4 columns">
<asp:DropDownList ID="ddlResHUF" runat="server" Height="38px" Width="200px">
                                                            <asp:ListItem>Resident</asp:ListItem>
                                                            <asp:ListItem>Non-Resident</asp:ListItem>
                                                           
                                                        </asp:DropDownList>
</div>
<div class="large-4 columns"></div>
</div>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                                    ShowSummary="false" />



</div>
 <div id="sectionB" class="tab-pane fade">
 <br />
 <div class="row">
 <div class="large-3 columns">
 <asp:Label ID="Label2" runat="server" Text="Flat/Door/Block No."></asp:Label><span style="color:Red;">*</span>
 </div>
 <div class="large-3 columns">
   <asp:TextBox ID="txtFlat" runat="server" Height="38px" Width="200px" style="text-transform:capitalize;"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFlat"
                                        ErrorMessage="Flat/Door/Block No. (Address Tab)" Display="None"></asp:RequiredFieldValidator>
 </div>

 <div class="large-3 columns">
     <asp:Label ID="Label18" runat="server" Text="Name of Premises/Building/Village"></asp:Label>
 </div>
 <div class="large-3 columns">
  <asp:TextBox ID="txtPremises" runat="server" Height="38px" Width="200px" style="text-transform:capitalize;"></asp:TextBox>
 </div>
 </div>
 <br />
 <div class="row">
 <div class="large-3 columns">
  <asp:Label ID="Label19" runat="server" Text="Road/Street/Lane/PostOffice"></asp:Label>
 </div>
 <div class="large-3 columns">
  <asp:TextBox ID="txtRoad" runat="server" Height="38px" Width="200px" style="text-transform:capitalize;"></asp:TextBox>
 </div>


 <div class="large-3 columns">
   <asp:Label ID="Label25" runat="server" Text="Area"></asp:Label><span style="color:Red;">*</span>
 </div>
 <div class="large-3 columns">
     <asp:TextBox ID="txtArea" runat="server" Height="38px" Width="200px" style="text-transform:capitalize;"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtArea"
                                        ErrorMessage="Area (Address Tab)" Display="None"></asp:RequiredFieldValidator>
 </div>
 </div>
 <br />
 <div class="row">
 <div class="large-3 columns">
     <asp:Label ID="Label30" runat="server" Text="City"></asp:Label><span style="color:Red;">*</span>
 </div>
 <div class="large-3 columns">
  <asp:TextBox ID="txtCity" runat="server" Height="38px" Width="200px" style="text-transform:capitalize;"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCity"
                                        ErrorMessage="City (Address Tab)" Display="None"></asp:RequiredFieldValidator>
 </div>

 <div class="large-3 columns">
  <asp:Label ID="Label31" runat="server" Text="State"></asp:Label><span style="color:Red;">*</span>
 </div>
 <div class="large-3 columns">
  <asp:DropDownList ID="ddlState" runat="server"  DataSourceID="ObjectDataSource1" DataTextField="StateName" DataValueField="StateCode"  Height="38px" Width="200px" >
                                                            </asp:DropDownList>

 </div>
 </div>

 <div class="row">
 <div class="large-3 columns">
 <asp:Label ID="Label32" runat="server" Text="PIN"></asp:Label><span style="color:Red;">*</span>
 </div>
 <div class="large-3 columns">
   <asp:TextBox ID="txtPIN" runat="server" Height="38px" Width="200px" MaxLength="6"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPIN"
                                        ErrorMessage="PIN (Address Tab)" Display="None"></asp:RequiredFieldValidator>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid PIN" ControlToValidate="txtPIN" ValidationExpression="[1-9]{1}[0-9]{5}"></asp:RegularExpressionValidator>
 </div>

 <div class="large-3 columns">
    <asp:Label ID="Label26" runat="server" Text="STD"></asp:Label>
 </div>
 <div class="large-3 columns">
 <asp:TextBox ID="txtSTD" runat="server" Height="38px" Width="200px" ></asp:TextBox>
   <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtSTD" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="First digit should not be zero" ControlToValidate="txtSTD" ValidationExpression="[1-9]{1}[0-9]{1,5}"></asp:RegularExpressionValidator>
 </div>
 </div>
 
 <div class="row">
 <div class="large-3 columns">
   <asp:Label ID="Label39" runat="server" Text="Phone"></asp:Label>
 </div>
 <div class="large-3 columns">
   <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" Height="38px" Width="200px" ></asp:TextBox>
     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtPhone" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                               
 </div>


 <div class="large-3 columns">
   <asp:Label ID="Label6" runat="server" Text="Mobile1"></asp:Label><span style="color:Red;">*</span>
 </div>
 <div class="large-3 columns">
   <asp:TextBox ID="txtMobile1" runat="server" MaxLength="10" onchange="setVals();" Height="38px" Width="200px" ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMobile1"
                                        ErrorMessage="Mobile1 (Address Tab)" Display="None"></asp:RequiredFieldValidator>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please enter valid Mobile1"
                                 ControlToValidate="txtMobile1" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                  <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtMobile1" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
 </div>

 </div>
 <div class="row">
 <div class="large-3 columns">
   <asp:Label ID="Label35" runat="server" Text="Mobile2"></asp:Label>
 </div>
 <div class="large-3 columns">
   <asp:TextBox ID="txtMobile2" runat="server" Height="38px" Width="200px" ></asp:TextBox>
     <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please enter valid Mobile2"
                                 ControlToValidate="txtMobile2" ValidationExpression="[1-9]{1}[0-9]{5}"></asp:RegularExpressionValidator>
                                  <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMobile2" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
 </div>

 <div class="large-3 columns">
 <asp:Label ID="Label28" runat="server" Text="E-Mail"></asp:Label><span style="color:Red;">*</span>
 </div>
 <div class="large-3 columns">
  <asp:TextBox ID="txtEmail" runat="server" Height="38px" Width="200px" ></asp:TextBox>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="Enter Email-ID (Address Tab)" Display="None"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="txtEmalValidation" runat="server" ControlToValidate="txtEmail" 
                                    ErrorMessage="Incorrect Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtEmail"
                                                            ErrorMessage="Required" Display="None"></asp:RequiredFieldValidator>--%>
 </div>
 </div>


 </div>
<div id="sectionc" class="tab-pane fade">
<br />
<div class="row">
<div class="large-4 columns">
   <asp:Label ID="lblBankName" runat="server" Text="Name of Bank"></asp:Label>
</div>
<div class="large-4 columns">
 <asp:TextBox ID="txtBankName" runat="server" MaxLength="125" Height="38px" Width="200px" style="text-transform:capitalize;"></asp:TextBox>
</div>
<div class="large-4 columns"></div>
</div>
<br />

<div class="row">
<div class="large-4 columns">
  <asp:Label ID="lblMICR" runat="server" Text="IFSC Code"></asp:Label>&nbsp;<a href="http://www.bankifsccode.com" target="_blank" style="font-size:13px">(Know your IFSC Code)</a><span style="color:Red;">*</span>
</div>
<div class="large-4 columns">
  <asp:TextBox ID="txtMICR" runat="server" Height="38px" Width="200px"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMICR"
                                        ErrorMessage="IFSC Code (Address Tab)" Display="None"></asp:RequiredFieldValidator>
                                          <asp:RegularExpressionValidator ID="txtMICRValid" runat="server" ControlToValidate="txtMICR" ErrorMessage="Incorrect IFSC Code" ValidationExpression="[A-Za-z]{4}[0][A-Z0-9]{6}"></asp:RegularExpressionValidator>
</div>
<div class="large-4 columns"></div>
</div>

<div class="row">
<div class="large-4 columns">
 <asp:Label ID="lblBranchAddress" runat="server" Text="Address of Branch" style="text-transform:capitalize;"></asp:Label>
</div>
<div class="large-4 columns">
<asp:TextBox ID="txtBranchAddress" runat="server" MaxLength="125" Height="38px" Width="200px"></asp:TextBox>
</div>
<div class="large-4 columns"></div>
</div>
<br />
<div class="row">
<div class="large-4 columns">
 <asp:Label ID="lblAccountType" runat="server" Text="Account Type"></asp:Label><span style="color:Red;">*</span>
</div>
<div class="large-4 columns">
 <asp:DropDownList ID="ddlAccountType" runat="server" Height="38px" Width="200px">
                                            <asp:ListItem>Savings</asp:ListItem>
                                            <asp:ListItem>Current</asp:ListItem>
                                        </asp:DropDownList>
</div>
<div class="large-4 columns"></div>
</div>

<div class="row">
<div class="large-4 columns">
 <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number"></asp:Label><span style="color:Red;">*</span>
</div>
<div class="large-4 columns">
 <asp:TextBox ID="txtAccountNumber" runat="server"  MaxLength="20" Height="38px" Width="200px"></asp:TextBox>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAccountNumber"
                                        ErrorMessage="Account Number (Address Tab)" Display="None"></asp:RequiredFieldValidator>
                                          <asp:RegularExpressionValidator ID="txtAccountNumberValid" runat="server" ControlToValidate="txtAccountNumber" ValidationExpression="[a-zA-Z0-9]([/-]?(((\d*[1-9]\d*)*[a-zA-Z])|(\d*[1-9]\d*[a-zA-Z]*))+)*[0-9]*" ErrorMessage="Invalid Account Number"></asp:RegularExpressionValidator>
</div>
<div class="large-4 columns"></div>
</div>

<div class="row">
<div class="large-4 columns">
  <asp:Label ID="lblESC" runat="server" Text="ECS (Y/N)"></asp:Label>
</div>
<div class="large-4 columns">
 <asp:DropDownList ID="ddlESC" runat="server" Height="38px" Width="200px">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
</div>
<div class="large-4 columns"></div>
</div>

<div class="row">
<div class="large-4 columns">
  <asp:Label ID="lblRefund" runat="server" Text="Refund Method"></asp:Label>
</div>
<div class="large-4 columns">
<asp:DropDownList ID="ddlRefund" runat="server" Height="38px" Width="200px">
                                            <asp:ListItem>By Cheque</asp:ListItem>
                                            <asp:ListItem>Direct Deposit</asp:ListItem>
                                        </asp:DropDownList>
</div>
<div class="large-4 columns"></div>
</div>
<br />

</div>
<br />
<div id="sectiond" class="tab-pane fade">




<div class="row">
<div class="large-6 columns">
 <asp:Label ID="Label24" runat="server" Text="Business Nature"></asp:Label>
</div>
<div class="large-6 columns">
<asp:DropDownList ID="ddlBNHUF" runat="server" Height="38px" Width="200px">
                                                            <asp:ListItem>Manufacturing</asp:ListItem>
                                                            <asp:ListItem>Trading</asp:ListItem>
                                                            <asp:ListItem>Manufacturing-cum-Trading</asp:ListItem>
                                                            <asp:ListItem>Services</asp:ListItem>
                                                            <asp:ListItem>Profession</asp:ListItem>
                                                            <asp:ListItem>Other</asp:ListItem>
                                                        </asp:DropDownList>
</div>
</div>

<div class="row">
<div class="large-6 columns">
<asp:Label ID="Label23" runat="server" Text="AO Code/Area Code" ></asp:Label>
</div>
<div class="large-6 columns">
<asp:TextBox ID="txtWardHUF" runat="server" Height="38px" Width="200px"></asp:TextBox>
</div>
</div>
<br />
<div class="row">
<div class="large-6 columns">
     <asp:CheckBox ID="CheckBox3" runat="server" Text="Change in Jurisdiction" />
</div>
<div class="large-6 columns">
 <asp:CheckBox ID="CheckBox4" runat="server" Text="Is there a permanent establishment in India"
                                                             />
</div>
</div>
                  

<div class="row">
                          
                                <div class="large-3 columns">
                                    Nature of Business:
                                </div>
                                <div class="large-3 columns">
                                    TradeName:
                                </div>
                                <div class="large-3 columns">
                                    TradeName:
                                </div>
                                <div class="large-3 columns">
                                    TradeName:
                                </div>
                            </div>
                     
                        <div class="row">
                           
                                <div class="large-3 columns">
                                    <asp:DropDownList ID="ddBusiness" runat="server" onchange="enableIt(this);" Width="171px">
                                    </asp:DropDownList>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade1" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade2" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade3" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                           
                        </div>
                        <div class="row">
                           
                                <br />
                                <div class="large-3 columns">
                                    <asp:DropDownList ID="ddBusiness2" runat="server" onchange="enableIt(this);" Width="171px">
                                    </asp:DropDownList>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade11" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade22" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade33" runat="server" disabled="disabled"></asp:TextBox>
                              
                            </div>
                        </div>
                        <div class="row">
                            
                                <br />
                                <div class="large-3 columns">
                                    <asp:DropDownList ID="ddBusiness3" runat="server" onchange="enableIt(this);" Width="171px">
                                    </asp:DropDownList>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade111" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade222" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade333" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                         
                        </div>
</div>
<div id="sectione" class="tab-pane fade" style="display:none">

<div class="row">
<div class="large-6 columns"> <asp:RadioButton ID="rdoRepresentative" runat="server" AutoPostBack="True" GroupName="grpSignatory"
                                OnCheckedChanged="rdoRepresentative_CheckedChanged" Text="Representative" /></div>
<div class="large-6 columns"><asp:RadioButton
                                ID="rdoSelf" runat="server" AutoPostBack="True" GroupName="grpSignatory" OnCheckedChanged="rdoSelf_CheckedChanged"
                                Text="Karta" /></div>
</div>
  <div class="row">
  <div class="large-12 columns">
    <asp:Panel ID="pnlRepresentative" runat="server"  Visible="False" >
    <div class="row">
    <div class="large-6 columns">
     <asp:Label ID="Label4" runat="server" Text="Name"></asp:Label><span style="color:Red">*</span>
    </div>
    <div class="large-6 columns">
     <asp:TextBox ID="txtNameRep" runat="server" Height="38px" Width="200px"></asp:TextBox>
    <%-- <asp:RequiredFieldValidator ID="RQ1" runat="server" ControlToValidate="txtNameRep" ErrorMessage="Please fill your name in Authorised Signatory"></asp:RequiredFieldValidator>--%>
    </div>
    </div>
    <br />
     <div class="row">
    <div class="large-6 columns">
      <asp:Label ID="Label7" runat="server" Text="PAN"></asp:Label>
    </div>
    <div class="large-6 columns">
      <asp:TextBox ID="txtPANRep" runat="server" style="text-transform:uppercase" Height="38px" Width="200px"></asp:TextBox>
    </div>
    </div>
    <br />
     <div class="row">
    <div class="large-6 columns">
    <asp:Label ID="Label8" runat="server" Text="Designation"></asp:Label>
    </div>
    <div class="large-6 columns">
     <asp:TextBox ID="txtDesignationRep" runat="server" Height="38px" Width="200px"></asp:TextBox>
    </div>
    </div>
    <br />
     <div class="row">
    <div class="large-6 columns">
      <asp:Label ID="Label9" runat="server" Text="Place"></asp:Label>
    </div>
    <div class="large-6 columns">
     <asp:TextBox ID="txtPlaceRep" runat="server" Height="38px" Width="200px"></asp:TextBox>
    </div>
    </div>
    <br />
     <div class="row">
    <div class="large-6 columns">
      <asp:Label ID="Label5" runat="server" Text="Flat"></asp:Label>
    </div>
    <div class="large-6 columns">
      <asp:TextBox ID="txtFlatRep" runat="server" Height="38px" Width="200px"></asp:TextBox>
    </div>
    </div>
    <br />
     <div class="row">
    <div class="large-6 columns">
     <asp:Label ID="Label17" runat="server" Text="Premises"></asp:Label>
    </div>
    <div class="large-6 columns"> <asp:TextBox ID="txtPremisesRep" runat="server" Height="38px" Width="200px"></asp:TextBox></div>
    </div>
    <br />
     <div class="row">
    <div class="large-6 columns">
    <asp:Label ID="Label211" runat="server" Text="Road"></asp:Label>
    </div>
    <div class="large-6 columns">
       <asp:TextBox ID="txtRoadRep" runat="server" Height="38px" Width="200px"></asp:TextBox>
    </div>
    </div>
    <br />
     <div class="row">
    <div class="large-6 columns">
      <asp:Label ID="Label27" runat="server" Text="Area"></asp:Label>
    </div>
    <div class="large-6 columns">
      <asp:TextBox ID="txtAreaRep" runat="server" Height="38px" Width="200px"></asp:TextBox>
    </div>
    </div>
    <br />
     <div class="row">
    <div class="large-6 columns">
        <asp:Label ID="Label29" runat="server" Text="City"></asp:Label>
    </div>
    <div class="large-6 columns">
     <asp:TextBox ID="txtCityRep" runat="server" Height="38px" Width="200px"></asp:TextBox>
    </div>
    </div>
    <br />
     <div class="row">
    <div class="large-6 columns">
     <asp:Label ID="Label33" runat="server" Text="State"></asp:Label>
    </div>
    <div class="large-6 columns">
    <asp:DropDownList ID="ddlStatesRep" runat="server" DataSourceID="ObjectDataSource2"
                                                DataTextField="StateName" DataValueField="StateCode" Height="38px" Width="200px">
                                            </asp:DropDownList>
    </div>
    </div>
    <br />
     <div class="row">
    <div class="large-6 columns">
    <asp:Label ID="Label34" runat="server" Text="PIN"></asp:Label>
    </div>
    <div class="large-6 columns">
      <asp:TextBox ID="txtPINRep" runat="server" Height="38px" Width="200px"></asp:TextBox>
     
    </div>
    </div>
    <br />
     
    </asp:Panel>
  </div>
  </div>                          
  <div class="row">
  <div class="large-12 columns">
   <asp:Panel ID="pnlAuthorised" runat="server"  Visible="False" >
   <div class="row">
   <div class="large-6 columns">
    <asp:Label ID="Label10" runat="server" Text="Name"></asp:Label>
   </div>
   <div class="large-6 columns">
     <asp:TextBox ID="txtNameAu" runat="server" Height="38px" Width="200px"></asp:TextBox>
   </div>
   </div>
   <br />
     <div class="row">
   <div class="large-6 columns">
       <asp:Label ID="Label11" runat="server" Text="Father Name"></asp:Label><span style="color:Red">*</span>
   </div>
   <div class="large-6 columns">
      <asp:TextBox ID="txtFNameAu" runat="server" Height="38px" Width="200px"></asp:TextBox>
  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtFNameAu" ErrorMessage="Please fill father name in Authorised Signatory"></asp:RequiredFieldValidator>--%>
   </div>
   </div>
 
     <div class="row">
   <div class="large-6 columns">
      <asp:Label ID="Label12" runat="server" Text="Designation"></asp:Label>
   </div>
   <div class="large-6 columns">
     <asp:TextBox ID="txtDesignationAu" runat="server" Height="38px" Width="200px"></asp:TextBox>
   </div>
   </div>
   <%
       if (Session["ITR"].ToString() != "1" && Session["ITR"].ToString() != "8")
       {
        %>
   <br />
     <div class="row">
   <div class="large-6 columns">
     <asp:Label ID="Label13" runat="server" Text="Place"></asp:Label>
   </div>
   <div class="large-6 columns">
          <asp:TextBox ID="txtPlaceAu" runat="server" Height="38px" Width="200px"></asp:TextBox>
   </div>
   </div>
   <br />
     <div class="row">
   <div class="large-6 columns">
     <asp:Label ID="Label14" runat="server" Text="Date of Filing"></asp:Label>
   </div>
   <div class="large-6 columns">
      <asp:TextBox ID="txtDateAu" runat="server" Height="38px" Width="200px"></asp:TextBox>
   </div>
   </div>
   <br />
     <div class="row">
   <div class="large-6 columns">
    <asp:Label ID="Label15" runat="server" Text="Ward/Circle/CIT"></asp:Label>
   </div>
   <div class="large-6 columns">
    <asp:TextBox ID="txtWardAu" runat="server" Height="38px" Width="200px"></asp:TextBox>
   </div>
   </div>
   <br />

   <%} %>
   </asp:Panel>
  </div>
  </div>
</div>
</div>
<div class="container">
<div class="row">
<div class="col-xs-4 col-sm-4 col-md-4 col-lg-4"><asp:Button ID="btnSave" runat="server" Text="Save & Continue" OnClick="btnSave_Click" class="radius button"  /></div>
<div class="col-xs-8 col-sm-8 col-md-8 col-lg-8"> <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True" Text="Label" Visible="False"></asp:Label></div>
</div>
</div>

</div>

</div>
 <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="getStates"
                                TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="getStates"
                    TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
</div>
   <%--<div class="show-for-large-only">
   <menu:side ID="Sidemenu" runat="server"  />
   </div>
--%>
</form>
<%--<table width="100%" border="0" cellspacing="00" cellpadding="00">

<tr>
<td colspan="2"><main:mainmenu ID="mm1" runat="server" /></td></tr>
<tr>
<td width="21%" valign="top" bgcolor="#6D89DD" style="height: 839px"><sub:submenu ID="sub1" runat="server" /></td>
<td width="79%" valign="top" style="height: 839px">
         <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            
        </asp:ScriptManager> 
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 776px">
                    <tr>
                        <td bgcolor="#ffb937" style="HEIGHT: 19px; width: 809px;" colspan="3"><font class="WhiteMed">&nbsp;<asp:Label ID="lblHeading" runat="server" Font-Bold="True"
                                                Text="Assessee Details"></asp:Label></font></td>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#ffb937" style="HEIGHT: 19px; width: 809px;" colspan="3"><font class="WhiteMed">&nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True"
                                                Text="Assessee Type"></asp:Label>
                            <asp:Label ID="lblAssesseeType" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp;&nbsp;
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Pan Number"></asp:Label>&nbsp;
                            <asp:Label ID="lblPan" runat="server" Font-Bold="True" Text="Label"></asp:Label></font></td>
                        </td>
                    </tr>
                </table>
                <br />
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="4" Height="353px">
                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <ContentTemplate>
                            <table style="width: 765px">
                                <tr>
                                    <td>
                                                       
                                    </td>
                                    <td>
                                                        
                                    </td>
                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNameHUF"
                                                            ErrorMessage="Required" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                                        <asp:Label ID="Label21" runat="server" Text="Date of Formation"></asp:Label>
                                    </td>
                                    <td>
                                                        <asp:TextBox ID="txtDateHUF" runat="server" Width="168px" ></asp:TextBox>
                                    </td>
                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDateHUF"
                                                            ErrorMessage="Required" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <HeaderTemplate>
                            Personal Details
                        </HeaderTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <ContentTemplate>
                            <table style="width: 681px; height: 309px">
                                <tr>
                                    <td style="width: 323px">
                                                            <asp:Label ID="Label2" runat="server" Text="Flat/Door/Block No."></asp:Label>
                                    </td>
                                    <td style="width: 340px">
                                                            <asp:TextBox ID="txtFlat" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 323px">
                                                            <asp:Label ID="Label18" runat="server" Text="Name of Premises/Building/Village"></asp:Label>
                                    </td>
                                    <td style="width: 340px">
                                                            <asp:TextBox ID="txtPremises" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 323px">
                                                            <asp:Label ID="Label19" runat="server" Text="Road/Street/Lane/PostOffice"></asp:Label>
                                    </td>
                                    <td style="width: 340px">
                                                            <asp:TextBox ID="txtRoad" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 323px">
                                                            <asp:Label ID="Label25" runat="server" Text="Area"></asp:Label>
                                    </td>
                                    <td style="width: 340px">
                                                            <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 323px">
                                                            <asp:Label ID="Label30" runat="server" Text="City"></asp:Label>
                                    </td>
                                    <td style="width: 340px">
                                                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 323px">
                                                            <asp:Label ID="Label31" runat="server" Text="State"></asp:Label>
                                    </td>
                                    <td style="width: 340px">
                                                            <asp:DropDownList ID="ddlState" runat="server" Width="145px" DataSourceID="ObjectDataSource1" DataTextField="StateName" DataValueField="StateCode" >
                                                            </asp:DropDownList>
                                    </td>
                                    <td style="width: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 323px">
                                                            <asp:Label ID="Label32" runat="server" Text="PIN"></asp:Label>
                                    </td>
                                    <td style="width: 340px">
                                                            <asp:TextBox ID="txtPIN" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 323px">
                                                        <asp:Label ID="Label26" runat="server" Text="STD"></asp:Label></td>
                                    <td style="width: 340px">
                                        <asp:TextBox ID="txtSTD"
                                                            runat="server" Width="75px"></asp:TextBox></td>
                                    <td style="width: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 323px">
                                                        <asp:Label ID="Label39" runat="server" Text="Phone"></asp:Label></td>
                                    <td style="width: 340px">
                                        <asp:TextBox ID="txtPhone"
                                                            runat="server" Width="168px"></asp:TextBox></td>
                                    <td style="width: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 323px">
                                                        <asp:Label ID="Label28" runat="server" Text="E-Mail"></asp:Label></td>
                                    <td style="width: 340px">
                                                        <asp:TextBox ID="txtEmail" runat="server" Width="312px"></asp:TextBox></td>
                                    <td style="width: 3px">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEmail"
                                                            ErrorMessage="Required" Display="None"></asp:RequiredFieldValidator></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <HeaderTemplate>
                            Address
                        </HeaderTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                        <ContentTemplate>
                            <table style="width: 665px">
                                <tr>
                                    <td>
                                                        <asp:Label ID="Label20" runat="server" Text="T.A.N."></asp:Label>
                                    </td>
                                    <td>
                                                        <asp:TextBox ID="txtTANHUF" runat="server" Width="168px"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                                        <asp:Label ID="Label23" runat="server" Text="AO Code/Area Code" Width="138px"></asp:Label>
                                    </td>
                                    <td>
                                                        <asp:TextBox ID="txtWardHUF" runat="server" Width="168px"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                                        <asp:Label ID="Label22" runat="server" Text="Residential Status" Width="128px"></asp:Label>
                                    </td>
                                    <td>
                                                        <asp:DropDownList ID="ddlResHUF" runat="server" Width="176px">
                                                            <asp:ListItem>Resident</asp:ListItem>
                                                            <asp:ListItem>Non-Resident</asp:ListItem>
                                                            <asp:ListItem>Not-Ordinarily Resident</asp:ListItem>
                                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                                        <asp:Label ID="Label24" runat="server" Text="Business Nature"></asp:Label>
                                    </td>
                                    <td>
                                                        <asp:DropDownList ID="ddlBNHUF" runat="server" Width="176px">
                                                            <asp:ListItem>Manufacturing</asp:ListItem>
                                                            <asp:ListItem>Trading</asp:ListItem>
                                                            <asp:ListItem>Manufacturing-cum-Trading</asp:ListItem>
                                                            <asp:ListItem>Services</asp:ListItem>
                                                            <asp:ListItem>Profession</asp:ListItem>
                                                            <asp:ListItem>Other</asp:ListItem>
                                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                                        <asp:CheckBox ID="CheckBox3" runat="server" Text="Change in Jurisdiction" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                                        <asp:CheckBox ID="CheckBox4" runat="server" Text="Is there a permanent establishment in India"
                                                            Width="304px" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <HeaderTemplate>
                            Other Information
                        </HeaderTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                        <ContentTemplate>
                            <table style="width: 374px">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblBankName" runat="server" Text="Name of Bank"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMICR" runat="server" Text="MICR Code(9 Digit)"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtMICR" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblBranchAddress" runat="server" Text="Address of Branch"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtBranchAddress" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAccountType" runat="server" Text="Account Type"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="ddlAccountType" runat="server" Width="143px">
                                            <asp:ListItem>Savings</asp:ListItem>
                                            <asp:ListItem>Current</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtAccountNumber" runat="server" Width="185px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblESC" runat="server" Text="ECS (Y/N)"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="ddlESC" runat="server" Width="56px">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRefund" runat="server" Text="Refund Method"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="ddlRefund" runat="server" Width="142px">
                                            <asp:ListItem>By Cheque</asp:ListItem>
                                            <asp:ListItem>Direct Deposit</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <HeaderTemplate>
                            Bank Details
                        </HeaderTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5">
                        <ContentTemplate>
                            <asp:RadioButton ID="rdoRepresentative" runat="server" GroupName="grpSignatory" Text="Representative" AutoPostBack="True" OnCheckedChanged="rdoRepresentative_CheckedChanged" />
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:RadioButton ID="rdoSelf" runat="server" GroupName="grpSignatory" Text="Self/Director/Partner" AutoPostBack="True" OnCheckedChanged="rdoSelf_CheckedChanged" /><br />
                            <asp:Panel ID="pnlRepresentative" runat="server" Height="50px" Width="125px" Visible="False">
                                <table style="width: 765px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Name"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtNameRep" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="PAN"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPANRep" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text="Designation"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesignationRep" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text="Place"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPlaceRep" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Flat"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFlatRep" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" Text="Premises"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPremisesRep" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="Road"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRoadRep" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label27" runat="server" Text="Area"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAreaRep" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label29" runat="server" Text="City"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCityRep" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label33" runat="server" Text="State"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlStatesRep" runat="server" DataSourceID="ObjectDataSource2"
                                                DataTextField="StateName" DataValueField="StateCode" Width="146px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label34" runat="server" Text="PIN"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPINRep" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="pnlAuthorised" runat="server" Height="50px" Width="125px" Visible="False">
                                <table style="width: 763px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Text="Name"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtNameAu" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text="Father Name"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtFNameAu" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Text="Designation"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtDesignationAu" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Text="Place"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtPlaceAu" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label14" runat="server" Text="Date of Filing"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtDateAu" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" Text="Ward/Circle/CIT"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtWardAu" runat="server"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                        <HeaderTemplate>
                            Authorised Signatory
                        </HeaderTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getStates"
                    TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getStates"
                    TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" /><br />
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Text="Label" Visible="False"></asp:Label><br />
    <br />
        </ContentTemplate>
       
       
        
      </asp:UpdatePanel>
      </form>      
    
                
    
    
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</table>--%>
</body>
</html>
