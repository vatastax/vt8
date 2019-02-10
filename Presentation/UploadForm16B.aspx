<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadForm16B.aspx.cs" Inherits="Presentation_UploadForm16B" %>

<%@ Register Src="../menu_header.ascx" TagName="menuheader" TagPrefix="header" %>
<%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../mobilemenu2.ascx" TagPrefix="mob1" TagName="menu1" %>
<!DOCTYPE html >
<html class="no-js" lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <title></title>
    <script type="text/javascript" src="Scripts/common.js"></script>
    <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <%--       <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />
           <link href="StyleSheet2.css" rel="stylesheet" type="text/css" />--%>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <link href="../style_folder/StaticStyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>
    <link href="../css/box_style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <%-- <div class="row hide-for-small-only">
        <div class="large-12 columns">
            <header:menuheader ID="header1" runat="server" />
        </div>
     </div>--%>
    <div class="row" style="margin-top: 10px">
        <div class="large-8 columns">
        </div>
        <div class="large-4 columns text-right">
        </div>
    </div>
    <div class="row show-for-small-only ">
        <div class="large-3 columns">
            <a href="../default.aspx">
                <img src="../images/logo2.PNG" style="width: 240px" /></a>
        </div>
        <div class="large-9 columns ">
            <div class="rmm" data-menu-style="minimal">
                <ul>
                    <li><a href="../default.aspx" class="button">Go To</a></li>
                    <li><a href="../ITRScreenshots.aspx" class="button">Demo e-filing</a></li>
                    <li><a href="../PriceGuide.aspx" class="button">Price Guide</a></li>
                    <%-- <li><a href="#" class="button">Rates and Tables</a></li>--%>
                    <li>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout1_Click"></asp:LinkButton></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="row hide-for-small">
        <div class="large-3 columns">
            <a href="../Default.aspx">
                <img src="../images/logo2.PNG" /></a>
        </div>
        <div class="large-9 columns ">
            <ul class="right button-group">
                <li><a class="button">Go-To</a>
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
                <li><a href="../about.aspx" class="button">Price Guide</a></li>
                <%-- <li><a href="#" class="button">Rates and Tables</a></li>--%>
                <li>
                    <asp:LinkButton ID="LinkButton2" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout11_Click"></asp:LinkButton></li>
            </ul>
        </div>
        <div style="float: right;">
            <asp:Literal ID="ltWelcome" runat="server"></asp:Literal>
        </div>
    </div>
    <br />
    
    <div class="row">
        <div class="large-12 columns">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true"
                NodeStyle-Font-Bold="false" ForeColor="#333333">
            </asp:SiteMapPath>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="login-wrap" style="height: 140px; background-color: White; width: auto;
            max-width: 500px;">
            <%------------------------Upload file interface ----------------------%>
            <div class="large-12 columns">
                <div class="row">
                    <div class="large-6 columns text-center">
                        Upload Your File Here
                    </div>
                    <div class="large-6 columns text-center">
                        <asp:FileUpload ID="FilePdfUpload" runat="server" />
                    </div>
                </div>
                <div class="large-4 columns">
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>
                <div class="row">
                    <div class="large-12 columns text-center">
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" class="radius button" OnClick="btnUpload_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
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
                    <hr style="margin-top: -4px;" />
                    <div class="row" style="background-color: gray;margin-top: -10px;">
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
                    <br />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
