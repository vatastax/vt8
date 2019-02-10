<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
       <hr />  
      <div class="row">
     
         
        <div class="large-6 columns " >
       
     <div class="title" >

          CONTACT Us
        
      </div>
      <br />
        <div class="row panel" style="height:240px; background-color:White">
         <div class="row subheader">
       <div class="large-12 columns subheading " style="color:#e42200">
       Our Headquarters
       </div>
     
       </div>
       <div class="large-12 columns">
       <p style"font-size: 18px; padding-bottom:-20px">
       Vatas Infotech Pvt. Ltd.<br />
       Flat No.7A, MIG Impereement Trust Flats,<br />
       J.P.Nagar,Jalandhar-144002<br />
       Punjab India
       Tel:0181-2258999,4636899
       Email:......@vatasinfotech.com</p>
       </div>
       </div>
       </div>
       <div class="large-6 columns">
       <br />
       <br />
    
      
       
                <div class="row panel" style="margin-top:35px; background-color:White">
                <div class="row subheader">
                <div class="large-12 columns subheading" style="color:#2fce03;">
                Tell us what you think
                </div>
                </div>
       <div class="large-12 columns">
            
     <p style="font-size: 18px; padding-bottom:-20px">  We depend on your constant feedback to help us improve our services.
     </p>
     
     
       <ul>
     
       <li><a href="#">Email to .............@vatasinfotech.com</a></li>
       <li><a href="#">Post comments on any of our social network pages</a></li>
       </ul>
       <img src="images/social.jpg" style="height:20px" />
       </div>
       </div>
       </div>
       </div>
     <%--  <div class="row">
       <div class="large-12 columns">
       Tell us your query
       </div>
       </div>--%>
       <br />
       <div class="row">
       <div class="large-6 columns panel " style="background-color:White"> <div class="row subheader">
       <div class="large-12 columns subheading" style="color:#00a3ee">
      Tell us your query
       </div>
       </div>
        <div class="row ">
       <div class="large-12 columns">
       <p style="font-size:18px">  We are always available to entertain your queries with our tax experts.</p>
       </div>
       </div>
         <div class="row ">
       <div class="large-12 columns">
  <div class="subheading" style="font-size:20px" >
Query Support*</div>
 

 
  <div class="subheading ">
          
             <a href="#panel1" style="font-size:18px">Please Fill Below Fields to Submit Your Query</a></div>
              <div class="content" data-slug="panel1">
                 <div class="row ">
                    <div class="large-2 columns">
                      <label class="inline">Name</label>
                    </div>
                    <div class="large-10 columns">
                      <%--<input type="text" id="yourName" placeholder="Enter Your Email ">--%>
                   <asp:TextBox ID="txtname" runat="server" placeholder="Enter Your Name " Required 
                            Height="29px" Width="178px" ></asp:TextBox>
                    </div>
                  </div>
                  <div class="row ">
                    <div class="large-2 columns">
                      <label class="inline">Email</label>
                    </div>
                    <div class="large-10 columns">
                      <%--<input type="text" id="yourName" placeholder="Enter Your Email ">--%>
                   <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Your Email " Required 
                            Height="29px" Width="178px" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtemail" ErrorMessage="Email id not in correct format" 
                            ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                  </div>
                  <div class="row  ">
                    <div class="large-2 columns">
                      <label class="inline">Subject</label>
                    </div>
                    <div class="large-10 columns">
                     <%-- <input type="text" id="yourEmail" placeholder="Subject">--%>
                  <asp:TextBox ID="txtsubject" runat="server" placeholder="Subject" Required 
                            Height="33px" Width="176px"></asp:TextBox>
                    </div>
                  </div>
                   <div class="row  ">
                    <div class="large-2 columns">
                      <label class="inline">Attachment</label>
                    </div>
                    <div class="large-6 columns">
                     <%-- <input type="text" id="yourEmail" placeholder="Subject">--%>
                 <asp:FileUpload ID="FUpload1" runat="server" />
                        
                    </div>
                    <div class="large-4 columns">
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" Class="radius button" 
                            onclick="btnUpload_Click" />
                    </div>
                  </div>
                  <label class="inline ">Comments</label>
                <%--  <textarea rows="6"></textarea>--%><asp:TextBox ID="txtcomment" 
                      runat="server" Height="112px" Width="351px"></asp:TextBox>
                  <br />
                  <asp:Button ID="Button1" runat="server" Text="Submit" class="radius button" 
                      onclick="Button1_Click" />
                
              
              </div>
        
          
          
  
      </div>
      </div>
       </div>
      
       
      
        <div class="large-6 columns">

        </div>
     
     
        </div>
     
     
      
         
      
     
       
     
     
       
     
      <footer class="row">
        <div class="large-12 columns">
          <hr/>
          <div class="row">
            <div class="large-4 columns">
              <p>© Copyright Vatas Infotech.</p>
            </div>
            <div class="large-8 columns">
              <ul class="inline-list right">
               <li><a href="Default.aspx">Home</a></li>
                <li><a href="about.aspx">About us</a></li>
                  <li><a href="contact.aspx">Contact us</a></li>
                  <li><a href="contact.aspx">Support&Feedback</a></li>
                  <li><a href="#">Terms&Condition</a></li>
                  <li><a href="#">Privacy&Policy</a></li>
              </ul>
            </div>
          </div>
        </div>
      </footer>
     
       
     
     
     
       
     
   
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

