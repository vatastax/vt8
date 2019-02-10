<%@ Page Title="" Language="C#" MasterPageFile="~/VatasMaster.master" AutoEventWireup="true" CodeFile="ContactUsNew.aspx.cs" Inherits="ContactUsNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript">
     $(document).ready(function () {
         var pathname = document.URL;
         pathname = pathname.substring(pathname.lastIndexOf("/"));
         pathname = pathname.substring(1);
         // alert(pathname);
         $('ul>li').each(function () {
             $(this).find('a').removeClass('activebutton');
             if ($(this).find('a').attr('href') == pathname) {

                 $(this).addClass('activebutton');
                 // alert('done');
             }

         })
         // $(this).addClass('active');
     });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200; ">
                  Contact Us
             </div>
    <!--address and feedback part-->
          <div class="large-6 columns text-left" style="padding: 0 1.2em; float:left;">
             <!--Address part--> 
             <div class="row panel" style="background-color:White;margin-bottom:15px;">
                <p style="color:#e42200;font-size:20px; font-weight:bold; margin-bottom:10px;text-align:center;font-family:Cambria;">Headquaters</p>
                <p style="font-size: 16px;  margin-top:10px; font-family:Calibri;" >
                    Vatas Infotech Pvt. Ltd.<br />
                    Flat No.7A, MIG Improvement Trust Flats,<br />
                    J.P.Nagar,Jalandhar-144002<br />
                    Punjab India<br />
                    Tel: 0181-2258999,4636899</br>
                    Email: contact@vatasinfotech.com
                </p>
               </div>
             <!--Address part--> 

             <!--feedback part-->
             <div class="row panel" style=" background-color:White;">
                <p style="color:#e42200;font-size:20px; font-weight:bold; text-align:center;font-family:Cambria;">Tell us what you think!</p>
                <p style="color:black; font-size:16px; font-family:Calibri;"> We depend on your constant feedback to help us improve our services.<br />
                <ul>
                    <li style="font-family:Calibri;">Email to contact@vatasinfotech.com</a></li>
                    <li style="font-family:Calibri;">Post comments on any of our social network pages</a></li>
                     <a href="https://www.facebook.com/echarteredaccountants" target="_blank"><img src="images/fb.png" alt="facebook" /></a>
                            <a href="http://www.twitter.com/ECAccountant" target="_blank"><img src="images/twitter.png" alt="twitter"  /></a>
                            <a href="https://in.linkedin.com/pub/vatas-infotech/b9/264/a82" target="_blank"><img src="images/LINKEDIN1.PNG" alt="Linkedin"  /></a>
                            <a href="https://plus.google.com/u/0/b/108616341946641442746/108616341946641442746" target="_blank" ><img src="images/google.png" alt="google"  /></a>
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
                <div class="row panel" style="background-color:White; ">
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
                            <asp:TextBox ID="txtname" runat="server" placeholder="Enter Your Name " 
                                Height="25px" Width="178" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rq1" runat="server" ControlToValidate="txtname" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                     </div>
                     <!--Name field--> 
                     
                     <!--Email field-->
                     <div class="row" style="margin-bottom:7px;" >
                         <div class="large-3 columns " >
                            <label  style="font-size:16px; text-align:left;font-family:Calibri;">Email:</label>
                         </div>
                         <div class="large-9 columns ">
                              <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Your Email " 
                                 Height="25px" Width="178" ontextchanged="txtemail_TextChanged" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display=None
                                ControlToValidate="txtemail" ErrorMessage="Email id not in correct format" 
                                ForeColor="Red" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                    </div>
                    <!--Email field-->

                    <!--Subject field-->
                    <div class="row" style="margin-bottom:7px;">
                        <div class="large-3 columns" >
                            <label  style="font-size:16px; text-align:left;font-family:Calibri;">Subject:</label>
                        </div>
                        <div class="large-9 columns">
                            <asp:TextBox ID="txtsubject" runat="server" placeholder="Subject" 
                                Height="25px" Width="178"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsubject" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <div class="large-9 columns text-left" style="display:none">
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" Class="btn_contact" onclick="btnUpload_Click1" 
                                />
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
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtComment" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                    onclick="Button1_Click1" />
                            </div>
                        </div>
                        <!--submit button-->
                     </div>
                     <br />
               </div>
           <!--Query part-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" Runat="Server">
<div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200; ">
                  Contact Us
             </div>
    <div class="row">
     <div class="medium-6 columns text-left" style=" float:left;">
        <div class="row panel" style="background-color:White;margin-bottom:15px;">
        <p style="color:#e42200;font-size:20px; font-weight:bold; margin-bottom:20px;text-align:center; font-family: Cambria;">Headquaters</p>
        <p style="font-size: 16px;  margin-top:10px; font-family: Calibri" >
            Vatas Infotech Pvt. Ltd.<br />
            Flat No.7A, MIG Improvement Trust Flats,<br />
            J.P.Nagar,Jalandhar-144002<br />
            Punjab India<br />
            Tel: 0181-2258999,4636899</br>
            Email: contact@vatasinfotech.com
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
            <li style="font-family: Calibri">Email to: contact@vatasinfotech.com</li>
            <li style="font-family: Calibri">Post comments on any of our social network pages</a></li>
                 <a href="https://www.facebook.com/echarteredaccountants" target="_blank"><img src="images/fb.png" alt="facebook" /></a>
                <a href="http://www.twitter.com/ECAccountant" target="_blank"><img src="images/twitter.png" alt="twitter"  /></a>
                <a href="https://in.linkedin.com/pub/vatas-infotech/b9/264/a82" target="_blank"><img src="images/LINKEDIN1.PNG" alt="Linkedin"  /></a>
                <a href="https://plus.google.com/u/0/b/108616341946641442746/108616341946641442746" target="_blank" ><img src="images/google.png" alt="google"  /></a>
            </ul>
    </div>
    </div>
    <!--feedback part-->
 </div>

  <!--Query part-->
        <div class="row" >
            <div class="large-12 columns " >
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
                        <asp:TextBox ID="txtName1" runat="server" placeholder="Enter Your Name "  
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
                                <asp:TextBox ID="txtEmail1" runat="server" placeholder="Enter Your Email "  
                                        Height="29px" Width="178" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"  Display=None
                                ControlToValidate="txtEmail1" ErrorMessage="Email id not in correct format" 
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
                            <asp:TextBox ID="txtSubject1" runat="server" placeholder="Subject"  
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
                            <asp:TextBox ID="txtComment1"  runat="server" Height="50px" Width="178px"></asp:TextBox>
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
                        <div class="medium-3 columns " style="display:none">
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

    </label>

</asp:Content>


