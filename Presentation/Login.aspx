<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Presentation_Login"  %>

<!DOCTYPE html>
<html class="no-js" lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>The Interactive Platform for free e-filing Income Tax Returns in India</title>

<script type="text/javascript" src="jscapslock.js"></script>   
  
    <%--<script src="../scripts/jquery.js" type="text/javascript"></script>--%>
  
    <%--<link href="../styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />--%>
  
    <%--<script type="text/javascript" src="../scripts/menu.js"></script>--%>
   
    <%--<link href="../styles/foundation.min.css" rel="stylesheet" type="text/css" />--%>

  <%--  <script src="../scripts/modernizr.js" type="text/javascript"></script>
    <script src="../scripts/foundation.min.js" type="text/javascript"></script>--%>
  
    <%--<link href="../Stylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />
   
    <link href="../Stylesheet/buttonstyle.css" rel="stylesheet" type="text/css" />--%>

  <%--  <script src="../js/modernizr.custom.34978.js" type="text/javascript"></script>--%>
   
    <%--<link href="../Stylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />--%>


    <!--Master javascript file-->
        <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <!--Master javascript file-->

     <!--master style sheet-->
    <link href="../style_folder/ItrLoginStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
<%--<style type="text/css">
.shwPWFont
{
   font-family: inherit;
}
</style>--%>
    <script type="text/javascript">
        //Add the javascript so we know where we want the enter key press to go

        function doClick(buttonName, e) {

            //the purpose of this function is to allow the enter key to 
            //point to the correct button to click.
            var key;

            if (window.event)
                key = window.event.keyCode;     //IE
            else
                key = e.which;     //firefox

            if (key == 13) {
                //Get the button the user wants to have clicked
                var btn = document.getElementById(buttonName);
                if (btn != null) { //If we find the button click it
                    btn.click();
                    event.keyCode = 0
                }
            }
        }
    </script>
<%--    <!------Restrict hash in name ------>
    <script type="text/javascript">
        function RestrictSpaceSpecial(e) {
          
    var k;
//    document.all ? k = e.keyCode : k = e.which;
    if (e.keyCode == 35) {
        alert('# not allowed');
        return false;

    }
}</script>--%>
<script type="text/javascript">
    function CheckSpecialChar(evt) {

        var charCode = (evt.which) ? evt.which : event.keyCode

        if (charCode == 35) {

            //        document.getElementById("divErrMsg").innerHTML = "Value Should Be Numeric!!";
            //ShowErrMsg();
            //alert(charCode);
            //alert('Value Should Be Numeric!!');
            return false;
        }
        return true;
    }
</script>
<!------nishu 8/8/2015 ----->
<script type="text/javascript">
    $(document).ready(function () {
        $('#txtName').bind('copy paste cut', function (e) {
            e.preventDefault(); //disable cut,copy,paste
        });
    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#txtPassword').bind('copy paste cut', function (e) {
            e.preventDefault(); //disable cut,copy,paste
        });
    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#txtPasswordConfirm').bind('copy paste cut', function (e) {
            e.preventDefault(); //disable cut,copy,paste
        });
    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#txtSecAnswer').bind('copy paste cut', function (e) {
            e.preventDefault(); //disable cut,copy,paste
        });
    });
</script>
    <style type="text/css">
        

</style>
    <script type="text/javascript">
        function EnableButton() {
            if (document.getElementById('<%=btnCreateUser.ClientID %>').disabled)
                document.getElementById('<%=btnCreateUser.ClientID %>').disabled = false;
            else
                document.getElementById('<%=btnCreateUser.ClientID %>').disabled = true;
        }

        function page_Ld() {
            //alert(document.getElementById('hdnActivation').value);

        }
    </script>
        <link rel="icon" type="image/png" href="../images/fevicon.png"/>
<link rel="shortcut icon" type="image/png" href="../images/fevicon.png"/>
 <script language="javascript" src="../js/jquery.js" type="text/javascript"></script>
<script language="javascript" src="../js/passwordStrengthMeter.js" type="text/javascript"></script>

