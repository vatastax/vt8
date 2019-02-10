<%@ Page Language="C#" AutoEventWireup="true" CodeFile="servicetax.aspx.cs" Inherits="servicetax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Service Tax</title>
    <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <script src="../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="../foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
    <script src="../sliderengine/jquery.js" type="text/javascript"></script>
    <script src="../sliderengine/jquery.js" type="text/javascript"></script>
    <script src="../sliderengine/amazingslider.js" type="text/javascript"></script>
    <script src="../js/modernizr.custom.34978.js" type="text/javascript"></script>
    <script src="../js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>
    <script src="../sliderengine/initslider-1.js" type="text/javascript"></script>
    <link href="../css/new_button.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
    <link href="../style_folder/StaticStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
    <link rel="icon" type="image/png" href="../images/fevicon.png" />
    <link rel="shortcut icon" type="image/png" href="../images/fevicon.png" />
    <!--IE Compatibility-->
    <script src="../js/ie_compatibility/es5-shim.min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/html5shiv.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/nwmatcher-1.2.5-min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/respond.min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/selectivizr-1.0.3b.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <%--    <div class="row" style="margin-top: 10px">
        <div class="large-8 columns">
        </div>
        <div class="large-4 columns text-right">
        </div>
    </div>--%>
    <%------------------show logo and menu on mobile screen -----------------------%>
    <div class="row show-for-small-only ">
        <div class="large-3 columns">
            <a href="../default.aspx">
                <img src="../images/logo2.png" style="width: 240px" /></a>
        </div>
        <div class="large-9 columns ">
            <div class="rmm" data-menu-style="minimal">
                <ul>
                    <li><a href="../default.aspx" class="button">Go To</a></li>
                    <li><a href="../guidehub.aspx" class="button">Demo to e-filing</a></li>
                    <li><a href="#" class="button">Price Guide</a></li>
                    <%--<li><a href="#" class="button">Rates and Tables</a></li>--%>
                    <li><a href="#" class="button">Login</a></li>
                </ul>
            </div>
        </div>
    </div>
    <%------------------show logo and menu on medium and large screen ----------%>
    <div class="row hide-for-small-only" style="margin-top: 4px">
        <div class="large-3 columns">
            <a href="../Default.aspx">
                <img src="../images/logo2.png" alt="Logo" style="width: 240px" /></a>
        </div>
        <div class="large-9 columns ">
            <ul class="right button-group">
                <li><a class="button">Go-To</a>
                    <ul style="background-color: gray; opacity: 0.7; border: 1px solid gray; border-radius: 10px;">
                        <li style="padding-top: 4px;"><a href="../pageRedirect.aspx?prj=vt" style="color: white;">
                            <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Income Tax Return</a> &nbsp;
                            <a href="../pageRedirect.aspx?prj=tds" style="color: white;">
                                <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Tax Deducted at Source</a></li>
                        <li style="padding-top: 2px;"><a href="../vat.aspx" style="color: white;">
                            <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Value Added Tax</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="../cet.aspx" style="color: white;">
                                <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Central Excise Tax</a></li>
                        <li style="padding-top: 2px; padding-bottom: 2px;"><a href="../nri.aspx" style="color: white;">
                            <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;NRI Taxation</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a
                                href="../tp.aspx" style="color: white;"><img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Transfer
                                Pricing</a></li>
                    </ul>
                </li>
                <li><a href="../guidehub.aspx" class="button">Demo to e-filing</a></li>
                <li><a href="#" class="button">Price Guide</a></li>
                <%--<li><a href="#" class="button">Rates and Tables</a></li>--%>
                <li><a href="#" class="button">Login</a></li>
            </ul>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="large-12 columns">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Arial Rounded MT Bold"
                ForeColor="#333333">
            </asp:SiteMapPath>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
    </div>
    <%------------------------------Breadcrump --------------------------------------%>
    <div class="row">
        <div class="large-12 columns">
            <div class="large-6 columns text-left">
                <span style="font-family: Cambria;"><a href="../Default.aspx">Home</a></span><span></span>
                <span style="font-family: Cambria; font-weight: bold;">>Service Tax</span>
            </div>
            <div class="large-6 columns text-right" style="margin-bottom: 5px">
                <a href="../Default.aspx">
                    <input type="button" value="Back to Home" class="newbtn" /></a>
            </div>
        </div>
    </div>
    <div class="row hide-for-small-only heading">
        <div class="large-12 columns text-center">
            <p class="lplh-58" style="text-align: center;">
                <br />
                <span style="color: #052A3C;"><span style="font-size: 30px;"><span style="font-family: Cambria;
                    line-height: 1.1">Welcome to the <b>Service Tax</b> Return Filing</span></span></span>
            </p>
        </div>
    </div>
    <div class="row text-center ">
        <div class="large-4 columns links">
            <a href="Default.aspx" class="button6 green2" style="padding-left: 25px; text-decoration: none;
                width: 290px; height: 80px;">E-File<br />
                Yourself</a>
        </div>
        <div class="large-4 columns links ">
            <a href="Default.aspx" class="button6 green2 " style="text-decoration: none; width: 290px;
                height: 80px;">E-file with CA Assistance</a>
        </div>
        <div class="large-4 columns links ">
            <a href="Default.aspx" class="button6 green2 " style="text-decoration: none; width: 290px;
                height: 80px;">Multiple Filing for Tax Professionals</a>
        </div>
    </div>
    <div style="background-color: gray; margin-top: 10px">
        <br />
        <div class="row" style="background-color: gray">
            <div class="large-4 columns">
                <a href="https://onlineservices.cbec-easiest.gov.in/csi/index.html" target="_blank"
                    class="button5 blue7" style="height: 50px; width: 220px; background-color: gray;">
                    <img src="../images/challan2.png" /></a>
            </div>
            <div class="large-4 columns">
                <a href=" https://cbec-easiest.gov.in/EST/AssesseeVerification.do" target="_blank"
                    class="button5 blue7" style="height: 50px; width: 220px; background-color: gray;">
                    <img src="../images/assessee2.png" /></a>
            </div>
            <%--<div class="large-3 columns" >
         <a href=" #" class="button5 blue7"  style=" height:50px; width:220px;  background-color:gray;"></a>
         </div>--%>
            <div class="large-4 columns">
                <a href=" https://cbec-easiest.gov.in/EST/InputPageForEPaymentServlet" target="_blank"
                    class="button5 blue7" style="height: 50px; width: 220px; margin: 5px 10px 0 10px;
                    background-color: gray; color: black;">
                    <img src="../images/epay.png" /></a>
            </div>
        </div>
    </div>
    <!-- Footer -->
    <div style="background-color: gray">
        <div class="row">
            <div class="large-12 columns " style="margin-top: -20px;">
                <br />
                <div class="row">
                    <div class="large-4 columns footer-links">
                        <a style="font-family: Cambria; font-size: 1.4375em; color: white; cursor: default;">
                            About</a>
                        <ul style="list-style-type: disc; color: #e1e3e5; font-family: Calibri; padding-left: 15px">
                            <li><a href="../AboutUs.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5">E-Charated Accontants</a></li>
                            <li><a href="../ContactUsNew.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5">Contact details</a></li>
                            <li><a href="../News.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5">News</a></li>
                            <li><a href="../Terms_Conditions.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5">Terms of use</a></li>
                            <li><a href="../PrivacyPolicy.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5">Privacy Policy</a></li>
                            <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                line-height: 1.42857; color: #e1e3e5">Site Map</a></li>
                            <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                line-height: 1.42857; color: #e1e3e5">FAQ's</a></li>
                        </ul>
                    </div>
                    <div class="large-5 columns footer-links">
                        <a style="font-family: Cambria; font-size: 1.4375em; color: white; cursor: default;">
                            How-tos</a>
                        <ul style="list-style-type: disc; color: #e1e3e5; font-family: Calibri; padding-left: 15px">
                            <li><a href="../GuideHub.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5">Guide to Service Tax e-filing</a></li>
                            <li><a href=" https://onlineservices.cbec-easiest.gov.in/csi/index.html" target="_blank"
                                style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 1.42857;
                                color: #e1e3e5">Know Status of Challan</a></li>
                            <li><a href=" https://cbec-easiest.gov.in/EST/AssesseeVerification.do" target="_blank"
                                style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 1.42857;
                                color: #e1e3e5">Know Status of Assessee</a></li>
                            <li><a href=" https://cbec-easiest.gov.in/EST/InputPageForEPaymentServlet" target="_blank"
                                style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 1.42857;
                                color: #e1e3e5">e-Payment</a></li>
                            <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                line-height: 1.42857; color: #e1e3e5">All Plans with Pricing</a></li>
                        </ul>
                    </div>
                    <div class="large-3 columns footer-links">
                        <a style="font-family: Cambria; font-size: 1.4375em; color: white; cursor: default;">
                            Services</a>
                        <ul style="list-style-type: disc; color: #e1e3e5; font-family: Calibri; padding-left: 15px">
                            <li><a href="../pageRedirect.aspx?prj=vt" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Income Tax Return</a></li>
                            <li><a href="../pageRedirect.aspx?prj=tds" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Tax Deducted At Source</a></li>
                            <li><a href="../vat.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                line-height: 1.42857; color: #e1e3e5;">Value Added Tax</a></li>
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
            <br />
            <hr style="margin-top: -10px;" />
            <div class="large-3 columns">
                <p style="color: #e1e3e5">
                    © 2015 Vatas Infotech Pvt.Ltd.</p>
            </div>
            <div class="large-9 columns text-right">
                <a href="https://www.facebook.com/echarteredaccountants" target="_blank">
                    <img src="../images/fb.png" alt="Facebook" /></a> <a href="http://www.twitter.com/ECAccountant"
                        target="_blank">
                        <img src="../images/twitter.png" alt="Twitter" /></a> <a href="https://in.linkedin.com/pub/vatas-infotech/b9/264/a82"
                            target="_blank">
                            <img src="../images/LINKEDIN1.PNG" alt="Linkedin" /></a> <a href="https://plus.google.com/u/0/b/108616341946641442746/108616341946641442746"
                                target="_blank">
                                <img src="../images/google.png" alt="GooglePlus" /></a>
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
    </form>
</body>
</html>
