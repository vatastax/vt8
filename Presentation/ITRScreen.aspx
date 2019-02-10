<%@ Page Language="C#" AutoEventWireup="true" CodeFile="itr1.aspx.cs" Inherits="itr1" %>

<!DOCTYPE html >

<html class="no-js" lang="en">
 
<head id="Head1" runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <title></title>
    <!--LIGHTBOX-->
    <script src="../js_lightbox/modernizr.custom.js"></script>

	<link rel="shortcut icon" href="../img_lightbox/demopage/favicon.ico"/>
	<link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Karla:400,700"/>
	<%--<link rel="stylesheet" href="../css_lightbox/screen.css" media="screen"/>
	<link rel="stylesheet" href="../css_lightbox/lightbox.css" media="screen"/>--%>
    <!--LIGHTBOX-->





    <%--<link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
   <%-- <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>--%>
    <script src="../js/ajax-googleapis-com-aja-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
      <script src="../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>

    <%--<link href="foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />--%>

   <%-- <script src="foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
     <script src="sliderengine/jquery.js" type="text/javascript"></script>--%>

    <%--<link href="StaticStylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="StaticStylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />--%>
    
     

    <%--<link href="sliderengine/amazingslider-1.css" rel="stylesheet" type="text/css" />--%>

     <script src="../js/modernizr.custom.34978.js" type="text/javascript"></script>
      <script src="../js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>

   <!--master javascript file-->
    <script src="../js/MasterJScript.js" type="text/javascript"></script>
   <!--master javascript file-->

   
    <!--master style sheet-->
    <link href="../style_folder/StaticStyleSheet.css" rel="stylesheet" type="text/css" />
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
         
            <a href="../default.aspx"><img src="../images/logo2.png" style="width:240px" /></a>
      
      
        </div>
        <div class="large-9 columns ">
        <div class="rmm" data-menu-style = "minimal">
          <ul  >
          <li><a href="../default.aspx" class="button">Go To</a></li>
          <li><a href="../itrscreenshots.aspx" class="button">Demo to e-filing</a></li>
          <li><a href="../PriceGuide.aspx" class="button">Price Guide</a></li>
            <%--<li><a href="#" class="button">Rates and Tables</a></li>--%>
               <li><a href="#" class="button">Login</a></li>
          </ul>
          </div>
         </div>
    
       </div>
        <%------------------show logo and menu on medium and large screen ----------%>  
     <div class="row hide-for-small-only" >
         <div class="large-4 columns" >
         
            
             <a href="../Default.aspx"><img src="../images/logo2.png" style="width:240px" /></a>
      
        </div>
        <div class="large-8 columns ">
          <ul class="right button-group">
          <li><a  class="button">Go-To</a>
          <ul style="background-color:gray; opacity:0.7; border:1px solid gray; border-radius:10px;">
                  <li style="padding-top:4px;"><a href="../pageRedirect.aspx?prj=tds" style="color:white;" ><img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Tax Deducted at Source</a>  <a href="../vat.aspx" style="color:white;"><img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Value Added Tax</a></li>
                <li style="padding-top:2px;"><a href="../pageRedirect.aspx?prj=stax" style="color:white;"><img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Service Tax</a >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="../cet.aspx" style="color:white;"><img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Central Excise Tax</a></li>
                 <li style="padding-top:2px;padding-bottom:2px;"><a href="../nri.aspx" style="color:white;"><img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;NRI Taxation</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../tp.aspx" style="color:white;"><img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Transfer Pricing</a></li>
            </ul>
          </li>
          <li><a id="a3" class=" button example-image-link" href="../img_lightbox/demopage/screen0.jpg" data-lightbox="example-set">Demo to e-filing</a></li>
          <div class="wrapper" style="display:none">
	            <div id="examples" class="section examples-section">		
		            <div class="image-row">
			            <div class="image-set">
			             <%--<a id="aid" class="example-image-link" href="../img_lightbox/demopage/screen0.jpg" data-lightbox="example-set">click here</a>--%>
			             <div style="display:none;">
				            <a class="example-image-link" href="../img_lightbox/demopage/screen0.jpg" data-lightbox="example-set" title="Click on the right side of the image to move forward."><img class="example-image" src="../img_lightbox/demopage/screen0.jpg" alt="Plants: image 1 0f 4 thumb" width="150" height="150"/></a>
				            <a class="example-image-link" href="../img_lightbox/demopage/screen0i.jpg" data-lightbox="example-set" title="Or press the right arrow on your keyboard."><img class="example-image" src="../img_lightbox/demopage/screen0i.jpg" alt="Plants: image 2 0f 4 thumb" width="150" height="150"/></a>
				            <a class="example-image-link" href="../img_lightbox/demopage/screen0.jpg" data-lightbox="example-set" title="The script preloads the next image in the set as you're viewing."><img class="example-image" src="../img_lightbox/demopage/screen0.jpg" alt="Plants: image 3 0f 4 thumb" width="150" height="150"/></a>
				            <a class="example-image-link" href="../img_lightbox/demopage/screen1.jpg" data-lightbox="example-set" title="Click anywhere outside the image or the X to the right to close."><img class="example-image" src="../img_lightbox/demopage/screen1.jpg" alt="Plants: image 4 0f 4 thumb" width="150" height="150"/></a>
			            </div>
			            </div>
		            </div>
	            </div>

	

	

	<script src="../js_lightbox/jquery-1.10.2.min.js"></script>
	<script src="../js_lightbox/lightbox-2.6.min.js"></script>

	<script>
	    var _gaq = _gaq || [];
	    _gaq.push(['_setAccount', 'UA-2196019-1']);
	    _gaq.push(['_trackPageview']);

	    (function () {
	        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
	        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
	        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
	    })();
	</script>

