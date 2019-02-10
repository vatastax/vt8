<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="2Services.aspx.cs" Inherits="Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="../foundation-5.5.0/js/foundation.min.js" type="text/javascript"></script>
    <script src="../js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-default.js" type="text/javascript"></script>
    <link href="../StaticStylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />
    <link href="../style_folder/DefaultStyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../StaticStylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</br>
<div class="row" style="margin-bottom:50px">
<div class="large-12 columns">
    <div class="row" style="margin-bottom:20px">
         <p class="lplh-58" style="text-align: center;">
         <span style=" font-size: 34px; font-family:Cambria; font-weight:500; line-height:1.1; letter-spacing:-2"> <span style="color:#3b3738;"> Our</span> <span style="color:#FC6F5C"> Services</span></span>
            <%--<span style="color:#3b3738;"><span style="font-size: 34px;"><span style="font-family:Cambria; font-weight:500; line-height:1.1; letter-spacing:-2"> Our Services</span>--%>
          </p>
    </div>
</div>
<div class="large-12 columns">
    <div class="row hide-for-small-only hide-for-medium-only">
        <div class="large-3 columns">
            <div style="width:220px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/itr.png" style="margin-left:80px" />
		        </div>
		       <%-- <div class="service_heading"  onmouseover="this.style.background='#FC6F5C'; this.style.color='#ffffff';" onmouseout="this.style.background='#dde1e0'; " style="background-color:#dde1e0; padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center">--%>
                <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="../pageRedirect.aspx?prj=vt">Income Tax Returns</a>
			        </br>
		        </div>
             </div>
        </div>
        <div class="large-3 columns">
            <div style="width:220px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/tds.png" style="margin-left:80px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="../pageRedirect.aspx?prj=tds">Tax Deducted at Source</a>
			        </br>
		        </div>
             </div>
        </div>
        <div class="large-3 columns">
            <div style="width:220px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/vat.png" style="margin-left:80px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="Gst.aspx">Goods & Service Tax</a>

			        </br>
		        </div>
             </div>
        </div>
        <div class="large-3 columns">
            <div style="width:220px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/st.png" style="margin-left:80px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="../pageRedirect.aspx?prj=stax">Service Tax</a>
			        </br>
		        </div>
             </div>
        </div>
    </div>

    <!--for large screens-->
     <div class="row  hide-for-small-only hide-for-medium-only" style="margin-top:30px; padding-left:80px">
        <div class="large-4 columns" >
            <div style="width:220px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/cet.png" style="margin-left:80px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="cet.aspx">Central Excise Tax</a>
			        </br>
		        </div>
             </div>
        </div> 
        
        <div class="large-4 columns" >
                   <div style="width:220px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/nri.png" style="margin-left:80px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="nri.aspx">NRI Taxation</a>
			        </br>
		        </div>
             </div>
        </div>
        
        
        <div class="large-4 columns">
            <div style="width:220px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/tp.png" style="margin-left:80px" />
		        </div>
		       <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="tp.aspx">Transfer Pricing</a>
			        </br>
		        </div>
             </div>
        </div>
        <div class="large-2 columns" >&nbsp;</div>
    </div>

    <!--for small screens-->
    <div class="row  show-for-small-only" style="margin-top:30px; ">
        <div class="large-4 columns" >
            <div style="width:220px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/cet.png" style="margin-left:80px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="cet.aspx">Central Excise Tax</a>
			        </br>
		        </div>
             </div>
        </div> 
        
        <div class="large-4 columns" >
                   <div style="width:220px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/nri.png" style="margin-left:80px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="nri.aspx">NRI Taxation</a>
			        </br>
		        </div>
             </div>
        </div>
        
        
        <div class="large-4 columns">
            <div style="width:220px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/tp.png" style="margin-left:80px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="tp.aspx">Transfer Pricing</a>
			        </br>
		        </div>
             </div>
        </div>
        <div class="large-2 columns" >&nbsp;</div>
    </div>
