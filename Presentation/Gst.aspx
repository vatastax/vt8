<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gst.aspx.cs" Inherits="Gst" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
     <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>--%>
     <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
    <script src="../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <%--<link href="foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />--%>
    <script src="../foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="../foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
     <%--<script src="../sliderengine/jquery.js" type="text/javascript"></script>--%>
    <%--<link href="StaticStylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />--%>
    <script src="../js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>
    


     <!--menu js files-->
    <script src="../js/modernizr.custom.js" type="text/javascript"></script>
    <script src="../js/classie.js" type="text/javascript"></script>

<!--for mobile menu-->
    <!--master javascript file-->
     <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <!--master javascript file-->
    <!--master style sheet-->
    <link href="../style_folder/SidePagesStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
<!--for mobile menu-->


     <!--master style sheet-->
    <link href="../style_folder/StyleSheet.css" rel="Stylesheet"" type="text/css" />
    <!--master style sheet-->
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
    <div class="row" style="margin-top:10px; margin-bottom:10px;">
    <div class="large-8 columns">
    </div>
    <div class="large-4 columns text-right">
        
    </div>
  
    </div>
  
<!---->
   <div class="row show-for-small-only">
     <div class="small-12 columns" >
         
            <a href="../Default.aspx"><img src="../images/logo2.PNG" style="width:240px" /></a>
      
      
        </div>
    </div>
     <!--menu for small screen-->
        <div class="large-3 columns show-for-small-only " >
                <!--left-menu(quick links)--> 
                <nav class="cbp-spmenu cbp-spmenu-vertical cbp-spmenu-left " id="cbp-spmenu-s1">
                   <ul style="list-style-type:none">
			        <h3>Quick Links</h3>
			        <li ><a href="../AboutUs.aspx" >About Us</a></li>
                    <li ><a href="../ContactUsNew.aspx">Contact Us</a></li>
                    <li><a href="../News.aspx" >Latest News</a></li>
                    <li ><a href="../SiteMap.aspx" >Site Map</a></li>
                    <li><a href="../Terms_Conditions.aspx" >Terms & Conditions</a></li>
                    <li><a href="#" >Feedback & Support</a></li>
                    <li ><a href="../PrivacyPolicy.aspx" >Privacy Policy</a></li>
                   </ul>
		        </nav>
                <!--left-menu(quick links)-->  

                 <!--top-menu(main menu)--> 
                 <nav class="cbp-spmenu cbp-spmenu-horizontal cbp-spmenu-top" id="cbp-spmenu-s3">
                    <ul style="list-style-type:none;margin-left: 0.5rem;">
                        <img src="../images/logo2.PNG" style="width:200px; height:auto;margin:5px 0 2px 5px;"/>
			            <li ><a href="../default.aspx " >Home</a></li>
                        <li ><a href="../Services.aspx">Services</a></li>
                        <li style="padding-left:5px"><a href="../AboutUs.aspx">About</a></li>
                        <li><a href="../ContactUsNew.aspx" >Contact</a></li>
                        <li ><a href="#" >Login</a></li>
                   </ul>
                 </nav>

                  <!--placement of menu images-->
                  <div class="row text-right">
               		    <!-- Class "cbp-spmenu-open" gets applied to menu -->
					    <%--<button  id="showLeft">Menu</button>	--%>
                    
                    <img src="../images/menu.PNG" alt="menu"   id="showTop"/>
                   
                         <%--<img src="images/mobilemenu.PNG" id="showLeft" />--%>
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

       <div class="row show-for-large-only" >
         <div class="large-4 columns" >
         
            
             <a href="../Default.aspx"><img src="../images/logo2.PNG" style="width:240px; height:auto" /></a>
      
        </div>
        <div class="large-8 columns ">
          <ul class="right button-group">
          <li><a href="../default.aspx" class="button">HOME</a></li>
          <li><a href="../Services.aspx" class="button">SERVICES</a></li>
          <li><a href="../AboutUs.aspx" class="button">ABOUT US</a></li>
          <li><a href="../ContactUsNew.aspx" class="button">CONTACT US</a></li>
           <li id="li_Login" runat="server" class="has-sub"><a href="#" class="button" >LOGIN</a>
           <ul>
           <li><div style=" width:280px;height:auto;    border-radius:10px; margin-left:-60px; z-index:30001; background-color:#d3d3d3;opacity:0.85; overflow:hidden; ">
           <table style="border:none;background-color:gray;margin-top:20px;margin-bottom:0px; padding-bottom:0px  ">
           <tr style="background-color:#d3d3d3;">
           <td><span style="font-weight:bold">Username</span></td>
           <td>   <asp:TextBox ID="txtUser1" runat="server"  required></asp:TextBox></td>
           </tr>
            <tr style="background-color:#d3d3d3;">
           <td><span style="font-weight:bold">Password</span></td>
           <td>    <asp:TextBox ID="txtPassword1" runat="server"  TextMode="Password" required></asp:TextBox></td>
           </tr>
            <tr style="background-color:#d3d3d3;">
           <td>     <span style="font-weight:bold">Security Code</span></td>
           <td>    <asp:Image ID="Image1" runat="server" ImageUrl="CImage.aspx" Width="140px" Height="30px"/>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/refresh.png" /></td>
           </tr>
           <tr style="background-color:#d3d3d3;">
           <td></td>
           <td> <asp:TextBox ID="txtCaptcha" runat="server" ></asp:TextBox></td>
           </tr>
            <tr style="background-color:#d3d3d3; padding:0; margin:0"><td></td><td><asp:Button ID="Button1" runat="server" Text="Login" OnClick="btnLogin1_Click" Font-Bold="true" class="button" Height="30px" style="padding-top:0px; padding-bottom:0px; padding-left:5px; padding-right:5px" ></asp:Button></td></tr>
           <tr style="background-color:#d3d3d3; padding:0;  margin-top:-70px">
           <td><asp:LinkButton ID="lnkSignup" runat="server" Text="Signup" ForeColor="#008cba" Font-Bold="true" OnClick="lnkSignup_Click"></asp:LinkButton></td>
         
         <td><asp:LinkButton ID="lnkPwd" runat="server" Text="Forget Password???" ForeColor="#008cba" Font-Bold="true" OnClick="lnkPwd_Click"></asp:LinkButton></td>
           </tr>
       
           <tr style="background-color:#d3d3d3; padding:0">
           <td> <asp:Label ID="Label1" runat="server"></asp:Label></td><td></td>
           </tr>
          
           <%--<tr style="background-color:#d3d3d3;">
           <td></td><td></td>
           </tr>--%>
           </table>
       <%--      <div class="row" style="margin-bottom:10px; margin-top:10px"">
    <div class="large-4 columns">
    Username
    </div>
    <div class="large-8 columns">
        <asp:TextBox ID="TextBox1" runat="server"  required></asp:TextBox>
    <%--Password--%>
    </div>
    <%--<div class="large-3 columns">
    </div>
      <div class="large-3 columns">
    </div>--%>
   <%-- </div>
 
   <div class="row" style="margin-bottom:10px">
    <div class="large-4 columns">
        Password
    </div>
    <div class="large-8 columns">
       <asp:TextBox ID="TextBox2" runat="server"  TextMode="Password" required></asp:TextBox>
    </div>
    </div>
       
     <div class="row" >
       <div class="large-4 columns">
           Security Code:
        </div>                        
        <div class="large-8 columns">
             <asp:Image ID="Image1" runat="server" ImageUrl="Presentation/CImage.aspx" Width="80%"/>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/refresh.png" />
        </div>
    </div>
    <div class="row" style="margin-bottom:10px">    
        <div class="large-4 columns">
             
        </div>                     
        <div class="large-8 columns">
              <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
        </div>
    </div>
           
          <div class="row" style="margin-bottom:10px">
             <div class="large-4 columns"></div>
            <div class="large-8 columns"> 
                <asp:Button ID="Button1" runat="server" Text="Login" OnClick="btnLogin1_Click"></asp:Button>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>
   
   <%-- <div class="large-3 columns"></div>
    <div class="large-3 columns"></div>--%>
 <%--   </div>
    <div class="row">
         <div class="large-4 columns">
          </div>
        <div class="large-8 columns">
         <a href="#" style="color:gray; font-weight:bold;">Forget Password??</a>
        </div>

    </div>--%>
          </li>
           </ul>
           </li>
           <li id="li_Logout" runat="server">
           <asp:LinkButton ID="lbtnLogout" runat="server" Text="LOGOUT" CssClass="button" OnClick="lbtnLogout_Click"></asp:LinkButton>
           </li>
          </ul>
          
         </div>
    <div style="float:right;"><asp:Literal ID="ltWelcome" runat="server"></asp:Literal> </div>
       </div>

     <div class="row show-for-medium-only" >
        <br/>
        <div class="medium-4 columns" >
              <a href="../default.aspx"><img src="../images/logo2.PNG" style="width:180px; height:auto; margin-left:15px;" /></a>
        </div>
        <div class="medium-8 columns ">
            <ul class="right button-group">
                <li><a href="../default.aspx" class="button">HOME</a></li>
                <li><a href="../Services.aspx" class="button">SERVICES</a></li>
                <li><a href="../AboutUs.aspx" class="button">ABOUT US</a></li>
                <li><a href="../ContactUsNew.aspx" class="button">CONTACT US</a></li>
                <li><a href="#" class="button">LOGIN</a></li>
            </ul>
        </div>
    </div>

    <div class="submenu1" style="display:none;" >

        <div class="row" style="margin-bottom:10px; margin-top:10px"">
    <div class="large-4 columns">
    Username
    </div>
    <div class="large-8 columns">
        <asp:TextBox ID="txtUser11" runat="server" ></asp:TextBox>
    <%--Password--%>
    </div>
    <%--<div class="large-3 columns">
    </div>
      <div class="large-3 columns">
    </div>--%>
    </div>
 
   <div class="row" style="margin-bottom:10px">
    <div class="large-4 columns">
        Password
    </div>
    <div class="large-8 columns">
       <asp:TextBox ID="txtPassword11" runat="server"  TextMode="Password"></asp:TextBox>
    </div>
    </div>
       
     <div class="row" >
       <div class="large-4 columns">
           Security Code:
        </div>                        
        <div class="large-8 columns">
             <asp:Image ID="Image2" runat="server" ImageUrl="CImage.aspx" Width="80%"/>
            <asp:ImageButton ID="ibtnCap1" runat="server" ImageUrl="../images/refresh.png" />
        </div>
    </div>
    <div class="row" style="margin-bottom:10px">    
        <div class="large-4 columns">
             
        </div>                     
        <div class="large-8 columns">
              <asp:TextBox ID="txtCaptcha1" runat="server" ></asp:TextBox>
        </div>
    </div>
             <%--  <div class="large-3 columns">
   
            </div>
            <div class="large-3 columns"></div>
            </div>--%>
          <div class="row" style="margin-bottom:10px">
             <div class="large-4 columns"></div>
            <div class="large-8 columns"> 
                <asp:Button ID="btnLogin1" runat="server" Text="Login" OnClick="btnLogin1_Click"></asp:Button>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
   
   <%-- <div class="large-3 columns"></div>
    <div class="large-3 columns"></div>--%>
    </div>
    <div class="row">
         <div class="large-4 columns">
          </div>
        <div class="large-8 columns">
         <a href="#" style="color:gray; font-weight:bold;">Forget Password??</a>
        </div>

    </div>
    </div>

