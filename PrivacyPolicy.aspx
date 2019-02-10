<%@ Page Title="" Language="C#" MasterPageFile="~/VatasMaster.master" AutoEventWireup="true" CodeFile="PrivacyPolicy.aspx.cs" Inherits="PrivacyPolicy" %>

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
          Online Privacy Policy & Practices
     </div>
      <div class="large-12 small-12 columns ">
             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">General</span>
             <p style="text-align:justify;font-family:Calibri;">
                  Protecting your information is important. Our relationship with you is our most important asset. We want you to feel comfortable and confident when using our products and services and with entrusting your personal and tax return information to us.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Links to our Website</span>
             <p style="text-align:justify;font-family:Calibri;">
                   This privacy policy applies to the echarteredaccountants.com web site and services that display or links to this site.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Collection of Personal Information</span>
             <p style="text-align:justify;font-family:Calibri;">
                We ask you for information such as name, address, and telephone number that helps us create or maintain your account information. We require that you create user credentials consisting of a user id and password. We also collect an e-mail address so that we may send communications such as order confirmation or information about the status of your return. We also collect information about your income, deductions, credits, dependents, etc. Collectively, this information is known as tax return information.   
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Use of Personal Information</span>
             <p style="text-align:justify;font-family:Calibri;">
                  We use your information to provide you the products and services you request. We do not sell or rent your personal or tax return information to anyone. We do not share your personal or tax return information with anyone outside/inside of echarteredaccountants.com for their promotional or marketing use. We summarize information about your usage and combine it with that of others to learn about the use of echarteredaccountants.com products to help us develop new products and services. This information is collected in such a way that it cannot be used to identify an individual. We may use service companies on our behalf to perform services for you but these companies are not allowed to use your information for their own purposes.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Retention of Personal Information</span>
             <p style="text-align:justify;font-family:Calibri;">
                  We retain copies of your completed and filed tax returns as long as needed or as required by law. This information may also be used to perform analysis relating to your claims under our guarantees, or to provide you with a copy of your returns for your convenience.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Sharing of Personal Information</span>
             <p style="text-align:justify;font-family:Calibri;">
                  We may access and/or disclose your information if it is necessary to comply with the law or legal process, to protect or defend echarteredaccountants.com. For example, we may be required to cooperate with regulators or law enforcement action such as a court order, subpoena or search warrant.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Security of Personal Information</span>
             <p style="text-align:justify;font-family:Calibri;">
                  The security of your personal information is important to us. We work to protect your personal information and tax return information from loss, misuse or unauthorized alteration by using industry-recognized security safeguards, coupled with carefully developed security procedures and practices. We maintain electronic and procedural safeguards of all tax return information. We use both internal and external resources to review our security procedures. Whenever we prompt you to transmit sensitive information, such as tax return orcredit card information, we support the encryption of your information as it is transmitted to us. Our employees are trained and required to safeguard your information.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Updation of Privacy Policy</span>
             <p style="text-align:justify;font-family:Calibri;">
                  We may update Privacy Policy from time to time. We will post any Privacy Policy changes on this page and, if the changes are significant or we will send you mail notifying you of the change.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">ERI services for E-Filing of Income Tax Returns</span>
             <p style="text-align:justify;font-family:Calibri;">
                  When you are in the process of e-Filing your Income Tax Return, echarteredaccountants.com may request information on your behalf only in order to provide e-Filing services to you. 
                  <ul style="list-style-type:disc">
                        <li>Addition of you as a Client of the e-Return Intermediary.</li>
                        <li>Retrieval of ITR information using e-Return Intermediary web services.</li>
                        <li>E-Filing access of your ITR.</li>
                        <li>Other additional web services as provided to e-Return Intermediaries. </li>

                  </ul>
             </p>
            
            <span style="font-family:Calibri; font-weight:bold; font-size:20px; "></span>
             <p style="text-align:justify;font-family:Calibri;">
                  
             </p>

             
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" Runat="Server">
    <div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200; ">
        Privacy & Policy
    </div>
    <div class="medium-12  columns ">
    
         <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">General</span>
             <p style="text-align:justify;font-family:Calibri;">
                  Protecting your information is important. Our relationship with you is our most important asset. We want you to feel comfortable and confident when using our products and services and with entrusting your personal and tax return information to us.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Links to our Website</span>
             <p style="text-align:justify;font-family:Calibri;">
                   This privacy policy applies to the echarteredaccountants.com web site and services that display or links to this site.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Collection of Personal Information</span>
             <p style="text-align:justify;font-family:Calibri;">
                We ask you for information such as name, address, and telephone number that helps us create or maintain your account information. We require that you create user credentials consisting of a user id and password. We also collect an e-mail address so that we may send communications such as order confirmation or information about the status of your return. We also collect information about your income, deductions, credits, dependents, etc. Collectively, this information is known as tax return information.   
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Use of Personal Information</span>
             <p style="text-align:justify;font-family:Calibri;">
                  We use your information to provide you the products and services you request. We do not sell or rent your personal or tax return information to anyone. We do not share your personal or tax return information with anyone outside/inside of echarteredaccountants.com for their promotional or marketing use. We summarize information about your usage and combine it with that of others to learn about the use of echarteredaccountants.com products to help us develop new products and services. This information is collected in such a way that it cannot be used to identify an individual. We may use service companies on our behalf to perform services for you but these companies are not allowed to use your information for their own purposes.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Retention of Personal Information</span>
             <p style="text-align:justify;font-family:Calibri;">
                  We retain copies of your completed and filed tax returns as long as needed or as required by law. This information may also be used to perform analysis relating to your claims under our guarantees, or to provide you with a copy of your returns for your convenience.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Sharing of Personal Information</span>
             <p style="text-align:justify;font-family:Calibri;">
                  We may access and/or disclose your information if it is necessary to comply with the law or legal process, to protect or defend echarteredaccountants.com. For example, we may be required to cooperate with regulators or law enforcement action such as a court order, subpoena or search warrant.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Security of Personal Information</span>
             <p style="text-align:justify;font-family:Calibri;">
                  The security of your personal information is important to us. We work to protect your personal information and tax return information from loss, misuse or unauthorized alteration by using industry-recognized security safeguards, coupled with carefully developed security procedures and practices. We maintain electronic and procedural safeguards of all tax return information. We use both internal and external resources to review our security procedures. Whenever we prompt you to transmit sensitive information, such as tax return orcredit card information, we support the encryption of your information as it is transmitted to us. Our employees are trained and required to safeguard your information.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Updation of Privacy Policy</span>
             <p style="text-align:justify;font-family:Calibri;">
                  We may update Privacy Policy from time to time. We will post any Privacy Policy changes on this page and, if the changes are significant or we will send you mail notifying you of the change.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">ERI services for E-Filing of Income Tax Returns</span>
             <p style="text-align:justify;font-family:Calibri;">
                  When you are in the process of e-Filing your Income Tax Return, echarteredaccountants.com may request information on your behalf only in order to provide e-Filing services to you. 
                  <ul style="list-style-type:disc">
                        <li>Addition of you as a Client of the e-Return Intermediary.</li>
                        <li>Retrieval of ITR information using e-Return Intermediary web services.</li>
                        <li>E-Filing access of your ITR.</li>
                        <li>Other additional web services as provided to e-Return Intermediaries. </li>

                  </ul>
             </p>
            
            <span style="font-family:Calibri; font-weight:bold; font-size:20px; "></span>
             <p style="text-align:justify;font-family:Calibri;">
                  
             </p>

    </div> 
</asp:Content>

