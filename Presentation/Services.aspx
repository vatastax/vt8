<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Presentation_Service" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Interactive Platform for free e-filing Income Tax Returns in India</title>
    <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <script src="../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="../foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
    <script src="../js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>
    <!--menu js files-->
    <script src="../js/modernizr.custom.js" type="text/javascript"></script>
    <script src="../js/classie.js" type="text/javascript"></script>
    <!--for mobile menu-->
    <!--master style sheet-->
    <link href="../style_folder/SidePagesStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
    <!--for mobile menu-->
    <!--master style sheet-->
    <link href="../style_folder/StyleSheet.css" rel="Stylesheet"" type="text/css" />
    <!--master style sheet-->
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
    <link rel="icon" type="image/png" href="../images/fevicon.png" />
    <link rel="shortcut icon" type="image/png" href="../images/fevicon.png" />
    <%-------------------------------------LOGIN POP UP BOX------------------------------------------%>
    <link href="../css/loginpopupbox/loginpopbox.css" rel="stylesheet" type="text/css" />
    <link href="../css/loginpopupbox/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="../css/loginpopupbox/demo.css" rel="stylesheet" type="text/css" />
    <script src="../js/loginpopupbox/modernizr.custom.63321.js" type="text/javascript"></script>
    <%-----------------------------------------------------------------------------------------------%>
    <%-----------------------------------Code For Event of Window Close------------------------------------------------------------%>
    <script language="javascript" type="text/javascript">
  //<![CDATA[
    function HandleClose() {
        //alert("Killing the session on the server!!");
        PageMethods.AbandonSession();
    }
   //]]>
    </script>
    <%-------------------------------------------------------------------------------------------------------------------------------%>
    <%--<link href="ITRStylesheet/styles/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
    <script src="../js/jquery.ui.min.js" type="text/javascript"></script>
    <script src="../Presentation/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/ie_compatibility/newhtml5shiv.js"></script>
    <script type="text/javascript" src="../js/ie_compatibility/placeholder.min.js"></script>
    <script src="../js/ie_compatibility/html5shiv.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/nwmatcher-1.2.5-min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/respond.min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/selectivizr-1.0.3b.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/es5-shim.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function ($) {
            // alert('before');
            setTimeout(function () {
                $('#ctl00_divErrorMsg').fadeOut('fast');
            }, 10000);
            // alert('after');

        });
    </script>
    <link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="../foundation-5.5.0/js/foundation.min.js" type="text/javascript"></script>
    <script src="../js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-default.js" type="text/javascript"></script>
    <link href="../StaticStylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />
    <link href="../style_folder/DefaultStyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../StaticStylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <%--This Message appears when Internet Explorer version is 8.0 or less than Internet Explorer 8.0--%>
    <div id="iemsg" runat="server" style="text-align: center; color: red;">
        <marquee>Please upgrade your browser to use ECHARTEREDACCOUNTANTS.COM or Press F12 -> Emulation -> Go to Document Mode -> Choose Edge or highest value. </marquee>
    </div>
    <%--    <hr style="color:#ef5845; background-color:red; padding:0px; margin:0px" />--%>
    <div id="divErrorMsg" runat="server" visible="false" style="margin: 0px; padding: 0px;
        color: white; background-color: #7f7f7f; text-align: center">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <%--  <hr style="color:#ef5845; background-color:red; padding:0px; margin:0px" />--%>
    </div>
    <%-- <div class="row" style="margin-top:10px">
    <div class="large-8 columns">
    </div>
    <div class="large-4 columns text-right">
        <img src="images/social.jpg" style="height:20px" />
    </div>
    <div class="large-2 columns">
    </div>
    </div>--%>
    <%-- <!--code for beta-->
    <div id="beta" class="row hide-for-small-only" style="width:200px">
        <img src="images/beta.png" />
    </div>
    <div id="beta_mob" class="row show-for-small-only">
        <img src="images/beta_mob.png" />
    </div>
    <!--code for beta-->--%>
    <br />
    <div class="row show-for-small-only ">
        <div class="small-12 columns">
            <a href="Default.aspx">
                <img src="../images/logo2.PNG" style="width: 240px" /></a>
        </div>
    </div>
    <%-- <div class="row show-for-small-only   ">
        
        <div class="small-12 columns ">
        <div class="rmm" data-menu-style = "minimal">
          <ul  >
          <li><a href="Default.aspx" class="button">HOME</a></li>
          <li><a href="Services.aspx" class="button">SERVICES</a></li>
          <li><a href="AboutUs.aspx" class="button">ABOUT US</a></li>
          <li><a href="ContactUsNew.aspx" class="button">CONTACT US</a></li>
           <li><a href="#" class="button">LOGIN</a></li>
          </ul>
          </div>
         </div>
    
       </div>--%>
    <!--menu for small screen-->
    <div class="large-3 columns show-for-small-only ">
        <!--left-menu(quick links)-->
        <nav class="cbp-spmenu cbp-spmenu-vertical cbp-spmenu-left " id="cbp-spmenu-s1">
                   <ul style="list-style-type:none">
			        <h3>Quick Links</h3>
			        <li ><a href="../AboutUs.aspx" >About Us</a></li>
                    <li ><a href="../ContactUsNew.aspx">Contact Us</a></li>
                    <li><a href="../News.aspx" >Latest News</a></li>
                    <li ><a href="../SiteMap.aspx" >Site Map</a></li>
                    <li><a href="../Terms_Conditions.aspx" >Terms & Conditions</a></li>
                    <li><a href="#" >Feedback & Support</a></li>
                    <li ><a href="../PrivacyPolicy.aspx" >Privacy Policy</a></li>
                   </ul>
		        </nav>
        <!--left-menu(quick links)-->
        <!--top-menu(main menu)-->
        <nav class="cbp-spmenu cbp-spmenu-horizontal cbp-spmenu-top" id="cbp-spmenu-s3">
                    <ul style="list-style-type:none;margin-left: 0.5rem;">
                        <a href="../Default.aspx"><img src="../images/logo2.PNG" style="width:200px; height:auto;margin:5px 0 2px 5px;"/></a>
			            <li ><a href="default.aspx " >Home</a></li>
                        <li ><a href="Services.aspx">Services</a></li>
                        <li style="padding-left:5px"><a href="../AboutUs.aspx">About</a></li>
                        <li><a href="../ContactUsNew.aspx" >Contact</a></li>
                        <li ><a href="../Presentation/login.aspx" >Login</a></li>
                   </ul>
                 </nav>
        <!--placement of menu images-->
        <div class="row text-right">
            <!-- Class "cbp-spmenu-open" gets applied to menu -->
            <%--<button  id="showLeft">Menu</button>	--%>
            <img src="../images/menu.PNG" alt="menu" id="showTop" />
            <%--<img src="images/mobilemenu.PNG" id="showLeft" />--%>
            <%-- <button id="showLeft" style="background-image:url('images/mainmenumob.PNG')"></button>
					     <button id="showTop" style="background-image:url('images/mainmenumob.PNG')"></button>--%>
        </div>
        <!--java-script for menus-->
        <script type="text/javascript">
                     var menuTop = document.getElementById('cbp-spmenu-s3'),
                        showTop = document.getElementById('showTop'),
                        body = document.body;



                     showTop.onclick = function () {
                         classie.toggle(this, 'active');
                         classie.toggle(menuTop, 'cbp-spmenu-open');
                         disableOther('showTop');
                     };

                     function disableOther(img) {
                         if (img != 'showLeft') {
                             classie.toggle(showLeft, 'disabled');
                         }

                         if (img != 'showTop') {
                             classie.toggle(showTop, 'disabled');
                         }
                     }
        </script>
        <!--java-script for menus-->
        <!--top-menu(main menu)-->
    </div>
    <!--menu for small screen-->
    <div class="row">
        <div class="large-4 columns hide-for-small hide-for-medium">
            <!--Resolution Problem Solved - Jaipal -->
            <a href="../Default.aspx">
                <img src="../images/logo2.PNG" style="width: 240px; height: auto" /></a>
        </div>
        <div class="large-8 columns hide-for-small hide-for-medium ">
            <!--Resolution Problem Solved - Jaipal -->
            <ul class="right button-group">
                <li><a href="../default.aspx" class="button">HOME</a></li>
                <li><a href="Services.aspx" class="button">SERVICES</a></li>
                <li><a href="../AboutUs.aspx" class="button">ABOUT US</a></li>
                <li><a href="../ContactUsNew.aspx" class="button">CONTACT US</a></li>
                <li id="li_Login" runat="server" class="has-sub"><a href="#" class="button">LOGIN</a>
                    <ul>
                        <li>
                            <%--<div style=" width:600px;height:auto; margin    border-radius:10px; margin-left:-400px; z-index:30001; background-color:#d3d3d3;opacity:0.85; overflow:hidden; ">--%>
                            <%-----------------------------------------------------------------------------------------------%>
                            <div class="container1" style="margin-left: -40px; border: 1px solid rgba(182, 182, 182, 0.67);
                                width: 205px; border-radius: 8px; -webkit-box-shadow: 10px 12px 15px -5px #ccc;
                                background-color: White;">
                                <section class="main1" style="margin-top: 7px;">
				
					<p style="margin-bottom: 4px">
						<asp:TextBox ID="txtUser1" placeholder="Email ID" runat="server" ValidationGroup="loginpopup" style="border-radius:8px;padding:5px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RqF1" runat="server" ControlToValidate="txtUser1" ErrorMessage="Enter Email ID" ForeColor="Red" ValidationGroup="loginpopup" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="RegEV" runat="server" ControlToValidate="txtUser1" ErrorMessage="Incorrect Format" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="loginpopup" Display="Dynamic" Font-Size="12px"></asp:RegularExpressionValidator>
						
					</p>
						<p style="margin-bottom: 4px">
							<asp:TextBox ID="txtPassword1" runat="server"  placeholder="Password" TextMode="Password" ValidationGroup="loginpopup" style="border-radius:8px;padding:5px" ></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RqF2" runat="server" ControlToValidate="txtPassword1" ErrorMessage="Enter Password" ForeColor="Red" ValidationGroup="loginpopup" Display="Dynamic" Font-Size="12px"></asp:RequiredFieldValidator>
							
					</p>
					<p class="field1">
						<asp:UpdatePanel ID="updCap" runat="server">
                        <ContentTemplate>
                        <asp:Image ID="imgCaptcha" runat="server"  BorderWidth="1" BorderColor="LightGray" Height="40px" style="margin-left:20px;margin-top:-18px;  border-radius: 8px;"/>
                         <asp:ImageButton ID="imgRefresh" runat="server" ImageUrl="images/refresh.png" OnClick="imgRefresh_Click" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
					</p>
                    <p class="field1">
						<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                         <asp:TextBox ID="txtCaptcha" runat="server" style="border-radius: 8px;margin-top:-16px; padding: 5px;" placeholder="Captcha Code"  ValidationGroup="loginpopup" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RqF3" runat="server" ControlToValidate="txtCaptcha" ForeColor="Red" ErrorMessage="Enter Captcha Code" ValidationGroup="loginpopup" Display="Dynamic"></asp:RequiredFieldValidator>
                       
                        </ContentTemplate>
                        </asp:UpdatePanel>
					</p>
                    <p class="submit" style="text-align:center">
						<asp:Button ID="Button1" runat="server" Text="Login" OnClick="btnLogin1_Click"  class="loginBtn"  ValidationGroup="loginpopup" style="padding-top:0px; padding-bottom:0px;  font-size: larger; margin-bottom:0;border-radius:4px"  ></asp:Button>
					</p>
                    <br />
                    <p style="text-align:center;margin-top:-26px;">
                     <asp:LinkButton ID="lnkSignup" runat="server" Text="Signup" ForeColor="#008cba" Font-Bold="true" OnClick="lnkSignup_Click" Font-Size="12px"></asp:LinkButton><br />
                     <asp:LinkButton ID="lnkPwd" runat="server" Text="Forget Password???" ForeColor="#008cba" Font-Bold="true" OnClick="lnkPwd_Click" Font-Size="12px"></asp:LinkButton>
                     
                    </p>
					
					
				
			</section>
                            </div>
                            <%-----------------------------------------------------------------------------------------------%>
                        </li>
                    </ul>
                </li>
                <li id="li_Logout" runat="server">
                    <asp:LinkButton ID="lbtnLogout" runat="server" Text="LOGOUT" CssClass="button" OnClick="lbtnLogout_Click"></asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    <div class="row show-for-medium-only">
        <div class="medium-4 columns">
            <a href="default.aspx">
                <img src="../images/logo2.PNG" style="width: 180px; height: auto; margin-left: 15px;" /></a>
        </div>
        <div class="medium-8 columns ">
            <ul class="right button-group">
                <li><a href="../default.aspx" style="font-size: 12px" class="button">HOME</a></li>
                <li><a href="Services.aspx" style="font-size: 12px" class="button">SERVICES</a></li>
                <li><a href="../AboutUs.aspx" style="font-size: 12px" class="button">ABOUT US</a></li>
                <li><a href="../ContactUsNew.aspx" style="font-size: 12px" class="button">CONTACT US</a></li>
                <li id="li_Login1" runat="server"><a href="login.aspx" style="font-size: 12px" class="button">
                    LOGIN</a></li>
                <li id="li_Logout1" runat="server">
                    <asp:LinkButton ID="lbtnLogout1" runat="server" Text="LOGOUT" Style="font-size: 12px"
                        CssClass="button" OnClick="lbtnLogout_Click"></asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div style="float: right;">
            <asp:Literal ID="ltWelcome" runat="server"></asp:Literal>
        </div>
    </div>
    <%--   <div class="submenu1" style="display:none;" >

        <div class="row" style="margin-bottom:10px; margin-top:10px"">
    <div class="large-4 columns">
    Username
    </div>
    <div class="large-8 columns">
        <asp:TextBox ID="txtUser11" runat="server" ></asp:TextBox>
   
    </div>
 
    </div>
 
   <div class="row" style="margin-bottom:10px">
    <div class="large-4 columns">
        Password
    </div>
    <div class="large-8 columns">
       <asp:TextBox ID="txtPassword11" runat="server"  TextMode="Password"></asp:TextBox>
    </div>
    </div>
       
     <div class="row" >
       <div class="large-4 columns">
           Security Code:
        </div>                        
        <div class="large-8 columns">
             <asp:Image ID="Image2" runat="server" ImageUrl="Presentation/CImage.aspx" Width="80%"/>
            <asp:ImageButton ID="ibtnCap1" runat="server" ImageUrl="images/refresh.png" />
        </div>
    </div>
    <div class="row" style="margin-bottom:10px">    
        <div class="large-4 columns">
             
        </div>                     
        <div class="large-8 columns">
              <asp:TextBox ID="txtCaptcha1" runat="server" ></asp:TextBox>
        </div>
    </div>
             
          <div class="row" style="margin-bottom:10px">
             <div class="large-4 columns"></div>
            <div class="large-8 columns"> 
                <asp:Button ID="btnLogin1" runat="server" Text="Login" OnClick="btnLogin1_Click"></asp:Button>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
   
   
    </div>
    <div class="row">
         <div class="large-4 columns">
          </div>
        <div class="large-8 columns">
         <a href="#" style="color:gray; font-weight:bold;">Forget Password??</a>
        </div>

    </div>
    </div>--%>
    <div>
    </div>
    </br>
    <div class="row" style="margin-bottom: 50px">
        <div class="large-12 columns">
            <div class="row" style="margin-bottom: 20px">
                <p class="lplh-58" style="text-align: center;">
                    <span style="font-size: 34px; font-family: Cambria; font-weight: 500; line-height: 1.1;
                        letter-spacing: -2"><span style="color: #3b3738;">Our</span> <span style="color: #FC6F5C">
                            Services</span></span>
                    <%--<span style="color:#3b3738;"><span style="font-size: 34px;"><span style="font-family:Cambria; font-weight:500; line-height:1.1; letter-spacing:-2"> Our Services</span>--%>
                </p>
            </div>
        </div>
      <%--  <div class="large-12 columns">
            <div class="row hide-for-small-only hide-for-medium-only">
                <div class="large-3 columns">
                    <div style="width: 220px; float: left;">
                        <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                            border-top-right-radius: 10px">
                            <img src="../images/itr.png" style="margin-left: 80px" />
                        </div>--%>
                        <%-- <div class="service_heading"  onmouseover="this.style.background='#FC6F5C'; this.style.color='#ffffff';" onmouseout="this.style.background='#dde1e0'; " style="background-color:#dde1e0; padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center">--%>
                     <%--   <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                            border-bottom-left-radius: 10px; text-align: center;">
                            <a href="../pageRedirect.aspx?prj=vt">Income Tax Returns</a> </br>
                        </div>
                    </div>
                </div>
                <div class="large-3 columns">
                    <div style="width: 220px; float: left;">
                        <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                            border-top-right-radius: 10px">
                            <img src="../images/tds.png" style="margin-left: 80px" />
                        </div>
                        <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                            border-bottom-left-radius: 10px; text-align: center;">
                            <a href="../pageRedirect.aspx?prj=tds">Tax Deducted at Source</a> </br>
                        </div>
                    </div>
                </div>
                <div class="large-3 columns">
                    <div style="width: 220px; float: left;">
                        <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                            border-top-right-radius: 10px">
                            <img src="../images/vat.png" style="margin-left: 80px" />
                        </div>
                        <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                            border-bottom-left-radius: 10px; text-align: center;">
                            <a href="Gst.aspx">Goods & Service Tax</a> </br>
                        </div>
                    </div>
                </div>
                <div class="large-3 columns">
                    <div style="width: 220px; float: left;">
                        <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                            border-top-right-radius: 10px">
                            <img src="../images/st.png" style="margin-left: 80px" />
                        </div>
                        <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                            border-bottom-left-radius: 10px; text-align: center;">
                            <a href="../pageRedirect.aspx?prj=stax">Service Tax</a> </br>
                        </div>
                    </div>
                </div>
            </div>
            </div>--%>

             <div class="row hide-for-small-only hide-for-medium-only">

     <div class="large-6 columns"> <div style="width:420px;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px;    text-align: center;">
			        <img src="../images/itr.png"  />
		        </div>
		     
                <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <%--<a href="../pageRedirect.aspx?prj=vt">Income Tax Returns</a>--%>
                    <asp:LinkButton ID="lbtnITR" runat="server" Text="Income Tax Returns" OnClick="lbtnITR_Click"></asp:LinkButton>
			        <br />
		        </div>
             </div></div>
     <div class="large-6 columns">     <div style="width:420px;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px;    text-align: center;">
			        <img src="../images/tds.png"  />
		        </div>
		        <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <%--<a href="../pageRedirect.aspx?prj=tds">Tax Deducted at Source</a>--%>
                    <asp:LinkButton ID="lbtnTDS" runat="server" Text="Tax Deducted at Source" OnClick="lbtnTDS_Click"></asp:LinkButton>
			        <br />
		        </div>
             </div></div>
