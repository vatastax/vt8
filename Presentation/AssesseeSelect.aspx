<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssesseeSelect.aspx.cs" Inherits="Presentation_AssesseeSelect"  EnableEventValidation="false"%>

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
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <title>The Interactive Platform for free e-filing Income Tax Returns in India</title>
        <link rel="icon" type="image/png" href="../images/fevicon.png"/>
<link rel="shortcut icon" type="image/png" href="../images/fevicon.png"/>
   
    <link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <%--<script src="../scripts/jquery.js" type="text/javascript"></script>
    <script src="../foundation-5.5.0/jquery.min.js" type="text/javascript"></script>
    <script src="../scripts/jquery-1.3.2.min.js" type="text/javascript"></script>--%>

    <%--<link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />--%>

    <%--<script type="text/javascript" src="../scripts/menu.js"></script>--%>

    <%--<link href="../foundation-5.5.0/css/foundation.min.css" rel="stylesheet" type="text/css" />--%>

    <%--<script src="../scripts/jquery.js" type="text/javascript"></script>
    <script src="../foundation-5.5.0/js/foundation.min.js" type="text/javascript"></script>
--%>
   <%-- <link href="../menu/flexnav.css" rel="stylesheet" type="text/css" />
    <link href="../menu/page.css" rel="stylesheet" type="text/css" />--%>

   <%-- <script src="../menu/js/flexnav.js" type="text/javascript"></script>--%>

    <%--<link href="../styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
   <link href="../styles/ui-1.10.4-themes-ui-lightness-jquery-ui.css" rel="stylesheet"   type="text/css" />--%>

    <%--<script src="../js/code-jquery-com-jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../js/code-jquery.com-ui-1.10.4-jquery-ui.js" type="text/javascript"></script>--%>


    <!--master javascript file-->
    <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <!--master javascript file-->

      <!--master style sheet-->
 <%--   <link href="../style_folder/ITRSoftwareAssesseeSelectStyleSheet.css" rel="stylesheet" type="text/css" />--%>
    <!--master style sheet-->

    <%--    <script type="text/javascript">
        $(document).ready(function () {

            $("#hide").click(function () {
                $("#div1").slideToggle();
            });

        });
</script>--%>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnmenu").click(function () {
                $("#divmenu").slideToggle();
            });

        });
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {


            // initialize FlexNav
            $(".flexnav").flexNav();
        });

        
    </script>
    <style type="text/css">
    .hrnew
    {
        
        height:2px;
        background-image:-webkit-linear-gradient(left, rgba(0, 0, 0, 1), rgba(0, 0, 0, 1), rgba(0, 0, 0, 1));
        border-color:Black;
        opacity:1.0;
        margin-top:4px;
    }
   
</style>

