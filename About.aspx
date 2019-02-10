<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Header and Nav -->
 <hr />
      <div class="row">
        <div class="large-12 columns">
          <div class="title" style="text-align:left">
         About Us
          </div>
        </div>
      </div>
      <!-- End Header and Nav -->
      <br />
      <div class="row">
     <!-- Nav Sidebar -->
        <!-- This is source ordered to be pulled to the left on larger screens -->
        <div class="large-4 columns hide-for-small-only ">
          <div class="panel">
            <a href="#"><img src="images/tax.jpg" /></a>
            <div class="subheading">Our Services</div>
              <div class="section-container vertical-nav" data-section data-options="deep_linking: false; one_up: true">
              <section class="section">
                <h5 ><a href="itr1.aspx">Income Tax Return</a></h5>
              </section>
              <section class="section">
                <h5 ><a href="tds.aspx">Tax Deducted at Source</a></h5>
              </section>
              <section class="section">
                <h5 ><a href="vat.aspx">Value Added Tax</a></h5>
              </section>
              <section class="section">
                <h5 ><a href="servicetax.aspx">Service Tax</a></h5>
              </section>
              <section class="section">
                <h5 ><a href="nri.aspx">NRI Taxation</a></h5>
              </section>
              <section class="section">
                <h5 ><a href="cet.aspx">Central Excise Tax</a></h5>
              </section>
              <section class="section">
                <h5 ><a href="tp.aspx">Transfer Pricing</a></h5>
              </section>
            </div>
     
          </div>
        </div>
        
        <!-- Main Feed -->
        <!-- This has been source ordered to come first in the markup (and on small devices) but to be to the right of the nav on larger screens -->
        <div class="large-8 columns">
     
          <!-- Feed Entry -->
          <div class="row">
            <div class="large-12 small-12 columns ">
            <p style="text-align:justify">
            E-Chartered Accountants is teamwork of many heads involved, who are chartered accountants, tax experts and accountants. The C.A professionals have been working in this field from past 30 years. They have been serving clients for all kinds of direct and indirect taxation, tax related services, taxation queries and much more.
The Team of our C.As felt the need of technology in the field of taxation which was missing in India since long but actively prevalent in other big nations. They began with the process without any technical knowledge of software but have proved successful today with the state-of-art technology for direct and indirect taxes. E-Chartered Accountants was found in 2010 and now it is ready to be exploited to the best. It is an authorized Government Intermediary and a company which will provide solutions to both companies and its employees. 

The cornerstones of E-Chartered Accountants include giving the best client experience and a commitment to serving clients how and where it is most convenient for them. Our Tax Experts provide personal advisory services to each client, with the goal to give the most accurate advice and to prepare tax requirements with detailed knowledge. Our Tax Experts strives to blend tax expertise with a strong focus on continually improving the client experience to provide all its clients with an unparalleled value proposition.

            </p>
            </div>
            
          </div>
          <!-- End Feed Entry -->
     
          <hr />
     
          <!-- Feed Entry -->
         
          <!-- End Feed Entry -->
     
        </div>
     
        <!-- Right Sidebar -->
        <!-- On small devices this column is hidden -->
     
        
      </div>
     
     
      <!-- Footer -->
     
      <footer class="row">
        <div class="large-12 columns">
          <hr />
          <div class="row">
            <div class="large-5 columns">
              <p>© Copyright Vatas Infotech.</p>
            </div>
            <div class="large-7 columns">
              <ul class="inline-list right">
                <li><a href="home.aspx">Home</a></li>
                <li><a href="about.aspx">About</a></li>
                <li><a href="contact.aspx">Contact Us</a></li>
                <li><a href="contact.aspx">Feedback & Support</a></li>
                <li><a href="#">Terms and Conditions</a></li>
                <li><a href="#">Privacy and Policy</a></li>
              </ul>
            </div>
          </div>
        </div>
      </footer>
    
</asp:Content>