<!---->

    
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
<span style="color:#052A3C;"><span style="font-size: 30px;"><span style="font-family:  Calibri"> <b>Goods & Service Tax</b></span>
</p>


      </div>
      </div>
    <br />
      <div class="row ">
        <div class="large-7 columns text-center" style="background-color:#f2f2f2; border:1px solid rgb(223, 218, 218); padding:10px 0">
             <span style="color:#ef5845; font-size:20px; font-family:Cambria; margin-botton:30px">Latest Updates</span>
           
             <p style="text-align:justify; padding:10px 10px 0 10px">
             The Goods and Service Tax Bill or GST Bill, officially known as The Constitution (122nd Amendment) Bill, 2014, would be a Value added Tax (VAT) to be implemented in India, from April 2016. GST stands for “Goods and Services Tax”, and is proposed to be a comprehensive indirect tax levy on manufacture, sale and consumption of goods as well as services at the national level. It will replace all indirect taxes levied on goods and services by the Indian Central and State governments. It is aimed at being comprehensive for most goods and services.
             </p>
             <p style="text-align:justify; padding:10px 10px 0 10px">
             The tax-rate under the proposed GST would come down, but the number of assesses would increase by 5-6 times. Although rates would come down, tax collection would go up due to increased buoyancy. The government is working on a special IT platform for smooth implementation of the proposed Goods and Services Tax (GST). The IT special purpose vehicle (SPV) christened as GST N (Network) will be owned by three stakeholders—the centre, the states and the technology partner NSDL, then Central Board of Excise and Customs (CBEC) Chairman S Dutt Majumdar said while addressing a "National Conference on GST". On the possibility of rolling out GST, he said, "There was no need for alarm if GST was not rolled out in April 1, 2012."
             </p>
             <p style="text-align:justify; padding:10px 10px 0 10px">
             The GST at the Central and at the State level will thus give more relief to industry, trade, agriculture and consumers through a more comprehensive and wider coverage of input tax set-off and service tax setoff, subsuming of several taxes in the GST and phasing out of CST. With the GST being properly formulated by appropriate calibration of rates and adequate compensation where necessary, there may also be revenue/ resource gain for both the Centre and the States, primarily through widening of tax base and possibility of a significant improvement in tax-compliance. In other words, the GST may usher in the possibility of a collective gain for industry, trade, agriculture and common consumers as well as for the Central Government and the State Governments. The GST may, indeed, lead to the possibility of collectively positive-sum game.
             </p>

        </div>
        <div class="large-1 columns">&nbsp;</div>
        <div class="large-4 columns text-center" style="background-color:#f2f2f2; border:1px solid rgb(223, 218, 218);padding:10px 0">
           <span style="color:#ef5845; font-size:20px; font-family:Cambria; ">FAQ's</span>
           <ul style="text-align:justify; padding:10px 10px 0 10px;">
           <li>
           <span style="color:#007095; ">What is GST?</span><br />
           It is a tax levied when a consumer buys goods or services. This is how what consumption is taxed in most developed countries.
           </li>
           <li>
           <span style="color:#007095; ">What is article 246A and how will the power transferto states take place?</span><br />
           The bill introduces a new article that says Parliament, and, subject to some conditions, the legislature of every state will have power to make laws with respect to goods and services tax imposed by the Union or the state.
           </li>
           <li>
           <span style="color:#007095; ">Is there any authority constituted under the GST?</span></br>
           The President would be required to constitute a Goods and Services Tax Council within sixty days of the Act coming into force. The GST Council shall aim to develop a harmonized national market of goods and services.
            However, as contemplated earlier, the new Bill has deleted the provisions that creates a Goods and Services Tax Dispute Settlement Authority.
           </li>
           <li>
           <span style="color:#007095; ">How will the states recover loss of revenue?</span><br />
           The bill allows for compensation for revenue loss to states for a period of 5 years.
           </li>
           </ul>
        </div> 
     
  </div>
 
  
     
      <!-- Second Band (Image Left with Text) -->
     <br />
     <br />
     <div style="background-color:#2B7CAD; padding-left:10px">
 <div class="row" >
   </br></br>
    <div class="large-10 columns">
        <div class="row">
   
       <div class="large-8 columns footer-links">
       <h4 style=" color:#ffffff;  font-family:Cambria; padding-left:10px">About</h4>
        <ul style=" list-style-type:disc; color:#ff6600; font-family:Calibri; padding-left:15px" >
                
               
                    <li><a href="../AboutUs.aspx"  style="color:White">E-Chartered Accountants.com</a></li>
                      <li ><a href="../ContactUsNew.aspx"  style="color:White">Contact Details</a></li>
                 
                      <li ><a href="../Terms_Conditions.aspx"  style="color:White">Terms & Condition</a></li>
                      <li ><a href="../PrivacyPolicy.aspx"  style="color:White">Privacy & Policy</a></li>
                       <%--<li ><a href="#" style="color:White">Apply Digital Signature</a></li>--%>
                        <li ><a href="../SiteMap.aspx" style="color:White">Site Map</a></li>
                         <li ><a href="../News.aspx" style="color:White">Latest News</a></li>
                         <%-- <li ><a href="#" style="color:White">Blog</a></li>--%>
                       <li ><a href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf" target="_blank"  style="color:White">FAQs</a></li>
                  </ul>
       </div>
            <div class="large-4 columns">
            <h4 style=" color:#ffffff;  font-family:Cambria; padding-left:10px">Have a doubt? Ask here.</h4>
            <div class="row">
            <div class="large-4 columns" style="color:White;font-family:Calibri;">
             Name
            </div>
            <div class="large-8 columns">
            <asp:TextBox ID="txtName" runat="server" Width="230" style="border-radius:3px;"></asp:TextBox>
            </div>
            </div>
            <br />
             <div class="row">
            <div class="large-4 columns" style="color:White;font-family:Calibri;">
           Email
            </div>
            <div class="large-8 columns">
            <asp:TextBox ID="txtEmail" runat="server" Width="230" style="border-radius:3px;"></asp:TextBox>
            </div>
            </div>
             <br />
             <div class="row">
            <div class="large-4 columns" style="color:White;font-family:Calibri;">
            Subject
            </div>
            <div class="large-8 columns">
            <asp:TextBox ID="txtSubject" runat="server" Width="230" style="border-radius:3px"></asp:TextBox>
            </div>
            </div>
             <br />
             <div class="row" style="margin-top: 10px;">
            <div class="large-4 columns" style="color:White;font-family:Calibri;">
            Comment
            </div>
            <div class="large-7 columns"  style="margin-bottom:10px" >
            <asp:TextBox ID="txtComment" runat="server"  TextMode="MultiLine" style="border-radius:3px; height:75px; "></asp:TextBox>
            </div>
    
            <div class="large-1 columns"> </div>
            </div>
             <br />
      <div class="row" style="margin-top: 10px;">
            <div class="large-4 columns" style="color:White;font-family:Calibri;">
            Attachment
            </div>
            <div class="large-5 columns"  style="margin-bottom:10px" >
       <asp:FileUpload ID="FUpload1" runat="server" />
            </div>
    <div class="large-2 columns">
    
    </div>
            <div class="large-1 columns"> <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/submit1.PNG" OnClick="ImageButton2_Click" ></asp:ImageButton></div>
            </div>
            </div>
     <%--<div class="large-4 columns"></div>--%>
         </div>
     </div>
   
        <div class="large-12 columns">
     
          <hr />
          <div class="row">
            <div class="large-3 columns">
              <p style="color:Silver">© 2015 Vatas Infotech Pvt.Ltd.</p>
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
                   <li ><a href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf"  style="color:White">FAQs</a></li>
              </ul>--%>
            </div>
          </div>
        </div> 
    <%--  </footer>--%>
      
        </div>
      </div>  
        
         

       
        
    
 
    </form>
</body>
</html>
