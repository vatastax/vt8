<%@ Page Language="C#" AutoEventWireup="true" CodeFile="STaxMaster.aspx.cs" Inherits="Presentation_STaxMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
<%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../mobilemenu2.ascx" TagPrefix="mob1" TagName="menu1" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../Presentation/MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="../menu_header.ascx" TagName="menuheader" TagPrefix="header" %>
<!DOCTYPE html >
<html lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta name="author" content="" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Control Panel</title>
    <link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/menu.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../js/tab.js" type="text/javascript"></script>
    <%--<script src="../js/Modernizer.min.js" type="text/javascript"></script>--%>
    <link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="../foundation-5.5.0/js/foundation.min.js" type="text/javascript"></script>
    <%--<script src="../css/jquery-1.4.2.min.js" type="text/javascript"></script>--%>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <%--<link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />--%>
   <%-- <link href="../ITRStylesheet/styles/menu.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnmenu").click(function () {
                $("#divmenu").slideToggle();
            });

        });
    </script>
    <%--   <script type="text/javascript">
       $(function () {
           // Convert to UpperCase/Title Case
       

               $('input').keyup(function () {
                   this.value = this.value.substr(0, 1).toUpperCase() + this.value.substr(1);
                   
              

               });
       });
</script>--%>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnInsert").click(function () {
                if (($("#txtSTD").val().length != 0 || $("#txtPhone").val().length) != 0) {
                    if (($("#txtSTD").val().length + $("#txtPhone").val().length) != 10) {

                        alert("Length of std and phone should be 10 digits");
                        var len = ("txtSTD").val().length + ("txtPhone").val().length;
                        alert(len);

                    }
                    else {

                    }
                }
            });
        });

      
    </script>
    <%-- <script type="text/javascript">
        $(document).ready(function () {

            $("#hide").click(function () {
                $("#div1").slideToggle();
            });

        });
    </script>--%>
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 00px;
            margin-bottom: 00px;
        }
        a
        {
            text-decoration: none;
            color: #215DC6;
        }
        
        a:hover
        {
            text-decoration: none;
            color: #40ACF4;
        }
        .style1
        {
            color: #215DC6;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: 12px;
        }
        input[type=text]
        {
            padding: 4px;
        }
    </style>
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

        function setNaming(id) {
            try {
                document.getElementById('txtNameRep').value = document.getElementById('txtFirstName').value + ' ' + document.getElementById('txtMiddleName').value + ' ' + document.getElementById('txtLastName').value
                document.getElementById('txtFNameAu').value = document.getElementById('txtFatherName').value;
            }
            catch (e) { alert(e); }
        }

        function setVals() {
            document.getElementById('RegularExpressionValidator2').disabled = 'true';
        }

        function SelectSignatory() {
            try {
                if (document.getElementById('rdoSelf').checked) {
                    document.getElementById('txtNameRep').disabled = 'true';
                    document.getElementById('txtFNameAu').disabled = 'true';
                    document.getElementById('txtPANRep').disabled = 'true';
                    document.getElementById('txtDesignationRep').disabled = 'true';
                    document.getElementById('RequiredFieldValidator11').disabled = 'true';
                }
                else {
                    document.getElementById('txtNameRep').removeAttribute('disabled');
                    document.getElementById('txtFNameAu').removeAttribute('disabled');
                    document.getElementById('txtPANRep').removeAttribute('disabled');
                    document.getElementById('txtDesignationRep').removeAttribute('disabled');
                    document.getElementById('RequiredFieldValidator11').removeAttribute('disabled');
                }
            }
            catch (e) { alert(e); }
        }

        function showLTU(id) {
            if (id.value == 'Yes')
                document.getElementById('row_LTU').style.display = 'block';
            else
                document.getElementById('row_LTU').style.display = 'none';
        }
    </script>
    <%-- <script src="../lib/jquery-1.8.3.min.js" type="text/javascript" charset="utf-8"></script>