</div>
          <li><a href="../PriceGuide.aspx" class="button">Price Guide</a></li>
            <%--<li><a href="#" class="button">Rates and Tables</a></li>--%>
               <li><a href="#" class="button">Login</a></li>      
          </ul>
         </div>
    
       </div>
      


    
    <%------------------------------Breadcrump --------------------------------------%>
     <%-- <br />
     <div class="row">
        <div class="large-12 columns">
            <span>Income Tax Returns</span>
        </div>
    </div>
--%>

     <%----------------tagline --------------------%>
      <div class="row hide-for-small-only heading">
      <div class="large-12 columns text-center">
      <p class="lplh-58" style="text-align: center;"></br>
<span style="color:#052A3C;"><span style="font-size: 30px;"><span style="font-family:  Calibri"> Welcome to the <b>Income Tax Return</b> Filing</span></span></span>
</p>


      </div>
      </div>
    <br />
      <div class="row text-center" id="buttons">
        <div class="large-4 columns links" id="links">

        
<ul style="  list-style:none ">
      <li>  <a href="E-FileYourself.aspx" class="button4 red3" style=" height:55px; width:260px;"  id="trigger">E-file yourself</a>
      </li>
        <li>   <a href="E-FileCA.aspx" class="button4 red3" style=" height:55px; width:260px;" id="A1">E-file with CA </a></li>
       <li>   <a href="../Presentation/Default.aspx?incometax" class="button4 red3" style=" height:85px; width:260px;" id="A2">Multiple filing for tax professionals </a></li>
</ul>
     <%-- <a href="#" class="button3">E-file yourself</a>--%>

         
        </div>
          <div class="large-8 columns links">
<%-- <a href="#" class="button2 red" style="height:70px; width:200px;" id="trigger2">Multiple filing for tax professionals </a>--%>
      <%--<a href="#" class="button3">Multiple filing for tax professionals</a>--%>

           <!-- First Band (Slider) -->
   <div id="carousel-example-generic" class="carousel slide hide-for-small-only" data-ride="carousel">
  <!-- Indicators -->
  <ul class="carousel-indicators pagination" style=" list-style-type:circle" >
    <li  class="active" ><a href="#0"></a></li>
    <li  ><a href="#1"></a></li>
    <li  ><a href="#2"></a></li>
     <li ><a href="#3"></a></li>
  </ul>
 
  <!-- Wrapper for slides -->
  <div class="carousel-inner">
    <div class="item active" >
