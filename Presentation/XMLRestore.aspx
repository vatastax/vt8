<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XMLRestore.aspx.cs" Inherits="Presentation_XMLRestore" %>
<%@ Register Src="../SubUserMenu_Employer.ascx" TagName="empmenu" TagPrefix="emp" %>
<%@ Register Src="../SubUserMenu_Asset.ascx" TagName="property" TagPrefix="house" %>
<%@ Register Src="MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="../UserControls/PopupControl.ascx" TagName="pop" TagPrefix="popup" %>
<%@ Register Src="../UserControls/ImportBalanceSheet.ascx" TagName="ImpBalance" TagPrefix="usr" %>
<%@ Register Src="~/UserControls/header.ascx" TagName="menuheader" TagPrefix="header" %>
<%@ Register Src="~/UserControls/menunew.ascx" TagName="menu" TagPrefix="mm" %>
<%@ Register Src="~/Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="~/UserControls/FileUploadDirectoryCtrk.ascx" TagPrefix="fileupload" TagName="fu"  %>


<!DOCTYPE html >
<html class="no-js" lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="Scripts/jquery_scripts.js"></script>
      <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <!--jsss-->
    <link href="gridstyle.css" rel="Stylesheet" type="text/css" />
    <title>Control Panel</title>
   
    <link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="../foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
    <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
    <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../ITRStylesheet/styles/tabstrip.js" type="text/javascript"></script>
    <%-- <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />--%>
 <%--   <link href="../css/new_button.css" rel="stylesheet" type="text/css" />--%>
     <link href="../css/box_style.css" rel="stylesheet" type="text/css" />

    <link rel="icon" type="image/png" href="../images/fevicon.png" />
    <link rel="shortcut icon" type="image/png" href="../images/fevicon.png" />
   <script type="text/javascript">
       $(document).ready(function () {
           pop(); //To set Grid of popup setings
           CheckRowCheckBoxes(); //Popup Div Function
           Fileupload(); //function to provide event for "My Files" link
           $("#btnmenu").click(function () {
               $("#divmenu").slideToggle();
           });

       });
    </script>
   
    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnInsert").click(function () {
                if (($("#txtSTD").val().length != 0 || $("#txtPhone").val().length) != 0) {
                    if (($("#txtSTD").val().length + $("#txtPhone").val().length) != 10) {

                        alert("Length of std and phone should be 10 digits");
                        var len = ("txtSTD").val().length + ("txtPhone").val().length;
                        //alert(len);

                    }
                    else {

                    }
                }
            });
        });

      
    </script>

    <script src="../Popup/jquery.min.js" type="text/javascript"></script>
    <script src="../Popup/jquery-ui.js" type="text/javascript"></script>
    <link href="../Popup/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPopup(message) {
            //            $(function () {
            $("#dialog").html(message);
            //                $("#dialog").html(document.getElementById('pnlRestore').value);
            var title="";
            if (message == "ITR Submitted Successfully!!")

                title = "ITR Submission";
            else
               title = "Error in ITR XML Generation!!";
            $("#dialog").dialog({
                title: title,
                width: 'auto',
                height: 'auto',
                minHeight: 'auto',
                buttons: {
                    OK: function () {
                        $(this).dialog('close');
                    }

                },
                modal: true
            });
            return false;
            //            });

        };
    </script>
 
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

        function enableDOB() {
            try {
                document.getElementById('txtdob_MaskedEditExtender_ClientState').disbaled = 'false'; //.removeAttribute('Enabled');
            }
            catch (e) { alert(e); }
        }
    </script>
    <link rel="icon" type="image/png" href="../images/fevicon.png" />
    <link rel="shortcut icon" type="image/png" href="../images/fevicon.png" />
    <script src="js/jquery-1.10.0.min.js" type="text/javascript"></script>
    <link href="../css/box_style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="Scripts/common.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#Details').css("display", "block");
        $('#ass').click(function () {
            //alert('salary');
            $('#Details').slideToggle();
        });
        $("#btn1").click(function () {
            try {
                $("#divPop").dialog({
                    title: 'Are You Sure',
                    width: 'auto',
                    height: 'auto',
                    minHeight: '0',
                    modal: true,
                    buttons: { Yes: function () {
                        window.location = "SignatoryDetails.aspx"
                    }

                    }
                });
            }
            catch (e) { alert(e); }
        });
    });
         </script>