</div>  

 <div class="row  show-for-small-only" style="margin-top:30px; ">
       <div class="large-4 columns"></div>
    <div class="large-4 columns">
            <div style="width:220px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="images/itr.png" style="margin-left:80px" />
		        </div>
		       <%-- <div class="service_heading"  onmouseover="this.style.background='#FC6F5C'; this.style.color='#ffffff';" onmouseout="this.style.background='#dde1e0'; " style="background-color:#dde1e0; padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center">--%>
                <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="pageRedirect.aspx?prj=vt">Income Tax Returns</a>
			        <br />
		        </div>
             </div>
        </div>
        <div class="large-4 columns">
            <div style="width:220px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="images/tds.png" style="margin-left:80px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="pageRedirect.aspx?prj=tds">Tax Deducted at Source</a>
			        <br />
		        </div>
             </div>
        </div>
        </div>
          <div class="row show-for-medium-only">
   
        <div class="medium-6 columns">
            <div style="width:320px;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px; text-align:center;">
			        <img src="images/itr.png"  />
		        </div>
		        <div class="service_heading"  style=" padding:20px 0;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="Presentation/default.aspx">Income Tax Returns</a>
			        <br />
		        </div>
             </div>
        </div>
        <div class="medium-6 columns">
            <div style="width:320px;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px; text-align:center;">
			        <img src="images/tds.png"  />
		        </div>
		        <div class="service_heading"  style=" padding:20px 0;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			       <a href="tds.aspx">Tax Deducted at Source</a>
			        <br />
		        </div>
             </div>
        </div>
          </div>
            <!--for large screens-->
       <%--     <div class="row  hide-for-small-only hide-for-medium-only" style="margin-top: 30px;
                padding-left: 80px">
                <div class="large-4 columns">
                    <div style="width: 220px; float: left;">
                        <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                            border-top-right-radius: 10px">
                            <img src="../images/cet.png" style="margin-left: 80px" />
                        </div>
                        <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                            border-bottom-left-radius: 10px; text-align: center;">
                            <a href="../cet.aspx">Central Excise Tax</a> </br>
                        </div>
                    </div>
                </div>
                <div class="large-4 columns">
                    <div style="width: 220px; float: left;">
                        <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                            border-top-right-radius: 10px">
                            <img src="../images/nri.png" style="margin-left: 80px" />
                        </div>
                        <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                            border-bottom-left-radius: 10px; text-align: center;">
                            <a href="../nri.aspx">NRI Taxation</a> </br>
                        </div>
                    </div>
                </div>
                <div class="large-4 columns">
                    <div style="width: 220px; float: left;">
                        <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                            border-top-right-radius: 10px">
                            <img src="../images/tp.png" style="margin-left: 80px" />
                        </div>
                        <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                            border-bottom-left-radius: 10px; text-align: center;">
                            <a href="../tp.aspx">Transfer Pricing</a> </br>
                        </div>
                    </div>
                </div>
                <div class="large-2 columns">
                    &nbsp;</div>
            </div>--%>


            <!--for small screens-->
         <%--   <div class="row  show-for-small-only" style="margin-top: 30px;margin-left: 50px;">
                <div class="large-4 columns">
                    <div style="width: 220px; float: left;">
                        <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                            border-top-right-radius: 10px">
                            <img src="../images/itr.png" style="margin-left: 80px" />
                        </div>
                        <%-- <div class="service_heading"  onmouseover="this.style.background='#FC6F5C'; this.style.color='#ffffff';" onmouseout="this.style.background='#dde1e0'; " style="background-color:#dde1e0; padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center">--%>
                       <%-- <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                            border-bottom-left-radius: 10px; text-align: center;">
                            <a href="../pageRedirect.aspx?prj=vt">Income Tax Returns</a> </br>
                        </div>--%>
                    <<%--/div>
                </div>
                <div class="large-4 columns">
                    <div style="width: 220px; float: left;">
                        <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                            border-top-right-radius: 10px">
                            <img src="../images/tds.png" style="margin-left: 80px" />
                        </div>
                        <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                            border-bottom-left-radius: 10px; text-align: center;">
                            <a href="../pageRedirect.aspx?prj=tds">Tax Deducted at Source</a> </br>
                        </div>
                    </div>
                </div>--%>
               <%-- <div class="large-4 columns">
                    <div style="width: 220px; float: left;">
                        <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                            border-top-right-radius: 10px">
                            <img src="../images/vat.png" style="margin-left: 80px" />
                        </div>
                        <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                            border-bottom-left-radius: 10px; text-align: center;">
                            <a href="Gst.aspx">Goods & Service Tax</a> </br>
                        </div>
                    </div>
                </div>--%>
               <%-- <div class="large-4 columns">
                    <div style="width: 220px; float: left;">
                        <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                            border-top-right-radius: 10px">
                            <img src="../images/st.png" style="margin-left: 80px" />
                        </div>
                        <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                            border-bottom-left-radius: 10px; text-align: center;">
                            <a href="../pageRedirect.aspx?prj=stax">Service Tax</a> </br>
                        </div>
                    </div>
                </div>
            --%>
           <%-- <div class="large-4 columns">
                <div style="width: 220px; float: left;">
                    <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                        border-top-right-radius: 10px">
                        <img src="../images/cet.png" style="margin-left: 80px" />
                    </div>
                    <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                        border-bottom-left-radius: 10px; text-align: center;">
                        <a href="../cet.aspx">Central Excise Tax</a> </br>
                    </div>
                </div>
            </div>--%>
           <%-- <div class="large-4 columns">
                <div style="width: 220px; float: left;">
                    <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                        border-top-right-radius: 10px">
                        <img src="../images/nri.png" style="margin-left: 80px" />
                    </div>
                    <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                        border-bottom-left-radius: 10px; text-align: center;">
                        <a href="../nri.aspx">NRI Taxation</a> </br>
                    </div>
                </div>
            </div>
            <div class="large-4 columns">
                <div style="width: 220px; float: left;">
                    <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                        border-top-right-radius: 10px">
                        <img src="../images/tp.png" style="margin-left: 80px" />
                    </div>
                    <div class="service_heading" style="padding: 20px; margin-bottom: 10px; border-bottom-right-radius: 10px;
                        border-bottom-left-radius: 10px; text-align: center;">
                        <a href="../tp.aspx">Transfer Pricing</a> </br>
                    </div>
                </div>
            </div>
            </div--%>
            
    <!--for medium screens-->
  <%--  <div class="medium-12 columns">
        <div class="row show-for-medium-only">
            <div class="medium-3 columns">
                <div style="width: 180px; float: left;">
                    <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                        border-top-right-radius: 10px">
                        <img src="../images/itr.png" style="margin-left: 65px" />
                    </div>
                    <div class="service_heading" style="padding: 20px 0; margin-bottom: 10px; border-bottom-right-radius: 10px;
                        border-bottom-left-radius: 10px; text-align: center;">
                        <a href="default.aspx">Income Tax Returns</a> </br>
                    </div>
                </div>
            </div>
            <div class="medium-3 columns">
                <div style="width: 180px; float: left;">
                    <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                        border-top-right-radius: 10px">
                        <img src="../images/tds.png" style="margin-left: 65px" />
                    </div>
                    <div class="service_heading" style="padding: 20px 0; margin-bottom: 10px; border-bottom-right-radius: 10px;
                        border-bottom-left-radius: 10px; text-align: center;">
                        <a href="tds.aspx">Tax Deducted at Source</a> </br>
                    </div>
                </div>
            </div>
            <div class="medium-3 columns">
                <div style="width: 180px; float: left;">
                    <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                        border-top-right-radius: 10px">
                        <img src="../images/vat.png" style="margin-left: 65px" />
                    </div>
                    <div class="service_heading" style="padding: 20px 0; margin-bottom: 10px; border-bottom-right-radius: 10px;
                        border-bottom-left-radius: 10px; text-align: center;">
                        <a href="Gst.aspx">Goods & Service Tax</a> </br>
                    </div>
                </div>
            </div>
            <div class="medium-3 columns">
                <div style="width: 180px; float: left;">
                    <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                        border-top-right-radius: 10px">
                        <img src="../images/st.png" style="margin-left: 65px" />
                    </div>
                    <div class="service_heading" style="padding: 20px 0; margin-bottom: 10px; border-bottom-right-radius: 10px;
                        border-bottom-left-radius: 10px; text-align: center;">
                        <a href="servicetax.aspx">Service Tax</a> </br>
                    </div>
                </div>
            </div>
        </div>
        <div class="row  show-for-medium-only" style="margin-top: 30px; padding-left: 80px">
            <div class="medium-4 columns">
                <div style="width: 180px; float: left;">
                    <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                        border-top-right-radius: 10px">
                        <img src="../images/cet.png" style="margin-left: 65px" />
                    </div>
                    <div class="service_heading" style="padding: 20px 0; margin-bottom: 10px; border-bottom-right-radius: 10px;
                        border-bottom-left-radius: 10px; text-align: center;">
                        <a href="../cet.aspx">Central Excise Tax</a> </br>
                    </div>
                </div>
            </div>
            <div class="medium-4 columns">
                <div style="width: 180px; float: left;">
                    <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                        border-top-right-radius: 10px">
                        <img src="../images/nri.png" style="margin-left: 65px" />
                    </div>
                    <div class="service_heading" style="padding: 20px 0; margin-bottom: 10px; border-bottom-right-radius: 10px;
                        border-bottom-left-radius: 10px; text-align: center;">
                        <a href="../nri.aspx">NRI Taxation</a> </br>
                    </div>
                </div>
            </div>
            <div class="medium-4 columns">
                <div style="width: 180px; float: left;">
                    <div style="background-color: #FC6F5C; padding-top: 30px; padding-bottom: 30px; border-top-left-radius: 10px;
                        border-top-right-radius: 10px">
                        <img src="../images/tp.png" style="margin-left: 65px" />
                    </div>
                    <div class="service_heading" style="padding: 20px 0; margin-bottom: 10px; border-bottom-right-radius: 10px;
                        border-bottom-left-radius: 10px; text-align: center;">
                        <a href="../tp.aspx">Transfer Pricing</a> </br>
                    </div>
                </div>
            </div>
            <div class="large-2 columns">
                &nbsp;</div>
        </div>
    </div>--%>
    </div>
    <!--footer-->
    <div style="background-color: #2B7CAD; padding-left: 10px">
        <div class="row">
            </br></br>
            <div class="large-10 columns">
                <div class="row">
                    <div class="large-8 columns footer-links">
                        <h4 style="color: #ffffff; font-family: Cambria; padding-left: 10px">
                            About</h4>
                        <ul style="list-style-type: disc; color: #FC6F5C; font-family: Calibri; padding-left: 15px">
                            <li><a href="../AboutUs.aspx" style="color: White">E-Chartered Accountants</a></li>
                            <li><a href="../ContactUsNew.aspx" style="color: White">Contact Details</a></li>
                            <li><a href="../Terms_Conditions.aspx" style="color: White">Terms & Condition</a></li>
                            <li><a href="../PrivacyPolicy.aspx" style="color: White">Privacy & Policy</a></li>
                            <%--<li ><a href="#" style="color:White">Apply Digital Signature</a></li>--%>
                            <li><a href="../SiteMap.aspx" style="color: White">Site Map</a></li>
                            <li><a href="../News.aspx" style="color: White">Latest News</a></li>
                            <%-- <li ><a href="#" style="color:White">Blog</a></li>--%>
                            <li><a href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf"
                                target="_blank" style="color: White">FAQs</a></li>
                        </ul>
                    </div>
                    <div class="large-4 columns">
                        <h4 style="color: #ffffff; font-family: Cambria; padding-left: 10px">
                            Have a doubt? Ask here.</h4>
                        <div class="row">
                            <div class="large-4 columns" style="color: White; font-family: Calibri;">
                                Name
                            </div>
                            <div class="large-8 columns">
                                <asp:TextBox ID="txtName" runat="server" Width="230" Style="border-radius: 3px;"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns" style="color: White; font-family: Calibri;">
                                Email
                            </div>
                            <div class="large-8 columns">
                                <asp:TextBox ID="txtEmail" runat="server" Width="230" Style="border-radius: 3px;"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns" style="color: White; font-family: Calibri;">
                                Subject
                            </div>
                            <div class="large-8 columns">
                                <asp:TextBox ID="txtSubject" runat="server" Width="230" Style="border-radius: 3px"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row" style="margin-top: 10px;">
                            <div class="large-4 columns" style="color: White; font-family: Calibri;">
                                Comment
                            </div>
                            <div class="large-7 columns" style="margin-bottom: 10px">
                                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Style="border-radius: 3px;
                                    height: 75px;"></asp:TextBox>
                            </div>
                            <div class="large-1 columns">
                            </div>
                        </div>
                        <br />
                        <div class="row" style="margin-top: 10px;">
                            <div class="large-4 columns" style="color: White; font-family: Calibri;">
                                Attachment
                            </div>
                            <div class="large-5 columns" style="margin-bottom: 10px">
                                <asp:FileUpload ID="FUpload1" runat="server" />
                            </div>
                            <div class="large-2 columns">
                            </div>
                            <div class="large-1 columns">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/submit1.PNG">
                                </asp:ImageButton></div>
                        </div>
                    </div>
                    <%--<div class="large-4 columns"></div>--%>
                </div>
            </div>
            <div class="large-12 columns">
                <hr />
                <div class="row">
                    <div class="large-3 columns">
                        <p style="color: Silver">
                            © 2015 Vatas Infotech Pvt.Ltd.</p>
                    </div>
                    <div class="large-9 columns text-right">
                        <a>
                            <img src="../images/fb.png" /></a> <a>
                                <img src="../images/twitter.png" /></a> <a>
                                    <img src="../images/LINKEDIN1.PNG" /></a> <a>
                                        <img src="../images/google.png" /></a>
                        <%-- <ul class="inline-list right">
                
                <li ><a href="home2.aspx" style="color:White">Home</a></li>
                <li><a href="about.aspx"  style="color:White">About us</a></li>
                  <li ><a href="contact.aspx"  style="color:White">Contact us</a></li>
                 
                  <li ><a href="#"  style="color:White">Terms&Condition</a></li>
                  <li ><a href="#"  style="color:White">Privacy&Policy</a></li>
                   <li ><a href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf"  style="color:White">FAQs</a></li>
              </ul>--%>
                    </div>
                </div>
            </div>
            <%--  </footer>--%>
        </div>
    </div>
    </form>
</body>
</html>
