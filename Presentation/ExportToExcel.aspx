<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportToExcel.aspx.cs" Inherits="Presentation_ExportToExcel" %>
<%@ Register Src="../UserControls/ExportToExcel.ascx" TagName="Export" TagPrefix="exp" %>
<%@ Register Src="../menu_header.ascx" TagName="menuheader" TagPrefix="header" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html class="no-js" lang="en">
<head id="Head1" runat="server">
    <script type="text/javascript">
    

    function get_PB()
    {

    }
    function submitIt() {
        try
        {
            window.location = 'http://192.168.1.202/Presentation/Salary.aspx?VType=40&sd=dn';// window.URL.toString() + "&sd=dn";
        }
        catch (e) { alert(e);}
        <%--document.getElementById('<%= hdnSD_Data.ClientID %>').value = 'done';
        document.getElementById('form1').submit();--%>
        //document.getElementById('btnSubmitSignatory').click();
    }
        function backIt() {
        try
        {
            window.location = 'http://192.168.1.202/Presentation/Salary.aspx?VType=40';// window.URL.toString() + "&sd=dn";
        }
        catch (e) { alert(e);}
</script>
<link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="Scripts/common.js"></script>
    <script type="text/javascript" src="jquery.min.js"></script>
    <!--jsss-->

    <link href="gridstyle.css" rel="Stylesheet" type="text/css" />
    <title>Control Panel</title>
  
   <!--Master javascript file-->
        <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <!--Master javascript file-->

     <!--master style sheet-->
    <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->


    <!-- Following code is for Tab Controls -->

  <%--  <link href="StyleSheet2.css" rel="stylesheet" type="text/css" />--%>
    
    <link rel="icon" type="image/png" href="../images/fevicon.png"/>
<link rel="shortcut icon" type="image/png" href="../images/fevicon.png"/>
<script src="../Presentation/jquery.min.js" type="text/javascript"></script>
           <%--<script src="../js/jquery.ui.min.js" type="text/javascript"></script>--%>
  
    <%--<link href="../ITRStylesheet/styles/jquery-ui.css" rel="stylesheet" type="text/css" />--%>

    <%------------------------------Jquery Validation ------------------------------%>
     <%--<link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />--%>

<style type="text/css">
    #hrnew
    {
        height: 2px;
        background-image: -webkit-linear-gradient(left, rgba(0, 0, 0, 1), rgba(0, 0, 0, 1), rgba(0, 0, 0, 1));
        opacity: 1.0;
        margin-top: 1px;
    }
    
    .headsize
    {
        font-size: 15px;
    }
    
    
    .btnstyle
    {
        background: #25A6E1;
        background: -moz-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
        background: -webkit-gradient(linear,left top,left bottom,color-stop(0%,#25A6E1),color-stop(100%,#188BC0));
        background: -webkit-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
        background: -o-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
        background: -ms-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
        background: linear-gradient(top,#25A6E1 0%,#188BC0 100%);
        filter: progid: DXImageTransform.Microsoft.gradient( startColorstr='#25A6E1',endColorstr='#188BC0',GradientType=0);
        padding: 8px 13px;
        color: #fff;
        font-family: 'Helvetica Neue' ,sans-serif;
        font-size: 17px;
        border-radius: 4px;
        -moz-border-radius: 4px;
        -webkit-border-radius: 4px;
        border: 1px solid #1A87B9;
    }
</style>

<%--StyleSheets for information box - jaipal--%>

<script src="js/jquery-1.10.0.min.js" type="text/javascript"></script>
<script src="js/index.js"></script>
<link href="../css/box_style.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  <div class="row hide-for-small-only">
    <div class="large-12 columns">
   
    <header:menuheader ID="header1" runat="server" />
    </div>
    </div>
     <div class="row ">
    <div class="large-12 columns">
   
     <exp:Export ID="exp" runat="server" />
    </div>
    </div>
  
    </form>
</body>
</html>