<div class="item" style="border:0px">
         <div class="row" style="border:0px" >
     <div class="well text-center">
     <%-- <p class="subheading" style=" color:#1569ac; margin-left:-150px; font-size:40px; font-family:Arial Sans-Serif; line-height:45px ">Quick And Easy </p> 
    
      <p style="font-size:24px; padding-bottom:20px; margin-left:-150px;color:#a8a7a7;font-family:Arial Sans-Serif"" >Simply UPLOAD FORM 16,<br /> preventing entry errors</p>
  
     <div style="float:right; margin-top:-180px; margin-left:-20px">
         <img src="../images/easy2.jpg" style="height:200px" />
     </div>--%>
    
      
 
   <img src="../images/easy.jpg" />
    
     </div>
     </div>
     </div>
      <div class="carousel-caption">
         
      </div>
      
    </div>
    <div class="item">
       
   <div class="row" style="border:0px">
     <div class="well text-center" style="border:0px">
    <%--  <p class="subheading" style=" color:#1569ac; margin-left:-150px; font-size:40px; font-family:Arial Sans-Serif; line-height:45px ">Approved ERI
</p>
     <p style="font-size:24px; padding-bottom:20px; margin-left:-150px; color:#a8a7a7;font-family:Arial Sans-Serif" >We are Government of India authorized, <BR />Income tax e-return intermediary<b>(ERI)</b></p>
      <div style="float:right; margin-top:-180px; margin-left:-20px">
          <img src="../images/approved.jpg" style="height:200px" />

      </div>   --%>
       <img src="../images/eri.jpg" />
     </div>
     </div>
 

    
    </div>
     <div class="carousel-caption">
        
      </div>
    <div class="item">
       
    <div class="row" style="border:0px">
     <div class="well text-center" style="border:0px">
      <%--   <p class="subheading" style=" color:#1569ac; margin-left:-150px; font-size:40px; font-family:Arial Sans-Serif; line-height:45px "> 
     Maximum Refund</p>
   <p style="font-size:24px; padding-bottom:20px; margin-left:-150px;color:#a8a7a7;font-family:Arial Sans-Serif" >Our experts help you,<br /> get MAXIMUM REFUND</p>
    <div style="float:right; margin-top:-180px; margin-left:-20px">
    <img src="../images/maxmumRefund.jpg" style="height:200px"  />
      </div> --%>
      <img src="../images/refund.jpg" />
     </div>
     </div>
   

     
    </div>
     <div class="carousel-caption">
        
      </div>
      <div class="item" style="margin-left:50px">
          
    <div class="row" style="border:0px">
     <div class="well text-center" style="border:0px">
    
       <%--  <p class="subheading" style=" color:#1569ac; margin-left:-200px; font-size:40px; font-family:Arial Sans-Serif; line-height:45px ">  
    
  Assessment Notice</p>
     <p style="font-size:24px; padding-bottom:20px; margin-left:-200px;color:#a8a7a7;font-family:Arial Sans-Serif" >ASSESSMENT NOTICE arrived,<br /> We'll handle it for you.</p>
       <div style="float:right; margin-top:-180px; ">
           <img src="../images/NOTIFICATION.jpg" style="height:200px" />
      </div>   --%>
        <img src="../images/assessment.jpg" />
     </div>
     </div>
 

   
    </div>
     
  
  
     
  </div>
 
  <!-- Controls -->
  <%--<a class="left carousel-control" href="#carousel-example-generic" role="button"  data-slide="prev" style="margin-left:-15px">
    <span class="glyphicon glyphicon-chevron-left"></span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next" style="margin-right:-20px">
    <span class="glyphicon glyphicon-chevron-right"></span>
  </a>--%>
</div> <!-- Carousel -->
        </div>
        <%--<div class="large-4 columns links ">
       <%-- <ul class="enlarge"><li> <a href="#" class="button3 red">E-file with CA </a><span style="height:250px"><ul><li>At Your service</li><li>Our experts review your return</li><li>Experts ensure your returns are correct</li></ul></span></li></ul>--%>
           <%-- <a href="#" class="button3 red" > E-file with CA  </a>--%>
<%--<a href="#" class="button2 red" style="padding-top:28px; height:70px; width:200px;" id="trigger1">E-file with CA </a>--%>
        </div>
       
      </div>
      <!-- Second Band (Image Left with Text) -->
     <br />
     <br />


     



