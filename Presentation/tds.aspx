<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tds.aspx.cs" Inherits="tds" %>

<!DOCTYPE html >
<html class="no-js" lang="en">
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<meta charset="utf-8" />
<head id="Head1" runat="server">
    <title>The Interactive Platform for free e-filing TDS Returns in India</title>
    <%--<link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>--%>
    <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <script src="../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <%--<link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />--%>
    <script src="../foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="../foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
    <script src="../sliderengine/jquery.js" type="text/javascript"></script>
    <%-- <link href="StaticStylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="StaticStylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />--%>
    <script src="../sliderengine/jquery.js" type="text/javascript"></script>
    <script src="../sliderengine/amazingslider.js" type="text/javascript"></script>
    <%--<link href="../sliderengine/amazingslider-1.css" rel="stylesheet" type="text/css" />--%>
    <script src="../js/modernizr.custom.34978.js" type="text/javascript"></script>
    <script src="../js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>
    <script src="../sliderengine/initslider-1.js" type="text/javascript"></script>
    <!--master style sheet-->
    <link href="../style_folder/StaticStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
    <script type="text/javascript">
        $(document).ready(function () {

            $("#div1").click(function () {
                $("#Regular").slideToggle();
                $("#Correction").hide();

            });
            $(".button3").click(function () {
                $(this).css(
                "color", "white" //nishu 8/3/2015 set color white on click of button
                  );
                $(".button3 a").css("color", "white");
            });
            $("#div2").click(function () {
                $("#Correction").slideToggle();
                $("#Regular").hide();
            });

        });

        
    </script>
    <link rel="icon" type="image/png" href="../images/fevicon.png" />
    <link rel="shortcut icon" type="image/png" href="../images/fevicon.png" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="row" style="margin-top: 10px">
        <div class="large-8 columns">
        </div>
        <div class="large-4 columns text-right">
        </div>
    </div>
    <br />
    <%------------------show logo and menu on mobile screen -----------------------%>
    <div class="row show-for-small-only " style="margin-top: -20px;">
        <div class="large-3 columns">
            <a href="../default.aspx">
                <img src="../images/logo2.png" style="width: 240px" /></a>
        </div>
        <div class="large-9 columns ">
            <div class="rmm" data-menu-style="minimal">
                <ul>
                    <li><a href="default.aspx" class="button">Go To</a></li>
                    <li><a href="../guidehub.aspx" class="button">Demo to e-filing</a></li>
                    <li><a href="#" class="button">Price Guide</a></li>
                    <%-- <li><a href="#" class="button">Rates and Tables</a></li>--%>
                    <li>
                        <asp:LinkButton ID="lbtnLogout" runat="server" Text="Logout" CssClass="button" PostBackUrl="logout.aspx"></asp:LinkButton></li>
                </ul>
            </div>
        </div>
    </div>
    <%------------------show logo and menu on medium and large screen ----------%>
    <div class="row hide-for-small-only" style="margin-top: -30px;">
        <div class="large-4 columns">
            <a href="../Default.aspx">
                <img src="../images/logo2.png" style="width: 240px" /></a>
        </div>
        <div class="large-8 columns ">
            <ul class="right button-group">
                <li><a class="button">Go-To</a>
                    <ul style="background-color: gray; opacity: 0.7; border: 1px solid gray; border-radius: 10px;">
                        <li style="padding-top: 4px;"><a href="../pageRedirect.aspx?prj=vt" style="color: white;">
                            <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Income Tax Return</a> &nbsp;&nbsp;
                            <a href="../vat.aspx" style="color: white;">
                                <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Value Added Tax</a></li>
                        <li style="padding-top: 2px;"><a href="../pageRedirect.aspx?prj=stax" style="color: white;">
                            <img src="../images/bullet.png" />&nbsp;&nbsp;&nbsp;Service Tax</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                <%-- <li><a href="#" class="button">Rates and Tables</a></li>--%>
                <li>
                    <%--<a href="#" class="button">Login</a>--%>
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout1_Click"></asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div class="large-8 columns  ">
        </div>
        <div class="large-4 columns  text-right">
            <asp:Literal ID="ltWelcome" runat="server"></asp:Literal>
        </div>
    </div>
    <%------------------------------Breadcrump --------------------------------------%>
    <div class="row hide-for-small-only heading">
        <div class="large-12 columns text-center">
            <p class="lplh-58" style="text-align: center;">
                <span style="color: #052A3C;"><span style="font-size: 30px;"><span style="font-family: Calibri;
                    line-height: 1.1">Welcome to the <b>Tax Deducted At Source</b> Return Filing</span></span></span>
            </p>
        </div>
    </div>
    <%--<div class="row text-center ">
        <div class="large-4 columns links " id="div1">
            <a href="#" class="button3 blue2" style="padding-left: 25px; text-decoration: none;
                width: 290px; height: 80px;">E-File</br>Yourself</a>
        </div>
        <div class="large-4 columns links " id="div2">
            <a href="#" class="button3 blue2 " style="text-decoration: none; width: 290px; height: 80px;">
                E-file with CA Assistance</a>
        </div>
        <div class="large-4 columns links " id="div3">
            <a href="#" class="button3 blue2 " style="text-decoration: none; width: 290px; height: 80px;">
                Multiple Filing for Tax Professionals</a>
        </div>
    </div>

    <div class="row text-center  " id="divPDF" style="display: none">
        <div class="large-3 columns links">
            <asp:LinkButton ID="lnkRegular" runat="server"  class="button3 blue2 " style="text-decoration: none; width: 220px;
                height: 90px" onclick="lnkRegular_Click" >Regular</asp:LinkButton>
            <%--<a href="Default.aspx" class="button3 blue2" style="padding-left: 25px; text-decoration: none;
                width: 220px; height: 90px">TDS (Salary) Form 24</a>
        </div>
        <div class="large-3 columns links ">
            <asp:LinkButton ID="lnkCorrectionImport" runat="server"  class="button3 blue2 " style="text-decoration: none; width: 220px;
                height: 90px" onclick="lnkCorrectionImport_Click" >Correction Import</asp:LinkButton>
            <%--<a href="Default.aspx" class="button3 blue2 " style="text-decoration: none; width: 220px;
                height: 90px">TDS (Others) Form 26</a>
        </div>
        <div class="large-3 columns links">
            <asp:LinkButton ID="lnkCorrectionForm" runat="server"  class="button3 blue2 " style="text-decoration: none; width: 220px;
                height: 90px" onclick="lnkCorrectionForm_Click" >Correction</asp:LinkButton>
            <%--<a href="Default.aspx" class="button3 blue2" style="text-decoration: none; width: 220px;
                height: 90px">TDS on NRI Form 27 </a>
        </div>
        <%--<div class="large-3 columns links">
            <a href="Default.aspx" class="button3 blue2" style="text-decoration: none; width: 220px;
                height: 90px">TCS<br />
                Form 27 EQ </a>
        </div>
    </div>--%>


    <%--Above Code Was Commented by Mudit And Replaced by Below Code Due to some changes --%>


    <div class="row text-center ">
        <div class="large-4 columns links " id="div1">
            <a href="#" class="button3 blue2" style="padding-left: 25px; text-decoration: none;
                width: 290px; height: 80px;">Regular</a>
        </div>
        <div class="large-4 columns links " id="div2">
            <a href="#" class="button3 blue2 " style="text-decoration: none; width: 290px; height: 80px;">
                Correction</a>
        </div>
        <div class="large-4 columns links " id="div3">
            <a href="#" class="button3 blue2 " style="text-decoration: none; width: 290px; height: 80px;">
                E-file with CA Assistance</a>
        </div>
    </div>

    <div class="row text-center  " id="divPDF" >
    <div id="Regular" style="display:none">
        <div class="links" style="float:left">
        
            <asp:LinkButton ID="lnkRegular" runat="server"  class="button3 blue2 " style="text-decoration: none; width: 210px;
                height: 90px" onclick="lnkRegular_Click" >Open</asp:LinkButton>
            <%--<a href="Default.aspx" class="button3 blue2" style="padding-left: 25px; text-decoration: none;
                width: 220px; height: 90px">TDS (Salary) Form 24</a>--%>
        </div>
        <div style=" display:none; float:left; background-color:White; height:90px width:50px" >&nbsp;&nbsp;</div>

        <div class="links" style="float:left">
             <asp:LinkButton ID="lnkRegularImport" runat="server"  class="button3 blue2 " style="text-decoration: none; width: 210px;
                height: 90px" onclick="lnkRegularImport_Click" >Regular Import</asp:LinkButton>
            <%--<a href="Default.aspx" class="button3 blue2" style="text-decoration: none; width: 220px;
                height: 90px">TCS<br />
                Form 27 EQ </a>--%>
        </div>
        </div>
       
        <div id="Correction"  style="display:none; margin-left:300px">
        <div class=" links" style="float:left">
            <asp:LinkButton ID="lnkCorrectionForm" runat="server"  class="button3 blue2 " style="text-decoration: none; width: 220px;
                height: 90px" onclick="lnkCorrectionForm_Click" >Open</asp:LinkButton>
            <%--<a href="Default.aspx" class="button3 blue2" style="text-decoration: none; width: 220px;
                height: 90px">TDS on NRI Form 27 </a>--%>
        </div>
            <div style=" display:none; float:left; width:50px" >&nbsp;&nbsp;</div>
        <div class="links " style="float:left">
            <asp:LinkButton ID="lnkCorrectionImport" runat="server"  class="button3 blue2 " style="text-decoration: none; width: 220px;
                height: 90px" onclick="lnkCorrectionImport_Click" >Correction Import</asp:LinkButton>
            <%--<a href="Default.aspx" class="button3 blue2 " style="text-decoration: none; width: 220px;
                height: 90px">TDS (Others) Form 26</a>--%>
        </div>
        </div>
       
    </div>




















    <%--<div class="row text-center  " id="divPDF" style="display: none">
        <div class="large-3 columns links">
            <a href="Default.aspx" class="button3 blue2" style="padding-left: 25px; text-decoration: none;
                width: 220px; height: 90px">TDS (Salary) Form 24</a>
        </div>
        <div class="large-3 columns links ">
            <a href="Default.aspx" class="button3 blue2 " style="text-decoration: none; width: 220px;
                height: 90px">TDS (Others) Form 26</a>
        </div>
        <div class="large-3 columns links">
            <a href="Default.aspx" class="button3 blue2" style="text-decoration: none; width: 220px;
                height: 90px">TDS on NRI Form 27 </a>
        </div>
        <div class="large-3 columns links">
            <a href="Default.aspx" class="button3 blue2" style="text-decoration: none; width: 220px;
                height: 90px">TCS<br />
                Form 27 EQ </a>
        </div>
    </div>--%>
    <%-- <div class="row text-center show-for-small" id="Div1">
        <div class="medium-3 columns links" id="Div2">
        <a href="#" class="button3 blue2"  >TDS for Salary Form 24</a>
    

         
        </div>
        <div class="medium-3 columns links ">
     
            <a href="#" class="button3 " >TDS (Others) Form 26</a>
        </div>
         <div class="large-3 columns links">
         <a href="#" class="button3 blue"  >TDS on NRI Form 27 </a>
     

         
        </div>
        <div class="large-3 columns links">
         <a href="#" class="button3 blue1"  >TCS Form 27 EQ </a>
         </div>
      </div>--%>
    <%-- <div class="row text-center show-for-medium-only" id="Div3">
        <div class="medium-3 columns links" id="Div4">
        <a href="#" class="button3 blue2"  >TDS for Salary Form 24</a>
    

         
        </div>
        <div class="medium-3 columns links ">
     
            <a href="#" class="button3 ">TDS (Others) Form 26</a>
        </div>
         <div class="medium-3 columns links">
         <a href="#" class="button3 blue"  >TDS on NRI Form 27 </a>
     

         
        </div>
        <div class="medium-3 columns links">
         <a href="#" class="button3 blue1"  >TCS Form 27 EQ </a>
         </div>
      </div>--%>
    <!-- Second Band (Image Left with Text) -->
    <br />
    <%--<%--<%--<%-- <div class="row">
        <div class="large-12 columns">
         
        </div>
      
      </div>
     
      <div class="row" >
        <div class="large-12 columns">
        <div id="carousel-example-generic" class="carousel slide hide-for-small-only" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
  </ol>
 
  <!-- Wrapper for slides -->
  <div class="carousel-inner">
    <div class="item active" >
     <div class="item" style="border:0px">
     <div class="row" style="border:0px" >
     <div class="well text-center">
     <p class="subheading" style=" color:#1569ac; margin-left:-150px; font-size:50px; font-family:Arial Sans-Serif; line-height:45px ">Document Treasury </p> 
    
      <p style="font-size:17px; padding-bottom:20px; margin-left:-150px;color:#a8a7a7;font-family:Arial Sans-Serif"" >We keep your tax document completely safe and secure with us</p>
  
     <div style="float:right; margin-top:-180px; margin-left:-20px">
      <img src="slider%20pics/document%20safe.jpg" style="height:200px" />
     </div>
    
      
 
   
    
     </div>
     </div>
     </div>
      <div class="carousel-caption">
         <%-- <h3>Security</h3>--%>
    <%--</div>
    </div>
    <div class="item">
       
     <div class="row" style="border:0px">
     <div class="well text-center" style="border:0px">
    <p class="subheading" style=" color:#1569ac; margin-left:-150px; font-size:50px; font-family:Arial Sans-Serif; line-height:45px ">   We do help 