<script type="text/javascript">
    jQuery(document).ready(function () {

        // $('#<%=txtUserID.ClientID %>').keyup(function () { $('#result').html(passwordStrength($('#<%=txtPassword.ClientID %>').val(), $('#<%=txtUserID.ClientID %>').val())) })
        $('#<%=txtPassword.ClientID %>').keyup(function () { $('#result').html(passwordStrength($('#<%=txtPassword.ClientID %>').val(), $('#<%=txtUserID.ClientID %>').val())) })
    })
    function showMore() {
        $('#more').slideDown()
    }
</script> 

 
<%--StyleSheets for login and signup page - jaipal--%>
    <link href="../css/loginstyle.css" rel="stylesheet" type="text/css" />

    <link href="../css/loginfonts.css" rel="stylesheet" type="text/css" />


<%--StyleSheets for information box - jaipal--%>

<script src="js/jquery-1.10.0.min.js" type="text/javascript"></script>
<script src="js/index.js"></script>
<link href="../css/box_style.css" rel="stylesheet" type="text/css" />
<%--------------popup code for message ----------------%>
 <script src="../Popup/jquery.min.js" type="text/javascript"></script>
    <script src="../Popup/jquery-ui.js" type="text/javascript"></script>
    <link href="../Popup/jquery-ui.css" rel="stylesheet" type="text/css" />
    <%--    <script type="text/javascript">
            $("[id*=btnLogin]").live("click", function () {
//                $("div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all").css("width","100px");
                var hv = $("#" + '<%= hdnCheck.ClientID %>').val();
                if (hv == "Invalid") {
                    $("#modal_dialog").dialog({
                        title: "Error Message",
                        buttons: {
                            Close: function () {
                                $(this).dialog('close');
                            }
                        },
                        modal: true
                    });
                    return false;
                }
            });
    </script>--%>
     <!--[if lt IE 8]>
<script type="text/javascript" src="../js/ie_compatibility/placeholder.min.js"></script>
     <script type="text/javascript" src="../js/ie_compatibility/newhtml5shiv.js"></script>
<script src="../js/ie_compatibility/html5shiv.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/nwmatcher-1.2.5-min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/respond.min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/selectivizr-1.0.3b.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/es5-shim.min.js" type="text/javascript"></script>
<![endif]-->
<!--[if lt IE 9]>
<script type="text/javascript" src="../js/ie_compatibility/placeholder.min.js"></script>
<script type="text/javascript" src="../js/ie_compatibility/newhtml5shiv.js"></script>
<script src="../js/ie_compatibility/html5shiv.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/nwmatcher-1.2.5-min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/respond.min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/selectivizr-1.0.3b.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/es5-shim.min.js" type="text/javascript"></script>
<![endif]-->
<!--[if lt IE 10]>
<script type="text/javascript" src="../js/ie_compatibility/placeholder.min.js"></script>
<script type="text/javascript" src="../js/ie_compatibility/newhtml5shiv.js"></script>
<script src="../js/ie_compatibility/html5shiv.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/nwmatcher-1.2.5-min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/respond.min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/selectivizr-1.0.3b.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/es5-shim.min.js" type="text/javascript"></script>
<![endif]-->
<script type="text/javascript" src="../js/ie_compatibility/placeholder.min.js"></script>
    <script type="text/javascript" src="../js/ie_compatibility/newhtml5shiv.js"></script>
