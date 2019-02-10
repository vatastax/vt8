<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Partnership.aspx.cs" Inherits="Presentation_Partnership" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %> <%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../mobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../mobilemenu2.ascx" TagPrefix="mob1" TagName="menu1" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagName="resmob" TagPrefix="resmenu" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../Presentation/MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
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
    <script src="../js/tab.js" type="text/javascript"></script>
    <script src="../js/Modernizer.min.js" type="text/javascript"></script>--%>
   
    <%--<link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />--%>

   <%-- <script src="../foundation-5.5.0/js/foundation.min.js" type="text/javascript"></script>
    <script src="../css/jquery-1.4.2.min.js" type="text/javascript"></script>--%>

      <%--<link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />--%>


       <!--master javascript file-->
    <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <!--master javascript file-->

       <!--master style sheet-->
    <link href="../style_folder/ItrSoftwareCompanyStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->

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

    });
</script>--%>

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

    function setSelf(vals) {
        //alert(vals);
        try {
            if (vals == '1') {
                document.getElementById('txtNameRep').disabled = 'true';
                document.getElementById('txtPANRep').disabled = 'true';
                document.getElementById('txtDesignationRep').disabled = 'true';
                document.getElementById('txtPlaceRep').disabled = 'true';
                document.getElementById('txtFlatRep').disabled = 'true';
                document.getElementById('txtPremisesRep').disabled = 'true';
                document.getElementById('txtRoadRep').disabled = 'true';
                document.getElementById('txtAreaRep').disabled = 'true';
                document.getElementById('txtCityRep').disabled = 'true';
                document.getElementById('ddlStatesRep').disabled = 'true';
                document.getElementById('txtPINRep').disabled = 'true';
                document.getElementById('txtNameAu').disabled = 'true';
                document.getElementById('txtFNameAu').disabled = 'true';
                document.getElementById('txtDesignationAu').disabled = 'true';
                document.getElementById('txtPlaceAu').disabled = 'true';
                document.getElementById('txtDateAu').disabled = 'true';
                document.getElementById('txtWardAu').disabled = 'true';
            }
            else {
                document.getElementById('txtNameRep').removeAttribute('disabled');
                document.getElementById('txtPANRep').removeAttribute('disabled');
                document.getElementById('txtDesignationRep').removeAttribute('disabled');
                document.getElementById('txtPlaceRep').removeAttribute('disabled');
                document.getElementById('txtFlatRep').removeAttribute('disabled');
                document.getElementById('txtPremisesRep').removeAttribute('disabled');
                document.getElementById('txtRoadRep').removeAttribute('disabled');
                document.getElementById('txtAreaRep').removeAttribute('disabled');
                document.getElementById('txtCityRep').removeAttribute('disabled');
                document.getElementById('ddlStatesRep').removeAttribute('disabled');
                document.getElementById('txtPINRep').removeAttribute('disabled');
                document.getElementById('txtNameAu').removeAttribute('disabled');
                document.getElementById('txtFNameAu').removeAttribute('disabled');
                document.getElementById('txtDesignationAu').removeAttribute('disabled');
                document.getElementById('txtPlaceAu').removeAttribute('disabled');
                document.getElementById('txtDateAu').removeAttribute('disabled');
                document.getElementById('txtWardAu').removeAttribute('disabled');

            }
        }
        catch (e) { alert(e); }
    }
    </script>
</head>


<body onload="P7_ExpMenu();setSelf('1');">
<form id="form1" runat="server" role="form">

<div class="container-fluid">
<br />
  <div class="row ">
        <div class="small-6 columns" style="vertical-align:top; ">
        <a href="Default.aspx">
            <img src="../images/logo2.png" style="width:220px; height:83px" />    </a>        
    </div>   
     <div class="small-6 columns text-right">
      Welcome <span style="font-weight:bold"><asp:Literal ID="ltUser" runat="server">   </asp:Literal></span>
   
      <br />
      <a href="logout.aspx">
      [Logout]
      </a>
     </div> 
    </div> 
 <div class="row">
 <br />
     <div class="large-12 columns">
         <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
             Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" NodeStyle-Font-Bold="false" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
     </div>
     </div>
       <div class="row hide-for-small-only">
  
     <div class="large-12 columns  ">
      <mob3:mediummenu id="Mediummenu1" runat="server" />
     </div>
     </div>
