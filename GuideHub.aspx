<%@ Page Title="" Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true" CodeFile="GuideHub.aspx.cs" Inherits="GuideHub" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
   
    <div class="row">
    <div class="large-12 columns">
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </div>
    </div>

     <div class="row text-center hide-for-small-only"  >
     <div class="large-12 columns">
    <h5> <p style=" color:gray; font-weight:500; line-height:1.1; font-size:26px">Guide Hub help you how to operate our website</p></h5>
     </div>

     </div>
     <br />
            <div style="background-color:#30d8f0;">
    <!-- First Band (Slider) -->
   <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
  </ol>
 
  <!-- Wrapper for slides -->
  <div class="carousel-inner">
    <div class="item active">
     <div class="item">
     <div class="row" >
     <div class="well text-center">
   
         <img src="GuideHubimages/login.png" />
  
    
      
 
   
    
     </div>
     </div>
     </div>
      <div class="carousel-caption">
         <%-- <h3>Security</h3>--%>
      </div>
    </div>
    <div class="item">
       
     <div class="row">
     <div class="well text-center">
         <img src="GuideHubimages/main.png" />
     
     
   
     </div>
     </div>
    

     
    </div>
     <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
      </div>
    <div class="item">
       
     <div class="row">
     <div class="well text-center">
         <img src="GuideHubimages/edit%20assessee.png" />
  
   
     </div>
     </div>
    

     
    </div>
     <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
      </div>
      <div class="item">
          
     <div class="row">
     <div class="well text-center">
      
    
         <img src="GuideHubimages/select%20year%20and%20itr.png" />
       
     </div>
     </div>
    

     
    </div>
     <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
      </div>
    <div class="item">
     
     <div class="row">
     <div class="well text-center">
         <img src="GuideHubimages/select%20itr.png" />
        
     </div>
     </div>
 

      <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
      </div>
    </div>
    <div class="item">
     
     <div class="row">
     <div class="well text-center">
    <img src="GuideHubimages/salary.png" />
      </div>
     </div>
     </div>
 

     
   
     <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
      </div>
         <div class="item">
     
     <div class="row">
     <div class="well text-center">
         <img src="GuideHubimages/Select%20computation.png" />
     </div>
     </div>
 

     
    </div>
     <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
      </div>
  </div>
 
  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left"></span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right"></span>
  </a>
</div> <!-- Carousel -->
   
      </div>

</asp:Content>