<script src="../lib/jquery.maskedinput.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $.mask.definitions['~'] = "[+-]";
        $("#txtDOB").mask("99/99/9999", { completed: function () { } });
        $("#phone").mask("(999) 999-9999");
        $("#phoneExt").mask("(999) 999-9999? x99999");
        $("#iphone").mask("+33 999 999 999");
        $("#tin").mask("99-9999999");
        $("#ssn").mask("999-99-9999");
        $("#product").mask("a*-999-a999", { placeholder: " " });
        $("#eyescript").mask("~9.99 ~9.99 999");
        $("#po").mask("PO: aaa-999-***");
        $("#pct").mask("99%");

        $("input").blur(function () {
            $("#info").html("Unmasked value: " + $(this).mask());
        }).dblclick(function () {
            $(this).unmask();
        });
    });
	
</script>
    --%>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#olditr").click(function () {
                $("#assdet1").hide();
                $("#detolditr").slideToggle();
            });

            $("#assdet").click(function () {
                $("#detolditr").hide();
                $("#assdet1").slideToggle();
            });
        });

        function showForm() {
            alert('sf');
            setTimeout(clickIt, 1200);
        }
        function clickIt() {
            $("#assdet").click();
            return false;
        }
    </script>
    <script type="text/javascript">
        function setForm(id) {
            alert(id.value);
        }
    </script>