<script src="../js/ie_compatibility/html5shiv.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/nwmatcher-1.2.5-min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/respond.min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/selectivizr-1.0.3b.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/es5-shim.min.js" type="text/javascript"></script>
</head>
<body >
    <form id="form1" runat="server" defaultbutton="btnLogin">
   <asp:HiddenField ID="hdnActivation" runat="server" />
   
    <div class="row show-for-small-only ">
    <div class="large-12 columns">
        
     <a href="../Default.aspx"><img src="../images/logo2.png" style="width:240px; height:auto" /></a>
    </div>
    </div>
    
      <div class="row show-for-small-only">
    <div class="large-6 columns">
    
    </div>
    <br />
    <div class="large-6 columns">
       <div class="nav-bar right">
                <ul class="button-group">
                    <li>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton3_Click" style="font-size:16px" >LOGIN&nbsp&nbsp</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton4_Click" style="font-size:16px" >SIGN-UP</asp:LinkButton>
                    </li>
                </ul>
            </div>
    </div>
    </div>
    <br />
    <div class="row hide-for-small">
        
                   <div class="large-6 columns" >
         
            
        <%--<p class="headline"  > E-Chartered &nbsp;&nbsp;Accountants<p>Your Pocket <b>TAX</b> Manager</p> </p>--%>
       <a href="../default.aspx"><img src="../images/logo2.png" style="width:240px; height:auto" alt="logo" /></a>
  
  
  
        </div>
        <%--<div class="large-3 columns"></div>--%>
        
        <div class="large-6 columns text-right">
            <div class="nav-bar right">
                <ul class="button-group">
                    <li>
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" Font-Size="16px">LOGIN &nbsp</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" Font-Size="16px">&nbsp SIGN-UP</asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
   
    </div>
    <div class="row"  style="max-width: 30rem;">


 
        <div class="large-12 columns" role="content">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
          <%--  <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>--%>
                        <asp:MultiView ID="mltView" ActiveViewIndex="0" runat="server">
                        <asp:View ID="viewList" runat="server">
                        <fieldset>
                        <center>
                        <asp:Label ID="lblTopMsg2" runat="server" Text="Account Locked" ForeColor="Red" Font-Size="Larger" Visible="false"></asp:Label>
                        <asp:Label ID="lblTopMsg" runat="server" Text=" - Suspicious Account Login Attempt" Visible="false"></asp:Label>
                        <asp:Literal ID="ltMsgTop" runat="server"></asp:Literal>
                        </center>
                        <div class="row">
                        <div class="login">
		                    <div class="login-main">
		 		                <div class="login-top">
                                     <img src="../images/head-img.png" alt="user" />
                                     <h1>Login to Your Account</h1>
                                     <div>

                                         <asp:TextBox ID="txtLogin" runat="server" placeholder="Email ID" ToolTip="Enter Email ID" TabIndex="1" required autofocus autocomplete="off"></asp:TextBox>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtLogin"
                                         Display="Dynamic" ErrorMessage="Format Incorrect" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                     </div>

                                     <asp:UpdatePanel ID="ShwHidePw" runat ="server">
                                     <ContentTemplate>
                                     <div>
                                     <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" TabIndex="2" ToolTip="Enter Password" placeholder="Password" required autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="txtPwd" ErrorMessage="Password Required"></asp:RequiredFieldValidator>--%>
                                         <asp:CheckBox ID="chkShowPassword"  runat="server" oncheckedchanged="chkShowPassword_CheckedChanged" AutoPostBack="True" 
                                             />
                                             <asp:Label ID="shwPWlbl" runat="server" Text="Show Password"></asp:Label>
                                     </div>
                                     </ContentTemplate>
                                     </asp:UpdatePanel>

                                     <div>
                                     <asp:UpdatePanel ID="updCap" runat="server">
                                     <ContentTemplate>
                                      <%--<div class="login-bottom">
                                     Enter Security Code 
                                     </div>--%>
                                      <div>     <asp:TextBox ID="txtimgcode" runat="server" autocomplete="off" TabIndex="3" placeholder="Enter Security Code"></asp:TextBox>
                                        <asp:Image ID="imgCaptcha" runat="server" Width="120px" BorderWidth="1" style="border-radius: 10px;" BorderColor="LightGray" Height="40px" />
                                        <asp:ImageButton ID="ibtnCap" runat="server" ImageUrl="../images/refresh.png" OnClick="ibtnCap_Click" />
                                        <%--<asp:Image ID="Image1" runat="server" ImageUrl="CImage.aspx"/>--%>
                                        <p> <asp:Label ID="Label6" runat="server" Font-Bold="True" 
	                                    ForeColor="Red" Text=""></asp:Label>
                                        </p>
                                        </div>
                                     </ContentTemplate>
                                     </asp:UpdatePanel>
                                     </div>
                                     <div>
                                     <br />
                                        <asp:Button ID="btnLogin" ValidationGroup="gg" runat="server" TabIndex="4" Text="Login" OnClick="btnLogin_Click"/></div>
                                    
                                    <div class="login-bottom">
                                        <div class="login-para" style="float:left; font-size:13px;">
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Forgot Password</asp:LinkButton>
                                        </div>
                                        <div class="login-para" style="float:right; font-size:13px;">New User? 
                                        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton4_Click">SignUp</asp:LinkButton>
                                        </div>
                                        <div class="clear"> </div>
                                        </div>
                                     </div>
                                     
                            </div>
                        </div>
                        </div>
                        </fieldset>
                        </asp:View>
                        
                         <asp:View ID="NewUser" runat="server">
                         <fieldset style="background-color:#F8F8F8;">
                         
                            <div class="row">
                            <div class="login">
		                      <div class="login-main">
		 		                 <div class="login-top">
                                      <img src="../images/head-imgsignup.png" alt="user" />
                                 <%--<h1>Create your Account to proceed for Tax Filling for <span style=" background-color:#ffff00; color:black">BETA</span></h1>--%>
                                 <h1>Create your Account</h1>
                                 <%--<div>
                                    <asp:DropDownList ID="ddAcType" TabIndex="6" runat="server" CssClass = "login-ddl">
                                       <asp:ListItem Text="Account Type" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Individual" Value="Individual"></asp:ListItem>
                                    <asp:ListItem Text="Professional" Value="Professional"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="ddAcType" Display="Dynamic" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>--%>
                                <div>
                                    <asp:TextBox ID="txtName" runat="server" type="text" placeholder="Name" required TabIndex="1" onkeypress="return CheckSpecialChar(event);"  ></asp:TextBox>
                                    <%--<ajaxToolkit:FilteredTextBoxExtender ID="TextBox1_FilteredTextBoxExtender" 
            runat="server" Enabled="True" FilterMode="InvalidChars" InvalidChars="#" 
            TargetControlID="txtName">
        </ajaxToolkit:FilteredTextBoxExtender>--%>
        
                                </div>
                                
                                <%--<div>
                                
                                    <asp:TextBox ID="txtPAN" runat="server" MaxLength="10"
                                        type="text" placeholder="Enter your PAN" TabIndex="2" required></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPAN"
                                        ErrorMessage="Wrong PAN" Display="Dynamic" ValidationExpression="\w{5}\d{4}\w{1}?"></asp:RegularExpressionValidator>
                                
                                </div>--%>
                                <asp:UpdatePanel ID="updEml" runat="server">
                                <ContentTemplate>
                                <div>
                                    <asp:TextBox ID="txtUserID" runat="server" TabIndex="3" type="text" placeholder="Email" required AutoPostBack="true" OnTextChanged="txtUserID_TextChanged"></asp:TextBox>
                                    <asp:Label ID="lblEmailComfirmation" runat="server" ForeColor="Red" Text="Email Already Exists!!" Visible="false" ></asp:Label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserID"
                                        ErrorMessage="Format Incorrect" Display="Dynamic"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                
                               <%-- <asp:UpdatePanel ID="ShwHidePwSignUp" runat ="server">
                                     <ContentTemplate>--%>
                                        <div>
                                    <asp:TextBox ID="txtPassword" TabIndex="4" runat="server" TextMode="Password" type="text" placeholder="Password" onkeypress="return CheckSpecialChar(event);" required></asp:TextBox>
                                      <label style="color:green" id="result"></label>
                                        <div id='more' style="display:none;background-color:#EEEEEE;padding:10px;margin:10px;width:600px">

                                        <ul type="disc">
                                          <li dir="ltr">If the password matches the username then <strong>BadPassword</strong></li>
                                          <li dir="ltr">If the password is less than 4 characters then <strong>TooShortPassword</strong></li>
                                          <li dir="ltr"><strong>Score += password length * 4</strong></li>
                                          <li dir="ltr"><strong>Score -= repeated characters in the password</strong> ( 1 char repetition )  </li>
                                          <li dir="ltr"><strong>Score -= repeated characters in the password</strong> ( 2 char repetition )  </li>
                                          <li dir="ltr"><strong>Score -= repeated characters in the password</strong> ( 3 char repetition )  <span dir="rtl"> </span></li>
                                          <li dir="ltr"><strong>Score -= repeated characters in the password</strong> ( 4 char repetition )  <span dir="rtl"> </span></li>
                                          <li dir="ltr">If the password has 3 numbers then <strong>score += 5</strong></li>
                                          <li dir="ltr">If the password has 2 special characters then <strong>score       += 5</strong></li>
                                          <li dir="ltr">If the password has upper and lower character then <strong>score       += 10</strong></li>
                                          <li dir="ltr">If the password has numbers and characters then <strong>score       += 15</strong></li>
                                          <li dir="ltr">If the password has numbers and special characters then <strong>score += 15</strong><span dir="rtl"> </span></li>
                                          <li dir="ltr">If the password has special characters and characters       then <strong>score += 15</strong><span dir="rtl"> </span></li>
                                          <li dir="ltr">If the password is only characters then <strong>score -= 10</strong></li>
                                          <li dir="ltr">If the password is only numbers then <strong>score -= 10</strong></li>
                                        </ul>
                                        <ul type="disc">
                                          <li dir="ltr">If score &gt; 100 then <strong>score = 100</strong></li>
                                        </ul>
                                        <p dir="ltr">Now  according to score we are going to decide the password strength</p>
                                        <ul type="disc">
                                          <li dir="ltr">If  0  &lt; score &lt; 34 then <strong>BadPassword</strong></li>
                                          <li dir="ltr">If  34 &lt; score       &lt; 68  then <strong>GoodPassword</strong></li>
                                          <li dir="ltr">If 68 &lt; score &lt; 100 then <strong>StrongPassword</strong></li>
                                        </ul>
                                        </div>

                                    <%--<asp:CheckBox ID="signupshowpw" Text="Show Password" runat="server" 
                                             oncheckedchanged="signupshowpw_CheckedChanged" AutoPostBack="True" 
                                             CssClass="shwPWFont" />--%>
                                </div>
                                <%--</ContentTemplate>
                                </asp:UpdatePanel>--%>
                                
                                   <div>
                                    <asp:TextBox ID="txtPasswordConfirm" runat="server" TabIndex="5" TextMode="Password" type="text"
                                        placeholder="Confirm Password" onkeypress="return CheckSpecialChar(event);" required></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic"  ControlToCompare="txtPassword"
                                        ControlToValidate="txtPasswordConfirm" Operator="Equal" ErrorMessage="Password Mismatch" ValidationGroup="gg1" ></asp:CompareValidator>
                                         <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic"  ControlToCompare="txtPassword"
                                         Operator="NotEqual" ControlToValidate="txtPasswordConfirm" style="color:Green" ErrorMessage="Password match" ValidationGroup="gg1"></asp:CompareValidator>
                                   </div>
                                   <br />
                                <%--<div>
                                    <asp:Label ID="Label12" runat="server" Text="Secret Question"></asp:Label>
                                </div>--%>
                                <div>
                                    <asp:DropDownList ID="ddlQuestions" TabIndex="6" runat="server" CssClass = "login-ddl">
                                        <asp:ListItem Value="0">Select secret Question</asp:ListItem>
                                        <asp:ListItem>Your mother Maiden Name?</asp:ListItem>
                                        <asp:ListItem>Your favorite Pet?</asp:ListItem>
                                        <asp:ListItem>Your first school Name?</asp:ListItem>
                                        <asp:ListItem>Your first Bike?</asp:ListItem>
                                        <asp:ListItem>Your nick name?</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ValidationGroup="gg1" ID="RequiredFieldValidator9" runat="server"
                                        ControlToValidate="ddlQuestions" Display="Dynamic" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                                
                                <div>
                                    <asp:TextBox ID="txtSecAnswer" TabIndex="7" runat="server" type="text" placeholder="Secret Answer" onkeypress="return CheckSpecialChar(event);" required></asp:TextBox>
                                </div>
                            <div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <%--<div class="login-bottom">
                                    Enter Security Code 
                                    </div>--%>
                                    <div>
                                        <asp:TextBox ID="txtimgcode2" runat="server" autocomplete="off" TabIndex="8" Placeholder="Enter Security Code" required></asp:TextBox>
                                        <asp:Image ID="imgCaptcha2" runat="server" Width="120px" BorderWidth="1" style="border-radius: 10px;" BorderColor="LightGray" Height="40px" />
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/refresh.png" OnClick="ibtnCap_Click" formnovalidate />
                                        <p> <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Text=""></asp:Label>
                                        </p>
                                    </div>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="login-bottom" style="font-size:10px">
                            <%--<asp:CheckBox ID="chkTerms" runat="server" Text="I accept <a href='../Terms_Conditions.aspx' target='_blank'>Terms & Conditions</a>"  onclick="javascript:EnableButton();"  AutoPostBack="true"  />--%>
                            <input type="checkbox" TabIndex="9" onclick="javascript:EnableButton();">&nbsp;&nbsp;I agree to the <a href='../Terms_Conditions.aspx' target='_blank'>Terms & Conditions</a> of<br />E-Chartered Accounts.com</input>
                            </div>
                            
                                <br />
                                <div>
                                    <%--<asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" class=" radius button" />--%>
                                   <script type="text/javascript">
                                       function checkPwfConf() {
                                           alert(document.getElementById('CompareValidator2').value);
                                       }
                                   </script>
                                    <asp:Button ValidationGroup="gg1" ID="btnCreateUser" TabIndex="10" runat="server" OnClick="btnCreateUser_Click" OnClientClick="checkPwfConf();"
                                        Text="Done" class="radius button" Enabled="false" Width="218" Height="45" />
                                 </div>
                             
                                 <div>
                                      <%-- <span style="font-size:10px;">By clicking Done, you are agreeing to</br>our <a href="../Terms_Conditions.aspx" target="_blank">Terms & Conditions</a> <span></span> --%>
                                </div>
                            
                        
                         <div style="text-align:right">
                            <span style=" font-size:12px;"><a href="../PrivacyPolicy.aspx" target="_blank">Privacy policy</a> | <a href="../Terms_Conditions.aspx" target="_blank">Terms & Conditions</a></span>
                            </div>
                            
                        </div>
                        </div>
                        </div>
                        </div>
                        
                        </fieldset>
                    </asp:View>

                        <asp:View ID="ForgotPassword" runat="server">
                       
                    <div class="login-wrap">
                    <h2>Recover your password !!!</h2>
                    <hr />
                    <div class="form" style="padding-left:15px;">
                            <div class="row">
                                <div class="large-5 columns">
                                    <asp:Label ID="Label3" runat="server" Text="User Name"></asp:Label>
                                </div>
                                <div class="large-7 columns">
                                    <asp:TextBox ID="txtUserName" runat="server" AutoPostBack="True" OnTextChanged="txtUserName_TextChanged"
                                        type="text"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="gg2" ID="RequiredFieldValidator5" runat="server"
                                        ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtUserName"
                                        Display="Dynamic" ErrorMessage="Format Incorrect"></asp:RegularExpressionValidator>--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-5 columns">
                                    <asp:Label ID="Label8" runat="server" Text="Secret Question"></asp:Label>
                                </div>
                                <div class="large-7 columns">
                                    <asp:TextBox ID="txtSecQuestion" runat="server" type="text" ReadOnly="True" Font-Names="Arial"
                                        ForeColor="Black"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-5 columns">
                                    <asp:Label ID="Label14" runat="server" Text="Secret Answer"></asp:Label>
                                </div>
                                <div class="large-7 columns">
                                    <asp:TextBox ID="txtAnswer" runat="server" type="text"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="gg2" ID="RequiredFieldValidator12" runat="server"
                                        ControlToValidate="txtAnswer" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-7 columns">
                               
                                    <asp:Button ValidationGroup="gg2" ID="Button1" runat="server" Text="Get Password"
                                        class="radius button" OnClick="Button1_Click" />
                                         </div>
                                <div class="large-5 columns">
                                        <asp:Button ID="Button2" runat="server"
                                            OnClick="Button2_Click" Text="Back" class="radius button" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-12 columns">
                                <center>
                                    <asp:Label ID="lblPassword" runat="server"></asp:Label>
                                    </center>
                                </div>
                            </div>

                        </div>
                        </div>
                        </asp:View>

                        <asp:View ID="viewCountryDetail" runat="server">
                            <div class="row">
                                <div class="large-4 columns">
                                    <asp:Label ID="lblStateName" runat="server" Text="State Name :" AssociatedControlID="txtStateName"></asp:Label>
                                </div>
                                <div class="large-8 columns">
                                    <asp:TextBox ID="txtStateName" runat="server" type="text" TabIndex="1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-4 columns">
                                    <asp:Label ID="lblCountryName" runat="server" Text="Country Name :" AssociatedControlID="txtCountryName"></asp:Label>
                                </div>
                                <div class="large-8 columns">
                                    <asp:TextBox ID="txtCountryName" runat="server" Style="vertical-align: middle; text-align: left"
                                        type="text"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-4 columns">
                                </div>
                                <div class="large-8 columns">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="False" TabIndex="9"
                                        CausesValidation="true" ValidationGroup="Save" class="button"></asp:Button>
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CausesValidation="False"
                                        UseSubmitBehavior="False" TabIndex="10" class="button"></asp:Button>
                                </div>
                            </div>
                            <div class="row">
                                <div class="large-4 columns">
                                </div>
                                <div class="large-8 columns">
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" Width="104px" ErrorMessage="Enter State Name"
                                        ControlToValidate="txtStateName" Display="None" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCountryName"
                                        Display="None" ErrorMessage="Enter Country Name" TabIndex="5" ValidationGroup="Save"
                                        Width="104px"></asp:RequiredFieldValidator>
                                    <asp:ValidationSummary ID="vlsUserGrp" runat="server" Width="496px" ValidationGroup="Save">
                                    </asp:ValidationSummary>
                                </div>
                            </div>
                        </asp:View>
                        <asp:View ID="viewMessage" runat="server">
                            <div class="row">
                                <div class="large-4 columns">
                                </div>
                                <div class="large-8 columns">
                                <br />
                                    
                                    <asp:Panel ID="pnlLogged" runat="server" Visible="false">
                                    <div class="login-wrap">
                                    <div class="row">
                                        <div class="large-12 columns">
                                        <h2><asp:Label ID="lblMessage" runat="server" Height="36px" Font-Bold="True"
                                        Font-Size="Large"></asp:Label></h2>
                                        <hr />
                                        </div>
                                       <div class="form large-12 columns" id="divMsg" runat="server">
                                        If not you, then 
                                        <asp:LinkButton ID="lbtnLogged" runat="server" Text="click here " OnClick="lbtnLogged_Click"></asp:LinkButton>
                                        to validate yourself.
                                        </div>
                                        <br />
                                         <div class="large-12 columns text-center">
                                        <asp:Button ID="btnGoBackM" TabIndex="10" runat="server" Font-Bold="true" style="margin-top:35px" UseSubmitBehavior="False"
                                            Text="Go Back" CausesValidation="False" OnClick="btnGoBackM_Click" class="radius button">
                                        </asp:Button>
                                        </div>
                                    </div>
                                    </div>
                                    
                                    </asp:Panel>
                                    <br />
                                </div>
                                <div class="large-4 columns">
                                </div>
                            </div>
                            <%--<div class="row">
                                <div class="large-4 columns">
                                </div>
                                <div class="large-8 columns">
                                    
                                </div>
                            </div>--%>
                        </asp:View>
                        <asp:View ID ="VwActiveUserMsg" runat="server">
                         <div class="row">
                                <div class="large-4 columns">
                                </div>
                                <div class="large-8 columns">
                                <br />
                         <asp:Panel ID="pnlActiveMsg" runat="server" Visible="false">
                                    <div class="login-wrap">
                                    <div class="row">
                                        <div class="large-12 columns">
                                        <h2><asp:Label ID="Label2" runat="server" Height="36px" Font-Bold="True"
                                        Font-Size="Large" Text="Link has been activated.<br/>Please login to use our services."></asp:Label></h2>
                                        <hr />
                                        </div>
                                        <br />
                                         <div class="large-12 columns text-center">
                                        <asp:Button ID="btnGoLogin" TabIndex="10" runat="server" Font-Bold="true" style="margin-top:35px" UseSubmitBehavior="False"
                                            Text="Login" CausesValidation="False" OnClick="btnGoLogin_Click" class="radius button">
                                        </asp:Button>
                                        </div>
                                    </div>
                                    </div>
                                    
                                    </asp:Panel>
                                     <br />
                                </div>
                                <div class="large-4 columns">
                                </div>
                            </div>
                        </asp:View>
                    </asp:MultiView>
                    
                        <%--</asp:MultiView>--%>
                <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>

       
      
      
        <div class="large-6 columns">
     
        <div class="row" id="divSignup" runat="server" >
        <div class="large-6 columns">
        
        </div>
