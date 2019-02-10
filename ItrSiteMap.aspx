<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItrSiteMap.aspx.cs" Inherits="ItrSiteMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html class="no-js" lang="en">
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
<head id="Head1" runat="server">
    <title></title>
    <%--<link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>--%>
    <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
      <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>

    <%--<link href="foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />--%>
    <script src="foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
     <script src="sliderengine/jquery.js" type="text/javascript"></script>
    <%--<link href="StaticStylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="StaticStylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />--%>
     <script src="sliderengine/jquery.js" type="text/javascript"></script>
      <script src="sliderengine/amazingslider.js" type="text/javascript"></script>
    <%--<link href="sliderengine/amazingslider-1.css" rel="stylesheet" type="text/css" />--%>
     <script src="js/modernizr.custom.34978.js" type="text/javascript"></script>
      <script src="js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>

    <script src="sliderengine/initslider-1.js" type="text/javascript"></script>
   
    <!--master style sheet-->
    <link href="style_folder/StaticStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->

    

</head>
<body>
    <form id="form1" runat="server">
    <div class="row" style="margin-top:10px">
    <div class="large-8 columns">
    </div>
    <div class="large-4 columns text-right">
        
    </div>
  
    </div>
    <br />

    <%------------------show logo and menu on mobile screen -----------------------%>
     <div class="row show-for-small-only ">
         <div class="large-3 columns" >
         
            <a href="Default.aspx"><img src="images/logo2.PNG" style="width:240px" /></a>
      
      
        </div>
        <div class="large-9 columns ">
        <div class="rmm" data-menu-style = "minimal">
          <ul  >
          <li><a href="default.aspx" class="button">Go To</a></li>
          <li><a href="itrscreenshots.aspx" class="button">Demo e-filing</a></li>
          <li><a href="PriceGuide.aspx" class="button">Price Guide</a></li>
           <%-- <li><a href="#" class="button">Rates and Tables</a></li>--%>
               <%--<li><a href="#" class="button">Login</a></li>--%>
               <li><asp:LinkButton ID="LinkButton1" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout1_Click"></asp:LinkButton></li>
          </ul>
          </div>
         </div>
    
       </div>
        <%------------------show logo and menu on medium and large screen ----------%>  
     <div class="row hide-for-small-only" >
         <div class="large-4 columns" >
         
            
             <a href="Default.aspx"><img src="images/logo2.PNG" style="width:240px" /></a>
      
        </div>
        <div class="large-8 columns ">
          <ul class="right button-group">
          <li><a href="default.aspx" class="button">Go-To</a>
          <ul style="background-color:gray; opacity:0.7; border:1px solid gray; border:1px solid gray; border-radius:10px; padding:0 10px">
                  <li style="padding-top:4px;"><a href="../pageRedirect.aspx?prj=tds" style="color:white;" ><img src="images/bullet.png" />&nbsp;&nbsp;&nbsp;Tax Deducted at Source</a>  <a href="Presentation/Gst.aspx" style="color:white;"><img src="images/bullet.png" />&nbsp;&nbsp;&nbsp;Goods & Service Tax</a></li>
                <li style="padding-top:2px;"><a href="../pageRedirect.aspx?prj=stax" style="color:white;"><img src="images/bullet.png" />&nbsp;&nbsp;&nbsp;Service Tax</a >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="cet.aspx" style="color:white;"><img src="images/bullet.png" />&nbsp;&nbsp;&nbsp;Central Excise Tax</a></li>
                 <li style="padding-top:2px;padding-bottom:2px;"><a href="nri.aspx" style="color:white;"><img src="images/bullet.png" />&nbsp;&nbsp;&nbsp;NRI Taxation</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="tp.aspx" style="color:white;"><img src="images/bullet.png" />&nbsp;&nbsp;&nbsp;Transfer Pricing</a></li>
            </ul>
          </li>
          <li><a href="itrscreenshots.aspx" class="button">Demo e-filing</a></li>
          <li><a href="PriceGuide.aspx" class="button">Price Guide</a></li>
           <%-- <li><a href="#" class="button">Rates and Tables</a></li>--%>
               <%--<li><a href="#" class="button">Login</a></li>    --%>  
               <li><asp:LinkButton ID="LinkButton2" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout11_Click"></asp:LinkButton></li> 
          </ul>
         </div>
         <div style="float:right;"><asp:Literal ID="ltWelcome" runat="server"></asp:Literal> </div>
       </div>
      


    
    <%------------------------------Breadcrump --------------------------------------%>
      <br />
     <div class="row">
        <div class="large-12 columns">
           
            <span style="font-family:Cambria;"> <a href="itr1.aspx">Income Tax Returns</a></span><span> ></span> <span style="font-family:Cambria; font-weight:bold;">SiteMap </span>
        </div>
    </div>


     <%----------------tagline --------------------%>
      <div class="row hide-for-small-only heading">
      <div class="large-12 columns text-center">
      <p class="lplh-58" style="text-align: center;"></br>
