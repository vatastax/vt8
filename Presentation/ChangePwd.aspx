<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="Presentation_ChangePwd" %>
<%--<%@ Register Assembly="controlgrid" Namespace="controlgrid" TagPrefix="cc1" %>--%>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
<%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../mobilemenu2.ascx" TagPrefix="mob1" TagName="menu1" %>
<%@ Register Src="../SubUserMenu_Employer.ascx" TagName="empmenu" TagPrefix="emp" %>
<%@ Register Src="../SubUserMenu_Asset.ascx" TagName="property" TagPrefix="house" %>

<%@ Register Src="../UserControls/ReceiptNo.ascx" TagName="receipt" TagPrefix="rec" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %><%@ Register Src="MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>

<%@ Register Src="../UserControls/TDS_Delete.ascx" TagName="DeleteTDS" TagPrefix="delTDS" %>


<%@ Register Src="../UserControls/PopupControl.ascx" TagName="pop" TagPrefix="popup" %>
<%@ Register Src="../menu_header.ascx" TagName="menuheader" TagPrefix="header" %>

<!DOCTYPE html >

<html class="no-js" lang="en">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <title></title>
       <script src="../js/MasterJScript.js" type="text/javascript"></script>
<%--<link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />--%>
<%--           <link href="StyleSheet2.css" rel="stylesheet" type="text/css" />--%>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery1.7.2.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.js" type="text/javascript"></script>
<%--     <link href="../css/jquery-ui.css" type="text/css" />--%>
         
      
       <script type="text/javascript">
           function ShowPopup(message) {
             
               $("#dialog").html(message);
            
               $("#dialog").dialog({
                   title: "Change Password",
                   buttons: {
                      
                       CLOSE: function () {

                           $(this).dialog('close');
                         
                       }

                   },
                   modal: true
               });
               return false;

           };
    </script>
    <link href="../css/popupstyle.css" rel="stylesheet" type="text/css" />
</head>
<body style="padding:none">
    <form id="form1" runat="server">
      
  <%--  <div class="row hide-for-small-only">
        <div class="large-12 columns">--%>
            <%--Add by nishu for header 11/4/2015 --%>
           <%-- <header:menuheader ID="header1" runat="server" />
        </div>
     </div>--%>
      <!--sitemap-->
   <%--   <div class="row ">
        <div class="large-12 columns  hidden-for-small-only" >
          
             <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
             Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" NodeStyle-Font-Bold="false" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
    </div>--%>
  <%--  <div class=" hide-for-small-only" >
            <main:mainmenu ID="mm1" runat="server" />
           
       </div>--%>
    <div style="width:80%;height:40%; margin-bottom:100px;margin-top:-10px; margin-left:10px">
    <div class="login">
	<div class="login-main">
		<div class="login-top" style="padding:none">
       <div>
            <%--<asp:Label ID="Label1" runat="server" Text="Enter Old password"></asp:Label>  --%>
            <asp:TextBox ID="txtOldPwd"  placeholder="Enter old password " TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"  ErrorMessage="Enter old password" ControlToValidate="txtOldPwd" ForeColor="Red"></asp:RequiredFieldValidator>
       </div>
       <div>
            <%--<asp:Label ID="Label2" runat="server" Text="Enter New password"></asp:Label>--%>
            <asp:TextBox ID="txtNewPwd" placeholder="Enter new password " TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"  ErrorMessage="Enter new password" ControlToValidate="txtNewPwd" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div style="margin-bottom:-20px">
            <%--<asp:Label ID="Label3" runat="server" Text="Confirm password"></asp:Label>--%>
            <asp:TextBox ID="txtComPwd" placeholder="Confirm password " TextMode="Password" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"  ErrorMessage="Enter confirm password" ControlToValidate="txtComPwd" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Confirm Password should be match with Password" ControlToValidate="txtComPwd" ControlToCompare="txtNewPwd"></asp:CompareValidator>
        </div>
        <div style="top:15px">
        <br />
                 <asp:Button ID="btnChange" runat="server" Text="Change" class="button radius" style="background:rgba(167, 57, 70, 0.86)" 
               onclick="btnChange_Click" />
               <br />
               <asp:Label ID="lblMsg" style="color:Red" runat="server" Visible="false"></asp:Label>
           
       </div>
    </div>
    </div>
    </div>
    </div>    
    </form>
</body>
</html>
