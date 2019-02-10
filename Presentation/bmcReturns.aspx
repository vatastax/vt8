<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bmcReturns.aspx.cs" Inherits="Presentation_bmcReturns" %>


<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %> <%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../mobilemenu2.ascx" TagPrefix="mob1" TagName="menu1" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../Presentation/MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="~/menu_header.ascx" TagName="menuheader" TagPrefix="header" %>


<!DOCTYPE html >

<html class="no-js" lang="en" >
<head id="Head1" runat="server">
   <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
 <meta charset="utf-8" />
<title>Control Panel</title>
 <script src="../js/jquery.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="../scripts/menu.js"></script> 
   <script type="text/javascript" src="Scripts/common.js"></script>

 <%--<script src="../foundation-5.5.0/jquery.min.js" type="text/javascript"></script>
 <script src="../scripts/jquery.js" type="text/javascript"></script>
  <script src="../foundation-5.5.0/jquery.min.js" type="text/javascript"></script>
    <script src="../scripts/jquery-1.3.2.min.js" type="text/javascript"></script>--%>

<%--<link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />--%>

<%--<script type="text/javascript" src="../scripts/menu.js"></script> --%>

    <%--<link href="../foundation-5.5.0/css/foundation.min.css" rel="stylesheet" type="text/css" />
    <link href="../styles/StyleSheet.css" rel="stylesheet" type="text/css" />--%>
  
    <%--<script src="../foundation-5.5.0/js/foundation.min.js" type="text/javascript"></script>--%>

    <%--<link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />--%>

       <%--<script src="../js/jquery.min.js" type="text/javascript"></script>--%>

    <!--Master javascript file-->
        <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <!--Master javascript file-->

    <!--master style sheet-->
    <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->


<%--    <script type="text/javascript">
        $(document).ready(function () {

            $("#hide").click(function () {
                $("#div1").slideToggle();
            });

        });
</script>--%>
<%-- <script type="text/javascript">
     $(document).ready(function () {

         $("#btnmenu").click(function () {
             $("#divmenu").slideToggle();
         });

     });
</script>--%>
 <script src="js/jquery-1.10.0.min.js" type="text/javascript"></script>

<link rel="icon" type="image/png" href="../images/fevicon.png"/>
<link rel="shortcut icon" type="image/png" href="../images/fevicon.png"/>
<link href="../css/tooltipbox.css" rel="stylesheet" type="text/css" />
<link href="../css/box_style.css" rel="stylesheet" type="text/css" />
<link href="../css/tooltipboxdown.css" rel="stylesheet" type="text/css" />


<script language="javascript" type="text/javascript">
  //<![CDATA[
    function HandleClose() {
        //alert("Killing the session on the server!!");
        PageMethods.AbandonSession();
    }
   //]]>


</script>
<script src="../js/ie_compatibility/selectivizr-1.0.3b.js" type="text/javascript"></script>
<script src="../js/ie_compatibility/html5shiv.js" type="text/javascript"></script>
<script src="../js/ie_compatibility/es5-shim.min.js" type="text/javascript"></script>
<script src="../js/ie_compatibility/nwmatcher-1.2.5-min.js" type="text/javascript"></script>
<script src="../js/ie_compatibility/respond.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function CheckAllEmp(Checkbox) {
        var GridVwHeaderChckbox = document.getElementById("<%=gvReturns.ClientID %>");
        for (i = 1; i < GridVwHeaderChckbox.rows.length; i++) {
            GridVwHeaderChckbox.rows[i].cells[1].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
        }
    }