<span style="color:#052A3C;"><span style="font-size: 30px;"><span style="font-family:  Calibri"> <b>Income Tax Return - SiteMap</b></span>
</p>


      </div>
      </div>
    <br />
     
      <div class="row">
      
      
      
     <div class="large-4 columns"  style="float:left;margin-bottom:20px;">
        <div class="row site1">
            <div class="large-6 columns ">
        
                    <span style="color:Gray; font-weight:bold;">Go-To</span>
        
            </div>
            <br />
            
             <div class="large-6 columns" style="margin-left:50px">
                <a href="pageRedirect.aspx?prj=vt" style="color:gray">Income Tax Returns</a>
            </div>
            <br/>
                <div class="large-6 columns" style="margin-left:100px">
                     <a href="Presentation/E-FileYourself.aspx">E-file Yourself</a>
                </div>
                <br />
                <div class="large-6 columns" style="margin-left:100px">
                     <a href="Presentation/E-FileCA.aspx">E-file with CA</a>
                </div>
                <br />
                <div class="large-6 columns" style="margin-left:100px">
                     <a href="login.aspx">Multiple filing for Tax Professionals</a>
                </div>
                 <br/>
             <div class="large-6 columns" style="margin-left:50px">
                <a href="pageRedirect.aspx?prj=tds">Tax Deducted at Source</a>
            </div>
            <br/>
             <div class="large-6 columns" style="margin-left:50px">
                <a href="Presentation/Gst.aspx">Goods & Service Tax</a>
            </div>
            <br/>
             <div class="large-6 columns" style="margin-left:50px">
               <a href="pageRedirect.aspx?prj=stax">Service Tax</a>
            </div>
            <br/>
             <div class="large-6 columns" style="margin-left:50px">
                <a href="cet.aspx">Central Excise Tax</a>
            </div>
            <br/>
             <div class="large-6 columns" style="margin-left:50px">
               <a href="nri.aspx">NRI Taxation</a>
            </div>
            <br/>
             <div class="large-6 columns" style="margin-left:50px">
                <a href="tp.aspx">Transfer Pricing</a>
            </div>
            <br/>

            
           
        </div>
    </div> 
    <div class="large-5 columns" style="float:left">
      <div class="row site1">
      <div class="large-6 columns " style="float:left">
                  <a href="ITRscreenshots.aspx" style="color:Gray; font-weight:bold;">Demo e-filing</a>
            </div>
            <br />
                <%--<div class="large-6 columns " style="float:left; clear:both;">
                      <a href="PriceGuide.aspx" style="color:Gray; font-weight:bold;">Price Guide</a>
                </div>
                <br />--%>
           <%-- <div class="large-6 columns "style="float:left; clear:both;">
                  <a href="#" style="color:Gray; font-weight:bold;">Rates & Tables</a>
            </div>
            <br />--%>
      
            <%--<div class="large-6 columns" style="margin-left:50px">
                <a href="#" style="color:gray">Guide for Understanding Form 16</a>
            </div>
            <br/>
            <div class="large-6 columns" style="margin-left:50px">
                <a href="ITRscreenshots.aspx" style="color:gray">Guide to ITR e-filing</a>
            </div>
            <br/>--%>
            
            <%--<div class="large-6 columns" style="margin-left:50px">
                <a href="#" style="color:gray">All Plans with Pricing</a>
            </div>
            <br/>--%>
            <div class="large-6 columns ">
                  <span  style=" font-weight:bold; color:gray">How-tos</span>
            </div>
            <br />
             <div class="large-6 columns" style="margin-left:50px">
                <a href="ITRscreenshots.aspx" style="color:gray">Guide to ITR e-filing</a>
            </div>
            <br />
            <div class="large-6 columns" style="margin-left:50px">
                <a href="TaxServices.aspx?service=26AS" style="color:gray">View your Form 26 AS</a>
            </div>
            <br/>
           <div class="large-6 columns" style="margin-left:50px">
                <a href="TaxServices.aspx?service=RefundStatus" style="color:gray">Check Income Tax Refund Status</a>
            </div>
            <div class="large-6 columns" style="margin-left:50px">
                <a href="Presentation/Default.aspx?incometax" style="color:gray">File Multiple Tax Returns</a>
            </div>
           <%-- <div class="large-6 columns" style="margin-left:50px">
                <a href="#" style="color:gray">Changed job/ Have Multiple Form 16</a>
            </div>
            <br/>--%>
            <div class="large-6 columns" style="margin-left:50px">
                <a href="TaxServices.aspx?service=ITRV" style="color:gray">Tracking of ITR-V Status</a>
            </div>
        
        <br /><br />
     </div>

    </div>
    <div class="large-3 columns" style="float:left">
      <div class="row site1">
        <div class="large-12 columns" >
             <a href="ContactUsNew.aspx" style="color:gray; font-weight:bold;">Contact Us</a>
        </div>
        <br />
        <div class="large-12 columns" >
             <a href="Terms_Conditions.aspx" style="color:gray; font-weight:bold;">Terms & Conditions</a>
        </div>
        <br />
        <div class="large-12 columns" >
             <a href="PrivacyPolicy.aspx" style="color:gray; font-weight:bold;">Privacy & Policy</a>
        </div>
        <br />
        <div class="large-12 columns" >
             <a href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf" target="_blank" style="color:gray; font-weight:bold;">FAQs</a>
        </div>
      </div>
   </div>
      </div>
       
      
      <!-- Second Band (Image Left with Text) -->
     <br />
     <br />


     