</div>

<br />

      
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

   
<div class="container-fluid">
<div class="row">
<%--<div class="col-xs-3 col-sm-3 col-md-3 col-lg-3 show-for-large-only"><sub:submenu ID="Submenu1" runat="server"  /></div>--%>
<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
            
        </asp:ScriptManager> 
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
      <%--  <div class="row hide-for-small-only">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <p class="bg-primary"><asp:Label ID="lblHeading" runat="server" 
                                                Text="Assessee Details" class="bg-primary"></asp:Label></p>
        </div>
        </div>--%>
        <div class="row  bg-primary hide-for-small-only">
        <div class="large-6 columns"><asp:Label ID="Label1" runat="server" Font-Bold="true"
                                                Text="Assessee Type" ></asp:Label>&nbsp; <asp:Label ID="lblAssesseeType" runat="server"  Text="Label"></asp:Label></div>
        <div class="large-6 columns">
        <asp:Label ID="Label3" runat="server"  Text="Pan Number" Font-Bold="true"  ></asp:Label>&nbsp;
                            <asp:Label ID="lblPan" runat="server"  Text="Label" ></asp:Label>
        </div>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <br />
<div class="container-fluid">

<ul class="nav nav-tabs" role="tablist" id="mytab">
<li class="active"><a  href="#SectionA" data-toggle="tab">Personal Details</a></li>
<li><a  href="#sectionB" data-toggle="tab" click="show();">Address</a></li>
<li><a  href="#sectionc"  data-toggle="tab">Bank Details</a></li>
<li><a  href="#sectiond"  data-toggle="tab">Other Information</a></li>
<li><a  href="#sectione"  data-toggle="tab">Signatory</a></li>
</ul>




 
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getStates"
                    TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getStates"
                    TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
</div>
<br />
<div class="tab-content">
<div id="SectionA"  class="tab-pane fade in active">

<div class="row">
<div class="large-6 columns">
  <asp:Label ID="Label4" runat="server" Text="Name"></asp:Label><span style="color:Red;">*</span>
</div>
<div class="large-6 columns">
<asp:TextBox ID="txtNamePart" runat="server" ></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNamePart"
                ErrorMessage="Enter Name (Personal Tab)" Display="None"></asp:RequiredFieldValidator>
</div>
</div>
<br />
<div class="row">
<div class="large-6 columns">
<asp:Label ID="Label5" runat="server" Text="Date of Constitution"></asp:Label><span style="color:Red;">*</span>
</div>
<div class="large-6 columns">
<asp:TextBox ID="txtDatePart" runat="server" type="date" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDatePart"
                                                            ErrorMessage="Enter Date of Constitution (Personal Tab)" Display="None" ></asp:RequiredFieldValidator>
</div>
</div>

<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                                    ShowSummary="false" />



