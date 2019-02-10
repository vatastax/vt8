<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuerySupport.aspx.cs" Inherits="Presentation_QuerySupport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Query Support</title>
    <link rel="icon" href="../images/fevicon.PNG" type="image/gif" sizes="16x16">
    <%--<link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>--%>
    <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <script src="../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <%--<link href="foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />--%>
    <script src="../foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="../foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
    <%-- <script src="sliderengine/jquery.js" type="text/javascript"></script>--%>
    <%--<link href="StaticStylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="StaticStylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />--%>
    <%-- <script src="sliderengine/jquery.js" type="text/javascript"></script>
      <script src="sliderengine/amazingslider.js" type="text/javascript"></script>--%>
    <%--<link href="sliderengine/amazingslider-1.css" rel="stylesheet" type="text/css" />--%>
    <script src="../js/modernizr.custom.34978.js" type="text/javascript"></script>
    <script src="../js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>
    <%-- <script src="sliderengine/initslider-1.js" type="text/javascript"></script>--%>
    <!--master style sheet-->
    <link href="../style_folder/StaticStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
    <script type="text/javascript">
        $(document).ready(function () {
            $('a#trigger').hover(function (e) {
                $('div#pop-up').show()
      .css('top', e.pageY)
      .css('left', e.pageX)
      .appendTo('body');
            }, function () {
                $('div#pop-up').hide();
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('a#trigger1').hover(function (e) {
                $('div#pop-up1').show()
      .css('top', e.pageY)
      .css('left', e.pageX)
      .appendTo('body');
            }, function () {
                $('div#pop-up1').hide();
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('a#trigger2').hover(function (e) {
                $('div#pop-up2').show()
      .css('top', e.pageY)
      .css('left', e.pageX)
      .appendTo('body');
            }, function () {
                $('div#pop-up2').hide();
            });
        });
    </script>
    <style type="text/css">
        h1
        {
            font-size: 30px;
            color: #37588B;
        }
        .button1
        {
            text-transform: uppercase;
            letter-spacing: 2px;
            text-align: center;
            color: #0C5;
            font-size: 24px;
            font-family: "Nunito" , sans-serif;
            font-weight: 300;
            position: absolute;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            width: 220px;
            height: 30px;
            background: #c74c3c;
            border: 1px solid #c74c3c;
            color: #FFF;
            overflow: hidden;
            transition: all 0.5s;
        }
        
        .button1:hover, .button:active
        {
            text-decoration: none;
            color: #c74c3c;
            border-color: #c74c3c;
            background: #FFF;
        }
        
        .button1 span
        {
            display: inline-block;
            position: relative;
            padding-right: 0;
            transition: padding-right 0.5s;
        }
        
        .button1 span:after
        {
            content: ' ';
            position: absolute;
            top: 0;
            right: -18px;
            opacity: 0;
            width: 10px;
            height: 10px;
            margin-top: -10px;
            background: rgba(0, 0, 0, 0);
            border: 3px solid #FFF;
            border-top: none;
            border-right: none;
            transition: opacity 0.5s, top 0.5s, right 0.5s;
            transform: rotate(-45deg);
        }
        
        .button1:hover span, .button:active span
        {
            padding-right: 30px;
        }
        
        .button:hover span:after, .button:active span:after
        {
            transition: opacity 0.5s, top 0.5s, right 0.5s;
            opacity: 1;
            border-color: #c74c3c;
            right: 0;
            top: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="row" style="margin-top: 10px">
        <div class="large-8 columns">
        </div>
        <div class="large-4 columns text-right">
        </div>
        <%--<div class="large-2 columns">
    </div>--%>
    </div>
    <br />
    <div class="row show-for-small-only " style="margin-top: -20px">
        <div class="large-3 columns">
            <a href="../default.aspx">
                <img src="../images/logo2.png" style="width: 240px" /></a>
        </div>
        <div class="large-9 columns ">
            <div class="rmm" data-menu-style="minimal">
                <ul>
                    <li><a class="button">Go To</a></li>
                    <li><a href="../ITRScreenshots.aspx" class="button">Demo to e-filing</a></li>
                    <li><a href="../PriceGuide.aspx" class="button">Price Guide</a></li>
                    <%--<li><a href="#" class="button">Rates and Tables</a></li>--%>
                    <li>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout11_Click"></asp:LinkButton></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="row hide-for-small" style="margin-top: -25px">
        <div class="large-3 columns">
            <a href="../Default.aspx">
                <img src="../images/logo2.png" /></a>
        </div>
        <div class="large-9 columns ">
            <ul class="right button-group">
                <li><a href="default.aspx" class="button">Go-To</a>
                    <ul style="background-color: gray; opacity: 0.8; border: 1px solid gray; border: 1px solid gray;
                        border-radius: 10px; padding: 0 10px">
                        <li style="padding-top: 4px;"><a href="../pageRedirect.aspx?prj=tds" style="color: white;">
                            <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Tax Deducted at Source</a> <a
                                href="../vat.aspx" style="color: white;">
                                <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Goods & Service Tax</a></li>
                        <li style="padding-top: 2px;"><a href="../pageRedirect.aspx?prj=stax" style="color: white;">
                            <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Service Tax</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="../cet.aspx" style="color: white;">
                                <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Central Excise Tax</a></li>
                        <li style="padding-top: 2px; padding-bottom: 2px;"><a href="../nri.aspx" style="color: white;">
                            <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;NRI Taxation</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a
                                href="../tp.aspx" style="color: white;"><img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Transfer
                                Pricing</a></li>
                    </ul>
                </li>
                <li><a href="../ITRScreenshots.aspx" class="button">Demo to e-filing</a></li>
                <li><a href="../PriceGuide.aspx" class="button">Price Guide</a></li>
                <li>
                    <asp:LinkButton ID="LinkButton2" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout1_Click"></asp:LinkButton></li>
            </ul>
        </div>
    </div>
    <%-- <%------------------------------Breadcrump --------------------------------------%>
    <%--<br /><div class="row">
        <div class="large-12 columns">--%>
    <%--<span><a href="itr1.aspx">Income Tax Returns<a />&nbsp;&nbsp; <a href="e-fileyourself.aspx" style="color:Gray"> E-File yourself</a> &nbsp;&nbsp; <a href="presentation/login.aspx" >Multiple filing for tax professionals</a></span>--%>
    <%-- <span style="font-family:Cambria;"> <a href="itr1.aspx">Income Tax Returns</a></span><span> ></span> <span style="font-family:Cambria; font-weight:bold;"> E-File with CA</span>
        </div>
    </div>--%>
    <br />
    <div class="row">
        <div class="large-12 columns">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true"
                NodeStyle-Font-Bold="false" ForeColor="#333333">
            </asp:SiteMapPath>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
    </div>
    <!--heading part-->
    <div class="row">
        <br />
        <div style="width: 80%; padding: 0 0 0 0; margin-left: 40px">
            <p>
                <span style="color: #e42200; font-size: 20px; font-weight: bold; margin-top: 10px;
                    margin-bottom: 10px; text-align: center; font-family: Cambria">Tell us your Query!
                </span></br> <span style="color: black; font-size: 16px; font-family: Calibri; font-weight: normal;
                    text-align: left;">We are always available to entertain your queries with our tax
                    experts. </span>
            </p>
        </div>
        <!--heading part-->
        <div class="row">
            <div class="login">
                <div class="login-main">
                    <div style="width: 85%; padding: 0 0 0 0; margin-left: 30px">
                        <div style="text-align: center; border: 2px solid #EB5739; border-radius: 20px; padding-left: 30px;
                            box-shadow: 3px 3px 5px #888888; -moz-box-shadow: 3px 3px 5px #888888; -webkit-box-shadow: 3px 3px 5px #888888;"
                            class="row ">
                            <br />
                            <div>
                                <img src="../images/query%20icon.png" style="height: 40px" /></div>
                            <span style="color: black; font-size: 17px; font-weight: bold; margin-bottom: 10px;
                                text-; font-family: Calibri">
                                <h1>
                                    Submit your Query</h1>
                                <br />
                            </span>
                            <div class="row " style="margin-bottom: 7px;">
                                <div class="large-12 columns ">
                                    <div class="large-2 columns">
                                        <label style="font-size: 17px; text-align: left; cursor: default; font-family: 'Open Sans', 'sans-serif';">
                                            Name:</label>
                                    </div>
                                    <div class="large-4 columns">
                                        <asp:TextBox ID="txtname" runat="server" type="text" placeholder="Enter Your Name"
                                            required TabIndex="1" Height="30px" Width="230" Style="border-radius: 5px;"></asp:TextBox>
                                    </div>
                                    <div class="large-2 columns">
                                        <label style="font-size: 17px; text-align: left; cursor: default; font-family: 'Open Sans', 'sans-serif';">
                                            E-Mail:</label>
                                    </div>
                                    <div class="large-4 columns">
                                        <asp:TextBox ID="txtemail" runat="server" TabIndex="2" placeholder="Enter Your E-Mail "
                                            Height="30px" Width="230" required OnTextChanged="txtemail_TextChanged" Style="border-radius: 5px;"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
                                            ControlToValidate="txtemail" ErrorMessage="Email id not in correct format" ForeColor="Red"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row " style="margin-bottom: 7px;">
                                <div class="large-12 columns ">
                                    <div class="large-2 columns">
                                        <label style="font-size: 17px; text-align: left; cursor: default; font-family: 'Open Sans', 'sans-serif';">
                                            Subject:</label>
                                    </div>
                                    <div class="large-4 columns">
                                        <asp:TextBox ID="txtsubject" runat="server" placeholder="Subject" TabIndex="3" Height="30px"
                                            Width="230" required Style="border-radius: 5px;"></asp:TextBox>
                                    </div>
                                    <div class="large-2 columns">
                                        <label style="font-size: 17px; text-align: left; cursor: default; font-family: 'Open Sans', 'sans-serif';">
                                            Comments:</label>
                                    </div>
                                    <div class="large-4 columns">
                                        <asp:TextBox ID="txtComment" runat="server" Height="100px" Width="230px" Style="border-radius: 5px;"
                                            required TabIndex="4" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="margin-bottom: 7px;">
                                <div class="large-2 columns">
                                    <label style="font-size: 16px; text-align: left; cursor: default; font-family: 'Open Sans', 'sans-serif';">
                                        Attachment:</label>
                                    <div style="text-align: left; cursor: default; font-size: 11px">
                                        (Only PDF Files Allowed)</div>
                                </div>
                                <div class="large-4 columns">
                                    <asp:FileUpload ID="FUpload1" runat="server" TabIndex="5" />
                                </div>
                                <div class="large-2 columns">
                                </div>
                                <div class="large-4 columns">
                                </div>
                                <%--<div class="row">
              <div class="large-3 columns text-left">
              </div>
              <div class="large-9 columns text-left" style="display: none">
                  <asp:Button ID="btnUpload" runat="server" Text="Upload" Class="btn_contact" OnClick="btnUpload_Click1" />
              </div>
          </div>--%>
                            </div>
                            <div class="row" style="margin-bottom: 7px;">
                                <div class="large-12 columns text-center">
                                    <asp:Button ID="Button1" runat="server" TabIndex="6" Text="Submit" class="radius button"
                                        OnClick="Button1_Click1" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--        <div style="width:50%; float:left">
        <%--<div class="row panel" style="background-color:White; ">
        hello
        </div>--%>
    </div>
    <%-- <a href="#" class="button2 red" style="height:70px; width:200px;" id="trigger2">Multiple filing for tax professionals </a>--%>
    <%--<a href="#" class="button3">Multiple filing for tax professionals</a>--%>
    <%--<div class="large-4 columns links ">
       <%-- <ul class="enlarge"><li> <a href="#" class="button3 red">E-file with CA </a><span style="height:250px"><ul><li>At Your service</li><li>Our experts review your return</li><li>Experts ensure your returns are correct</li></ul></span></li></ul>--%>
    <%-- <a href="#" class="button3 red" > E-file with CA  </a>--%>
    <%--<a href="#" class="button2 red" style="padding-top:28px; height:70px; width:200px;" id="trigger1">E-file with CA </a>--%>
    <!-- Second Band (Image Left with Text) -->
    <br />
    <br />
    <div style="background-color: gray; margin-top: 10px">
        </br>
        <div class="row" style="background-color: gray">
            <div class="large-3 columns">
                <a href="../TaxServices.aspx?service=26AS" class="button5 blue7" style="height: 50px;
                    width: 220px; background-color: gray;">
                    <img src="../images/form2.png" /></a>
            </div>
            <div class="large-3 columns">
                <a href="../TaxServices.aspx?service=ITRV" class="button5 blue7" style="height: 50px;
                    width: 220px; background-color: gray;">
                    <img src="../images/track2.png" /></a>
            </div>
            <div class="large-3 columns">
                <a href="../TaxCalculator.aspx" class="button5 blue7" style="height: 50px; width: 220px;
                    background-color: gray;">
                    <img src="../images/taxcal2.png" /></a>
            </div>
            <div class="large-3 columns">
                <a href="../TaxServices.aspx?service=RefundStatus" class="button5 blue7" style="height: 50px;
                    width: 220px; background-color: gray; color: black;">
                    <img src="../images/refund2.png" /></a>
            </div>
        </div>
    </div>
    <%-- <div class="large-12 columns" style=" background-image:url(images/pattern2.JPG); background-repeat: repeat-x; ">
         &nbsp;
        </div>--%>
    <div style="background-color: gray">
        <div style="background-color: gray">
            <div class="row">
                <div class="large-12 columns ">
                    </br>
                    <div class="row">
                        <div class="large-4 columns footer-links">
                            <a style="font-family: Cambria; font-size: 1.4375em; color: white;">About</a>
                            <ul style="list-style-type: disc; font-family: Calibri; padding-left: 15px; color: #e1e3e5;">
                                <li><a href="../AboutUs.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5;">E-Chartered Accountants.com</a></li>
                                <li><a href="../ContactUsNew.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Contact details</a></li>
                                <li><a href="../News.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5;">News</a></li>
                                <li><a href="../Terms_Conditions.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Terms of use</a></li>
                                <li><a href="../PrivacyPolicy.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Privacy Policy</a></li>
                                <li><a href="../ItrSiteMap.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Site Map</a></li>
                                <li><a href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf"
                                    target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                    line-height: 1.42857; color: #e1e3e5;">FAQ's</a></li>
                            </ul>
                        </div>
                        <%--<div class="large-3 columns footer-links">
         <a style="font-family:Cambria;  font-size:1.4375em; color:white">Guide Hub</a>
              <ul style=" list-style-type: disc; color:#e1e3e5; font-family:Calibri; padding-left:15px" >--%>
                        <%--<li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">Section 80 deductions</a></li>--%>
                        <%--<li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">Guide for understanding Form16</a></li>--%>
                        <%-- <li><a href="../itrscreenshots.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">Guide to ITR e-filing</a></li>
        
                <li><a href="../TaxServices.aspx?service=26AS" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">View your Form 26 AS</a></li>--%>
                        <%--<li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">All Plans with Pricing</a></li>--%>
                        <%--  </ul>
            </div>--%>
                        <div class="large-4 columns footer-links">
                            <a style="font-family: Cambria; font-size: 1.4375em; color: white">How-tos</a>
                            <ul style="list-style-type: disc; color: #e1e3e5; font-family: Calibri; padding-left: 15px">
                                <li><a href="../itrscreenshots.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5">Guide to ITR e-filing</a></li>
                                <li><a href="../TaxServices.aspx?service=26AS" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5">View your Form 26 AS</a></li>
                                <li><a href="../TaxServices.aspx?service=RefundStatus" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5">Check Income Tax Refund Status</a></li>
                                <li><a href="../Presentation/Default.aspx?incometax" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5">File Multiple Tax Returns</a></li>
                                <%--<li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">Changed jobs/ Have multiple Form 16</a></li>
                <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">How to pay tax i.e. due</a></li>--%>
                                <li><a href="../TaxServices.aspx?service=ITRV" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5">Tracking of ITR-V status</a></li>
                            </ul>
                        </div>
                        <div class="large-3 columns footer-links">
                            <a style="font-family: Cambria; font-size: 1.4375em; color: white">Services</a>
                            <ul style="list-style-type: disc; color: #e1e3e5; font-family: Calibri; padding-left: 15px">
                                <li><a href="../pageRedirect.aspx?prj=vt" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Income Tax Return</a></li>
                                <li><a href="../pageRedirect.aspx?prj=tds" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Tax Deducted At Source</a></li>
                                <li><a href="../vat.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                    line-height: 1.42857; color: #e1e3e5;">Goods & Service Tax</a></li>
                                <li><a href="../pageRedirect.aspx?prj=stax" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Service Tax</a></li>
                                <li><a href="../cet.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                    line-height: 1.42857; color: #e1e3e5;">Centeral Excise Tax</a></li>
                                <li><a href="../nri.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                    line-height: 1.42857; color: #e1e3e5;">NRI Taxation</a></li>
                                <li><a href="../tp.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                    line-height: 1.42857; color: #e1e3e5;">Transfer Pricing</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="background-color: gray">
                <div class="large-12 columns">
                    <hr />
                    <div class="row" style="background-color: gray">
                        <div class="large-3 columns">
                            <p style="color: #e1e3e5;">
                                © 2015 Vatas Infotech Pvt.Ltd.</p>
                        </div>
                        <div class="large-9 columns text-right">
                            <a href="https://www.facebook.com/echarteredaccountants" target="_blank">
                                <img src="../images/fb.png" /></a> <a href="http://www.twitter.com/ECAccountant"
                                    target="_blank">
                                    <img src="../images/twitter.png" /></a> <a href="https://in.linkedin.com/pub/vatas-infotech/b9/264/a82"
                                        target="_blank">
                                        <img src="../images/LINKEDIN1.PNG" /></a> <a href="https://plus.google.com/u/0/b/108616341946641442746/108616341946641442746"
                                            target="_blank">
                                            <img src="../images/google.png" /></a>
                            <%-- <ul class="inline-list right">
                
                <li ><a href="home2.aspx" style="color:White">Home</a></li>
                <li><a href="about.aspx"  style="color:White">About us</a></li>
                  <li ><a href="contact.aspx"  style="color:White">Contact us</a></li>
                 
                  <li ><a href="#"  style="color:White">Terms&Condition</a></li>
                  <li ><a href="#"  style="color:White">Privacy&Policy</a></li>
                   <li ><a 

href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf"  

style="color:White">FAQs</a></li>
              </ul>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- <div id="pop-up">
   
      <ul>
      <li>
       Lets You do it on your own
      </li>
      <li>
       It is free of cost
      </li>
      <li> Very simple to use</li>
      <li> Demo guide for your help</li>
      </ul>
     
     
      </div>
       <div id="pop-up1">
 <ul>
 <li>    E-file with CA </li>
 <li>  At Your service</li>
 <li> Our experts review your return</li>
 <li>   Experts ensure your returns are correct</li>
 </ul>
      
      </div>
       <div id="pop-up2">
    <ul>
   <li> Help for tax professional</li>
    <li> Our Portal helps tax professionals prepare & file ITR for their clients</li>
    <li>We provide you on individual login for multiple filings</li>
    </ul>
      
      </div>--%>
    </form>
</body>
</html>
