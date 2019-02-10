<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reception.aspx.cs" Inherits="Presentation_Reception" %>
<%@ Register Src="../menu_header.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <!--Master javascript file-->
        <%--<script src="../js/MasterJScript.js" type="text/javascript"></script>--%>
         <script src="Scripts/JScript.js" type="text/javascript"></script>
        <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <!--Master javascript file-->

     <!--master style sheet-->
    <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />   
    <link href="../css/new_button.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        // $(document).ready(function () {
        $(document).ready(function () {
            //alert('gg');

            $("#dny_Grd_ITRInfo_Dynamic_Gridview_ctl01_txt_Name_hdr").bind("keypress", function (e) {
                if (e.keyCode == 13) {
                    return e.keyCode = 9;
                }
            });

            $("#dny_Grd_ITRInfo_Dynamic_Gridview_ctl01_txt_Name_hdr").bind("keypress", function (e) {
                if (e.keyCode == 13) {
                    return e.keyCode = 9;
                }
            });


            //});
        });
    </script>
    <!--master style sheet-->
</head>
<body>
     <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdnID" runat="server" />
    <asp:HiddenField ID="hdnAY" runat="server" />
    <%--<div style="display:none">
    <sum:ss ID="aa1" runat="server" />
    </div>--%>
    <%-------------header ----------------%>
    <div class="row" >
        <div class="large-12 columns hide-for-small-only">
            <%
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
            %>
        </div>
    </div>
   

    <%---------------show assesee detail on medium screen -------------------%>
     <div class="row show-for-medium-only">
  
     <div class="large-12 columns  "> <%
        if (Session["ay"] != null && Session["NameID"] != null)
        {
            %>
      <mob3:mediummenu id="Mediummenu1" runat="server" />
      <%} %>
      <br />
     </div>
     </div>
     <%-------------show header on mobile screen --------------------------------------------------------%>
    <div class="row show-for-small-only ">
    <br />
        <div class="small-12 columns" style="vertical-align:top; ">
        <a href="Default.aspx">
            <img src="../images/logo2.png" style="width:180px; height:auto" />    </a>        
    </div>    
    </div>
    <%----------------show username on mobile menu --------------------%>
     <div class="row show-for-small-only">     
     <div class="large-12 columns text-right">
      Welcome <span style="color:Black;font-family:'Open Sans','sans-serif';font-size:15px;font-weight:bold;color:#008CBA;  text-transform:capitalize"><asp:Literal ID="ltUser" runat="server" /></span>
         
      <a href="logout.aspx">
 [Logout]
 </a>
     </div>
     </div>
     <%--show breadcrumps in all views nishu 8/4/2015--%>
    <div class="row" >
    
    <div class="large-6 columns text-left">
     <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
              Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" NodeStyle-Font-Bold="false" ForeColor="#333333" RootNodeStyle-ForeColor="#19b99a">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </div>
    <div class="large-6 columns text-right">
       <%-- <a href="itr1.aspx"><input type="button" value=" Back to Home " class="newbtn" /></a>--%>
       <%---nishu 8/3/2015 ------%>
       
       <asp:Button ID="btnBacKMain" runat="server" Text=" Back to Home " class="newbtn"  /> 
    
    </div>
    </div>
<asp:Button ID="btnList" runat="server" Text="List of Assessees" class="radius button" Font-Bold="true" style="height:38px;padding-top:0;padding-bottom:0; margin:0px;width:260px;" OnClick="btnProcess_Click" />
<asp:Button ID="btnProcess" runat="server" Text="Processing Assessees" class="radius button" Font-Bold="true" style="height:38px;padding-top:0;padding-bottom:0; margin:0px;width:260px;" />
<asp:Button ID="btnReporting" runat="server" Text="Reporting" class="radius button" Font-Bold="true" style=" height:38px;padding-top:0;padding-bottom:0; margin:0px; width:260px;" />
<asp:Button ID="bb1" runat="server" OnClick="btnProcess_Click" />
    <div class="large-12 columns" style="overflow: hidden; width: 970px;">
        <VATAS:VGrid ID="VGrid1" runat="server" Width="100%" />
    </div>
    <br>
    <div class="large-12 columns" style="overflow: hidden; width: 970px;">
    <center>
    <asp:Button ID="btnAddAssessee" runat="server" OnClick="btnAddAssessee_Click" Text="Add New Assessee"
                                class="radius button" Font-Bold="true" style=" height:53px" />
    </center>
    </div>
    </form>
</body>
</html>