</div>
 <div id="sectionB" class="tab-pane fade">
 
 
 
                         <div class="row">
                         <div class="large-3 columns"><asp:Label ID="Label2" runat="server" Text="Flat/Door/Block No."></asp:Label><span style="color:Red;">*</span>
                         </div>
                         <div class="large-3 columns"><asp:TextBox ID="txtFlat" runat="server" ></asp:TextBox> 
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFlat"
                                                            ErrorMessage="Enter Flat/Door/Block (Address Tab)" Display="None"></asp:RequiredFieldValidator></div>
                      
                            
                         <div class="large-3 columns"><asp:Label ID="Label18" runat="server" Text="Name of Premises/Building/Village" Width="234px"></asp:Label></div>
                         <div class="large-3 columns"><asp:TextBox ID="txtPremises" runat="server"  ></asp:TextBox></div>
                         </div> 
                           <br />
                           <div class="row">
                         <div class="large-3 columns">  <asp:Label ID="Label19" runat="server" Text="Road/Street/Lane/PostOffice"></asp:Label></div>
                         <div class="large-3 columns"><asp:TextBox ID="txtRoad" runat="server" ></asp:TextBox></div>
                        
                         <div class="large-3 columns">  <asp:Label ID="Label25" runat="server" Text="Area"></asp:Label><span style="color:Red;">*</span></div>
                         <div class="large-3 columns"><asp:TextBox ID="txtArea" runat="server"  ></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtArea"
                                                            ErrorMessage="Enter Area (Address Tab)" Display="none"></asp:RequiredFieldValidator></div>
                         </div> 
                           <br />
                           <div class="row">
                         <div class="large-3 columns">  <asp:Label ID="Label30" runat="server" Text="City"></asp:Label><span style="color:Red;">*</span></div>
                         <div class="large-3 columns"> <asp:TextBox ID="txtCity" runat="server"  ></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity"
                                                            ErrorMessage="Enter City (Address Tab)"  Display="None"></asp:RequiredFieldValidator></div>
                        
                         <div class="large-3 columns">   <asp:Label ID="Label31" runat="server" Text="State"></asp:Label><span style="color:Red;">*</span></div>
                         <div class="large-3 columns">  <asp:DropDownList ID="ddlState" runat="server" DataSourceID="ObjectDataSource1" DataTextField="StateName" DataValueField="StateCode" Width="171px" >
                                                            </asp:DropDownList></div>
                         </div> 
                      
                            <div class="row">
                         <div class="large-3 columns">   <asp:Label ID="Label32" runat="server" Text="PIN"></asp:Label><span style="color:Red;">*</span></div>
                         <div class="large-3 columns"> <asp:TextBox ID="txtPIN" runat="server"  ></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPIN"
                                                            ErrorMessage="Enter PIN (Address Tab)" Display="None"></asp:RequiredFieldValidator></div>
                        
                         <div class="large-3 columns">    <asp:Label ID="Label14" runat="server" Text="STD"></asp:Label></div>
                         <div class="large-3 columns">  <asp:TextBox ID="txtSTD" runat="server"  ></asp:TextBox>
                                                            
                         </div> 
                         </div>
                           <br />
                           <div class="row">
                         <div class="large-3 columns">     <asp:Label ID="Label33" runat="server" Text="Phone"></asp:Label></div>
                         <div class="large-3 columns">  <asp:TextBox ID="txtPhone" runat="server"  ></asp:TextBox>
                                                            
                         </div> 
                        
                         <div class="large-3 columns">    <asp:Label ID="Label38" runat="server" Text="Mobile1"></asp:Label><span style="color:Red;">*</span></div>
                         <div class="large-3 columns">   <asp:TextBox ID="txtMobile1" runat="server"  ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMobile1"
                                                            ErrorMessage="Enter Mobile1 (Address Tab)" Display="None"></asp:RequiredFieldValidator>
                                                            
                         </div> 
                         </div>
                           <br />
                           <div class="row">
                         <div class="large-3 columns">     <asp:Label ID="Label39" runat="server" Text="Mobile2"></asp:Label></div>
                         <div class="large-3 columns">  <asp:TextBox ID="txtMobile2" runat="server"  ></asp:TextBox>
                                                            
                         </div> 
                        
                         <div class="large-3 columns">    <asp:Label ID="Label12" runat="server" Text="E-Mail"></asp:Label><span style="color:Red;">*</span></div>
                         <div class="large-3 columns">  <asp:TextBox ID="txtEmail" runat="server"  ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
                                                            ErrorMessage="Enter Email (Address Tab)" Display="None" ></asp:RequiredFieldValidator>
                                                            
                         </div> 
                         </div>



 </div>
<div id="sectionc" class="tab-pane fade">