<div style="background-color:gray; margin-top:10px">
</br>
     <div class="row" style="background-color:gray">
    
      <div class="large-3 columns" >
          <a href="../TaxServices.aspx?service=26AS" target="_blank" class="button5 blue7" style=" height:50px; width:220px;  background-color:gray;"><img src="../images/form2.png" /></a>
          </div>
           <div class="large-3 columns" >
         <a href="../TaxServices.aspx?service=ITRV" target="_blank" class="button5 blue7"  style=" height:50px; width:220px;  background-color:gray; "><img src="../images/track2.png" /></a>
         </div>
          <div class="large-3 columns" >
         <a href="../TaxCalculator.aspx" class="button5 blue7"  style=" height:50px; width:220px;  background-color:gray;"><img src="../images/taxcal2.png" /></a>
         </div>
          <div class="large-3 columns" >
         <a href="../TaxServices.aspx?service=RefundStatus" target="_blank" class="button5 blue7"  style=" height:50px; width:220px; background-color:gray;  color:black;"><img src="../images/refund2.png" /></a>
         </div>
         
       
        </div>
        
         </div>

     <%-- <div class="large-12 columns" style=" background-image:url(images/pattern2.JPG); background-repeat: repeat-x; ">
         &nbsp;
        </div>--%>
     
      <div  style="background-color:gray" >
    
     <div  style="background-color:gray" >
      <div class="row" >
        <div class="large-12 columns ">
      </br>
          <div class="row">
            <div class="large-4 columns footer-links">
            <a  style=" font-family:Cambria;  font-size:1.4375em; color:white;">    About</a>
        
             <ul style=" list-style-type:  disc; font-family:Calibri; padding-left:15px; color:#e1e3e5;">
             <li> <a href="../AboutUs.aspx" style=" font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">E-Charated Accontants</a></li>
             <li><a href="../ContactUsNew.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857; color:#e1e3e5;"> Contact details</a></li>
             <li> <a href="../News.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">News</a></li>
             <li><a href="../Terms_Conditions.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Terms of use</a></li>
            <li><a href="../PrivacyPolicy.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Privacy Policy</a></li>
            <li><a href="../ItrSiteMap.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Site Map</a></li>
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
               <li><a href="../itrscreenshots.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">Guide to ITR e-filing</a></li>
        
                <li><a href="../TaxServices.aspx?service=26AS" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">View your Form 26 AS</a></li>
                <li><a href="../TaxServices.aspx?service=RefundStatus" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">Check Income Tax Refund Status</a></li>
                <li><a href="../Presentation/Default.aspx?incometax" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">File Multiple Tax Returns</a></li>
                <%--<li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">Changed jobs/ Have multiple Form 16</a></li>
                <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">How to pay tax i.e. due</a></li>--%>
                 <li><a href="../TaxServices.aspx?service=ITRV" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5">Tracking of ITR-V status</a></li>

              </ul>
            </div>
              <div class="large-3 columns footer-links">
            <a  style="font-family:Cambria;  font-size:1.4375em; color:white">Services</a>    

       
              <ul style=" list-style-type: disc; color:#e1e3e5; font-family:Calibri;padding-left:15px" >
                 <li><a href="../pageRedirect.aspx?prj=vt" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Income Tax Return</a></li>
                 <li><a href="../pageRedirect.aspx?prj=tds" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Tax Deducted At Source</a></li>
                 <li><a href="../vat.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Value Added Tax</a></li>
                 <li><a href="../pageRedirect.aspx?prj=stax" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Service Tax</a></li>
                 <li><a href="../cet.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Centeral Excise Tax</a></li>
                 <li><a href="../nri.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">NRI Taxation</a></li>
                 <li><a href="../tp.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Transfer Pricing</a></li>
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
               <a href="https://www.facebook.com/echarteredaccountants" target="_blank"><img src="../images/fb.png" /></a>
                <a href="http://www.twitter.com/ECAccountant" target="_blank"><img src="../images/twitter.png" /></a>
                <a href="https://in.linkedin.com/pub/vatas-infotech/b9/264/a82" target="_blank"><img src="../images/LINKEDIN1.PNG" /></a>
                <a href="https://plus.google.com/u/0/b/108616341946641442746/108616341946641442746" target="_blank" ><img src="../images/google.png" /></a>
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