<div style="background-color:gray; margin-top:10px">
</br>
     <div class="row" style="background-color:gray">
    
      <div class="large-3 columns" >
          <a href="TaxServices.aspx?service=26AS" target="_blank" class="button5 blue7" style=" height:50px; width:220px;  background-color:gray;"><img src="images/form2.png" /></a>
          </div>
           <div class="large-3 columns" >
         <a href="TaxServices.aspx?service=ITRV" target="_blank" class="button5 blue7"  style=" height:50px; width:220px;  background-color:gray; "><img src="images/track2.png" /></a>
         </div>
          <div class="large-3 columns" >
         <a href="TaxCalculator.aspx" class="button5 blue7"  style=" height:50px; width:220px;  background-color:gray;"><img src="images/taxcal2.png" /></a>
         </div>
          <div class="large-3 columns" >
         <a href="TaxServices.aspx?service=RefundStatus" target="_blank" class="button5 blue7"  style=" height:50px; width:220px; background-color:gray;  color:black;"><img src="images/refund2.png" /></a>
         </div>
         
       
        </div>
        
         </div>

     
       <div  style="background-color:gray" >
    
     <div  style="background-color:gray" >
      <div class="row" >
        <div class="large-12 columns ">
      </br>
          <div class="row">
            <div class="large-4 columns footer-links">
            <a  style=" font-family:Cambria;  font-size:1.4375em; color:white;">    About</a>
        
             <ul style=" list-style-type:  disc; font-family:Calibri; padding-left:15px; color:#e1e3e5;">
             <li> <a href="AboutUs.aspx" style=" font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">E-Chartered Accountants.com</a></li>
             <li><a href="ContactUsNew.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857; color:#e1e3e5;"> Contact details</a></li>
             <li> <a href="News.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">News</a></li>
             <li><a href="Terms_Conditions.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Terms of use</a></li>
            <li><a href="PrivacyPolicy.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Privacy Policy</a></li>
            <li><a href="ItrSiteMap.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Site Map</a></li>
             <li><a href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">FAQ's</a></li>
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
            <a  style="font-family:Cambria;  font-size:1.4375em; color:white">How-tos</a>     

      
              <ul style=" list-style-type: disc; color:#e1e3e5; font-family:Calibri; padding-left:15px" >
               <li><a href="itrscreenshots.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">Guide to ITR e-filing</a></li>
        
                <li><a href="TaxServices.aspx?service=26AS" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">View your Form 26 AS</a></li>
                <li><a href="TaxServices.aspx?service=RefundStatus" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">Check Income Tax Refund Status</a></li>
                <li><a href="Presentation/Default.aspx?incometax" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">File Multiple Tax Returns</a></li>
                <%--<li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">Changed jobs/ Have multiple Form 16</a></li>
                <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">How to pay tax i.e. due</a></li>--%>
                 <li><a href="TaxServices.aspx?service=ITRV" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">Tracking of ITR-V status</a></li>

              </ul>
            </div>
              <div class="large-3 columns footer-links">
            <a  style="font-family:Cambria;  font-size:1.4375em; color:white">Services</a>    

       
              <ul style=" list-style-type: disc; color:#e1e3e5; font-family:Calibri;padding-left:15px" >
                 <li><a href="pageRedirect.aspx?prj=vt" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Income Tax Return</a></li>
                 <li><a href="pageRedirect.aspx?prj=tds" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Tax Deducted At Source</a></li>
                 <li><a href="Presentation/Gst.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Goods & Service Tax</a></li>
                 <li><a href="pageRedirect.aspx?prj=stax" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Service Tax</a></li>
                 <li><a href="cet.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Centeral Excise Tax</a></li>
                 <li><a href="nri.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">NRI Taxation</a></li>
                 <li><a href="tp.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Transfer Pricing</a></li>
              </ul>
            </div> 
          </div>
          
        
        
          </div>
</div>
       <div class="row" style="background-color:gray" >
        <div class="large-12 columns">
     
          <hr />
          <div class="row" style="background-color:gray" >
            <div class="large-3 columns">
              <p style="color:#e1e3e5;">© 2015 Vatas Infotech Pvt.Ltd.</p>
            </div>
            <div class="large-9 columns text-right">
               <a href="https://www.facebook.com/echarteredaccountants" target="_blank"><img src="images/fb.png" /></a>
                <a href="http://www.twitter.com/ECAccountant" target="_blank"><img src="images/twitter.png" /></a>
                <a href="https://in.linkedin.com/pub/vatas-infotech/b9/264/a82" target="_blank"><img src="images/LINKEDIN1.PNG" /></a>
                <a href="https://plus.google.com/u/0/b/108616341946641442746/108616341946641442746" target="_blank" ><img src="images/google.png" /></a>
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
     
    </form>
</body>
</html>
