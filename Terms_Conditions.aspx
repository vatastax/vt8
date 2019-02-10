<%@ Page Title="" Language="C#" MasterPageFile="~/VatasMaster.master" AutoEventWireup="true" CodeFile="Terms_Conditions.aspx.cs" Inherits="Terms_Conditions" %>

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
        Terms & Conditions
    </div>
     <div class="large-12 small-12 columns ">
     Echartered Accountants is a product of Vatas Infotech Private Limited.
     </div>
    <div class="large-12 small-12 columns ">
        <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Terms of Use</span>
             <p style="text-align:justify;font-family:Calibri;">
                  In order to use the Services, you must first agree to the Terms. You may not use the Services if you do not accept the Terms. You accept the Terms by creating an account for services at any echarteredaccountants.com website.You may not use the Services and may not accept the Terms if (a) you are not of legal age to form a binding contract with echarteredaccountants.com, or (b) you are not a resident of India. If you do not agree to all of these terms & conditions, do not access the website or any services or information provided on or through the website.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Provision of the Services</span>
             <p style="text-align:justify;font-family:Calibri;">
                Echarteredaccountants.com is constantly innovating in order to provide the best possible experience for its users. You acknowledge and agree that the form and nature of the Services which echarteredaccountants.com provides may change from time to time without prior notice to you. As part of this continuing innovation, you acknowledge and agree that echarteredaccountants.com may stop (permanently or temporarily) providing the Services (or any features within the Services) to you or to users generally at echarteredaccountants.com's sole discretion, without prior notice to you. You may stop using the Services at any time. You do not need to specifically inform echarteredaccountants.com when you stop using the Services. You acknowledge and agree that if echarteredaccountants.com disables access to your account, you may be prevented from accessing the Services, your account details or any files or other content which is contained in your account. You acknowledge and agree that while echarteredaccountants.com may not currently have set a fixed upper limit on the number of transmissions you may send or receive through the Services or on the amount of storage space used for the provision of any service, such fixed upper limits may be set by echarteredaccountants.com at any time, at echarteredaccountants.com’s discretion.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">User Responsibilities</span>
             <p style="text-align:justify;font-family:Calibri;">
                In order to prepare your return, to file your return, to provide advice about tax matters, and/or to provide an audit defense service, you will need to provide information about your income, deductions, credits, dependents, etc. Collectively, this information is known as tax return information. In order to use echarteredaccountants.com Services, you will need to provide your tax return information. You agree that any information you give to echarteredaccountants.com will always be accurate, correct and up to date. You agree to use the services only for purposes that are permitted by any applicable law, regulation or generally accepted practices or guidelines in the relevant jurisdictions (including any laws regarding the export of data or software to and from India). You agree not to access (or attempt to access) any of the Services by any means other than through the interface that is provided by echarteredaccountants.com, unless you have been specifically allowed to do so in a separate agreement with echarteredaccountants.com. You specifically agree not to access (or attempt to access) any of the Services through any automated means (including use of scripts or web crawlers) and shall ensure that you comply with the instructions set out in any robots.txt file present on the Services. You agree that you will not engage in any activity that interferes with or disrupts the Services (or the servers and networks which are connected to the Services). Unless you have been specifically permitted to do so in a separate agreement with echarteredaccountants.com, you agree that you will not reproduce, duplicate, copy, sell, trade or resell the Services for any purpose. You agree that you are solely responsible for (and that echarteredaccountants.com has no responsibility to you or to any third party for) any breach of your obligations under the Terms and for the consequences (including any loss or damage which echarteredaccountants.com may suffer) of any such breach. 
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">User Account</span>
             <p style="text-align:justify;font-family:Calibri;">
                You agree and understand that you are responsible for maintaining the confidentiality of passwords associated with any account you use to access the Services. Accordingly, you agree that you will be solely responsible to echarteredaccountants.com for all activities that occur under your account. If you become aware of any unauthorized use of your password or of your account, you agree to notify echarteredaccountants.com immediately.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Privacy and your Personal Information</span>
             <p style="text-align:justify;font-family:Calibri;">
                For information about echarteredaccountants.com’s data protection practices, please read echarteredaccountants.com’s privacy policy. This policy explains how echarteredaccountants.com treats your personal information, and protects your privacy, when you use the Services. You agree to the use of your data in accordance with echarteredaccountants.com’s privacy policies.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Correctness</span>
             <p style="text-align:justify;font-family:Calibri;">
                Echarteredaccountants.com takes great care in ensuring the correctness of your Income Tax Return. There are strong test suites and professionals (internal and third party) who work hard on ensuring the correctness of echarteredaccountants.com software. However, echarteredaccountants.com provides no guarantee or warranty on the correctness of your Income Tax Return. You are required to review your Income Tax Return for ensuring correctness. You will not hold echarteredaccountants.com responsible for any issue that arises from incorrect Income Tax Return filing.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Exclusion of Warranties</span>
             <p style="text-align:justify;font-family:Calibri;">
             <ul style="list-style-type:decimal">
                <li>Nothing in these terms shall exclude or limit echarteredaccountants.com’s warranty or liability for losses which may not be lawfully excluded or limited by applicable law. Some jurisdictions do not allow the exclusion of certain warranties or conditions or the limitation or exclusion of liability for loss or damage caused by negligence, breach of contract or breach of implied terms, or incidental or consequential damages. Accordingly, only the limitations which are lawful in your jurisdiction will apply to you and our liability will be limited to the maximum extent permitted by law. </li>
                <li>	You expressly understand and agree that your use of the services is at your sole risk and that the services are provided "as is" and “as available.”</li>
                <li>	In particular, echarteredaccountants.com, its subsidiaries and affiliates, and its licensors do not represent or warrant to you that: </li>
                    <ul style="list-style-type:upper-alpha">
                        <li>	Your use of the services will meet your requirements, </li>
                        <li>	Your use of the services will be uninterrupted, timely, secure or free from error, </li>
                       <li> 	Any information obtained by you as a result of your use of the services will be accurate or reliable, and </li>
                       <li>	    That defects in the operation or functionality of any software provided to you as part of the services will be corrected.</li>
                    </ul>
                <li>	Any material downloaded or otherwise obtained through the use of the services is done at your own discretion and risk and that you will be solely responsible for any damage to your computer system or other device or loss of data that results from the download of any such material. </li>
                <li>	No advice or information, whether oral or written, obtained by you from echarteredaccountants.com or through or from the services shall create any warranty not expressly stated in the terms. </li>
                <li>Echarteredaccountants.com further expressly disclaims all warranties and conditions of any kind, whether express or implied, including, but not limited to the implied warranties and conditions of merchantability, fitness for a particular purpose and non-infringement. </li>
               </ul>      

             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Limitation od Libility</span>
             <p style="text-align:justify;font-family:Calibri;">
             <ul style="list-style-type:decimal">
                <li>Subject to overall provision in paragraph above, you expressly understand and agree that echarteredaccountants.com, its subsidiaries and affiliates, and its licensors shall not be liable to you for: </li>
                <ul style="list-style-type:upper-alpha">
               	<li>Any direct, indirect, incidental, special consequential or exemplary damages which may be incurred by you, however caused and under any theory of liability.. This shall include, but not be limited to, any loss of profit (whether incurred directly or indirectly), any loss of goodwill or business reputation, any loss of data suffered, cost of procurement of substitute goods or services, or other intangible loss; </li>
                <li>Any loss or damage which may be incurred by you, including but not limited to loss or damage as a result of: </li>
                   <ul style="list-style-type:upper-roman">
                        <li>	Any reliance placed by you on the completeness, accuracy or existence of any advertising, or as a result of any relationship or transaction between you and any advertiser or sponsor whose advertising appears on the services; </li>
                        <li>	Any changes which echarteredaccountants.com may make to the services, or for any permanent or temporary cessation in the provision of the services (or any features within the services); </li>
                        <li>	The deletion of, corruption of, or failure to store, any content and other communications data maintained or transmitted by or through your use of the services; </li>
                        <li>	Your failure to provide echarteredaccountants.com with accurate account information; </li>
                        <li>	Your failure to keep your password or account details secure and confidential; </li>
                    </ul>
               </ul>
                <li>	The limitations on echarteredaccountants.com’s liability to you in paragraph above shall apply whether or not echarteredaccountants.com has been advised of or should have been aware of the possibility of any such losses arising. </li>
             </ul>

             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Refund Issuance</span>
             <p style="text-align:justify;font-family:Calibri;">
                Questions about refunds and cancellations should be addressed to refunds@echarteredaccountants.com. You can cancel your payment or request a refund before the CA Assigned has commenced working on your case. The claim for refund will be processed within 10 working days.
             </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" Runat="Server">
    <div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200; ">
        Terms & Conditions
    </div>
     <div class="medium-12  columns ">
        <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Terms of Use</span>
             <p style="text-align:justify;font-family:Calibri;">
                  In order to use the Services, you must first agree to the Terms. You may not use the Services if you do not accept the Terms. You accept the Terms by creating an account for services at any echarteredaccountants.com website.You may not use the Services and may not accept the Terms if (a) you are not of legal age to form a binding contract with echarteredaccountants.com, or (b) you are not a resident of India. If you do not agree to all of these terms & conditions, do not access the website or any services or information provided on or through the website.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Provision of the Services</span>
             <p style="text-align:justify;font-family:Calibri;">
                Echarteredaccountants.com is constantly innovating in order to provide the best possible experience for its users. You acknowledge and agree that the form and nature of the Services which echarteredaccountants.com provides may change from time to time without prior notice to you. As part of this continuing innovation, you acknowledge and agree that echarteredaccountants.com may stop (permanently or temporarily) providing the Services (or any features within the Services) to you or to users generally at echarteredaccountants.com's sole discretion, without prior notice to you. You may stop using the Services at any time. You do not need to specifically inform echarteredaccountants.com when you stop using the Services. You acknowledge and agree that if echarteredaccountants.com disables access to your account, you may be prevented from accessing the Services, your account details or any files or other content which is contained in your account. You acknowledge and agree that while echarteredaccountants.com may not currently have set a fixed upper limit on the number of transmissions you may send or receive through the Services or on the amount of storage space used for the provision of any service, such fixed upper limits may be set by echarteredaccountants.com at any time, at echarteredaccountants.com’s discretion.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">User Responsibilities</span>
             <p style="text-align:justify;font-family:Calibri;">
                In order to prepare your return, to file your return, to provide advice about tax matters, and/or to provide an audit defense service, you will need to provide information about your income, deductions, credits, dependents, etc. Collectively, this information is known as tax return information. In order to use echarteredaccountants.com Services, you will need to provide your tax return information. You agree that any information you give to echarteredaccountants.com will always be accurate, correct and up to date. You agree to use the services only for purposes that are permitted by any applicable law, regulation or generally accepted practices or guidelines in the relevant jurisdictions (including any laws regarding the export of data or software to and from India). You agree not to access (or attempt to access) any of the Services by any means other than through the interface that is provided by echarteredaccountants.com, unless you have been specifically allowed to do so in a separate agreement with echarteredaccountants.com. You specifically agree not to access (or attempt to access) any of the Services through any automated means (including use of scripts or web crawlers) and shall ensure that you comply with the instructions set out in any robots.txt file present on the Services. You agree that you will not engage in any activity that interferes with or disrupts the Services (or the servers and networks which are connected to the Services). Unless you have been specifically permitted to do so in a separate agreement with echarteredaccountants.com, you agree that you will not reproduce, duplicate, copy, sell, trade or resell the Services for any purpose. You agree that you are solely responsible for (and that echarteredaccountants.com has no responsibility to you or to any third party for) any breach of your obligations under the Terms and for the consequences (including any loss or damage which echarteredaccountants.com may suffer) of any such breach. 
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">User Account</span>
             <p style="text-align:justify;font-family:Calibri;">
                You agree and understand that you are responsible for maintaining the confidentiality of passwords associated with any account you use to access the Services. Accordingly, you agree that you will be solely responsible to echarteredaccountants.com for all activities that occur under your account. If you become aware of any unauthorized use of your password or of your account, you agree to notify echarteredaccountants.com immediately.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Privacy and your Personal Information</span>
             <p style="text-align:justify;font-family:Calibri;">
                For information about echarteredaccountants.com’s data protection practices, please read echarteredaccountants.com’s privacy policy. This policy explains how echarteredaccountants.com treats your personal information, and protects your privacy, when you use the Services. You agree to the use of your data in accordance with echarteredaccountants.com’s privacy policies.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Correctness</span>
             <p style="text-align:justify;font-family:Calibri;">
                Echarteredaccountants.com takes great care in ensuring the correctness of your Income Tax Return. There are strong test suites and professionals (internal and third party) who work hard on ensuring the correctness of echarteredaccountants.com software. However, echarteredaccountants.com provides no guarantee or warranty on the correctness of your Income Tax Return. You are required to review your Income Tax Return for ensuring correctness. You will not hold echarteredaccountants.com responsible for any issue that arises from incorrect Income Tax Return filing.
             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Exclusion of Warranties</span>
             <p style="text-align:justify;font-family:Calibri;">
             <ul style="list-style-type:decimal">
                <li>Nothing in these terms shall exclude or limit echarteredaccountants.com’s warranty or liability for losses which may not be lawfully excluded or limited by applicable law. Some jurisdictions do not allow the exclusion of certain warranties or conditions or the limitation or exclusion of liability for loss or damage caused by negligence, breach of contract or breach of implied terms, or incidental or consequential damages. Accordingly, only the limitations which are lawful in your jurisdiction will apply to you and our liability will be limited to the maximum extent permitted by law. </li>
                <li>	You expressly understand and agree that your use of the services is at your sole risk and that the services are provided "as is" and “as available.”</li>
                <li>	In particular, echarteredaccountants.com, its subsidiaries and affiliates, and its licensors do not represent or warrant to you that: </li>
                    <ul style="list-style-type:upper-alpha">
                        <li>	Your use of the services will meet your requirements, </li>
                        <li>	Your use of the services will be uninterrupted, timely, secure or free from error, </li>
                       <li> 	Any information obtained by you as a result of your use of the services will be accurate or reliable, and </li>
                       <li>	    That defects in the operation or functionality of any software provided to you as part of the services will be corrected.</li>
                    </ul>
                <li>	Any material downloaded or otherwise obtained through the use of the services is done at your own discretion and risk and that you will be solely responsible for any damage to your computer system or other device or loss of data that results from the download of any such material. </li>
                <li>	No advice or information, whether oral or written, obtained by you from echarteredaccountants.com or through or from the services shall create any warranty not expressly stated in the terms. </li>
                <li>Echarteredaccountants.com further expressly disclaims all warranties and conditions of any kind, whether express or implied, including, but not limited to the implied warranties and conditions of merchantability, fitness for a particular purpose and non-infringement. </li>
               </ul>      

             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Limitation od Libility</span>
             <p style="text-align:justify;font-family:Calibri;">
             <ul style="list-style-type:decimal">
                <li>Subject to overall provision in paragraph above, you expressly understand and agree that echarteredaccountants.com, its subsidiaries and affiliates, and its licensors shall not be liable to you for: </li>
                <ul style="list-style-type:upper-alpha">
               	<li>Any direct, indirect, incidental, special consequential or exemplary damages which may be incurred by you, however caused and under any theory of liability.. This shall include, but not be limited to, any loss of profit (whether incurred directly or indirectly), any loss of goodwill or business reputation, any loss of data suffered, cost of procurement of substitute goods or services, or other intangible loss; </li>
                <li>Any loss or damage which may be incurred by you, including but not limited to loss or damage as a result of: </li>
                   <ul style="list-style-type:upper-roman">
                        <li>	Any reliance placed by you on the completeness, accuracy or existence of any advertising, or as a result of any relationship or transaction between you and any advertiser or sponsor whose advertising appears on the services; </li>
                        <li>	Any changes which echarteredaccountants.com may make to the services, or for any permanent or temporary cessation in the provision of the services (or any features within the services); </li>
                        <li>	The deletion of, corruption of, or failure to store, any content and other communications data maintained or transmitted by or through your use of the services; </li>
                        <li>	Your failure to provide echarteredaccountants.com with accurate account information; </li>
                        <li>	Your failure to keep your password or account details secure and confidential; </li>
                    </ul>
               </ul>
                <li>	The limitations on echarteredaccountants.com’s liability to you in paragraph above shall apply whether or not echarteredaccountants.com has been advised of or should have been aware of the possibility of any such losses arising. </li>
             </ul>

             </p>

             <span style="font-family:Calibri; font-weight:bold; font-size:20px; ">Refund Issuance</span>
             <p style="text-align:justify;font-family:Calibri;">
                Questions about refunds and cancellations should be addressed to refunds@echarteredaccountants.com. You can cancel your payment or request a refund before the CA Assigned has commenced working on your case. 
             </p>
     </div>
</asp:Content>

