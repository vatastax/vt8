<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ECA_Details.aspx.cs"
    Inherits="Presentation_ECA_Details" %>

<%@ Register Src="~/UserControls/header.ascx" TagName="menuheader" TagPrefix="header" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>The Interactive Platform for free e-filing Income Tax Returns in India</title>
    <link rel="icon" href="../images/fevicon.PNG" type="image/gif" />
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="../foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
    <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <script src="../foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="../js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>
    <script src="../js/modernizr.custom.js" type="text/javascript"></script>
    <script src="../js/classie.js" type="text/javascript"></script>
    <link href="../ECAStyleSheet/Master.css" rel="stylesheet" type="text/css" />
    <link href="../css/smart_wizard.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-2.0.0.min.js" type="text/javascript"></script>
    <script src="../js/jquery.smartWizard.js" type="text/javascript"></script>
    <link href="../css/big_box_style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            // $("#btnUpload").click(function () {
            //alert('ggg');


            // $('step-4').css("display", "none");
            //            });
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
            if (document.URL.toString().indexOf('?st') != -1) {
                //alert(document.URL);
                if (document.URL.toString().substring((document.URL.toString().length - 4), document.URL.toString().length) == "fail")
                    HighlightStep(3);
                else if (document.URL.toString().substring((document.URL.toString().length - 4), document.URL.toString().length) == "pass") {
                    // $('#step-2').css("display", "none");
                    HighlightStep(4);
                    $('#divSucessMsg').css("display", "block");
                    if ($('a').hasClass('buttonPrevious ')) {
                        $('a').removeClass('buttonDisabled');
                    }
                    else if ($('a').hasClass('buttonFinish ')) {
                        $('a').removeClass('buttonDisabled');
                    }
                    $('.buttonPrevious').click(function () {
                        //                        if ($('a').hasClass('buttonNext')) {
                        //                            $('a').removeClass('buttonDisabled');
                        //                        }
                        //                        else if ($('a').hasClass('buttonFinish ')) {
                        //                            $(this).addClass('buttonDisabled');
                        //                        }
                        //                        if (('a').attr('rel') == 2) {
                        //                            HighlightStep(2);
                        //                        }
                        $('a').each(function () {


                            var href = $(this).attr('href');
                            if (href == '#step-3') {
                                if ($(this).hasClass('selected')) {
                                    // alert('sss');
                                    HighlightStep(2);
                                }
                                else {
                                    HighlightStep(3);
                                }
                            }
                        })

                    });

                }
            }
            else {
                if ($('#hdnStatus').val() == 'true') {
                    $('a').each(function () {
                        var href = $(this).attr('href');
                        if (href == '#step-4') {
                            alert('ggg');
                            $(this).css('display', 'none');
                            $(this).attr('href', '#');
                        }

                        //                    if (href == '#step-2') {
                        //                        if ($(this).hasClass('done')) {
                        //                            alert('ggg2');
                        //                            // $(this).css('display', 'none');
                        //                            //if($(this))
                        //                            // $('div #step-4').css('display','none');
                        //                            $('.buttonNext').addClass('disabled');
                        //                            $('.buttonNext').addClass('buttonDisabled');
                        //                        }



                    })
                }
            }
            //            $('.buttonNext').click(function () {
            //                if ($('#hdnStatus').val() == 'true') {
            //                    alert('true');
            //                    $('a').each(function () {
            //                        var href = $(this).attr('href');
            //                        if (href == '#step-2') {
            //                            if ($(this).hasClass('selected')) {
            //                                alert('ggg1');
            //                                // $(this).css('display', 'none');
            //                                //if($(this))
            //                                // $('div #step-4').css('display','none');
            //                                $('.buttonNext').addClass('disabled');
            //                                $('.buttonNext').addClass('buttonDisabled');
            //                                $('#step-4').css('display', 'none');
            //                            }
            //                            else if ($(this).hasClass('done')) {
            //                                alert('ggg1');
            //                                // $(this).css('display', 'none');
            //                                //if($(this))
            //                                // $('div #step-4').css('display','none');
            //                                $('#step-4').css('display', 'none');
            //                                $('.buttonNext').addClass('disabled');
            //                                $('.buttonNext').addClass('buttonDisabled');
            //                            }
            //                        }
            //                    })
            //                }
            //            })
            // $('#step-3').attr('isdone', '1');
            // $('#step-2').attr('isdone', '0');
            // $('#step-4').attr('isdone', '0');
            function HighlightStep(val) {
                $('#step-' + val).css("display", "block");
                $('#step-' + (parseInt(val - 1)).toString()).css("display", "none");
                $('#step-' + (parseInt(val - 2)).toString()).css("display", "none");
                $('#step-' + (parseInt(val + 1)).toString()).css("display", "none");
                $('a').each(function () {
                    var href = $(this).attr('href');

                    if (href == '#step-' + val.toString()) {
                        $(this).attr('isdone', '1');
                        $(this).removeClass('disabled');

                        $(this).addClass('selected');

                        $('.buttonPrevious').removeClass('buttonDisabled');
                        $('.stepContainer').css('height', 'auto');

                    } else if (href == '#step-' + (parseInt(val - 1)).toString()) {

                        $(this).attr('isdone', '0');
                        $(this).addClass('disabled');
                    }
                    else if (href == '#step-' + (parseInt(val - 2)).toString()) {

                        $(this).attr('isdone', '0');
                        $(this).addClass('disabled');
                    }
                    else if (href == '#step-' + (parseInt(val + 1)).toString()) {

                        $(this).attr('isdone', '0');
                        $(this).addClass('disabled');
                    }

                })


            }

        });
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {

        }
        //following event is being used as the last event after page loaded for updatepanel asynchronous events
        function EndRequestHandler(sender, args) {
            //            $("#btnUpload").click(function () {
            //                $('step-2').css("display", "block");
            //                $('step-1').css("display", "none");
            //                $('step-3').css("display", "none");
            //                $('step-4').css("display", "none");
            //            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
    <div class="row show-for-small-only ">
        <div class="small-12 columns">
            <a href="Default.aspx">
                <img src="../images/logo2.PNG" style="width: 240px" /></a>
        </div>
    </div>
    <!--menu for small screen-->
    <div class="large-3 columns show-for-small-only ">
        <!--left-menu(quick links)-->
        <nav class="cbp-spmenu cbp-spmenu-vertical cbp-spmenu-left " id="cbp-spmenu-s1">
                   <ul style="list-style-type:none">
			        <h3>Quick Links</h3>
			        <li ><a href="AboutUs.aspx" >About Us</a></li>
                    <li ><a href="ContactUsNew.aspx">Contact Us</a></li>
                    <li><a href="News.aspx" >Latest News</a></li>
                    <li ><a href="SiteMap.aspx" >Site Map</a></li>
                    <li><a href="Terms_Conditions.aspx" >Terms & Conditions</a></li>
                    <li><a href="#" >Feedback & Support</a></li>
                 
                    <li ><a href="PrivacyPolicy.aspx" >Privacy Policy</a></li>
                   </ul>
		        </nav>
        <!--left-menu(quick links)-->
        <!--top-menu(main menu)-->
        <nav class="cbp-spmenu cbp-spmenu-horizontal cbp-spmenu-top" id="cbp-spmenu-s3">
                   <ul style="list-style-type:none;margin-left: 0.5rem;">
                      <img src="../images/logo2.PNG" style="width:200px; height:auto;margin:5px 0 2px 5px;"/>
			            <li ><a href="default.aspx " >Home</a></li>
                        <li ><a href="Services.aspx">Services</a></li>
                        <li style="padding-left:5px"><a href="AboutUs.aspx">About</a></li>
                        <li><a href="ContactUsNew.aspx" >Contact</a></li>
                          <%--   <li><a href="Pricings.aspx" >Pricing</a></li>--%>
                        <li><a href="Presentation/login.aspx" >Login</a></li>
                        <%--<li id="li_logout_mob" runat="server"><a href="Presentation/logout.aspx" >Logout</a></li>--%>
                   </ul>
                 </nav>
        <!--placement of menu images-->
        <div class="row text-right">
            <!-- Class "cbp-spmenu-open" gets applied to menu -->
            <%--<button  id="showLeft">Menu</button>	--%>
            <img src="../images/menu.PNG" alt="menu" id="showTop" />
            <%--<img src="../images/mobilemenu.PNG" id="showLeft" />--%>
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
        <div class="large-3 columns hide-for-small hide-for-medium">
            <!--Resolution Problem Solved - Jaipal -->
            <a href="Default.aspx">
                <img src="../images/logo2.PNG" alt="logo" style="width: 240px; height: auto" /></a>
        </div>
        <div class="large-9 columns hide-for-small hide-for-medium ">
            <!--Resolution Problem Solved - Jaipal -->
            <ul class="right button-group">
                <li><a href="default.aspx" class="button">HOME</a></li>
                <li><a href="Services.aspx" class="button">SERVICES</a></li>
                <li><a href="AboutUs.aspx" class="button">ABOUT US</a></li>
                <li><a href="ContactUsNew.aspx" class="button">CONTACT US</a></li>
                <%--  <li><a href="Pricings.aspx" class="button">PRICING</a></li>--%>
                <li id="li_Login" runat="server" class="has-sub"><a href="Presentation/Login.aspx"
                    class="button">LOGIN</a>
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
                         <asp:ImageButton ID="imgRefresh" runat="server" ImageUrl="../images/refresh.png"  />
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
						<asp:Button ID="Button1" runat="server" Text="Login"   class="loginBtn"  ValidationGroup="loginpopup" style="padding-top:0px; padding-bottom:0px;  font-size: larger; margin-bottom:0;border-radius:4px"  ></asp:Button>
					</p>
                    <br />
                    <p style="text-align:center;margin-top:-26px;">
                     <asp:LinkButton ID="lnkSignup" runat="server" Text="Signup" ForeColor="#008cba" Font-Bold="true"  Font-Size="12px"></asp:LinkButton><br />
                     <asp:LinkButton ID="lnkPwd" runat="server" Text="Forget Password???" ForeColor="#008cba" Font-Bold="true"  Font-Size="12px"></asp:LinkButton>
                     
                    </p>
			</section>
                            </div>
                            <%-----------------------------------------------------------------------------------------------%>
                        </li>
                    </ul>
                </li>
                <li id="li_Logout" runat="server">
                    <asp:LinkButton ID="lbtnLogout" runat="server" Text="LOGOUT" CssClass="button"></asp:LinkButton>
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
                <li><a href="default.aspx" style="font-size: 12px" class="button">HOME</a></li>
                <li><a href="Services.aspx" style="font-size: 12px" class="button">SERVICES</a></li>
                <li><a href="AboutUs.aspx" style="font-size: 12px" class="button">ABOUT US</a></li>
                <li><a href="ContactUsNew.aspx" style="font-size: 12px" class="button">CONTACT US</a></li>
                <%--  <li><a href="Pricings.aspx" style="font-size: 12px" class="button" >PRICING</a></li>--%>
                <li id="li_Login1" runat="server"><a href="Presentation/login.aspx" style="font-size: 12px"
                    class="button">LOGIN</a></li>
                <li id="li_Logout1" runat="server">
                    <asp:LinkButton ID="lbtnLogout1" runat="server" Text="LOGOUT" Style="font-size: 12px"
                        CssClass="button"></asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div style="float: right;">
            <asp:Literal ID="ltWelcome" runat="server"></asp:Literal>
        </div>
    </div>
    <br />
    <!-- Tabs -->
    <div class="row">
        <div class="large-12 columns">
            <div id="wizard1" class="swMain">
                <ul>
                    <%--<li><a href="#step-1">
                        <span class="stepDesc">Personal Information<br />
                        </span></a></li>--%>
                    <li><a href="#step-2">
                        <%--       <label class="stepNumber">2</label>--%>
                        <span class="stepDesc">Upload Documents<br />
                            <%--  <small>Enable Finish Button</small>--%>
                        </span></a></li>
                    <li><a href="#step-3">
                        <%--  <label class="stepNumber">3</label>--%>
                        <span class="stepDesc">Payment<br />
                            <%--   <small>Step 3 description</small>--%>
                        </span></a></li>
                    <li><a href="#step-4">
                        <%--        <label class="stepNumber">4</label>--%>
                        <span class="stepDesc">Assigned Expert
                            <br />
                            <%--     <small>Step 4 description</small>--%>
                        </span></a></li>
                </ul>
                <%--<div id="step-1">
                    <h2 class="StepTitle">
                        Personal Information</h2>
                    <br />
                    <div class="row">
                        <div class="large-3 columns">
                            Name</div>
                        <div class="large-3 columns">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
                            <div class="large-3 columns">
                            Father Name</div>
                        <div class="large-3 columns">
                            <asp:TextBox ID="txtFName" runat="server"></asp:TextBox></div>
                    </div>
                  
                 
                    <div class="row">
                        <div class="large-3 columns">
                            PAN</div>
                        <div class="large-3 columns">
                            <asp:TextBox ID="txtPAN" runat="server"></asp:TextBox></div>
                             <div class="large-3 columns">
                            Date of Birth</div>
                        <div class="large-3 columns">
                            <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox></div>
                    </div>
              
                    <div class="row">
                        <div class="large-3 columns">
                            Address</div>
                        <div class="large-3 columns">
                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></div>
                            <div class="large-3 columns">
                            City</div>
                        <div class="large-3 columns">
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        </div>
                    </div>
                         
                          <div class="row">
                        <div class="large-3 columns">
                            State</div>
                        <div class="large-3 columns">
                            <asp:DropDownList ID="ddState" runat="server" Width="198px">
                            </asp:DropDownList>
                           </div>
                               <div class="large-3 columns">
                            Pin Code</div>
                        <div class="large-3 columns">
                            <asp:TextBox ID="txtPin" runat="server"></asp:TextBox></div>
                    </div>
                         
                    <div class="row">
                        <div class="large-3 columns">
                            Mobile No.</div>
                        <div class="large-3 columns">
                            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox></div>
                              <div class="large-3 columns">
                            Email</div>
                        <div class="large-3 columns">
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></div>
                    </div>
                       <div class="row">
                        <div class="large-3 columns">
                         </div>
                        <div class="large-3 columns">
                         </div>
                              <div class="large-3 columns">
                          </div>
                        <div class="large-3 columns">
                            <asp:Button ID="btnSavePersonalInfo" runat="server" Text="Save" class="button radius" /></div>
                    </div>
                </div>--%>
                <div id="step-2">
                    <h2 class="StepTitle">
                        Upload Documents</h2>
                    <br />
                    <div class="row">
                        <div class="large-4 columns">
                            Upload documents
                        </div>
                        <div class="large-4 columns">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                        <div class="large-4 columns">
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
                                class="button radius" />
                            <%--<asp:Button ID="bb1" runat="server" />--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-12 columns">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText="No files uploaded">
                                <Columns>
                                    <asp:BoundField DataField="Text" HeaderText="Uploaded Documents" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%--<asp:LinkButton ID="lnkDownload" Text="Download" 
                                                runat="server" OnClick="DownloadFile"></asp:LinkButton>--%>
                                            <asp:Button ID="btnDownload" runat="server" Text="Download" ToolTip='<%# Eval("Value") %>'
                                                OnClick="DownloadFile" CssClass="radius button" Style="height: 20px; padding-top: 0;
                                                padding-left: 4; padding-right: 4; margin: 0 0 0 0;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%--<asp:LinkButton ID="lnkDelete" Text="Delete" CommandArgument='<%# Eval("Value") %>'
                                                runat="server" OnClick="DeleteFile" />--%>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip='<%# Eval("Value") %>'
                                                OnClick="DeleteFile" CssClass="radius button" Style="height: 20px; padding-top: 0;
                                                padding-left: 4; padding-right: 4; margin: 0 0 0 0;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div id="step-3">
                    <h2 class="StepTitle">
                        Payment</h2>
                    <div class="row">
                        <div class="large-4 columns " style="margin: 0px; padding: 0px">
                            <ul class="pricing-table">
                                <li class="title" style="background-color: #494e6b">Standard</li>
                                <li class="price">
                                    <img src="../images/rupee-symbol.png" />&nbsp;149/-</li>
                                <%--    <li class="description"></li>--%>
                                <li class="bullet-item"><i class="foundicon-graph"></i>Salary</li>
                                <li class="bullet-item"><i class="foundicon-graph"></i>House Property</li>
                                <li class="bullet-item"><i class="foundicon-address-book"></i>Business Income (presumptive)
                                </li>
                                <li class="bullet-item"><i class="foundicon-website"></i>Other Sources</li>
                                <li class="bullet-item" style="color: White"><i class="foundicon-website"></i>30 minute
                                    talk with CA</li>
                                <li class="bullet-item" style="color: #e14658; font-weight: bold; font-size: 17px"><i
                                    class="foundicon-website"></i>PLUS</li>
                                <li class="bullet-item"><i class="foundicon-website"></i>ITR reviewed by CA</li>
                                <li class="bullet-item" style="color: White"><i class="foundicon-cloud"></i>Capital
                                    Gains</li>
                                <li class="cta-button "><a class="button radius" href="#">Pay Now</a></li>
                            </ul>
                        </div>
                        <div class="large-4 columns recommended">
                            <ul class="pricing-table right-side">
                                <li class="title" style="background-color: #494e6b">Professional</li>
                                <li class="price">
                                    <img src="../images/rupee-symbol.png" />&nbsp;399/-</li>
                                <%--   <li class="description"></li>--%>
                                <li class="bullet-item"><i class="foundicon-graph"></i>Salary (Multiple Employer)</li>
                                <li class="bullet-item"><i class="foundicon-graph"></i>House Property (Multiple )</li>
                                <li class="bullet-item"><i class="foundicon-cloud"></i>Business Income </li>
                                <li class="bullet-item"><i class="foundicon-address-book"></i>Capital Gains </li>
                                <li class="bullet-item"><i class="foundicon-website"></i>Other Sources</li>
                                <li class="bullet-item" style="color: #e14658; font-weight: bold; font-size: 17px"><i
                                    class="foundicon-website"></i>PLUS</li>
                                <li class="bullet-item"><i class="foundicon-website"></i>ITR prepared by CA</li>
                                <li class="bullet-item" style="color: White"><i class="foundicon-website"></i>30 minute
                                    talk with CA</li>
                                <li class="cta-button "><a class="button radius" href="../PersonalInfo.aspx">Pay Now</a></li>
                            </ul>
                        </div>
                        <div class="large-4 columns" style="margin: 0px; padding: 0px">
                            <ul class="pricing-table right-side">
                                <li class="title" style="background-color: #494e6b">Professional Plus</li>
                                <li class="price">
                                    <img src="../images/rupee-symbol.png" />&nbsp;599/-</li>
                                <%--    <li class="description"></li>--%>
                                <li class="bullet-item"><i class="foundicon-graph"></i>Salary (Multiple Employer)</li>
                                <li class="bullet-item"><i class="foundicon-graph"></i>House Property (Multiple)
                                </li>
                                <li class="bullet-item"><i class="foundicon-cloud"></i>Business Income</li>
                                <li class="bullet-item"><i class="foundicon-address-book"></i>Capital Gains</li>
                                <li class="bullet-item"><i class="foundicon-website"></i>Other Sources</li>
                                <li class="bullet-item" style="color: #e14658; font-weight: bold; font-size: 17px"><i
                                    class="foundicon-website"></i>PLUS</li>
                                <li class="bullet-item"><i class="foundicon-website"></i>ITR prepared by CA </li>
                                <li class="bullet-item"><i class="foundicon-website"></i>30 minute talk with CA</li>
                                <li class="cta-button">
                                    <asp:Button ID="btnEnrollNow3" runat="server" Text="Pay Now" CssClass="button radius"
                                        OnClick="btnEnrollNow3_Click" />
                                    <%--<a class="button radius" href="PersonalInfo.aspx">Enroll Now</a>--%></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div id="step-4">
                    <h2 class="StepTitle">
                        Expert Details</h2>
                    <div class="row">
                        <div class="large-12 columns text-center">
                            <img src="../images/ca.png" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-12 columns text-center">
                            Your return has been assigned to CA Honey Vig
                        </div>
                    </div>
                    <div class="row">
                        <div class="large-12 columns text-center">
                            Expect call from him within 24 hours or you can contact him directly at 0181-2258999
                        </div>
                    </div>
                    <br />
                    <div class="row" id="divSucessMsg" style="display: none">
                        <div class="large-12 columns">
                            <div class="login-wrap">
                                <div class="row">
                                    <div class="large-12 columns">
                                        <center>
                                            <p>
                                                Thank you.<br />
                                                Your payment has been done sucessfully.</p>
                                        </center>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    <!-- End SmartWizard Content -->
    <%-- </ContentTemplate>
       <Triggers>
      
        <asp:PostBackTrigger ControlID = "btnUpload" />
    </Triggers>
    </asp:UpdatePanel>--%>
    <%----------add code of default2.aspx ---------------%>
    <%--   <form id="form2" runat="server" method="post">--%>
    <div id="frmError" runat="server">
        <span style="color: red">Please fill all mandatory fields.</span>
        <br />
        <br />
    </div>
    <input type="hidden" runat="server" id="key" name="key" />
    <input type="hidden" runat="server" id="hash" name="hash" />
    <input type="hidden" runat="server" id="txnid" name="txnid" />
    <input type="hidden" runat="server" id="enforce_paymethod" name="enforce_paymethod" />
    <table style="display: none;">
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
                <asp:TextBox ID="amount" runat="server" Text="1" />
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
                <%--<asp:TextBox ID="surl" runat="server" Text="http://www.echarteredaccountants.com?st=pass" />--%>
                <asp:TextBox ID="surl" runat="server" Text="http://localhost:1126/tfs_vatas/Presentation/ECA_Details.aspx?st=pass" />
            </td>
        </tr>
        <tr>
            <td>
                Failure URI:
            </td>
            <td colspan="3">
                <%--<asp:TextBox ID="furl" runat="server" Text="http://www.echarteredaccountants.com?st=fail" />--%>
                <asp:TextBox ID="furl" runat="server" Text="http://localhost:1126/tfs_vatas/Presentation/ECA_Details.aspx?st=fail" />
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
    <asp:Button ID="submit" Text="submit" Width="100px" runat="server" OnClick="Button1_Click"
        Style="display: none;" />
        <asp:HiddenField ID="hdnStatus" runat="server" Value="true" />
    <%--   </form>--%>
    </form>
</body>
