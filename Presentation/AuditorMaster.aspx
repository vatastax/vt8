<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditorMaster.aspx.cs" Inherits="Presentation_Auditor_Master" %>

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
    <script src="../scripts/jquery.js" type="text/javascript"></script>
    <link href="../styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />
    <script type="text/javascript" src="../scripts/menu.js"></script>
    <link href="../styles/foundation.min.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/modernizr.js" type="text/javascript"></script>
    <script src="../scripts/foundation.min.js" type="text/javascript"></script>
           <script src="../js/jquery.min.js" type="text/javascript"></script>
              <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
                <link href="../styles/StyleSheet.css" rel="stylesheet" type="text/css" />
       <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
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
            <img src="../images/securedownload.jpg" style="width:200px; height:70px" />
            <img src="../images/menu1.JPG" id="btnmenu" />
            <%--     <img src="../images/download.png" id="btnmenu" style="width:60px" />--%>
        </div>
    </div>
    <div class="row hidden-for-large hidden-for-medium" id="divmenu" style="display: none">
        <div class="large-12 columns">
            <resmenu:resmob ID="mob1" runat="server" />
        </div>
    </div>
  <div class="row show-for-small-only" >
        <div class="large-12 columns">
          <mob2:mobmenu id="mobmenu" runat="server" />
                <%--<img src="../images/details.JPG" />--%>
            
        </div>
    </div>
    <br />
   
    <div class="row">
       <%-- <div class="large-3 columns show-for-large-only">
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
      <%--  </div>--%>
        <div class="large-12 columns">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:MultiView ID="mltView" ActiveViewIndex="0" runat="server">
                        <asp:View ID="viewList" runat="server">
                            <div class="row">
                                <div class="large-12 columns panel hide-for-small-only">
                                    <asp:Label ID="lblHeading" runat="server" Font-Bold="true" Text="Auditor Master"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label1" runat="server" Text="Auditor Name"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtName" runat="server" required></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ValidationGroup="gg" ID="req1" runat="server" ControlToValidate="txtName" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label4" runat="server" Text="Phone No."></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label5" runat="server" Text="Membership No."></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtMember" runat="server" required></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMember" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label6" runat="server" Text="P.A.N."></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtPAN" runat="server" MaxLength="10" Style="text-transform: uppercase;"
                                        required></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPAN" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator>    --%>
                                    <asp:RegularExpressionValidator ValidationGroup="gg" ID="RegularExpressionValidator1"
                                        runat="server" ErrorMessage="Invalid PAN" ControlToValidate="txtPAN" ValidationExpression="^[\w]{3}(p|P|c|C|h|H|f|F|a|A|t|T|b|B|l|L|j|J|g|G)[\w][\d]{4}[\w]$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label2" runat="server" Text="Firm Name"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtFirmName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-4 columns">
                                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Add" ValidationGroup="gg"
                                        class="raius button" Height="53px" Width="162px" />
                                </div>
                                <div class="large-4 columns">
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                        ValidationGroup="gg" class="radius button" Height="53px" Width="162px" />
                                </div>
                                <div class="large-4 columns">
                                    <asp:Button ID="Button4" runat="server" Text="Cancel" OnClick="Button4_Click" Class="radius button" Height="53px" Width="162px" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-12 columns">
                                    <%-- <asp:GridView ID="gvCM" Width="95%" runat="server" AutoGenerateColumns="false"
                                             OnRowDataBound="gvCM_RowDataBound" OnRowCommand="gvCM_RowCommand" EmptyDataText="<center> ---- ----- No Consultant Added  ---- ----- </center>">
                                             <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6492C3"></HeaderStyle>
                                            <Columns>
                                            <asp:TemplateField>
                                            <HeaderTemplate>
                                            SNo.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                            <asp:Label ID="lblSNO" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                            <HeaderTemplate>
                                            Consultant Name
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                            <asp:Label ID="lblEmpName" runat="server" Text='<%# Eval("AuditorName") %>'></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                            <HeaderTemplate>
                                            PAN
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                            <asp:Label ID="lblPAN" runat="server" Text='<%# Eval("PAN") %>'></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                            <HeaderTemplate>
                                            Membership No
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%# Eval("MembershipNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>                                            
                                            <asp:TemplateField>
                                            <HeaderTemplate>
                                            Phone
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                            <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>                                            
                                            <asp:TemplateField>
                                            <ItemTemplate>
                                            <asp:LinkButton ID="lbtnEdit" runat="server" Text="Edit" CommandName="edt" CommandArgument='<%# Eval("ConsultID") %>'></asp:LinkButton>
                                            &nbsp;
                                            <asp:LinkButton ID="lbtnDel" runat="server" Text="Delete" OnClientClick="return validateIt();" CommandName="ddel" CommandArgument='<%# Eval("ConsultID") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            </Columns>
                                            </asp:GridView>--%>
                                </div>
                            </div>
                        </asp:View>
                        <asp:View ID="viewCountryDetail" runat="server">
                            <div class="row">
                                <div class="large-12 columns heading">
                                    State Detail
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="lblStateName" runat="server" Text="State Name :" AssociatedControlID="txtStateName"
                                        required></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtStateName" runat="server" TabIndex="1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="lblCountryName" runat="server" Text="Country Name :" AssociatedControlID="txtCountryName"
                                        required></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtCountryName" runat="server" Style="vertical-align: middle; text-align: left"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-4 columns">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="False" TabIndex="9"
                                        CausesValidation="true" ValidationGroup="Save" class="button"></asp:Button></div>
                                <div class="large-4 columns">
                                    <asp:Button ID="btnDelete" runat="server" Width="66px" Text="Delete" CausesValidation="False"
                                        UseSubmitBehavior="False" TabIndex="10" class="button"></asp:Button></div>
                                <div class="large-4 columns">
                                    <asp:Button ID="btnGoBack" runat="server" Text="Go Back" CausesValidation="False"
                                        UseSubmitBehavior="False" TabIndex="11" Class="button"></asp:Button>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-12 columns">
                                    <%--  <asp:RequiredFieldValidator id="rfvName" runat="server"  ErrorMessage="Enter State Name" ControlToValidate="txtStateName" Display="None" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCountryName"
                                                Display="None" ErrorMessage="Enter Country Name" TabIndex="5" ValidationGroup="Save"
                                               ></asp:RequiredFieldValidator>
											<asp:ValidationSummary id="vlsUserGrp" runat="server"  ValidationGroup="Save"></asp:ValidationSummary>--%>
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
                                <div class="large-12 columns">
                                    <asp:Label ID="lblSubHeading" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-4 columns">
                                    <asp:Button ID="btnOK" runat="server" Text="OK" class="button"></asp:Button>
                                </div>
                                <div class="large-4 columns">
                                    <asp:Button ID="Button3" runat="server" Text="Remove" Visible="False" class="button" />
                                </div>
                                <div class="large-4 columns">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="button" />
                                </div>
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
          <%--<div class="show-for-large-only">
   <menu:side ID="Sidemenu" runat="server"  />
   </div>--%>
    </form>
</body>
</html>