</div>


<!--for medium screens-->

<div class="medium-12 columns">
    <div class="row show-for-medium-only">
        <div class="medium-3 columns">
            <div style="width:180px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/itr.png" style="margin-left:65px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px 0;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="Presentation/default.aspx">Income Tax Returns</a>
			        </br>
		        </div>
             </div>
        </div>
        <div class="medium-3 columns">
            <div style="width:180px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/tds.png" style="margin-left:65px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px 0;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			       <a href="tds.aspx">Tax Deducted at Source</a>
			        </br>
		        </div>
             </div>
        </div>
        <div class="medium-3 columns">
            <div style="width:180px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/vat.png" style="margin-left:65px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px 0;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="Gst.aspx">Goods & Service Tax</a>
			        </br>
		        </div>
             </div>
        </div>
        <div class="medium-3 columns">
            <div style="width:180px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/st.png" style="margin-left:65px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px 0;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="servicetax.aspx">Service Tax</a>
			        </br>
		        </div>
             </div>
        </div>
    </div>

   
     <div class="row  show-for-medium-only" style="margin-top:30px; padding-left:80px">
        <div class="medium-4 columns" >
            <div style="width:180px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/cet.png" style="margin-left:65px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px 0;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="cet.aspx">Central Excise Tax</a>
			        </br>
		        </div>
             </div>
        </div> 
        
        <div class="medium-4 columns" >
                   <div style="width:180px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/nri.png" style="margin-left:65px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px 0;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			         <a href="nri.aspx">NRI Taxation</a>
			        </br>
		        </div>
             </div>
        </div>
        
        
        <div class="medium-4 columns">
            <div style="width:180px;float:left;">
                <div style=" background-color:#FC6F5C;padding-top:30px; padding-bottom:30px; border-top-left-radius:10px;border-top-right-radius:10px">
			        <img src="../images/tp.png" style="margin-left:65px" />
		        </div>
		        <div class="service_heading"  style=" padding:20px 0;  margin-bottom:10px;border-bottom-right-radius:10px; border-bottom-left-radius:10px; text-align:center;">
			        <a href="tp.aspx">Transfer Pricing</a>
			        </br>
		        </div>
             </div>
        </div>
        <div class="large-2 columns" >&nbsp;</div>
    </div>

   
</div>

</div>


<!--footer-->

  <div style="background-color:#2B7CAD; padding-left:10px">
<div class="row" >
   </br></br>
    <div class="large-10 columns">
        <div class="row">
   
       <div class="large-8 columns footer-links">
       <h4 style=" color:#ffffff;  font-family:Cambria; padding-left:10px">About</h4>
        <ul style=" list-style-type:disc; color:#FC6F5C; font-family:Calibri; padding-left:15px" >
                
               
                    <li><a href="AboutUs.aspx"  style="color:White">E-Chartered Accountants</a></li>
                      <li ><a href="ContactUsNew.aspx"  style="color:White">Contact Details</a></li>
                 
                      <li ><a href="Terms_Conditions.aspx"  style="color:White">Terms & Condition</a></li>
                      <li ><a href="PrivacyPolicy.aspx"  style="color:White">Privacy & Policy</a></li>
                       <%--<li ><a href="#" style="color:White">Apply Digital Signature</a></li>--%>
                        <li ><a href="SiteMap.aspx" style="color:White">Site Map</a></li>
                         <li ><a href="News.aspx" style="color:White">Latest News</a></li>
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
            <div class="large-1 columns"> <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/submit1.PNG" ></asp:ImageButton></div>
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
              
                <a><img src="../images/fb.png" /></a>
                <a><img src="../images/twitter.png" /></a>
                <a><img src="../images/LINKEDIN1.PNG" /></a>
                <a><img src="../images/google.png" /></a>
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
</asp:Content>