<%--        <div class="large-6 columns text-left"> 
           <span style="font-size:18px">Don't have an account?</span>
           <br />
           <br />
           <asp:Button ID="Button3" OnClick="Button3_Click" runat="server" Text="Sign Up" class="radius button" formnovalidate style="background-color:#ef5845; width:206px; heigth:30px" /></div>--%>
        
        </div>
        
       <div class="row" id="divLogin" runat="server" visible="false" >
        <div class="large-6 columns">
        
        </div>
        <%--<div class="large-6 columns text-left"> 
           <span style="font-size:18px">Already have an account?</span>
           <br />
           <br />
           <asp:Button ID="Button4" Width="206px" Height="45px" runat="server" Text="Login" class="radius button" 
                formnovalidate style="background-color:#ef5845" onclick="Button4_Click1" /></div>--%>
        
        </div>
        </div>
    </div>
    <footer class="row">
    <br />
    <div class="large-12 columns">
      <hr/>
      <div class="row">
        <div class="large-3 columns">
           © 2016 Vatas Infotech Pvt.Ltd.
           </div>
                 <div class="large-9 columns text-right">              
                <a href="https://www.facebook.com/echarteredaccountants" target="_blank"><img src="../images/fb.png" alt="facebook"></a>
                <a href="http://www.twitter.com/ECAccountant" target="_blank"><img src="../images/twitter.png" alt="twitter"></a>
                <a href="https://in.linkedin.com/pub/vatas-infotech/b9/264/a82" target="_blank"><img src="../images/LINKEDIN1.PNG" alt="Linkedin"></a>
                <a href="https://plus.google.com/u/0/b/108616341946641442746/108616341946641442746" target="_blank"><img src="../images/google.png" alt="google"></a>
                </div>             
             </div>
             </div>
  </footer>
<%--  <asp:HiddenField ID="hdnCheck" runat="server" />--%>
  <div id="modal_dialog" style="display:none;">
  Please Check Either Your UserName or Password is Not Correct! 
  </div>
  <div id="modal_dialog1" style="display:none;" >
  Sorry your account is locked you have exceeded maximum login attempts. Please Contact us at support@echarteredaccountants.com or 
  <asp:LinkButton ID="lbtnSendMail" runat="server" Text="Click Here" OnClick="lbtnSendMail_Click" ForeColor="Blue"></asp:LinkButton> to get your password via mail.
  </div>
   <div id="modal_dialog2" style="display:none;" >
   </div>
    </form>
</body>
</html>
