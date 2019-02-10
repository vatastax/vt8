<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUs1.aspx.cs" Inherits="ContactUs1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<head id="Head1" runat="server">
    <title></title>
     <%--<link rel="stylesheet" type="text/css" href="StaticStylesheet/Stylesheet2.css">

    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
     <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>--%>
     <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <%--<link href="foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />--%>
    <script src="foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
     <script src="sliderengine/jquery.js" type="text/javascript"></script>
    <%--<link href="StaticStylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />--%>
    <script src="js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>

    <!--master style sheet-->
    <link href="style_folder/SidePagesStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->


</head>
<body>
    <form id="form1" runat="server">
    
        <!-- for mobile menu -->
       <%-- <link rel="stylesheet" type="text/css" href="StaticStylesheet/default.css" />
        <link rel="stylesheet" type="text/css" href="StaticStylesheet/component.css" />--%>
        <script src="js/modernizr.custom.js"></script>
            <script src="js/classie.js" type="text/javascript"></script>
        <!-- for mobile menu -->

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
         </br>
             <div class="medium-4 columns" >
                <img src="images/logo2.PNG" style="width:180px; height:auto;margin-left:15px;" />
      
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
 
    <br /> 
      <!--menu for mobile-->
        <div class="large-3 columns show-for-small-only " >
              
                <nav class="cbp-spmenu cbp-spmenu-vertical cbp-spmenu-left " id="cbp-spmenu-s1">
                   <ul style="list-style-type:none">
			        <h3>Quick Links</h3>
			        <li ><a href="AboutUs.aspx">About Us</a></li>
                    <li ><a href="ContactUs.aspx" style=" font-weight: bold;">Contact Us</a></li>
                    <li><a href="#" >Latest News</a></li>
                    <li ><a href="#" >Site Map</a></li>
                    <li><a href="#" >Terms & Conditions</a></li>
                    <li><a href="#" >Feedback & Support</a></li>
                    <li ><a href="#" >Terms & Conditions</a></li>
                    <li ><a href="#" >Privacy Policy</a></li>
                   </ul>
		        </nav>

                 <nav class="cbp-spmenu cbp-spmenu-horizontal cbp-spmenu-top" id="cbp-spmenu-s3">
                  
                   <ul style="list-style-type:none">
                  <img src="images/logo2.PNG" style="width:150px; height:auto;margin:5px 0 2px 0;"/>
			        <li ><a href="default.aspx " >Home</a></li>
                    <li ><a href="AboutUs.aspx" >About</a></li>
                    <li><a href="ContactUs.aspx" style=" font-weight:bold">Contact</a></li>
                    <li ><a href="#" >Login</a></li>
                   
                   </ul>
                  
		        </nav>

            <div class="row text-right">
               		<!-- Class "cbp-spmenu-open" gets applied to menu -->
					<%--<button  id="showLeft">Menu</button>	--%>
                    <img src="images/mainmenumob.PNG" alt="menu"   id="showTop"/>
                <img src="images/menuuu1.png" alt="side-menu" id="showLeft"/>
                
                
            </div>

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




        </div>
        <!--menu for mobile-->

        <!--content part for large-screen-->
        <!--left part-->
        <div class="large-3 columns abt show-for-large-only " >
         
            <p style=" text-align:center; font-size:21px; font-family: Cambria;background-color:Gray;color:white;padding:5px">Quick Links</p> 
            <ul >
                <li ><a href="AboutUs.aspx">About Us</a></li>
                <li ><a href="ContactUS.aspx" style="font-weight:bold;">Contact Us</a></li>
                <li><a href="#" >Latest News</a></li>
                <li ><a href="#" >Site Map</a></li>
                <li><a href="#" >Terms & Conditions</a></li>
                <li><a href="#" >Feedback & Support</a></li>
                <li ><a href="#" >Terms & Conditions</a></li>
                <li ><a href="#" >Privacy Policy</a></li>
            </ul>
          </div>  
         <!--left part-->
         <!--right part-->
          <div class="large-9 columns  hide-for-medium-only">
  
          <!--heading-->   
                 <%-- <div class="row">
                     <div class="large-12 columns">
                           <div class="title" style="text-align:left">
                                 Contact Us
                          </div>
                    </div>
                  </div>--%>
             <!--heading-->   
        
         <!--address and feedback part-->
          <div class="large-6 columns text-left" style="padding: 0 1.2em; float:left;">
             <!--Address part--> 
             <div class="row panel" style="background-color:White;margin-bottom:15px;">
                <p style="color:#e42200;font-size:20px; font-weight:bold; margin-bottom:10px;text-align:center;font-family:Cambria;">Headquaters</p>
                <p style="font-size: 16px;  margin-top:10px; font-family:Calibri;" >
                    Vatas Infotech Pvt. Ltd.<br />
                    Flat No.7A, MIG Impereement Trust Flats,<br />
                    J.P.Nagar,Jalandhar-144002<br />
                    Punjab India<br />
                    Tel:0181-2258999,4636899</br>
                    Email:...... @vatasinfotech.com
                </p>
               </div>
             <!--Address part--> 

             <!--feedback part-->
             <div class="row panel" style=" background-color:White;">
                <p style="color:#e42200;font-size:20px; font-weight:bold; text-align:center;font-family:Cambria;">Tell us what you think!</p>
                <p style="color:black; font-size:16px; font-family:Calibri;"> We depend on your constant feedback to help us improve our services.<br />
                <ul>
                    <li><a href="#" style="font-family:Calibri;">Email to .............@vatasinfotech.com</a></li>
                    <li><a href="#" style="font-family:Calibri;">Post comments on any of our social network pages</a></li>
                    <a><img src="images/fb.png" /></a>
                    <a><img src="images/twitter.png" /></a>
                    <a><img src="images/LINKEDIN1.PNG" /></a>
                    <a><img src="images/google.png" /></a>
                </ul>
              </div>
              <!--feedback part-->
            </div>
           <!--address and feedback part-->
           
           <!--Query part-->
           <div class="large-6 columns  ">
                <div class="row show-for-small-only ">
                    <br />
                </div>
                <div class="row panel" style="background-color:White;">
                    <!--heading part-->
                    <p> 
                        <span style="color:#e42200;font-size:20px; font-weight:bold; margin-top:10px;margin-bottom:10px; text-align:center; font-family:Cambria"> Tell us your Query!
                        </span></br>
                        <span   style="color:black; font-size:16px;   font-family:Calibri; font-weight: normal; text-align:left; "> We are always available to entertain your queries with our tax experts.
                        </span>
                    </p>
                    <p style="color:black;font-size:17px; font-weight:bold; margin-bottom:10px;text-align:center; font-family: Calibri">Please fill below fields to Submit your Query<br /></p>
                    <!--heading part-->
                    
                    <!--Name field-->                   
                    <div class="row " style="margin-bottom:7px;">
                       <div class="large-3 columns " >
                           <label style="font-size:16px;text-align:left; font-family:Calibri;">Name:</label>
                       </div>
                       <div class="large-9 columns " >
                            <%--<input type="text" id="yourName" placeholder="Enter Your Email ">--%>
                            <asp:TextBox ID="txtname" runat="server" placeholder="Enter Your Name " Required 
                                Height="25px" Width="178" ></asp:TextBox>
                        </div>
                     </div>
                     <!--Name field--> 
                     
                     <!--Email field-->
                     <div class="row" style="margin-bottom:7px;" >
                         <div class="large-3 columns " >
                            <label  style="font-size:16px; text-align:left;font-family:Calibri;">Email:</label>
                         </div>
                         <div class="large-9 columns ">
                              <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Your Email " Required 
                                 Height="25px" Width="178" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display=None
                                ControlToValidate="txtemail" ErrorMessage="Email id not in correct format" 
                                ForeColor="Red" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                         </div>
                    </div>
                    <!--Email field-->

                    <!--Subject field-->
                    <div class="row" style="margin-bottom:7px;">
                        <div class="large-3 columns" >
                            <label  style="font-size:16px; text-align:left;font-family:Calibri;">Subject:</label>
                        </div>
                        <div class="large-9 columns">
                            <asp:TextBox ID="txtsubject" runat="server" placeholder="Subject" Required 
                                Height="25px" Width="178"></asp:TextBox>
                        </div>
                     </div>
                     <!--Subject field-->

                     <!--Attachment field-->
                     <div class="row" style="margin-bottom:7px;">
                        <div class="large-3 columns">
                            <label  style="font-size:16px;  text-align:left;font-family:Calibri;">Attachment:</label>
                        </div>
                        <div class="large-9 columns">
                             <asp:FileUpload ID="FUpload1" runat="server" />
                        </div>
                        <br />
                      </div>
                      <!--Attachment field-->

                      <!--upload button-->
                      <div class="row" >
                        <div class="large-3 columns text-left">
                        </div>
                        <div class="large-9 columns text-left">
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" Class="btn_contact" 
                                onclick="btnUpload_Click" />
                        </div>
                       </div>
                       <!--upload button-->

                       <!--Comment field-->
                       <div class="row" style="margin-bottom:7px;">
                          <div class="large-3 columns">
                                <label  style="font-size:16px; text-align:left;font-family:Calibri;">Comments:</label>
                          </div>
                          <div class="large-9 columns">
                              <asp:TextBox ID="txtComment" 
                              runat="server" Height="50px" Width="178px"></asp:TextBox>
                          </div><br />
                        </div>
                        <!--comment field-->
                        <br />

                        <!--submit button-->
                        <div class="row" style="margin-bottom:7px;">
                             <div class="large-3 columns">
                             </div>
                            <div class="large-9 columns text-left" >
                                <asp:Button ID="Button1" runat="server" Text="Submit" class="btn_contact" 
                                    onclick="Button1_Click" />
                            </div>
                        </div>
                        <!--submit button-->
                     </div>
               </div>
           <!--Query part-->
     
        </div>
         <!--right part-->
         <!--content part for large-screen-->          
     </div>
         
            <!--content part for medium screen-->
            <div class="row show-for-medium-only">
                <!--Content part-->
                <div class="medium-12 columns">
                   <div class="row">
                       <!--left part(menu)-->
                       <div class=" medium-3 columns abt  " >
                         <p style="text-align:center;font-family: Cambria; font-size:21px; background-color:Gray;color:white;padding:5px">Quick Links</p> 
                         <ul >
                            <li ><a href="AboutUs.aspx">About Us</a></li>
                            <li ><a href="ContactUs.aspx" style="font-weight:bold;">Contact Us</a></li>
                            <li><a href="#" >Latest News</a></li>
                            <li ><a href="#" >Site Map</a></li>
                            <li><a href="#" >Terms & Conditions</a></li>
                            <li><a href="#" >Feedback & Support</a></li>
                            <li ><a href="#" >Terms & Conditions</a></li>
                            <li ><a href="#" >Privacy Policy</a></li>
                          </ul>
                        </div>  
                        <!--left part(menu)-->                                           
                        
                        <!--right part-->  
                        <div class=" medium-9 columns">
                           <!--address and feedback part-->
                           <div class="row">
                             <!--address part-->
                              <div class="medium-6 columns text-left" style=" float:left;">
                                 <div class="row panel" style="background-color:White;margin-bottom:15px;">
                                    <p style="color:#e42200;font-size:20px; font-weight:bold; margin-bottom:20px;text-align:center; font-family: Cambria;">Headquaters</p>
                                    <p style="font-size: 16px;  margin-top:10px; font-family: Calibri" >
                                        Vatas Infotech Pvt. Ltd.<br />
                                        Flat No.7A, MIG Impereement Trust Flats,<br />
                                        J.P.Nagar,Jalandhar-144002<br />
                                        Punjab India<br />
                                        Tel:0181-2258999,4636899</br>
                                        Email:...... @vatasinfotech.com
                                    </p>
                                  </div>
                               </div>      
                             <!--address part-->                                  
                                 
                             <!--feedback part-->                                                 
                             <div class="medium-6 columns " style="padding:0  1.2em; ">
                                <div class="row panel" style=" background-color:White;">
                                    <p style="color:#e42200;font-size:20px; font-weight:bold; text-align:center; font-family: Cambria;">Tell us what you think!</p>
                                    <span style="color:black; font-size:16px; "> We depend on your constant feedback to help us improve our services.</span>
                                     <ul>
                                        <li><a href="#" style="font-family: Calibri">Email to: .............@vatasinfotech.com</a></li>
                                        <li><a href="#" style="font-family: Calibri">Post comments on any of our social network pages</a></li>
                                        <a><img src="images/fb.png" /></a>
                                        <a><img src="images/twitter.png" /></a>
                                        <a><img src="images/LINKEDIN1.PNG" /></a>
                                        <a><img src="images/google.png" /></a>
                                     </ul>
                                </div>
                              </div>
                              <!--feedback part-->
                            </div>
                           <!--address and feedback part-->
                         
                         <!--Query part-->
                         <div class="row">
                             <div class="large-12 columns "  >
                                 <div class="row panel" style="background-color:White;">
                                    <!--headings-->
                                    <p> 
                                        <span style="color:#e42200;font-size:20px; font-weight:bold; margin-top:10px;margin-bottom:10px; text-align:center; font-family:Cambria"> Tell us your Query!
                                        </span></br>
                                        <span   style="color:black; font-size:16px; text-align:center; font-family:Calibri; font-weight: normal; "> We are always available to entertain your queries with our tax experts.
                                        </span>
                                    </p>
                                    <p style="color:black;font-size:17px; font-weight:bold; margin-bottom:10px;text-align:center; font-family: Calibri">Please fill below fields to Submit your Query<br /></p>
                                    <br />
                                    <!--headings-->

                                    <!--first row-->
                                    <div class="row " style="margin-bottom:10px;">
                                        <!--Name field-->
                                        <div class="medium-6 columns">
                                           <div class="medium-3 columns ">
                                                <label style="font-size:16px;text-align:left;font-family:Calibri" ">Name:</label>
                                            </div>
                                            <div class="medium-9 columns " >
                                                <%--<input type="text" id="yourName" placeholder="Enter Your Email ">--%>
                                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Enter Your Name " Required 
                                                    Height="29px" Width="178" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <!--Name field-->

                                        <!--Email field-->
                                        <div class="medium-6 columns">
                                            <div class="medium-3 columns " >
                                                <label style="font-size:16px; text-align:left;font-family:Calibri"">Email:</label>
                                             </div>
                                             <div class="medium-9 columns ">
                                                  <asp:TextBox ID="TextBox6" runat="server" placeholder="Enter Your Email " Required 
                                                         Height="29px" Width="178" ></asp:TextBox>
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"  Display=None
                                                    ControlToValidate="txtemail" ErrorMessage="Email id not in correct format" 
                                                    ForeColor="Red" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                               </div>
                                        </div>
                                        <!--Email field-->
                                    </div>
                                    <!--first row-->
                                    
                                    <!--second row-->
                                    <div class="row " >
                                        <!--Subject field-->
                                        <div class="medium-6 columns">
                                            <div class="medium-3 columns ">
                                                 <label   style="font-size:16px; text-align:left;font-family:Calibri"">Subject:</label>
                                            </div>
                                            <div class="medium-9 columns " >
                                                <asp:TextBox ID="TextBox3" runat="server" placeholder="Subject" Required 
                                                 Height="33px" Width="178"></asp:TextBox>
                                            </div>
                                        </div>
                                        <!--Subject field-->
                                        <!--Comment field-->
                                        <div class="medium-6 columns">
                                            <div class="medium-3 columns ">
                                                <label style="font-size:16px; text-align:left;font-family:Calibri"">Comments:</label>
                                            </div>
                                            <div class="medium-9 columns ">
                                                <asp:TextBox ID="TextBox4"  runat="server" Height="50px" Width="178px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <!--Comment field-->
                                    </div>
                                    <!--second row-->

                                    <!--third row-->
                                    <div class="row" style="margin-top:15px;">
                                        <!--Attachment field-->
                                        <div class="medium-9 columns">
                                            <div class="medium-3 columns ">
                                                <label class="inline" style="font-size:16px;  text-align:left;font-family:Calibri"">Attachment</label>
                                            </div>
                                            <div class="medium-6 columns " >
                                                <asp:FileUpload ID="FileUpload2" runat="server" />
                                            </div>
                                            <div class="medium-3 columns " >
                                                <asp:Button ID="Button4" runat="server" Text="Upload" 
                                                onclick="btnUpload_Click" />
                                            </div>
                                         </div>
                                         <div class="medium-3 columns">
                                         </div>   
                                         <!--Attachment field-->
                                    </div>
                                    <!--third row-->
                                    
                                    <!--submit button-->
                                    <div class="row">
                                        <div class="medium-3 columns text-right ">
                                            <asp:Button ID="Button3" runat="server" Text="Submit" class="btn_contact" 
                                            onclick="Button1_Click" />
                                        </div>
                                        <div class="medium-9 columns">
                                        </div>
                                     </div>
                                     <!--submit button-->
                                </div>
                              </div>
                         </div>
                         <!--Query part-->


                          </div>
                        <!--right part-->  
                    </div>
                </div>
                <!--content part-->

                <!-- Footer for medium screen -->
                <div  style="background-color:white; padding-top:20px;" >
                  <div class="row show-for-medium-only" >
                     <hr />
                     <div class="medium-12 columns" >
                        <!--footer menu-->
                        <div class="row">
                            <div class="medium-1 columns">
                            </div>
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
                        </div>
                        <!--footer menu-->
                        <!--footer bottom-->
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
                        <!--footer bottom-->
                     </div>
                  </div>
                </div>
                <!--footer for medium screen-->
             </div>
             <!--content part for medium screen-->
            

          <!-- Footer for small and large screen-->
          <div  style="background-color:white; padding-top:20px;" >
              <div class="row hidden-for-medium-only" >
                <hr/>
                 <div class="large-12 columns" >
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
