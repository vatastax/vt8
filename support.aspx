<%@ Page Title="" Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true" CodeFile="support.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <!-- End Top Bar -->
     
     
      <!-- Main Page Content and Sidebar -->
     
      <div class="row">
     
        <!-- Contact Details -->
        <div class="large-12 columns">
     
          <h3>Support</h3>
         
     
          <div class="section-container tabs" data-section>
            <section class="section">
              <h5 class="title"><a href="#panel1">Please Fill Below Fields to Submit Your Query</a></h5>
              <div class="content" data-slug="panel1">
               
                  <div class="row collapse">
                    <div class="large-2 columns">
                      <label class="inline">Your Email</label>
                    </div>
                    <div class="large-10 columns">
                   <%--   <input type="text" id="yourName" placeholder="Enter Your Email ">--%>
                   <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Your Email " Required 
                            Height="29px" Width="178px"></asp:TextBox>
                    </div>
                  </div>
                  <div class="row collapse">
                    <div class="large-2 columns">
                      <label class="inline">Subject</label>
                    </div>
                    <div class="large-10 columns">
                  <%--    <input type="text" id="yourEmail" placeholder="Subject">--%>
                  <asp:TextBox ID="txtsubject" runat="server" placeholder="Subject" Required 
                            Height="33px" Width="176px"></asp:TextBox>
                    </div>
                  </div>
                  <label class="inline">Comments</label>
                 <%-- <textarea rows="6"></textarea>--%><asp:TextBox ID="txtcomment" 
                      runat="server" Height="112px" Width="351px"></asp:TextBox>
                  <br />
                  <button type="submit" class="radius button">Submit</button>
              
              </div>
            </section>
          
          </div>
        </div>
     
        <!-- End Contact Details -->
     
     
        <!-- Sidebar -->
     
     
     
        <!-- End Sidebar -->
      </div>
     
      <!-- End Main Content and Sidebar -->
     
     
      <!-- Footer -->
     
      <footer class="row">
        <div class="large-12 columns">
          <hr />
          <div class="row">
            <div class="large-6 columns">
              <p>© Copyright no one at all. Go to town.</p>
            </div>
            <div class="large-6 columns">
              <ul class="inline-list right">
                <li><a href="#">Link 1</a></li>
                <li><a href="#">Link 2</a></li>
                <li><a href="#">Link 3</a></li>
                <li><a href="#">Link 4</a></li>
              </ul>
            </div>
          </div>
        </div>
      </footer>
     
      <!-- End Footer -->
     
     
     
      <!-- Map Modal -->
     
      <div class="reveal-modal" id="mapModal">
        <h4>Where We Are</h4>
        <p><img src="http://placehold.it/800x600" /></p>
     
        <!-- Any anchor with this class will close the modal. This also inherits certain styles, which can be overriden. -->
        <a href="#" class="close-reveal-modal">×</a>
      </div>
    
</asp:Content>