our tax professional</p>
     <p style="font-size:17px; padding-bottom:20px; margin-left:-150px; color:#a8a7a7;font-family:Arial Sans-Serif" >We assist tax professional and CA's Serve their client with our help</p>
      <div style="float:right; margin-top:-180px; margin-left:-20px">
          <img src="slider%20pics/ASSIST_Icon_100x100.png" style="height:200px" />
      </div>
     </div>
     </div>--%>
    <%-- 
    </div>
     <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
    <%-- </div>
    <div class="item">
       
     <div class="row" style="border:0px">
     <div class="well text-center" style="border:0px">
        <p class="subheading" style=" color:#1569ac; margin-left:-150px; font-size:50px; font-family:Arial Sans-Serif; line-height:45px "> 
     Go green
      think green</p>
   <p style="font-size:17px; padding-bottom:20px; margin-left:-150px;color:#a8a7a7;font-family:Arial Sans-Serif" >Let's start e-tax procedure instead of paper procedure</p>
    <div style="float:right; margin-top:-180px; margin-left:-20px">
        <img src="slider%20pics/Go-Green-Logo.jpg" style="height:200px" />
      </div>
     </div>
     </div>--%>
    <%--    </div>
     <div class="carousel-caption">--%>
    <%--  <h3>Caption Text</h3>--%>
    <%-- </div>
      <div class="item">
          
     <div class="row" style="border:0px">
     <div class="well text-center" style="border:0px">
    
        <p class="subheading" style=" color:#1569ac; margin-left:-150px; font-size:50px; font-family:Arial Sans-Serif; line-height:45px ">  
    
     Let's you do it  
 on your own</p>
     <p style="font-size:17px; padding-bottom:20px; margin-left:-150px;color:#a8a7a7;font-family:Arial Sans-Serif" >Our interface are easy and informative,which ley's you do it yourself.</p>
       <div style="float:right; margin-top:-180px; margin-left:-20px">
           <img src="slider%20pics/New%20Picture.bmp" style="height:200px" />
      </div>
     </div>
     </div>--%>
    <%-- 
    </div>
     <div class="carousel-caption">
     <%--   <%--  <h3>Caption Text</h3>--%>
    <%-- </div>--%>
    <%-- <div class="item">
     
     <div class="row" style="border:0px">
     <div class="well text-center">
     <p class="subheading" style=" color:#1569ac; margin-left:-150px; font-size:50px; font-family:Arial Sans-Serif; line-height:45px "> 
     How may
  I HELP YOU</p>--%>
    <%--  <p style="font-size:17px; padding-bottom:20px; margin-left:-150px;color:#a8a7a7;font-family:Arial Sans-Serif" >Our team is readily available with CA support for any kind of tax procedure assistance.</p>
      <div style="float:right; margin-top:-180px; margin-left:-20px">
          <img src="slider%20pics/how%20may%20i%20help%20u.jpg" style="height:200px" />
      </div>
     </div>
     </div>--%>
    <%--<div class="carousel-caption">--%>
    <%--  <h3>Caption Text</h3>--%>
    <%--</div>
    </div>
    <div class="item">
     
    <%-- <div class="row" style="border:0px">
     <div class="well text-center" style="border:0px">
     <p class="subheading" style=" color:#1569ac; margin-left:-150px; font-size:50px; font-family:Arial Sans-Serif; line-height:45px "> 
     We are the
