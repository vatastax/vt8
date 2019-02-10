<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployerMaster.aspx.cs" Inherits="Presentation_EmployerMaster"
    EnableViewState="true" %>

<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
<%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../mobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagName="resmob" TagPrefix="resmenu" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../Presentation/MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="~/menu_header.ascx" TagName="menuheader" TagPrefix="header" %>
<!DOCTYPE html>
<html class="no-js" lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Control Panel</title>
    <%--<script src="../scripts/jquery.js" type="text/javascript"></script>--%>
    <%--<link href="../styles/StyleSheet.css" rel="stylesheet" type="text/css" />--%>
    <%--<script src="../js/jquery.min.js" type="text/javascript"></script>--%>
    <%--<link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />--%>
    <%--    <script type="text/javascript" src="../scripts/menu.js"></script> --%>
    <%-- <link href="../foundation-5.5.0/css/foundation.min.css" rel="stylesheet" type="text/css" />--%>
    <%--<link href="../styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../foundation-5.5.0/js/foundation.min.js" type="text/javascript"></script>--%>
    <%-- <link href="../StaticStylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />
    <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />--%>
    <!--master javascript file-->
    <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <!--master javascript file-->
    <!--master style sheet-->
    <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
    <script type="text/javascript">
        function validateIt() {
            if (confirm('Are you sure you want to delete it?'))
                return true;
            else
                return false;
        }
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

            $("#divass").click(function () {
                $("#divassdet").slideToggle();
            });

        });
    </script>
    <script type="text/javascript">
        function validateIt() {
            if (confirm('Are you sure you want to delete the selected record?')) {
                return true;
            }
            else {
                return false;
            }

        }

    </script>
    <style>
        .hrnew
        {
            height: 2px;
            background-image: -webkit-linear-gradient(left, rgba(0, 0, 0, 1), rgba(0, 0, 0, 1), rgba(0, 0, 0, 1));
            opacity: 1.0;
            margin-top: 4px;
        }
        .font
        {
            color: Black;
            font-family: 'Open Sans' , 'sans-serif';
            font-size: 15px;
        }
    </style>