</head>
<body onload="P7_ExpMenu()" class="no-js">
    <form id="form1" runat="server" role="form">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 hide-for-small-only">
               <%-- <%
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
                %>--%>
                  <header:menuheader ID="header1" runat="server" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="large-12 columns">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="calibri" ForeColor="#333333">
            </asp:SiteMapPath>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
    </div>
    <br />
    <div class="row show-for-small-only" style="background-color: #F8F8F8">
        <div class="large-12 columns">
            <img src="../images/securedownload.jpg" style="width: 200px; height: 70px" />
            <img src="../images/menu1.JPG" id="btnmenu" />
        </div>
    </div>
    <div class="row hidden-for-large hidden-for-medium" id="divmenu" style="display: none">
        <div class="large-12 columns">
            <%
                if (Session["ay"] != null)
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
    <div class="row show-for-small-only">
        <div class="large-12 columns">
            <mob2:mobmenu ID="mobmenu" runat="server" />
            <%--<img src="../images/details.JPG" />--%>
        </div>
    </div>
    <div class="row show-for-medium-only">
        <div class="large-12 columns">
            <mob3:mediummenu ID="medmenu" runat="server" />
        </div>
    </div>
    <div class="row hidden-for-large hidden-for-medium" id="div1" style="display: none">
        <div class="large-12 columns">
            <sub:submenu ID="Submenu1" runat="server" />
        </div>
    </div>
    <%--  <div class="row">
        <div class="large-12 columns hide-for-large hide-for-medium">
            <div id="hide" class="button">
                Check Assessess Details</div>
        </div>
    </div>--%>
    <%-- <div class="row hidden-for-large hidden-for-medium" id="div1" style="display: none">
        <div class="large-12 columns">
            <sub:submenu ID="Submenu2" runat="server" />
        </div>
    </div>--%>
    <div class="container-fluid">
        <div class="row">
            <%-- <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3 hide-for-small">
                <sub:submenu ID="Submenu1" runat="server" />
            </div>--%>
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
                        <div class="row  bg-primary hide-for-small-only">
                            <div class="large-12 columns">
                                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Assessee Details"></asp:Label>&nbsp;
                                <asp:Label ID="lblAssesseeType" runat="server" Text="Label" Width="66px"></asp:Label></div>
                            <%--  <div class="large-6 columns">
                                <asp:Label ID="Label3" runat="server" Text="Pan Number" Font-Bold="true"></asp:Label>&nbsp;
                                <asp:Label ID="lblPan" runat="server" Text="Label" Style="text-transform: uppercase;"></asp:Label>
                            </div>--%>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <div class="container-fluid">
                    <ul class="nav nav-tabs" role="tablist" id="mytab">
                        <li class="active"><a href="#SectionA" data-toggle="tab">Personal Details</a></li>
                        <li><a href="#sectionB" data-toggle="tab" click="show();">Address</a></li>
                        <%--<li><a href="#sectionc" data-toggle="tab">Bank Details</a></li>--%>
                        <li><a href="#sectione" data-toggle="tab">Authorised Signatory</a></li>
                        <li><a href="#sectiond" data-toggle="tab">Other Information</a></li>
                    </ul>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getStates"
                        TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getStates"
                        TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
                </div>
                <br />
                <div class="tab-content">
                    <div id="SectionA" class="tab-pane fade in active">
                        <%--<div class="row">
                       
                      
                            <div class="large-4 columns">
                                <asp:Label ID="Label4" runat="server" Text="Salute"></asp:Label><span style=" color:red">*</span>
                            </div>
                            <div class="large-4 columns">
                                <asp:DropDownList ID="ddlSalute" runat="server" Class="form-control">
                                    <asp:ListItem>Mr.</asp:ListItem>
                                    <asp:ListItem>Mrs.</asp:ListItem>
                                    <asp:ListItem>Miss.</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                              <div class="large-4 columns"></div>
                            </div>--%>
                        <br />
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="lblFirstName" runat="server" Text="Name of the Assessee"></asp:Label>
                            </div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtLastName" runat="server" class="form-control" placeholder="Assessee Name"
                                    MaxLength="25"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFirstName"
                                    ErrorMessage="Enter First Name (Personal Details)" Display="None"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="Label3" runat="server" Text="Service Tax Registration No."></asp:Label>
                            </div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtSTGN" runat="server" class="form-control" placeholder="Service Tax Registration No."
                                    MaxLength="25"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFirstName"
                                    ErrorMessage="Enter First Name (Personal Details)" Display="None"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="Label15" runat="server" Text="PAN"></asp:Label></div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtPANRep" runat="server" class="form-control" placeholder="PAN"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="txtPANRepvalid" runat="server" ControlToValidate="txtPANRep"
                                    ErrorMessage="Please Fill Correct PAN" ValidationExpression="^[\w]{3}(p|P|c|C|h|H|f|F|a|A|t|T|b|B|l|L|j|J|g|G)[\w][\d]{4}[\w]$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="Label4" runat="server" Text="Is Large Tax Payer?"></asp:Label>
                            </div>
                            <div class="large-4 columns">
                                <asp:DropDownList ID="ddIsTaxPayer" runat="server" onchange="showLTU(this);">
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <div id="row_LTU" class="row" style="display: none;">
                            <div class="large-4 columns">
                                <asp:Label ID="Label5" runat="server" Text="Name of Large Taxpayer Unit"></asp:Label>
                            </div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtTaxPayerUnit" runat="server" Width="313px"></asp:TextBox>
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                    </div>
                    <div id="sectionB" class="tab-pane fade">
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label2" runat="server" Text="Flat/Door/Building"></asp:Label><span
                                    style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtFlat" runat="server" placeholder="Flat/Door/Building" Width="231px"
                                    Height="34px" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtFlat" ErrorMessage="Enter Flat/Door/Block No. (Address Tab)"
                                    Display="None"></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-3 columns">
                                <asp:Label ID="Label18" runat="server" Text="Name of Premises"></asp:Label></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtPremises" runat="server" Width="231px" Height="34px" placeholder="Premises"
                                    MaxLength="50"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label19" runat="server" Text="Road/Street"></asp:Label></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtRoad" runat="server" Width="231px" Height="34px" placeholder="Road/Street"
                                    MaxLength="50"></asp:TextBox></div>
                            <div class="large-3 columns">
                                <asp:Label ID="Label25" runat="server" Text="Area/Locality"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtArea" runat="server" class="form-control" placeholder="Area/Locality"
                                    MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtArea" ErrorMessage="Enter Area (Address Tab)" Display="None"></asp:RequiredFieldValidator></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label30" runat="server" Text="Town/City/District"></asp:Label><span
                                    style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtCity" runat="server" class="form-control" placeholder="City"
                                    MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator6" runat="server"
                                    ControlToValidate="txtCity" ErrorMessage="Enter City (Address Tab)" Display="None"></asp:RequiredFieldValidator></div>
                            <div class="large-3 columns">
                                <asp:Label ID="Label31" runat="server" Text="State"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:DropDownList ID="ddlState" runat="server" class="form-control" DataSourceID="ObjectDataSource1"
                                    DataTextField="StateName" DataValueField="StateCode">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label40" runat="server" Text="Country"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:DropDownList ID="ddlCountry" runat="server" class="form-control" DataTextField="Country_Name"
                                    DataValueField="CountryId">
                                </asp:DropDownList>
                            </div>
                            <div class="large-3 columns">
                                <asp:Label ID="Label32" runat="server" Text="Pin Code"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtPIN" runat="server" class="form-control" placeholder="Pin Code"
                                    MaxLength="6"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator7" runat="server"
                                    ControlToValidate="txtPIN" ErrorMessage="Enter PIN (Address Tab)" Display="None"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid PIN"
                                    ControlToValidate="txtPIN" ValidationExpression="[1-9]{1}[0-9]{5}"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label14" runat="server" Text="STD Code"></asp:Label></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtSTD" runat="server" class="form-control" placeholder="STD Code"
                                    MaxLength="5"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    TargetControlID="txtSTD" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="First digit should not be zero"
                                    ControlToValidate="txtSTD" ValidationExpression="[1-9]{1}[0-9]{1,5}"></asp:RegularExpressionValidator>
                            </div>
                            <div class="large-3 columns">
                                <asp:Label ID="Label33" runat="server" Text="Phone"></asp:Label></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="Phone"
                                    MaxLength="10"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    TargetControlID="txtPhone" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label38" runat="server" Text="Mobile No.1"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtMobile1" runat="server" class="form-control" placeholder="Mobile Number1"
                                    MaxLength="10" onchange="setVals();"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please enter valid Mobile1"
                                    ControlToValidate="txtMobile1" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator8" runat="server"
                                    ControlToValidate="txtMobile1" ErrorMessage="Enter Mobile1 (Address Tab)" Display="None"></asp:RequiredFieldValidator>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    TargetControlID="txtMobile1" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                            <div class="large-3 columns">
                                <asp:Label ID="Label39" runat="server" Text="Mobile No.2"></asp:Label></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtMobile2" runat="server" class="form-control" placeholder="Mobile Number2"
                                    MaxLength="10"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please enter valid Mobile2"
                                    ControlToValidate="txtMobile2" ValidationExpression="[1-9]{1}[0-9]{5}"></asp:RegularExpressionValidator>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    TargetControlID="txtMobile2" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label12" runat="server" Text="Email Address"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email Address"
                                    MaxLength="125" Style="text-transform: lowercase"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator5" runat="server"
                                    ControlToValidate="txtEmail" ErrorMessage="Enter Email-ID (Address Tab)" Display="None"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="txtEmalValidation" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="Incorrect Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </div>
                            <div class="large-3 columns">
                            </div>
                            <div class="large-3 columns">
                            </div>
                        </div>
                    </div>
                    <div id="sectionc" class="tab-pane fade">
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="lblBankName" runat="server" Text="Name of Bank"></asp:Label>
                            </div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtBankName" runat="server" class="form-control" placeholder="Name of Bank"
                                    MaxLength="125"></asp:TextBox></div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="lblBranchAddress" runat="server" Text="Address of Branch"></asp:Label>
                            </div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtBranchAddress" runat="server" class="form-control" placeholder="Address of Branch"
                                    MaxLength="125"></asp:TextBox></div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number"></asp:Label><span
                                    style="color: Red">*</span>
                            </div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtAccountNumber" runat="server" class="form-control" placeholder="Account Number"
                                    MaxLength="20"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAccountNumber"
                                    ErrorMessage="Enter Account No (Bank Tab)" Display="None">
                                </asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="txtAccountNumberValid" runat="server" ControlToValidate="txtAccountNumber"
                                    ValidationExpression="[a-zA-Z0-9]([/-]?(((\d*[1-9]\d*)*[a-zA-Z])|(\d*[1-9]\d*[a-zA-Z]*))+)*[0-9]*"
                                    ErrorMessage="Invalid Account Number"></asp:RegularExpressionValidator>
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="lblAccountType" runat="server" Text="Account Type"></asp:Label><span
                                    style="color: Red">*</span>
                            </div>
                            <div class="large-4 columns">
                                <asp:DropDownList ID="ddlAccountType" runat="server" class="form-control">
                                    <asp:ListItem>Savings</asp:ListItem>
                                    <asp:ListItem>Current</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="lblMICR" runat="server" Text="IFSC Code"></asp:Label>&nbsp;<a href="http://www.bankifsccode.com"
                                    target="_blank" style="font-size: 13px">(Know your IFSC Code)</a><span style="color: Red">*</span>
                            </div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtMICR" runat="server" class="form-control" Placeholder="IFSC Code"
                                    MaxLength="11" Style="text-transform: uppercase"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ValidationGroup="gg1" ID="req11" runat="server" ControlToValidate="txtMICR"
                                    ErrorMessage="Enter IFSC Code (Bank Tab)" Display="None">
                                </asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="txtMICRValid" runat="server" ControlToValidate="txtMICR"
                                    ErrorMessage="Incorrect IFSC Code" ValidationExpression="[A-Z]{4}[0][A-Z0-9]{6}"></asp:RegularExpressionValidator>
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="lblESC" runat="server" Text="ECS (Y/N)"></asp:Label>
                            </div>
                            <div class="large-4 columns">
                                <asp:DropDownList ID="ddlESC" runat="server" class="form-control">
                                    <asp:ListItem Selected="True">Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="lblRefund" runat="server" Text="Refund Method"></asp:Label>
                            </div>
                            <div class="large-4 columns">
                                <asp:DropDownList ID="ddlRefund" runat="server" class="form-control">
                                    <asp:ListItem>By Cheque</asp:ListItem>
                                    <asp:ListItem Selected="True">Direct Deposit</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                    </div>
                    <div id="sectiond" class="tab-pane fade">
                        <%-- <asp:UpdatePanel ID="upd2" runat="server">
                            <ContentTemplate>--%>
                        <div class="row" id="olditr">
                            <div class=" large-12 columns panel" style="padding: 10px; font-size: 15px; font-weight: bold">
                                <a href="#">Select Service Type</a>
                            </div>
                        </div>
                        <div class="row" style="overflow: hidden" id="detolditr">
                            <br />
                            <%--   <div class="row">
                            <div class="large-6 columns">
                                No. Of Dependents:</div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtNoOfDependents" runat="server" class="form-control">
                                </asp:TextBox></div>
                        </div>--%>
                            <asp:UpdatePanel ID="upd1" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="large-12 columns">
                                            <asp:GridView ID="gvServices" CssClass="large-12 columns" runat="server" CellPadding="0"
                                                CellSpacing="0" BorderWidth="0" GridLines="None" ShowHeader="false" ShowFooter="false"
                                                AutoGenerateColumns="false" OnRowDataBound="gvServices_RowDataBound" 
                                                onrowcommand="gvServices_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="row">
                                                                <div class="large-8 columns">
                                                                    <asp:DropDownList ID="ddService" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddService_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class=" large-1 columns">
                                                                    <asp:Button ID="btnViewGRow" runat="server" Text="VIEW" CommandName="viw" CommandArgument='<%# Container.DataItemIndex %>' formnovalidate  
                                                                        CssClass="radius button" />
                                                                </div>
                                                                <div class=" large-1 columns">
                                                                    <asp:Button ID="btnAddGRow" runat="server" Text="ADD" formnovalidate OnClick="btnAddGRow_Click"
                                                                        CssClass="radius button" />
                                                                </div>
                                                                <div class=" large-2 columns ">
                                                                    <asp:Button ID="btnRemGRow" runat="server" Text="REMOVE" formnovalidate CssClass="radius button"
                                                                        OnClick="btnRemGRow_Click" />
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="assdet">
                            <div class=" large-12 columns panel" style="padding: 10px; font-size: 15px; font-weight: bold">
                                <a href="#">Fill The Form</a>
                            </div>
                        </div>
                        <div id="assdet1" style="display: none" runat="server">
                            <asp:UpdatePanel ID="upd3" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="large-8 columns">
                                            <asp:Label ID="lblServTitle" runat="server" Text="Selected Service" Font-Bold="true"
                                                Font-Size="Larger"></asp:Label>
                                        </div>
                                        <div class="large-12 columns">
                                            <div class="large-3 columns">
                                                <b>Service Provider</b>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:DropDownList ID="ddSP" runat="server">
                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="large-3 columns">
                                                <b>Service Receiver</b>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:DropDownList ID="DropDownList1" runat="server">
                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="large-12 columns">
                                            <div class="large-3 columns">
                                                <b>Partial Reverse Charge</b>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:DropDownList ID="DropDownList2" runat="server">
                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="large-3 columns">
                                                <b>Partial Reverse Charge</b>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:DropDownList ID="DropDownList3" runat="server">
                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="large-12 columns">
                                            <div class="large-3 columns">
                                                <b>%age of Service Tax Payable</b>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:TextBox ID="txtSTaxPayable" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="large-3 columns">
                                                <b>%age of Service Tax Payable</b>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="large-12 columns">
                                            &nbsp;
                                        </div>
                                        <div class="large-12 columns">
                                            <div class="large-2 columns">
                                                &nbsp;&nbsp;
                                            </div>
                                            <div class="large-6 columns">
                                                <b>Is there any benefit of exemptions notification availed?</b>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:DropDownList ID="DropDownList4" runat="server">
                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="large-1 columns">
                                                &nbsp;&nbsp;
                                            </div>
                                        </div>
                                        <div class="large-12 columns">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="large-12 columns">
                                                            <asp:GridView ID="gvExempNotifications" CssClass="large-12 columns" runat="server" CellPadding="0"
                                                                CellSpacing="0" BorderWidth="0" GridLines="None" ShowFooter="false"
                                                                AutoGenerateColumns="false" OnRowDataBound="gvExempNotifications_RowDataBound" Visible="false">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                     <div class="row">
                                                                                <div class="large-4 columns">
                                                                                    Notification No
                                                                                </div>
                                                                                <div class="large-4 columns">
                                                                                   SI. NO.
                                                                                </div>
                                                                                <div class="large-4 columns">&nbsp;
                                                                                </div>
                                                                            </div>
                                                                    </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="row">
                                                                                <div class="large-4 columns">
                                                                                    <asp:DropDownList ID="ddService_NN" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddService_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div class="large-4 columns">
                                                                                    <asp:DropDownList ID="dd_SIN" runat="server" AutoPostBack="true">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                
                                                                 <div class=" large-1 columns">
                                                                 &nbsp;
                                                                </div>
                                                                <div class=" large-1 columns">
                                                                    <asp:Button ID="btnAddGRow2" runat="server" Text="ADD" formnovalidate OnClick="btnAddGRow2_Click"
                                                                        CssClass="radius button" />
                                                                </div>
                                                                <div class=" large-2 columns ">
                                                                    <asp:Button ID="btnRemGRow2" runat="server" Text="REMOVE" formnovalidate CssClass="radius button"
                                                                        OnClick="btnRemGRow2_Click" />
                                                                </div>
                                                               
                                                                            </div>
                                                                            
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="large-12 columns">
                                            <div class="large-2 columns">
                                                &nbsp;&nbsp;
                                            </div>
                                            <div class="large-6 columns">
                                                <b>Is there any abatement claimed from value of services?</b>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:DropDownList ID="DropDownList5" runat="server">
                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="large-1 columns">
                                                &nbsp;&nbsp;
                                            </div>
                                        </div>
                                        <div class="large-12 columns">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="large-12 columns">
                                                            <asp:GridView ID="gvAbtclaimed" CssClass="large-12 columns" runat="server" CellPadding="0"
                                                                CellSpacing="0" BorderWidth="0" GridLines="None" ShowFooter="false"
                                                                AutoGenerateColumns="false" OnRowDataBound="gvAbtclaimed_RowDataBound" Visible="false">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                     <div class="row">
                                                                                <div class="large-4 columns">
                                                                                    Notification No
                                                                                </div>
                                                                                <div class="large-4 columns">
                                                                                   SI. NO.
                                                                                </div>
                                                                                 <div class="large-4 columns">
                                                                                   &nbsp;
                                                                                </div>
                                                                            </div>
                                                                    </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="row">
                                                                                <div class="large-4 columns">
                                                                                    <asp:DropDownList ID="ddService_NN" runat="server" >
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div class="large-4 columns">
                                                                                    <asp:DropDownList ID="dd_SIN" runat="server" AutoPostBack="true">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                             <div class=" large-1 columns">
                                                                             &nbsp;
                                                                            </div>
                                                                            <div class=" large-1 columns">
                                                                                <asp:Button ID="btnAddGRow" runat="server" Text="ADD" formnovalidate OnClick="btnAddGRow3_Click"
                                                                                    CssClass="radius button" />
                                                                            </div>
                                                                            <div class=" large-2 columns ">
                                                                                <asp:Button ID="btnRemGRow3" runat="server" Text="REMOVE" formnovalidate CssClass="radius button"
                                                                                    OnClick="btnRemGRow3_Click" />
                                                                            </div>
                                                               
                                                                            </div>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="large-12 columns">
                                            <div class="large-2 columns">
                                                &nbsp;&nbsp;
                                            </div>
                                            <div class="large-6 columns">
                                                <b>Whether provisionally assessed?</b>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:DropDownList ID="DropDownList6" runat="server">
                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="large-1 columns">
                                                &nbsp;&nbsp;
                                            </div>
                                        </div>
                                       <div class="large-12 columns">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="large-12 columns">
                                                            <asp:GridView ID="gvProvisional" CssClass="large-12 columns" runat="server" CellPadding="0"
                                                                CellSpacing="0" BorderWidth="0" GridLines="None" ShowFooter="false" Visible="false"
                                                                AutoGenerateColumns="false">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                    <div class="row">
                                                                                <div class="large-8 columns">
                                                                                   Provisional Assessment Order No
                                                                                </div>
                                                                                <div class="large-4 columns">
                                                                                   Date
                                                                                </div>
                                                                            </div>                                                                    
                                                                    </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="row">
                                                                                <div class="large-8 columns">
                                                                                   <asp:TextBox ID="txtNotificationNo" runat="server" Width="100%"></asp:TextBox>
                                                                                </div>
                                                                                <div class="large-4 columns">
                                                                                   <asp:TextBox ID="txt" runat="server" Width="100%"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                    <div id="sectione" class="tab-pane fade">
                        <br />
                        <div class="row" id="pnlRepresentative">
                            <div class="large-4 columns">
                                <asp:Label ID="Label6" runat="server" Text="Name"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtNameRep" runat="server" Class="form-control" required placeholder="Name"
                                    MaxLength="125"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RQ1" runat="server" ControlToValidate="txtNameRep"
                                    ErrorMessage="Please fill your name in Authorised Signatory"></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <div class="row" id="pnlAuthorised">
                            <div class="large-4 columns">
                                <asp:Label ID="Label26" runat="server" Text="Father Name"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtFNameAu" runat="server" class="form-control" Required placeholder="Father Name"
                                    MaxLength="125"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtFNameAu" ErrorMessage="Please fill father name in Authorised Signatory"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="Label16" runat="server" Text="Designation"></asp:Label></div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtDesignationRep" runat="server" class="form-control" placeholder="Designation"
                                    MaxLength="25"></asp:TextBox></div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <%-- <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label17" runat="server" Text="Place"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtPlaceRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label20" runat="server" Text="Flat"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtFlatRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label21" runat="server" Text="Premises"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtPremisesRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label22" runat="server" Text="Road"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtRoadRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label27" runat="server" Text="Area"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtAreaRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label29" runat="server" Text="City"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtCityRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label23" runat="server" Text="State"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:DropDownList ID="ddlStatesRep" runat="server" DataSourceID="ObjectDataSource2"
                                    DataTextField="StateName" DataValueField="StateCode" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label34" runat="server" Text="PIN"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtPINRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label24" runat="server" Text="Name"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtNameAu" runat="server" Class="form-control"></asp:TextBox></div>
                        </div>--%>
                        <br />
                        <br />
                        <%--    <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label28" runat="server" Text="Designation"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtDesignationAu" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label35" runat="server" Text="Place"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtPlaceAu" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label36" runat="server" Text="Date of Filing"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtDateAu" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label37" runat="server" Text="Ward/Circle/CIT"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtWardAu" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />--%>
                    </div>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                                ShowSummary="false" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                            <asp:Button ID="btnInsert" ValidationGroup="gg1" runat="server" Text="Save" OnClick="Button1_Click1"
                                class="btn-primary" Width="162px" Height="53px" /></div>
                        <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True" Text="Label"
                                Visible="False"></asp:Label></div>
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
    <div class="show-for-large-only">
        <menu:side ID="Sidemenu" runat="server" />
    </div>
    </form>
</body>
</html>