<div class="row">
                   <div class="large-4 columns">
                    <asp:Label ID="lblBankName" runat="server" Text="Name of Bank"></asp:Label>
                   </div>
                    <div class="large-8 columns"><asp:TextBox ID="txtBankName" runat="server"  ></asp:TextBox></div>
                   </div>
                         <br />
                         <div class="row">
                   <div class="large-4 columns">
                     <asp:Label ID="lblMICR" runat="server" Text="IFSC Code"></asp:Label>
                   </div>
                    <div class="large-8 columns">  <asp:TextBox ID="txtMICR" runat="server"  ></asp:TextBox><span style="color:Red;">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMICR"
                ErrorMessage="Enter IFSC Code (Bank Details Tab)" Display="None"></asp:RequiredFieldValidator>
                    </div>
                   </div>
                           <br />
                             <div class="row">
                   <div class="large-4 columns">
                     <asp:Label ID="lblBranchAddress" runat="server" Text="Address of Branch"></asp:Label>
                   </div>
                    <div class="large-8 columns">  <asp:TextBox ID="txtBranchAddress" runat="server"  ></asp:TextBox></div>
                   </div>
                          <br />
                           <div class="row">
                   <div class="large-4 columns">
                    <asp:Label ID="lblAccountType" runat="server" Text="Account Type"></asp:Label><span style="color:Red;">*</span>
                   </div>
                    <div class="large-8 columns">  <asp:DropDownList ID="ddlAccountType" runat="server" Width="171px">
                                       <asp:ListItem>Savings</asp:ListItem>
                                       <asp:ListItem>Current</asp:ListItem>
                                   </asp:DropDownList></div>
                   </div>
                   <br /><div class="row">
                           <div class="large-4 columns">
                   <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number"></asp:Label><span style="color:Red;">*</span>
                   </div>
                    <div class="large-8 columns">   <asp:TextBox ID="txtAccountNumber" runat="server"   ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAccountNumber"
                ErrorMessage="Enter Account Number (Bank Details Tab)" Display="None"></asp:RequiredFieldValidator>
                    </div>
                   </div>
                   <br />
                   <div class="row">
                   <div class="large-4 columns">
                  <asp:Label ID="lblESC" runat="server" Text="ECS (Y/N)"></asp:Label>
                   </div>
                    <div class="large-8 columns">    <asp:DropDownList ID="ddlESC" runat="server" width="171px" >
                                       <asp:ListItem>Yes</asp:ListItem>
                                       <asp:ListItem>No</asp:ListItem>
                                   </asp:DropDownList></div>
                   </div>

                                                  <br />
                                                  <div class="row">
                   <div class="large-4 columns">
                <asp:Label ID="lblRefund" runat="server" Text="Refund Method"></asp:Label>
                   </div>
                    <div class="large-8 columns">     <asp:DropDownList ID="ddlRefund" runat="server" width="171px">
                                       <asp:ListItem>By Cheque</asp:ListItem>
                                       <asp:ListItem>Direct Deposit</asp:ListItem>
                                   </asp:DropDownList></div>
                   </div>



</div>
<br />
<div id="sectiond" class="tab-pane fade">

