<%@ Page Language="C#" AutoEventWireup="true" CodeFile="2Default.aspx.cs" Inherits="_2Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
      <link href="css/smart_wizard.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-2.0.0.min.js" type="text/javascript"></script>
    <script src="js/jquery.smartWizard.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnUpload").click(function () {
                $('step-2').css("display", "block");
                $('step-1').css("display", "none");
                $('step-3').css("display", "none");
                $('step-4').css("display", "none");
            });
            //  Wizard 1  	
            $('#wizard1').smartWizard({
                transitionEffect: 'fade',
                onFinish: onFinishCallback,
                onLeaveStep: leaveAStepCallback
            });
            function leaveAStepCallback(obj, context) {
                // To check and enable finish button if needed
                if (context.fromStep >= 2) {
                    $('#wizard1').smartWizard('enableFinish', true);
                }
                return true;
            }
            //  Wizard 2
            $('#wizard2').smartWizard({ transitionEffect: 'slide', onFinish: onFinishCallback });
            function onFinishCallback() {
                alert('Finish Called');
            }

        });
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {

        }
        //following event is being used as the last event after page loaded for updatepanel asynchronous events
        function EndRequestHandler(sender, args) {
            $("#btnUpload").click(function () {
                $('step-2').css("display", "block");
                $('step-1').css("display", "none");
                $('step-3').css("display", "none");
                $('step-4').css("display", "none");
            });
        }
    </script>

      <link rel="icon" href="images/fevicon.PNG" type="image/gif"  />
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <link href="foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
    <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <script src="foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>
    <script src="js/modernizr.custom.js" type="text/javascript"></script>
    <script src="js/classie.js" type="text/javascript"></script>
    <link href="ECAStyleSheet/Master.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
 a
 {
     outline:0;
 }
.loginBtn{
  background: #37588B;
  color: #FFF;
  border:none;
  font-size: 23px;
  font-weight: 400;
  padding: 10px 0px;
  width: 50%;
  cursor: pointer;
  outline: none;
  border-radius:10px;
}
.loginBtn:hover{
	background:#F05840;
	border-radius:10px;
	transition: 0.5s all;
  -webkit-transition: 0.5s all;
  -moz-transition: 0.5s all;
  -o-transition: 0.5s all;
}

.loginBtn:focus{
	background:#F05840;
	border-radius:10px;
	transition: 0.5s all;
  -webkit-transition: 0.5s all;
  -moz-transition: 0.5s all;
  -o-transition: 0.5s all;
}
</style>

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
    <%-----------------------------------Code For Event of Window Close------------------------------------------------------------%>
<script language="javascript" type="text/javascript">
  //<![CDATA[
    function HandleClose() {
        //alert("Killing the session on the server!!");
        PageMethods.AbandonSession();
    }
   //]]>
</script>
<script src="js/jquery.ui.min.js" type="text/javascript"></script>
 <script src="Presentation/jquery.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="js/ie_compatibility/newhtml5shiv.js"></script>
