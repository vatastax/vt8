<%@ Page Title="" Language="C#" MasterPageFile="~/VatasMaster.master" AutoEventWireup="true" CodeFile="SiteMap.aspx.cs" Inherits="SiteMap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript">
     $(document).ready(function () {
         $('table').css('margin', '0px');
         $('table').css('padding', '0px');
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
<link href="StaticStylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH1" Runat="Server">
<div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200; ">
                  Site Map
</div>

   <%-- <div class="large-7 columns"  style="float:left;margin-bottom:20px;">
        <div class="row site1">
            <div class="large-6 columns ">
        
                    <a href="default.aspx" style="color:Gray; font-weight:bold;">Home</a>
        
            </div>
            <br />
            <div class="large-6 columns">
                 <span style=" font-weight:bold; color:gray">About Us</span>
            </div>
            <br />
            <div class="large-6 columns" style="margin-left:50px">
                <a href="AboutUs.aspx">e-Chartered Accountants</a>
            </div>
            <br/>
             <div class="large-6 columns">
                 <span style=" font-weight:bold; color:gray">Services</span>
            </div>
            <br />
             <div class="large-6 columns" style="margin-left:50px">
                <a href="pageRedirect.aspx?prj=vt" style="color:gray">Income Tax Returns</a>
            </div>
            <br/>
                <div class="large-6 columns" style="margin-left:100px">
                     <a href="Presentation/E-FileYourself.aspx">
                         E-FileYourself.aspx</a>
                </div>
                <br />
                <div class="large-6 columns" style="margin-left:100px">
                     <a href="Presentation/E-FileCA.aspx">E-file with CA</a>
                </div>
                <br />
                <div class="large-6 columns" style="margin-left:100px">
                     <a href="presentation/login.aspx">Multiple filing for Tax Professionals</a>
                </div>
                 <br/>
             <div class="large-6 columns" style="margin-left:50px">
                <a href="pageRedirect.aspx?prj=tds">Tax Deducted at Source</a>
            </div>
            <br/>
             <div class="large-6 columns" style="margin-left:50px">
                <a href="Presentation/Gst.aspx">Goods & Service Tax</a>
            </div>
            <br/>
             <div class="large-6 columns" style="margin-left:50px">
               <a href="pageRedirect.aspx?prj=stax">Service Tax</a>
            </div>
            <br/>
             <div class="large-6 columns" style="margin-left:50px">
                <a href="cet.aspx">Central Excise Tax</a>
            </div>
            <br/>
             <div class="large-6 columns" style="margin-left:50px">
               <a href="nri.aspx">NRI Taxation</a>
            </div>
            <br/>
             <div class="large-6 columns" style="margin-left:50px">
                <a href="tp.aspx">Transfer Pricing</a>
            </div>
            <br/>
        </div>
    </div>
    <div class="large-5 columns" style="float:left">
      <div class="row site1">
        <div class="large-12 columns" >
             <a href="ContactUsNew.aspx" style="color:gray; font-weight:bold;">Contact Us</a>
        </div>
        <br />
        <div class="large-12 columns" >
             <a href="Terms_Conditions.aspx" style="color:gray; font-weight:bold;">Terms & Conditions</a>
        </div>
        <br />
        <div class="large-12 columns" >
             <a href="PrivacyPolicy.aspx" style="color:gray; font-weight:bold;">Privacy & Policy</a>
        </div>
        <br />
        <div class="large-12 columns" >
             <a href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf" target="_blank" style="color:gray; font-weight:bold;">FAQs</a>
        </div>
        <br /><br />
     </div>

    </div>
--%>
<div class="large-12 columns">
    <asp:TreeView ID="TreeView1" runat="server"  NodeIndent="10" DataSourceID="SiteMapDataSource1">
    <HoverNodeStyle Font-Underline="True" ForeColor="#DD5555" />
    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px"
        NodeSpacing="0px" VerticalPadding="0px"></NodeStyle>
    <ParentNodeStyle Font-Bold="False" />
    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"
        ForeColor="#DD5555" />
</asp:TreeView>

    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH2" Runat="Server">

<div class="title" style="text-align:left;font-size:20px; font-weight:bold;font-family:Cambria;font-size:21px;font-weight:bold;color:#e42200; ">
                  Site Map
</div>
<div class="large-12 columns">
    <asp:TreeView ID="TreeView2" runat="server"  NodeIndent="10" DataSourceID="SiteMapDataSource2">
    <HoverNodeStyle Font-Underline="True" ForeColor="#DD5555" />
    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px"
        NodeSpacing="0px" VerticalPadding="0px"></NodeStyle>
    <ParentNodeStyle Font-Bold="False" />
    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"
        ForeColor="#DD5555" />

    </asp:TreeView>
      <asp:SiteMapDataSource ID="SiteMapDataSource2" runat="server" />
</div>
   <%-- <div class="medium-7 columns"  style="float:left;margin-bottom:20px;">
        <div class="row site1">
            <div class="medium-6 columns ">
        
                    <a href="default.aspx" style="color:Gray; font-weight:bold;">Home</a>
        
            </div>
            <br />
            <div class="medium-6 columns">
                 <span style=" font-weight:bold; color:gray">About Us</span>
            </div>
            <br />
            <div class="medium-6 columns" style="margin-left:50px">
                <a href="AboutUs.aspx">e-Chartered Accountants</a>
            </div>
            <br/>
             <div class="medium-6 columns">
                 <span style=" font-weight:bold; color:gray">Services</span>
            </div>
            <br />
             <div class="medium-6 columns" style="margin-left:50px">
                <a href="pageRedirect.aspx?prj=vt" style="color:gray">Income Tax Returns</a>
            </div>
            <br/>
                <div class="medium-6 columns" style="margin-left:100px">
                     <a href="Presentation/E-FileYourself.aspx">E-file Yourself</a>
                </div>
                <br />
                <div class="medium-6 columns" style="margin-left:100px">
                     <a href="Presentation/E-FileCA.aspx">E-file with CA</a>
                </div>
                <br />
                <div class="medium-6 columns" style="margin-left:100px">
                     <a href="presentation/login.aspx">Multiple filing for Tax Professionals</a>
                </div>
                 <br/>
             <div class="medium-6 columns" style="margin-left:50px">
                <a href="pageRedirect.aspx?prj=tds">Tax Deducted at Source</a>
            </div>
            <br/>
             <div class="medium-6 columns" style="margin-left:50px">
                <a href="Presentation/Gst.aspx">Value Added Tax</a>
            </div>
            <br/>
             <div class="medium-6 columns" style="margin-left:50px">
               <a href="pageRedirect.aspx?prj=stax">Service Tax</a>
            </div>
            <br/>
             <div class="medium-6 columns" style="margin-left:50px">
                <a href="cet.aspx">Central Excise Tax</a>
            </div>
            <br/>
             <div class="large-6 columns" style="margin-left:50px">
               <a href="nri.aspx">NRI Taxation</a>
            </div>
            <br/>
             <div class="medium-6 columns" style="margin-left:50px">
                <a href="tp.aspx">Transfer Pricing</a>
            </div>
            <br/>
        </div>
    </div>
    <div class="medium-5 columns" style="float:left">
      <div class="row site1">
        <div class="medium-12 columns" >
             <a href="ContactUsNew.aspx" style="color:gray; font-weight:bold;">Contact Us</a>
        </div>
        <br />
        <div class="medium-12 columns" >
             <a href="Terms_Conditions.aspx" style="color:gray; font-weight:bold;">Terms & Conditions</a>
        </div>
        <br />
        <div class="medium-12 columns" >
             <a href="PrivacyPolicy.aspx" style="color:gray; font-weight:bold;">Privacy & Policy</a>
        </div>
        <br />
        <div class="medium-12 columns" >
             <a href=""https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf" target="_blank"" style="color:gray; font-weight:bold;">FAQs</a>
        </div>
        <br /><br />
     </div>

    </div>--%>
</asp:Content>

