<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tax Consultant Master.aspx.cs"
    Inherits="Presentation_Tax_Consultant_Master" %>

<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
<%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../mobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../mobilemenu2.ascx" TagPrefix="mob1" TagName="menu1" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagName="resmob" TagPrefix="resmenu" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../Presentation/MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="~/menu_header.ascx" TagName="menuheader" TagPrefix="header" %>
<!DOCTYPE html >
<html class="no-js" lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
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

        });</script>
    <script type="text/javascript">
        function validateIt() {
            if (confirm('Are you sure you want to remove this record?')) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</head>
<body onload="P7_ExpMenu()">
    <form id="form1" runat="server">
    <%----for header breadcrumps and menu nishu11/4/2015-----%>
     <div class="row hide-for-small-only">
    <div class="large-12 columns">
    <%--Add by nishu for header 11/4/2015 --%>
    <header:menuheader ID="header1" runat="server" />
    </div>
    </div>
     <div class="row">
     <div class="large-12 columns text-right">
         <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
             Font-Names="Calibri" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
     </div>
     </div>
    <div class="row hide-for-small-only">
        <div class="large-12 columns">
            <main:mainmenu ID="mm1" runat="server" />
        </div>
    </div>
     <div class="row hide-for-small-only">
        <div class="large-12 columns">
           <mob3:mediummenu id="medmenu" runat="server" />
         
        </div>
    </div>
    <div class="row show-for-small-only" style="background-color: #F8F8F8">
        <div class="large-12 columns">
           <a href="Default.aspx"><img src="../images/logo2.png" style="width:200px; height:70px" /></a>
            <img src="../images/menu1.JPG" id="btnmenu" />
            <%--<img src="../images/download.png" id="btnmenu" style="width:60px" />--%>
        </div>
    </div>
    <div class="row hidden-for-large hidden-for-medium" id="divmenu" style="display: none">
        <div class="large-12 columns">
            <resmenu:resmob ID="mob1" runat="server" />
        </div>
    </div>
   <%-- <div class="row show-for-small-only" id="divass">
        <div class="large-12 columns panel">
            Assesses Details
        </div>
    </div>
    <div class="row hidden-for-large hidden-for-medium" id="divassdet" style="display: none">
        <div class="large-12 columns">
            <sub:submenu ID="Submenu2" runat="server" />
        </div>
    </div>--%>
     <div class="row show-for-small-only" >
        <div class="large-12 columns">
          <mob2:mobmenu id="mobmenu" runat="server" />
                <%--<img src="../images/details.JPG" />--%>
            
        </div>
    </div>
    <br />
   
    <div class="row">
       
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
       
        <div class="large-12 columns">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:MultiView ID="mltView" ActiveViewIndex="0" runat="server">
                        <asp:View ID="viewList" runat="server">
                            <div class="row">
                                <div class="large-12 columns panel">
                                    <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Text="Tax Consultant Master"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtName" runat="server" MaxLength="50" required></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ValidationGroup="gg" ID="req1" runat="server" ControlToValidate="txtName" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator> --%>
                                </div>
                            </div>
                              <br />
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" required></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAddress" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator>    --%>
                                </div>
                            </div>
                              <br />
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label4" runat="server" Text="Phone No."></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtPhoneNo" runat="server" MaxLength="14" required></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPhoneNo" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator> --%>
                                </div>
                            </div>
                              <br />
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label5" runat="server" Text="Membership No."></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtMembershipNo" runat="server" MaxLength="20" required></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMembershipNo" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator> --%>
                                </div>
                            </div>
                              <br />
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label6" runat="server" Text="P.A.N."></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtPAN" runat="server" Style="text-transform: uppercase;" MaxLength="10"
                                        required></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPAN" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator> --%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid PAN"
                                        ControlToValidate="txtPAN" ValidationExpression="^[\w]{3}(p|P|c|C|h|H|f|F|a|A|t|T|b|B|l|L|j|J|g|G)[\w][\d]{4}[\w]$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                              <br />
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label7" runat="server" Text="ECS"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:DropDownList ID="ddECS" runat="server" Width="173px">
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                              <br />
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label2" runat="server" Text="Firm Name"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtFName" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                              <br />
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Button ValidationGroup="gg" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                        class="radius button" Height="53px" Width="162px" /></div>
                                <div class="large-6 columns">
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" class="radius button" Height="53px" Width="162px" />
                                </div>
                            </div>
                              <br />
                            <div class="row">
                                <div class="large-12 columns">
                                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="Large"></asp:Label>
                                </div>
                            </div>
                        </asp:View>
                        <asp:View ID="viewCountryDetail" runat="server">
                            <div class="row">
                                <div class="large-12 columns panel">
                                    State Detail
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="lblStateName" runat="server" Text="State Name :" AssociatedControlID="txtStateName"></asp:Label></div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtStateName" runat="server" TabIndex="1" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="lblCountryName" runat="server" Text="Country Name :" AssociatedControlID="txtCountryName"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtCountryName" runat="server" Style="vertical-align: middle; text-align: left"
                                        required></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="False" TabIndex="9"
                                        CausesValidation="true" class="button" Height="53px" Width="162px"></asp:Button>
                                </div>
                                <div class="large-6 columns">
                                    <asp:Button ID="btnDelete" runat="server" Width="162px" Text="Delete" CausesValidation="False"
                                        UseSubmitBehavior="False" TabIndex="10" class="button" Height="53px"></asp:Button><asp:Button ID="btnGoBack"
                                            runat="server" Text="Go Back" CausesValidation="False" UseSubmitBehavior="False"
                                            TabIndex="11" class="button" Height="53px" Width="162px"></asp:Button>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-12 columns">
                                    <%-- <asp:RequiredFieldValidator ValidationGroup="gg" id="rfvName" runat="server" Width="104px" ErrorMessage="Enter State Name" ControlToValidate="txtStateName" Display="None" ></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ValidationGroup="gg" ID="rfvCode" runat="server" ControlToValidate="txtCountryName"
                                                Display="None" ErrorMessage="Enter Country Name" TabIndex="5" 
                                                Width="104px"></asp:RequiredFieldValidator>--%>
                                    <asp:ValidationSummary ID="vlsUserGrp" runat="server" Width="496px"></asp:ValidationSummary>
                                </div>
                            </div>
                        </asp:View>
                        <asp:View ID="viewMessage" runat="server">
                            <div class="row">
                                <div class="large-12 columns">
                                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-12 columns">
                                    <asp:Button ID="btnGoBackM" TabIndex="10" runat="server" UseSubmitBehavior="False"
                                        Text="Go Back" CausesValidation="False" class="button"></asp:Button>
                                </div>
                            </div>
                        </asp:View>
                        <asp:View ID="ViewDetails" runat="server">
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="lblSubHeading" runat="server" Font-Bold="True" Text="Label"></asp:Label></div>
                                <div class="large-6 columns">
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-4 columns">
                                    <asp:Button ID="btnOK" runat="server" Text="OK" class="button"></asp:Button></div>
                                <div class="large-4 columns">
                                    <asp:Button ID="Button3" runat="server" Text="Remove" Visible="False" class="button" /></div>
                                <div class="large-4 columns">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="button" /></div>
                            </div>
                        </asp:View>
                    </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>
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
