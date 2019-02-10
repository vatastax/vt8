<%@ Page Title="" Language="C#" MasterPageFile="~/VatasMaster.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript">
     $(document).ready(function () {
         var pathname = document.URL;
         pathname = pathname.substring(pathname.lastIndexOf("/"));
         pathname = pathname.substring(1);
          //alert(pathname);
         $('ul>li').each(function () {
             $(this).find('a').removeClass('activebutton');
             if ($(this).find('a').attr('href') == pathname) {
                 //alert($(this).find('a').attr('href'));
                 $(this).addClass('activebutton');
                 //alert('done');
             }

         })
         // $(this).addClass('active');
     });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">

  
    <div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200; ">
                  About Us
             </div>
             <div class="large-12 small-12 columns ">
                <p style="text-align:justify;font-family:Calibri;">
                    E-Chartered Accountants is teamwork of many heads involved, who are chartered accountants, tax experts and accountants. 
                    The C.A professionals have been working in this field from past 30 years. 
                    They have been serving clients for all kinds of direct and indirect taxation, tax related services, taxation queries and much more.
                    The Team of our C.As felt the need of technology in the field of taxation which was missing in India since long but actively prevalent in other big nations. 
                    They began with the process without any technical knowledge of software but have proved successful today with the state-of-art technology for direct and indirect taxes. 
                    E-Chartered Accountants was found in 2010 and now it is ready to be exploited to the best.
                    It is an authorized Government Intermediary and a company which will provide solutions to both companies and its employees. 
                    The cornerstones of E-Chartered Accountants include giving the best client experience and a commitment to serving clients how and where it is most convenient for them.
                    Our Tax Experts provide personal advisory services to each client, with the goal to give the most accurate advice and to prepare tax requirements with detailed knowledge.
                    Our Tax Experts strives to blend tax expertise with a strong focus on continually improving the client experience to provide all its clients with an unparalleled value proposition.
                </p>
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" Runat="Server">
    
                                 <div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200;">
                                    About Us
                                 </div>
                                <div class="medium-12  columns ">
                                   <p style="text-align:justify;font-family:Calibri;">
                                         E-Chartered Accountants is teamwork of many heads involved, who are chartered accountants, tax experts and accountants.
                                         The C.A professionals have been working in this field from past 30 years. 
                                         They have been serving clients for all kinds of direct and indirect taxation, tax related services, taxation queries and much more.
                                          The Team of our C.As felt the need of technology in the field of taxation which was missing in India since long but actively prevalent in other big nations.
                                          They began with the process without any technical knowledge of software but have proved successful today with the state-of-art technology for direct and indirect taxes.
                                          E-Chartered Accountants was found in 2010 and now it is ready to be exploited to the best. 
                                          It is an authorized Government Intermediary and a company which will provide solutions to both companies and its employees. 
                                          The cornerstones of E-Chartered Accountants include giving the best client experience and a commitment to serving clients how and where it is most convenient for them.
                                          Our Tax Experts provide personal advisory services to each client, with the goal to give the most accurate advice and to prepare tax requirements with detailed knowledge. 
                                          Our Tax Experts strives to blend tax expertise with a strong focus on continually improving the client experience to provide all its clients with an unparalleled value proposition.
                                   </p>
                                </div>                                            
                            
</asp:Content>