</head>
<body onload="P7_ExpMenu()">
    <form id="form1" runat="server">
    <div class="row hide-for-small-only">
        <div class="large-12 columns">
            <%--Add by nishu for header 11/4/2015 --%>
            <header:menuheader ID="header1" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="large-12 columns">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Cambria" ForeColor="#333333">
            </asp:SiteMapPath>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
    </div>
    <div class="hide-for-small-only hide-for-medium-only">
        <menu:side ID="Sidemenu" runat="server" />
    </div>
    <div class="row hide-for-small-only">
        <div class="large-12 columns">
            <main:mainmenu ID="mm1" runat="server" />
        </div>
    </div>
    <div class="row show-for-medium-only">
        <div class="large-12 columns">
            <mob3:mediummenu ID="medmenu" runat="server" />
        </div>
    </div>
    <div class="row show-for-small-only" style="background-color: #F8F8F8">
        <div class="small-9 columns">
            <a href="Default.aspx">
                <img src="../images/logo2.PNG" style="width: 200px; height: 70px" /></a>
        </div>
        <div class="small-3 columns">
            <img src="../images/menu1.JPG" id="btnmenu" style="margin-top: 15px; width: 40px;
                height: 40px" />
        </div>
    </div>
    <div class="row hidden-for-large hidden-for-medium" id="divmenu" style="display: none">
        <div class="large-12 columns">
            <resmenu:resmob ID="mob1" runat="server" />
        </div>
    </div>
    <%--  <div class="row show-for-small-only" id="divass">
   <div class="large-12 columns panel">
   Assesses Details
   </div>
   </div>
   <div class="row hidden-for-large hidden-for-medium" id="divassdet" style="display:none" >
   <div class="large-12 columns">
    <sub:submenu ID="Submenu2" runat="server" />
   </div>
   </div>--%>
    <div class="row show-for-small-only">
        <div class="large-12 columns">
            <mob2:mobmenu ID="mobmenu" runat="server" />
            <%--<img src="../images/details.JPG" />--%>
        </div>
    </div>
    <div class="row">
        <%--  <div class="large-3 columns show-for-large-only">
            
         
            <sub:submenu ID="Submenu1" runat="server" />--%>
        <%--  <br />--%>
        <%-- <%
                    if (Request.QueryString["vtype"].ToString() == "40" || Request.QueryString["vtype"].ToString() == "41")
                    {
                     %>
                     <emp:empmenu ID="Empmenu1" runat="server" />
                     <%
                    }
                         %>
                         <%
                             if (Request.QueryString["vtype"].ToString() == "42" || Request.QueryString["vtype"].ToString() == "43")
                    {
                     %>
                     <house:property ID="Property1" runat="server" />
                     <%
                    }
                        %>--%>
        <%--     </div>--%>
        <div class="large-12 columns">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
            <asp:MultiView ID="mltView" ActiveViewIndex="0" runat="server">
                <asp:View ID="viewList" runat="server">
                    <div class="row">
                        <div class="large-12 columns ">
                            <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Style="font-family: 'Open Sans','sans-serif';
                                font-size: 15px; font-weight: bold; text-transform: uppercase; color: #ef5845;"
                                Text="Employer Master"></asp:Label>
                            <hr class="hrnew" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-8 columns font">
                            <asp:Label ID="Label10" runat="server" Text="PAN"></asp:Label>
                        </div>
                        <div class="large-4 columns">
                            <asp:TextBox ID="txtPAN" runat="server" MaxLength="10" Style="text-transform: uppercase;"
                                required></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPAN"
                                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid PAN"
                                ControlToValidate="txtPAN" Display="None" ValidationExpression="^[\w]{3}(p|P|c|C|h|H|f|F|a|A|t|T|b|B|l|L|j|J|g|G)[\w][\d]{4}[\w]$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-8 columns font">
                            <asp:Label ID="Label1" runat="server" Text="TAN"></asp:Label>
                        </div>
                        <div class="large-4 columns">
                            <asp:TextBox ID="txtTAN" runat="server" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid TAN"
                                ControlToValidate="txtTAN" Display="None" ValidationExpression="^[\w]{3}(p|P|c|C|h|H|f|F|a|A|t|T|b|B|l|L|j|J|g|G)[\w][\d]{4}[\w]$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-8 columns font">
                            <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                        </div>
                        <div class="large-4 columns">
                            <asp:TextBox ID="txtName" runat="server" required></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-8 columns font">
                            <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
                        </div>
                        <div class="large-4 columns">
                            <asp:TextBox ID="txtAddr" runat="server" required></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddr"
                                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-8 columns font">
                            <asp:Label ID="Label5" runat="server" Text="Phone No."></asp:Label>
                        </div>
                        <div class="large-4 columns">
                            <asp:TextBox ID="txtPhone" runat="server" required></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhone"
                                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-8 columns font">
                            <asp:Label ID="Label6" runat="server" Text="Type of Employer"></asp:Label>
                        </div>
                        <div class="large-4 columns">
                            <asp:DropDownList ID="ddlEmployer" runat="server">
                                <asp:ListItem>Government</asp:ListItem>
                                <asp:ListItem>PSU</asp:ListItem>
                                <asp:ListItem>Others</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                    <br />
                    <div class="row" style="float: right">
                        <div class="large-3 columns">
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" class="radius button"
                                formnovalidate Height="53px" Width="162px" /></div>
                        <div class="large-3 columns">
                            <asp:Button ValidationGroup="gg" ID="btnInsert" runat="server" OnClick="btnInsert_Click"
                                Text="Insert" class="radius button" Height="53px" Width="162px" />
                        </div>
                        <div class="large-3 columns">
                            <asp:Button ValidationGroup="gg" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                class="radius button" Height="53px" Width="162px" /></div>
                        <div class="large-3 columns">
                            <asp:Button ID="btnDel" runat="server" Text="Delete" OnClick="btnDel_Click" OnClientClick="return validateIt();"
                                class="radius button" Height="53px" Width="162px" /></div>
                </asp:View>
                <asp:View ID="viewCountryDetail" runat="server">
                    <div class="row">
                        <div class="large-12 columns panel">
                            State Detail
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-6 columns">
                            <asp:Label ID="lblStateName" runat="server" Text="State Name :" Width="130px" Height="6px"
                                AssociatedControlID="txtStateName"></asp:Label></div>
                        <div class="large-6 columns">
                            <asp:TextBox ID="txtStateName" runat="server" Width="163px" TabIndex="1" required></asp:TextBox></div>
                    </div>
                    <div class="row">
                        <div class="large-6 columns">
                            <asp:Label ID="lblCountryName" runat="server" Text="Country Name :" Width="103px"
                                AssociatedControlID="txtCountryName"></asp:Label></div>
                        <div class="large-6 columns">
                            <asp:TextBox ID="txtCountryName" runat="server" Width="164px" Style="vertical-align: middle;
                                text-align: left" required></asp:TextBox></div>
                    </div>
                    <div class="row">
                        <div class="large-6 columns">
                            <asp:Button ID="btnSave" runat="server" Width="68px" Text="Save" UseSubmitBehavior="False"
                                TabIndex="9" CausesValidation="true" ValidationGroup="Save"></asp:Button></div>
                        <div class="large-6 columns">
                            <asp:Button ID="btnDelete" runat="server" Width="66px" Text="Delete" CausesValidation="False"
                                UseSubmitBehavior="False" TabIndex="10"></asp:Button>&nbsp;<asp:Button ID="btnGoBack"
                                    runat="server" Text="Go Back" CausesValidation="False" UseSubmitBehavior="False"
                                    TabIndex="11"></asp:Button></div>
                    </div>
                    <div class="row">
                        <div class="large-12 columns">
                            <%-- <asp:RequiredFieldValidator id="rfvName" runat="server" Width="104px" ErrorMessage="Enter State Name" ControlToValidate="txtStateName" Display="None" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCountryName"
                                                Display="None" ErrorMessage="Enter Country Name" TabIndex="5" ValidationGroup="Save"
                                                Width="104px"></asp:RequiredFieldValidator>--%>
                            <asp:ValidationSummary ID="vlsUserGrp" runat="server" Width="496px" ValidationGroup="Save">
                            </asp:ValidationSummary>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="viewMessage" runat="server">
                    <div class="row">
                        <div class="large-12 columns">
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-12 columns">
                            <asp:Button ID="btnGoBackM" TabIndex="10" runat="server" UseSubmitBehavior="False"
                                Text="Go Back" CausesValidation="False"></asp:Button>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="ViewDetails" runat="server">
                    <div class="row">
                        <div class="large-12 columns">
                            <asp:Label ID="lblSubHeading" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-4 columns">
                            <asp:Button ID="btnOK" runat="server" Text="OK" class="button"></asp:Button></div>
                        <div class="large-4 columns">
                            <asp:Button ID="Button3" runat="server" Text="Remove" Visible="False" Width="73px"
                                class="button" /></div>
                        <div class="large-4 columns">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="75px" class="button" /></div>
                    </div>
                </asp:View>
            </asp:MultiView>
            <%--</ContentTemplate>
            </asp:UpdatePanel>       --%>
        </div>
    </div>
    <footer class="row">
        <div class="large-12 columns">
          <hr/>
          <div class="row">
            <div class="large-6 columns">
              <p>© Copyright to Vatas Infotech.</p>
            </div>
            <div class="large-6 columns">
              <%--<ul class="inline-list right">
                <li><a href="#">Section 1</a></li>
                <li><a href="#">Section 2</a></li>
                <li><a href="#">Section 3</a></li>
                <li><a href="#">Section 4</a></li>
              </ul>--%>
            </div>
          </div>
         

        </div> 
      </footer>
    </form>
</body>
</html>
