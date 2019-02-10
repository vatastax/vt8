<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pricings.aspx.cs" Inherits="Pricings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
      li.pricing-table
    {
        padding:8px;
    }
    /* ---------- Recommended Plan Styles ---------- */
div.recommended  td.recommended {
	background: #3a3c3f;
	color: #b4bac4;
}

	div.recommended  {
		background: #3f3250 url("img/recommendationBadge.png") top left no-repeat;
		margin-top: -10px;
		padding-top: 20px;
	}
	
	

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<div class="row">
    <div class="large-3 columns" style="margin:0px; padding:0px">
      <ul class="pricing-table left-side">
        <li class="title" style="background-color:#494e6b">Lite</li>
        <li class="price" style="font-family:geogria">Free</li>
       <%-- <li class="description"></li>--%>
          <li class="bullet-item"><i class="foundicon-graph"></i>Salary</li>
        <li class="bullet-item"><i class="foundicon-graph"></i>House Property</li>
        <li class="bullet-item"><i class="foundicon-cloud"></i> Business income (Presumptive)</li>
         <li class="bullet-item"><i class="foundicon-phone"></i>Other Sources</li>
        <li class="bullet-item" style="color:White"><i class="foundicon-address-book"></i> (Presumptive)</li>
         <li class="bullet-item" style="color:White"><i class="foundicon-address-book"></i> (Presumptive)</li>
           <li class="bullet-item" style="color:White"><i class="foundicon-address-book"></i> (Presumptive)</li>
             <li class="bullet-item" style="color:White"><i class="foundicon-address-book"></i> (Presumptive)</li>
       
        <li class="cta-button"><a class="button  radius" href="presentation/login.aspx?Value=Signup">Enroll Now</a></li>
     
      </ul>
    </div>
    <div class="large-3 columns " style="margin:0px;padding:0px">
      <ul class="pricing-table">
        <li class="title" style="background-color:#494e6b">Standard</li>
        <li class="price">
            <img src="images/rupee-symbol.png" />&nbsp;149/-</li>
    <%--    <li class="description"></li>--%>
         <li class="bullet-item"><i class="foundicon-graph"></i>Salary</li>
        <li class="bullet-item"><i class="foundicon-graph"></i>House Property</li>
      
        <li class="bullet-item"><i class="foundicon-address-book"></i>Business Income (presumptive) </li>
      
        <li class="bullet-item"><i class="foundicon-website"></i>Other Sources</li>
           <li class="bullet-item" style="color:White"><i class="foundicon-website"></i>30 minute talk with CA</li>
        <li class="bullet-item" style="color:#e14658; font-weight:bold; font-size:17px"><i class="foundicon-website" ></i>PLUS</li>
         <li class="bullet-item"><i class="foundicon-website"></i>ITR reviewed by CA</li>
         
             <li class="bullet-item" style="color:White"><i class="foundicon-cloud"></i>Capital Gains</li>
          <li class="cta-button "><a class="button radius" href="Presentation/E-FileCA.aspx">Enroll Now</a></li>
      </ul>
    </div>
    <div class="large-3 columns recommended" >
      <ul class="pricing-table right-side">
        <li class="title" style="background-color:#494e6b">Professional</li>
        <li class="price">  <img src="images/rupee-symbol.png" />&nbsp;399/-</li>
     <%--   <li class="description"></li>--%>
           <li class="bullet-item"><i class="foundicon-graph"></i>Salary (Multiple Employer)</li>
        <li class="bullet-item"><i class="foundicon-graph"></i>House Property (Multiple )</li>
        <li class="bullet-item"><i class="foundicon-cloud"></i>Business Income </li>
        <li class="bullet-item"><i class="foundicon-address-book"></i>Capital Gains </li>
        <li class="bullet-item"><i class="foundicon-website"></i>Other Sources</li>
       <li class="bullet-item" style="color:#e14658; font-weight:bold; font-size:17px"><i class="foundicon-website" ></i>PLUS</li>
         <li class="bullet-item"><i class="foundicon-website"></i>ITR prepared by CA</li>
       <li class="bullet-item" style="color:White"><i class="foundicon-website"></i>30 minute talk with CA</li>
           
          <li class="cta-button "><a class="button radius" href="Presentation/E-FileCA.aspx">Enroll Now</a></li>
      </ul>
    </div>
    <div class="large-3 columns" style="margin:0px;padding:0px">
       <ul class="pricing-table right-side">
        <li class="title" style="background-color:#494e6b">Professional Plus</li>
        <li class="price">  <img src="images/rupee-symbol.png" />&nbsp;599/-</li>
    <%--    <li class="description"></li>--%>
           <li class="bullet-item"><i class="foundicon-graph"></i>Salary (Multiple Employer)</li>
        <li class="bullet-item"><i class="foundicon-graph"></i>House Property (Multiple) </li>
        <li class="bullet-item"><i class="foundicon-cloud"></i>Business Income</li>
        <li class="bullet-item"><i class="foundicon-address-book"></i>Capital Gains</li>
        <li class="bullet-item"><i class="foundicon-website"></i> Other Sources</li>
         <li class="bullet-item" style="color:#e14658; font-weight:bold; font-size:17px"><i class="foundicon-website"></i>PLUS</li>
          <li class="bullet-item"><i class="foundicon-website"></i>ITR prepared by CA </li>
           <li class="bullet-item"><i class="foundicon-website"></i>30 minute talk with CA</li>
        <li class="cta-button"><a class="button radius" href="Presentation/E-FileCA.aspx">Enroll Now</a></li>
      </ul>
    </div>
  </div>
</asp:Content>