Multipurpose ECA's</p>
      <p style="font-size:17px; padding-bottom:20px; margin-left:-150px;color:#a8a7a7;font-family:Arial Sans-Serif" >We provide solutions to many tax procedures(ITR,TDS,Service Tax and VAT)under one roof</p>
     <div style="float:right; margin-top:-180px; margin-left:-20px">
         <img src="slider%20pics/all%20in%20one.jpg" style="height:200px" />
      </div>
     </div>
     </div>--%>
    <%-- </div>
     <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
    <%--  </div>
         <div class="item">
     
     <div class="row" style="border:0px">
     <div class="well text-center" style="border:0px">
      <p class="subheading" style="color:#1569ac; margin-left:-150px; font-size:50px; font-family:Arial Sans-Serif; line-height:45px"> 
     At your assitance
 Mr CA</p>
       <p style="font-size:17px; padding-bottom:20px; margin-left:-150px;color:#a8a7a7;font-family:Arial Sans-Serif" >We assist tax professionals and CA serve their clients do with our help.</p>
          <div style="float:right; margin-top:-180px; margin-left:-20px">
              <img src="slider%20pics/ASSIST_Icon_100x100.png" style="height:200px" />
          </div>
     </div>
     </div>--%>
    <%--</div>
     <div class="carousel-caption">--%>
    <%--  <h3>Caption Text</h3>--%>
    <%-- </div>
  </div>
 
  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left"></span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right"></span>
  </a>
