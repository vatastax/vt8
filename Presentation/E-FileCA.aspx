<%@ Page Language="C#" AutoEventWireup="true" CodeFile="E-FileCA.aspx.cs" Inherits="E_FileCA" %>

<!DOCTYPE html >

<html class="no-js" lang="en">
<head id="Head1" runat="server">
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <title>E-File with CA</title>
    <link rel="icon" href="../images/fevicon.PNG"" type="image/gif"  />
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
    <link href="../css/new_button.css" rel="stylesheet" type="text/css" />
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
    <!-- BEGIN LivePerson Monitor. -->
    <script type="text/javascript">        window.lpTag = window.lpTag || {}; if (typeof window.lpTag._tagCount === 'undefined') { window.lpTag = { site: '21832554' || '', section: lpTag.section || '', autoStart: lpTag.autoStart === false ? false : true, ovr: lpTag.ovr || {}, _v: '1.5.1', _tagCount: 1, protocol: location.protocol, events: { bind: function (app, ev, fn) { lpTag.defer(function () { lpTag.events.bind(app, ev, fn); }, 0); }, trigger: function (app, ev, json) { lpTag.defer(function () { lpTag.events.trigger(app, ev, json); }, 1); } }, defer: function (fn, fnType) { if (fnType == 0) { this._defB = this._defB || []; this._defB.push(fn); } else if (fnType == 1) { this._defT = this._defT || []; this._defT.push(fn); } else { this._defL = this._defL || []; this._defL.push(fn); } }, load: function (src, chr, id) { var t = this; setTimeout(function () { t._load(src, chr, id); }, 0); }, _load: function (src, chr, id) { var url = src; if (!src) { url = this.protocol + '//' + ((this.ovr && this.ovr.domain) ? this.ovr.domain : 'lptag.liveperson.net') + '/tag/tag.js?site=' + this.site; } var s = document.createElement('script'); s.setAttribute('charset', chr ? chr : 'UTF-8'); if (id) { s.setAttribute('id', id); } s.setAttribute('src', url); document.getElementsByTagName('head').item(0).appendChild(s); }, init: function () { this._timing = this._timing || {}; this._timing.start = (new Date()).getTime(); var that = this; if (window.attachEvent) { window.attachEvent('onload', function () { that._domReady('domReady'); }); } else { window.addEventListener('DOMContentLoaded', function () { that._domReady('contReady'); }, false); window.addEventListener('load', function () { that._domReady('domReady'); }, false); } if (typeof (window._lptStop) == 'undefined') { this.load(); } }, start: function () { this.autoStart = true; }, _domReady: function (n) { if (!this.isDom) { this.isDom = true; this.events.trigger('LPT', 'DOM_READY', { t: n }); } this._timing[n] = (new Date()).getTime(); }, vars: lpTag.vars || [], dbs: lpTag.dbs || [], ctn: lpTag.ctn || [], sdes: lpTag.sdes || [], ev: lpTag.ev || [] }; lpTag.init(); } else { window.lpTag._tagCount += 1; } </script>
    <!-- END LivePerson Monitor. -->
    <br />
    <div class="row show-for-small-only " style="margin-top: -15px;">
        <div class="large-3 columns">
            <a href="../default.aspx">
                <img src="../images/logo2.PNG" style="width: 240px" /></a>
        </div>
        <div class="large-9 columns ">
            <div class="rmm" data-menu-style="minimal">
                <ul>
                    <li><a class="button">Go To</a></li>
                    <li><a href="../ITRScreenshots.aspx" class="button">Demo e-filing</a></li>
                    <li><a href="../PriceGuide.aspx" class="button">Price Guide</a></li>
                    <%--<li><a href="#" class="button">Rates and Tables</a></li>--%>
                    <li>
                        <asp:LinkButton ID="LinkButton2" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout11_Click"></asp:LinkButton></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="row hide-for-small" style="margin-top: -20px;">
        <div class="large-3 columns">
            <a href="../Default.aspx">
                <img src="../images/logo2.PNG" /></a>
        </div>
        <div class="large-9 columns ">
            <ul class="right button-group">
                <li><a href="default.aspx" class="button">Go-To</a>
                    <ul style="background-color: gray; opacity: 0.7; border: 1px solid gray; border: 1px solid gray;
                        border-radius: 10px; padding: 0 10px">
                        <li style="padding-top: 4px;"><a href="../pageRedirect.aspx?prj=tds" style="color: white;">
                            <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Tax Deducted at Source</a> <a
                                href="../Presentation/Gst.aspx" style="color: white;">
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
                <li><a href="../ITRScreenshots.aspx" class="button">Demo e-filing</a></li>
                <li><a href="../PriceGuide.aspx" class="button">Price Guide</a></li>
                <%-- <li><a href="#" class="button">Rates and Tables</a></li>--%>
                <li>
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout1_Click"></asp:LinkButton></li>
            </ul>
        </div>
        <div style="float: right;">
            <asp:Literal ID="ltWelcome" runat="server"></asp:Literal>
        </div>
    </div>
    <%------------------------------Breadcrump --------------------------------------%>
    <br />
    <div class="row">
        <div class="large-12 columns">
            <div class="large-6 columns text-left">
                <%--<span><a href="itr1.aspx">Income Tax Returns<a />&nbsp;&nbsp; <a href="e-fileyourself.aspx" style="color:Gray"> E-File yourself</a> &nbsp;&nbsp; <a href="presentation/login.aspx" >Multiple filing for tax professionals</a></span>--%>
                <span style="font-family: Cambria;"><a href="itr1.aspx">Income Tax Returns</a></span><span>
                    ></span> <span style="font-family: Cambria; font-weight: bold;">E-File with CA</span>
            </div>
            <div class="large-6 columns text-right">
                <a href="../Presentation/itr1.aspx">
                    <input type="button" value="Back to Home" class="newbtn" /></a>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="row  heading">
        <div class="large-12 columns text-center">
            <span style="color: #052A3C;"><span style="font-size: 30px; line-height: 0px;"><span
                style="font-family: Calibri">E-File Tax Returns with <b>CA</b><br />
            </span></span></span><span style="color: #052A3C; font-size: 16px; margin-top: 0px;
                font-family: Cambria">Our expert CAs are at your service.</br>They <b>Make, Review</b>
                & <b>File</b> your returns correctly after constant correspondence and approval
                of yours.</span>
        </div>
    </div>
    <br />
    <br />
    <div class="row show-for-small text-center">
        <div class="small-12 columns text-center">
            <div class="large-3 columns">
            </div>
            <div class="large-3 columns">
                <%--<a href="http://192.168.1.202:90/chatlogin.aspx" class="button4 red3" style="height:55px; width:260px; "   >Chat Client</a>--%>
                <div id="cc_mob">
                </div>
            </div>
            <div class="large-3 columns">
                <a href="QuerySupport.aspx" class="button4 red3" style="height: 55px; width: 260px;">
                    Query Support</a>
            </div>
            <div class="large-3 columns">
            </div>
        </div>
    </div>
    <div class="row show-for-medium text-center">
        <div class="large-12 columns text-center">
            <div class="large-3 columns">
            </div>
            <div class="large-3 columns">
                <%--<a href="http://192.168.1.202:90/chatlogin.aspx" class="button4 red3" style="height:55px; width:260px; "   >Chat Client</a>--%>
                <div id="cc_tab">
                </div>
            </div>
            <div class="large-3 columns">
                <a href="QuerySupport.aspx" class="button4 red3" style="height: 55px; width: 260px;">
                    Query Support</a>
            </div>
            <div class="large-3 columns">
            </div>
        </div>
    </div>
    <div class="row hide-for-small hide-for-medium text-center">
        <div class="large-12 columns text-center">
            <div class="large-6 columns">
                <%--<a href="http://192.168.1.202:90/chatlogin.aspx" class="button4 red3" style="height:55px; width:260px; "   >Chat Client</a>--%>
                <%--<div id="chat_client_big">
                </div>--%>
            </div>
            <div class="large-6 columns">
                <a href="QuerySupport.aspx" class="button4 red3" style="height: 55px; width: 260px;">
                    Query Support</a>
            </div>
        </div>
        <%-- <a href="#" class="button3">E-file yourself</a>--%>
    </div>
    <%-- <a href="#" class="button2 red" style="height:70px; width:200px;" id="trigger2">Multiple filing for tax professionals </a>--%>
    <%--<a href="#" class="button3">Multiple filing for tax professionals</a>--%>
    <%--<div class="large-4 columns links ">
       <%-- <ul class="enlarge"><li> <a href="#" class="button3 red">E-file with CA </a><span style="height:250px"><ul><li>At Your service</li><li>Our experts review your return</li><li>Experts ensure your returns are correct</li></ul></span></li></ul>--%>
    <%-- <a href="#" class="button3 red" > E-file with CA  </a>--%>
    <%--<a href="#" class="button2 red" style="padding-top:28px; height:70px; width:200px;" id="trigger1">E-file with CA </a>--%>
    </div> </div>
    <!-- Second Band (Image Left with Text) -->
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
                <div class="large-12 columns " style="margin-top: -20px">
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
                                <li><a href="../Presentation/Gst.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                    font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Goods & Service Tax</a></li>
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
                    <hr style="margin-top: -10px" />
                    <div class="row" style="background-color: gray; margin-top: -10px;">
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
