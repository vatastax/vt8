<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" %>

<!DOCTYPE html >

<html class="no-js" lang="en">
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
<head id="Head1" runat="server">
    <title></title>
    
     <%--<link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>

    <%-- <script src="js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
        <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>--%>

    <%--<link href="foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />--%>

   <%-- <script src="foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>--%>

       <%--<link href="StaticStylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />--%>

    <%--<script src="js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>--%>

    <!--menu js files-->
    <script src="js/modernizr.custom.js" type="text/javascript"></script>
    <script src="js/classie.js" type="text/javascript"></script>


    <!--master javascript file-->
     <script src="js/MasterJScript.js" type="text/javascript"></script>
    <!--master javascript file-->

    <!--master style sheet-->
    <link href="style_folder/SidePagesStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->


</head>
<body>
    <form id="form1" runat="server">
    <!-- for mobile menu -->
<%--<link rel="stylesheet" type="text/css" href="StaticStylesheet/default.css" />
<link rel="stylesheet" type="text/css" href="StaticStylesheet/component.css" />--%>

<!-- for mobile menu -->
<%--<link rel="stylesheet" type="text/css" href="StaticStylesheet/Stylesheet2.css">--%>

 <div class="row">
    <!--menu for large screen-->    
    <div class="row show-for-large-only" >
        </br>
        <div class="large-4 columns" >
            <img src="images/logo2.PNG" style="width:240px; height:auto" />
        </div>
        <div class="large-8 columns ">
            <ul class="right button-group">
                <li><a href="default.aspx" class="button">HOME</a></li>
                <li><a href="AboutUs.aspx" class="button">ABOUT US</a></li>
                <li><a href="ContactUs.aspx" class="button">CONTACT US</a></li>
                <li><a href="#" class="button">LOGIN</a></li>
            </ul>
        </div>
     </div>
    <!--menu for large  screen-->    

    <!--menu for medium screen-->    
    <div class="row show-for-medium-only" >
        <br/>
        <div class="medium-4 columns" >
             <img src="images/logo2.PNG" style="width:180px; height:auto;" />
        </div>
        <div class="medium-8 columns ">
            <ul class="right button-group">
                <li><a href="default.aspx" class="button">HOME</a></li>
                <li><a href="AboutUs.aspx" class="button">ABOUT US</a></li>
                <li><a href="ContactUs.aspx" class="button">CONTACT US</a></li>
                <li><a href="#" class="button">LOGIN</a></li>
            </ul>
        </div>
    </div>
    <!--menu for large screen-->    

    <!--logo for small screen-->
    <div class="row show-for-small-only">
        <div class="small-12 columns" >
           <a href="Default.aspx"><img src="images/logo2.PNG" style="width:240px" /></a>
        </div>
    </div>
    <!--logo for small screen-->

      <!--side menu for small and large screen-->
          <!--menu for small screen-->
            <div class="large-3 columns show-for-small-only " >
                <!--left-menu(quick links)--> 
                <nav class="cbp-spmenu cbp-spmenu-vertical cbp-spmenu-left " id="cbp-spmenu-s1">
                   <ul style="list-style-type:none">
			        <h3>Quick Links</h3>
			        <li ><a href="AboutUs.aspx" style="font-weight:bold;">About Us</a></li>
                    <li ><a href="ContactUs.aspx">Contact Us</a></li>
                    <li><a href="#" >Latest News</a></li>
                    <li ><a href="#" >Site Map</a></li>
                    <li><a href="#" >Terms & Conditions</a></li>
                    <li><a href="#" >Feedback & Support</a></li>
                    <li ><a href="#" >Terms & Conditions</a></li>
                    <li ><a href="#" >Privacy Policy</a></li>
                   </ul>
		        </nav>
                <!--left-menu(quick links)-->  

                 <!--top-menu(main menu)--> 
                 <nav class="cbp-spmenu cbp-spmenu-horizontal cbp-spmenu-top" id="cbp-spmenu-s3">
                    <ul style="list-style-type:none">
                        <img src="images/logo2.PNG" style="width:150px; height:auto;margin:5px 0 2px 0;"/>
			            <li ><a href="default.aspx " >Home</a></li>
                        <li ><a href="AboutUs.aspx" style=" font-weight:bold">About</a></li>
                        <li><a href="ContactUs.aspx" >Contact</a></li>
                        <li ><a href="#" >Login</a></li>
                   </ul>
                 </nav>

                  <!--placement of menu images-->
                  <div class="row text-right">
               		    <!-- Class "cbp-spmenu-open" gets applied to menu -->
					    <%--<button  id="showLeft">Menu</button>	--%>
                    
                    <img src="images/mainmenumob.PNG" alt="menu"   id="showTop"/>
                    <img src="images/menuuu1.png" alt="side-menu" id="showLeft"/>
                 
                         <%--<img src="images/mobilemenu.PNG" id="showLeft" />--%>
                        <%-- <button id="showLeft" style="background-image:url('images/mainmenumob.PNG')"></button>
					     <button id="showTop" style="background-image:url('images/mainmenumob.PNG')"></button>--%>
			      </div>


                 <!--java-script for menus-->
                 <script type="text/javascript">
                     var menuLeft = document.getElementById('cbp-spmenu-s1'),
			            showLeft = document.getElementById('showLeft'),
                        menuTop = document.getElementById('cbp-spmenu-s3'),
                        showTop = document.getElementById('showTop'),
                        body = document.body;

                     showLeft.onclick = function () {
                         classie.toggle(this, 'active');
                         classie.toggle(menuLeft, 'cbp-spmenu-open');
                         disableOther('showLeft');
                     };

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
        <br />
       
        <!--menu for large screen-->
        <div class="large-3 columns show-for-large-only abt ">
            <p style=" text-align:center; font-size:21px; font-family: Cambria;background-color:Gray;color:white;padding:5px">Quick Links</p> 
            <ul>
                <li><a href="AboutUs.aspx" style=" font-weight:bold;">About Us</a></li>
                <li ><a href="ContactUs.aspx">Contact Us</a></li>
                <li><a href="#" >Latest News</a></li>
                <li ><a href="#" >Site Map</a></li>
                <li><a href="#" >Terms & Conditions</a></li>
                <li><a href="#" >Feedback & Support</a></li>
                <li ><a href="#" >Terms & Conditions</a></li>
                <li ><a href="#" >Privacy Policy</a></li>
            </ul>  
       </div>
       <!--menu for large screen-->
        
        <!--right-part(for small and large screen)-->
        <div class="large-9 column hide-for-medium">
             <div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200;">
                  About Us
             </div>
             <div class="large-12 columns ">
                <p style="text-align:justify;font-family:Calibri;">
                    E-Chartered Accountants is teamwork of many heads involved, who are chartered accountants, tax experts and accountants. 
                    The C.A professionals have been working in this field from past 30 years. 
                    They have been serving clients for all kinds of direct and indirect taxation, tax related services, taxation queries and much more.
                    The Team of our C.As felt the need of technology in the field of taxation which was missing in India since long but actively prevalent in other big nations. 
                    They began with the process without any technical knowledge of software but have proved successful today with the state-of-art technology for direct and indirect taxes. 
                    E-Chartered Accountants was found in 2010 and now it is ready to be exploited to the best.
                    It is an authorized Government Intermediary and a company which will provide solutions to both companies and its employees. 
                    The cornerstones of E-Chartered Accountants include giving the best client experience and a commitment to serving clients how and where it is most convenient for them.
                    Our Tax Experts provide personal advisory services to each client, with the goal to give the most accurate advice and to prepare tax requirements with detailed knowledge.
                    Our Tax Experts strives to blend tax expertise with a strong focus on continually improving the client experience to provide all its clients with an unparalleled value proposition.
                </p>
            </div>
        </div>
        <!--right-part(for small and large screen)-->
     </div>
     <!--side menu for small and large screen-->   

  
    <!-- for medium screen-->
        <!--outer part for medium screen-->
                <div class="row show-for-medium-only">
                  <div class="medium-12 columns">
                  <!--content-part-->
                     <div class="row">
                        <!--left-part-->
                         <div class=" medium-3 columns abt  " >
                           <p style=" text-align:center; font-size:21px; font-family: Cambria;background-color:Gray;color:white;padding:5px">Quick Links</p> 
                             <ul >
                                <li ><a href="AboutUs.aspx" style="font-weight:bold;">About Us</a></li>
                                <li ><a href="ContactUs.aspx" >Contact Us</a></li>
                                <li><a href="#" >Latest News</a></li>
                                <li ><a href="#" >Site Map</a></li>
                                <li><a href="#" >Terms & Conditions</a></li>
                                <li><a href="#" >Feedback & Support</a></li>
                                <li ><a href="#" >Terms & Conditions</a></li>
                                <li ><a href="#" >Privacy Policy</a></li>
                            </ul>
                         </div>    
                          <!--left-part-->                                         
                          
                          <!--right-part-->
                          <div class=" medium-9 columns">
                             <div class="row">
                                 <div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200;">
                                    About Us
                                 </div>
                                <div class="large-12 small-12 columns ">
                                   <p style="text-align:justify;font-family:Calibri;">
                                         E-Chartered Accountants is teamwork of many heads involved, who are chartered accountants, tax experts and accountants.
                                         The C.A professionals have been working in this field from past 30 years. 
                                         They have been serving clients for all kinds of direct and indirect taxation, tax related services, taxation queries and much more.
                                          The Team of our C.As felt the need of technology in the field of taxation which was missing in India since long but actively prevalent in other big nations.
                                          They began with the process without any technical knowledge of software but have proved successful today with the state-of-art technology for direct and indirect taxes.
                                          E-Chartered Accountants was found in 2010 and now it is ready to be exploited to the best. 
                                          It is an authorized Government Intermediary and a company which will provide solutions to both companies and its employees. 
                                          The cornerstones of E-Chartered Accountants include giving the best client experience and a commitment to serving clients how and where it is most convenient for them.
                                          Our Tax Experts provide personal advisory services to each client, with the goal to give the most accurate advice and to prepare tax requirements with detailed knowledge. 
                                          Our Tax Experts strives to blend tax expertise with a strong focus on continually improving the client experience to provide all its clients with an unparalleled value proposition.
                                   </p>
                                </div>                                            
                            </div>
                         </div>
                         <!--right-part-->

                        </div>
                  <!--content-part-->

                    </div>
                </div>
                <!--outer part for medium screen-->
       
                <!-- Footer for medium screen -->
               <div  style="background-color:white; padding-top:20px;" >
                  <div class="row show-for-medium-only" >
                    <hr />
                    <div class="medium-12 columns" >
                       <div class="row">
                           <div class="medium-1 columns">
                           </div>
                           <!--footer menu-->
                           <div class="medium-11 columns text-right">
                              <ul class="inline-list right" >
                                <li style="  margin-left: 0.375rem;"><a href="default.aspx" style="color:Black;">Home   |</a></li>
                                <li style="  margin-left: 0.375rem;"><a href="ContactUs.aspx" style="color:Black;margin-left:0.05rem;">Contact Us   |</a></li>
                                <li style="  margin-left: 0.375rem;"><a href="#" style="color:Black;">SiteMap   |</a></li>
                                <li style="  margin-left: 0.375rem;"><a href="#" style="color:Black;">FAQs   |</a></li>
                                <li style="  margin-left: 0.375rem;"><a href="contact.aspx" style="color:Black;">Feedback & Support   |</a></li>
                                <li style="  margin-left: 0.375rem;"><a href="#" style="color:Black;">Terms & Conditions   |</a></li>
                                <li style="  margin-left: 0.375rem;"><a href="#" style="color:Black;">Privacy & Policy</a></li>
                              </ul>
                            </div>
                           <!--footer menu-->
                        </div>
                        <!--footer bottom part-->
                        <div class="row">
                          <!--copyright-->
                          <div class="medium-4 columns">
                               <p style="color:black">© 2015 Vatas Infotech Pvt.Ltd.</p>
                          </div>
                          <!--copyright-->
                          <!--social networking sites-->
                          <div class="medium-8 columns text-right">
                             <a><img src="images/fb.png" /></a>
                             <a><img src="images/twitter.png" /></a>
                             <a><img src="images/LINKEDIN1.PNG" /></a>
                             <a><img src="images/google.png" /></a>
                          </div>
                          <!--social networking sites-->
                       </div>
                       <!--footer bottom part-->
                     </div>
                  </div>
                </div>
                <!--footer for medium screen-->
           
        <!--outer part for medium screen-->
     <!-- for medium screen-->
      
  
    <!-- Footer for small and large screen-->
    <div  style="background-color:white; padding-top:20px;" >
        <div class="row hidden-for-medium-only" >
            <hr/>         
             <div class="large-12 columns">
                 <!--footer menu-->
                 <div class="row">
                     <div class="large-3 columns">
                     </div>     
                      <div class="large-9 columns text-right">
                        <ul class="inline-list right" >
                        <li style="  margin-left: 0.375rem;"><a href="default.aspx" style="color:Black;">Home   |</a></li>
                        <li style="  margin-left: 0.375rem;"><a href="ContactUs.aspx" style="color:Black;margin-left:0.05rem;">Contact Us   |</a></li>
                        <li style="  margin-left: 0.375rem;"><a href="#" style="color:Black;">SiteMap   |</a></li>
                        <li style="  margin-left: 0.375rem;"><a href="#" style="color:Black;">FAQs   |</a></li>
                        <li style="  margin-left: 0.375rem;"><a href="contact.aspx" style="color:Black;">Feedback & Support   |</a></li>
                        <li style="  margin-left: 0.375rem;"><a href="#" style="color:Black;">Terms & Conditions   |</a></li>
                        <li style="  margin-left: 0.375rem;"><a href="#" style="color:Black;">Privacy & Policy</a></li>
                    </ul>
                    </div>
                  </div>
                  <!--footer menu-->
                  <!--footer bottom-->
                  <div class="row">
                    <!--copyright-->
                    <div class="large-4 columns">
                         <p style="color:black">© 2015 Vatas Infotech Pvt.Ltd.</p>
                    </div>
                    <!--copyright-->
                    <!--social networking sites-->
                    <div class="large-8 columns text-right">
                         <a><img src="images/fb.png" /></a>
                        <a><img src="images/twitter.png" /></a>
                        <a><img src="images/LINKEDIN1.PNG" /></a>
                        <a><img src="images/google.png" /></a>
                    </div>
                    <!--social networking sites-->
                  </div>
                  <!--footer bottom-->
              </div>
          </div>      
     </div>
   
      <!--footer for small and large screen-->
    </form>
</body>
</html>
