<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Partner Master.aspx.cs" Inherits="Presentation_Partner_Master" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %> <%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagName="resmob" TagPrefix="resmenu" %>
<%@ Register Src="../mobilemenu.ascx" TagPrefix="mob" TagName="menu" %>

<!DOCTYPE html>
<html class="no-js" lang="en" >
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
     
         <main:mainmenu ID="mm1" runat="server" />
        </div>

      </div>
  
          <div class="row show-for-small-only" style="background-color:#F8F8F8">
      <div class="large-12 columns">
          <img src="../images/Logo.jpg" style="width:60px" />
          <img src="../images/LogoText_.jpg" style="width:120px" />
          <%--<img src="../images/download.png" id="btnmenu" style="width:60px" />--%>
      </div>
       
       </div>
      
      <div class="row hidden-for-large hidden-for-medium" id="divmenu" style="display:none">
      
      <div class="large-12 columns">
       <resmenu:resmob ID="mob1" runat="server" />
      
      </div>
      </div>
   <div class="row show-for-small-only" id="divass">
   <div class="large-12 columns panel">
   Assesses Details
   </div>
   </div>
   <div class="row hidden-for-large hidden-for-medium" id="divassdet" style="display:none" >
   <div class="large-12 columns">
    <sub:submenu ID="Submenu2" runat="server" />
   </div>
   </div>
      <div class="row">    
        
        <div class="large-3 columns hide-for-small-only">
            
         
            <sub:submenu ID="Submenu1" runat="server" />
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
        </div>
         
         
        <div class="large-9 columns">
                
         <asp:ScriptManager ID="ScriptManager1" runat="server">
            
        </asp:ScriptManager> 
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:MultiView ID="mltView" ActiveViewIndex = "0" runat="server">
                <asp:View ID="viewList" runat = "server" >
                <div class="row">
                <div class="large-12 columns panel">
                <asp:Label ID="lblHeading" runat="server" Font-Bold="True"
                                                Text="Partner Master"></asp:Label>
                </div>
                </div>
                <div class="row">
                <div class="large-6 columns">
                  <asp:Label ID="Label1" runat="server" Text="P.A.N."></asp:Label>
                </div>
                  <div class="large-6 columns">
                   <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                  </div>
                </div>
                  <div class="row">
                <div class="large-6 columns">
                 <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
                </div>
                  <div class="large-6 columns">
                   <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                  </div>
                </div>
                  <div class="row">
                <div class="large-6 columns">
                  <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
                </div>
                  <div class="large-6 columns">
                  <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                  </div>
                </div>
                  <div class="row">
                <div class="large-6 columns">
                 <asp:Label ID="Label5" runat="server" Text="Phone No."></asp:Label>
                </div>
                  <div class="large-6 columns">
                  <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                  </div>
                </div>
                  <div class="row">
                <div class="large-6 columns">
                 <asp:Label ID="Label6" runat="server" Text="Profit Sharing Ratio"></asp:Label>
                </div>
                  <div class="large-6 columns">
                  <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                  </div>
                </div>
                  <div class="row">
                <div class="large-6 columns">
                </div>
                  <div class="large-6 columns">
                  </div>
                </div>
                </asp:View>
                <asp:View ID="viewCountryDetail" runat = "server" >
                <div class="row">
                <div class="large-12 columns panel">State Detail</div>
                </div>
                <div class="row">
                <div class="large-6 columns">
                 <asp:Label ID="lblStateName" runat="server" Text="State Name :"  AssociatedControlID="txtStateName"></asp:Label>
                </div>
                <div class="large-6 columns">
                <asp:textbox id="txtStateName" runat="server" Width="163px" TabIndex="1" required></asp:textbox>
                </div>
                </div>
                 <div class="row">
                <div class="large-6 columns">
                  <asp:Label ID="lblCountryName" runat="server" Text="Country Name :"  AssociatedControlID="txtCountryName"></asp:Label>
                </div>
                <div class="large-6 columns">
                 <asp:TextBox ID="txtCountryName" runat="server"  style="vertical-align: middle; text-align: left" required></asp:TextBox>
                </div>
                </div>
                 <div class="row">
                <div class="large-4 columns">
                <asp:button id="btnSave" runat="server"  Text="Save" UseSubmitBehavior="False" TabIndex="9" CausesValidation = "true" ValidationGroup="Save" class="button"></asp:button>
                </div>
                <div class="large-4 columns">
                <asp:button id="btnDelete" runat="server" Width="66px" Text="Delete" CausesValidation="False" UseSubmitBehavior="False" TabIndex="10" class="button"></asp:button>
                </div>
                <div class="large-4 columns">
                <asp:Button id="btnGoBack" runat="server" Text="Go Back" CausesValidation="False" UseSubmitBehavior="False" TabIndex="11" class="button"></asp:Button>
                </div>
                </div>
                 <div class="row">
                <div class="large-12 columns"></div>
              <%-- <asp:RequiredFieldValidator id="rfvName" runat="server" Width="104px" ErrorMessage="Enter State Name" ControlToValidate="txtStateName" Display="None" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                                           <%-- <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCountryName"
                                                Display="None" ErrorMessage="Enter Country Name" TabIndex="5" ValidationGroup="Save"
                                                Width="104px"></asp:RequiredFieldValidator>--%>
											<asp:ValidationSummary id="vlsUserGrp" runat="server" Width="496px" ValidationGroup="Save"></asp:ValidationSummary>
                </div>
                 
                </asp:View>
                     <asp:View ID="viewMessage" runat = "server">
                     <div class="row">
                     <div class="large-12 columns">
                      <asp:Label ID="lblMessage"  runat="server"  Font-Bold="True" Font-Size="Large"></asp:Label>
                     </div>
                     </div>
                        <div class="row">
                     <div class="large-12 columns">
                    <asp:Button id="btnGoBackM" tabIndex=10 runat="server" UseSubmitBehavior="False" Text="Go Back" CausesValidation="False" class="button"></asp:Button>
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
   
    
    </form>

</body>
</html>