<script src="js/jquery-1.10.0.min.js" type="text/javascript"></script>
    <link href="../css/box_style.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.7;
}
.pnlBackGround
{
    background-color:White;
}
    </style>
    <script type="text/javascript">
        function openPop() {
            document.getElementById('btnPop').click();
        }
    </script>
    <script type="text/javascript">
        function CheckPan() {
            var AT = document.getElementById("ddlAssesseeList").value;
            var AP = document.getElementById("txtPAN").value.trim();
            AP = AP.toLowerCase();
            //alert(AP);
            if (document.getElementById('ddITR').value == '-1') {
                document.getElementById('errData').innerHTML = '<b>Select ITR!!</b>';
                document.getElementById('Button3').click();
                return false;
            }
            else {
                if (AP == '') {
                    document.getElementById('errData').innerHTML = '<b>Invalid PAN!!</b>';
                    document.getElementById('Button3').click();
                    return false;
                }
                else {
                    //alert(document.getElementById('ddlAssesseeList').value);
                    if (document.getElementById('ddlAssesseeList').value == '0') {
                        if (/[a-z]{3}[p][a-z]\d{4}[a-z]/i.test(document.getElementById('txtPAN').value.trim()) == false) {
                            document.getElementById('errData').innerHTML = '<b>Invalid PAN!!</b>';
                            document.getElementById('Button3').click();
                            return false;
                        }
                    }
                    else if (document.getElementById('ddlAssesseeList').value == '1') {
                        if (/[a-z]{3}[h][a-z]\d{4}[a-z]/i.test(document.getElementById('txtPAN').value.trim()) == false) {
                            document.getElementById('errData').innerHTML = '<b>Invalid PAN!!</b>';
                            document.getElementById('Button3').click();
                            return false;
                        }
                    }
                    else {
                        document.getElementById('errData').innerHTML = '<b>Select ITR!!</b>';
                        document.getElementById('Button3').click();
                        return false;
                    }
                }
            }
        }

        function pageLoad() {
            document.getElementById('ddITR').focus();
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
        <script src="../Popup/jquery.min.js" type="text/javascript"></script>
    <script src="../Popup/jquery-ui.js" type="text/javascript"></script>
    <link href="../Popup/jquery-ui.css" rel="stylesheet" type="text/css" />
  
</head>
<body onload="P7_ExpMenu()" >
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function ShowPopup(message) {
            $(function ($) {
                $("#msg1").dialog({
                    title: "Save Message",
                    width: 'auto',
                    height: 'auto',
                    minHeight: '0',
                    buttons: {
                        Ok: function () {
                            $(this).dialog('close');// window.location = 'Main.aspx'
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
   <div class="row show-for-small-only hide-for-large hide-for-medium">
        <div class="small-8 columns" style="vertical-align:top; ">
        <a href="Default.aspx">
            <img src="../images/logo2.PNG" style="width:220px; height:auto" />    </a>        
    </div>   
     
    
    <div class="small-12 columns text-right " style="margin-bottom:10px">
      Welcome <span style="font-weight:bold;color:#008CBA;"><asp:Literal ID="ltUser" runat="server">   </asp:Literal></span>
        <a href="logout.aspx">
      [Logout]
      </a>
     </div> 
     </div> 
     <%-------------header ----------------%>

     <div class="row" style="margin-top: -10px;">
        <div class="large-12 columns hide-for-small-only">
            <header:menuheader ID="header1" runat="server" />
        </div>
    </div>
    <br />
    <div class="row" style="margin-top: -30px;">
        <div class="large-12 columns">
            <div class="large-6 columns text-left">
                <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" RootNodeStyle-ForeColor="#009933" NodeStyle-ForeColor="#009933" 
                    NodeStyle-Font-Bold="false" ForeColor="#333333" CurrentNodeStyle-ForeColor="#333333">
                </asp:SiteMapPath>
                <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
            </div>
            <%--<div class="large-6 columns text-right">
                <a href="../Presentation/Main.aspx"><input type="button" value=" Back to Main " class="newbtn" /></a>
            </div>--%>
        </div>
    </div>
    <br />
    <%--nishu 6/4/2015 --%>
  <%--  <div class="row show-for-small-only" style="background-color: #F8F8F8">
        <div class="large-12 columns">
            <img src="../images/logo2.PNG" style="width: 200px; height: 70px" />
            <img src="../images/menu1.JPG" id="btnmenu" />
        </div>
    </div>
    <div class="row show-for-small-only" id="divmenu">
        <div class="large-12 columns">
            <%
                if (Session["ay"] != null)
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
    </div>--%>
    <%--  <div class="row">
     <div class="large-12 columns hide-for-large hide-for-medium">
   <div id="hide" class="panel">Check Assessess Details</div>
     </div>
     </div>
    <div class="row hidden-for-large hidden-for-medium" id="div1" style="display:none">
     <div class="large-12 columns" >
       <sub:submenu ID="Submenu1" runat="server" />
     </div>

     </div>--%>
     <%--Commented by nishu 7/4/2015 --%>
    <%--<div class="row show-for-small-only">
        <div class="large-12 columns">
            <mob2:mobmenu ID="mobmenu" runat="server" />
            <%--<img src="../images/details.JPG" />
        </div>
    </div>--%>
   <%-- <div class="row show-for-medium-only">
        <div class="large-12 columns">
            <mob3:mediummenu ID="medmenu" runat="server" />
        </div>
    </div>--%>
    <div class="row">
    <div class="large-12 columns">
       <span style="border-top-right-radius: 10px;    background-color: white;    background: transparent; outline: none;text-decoration: underline;    margin-bottom: -4px;color:#e14658;font-size:16px;font-family: 'Open Sans','sans-serif';"><b>ADD NEW ASSESSEE</b></span>
                   
    </div>
    </div>
    <div class="row" >
        <%--  <div class="large-3 columns hide-for-small">
        <sub:submenu ID="sub1" runat="server" />
     
        
     
        </div>--%>
        <div class="large-6 columns">
            <asp:MultiView ID="mltView" ActiveViewIndex="0" runat="server">
            
                <asp:View ID="viewList" runat="server">
                  <%--<fieldset style="background-color:White; width:80%">--%>
                
                    <%--<div class="row">
                        <div class="large-12 columns">
                            <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Text="Create Assessee"></asp:Label>
                        </div>
                    </div>
                    <br />--%>
                    <div class="row">
                    <asp:UpdatePanel ID="upd2" runat="server">
                    <ContentTemplate>
                    <fieldset style="border-color:Red" >
                    <legend style=" border-color:Red">Create assessee by filling form</legend>
                    <div class="row" id="div2" runat="server">
                        <div class="large-6 columns " >
                            <asp:Label ID="Label5" runat="server" Text="Select ITR"></asp:Label><span style="color:Red">*</span>
                        </div>
                        <div class="large-6 columns " >
                            <asp:DropDownList ID="ddITR" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddITR_SelectedIndexChanged">
                            <%--<asp:ListItem Text="ITR-1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="ITR-2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="ITR-2A" Value="9"></asp:ListItem>
                            <asp:ListItem Text="ITR-3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="ITR-4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="ITR-4S" Value="8"></asp:ListItem>
                            <asp:ListItem Text="ITR-5" Value="5"></asp:ListItem>
                            <asp:ListItem Text="ITR-6" Value="6"></asp:ListItem>
                            <asp:ListItem Text="ITR-7" Value="7"></asp:ListItem>--%>
                            </asp:DropDownList>

                        </div>
                       
                    </div>
                    <div class="row">
                       <div class="large-6 columns " >
                            <asp:Label ID="Label1" runat="server" Text="Choose Assessee Type" ></asp:Label><span style="color:Red">*</span>
                        </div>
                        <div class="large-6 columns " >
                            <asp:DropDownList ID="ddlAssesseeList" runat="server" Width="200px"  OnSelectedIndexChanged="ddlAssesseeList_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Value="-1">Select Type of Assessee</asp:ListItem>
                               <%-- <asp:ListItem Value="0">Individual</asp:ListItem>
                                <asp:ListItem Value="1">Hindu Undivided Family (HUF)</asp:ListItem>
                                <asp:ListItem Value="2">Partnership Firm</asp:ListItem>
                                <asp:ListItem Value="3">Company</asp:ListItem>
                                <asp:ListItem Value="4">Association of Person (AOP)</asp:ListItem>
                                <asp:ListItem Value="5">Body of Individuals (BOI)</asp:ListItem>
                                <asp:ListItem Value="6">Co-Operative Society</asp:ListItem>
                                <asp:ListItem Value="7">Co-Operative Bank</asp:ListItem>
                                <asp:ListItem Value="8">Local Authority</asp:ListItem>--%>
                            </asp:DropDownList>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAssesseeList"
                                ErrorMessage="Select Type" Display="Dynamic" InitialValue="-1" ValidationGroup="gg1"></asp:RequiredFieldValidator>
                        </div>
                        </div>

                          <div class="row" id="divPAN" runat="server">
                        <div class="large-6 columns " >
                            <asp:Label ID="Label2" runat="server" Text="Enter Assessee PAN"></asp:Label><span style="color:Red">*</span>
                        </div>
                        <div class="large-6 columns " >
                            <asp:TextBox ID="txtPAN" required oninvalid="this.setCustomValidity('Enter Assessee PAN')" runat="server" MaxLength="10" placeholder="Enter Assessee PAN"  Style="text-transform: uppercase;"
                                Width="200px" onchange="setUpper(this);" ></asp:TextBox><div id="divPANErr" style="color:Red" ></div>
                                <% if (Session["UploadForm16Details"] != null)
                                   { %>
                                <asp:Label ID="lblPanValidation" runat="server" Text="This Pan has come from your Uploaded PDF" ForeColor="Red"></asp:Label>
                                <%} %>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPAN"
                                ErrorMessage="Enter PAN" Display="Dynamic" ValidationGroup="gg1"></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid PAN"
                                ControlToValidate="txtPAN" ValidationExpression="[A-Za-z]{3}[p|P|c|C|h|H|f|F|a|A|t|T|b|B|l|L|j|J|g|G]{1}[A-Za-z]{1}[0-9]{4}[A-Za-z]{1}" ValidationGroup="gg1"></asp:RegularExpressionValidator>--%>
                        </div>
                       
                    </div>
                    <div class="row" id="div1" runat="server">
                        <div class="large-6 columns " >
                            <asp:Label ID="Label4" runat="server" Text="Select AY"></asp:Label><span style="color:Red">*</span>
                        </div>
                        <div class="large-6 columns " >
                            <asp:DropDownList ID="ddAY" runat="server" Width="200px">
                            <asp:ListItem Text="2016-2017" Value="2016-2017"></asp:ListItem>
                            <asp:ListItem Text="2015-2016" Value="2015-2016"></asp:ListItem>
                            <asp:ListItem Text="2014-2015" Value="2014-2015"></asp:ListItem>
                            <%--<asp:ListItem Text="2013-2014" Value="2013-2014"></asp:ListItem>--%>
                            </asp:DropDownList>

                        </div>                       
                    </div>                      

                    <div id="divST" runat="server" visible="false" class="row">
                        <div class="large-6 columns">
                            <asp:Label ID="Label3" runat="server" Text="STC Code Number"></asp:Label>
                        </div>
                        <div class="large-6 columns">
                            <asp:TextBox ID="txtSTCNo" runat="server" MaxLength="15" Style="text-transform: uppercase;"
                                Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPAN"
                                ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid STC Code"
                                ControlToValidate="txtSTCNo" ValidationExpression="/[0-9a-zA-Z]{6,}/"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                      
                    <div class="row">
                        <div class="large-6 columns">
                        <asp:Literal ID="ltMsg" runat="server"  ></asp:Literal>
                            <%--<asp:Label ID="lblMsg" runat="server" Text="We couldn't find your PAN Details" Font-Size="Large" ForeColor="Red" style="text-decoration:blink;">
                        </asp:Label>
                            <asp:Label ID="ltMsg" runat="server" Text="We couldn't find your PAN Details" Visible="false"
                                Font-Size="Large" ForeColor="Red"></asp:Label>
                            <%----%>
                        </div>
                        <div class="large-6 columns">
                        </div>
                      <%-- <br />--%>
                      
                    </div>
                      <div class="row">
                        <div class="large-6 columns">
                        </div>
                        <div class="large-6 columns text-right">
                        <asp:Button ID="btnEnterSal" runat="server" Font-Bold="true" Text="Add" height="50px" Width="109px" OnClick="btnEnter_Click" OnClientClick="return CheckPan();"
                                class="button" ValidationGroup="gg1" />

                            <%--<asp:Button ID="btnEnter" runat="server" Font-Bold="true" Text="Enter" height="50px" Width="109px" OnClick="btnEnter_Click"
                                class="radius button" ValidationGroup="gg1" OnClientClick="javascript:return CheckPan();"  />--%>
                                
                                </div>
                    </div>      
                    </fieldset>
                 
                    </ContentTemplate>
                    </asp:UpdatePanel>
                  
                
                    </div>
                  
                    
                   <%-- <div class="row">
                <div class="large-6 columns">
                <asp:Label ID="Label3" runat="server" Text="Section under which return is being filed"></asp:Label>
                </div>
                <div class="large-6 columns">
                 <asp:DropDownList ID="ddlWhichSection" runat="server" Width="296px">
                                                        <asp:ListItem>Voluntarily before the due date</asp:ListItem>
                                                        <asp:ListItem>voluntarily after the due date</asp:ListItem>
                                                        <asp:ListItem>In response to notice u/s 142(1)</asp:ListItem>
                                                        <asp:ListItem>in response to notice u/s 148</asp:ListItem>
                                                        <asp:ListItem>in response to notice u/s 153 A</asp:ListItem>
                                                    </asp:DropDownList>
                </div>
                </div>
                 <div class="row">
                <div class="large-6 columns">
               <asp:Label ID="Label4" runat="server" Text="Return of Income"></asp:Label>
                </div>
                <div class="large-6 columns">
                <asp:DropDownList ID="ddlROI" runat="server" Width="250px">
                                                        <asp:ListItem>Return of income u/s 139</asp:ListItem>
                                                        <asp:ListItem>Return of income u/s 142</asp:ListItem>
                                                        <asp:ListItem>Return of income u/s 148</asp:ListItem>
                                                    </asp:DropDownList>
                </div>
                </div>
                <div class="row">
                <div class="large-6 columns">
                 <asp:Label ID="Label5" runat="server" Text="Return of FBT"></asp:Label>
                </div>
                <div class="large-6 columns">
                 <asp:DropDownList ID="ddlROFB" runat="server" Width="250px">
                                                        <asp:ListItem>Return of Fringe Benefit 115 WD(1)</asp:ListItem>
                                                        <asp:ListItem>Return of Fringe Benefit 115WD(2)</asp:ListItem>
                                                        <asp:ListItem>Return of Fringe Benefit 115 WH</asp:ListItem>
                                                    </asp:DropDownList>
                </div>
                </div>
                   <div class="row">
                <div class="large-6 columns">
                 <asp:CheckBox ID="chkFirstReturn" runat="server" Text="Is this your first return?" />
                </div>
                <div class="large-6 columns"></div>
                </div>
                   <div class="row">
                <div class="large-6 columns">
                <asp:Label ID="Label6" runat="server" Text="Return Type"></asp:Label>
                </div>
                <div class="large-6 columns">
                <asp:DropDownList ID="ddlReturnType" runat="server">
                                                        <asp:ListItem>Origional</asp:ListItem>
                                                        <asp:ListItem>Revised</asp:ListItem>
                                                    </asp:DropDownList>
                </div>
                </div>
                   <div class="row">
                <div class="large-6 columns">
                 <asp:Label ID="lblRecieptNO" runat="server" Text="Reciept No."></asp:Label>
                </div>
                <div class="large-6 columns">
                 <asp:TextBox ID="txtRecieptNo" runat="server"></asp:TextBox>
                </div>
                </div>--%>
                  
                 <%--</fieldset>--%>
                </asp:View>
           
            </asp:MultiView>
        </div>
        
        <div class="large-6 columns">
        <fieldset style="border-color:Red;  " >
        <legend style=" border-color:Red">Import(XML)</legend>
     <%--   <span style="border-top-right-radius: 10px;    background-color: white;    background: transparent; outline: none;text-decoration: underline;    margin-bottom: -4px;color:rgb(236, 88, 58);font-size:16px;font-family: 'Open Sans','sans-serif';"><b>Import XML</b></span>--%>
             <%-- <hr class="hrnew" />--%>
            <div class="row">
              
                    <div class="large-10 columns">
                        <p>
                            Create Assessee by importing ITR XML File</p>
                    </div>
                    <div class="large-2 columns">
                    </div>
                </div>
                <div class="row">
                    <div class="large-12 columns">
                        <p>
                            <span style="font-size: 13px;"><b style="color: Red"><u>Note</u>:&nbsp;Only for ITR-1 and ITR-4S w.e.f. Assessment Year 2014-2015.</b></span>
                        </p>
                    </div>                    
                </div>
             <div class="row">
                <div class="large-12 columns">
                </div>
                </div>
                  <div class="row">
                <div class="large-12 columns">
                </div>
                </div>
                  <div class="row">
                <div class="large-12 columns">
                </div>
                </div>
                  <br />
                <br />
                <br />
                    <br />
                <br />
       
                <div class="row">
                <div class="large-6 columns">
                        </div>
                    <div class="large-6 columns text-right">
                        <input type="button" value="Import" font-bold="true" class="button " style="height:50px;
                            font-weight: bold; width: 109px;" onclick="openPop();" />
                    </div>
                </div>
              
        
      <%--  <table style="border-bottom:0px; border-top:0px; border-right:0px; border:0px ">
      
        <tr>
        <td> 
          
          <%--<asp:Button ID="btnImportXML" runat="server" Text="Import" class="button radius" OnClientClick="openPop();" />--%></td>
      <%--  <td></td>
        </tr>
        <tr>
        <td></td>
        <td></td>
        </tr>
        </table>--%>
        </fieldset>
        
        </div>
    </div>
    <br />
    <br />
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
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlPopup" TargetControlID="btnPop" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
    </ajaxToolkit:ModalPopupExtender>

    <%-- PAN Error Popup --%>
     <asp:Panel ID="pnlPANErr" runat="server">
     <div class="login-wrap" style="margin-top: 30px;height:140px; background-color:White;" >
     <asp:Panel ID="Panel2" runat="server" Width="400px">
                <%--<span style="color: Black; font-family: 'Open Sans','sans-serif'; margin-left: -72px;
                    font-size: xx-large; font-size: 15px; font-weight: bold; text-transform: uppercase;
                    color: #ef5845; text-decoration: underline">
                    Invalid PAN !!
                </span>--%>
                <div class="form large-8 columns text-center" style="text-align:center;">
                    <span id="errData" style="color:#e14658"></span>
                    <br /><br />
                    <center> <asp:Button ID="Button2" runat="server" Font-Bold="true" Text="Cancel" CssClass="radius button"
                     Style="border-radius: 4px" />
                     </center>
                </div>
            </asp:Panel>
     </div>
    </asp:Panel>

    <asp:Button ID="Button3" runat="server" Text="popup" style="display:none;" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="pnlPANErr" TargetControlID="Button3" BackgroundCssClass="modalBackground" CancelControlID="Button2">
    </ajaxToolkit:ModalPopupExtender>
    <br />
    <br />


    <div class="row">
        <div class="large-12 columns">
            <hr />  
              <p>© 2016 Vatas Infotech Pvt.Ltd.</p>
        </div>
  </div> 
   
   <%-- <div class="show-for-large-only">
        <menu:side ID="Sidemenu" runat="server" />
    </div>--%>
    <div id="msg1" style="height:20px">
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