</div> <!-- Carousel -->
      </div>
      </div>
     <br />
      <!-- Third Band (Image Right with Text) -->
    --%>
    <%-- <div class="large-12 columns" style=" background-image:url(images/pattern2.JPG); background-repeat: repeat-x; ">
         &nbsp;
        </div>--%>
    <div style="background-color: gray; margin-top: 10px">
        <br />
        <div class="row" style="background-color: gray">
            <div class="large-3 columns">
                <a href=" https://tin.tin.nsdl.com/tan/form49B.html" target="_blank" class="button5 blue7"
                    style="height: 50px; width: 220px; background-color: gray; color: black;">
                    <img src="../images/tan.PNG" /></a>
            </div>
            <div class="large-3 columns">
                <a href="https://tin.tin.nsdl.com/tan/ChangeRequest.html" target="_blank" class="button5 blue7"
                    style="height: 50px; width: 220px; background-color: gray; color: black;">
                    <img src="../images/correction_tds.png" /></a>
            </div>
            <div class="large-3 columns">
                <a href=" https://tin.tin.nsdl.com/oltas/index.html" target="_blank" class="button5 blue7"
                    style="height: 50px; width: 220px; background-color: gray; color: black;">
                    <img src="../images/challan_tds.PNG" /></a>
            </div>
            <div class="large-3 columns">
                <a href=" https://onlineservices.tin.egov-nsdl.com/etaxnew/tdsnontds.jsp" target="_blank"
                    class="button5 blue7" style="height: 50px; width: 220px; background-color: gray;
                    color: black;">
                    <img src="../images/epayment.PNG" /></a>
            </div>
        </div>
    </div>
    <!-- Footer -->
    <div style="background-color: gray">
        <div class="row">
            <div class="large-12 columns ">
                </br>
                <div class="row">
                    <div class="large-4 columns footer-links">
                        <a style="font-family: Cambria; font-size: 1.4375em; color: white">About</a>
                        <ul style="list-style-type: disc; color: #e1e3e5; font-family: Calibri; padding-left: 15px">
                            <li><a href="../AboutUs.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5;">E-Charated Accontants</a></li>
                            <li><a href="../ContactUsNew.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Contact details</a></li>
                            <li><a href="../News.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5;">News</a></li>
                            <li><a href="../Terms_Conditions.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Terms of use</a></li>
                            <li><a href="../PrivacyPolicy.aspx" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Privacy Policy</a></li>
                            <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                line-height: 1.42857; color: #e1e3e5;">Site Map</a></li>
                            <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                line-height: 1.42857; color: #e1e3e5;">FAQ's</a></li>
                        </ul>
                    </div>
                    <div class="large-5 columns footer-links">
                        <a style="font-family: Cambria; font-size: 1.4375em; color: white">How-tos</a>
                        <ul style="list-style-type: disc; color: #e1e3e5; font-family: Calibri; padding-left: 15px;
                            text-align: justify">
                            <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                line-height: 1.42857; color: #e1e3e5;">Guide to TDS-e-filing</a></li>
                            <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                line-height: 1.42857; color: #e1e3e5;">Guide to generation of Form 16 A</a></li>
                            <%--<li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Guide for Interest on late filing</a></li>--%>
                            <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                line-height: 1.42857; color: #e1e3e5;">Import utility for Excel in TDS</a></li>
                            <li><a href=" https://tin.tin.nsdl.com/tan/form49B.html" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Apply TAN</a></li>
                            <li><a href="https://tin.tin.nsdl.com/tan/ChangeRequest.html" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Changes/Correction in TAN</a></li>
                            <li><a href=" https://tin.tin.nsdl.com/oltas/index.html" target="_blank" style="font-family: Arial,Helvetica,Arial,sans-serif;
                                font-size: 14px; line-height: 1.42857; color: #e1e3e5;">Challan Status Enquiry</a></li>
                            <li><a href=" https://onlineservices.tin.egov-nsdl.com/etaxnew/tdsnontds.jsp" target="_blank"
                                style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px; line-height: 1.42857;
                                color: #e1e3e5;">e-Payment</a></li>
                            <%--<li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Status of original return</a></li>
                <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif;font-size: 14px;line-height: 1.42857;color:#e1e3e5;">Status of correction return</a></li>--%>
                            <li><a href="#" style="font-family: Arial,Helvetica,Arial,sans-serif; font-size: 14px;
                                line-height: 1.42857; color: #e1e3e5;">All Plans with Pricing</a></li>
                        </ul>
                    </div>
                    <div class="large-3 columns footer-links">
                        <a style="font-family: Cambria; font-size: 1.4375em; color: white">Services</a>
                        <ul style="list-style-type: disc; color: #e1e3e5; font-family: Calibri; padding-left: 15px;
                            text-align: justify">
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
            <div class="large-12 columns">
                <hr style="margin-top: -4px;" />
                <div class="row" style="background-color: gray; margin-top: -10px;">
                    <div class="large-3 columns">
                        <p style="color: #e1e3e5;">
                            © 2016 Vatas Infotech Pvt.Ltd.</p>
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
                   <li ><a href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf"  style="color:White">FAQs</a></li>
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