<script type="text/javascript">
    function openDialogXML() {
        try {
            getConstVal(document.getElementById('hdnNameID').value, 1120);
            document.getElementById('btn1').click();
        }
        catch (e) { alert(e); }
    }


    function SaveAssessee() {
        try {
            //document.getElementById('Submenu2_aProfile').click();
            window.location = 'Main.aspx';
            //            $(document).ready(function ($) {
            //                $('#Submenu2_aProfile').click();
            //            });
        } catch (e) { alert(e); }
    }
</script>



    <%---------------------Tooltip Grid -------------------------%>
    <link href="../css/tooltip.css" rel="stylesheet" type="text/css" />
 
</head>
<body onload="loadPage();" style="height: 600px; ">
    <%--  onunload="HandleClose(0)">--%>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" >
    </asp:ScriptManager>
    <%--------------------nishu 14-3-2016 --------------------------%>
    <div class="row show-for-small-only" style="background-color: White; margin-top: -20px">
       
        <div class="small-9 columns">
         
            <a href="Default.aspx">
                <img src="../images/logo2.png" style="width: 180px; height: auto" /></a>
        </div>
        <div class="small-3 columns text-right">
            <img src="../images/menu1.JPG" id="btnmenu" style="margin-top: 15px; width: 40px;
                height: 40px" />
        </div>
        <div class="row hidden-for-large hidden-for-medium" id="divmenu" style="display: none">
            <div class="large-12 columns">
                <mob:menu ID="mob1" runat="server" />
            </div>
        </div>
        <%----------------show username on mobile menu --------------------%>
        <div class="row show-for-small-only">
            <br />
            <div class="large-12 columns text-right">
                Welcome <span style="color: Black; font-family: 'Open Sans','sans-serif'; font-size: 15px;
                    font-weight: bold; color: #008CBA; text-transform: capitalize">
                    <asp:Literal ID="ltUser" runat="server" /></span> <a href="logout.aspx">[Logout]
                </a>
            </div>
        </div>
        <%----------------show username on mobile menu --------------------%>
    </div>
    <div class="row show-for-small-only">
        <div class="large-12 columns ">
            <mob2:mobmenu ID="mobmenu" runat="server" />
        </div>
    </div>
    <header:menuheader ID="header" runat="server"></header:menuheader>
  
    <div class="large-3 medium-3 columns  " style="left: 0; padding: 0; width: 300px">
        <asp:UpdatePanel ID="Upleft" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="ass" class="show-for-large-only" style="width: 242px; background-color: #565656;
                    -webkit-border-radius: 4px; -moz-border-radius: 4px; border-radius: 4px; padding: 3px;
                    -moz-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); -webkit-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                    box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); text-align: center; -webkit-border-radius: 4px;
                    -moz-border-radius: 4px; border-radius: 4px; padding: 3px; -moz-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                    -webkit-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                    margin-left: 3px">
                    <span style="color: White">Assessee Details [<asp:LinkButton ID="lbtnEditProf" runat="server" Text="Edit" OnClick="lbtnEditProf_Click" ToolTip="Click this link to Change Current Profile Details" style="font-size:13px" ForeColor="White"></asp:LinkButton>]</span>
                </div>
                <div id="Details" class="hidden-for-small-only" style="font-family: 'Open Sans', sans-serif;
                    width: 290px; display: none">
                    <sub:submenu ID="Submenu2" runat="server" />
                </div>
                <div id="dd" style="overflow-y: auto; height: 475px; width: 265px" class="hide-for-small-only">
                    <mm:menu ID="menu1" runat="server"></mm:menu>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
          <script type="text/javascript" src="Scripts/common.js"></script>
    </div>
    <div class="large-9 medium-9 columns " style="padding-left: 0;">
    <br />
   <center>
        <div id="divErr2" runat="server" class="login-wrap2" style="margin-top: 40px;">
            <asp:Literal ID="ltTitleSub" runat="server"></asp:Literal>
            
            <a id="AFinish" runat="server" href="#" onclick="SaveAssessee();" class="radius button">Finish</a>
            <asp:GridView ID="gvError" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvError_RowDataBound">
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
            Error Description
            </HeaderTemplate>
            <ItemTemplate>
            <asp:LinkButton ID="lbtnErr" runat="server" Text='<%# Eval("particular") %>' PostBackUrl='<%# "manageLinking.aspx?VType=" + Eval("vtype") + "&tab=" + Eval("tab") %>'></asp:LinkButton>            
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            </asp:GridView>
            <asp:Panel ID="pnlRestore" runat="server" Width="400px" style="display:none;">
                <span style="color: Black; font-family: 'Open Sans','sans-serif'; margin-left: -72px;
                    font-size: xx-large; font-size: 15px; font-weight: bold; text-transform: uppercase;
                    color: #ef5845; text-decoration: underline">
                    <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                </span>
                <div class="form">
                    <asp:FileUpload ID="fup1" runat="server" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Upload" CssClass="radius button"
                        OnClick="btnSubmit_Click" Style="left: -66px; border-radius: 4px" />
                </div>
            </asp:Panel>
            <div id="dialog" style="display:none; max-height:100px;">
                <div>
                    <asp:Panel ID="pnlGen" runat="server" Visible="false" CssClass="panel">
                        &nbsp;
                    </asp:Panel>
                </div>
            </div>
            <%--  <div id="dialog_Signatory">
        <div>
            
            <SDet:signatory ID="sDet1" runat="server" />
        </div>
    </div>--%>
        </div>
        <%--Enter Assessment Year: <asp:TextBox ID="txtAY" runat="server"></asp:TextBox>
    <br />--%>
    </center>
      </div>
    
 <div  id="divPop" style="display: none">                          