<div class="row">
                   <div class="large-4 columns"><asp:Label ID="Label49" runat="server" Text="T.A.N."></asp:Label></div>
                    <div class="large-8 columns"><asp:TextBox ID="txtTANPart" runat="server" ></asp:TextBox> </div>
                    </div>
                    <br />
                    <div class="row">
                   <div class="large-4 columns"><asp:Label ID="Label8" runat="server" Text="Type of Firm"></asp:Label></div>
                    <div class="large-8 columns"><asp:DropDownList ID="ddlTypeofFirmPart" runat="server" Width="171px" >
                                                            <asp:ListItem>Others</asp:ListItem>
                                                            <asp:ListItem>Professional</asp:ListItem>
                                                        </asp:DropDownList> </div>
                    </div>
                    <br />
                    <div class="row">
                   <div class="large-4 columns"><asp:Label ID="Label10" runat="server" Text="Residential Status" Width="128px"></asp:Label></div>
                    <div class="large-8 columns"> <asp:DropDownList ID="ddlResPart" runat="server" Width="171px">
                                                            <asp:ListItem>Resident</asp:ListItem>
                                                            <asp:ListItem>Non-Resident</asp:ListItem>
                                                            <asp:ListItem>Not-Ordinarily Resident</asp:ListItem>
                                                        </asp:DropDownList> </div>
                    </div>
                    <br />
                      <div class="row">
                   <div class="large-4 columns">  <asp:Label ID="Label7" runat="server" Text="Business Nature"></asp:Label></div>
                    <div class="large-8 columns">  <asp:DropDownList ID="ddlBussNaturePart" runat="server" width="171px">
                                                            <asp:ListItem>Manufacturing</asp:ListItem>
                                                            <asp:ListItem>Trading</asp:ListItem>
                                                            <asp:ListItem>Manufacturing-cum-Trading</asp:ListItem>
                                                            <asp:ListItem>Services</asp:ListItem>
                                                            <asp:ListItem>Profession</asp:ListItem>
                                                            <asp:ListItem>Other</asp:ListItem>
                                                        </asp:DropDownList> </div>
                    </div>
                    <br />
                     <div class="row">
                   <div class="large-4 columns">   <asp:Label ID="Label11" runat="server" Text="AO Code/Area Code" Width="143px"></asp:Label></div>
                    <div class="large-8 columns">     <asp:TextBox ID="txtWardPart" runat="server" ></asp:TextBox></div>
                    </div>
                    <br />

                     <div class="row">
                   <div class="large-4 columns" class="checkbox">   <asp:CheckBox ID="CheckBox1" runat="server" Text="Change in Jurisdiction" /></div>
                    <div class="large-8 columns" class="checkbox"> <asp:CheckBox ID="CheckBox2" runat="server" Text="Is there a permanent establishment in India"
                                                             /></div>
                    </div>
                    <br />
                  <br />
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
                           
                                <br />
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
<div id="sectione" class="tab-pane fade">

 <div class="row">
                           
                   <div class="large-4 columns"> <asp:RadioButton ID="rdoRepresentative" runat="server" GroupName="grpSignatory" Text="Representative" onchange="setSelf('0');"  /></div>
                   <div class="large-8 columns">
                   <asp:RadioButton ID="rdoSelf" runat="server" GroupName="grpSignatory" Text="Self/Director/Partner" onchange="setSelf('1');" />
                   </div>
                            </div>
                            <br />
                            <div class="row">
                            <div class="large-12 columns">
                             <asp:Panel ID="pnlRepresentative" runat="server">
                            <div class="row" >
                          
                   <div class="large-4 columns">  <asp:Label ID="Label6" runat="server" Text="Name"></asp:Label></div>
                   <div class="large-8 columns"><asp:TextBox ID="txtNameRep" runat="server" ></asp:TextBox></div>
                   </div>
                   <br />
                   <div class="row">
                           
                   <div class="large-4 columns"> <asp:Label ID="Label15" runat="server" Text="PAN"></asp:Label></div>
                   <div class="large-8 columns">  <asp:TextBox ID="txtPANRep" runat="server" style="text-transform:uppercase" ></asp:TextBox></div>
                   </div>
                   <br />
                   <div class="row">
                           
                   <div class="large-4 columns">  <asp:Label ID="Label16" runat="server" Text="Designation"></asp:Label></div>
                   <div class="large-8 columns">      <asp:TextBox ID="txtDesignationRep" runat="server"  ></asp:TextBox></div>
                   </div>
                   <br />
                   <div class="row">
                           
                   <div class="large-4 columns">   <asp:Label ID="Label17" runat="server" Text="Place"></asp:Label></div>
                   <div class="large-8 columns">      <asp:TextBox ID="txtPlaceRep" runat="server"  ></asp:TextBox></div>
                   </div>
                   <br />
                    <div class="row">
                           
                   <div class="large-4 columns">   <asp:Label ID="Label20" runat="server" Text="Flat"></asp:Label></div>
                   <div class="large-8 columns">      <asp:TextBox ID="txtFlatRep" runat="server"  ></asp:TextBox></div>
                   </div>
                   <br />
                   <div class="row">
                           
                   <div class="large-4 columns">   <asp:Label ID="Label21" runat="server" Text="Premises"></asp:Label></div>
                   <div class="large-8 columns">       <asp:TextBox ID="txtPremisesRep" runat="server"  ></asp:TextBox></div>
                   </div>
                   <br />
                    <div class="row">
                           
                   <div class="large-4 columns">   <asp:Label ID="Label22" runat="server" Text="Road"></asp:Label></div>
                   <div class="large-8 columns">        <asp:TextBox ID="txtRoadRep" runat="server" ></asp:TextBox></div>
                   </div>
                   <br />
                    <div class="row">
                           
                   <div class="large-4 columns">   <asp:Label ID="Label27" runat="server" Text="Area"></asp:Label></div>
                   <div class="large-8 columns">           <asp:TextBox ID="txtAreaRep" runat="server" ></asp:TextBox></div>
                   </div>
                   <br />
                    <div class="row">
                           
                   <div class="large-4 columns">    <asp:Label ID="Label29" runat="server" Text="City"></asp:Label></div>
                   <div class="large-8 columns">             <asp:TextBox ID="txtCityRep" runat="server" ></asp:TextBox></div>
                   </div>
                   <br />
                   <div class="row">
                           
                   <div class="large-4 columns">      <asp:Label ID="Label23" runat="server" Text="State"></asp:Label></div>
                   <div class="large-8 columns">              <asp:DropDownList ID="ddlStatesRep" runat="server" DataSourceID="ObjectDataSource2"
                                                DataTextField="StateName" DataValueField="StateCode" Width="171px" >
                                            </asp:DropDownList></div>
                   </div>
                   <br />
                   <div class="row">
                           
                   <div class="large-4 columns">       <asp:Label ID="Label34" runat="server" Text="PIN"></asp:Label></div>
                   <div class="large-8 columns">              <asp:TextBox ID="txtPINRep" runat="server" ></asp:TextBox></div>
                   </div>
                   <br />
                   <div class="row">
                           
                   <div class="large-4 columns">     <asp:Label ID="Label24" runat="server" Text="Name"></asp:Label></div>
                   <div class="large-8 columns">             <asp:TextBox ID="txtNameAu" runat="server"  ></asp:TextBox></div>
                   </div>
                   </asp:Panel>
                   </div>
                            </div>
                   <br />
                   <div class="row">
                   <div class="large-12 columns">
                   <asp:Panel ID="pnlAuthorised" runat="server">
                   
                    <div class="row" id="">
                           
                   <div class="large-4 columns">      <asp:Label ID="Label26" runat="server" Text="Father Name"></asp:Label></div>
                   <div class="large-8 columns">             <asp:TextBox ID="txtFNameAu" runat="server"  ></asp:TextBox></div>
                   </div>
                   <br />
                    <div class="row">
                           
                   <div class="large-4 columns">      <asp:Label ID="Label28" runat="server" Text="Designation"></asp:Label></div>
                   <div class="large-8 columns">             <asp:TextBox ID="txtDesignationAu" runat="server"  ></asp:TextBox></div>
                   </div>
                   <br />
                   <div class="row">
                           
                   <div class="large-4 columns">     <asp:Label ID="Label35" runat="server" Text="Place"></asp:Label></div>
                   <div class="large-8 columns">            <asp:TextBox ID="txtPlaceAu" runat="server"  ></asp:TextBox></div>
                   </div>
                   <br />
                   <div class="row">
                           
                   <div class="large-4 columns">     <asp:Label ID="Label36" runat="server" Text="Date of Filing"></asp:Label></div>
                   <div class="large-8 columns">            <asp:TextBox ID="txtDateAu" runat="server"  ></asp:TextBox></div>
                   </div>
                   <br />
                     <div class="row">
                           
                   <div class="large-4 columns">     <asp:Label ID="Label37" runat="server" Text="Ward/Circle/CIT"></asp:Label></div>
                   <div class="large-8 columns">             <asp:TextBox ID="txtWardAu" runat="server"  ></asp:TextBox></div>
                   </div>
                   <br />
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




  <%-- <div class="show-for-large-only">
   <menu:side ID="Sidemenu" runat="server"  />
   </div>--%>
</form>

</body>
</html>
