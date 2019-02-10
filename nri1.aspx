<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="nri1.aspx.cs" Inherits="nri1"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br />
<div class="row" style="margin-bottom:50px">

<center>
    <img src="images/NRI_CONS.png" />

<h1 style="color:Black;">

</center>
</div>
<br /><br />

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
                   <li ><a href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf"  style="color:White">FAQs</a></li>
              </ul>--%>
            </div>
          </div>
        </div> 
    <%--  </footer>--%>
      
        </div>
   </div>
</asp:Content>