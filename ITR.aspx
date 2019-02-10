<%@ Page Title="" Language="C#" MasterPageFile="../MasterPage.master" AutoEventWireup="true" CodeFile="ITR.aspx.cs" Inherits="ITR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Stylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />
     <script src="sliderengine/jquery.js" type="text/javascript"></script>
      <script src="sliderengine/amazingslider.js" type="text/javascript"></script>
    <link href="sliderengine/amazingslider-1.css" rel="stylesheet" type="text/css" />
     <script src="js/modernizr.custom.34978.js" type="text/javascript"></script>

    <script src="sliderengine/initslider-1.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
     
     
      <!-- First Band (Image) -->
     <br />
     <br />
      <div class="row hide-for-small-only heading">
      <div class="large-12 columns text-center">
      <p class="lplh-58" style="text-align: center;">
<span style="color:#052A3C;"><span style="font-size: 36px;"><span style="font-family: open sans;"><strong> Welcome to the Income Tax Return</strong></span></span></span>
</p>


      </div>
      </div>
      <br />
      <br />
      <div class="row text-center" id="buttons">
        <div class="large-6 columns">
      <a href="#" class="button2"><span>✓</span>Upload Form 16A</a>

         
        </div>
        <div class="large-6 columns">
            <a href="#" class="button2 red"><span>✓</span> New User </a>
        </div>
      </div>
      <!-- Second Band (Image Left with Text) -->
     <br />
     <br />
      <div class="row">
        <div class="large-12 columns">
         
        </div>
      
      </div>
     
      <div class="row" >
        <div class="large-12 columns">
       <%-- <div id="slider">--%>
                 <div id="amazingslider-wrapper-1" style="display:block;position:relative;max-width:900px;margin:0px auto 56px;">
        <div id="amazingslider-1" style="display:block;position:relative;margin:0 auto;" >
            <ul class="amazingslider-slides" >
                <li><img src="images/FORM 16.bmp" alt="Classic" /></li>
                <li><img src="images/ERI.bmp" alt="Content" /></li>
                <li><img src="images/MAX REFUND.bmp" alt="ContentBox" /></li>
                <li><img src="images/go green.bmp" alt="Cube" />
                </li>
                <li><img src="images/NOTICE.bmp" alt="Elegant" />
                </li>
                 <li><img src="images/versatile eca.bmp" alt="Events" />
                </li>
               
                </ul>
                <ul class="amazingslider-thumbnails" style="display:none;">
                <li><img src="images/Classic-tn.png" alt="Classic" /></li>
                <li><img src="images/Content-tn.png" alt="Content" /></li>
                <li><img src="images/ContentBox-tn.png" alt="ContentBox" /></li>
                <li><img src="images/Cube-tn.png" alt="Cube" /></li>
                 <li><img src="images/Elegant-tn.png" alt="Elegant" /></li>
                <li><img src="images/Events-tn.png" alt="Events" /></li>
                <li><img src="images/FeatureList-tn.png" alt="FeatureList" /></li>
                 </ul>
 
           
      
    </div>

        <hr />
        </div>
      </div>
      </div>
     
      <!-- Third Band (Image Right with Text) -->
     
    
    
      <!-- Footer -->
     
      <footer class="row panel">
        <div class="large-12 columns ">
        VATAS TAX
          <hr />
          <div class="row">
            <div class="large-4 columns">
            About
             <ul>
             <li><a href="#"> Contact details</a></li>
             <li> <a href="#">E-Charated Accontants</a></li>
             <li> <a href="#">News</a></li>
             <li><a href="#">Blogs</a></li>
             <li><a href="#">FAQ's</a></li>
            
             </ul>
            </div>
            <div class="large-4 columns">
           <a href="Guidehub.aspx">Guide Hub</a> 
              <ul >
                <li><a href="#">Section 80 deduction</a></li>
                <li><a href="#">Guide for understanding form16</a></li>
                <li><a href="#">Guide to e-filing</a></li>
                <li><a href="#">Guide to TDS-e-filing</a></li>
              </ul>
            </div>
            <div class="large-4 columns">
             How-tos
              <ul >
                <li><a href="#">Check Income Tax Refund</a></li>
                <li><a href="#">Multiple Tax Refund</a></li>
                <li><a href="#">Multiple Return</a></li>
                <li><a href="#">Guide to TDS-e-filing</a></li>
              </ul>
            </div>
               <p style=" text-align:left">© Copyright to vatas infotech.</p>
          </div>
        </div>
      </footer>
    
</asp:Content>