<p>You have <span id="divAmt"></span> . Do you want to proceed?</p>
<asp:Label ID="Label8" runat="server" ForeColor="Red" Font-Bold="True" Text="You have 25000 amount payable. Do you want to proceed? "
    Visible="False"></asp:Label>
    <div style="display:none">
    <asp:Button ID="Button12" runat="server" Text=" Yes " />
    &nbsp;
    <asp:Button ID="Button13" runat="server" Text=" No " />
    </div>   
    </div>



 <input type="button" value="click me" id="btn1" style="display:none;" />

    <asp:HiddenField ID="hdnXML" runat="server" />
    <asp:HiddenField ID="hdnNewXML" runat="server" />
    <asp:HiddenField ID="hdnRestore" runat="server" />
    <asp:HiddenField ID="hdnNameID" runat="server" />

    <%-- Files Popup --%>
   <div id="popupdiv1" style="width: auto; display:none; min-height: 0px; height: 62.04px;position: absolute;top: 15%;
        left: 25%;
        width: 52%;
        height: 45%;
        padding: 16px;
       
        background-color:white;
        z-index:1002; " class="ui-dialog-content ui-widget-content ui-corner-all">
<%--  <div class="ui-dialog ui-widget ui-widget-content ui-corner-all">--%>
 <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix" style="    padding: .2em 1em;
    position: relative;">
 <span class="ui-dialog-title" style="    font-weight: bold;
    font-size: 19px;">Upload Files &nbsp;<span style="color:white; font-size:12px;">(Extensions allowed: pdf,jpg,gif,png,doc,docx,xls,xlsx,xml,csv,txt,zip,rar)</span></span><a id="close" href="#"><span style="    font-weight: bold;
    font-size: 19px;">X</span></a>
 </div>

 <p>
 <% if (!Request.Url.ToString().Contains("Profile"))
       {  %>
<fileupload:fu ID="fu1" runat="server" />
<%} %>
 </p>
 <%--</div>--%>
 
 </div>
<div  id="BlackContent" style="display:none;background-color: #101010; 
    filter: alpha(opacity=70); 
    opacity: .30;
    width:100%;
    height:800px;
    z-index:400;
    position:absolute;
    top:0;
    left:0;  "></div>
    </form>
</body>
</html>