<script type="text/javascript" src="js/ie_compatibility/placeholder.min.js"></script>
<script src="js/ie_compatibility/html5shiv.js" type="text/javascript"></script>
    <script src="js/ie_compatibility/nwmatcher-1.2.5-min.js" type="text/javascript"></script>
    <script src="js/ie_compatibility/respond.min.js" type="text/javascript"></script>
    <script src="js/ie_compatibility/selectivizr-1.0.3b.js" type="text/javascript"></script>
    <script src="js/ie_compatibility/es5-shim.min.js" type="text/javascript"></script>
    <!------- code for show Err msg when user enter wrong captcha and user name and password if he/she logins from login popup ------->
        <script type="text/javascript">
            $(document).ready(function ($) {

                setTimeout(function () {
                    $('#ctl00_divErrorMsg').fadeOut('fast');
                }, 10000);


            });
        </script>
        <%--------active link ----------------%>
         <script type="text/javascript">
             $(document).ready(function () {
                 $('.button-group a').click(function () {
                     $(".button-group a").removeClass("active");
                     // alert('ffff');
                     $(this).addClass('active');
                 });
             });</script>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div id="frmError" runat="server">
        <span style="color: red">Please fill all mandatory fields.</span>
        <br />
        <br />
    </div>
    <input type="hidden" runat="server" id="key" name="key" />
    <input type="hidden" runat="server" id="hash" name="hash" />
    <input type="hidden" runat="server" id="txnid" name="txnid" />
    <input type="hidden" runat="server" id="enforce_paymethod" name="enforce_paymethod" />
    <table style="display:none;">
        <tr>
            <td>
                <b>Mandatory Parameters</b>
            </td>
        </tr>
        <tr>
            <td>
                Amount:
            </td>
            <td>
                <asp:TextBox ID="amount" runat="server" Text="10" />
            </td>
            <td>
                First Name:
            </td>
            <td>
                <asp:TextBox ID="firstname" runat="server" Text="Ankush" />
            </td>
        </tr>
        <tr>
            <td>
                Email:
            </td>
            <td>
                <asp:TextBox ID="email" runat="server" Text="ankush.passion@gmail.com" />
            </td>
            <td>
                Phone:
            </td>
            <td>
                <asp:TextBox ID="phone" runat="server" Text="9412312345" />
            </td>
        </tr>
        <tr>
            <td>
                Product Info:
            </td>
            <td colspan="3">
                <asp:TextBox ID="productinfo" runat="server" Text="ITR Registration" />
            </td>
        </tr>
        <tr>
            <td>
                Success URI:
            </td>
            <td colspan="3">
                <asp:TextBox ID="surl" runat="server" Text="http://www.echarteredaccountants.com?st=pass" />
            </td>
        </tr>
        <tr>
            <td>
                Failure URI:
            </td>
            <td colspan="3">
                <asp:TextBox ID="furl" runat="server" Text="http://www.echarteredaccountants.com?st=fail" />
            </td>
        </tr>
        <tr>
            <td>
                <b>Optional Parameters</b>
            </td>
        </tr>
        <tr>
            <td>
                Last Name:
            </td>
            <td>
                <asp:TextBox ID="lastname" runat="server" />
            </td>
            <td>
                Cancel URI:
            </td>
            <td>
                <asp:TextBox ID="curl" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Address1:
            </td>
            <td>
                <asp:TextBox ID="address1" runat="server" />
            </td>
            <td>
                Address2:
            </td>
            <td>
                <asp:TextBox ID="address2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                City:
            </td>
            <td>
                <asp:TextBox ID="city" runat="server" />
            </td>
            <td>
                State:
            </td>
            <td>
                <asp:TextBox ID="state" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Country:
            </td>
            <td>
                <asp:TextBox ID="country" runat="server" />
            </td>
            <td>
                Zipcode:
            </td>
            <td>
                <asp:TextBox ID="zipcode" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                UDF1:
            </td>
            <td>
                <asp:TextBox ID="udf1" runat="server" />
            </td>
            <td>
                UDF2:
            </td>
            <td>
                <asp:TextBox ID="udf2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                UDF3:
            </td>
            <td>
                <asp:TextBox ID="udf3" runat="server" />
            </td>
            <td>
                UDF4:
            </td>
            <td>
                <asp:TextBox ID="udf4" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                UDF5:
            </td>
            <td>
                <asp:TextBox ID="udf5" runat="server" />
            </td>
            <td>
                PG:
            </td>
            <td>
                <asp:TextBox ID="pg" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Service Provider:
            </td>
            <td>
                <asp:TextBox ID="service_provider" runat="server" Text="payu_paisa" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="submit" Text="submit" Width="100px" runat="server" OnClick="Button1_Click" />
    
    </form>
</body>
</html>
