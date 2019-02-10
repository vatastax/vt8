<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BankMaster.aspx.cs" Inherits="Presentation_Bank_Master" %>

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
   <%-- <script type="text/javascript" src="../scripts/menu.js"></script> 
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../scripts/jquery.js" type="text/javascript"></script>--%>

    <%--<link href="../styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />--%>

    <%--<script type="text/javascript" src="../scripts/menu.js"></script>--%>

    <%--<link href="../styles/foundation.min.css" rel="stylesheet" type="text/css" />--%>

  <%--  <script src="../scripts/modernizr.js" type="text/javascript"></script>
    <script src="../scripts/foundation.min.js" type="text/javascript"></script>--%>

       <%--<link href="../styles/StyleSheet.css" rel="stylesheet" type="text/css" />
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
</head>
<body onload="P7_ExpMenu()">
    <form id="form1" runat="server">
     <div class="row hide-for-small-only">
    <div class="large-12 columns">
    <%--Add by nishu for header 11/4/2015 --%>
    <header:menuheader ID="header1" runat="server" />
    </div>
    </div>
    <div class="row hide-for-small-only">
        <div class="large-12 columns">
            <main:mainmenu ID="mm1" runat="server" />
        </div>
    </div>



    
     </div>
      <div class="row hide-for-small-only">
        <div class="large-12 columns">
           <mob3:mediummenu id="medmenu" runat="server" />
         
        </div>
    </div>
    <div class="row show-for-small-only" style="background-color: #F8F8F8">
        <div class="small-9 columns">
            <a href="Default.aspx">
            <img src="../images/logo2.PNG" style="width:200px; height:70px" /></a>
        </div>
        <div class="small-3 columns">
            <img src="../images/menu1.JPG" id="btnmenu" style="margin-top:15px;width:40px; height:40px"/>  
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
    <%-- change location of breadcrumps 11/4/2015 --%>
      <div class="row">
         <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
             Font-Names="Calibri" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
     </div>
   
    <div class="row">
      <%--  <div class="large-3 columns hide-for-small-only">
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
       <%-- </div>--%>
        <div class="large-12 columns">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:MultiView ID="mltView" ActiveViewIndex="0" runat="server">
                        <asp:View ID="viewList" runat="server">
                            <div class="row">
                                <div class="large-12 columns panel">
                                    <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Text="Bank Details"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label1" runat="server" Text="Bank Name"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtBankName" runat="server" required></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="req1" runat="server" ControlToValidate="txtBankName" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label3" runat="server" Text="MICR Code"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtMICR" runat="server" required></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMICR" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtAddress" runat="server" required></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label5" runat="server" Text="Account Type"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:DropDownList ID="ddAccountType" runat="server" class="form-control" required>
                                        <asp:ListItem Text=" --  --  -- -- Select -- -- --  -- " Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Savings" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Current" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="CashCredit" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="req2" runat="server" ControlToValidate="ddAccountType" InitialValue="-1" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label6" runat="server" Text="Account No."></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:TextBox ID="txtAccountNo" runat="server" required></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAccountNo" ErrorMessage="*">
                                                        </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-6 columns">
                                    <asp:Label ID="Label7" runat="server" Text="ECS"></asp:Label>
                                </div>
                                <div class="large-6 columns">
                                    <asp:DropDownList ID="ddECS" runat="server" class="form-control">
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="large-3 columns">&nbsp;</div>
                                <div class="large-3 columns">
                                    <asp:Button ValidationGroup="gg" ID="btnInsert" runat="server" OnClick="btnInsert_Click"
                                        Text="Insert" class="radius button" Height="53px" Width="162px"  /></div>
                                <div class="large-3 columns">
                                    <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="Update" class="radius button" Height="53px" Width="162px"  />
                                </div>
                                <div class="large-3 columns"></div>
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
       <%-- <div class="show-for-large-only">
   <menu:side ID="Sidemenu" runat="server"  />
   </div>--%>
    </form>
</body>
</html>