</script>
</head>
<body><%-- onunload="HandleClose(0)"> --%>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>


    <%--<asp:Button ID="btnTesting" runat="server" Text="Test Here" OnClick="btnTesting_Click" />--%>

    <div class="row hide-for-small-only">
    <div class="large-12 columns">
    <%--Add by nishu for header 11/4/2015 --%>
    <header:menuheader ID="header1" runat="server" />
    </div>
    </div>
   <%-------------------Breadcrumps -----------------------%>
  <div class="row">
     <div class="large-12 columns hidden-for-small-only">
         <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
             Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" NodeStyle-Font-Bold="false" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
     </div>
   </div>
    <div class="row">
        <div class="large-12 columns hide-for-small-only">
         
          <%
    if(Session["ay"]!=null || Session["Project"].ToString()=="stax")
    {
    %>

<main:mainmenu ID="mm1" runat="server"  />
<%
    }
    else
    {
    %>

<main2:mainmenu2 ID="mm12" runat="server"  />
<%
    }
    %>
         
         
        </div>
      </div>
   
      
  <div class="row show-for-small-only" style="background-color: #F8F8F8">
  <br />
        <div class="small-9 columns">
        <a href="Default.aspx">
            <img src="../images/logo2.PNG" style="width:180px; height:auto" /></a>
        </div>
        <%----------------show username on mobile menu --------------------%>
     <div class="row show-for-small-only">     
     <div class="large-12 columns text-right">
      Welcome <span style="font-weight:bold;color:#008CBA;  text-transform:capitalize"><asp:Literal ID="ltUser" runat="server" /></span>
         
      <a href="logout.aspx">
 [Logout]
 </a>
     </div>
     </div>
     <%--show breadcrumps in all views nishu 8/4/2015--%>
    <div class="row" >
    <br />
    <div class="large-12 columns" style="margin-top:-20px">
     <asp:SiteMapPath ID="SiteMapPath3" runat="server" 
              Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" NodeStyle-Font-Bold="false" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource3" runat="server" />
    </div>
    </div>
            <%--<div class="small-3 columns text-right">
          
            <img src="../images/menu1.JPG" id="btnmenu" style="margin-top:15px;width:40px; height:40px"/>
           
        </div>--%>
  </div>

   <%-------------------Breadcrumps -----------------------%>
  <div class="row">
     <div class="large-12 columns show-for-small-only">
         <asp:SiteMapPath ID="SiteMapPath2" runat="server" 
             Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true" NodeStyle-Font-Bold="false" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
     </div>
   </div>

    <div class="row show-for-small-only" id="divmenu" style="display:none">
      
      <div class="large-12 columns">
          
          <%
    if(Session["ay"]!=null)
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
       <div class="row show-for-small-only" style="color:White" >
        <div class="large-12 columns">
          <mob2:mobmenu id="mobmenu" runat="server" />
                <%--<img src="../images/details.JPG" />--%>
            
        </div>
    </div>
    <div class="row show-for-medium-only" style="color:White" >
        <div class="large-12 columns">
           <mob3:mediummenu id="medmenu" runat="server" />
         
        </div>
    </div>
    <div class="medium-12 columns" >
   <div class="login-wrap" style="width:980px;margin-top:52px;margin-left:245px">
   <h2 style="font-size:20px">Assessee Allocation</h2>
   <hr />
   <asp:GridView ID="gvReturns" runat="server" AutoGenerateColumns="false" Width="80%">
   <Columns>
   <asp:TemplateField>
   <HeaderTemplate>
   <table width="100%">
   <tr>
   <td style="width:15%;">
   No#
   </td>
   <td style="width:30%;">
   Name of Assessee
   </td>
   <td style="width:20%;">
   PAN
   </td>
   <td style="width:15%;">
   ITR
   </td>
   <td style="width:20%;">
   AY
   </td>
   </tr>
   </table>
   </HeaderTemplate>
   <ItemTemplate>
   <table width="100%">
   <tr>
   <td style="width:15%;">
   <asp:Label ID="lblNo" runat="server" Text='<%# Eval("id") %>'></asp:Label>
   </td>
   <td style="width:30%;">
   <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
   </td>
   <td style="width:20%;">
   <asp:Label ID="Label2" runat="server" Text='<%# Eval("PanNo") %>'></asp:Label>
   </td>
   <td style="width:15%;">
   <asp:Label ID="Label3" runat="server" Text='<%# Eval("ReturnType") %>'></asp:Label>
   </td>
   <td style="width:15%;">
   <asp:Label ID="lblAY" runat="server" Text='<%# Eval("AY") %>'></asp:Label>
   </td>
   </tr>
   </table>
   </ItemTemplate>
   </asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="40px">
    <HeaderTemplate>
        <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick="CheckAllEmp(this);" />
    </HeaderTemplate>
    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    <ItemTemplate>
    <asp:Label ID="lblNameID" runat="server" Text='<%# Eval("NameID") %>' style="display:none;"></asp:Label>
        <asp:Label ID="lblID" runat="server" Text='<%# Eval("id") %>' style="display:none;"></asp:Label>
        <asp:CheckBox ID="chkAss" runat="server"></asp:CheckBox>
    </ItemTemplate>
</asp:TemplateField>

   </Columns>
   </asp:GridView>
   <div class="form">
   <asp:Button ID="btnAllocate" runat="server" style="border-radius:10px;" Text="Prcess XML" CssClass="button" OnClick="btnAllocate_Click" />
   
   </div>
   </div>
   </div>
   
      
    <div class="row hidden-for-large hidden-for-medium" id="div1" style="display:none">
     <div class="large-12 columns" >
       <sub:submenu ID="Submenu1" runat="server" />
     </div>

     </div>
    <div class="row">
    
   <%-- <div class="large-3 columns show-for-large-only">
        <sub:submenu ID="sub1" runat="server" />
        </div>
     --%>
        <div class="large-12 columns" >   
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                         <%--<mob3:mediummenu id="Mediummenu1" runat="server" />--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
     
        </div>
         
      </div>
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
    <div class="row" style="bottom:0;  margin-left: auto;margin-right: auto;margin-top: 100px;" >
      <hr/>       
      <div class="large-12 columns" >
        <div class="large-6 columns" >
     
          © 2015 Vatas Infotech Pvt.Ltd.
          </div>
        <%--<div class="large-6 columns text-right">
            
                <a href="https://www.facebook.com/echarteredaccountants" target="_blank"><img src="../images/fb.png"></a>
                <a href="http://www.twitter.com/ECAccountant" target="_blank"><img src="../images/twitter.png"></a>
                <a href="https://in.linkedin.com/pub/vatas-infotech/b9/264/a82" target="_blank"><img src="../images/LINKEDIN1.PNG"></a>
                <a href="https://plus.google.com/u/0/b/108616341946641442746/108616341946641442746" target="_blank"><img src="../images/google.png"></a>
             
            </div>--%>
           </div>     
     </div>
  <div class="hide-for-small-only hide-for-medium-only">
 <menu:side ID="Sidemenu" runat="server" />
 </div>
  </form>
</body>
</html>


