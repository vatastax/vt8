<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

  
  
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- BEGIN LivePerson Monitor. -->
<script type="text/javascript">    window.lpTag = window.lpTag || {}; if (typeof window.lpTag._tagCount === 'undefined') { window.lpTag = { site: '21832554' || '', section: lpTag.section || '', autoStart: lpTag.autoStart === false ? false : true, ovr: lpTag.ovr || {}, _v: '1.5.1', _tagCount: 1, protocol: location.protocol, events: { bind: function (app, ev, fn) { lpTag.defer(function () { lpTag.events.bind(app, ev, fn); }, 0); }, trigger: function (app, ev, json) { lpTag.defer(function () { lpTag.events.trigger(app, ev, json); }, 1); } }, defer: function (fn, fnType) { if (fnType == 0) { this._defB = this._defB || []; this._defB.push(fn); } else if (fnType == 1) { this._defT = this._defT || []; this._defT.push(fn); } else { this._defL = this._defL || []; this._defL.push(fn); } }, load: function (src, chr, id) { var t = this; setTimeout(function () { t._load(src, chr, id); }, 0); }, _load: function (src, chr, id) { var url = src; if (!src) { url = this.protocol + '//' + ((this.ovr && this.ovr.domain) ? this.ovr.domain : 'lptag.liveperson.net') + '/tag/tag.js?site=' + this.site; } var s = document.createElement('script'); s.setAttribute('charset', chr ? chr : 'UTF-8'); if (id) { s.setAttribute('id', id); } s.setAttribute('src', url); document.getElementsByTagName('head').item(0).appendChild(s); }, init: function () { this._timing = this._timing || {}; this._timing.start = (new Date()).getTime(); var that = this; if (window.attachEvent) { window.attachEvent('onload', function () { that._domReady('domReady'); }); } else { window.addEventListener('DOMContentLoaded', function () { that._domReady('contReady'); }, false); window.addEventListener('load', function () { that._domReady('domReady'); }, false); } if (typeof (window._lptStop) == 'undefined') { this.load(); } }, start: function () { this.autoStart = true; }, _domReady: function (n) { if (!this.isDom) { this.isDom = true; this.events.trigger('LPT', 'DOM_READY', { t: n }); } this._timing[n] = (new Date()).getTime(); }, vars: lpTag.vars || [], dbs: lpTag.dbs || [], ctn: lpTag.ctn || [], sdes: lpTag.sdes || [], ev: lpTag.ev || [] }; lpTag.init(); } else { window.lpTag._tagCount += 1; } </script>
<!-- END LivePerson Monitor. -->
    <br />
  <div class="row heading">
      <div class="large-12 columns text-center">
      <p class="lplh-58" style="text-align: center;">
<span style="color:#3b3738;"><span style="font-size: 34px;"><span style="font-family:Calibri; font-weight:500; line-height:1.1; letter-spacing:-2"> Welcome to the <b style=" font-family:Segoe Print">new</b> age <b style=" font-family:Segoe Print">CA</b> of India</span></span></span>
</p>


      </div>
      </div>

 <%--<div class="row">
        <div class="large-12 columns">
           
          <ul class="ul1">
  <li class="li1"><a href="itr1.aspx" class="round darkblue">ITR<span class="round">Income Tax Return.</span></a></li>
  <li class="li1"><a href="tds.aspx" class="round lightblue2">TDS<span class="round">Tax Deductive Source</span></a></li>
	<li class="li1"><a href="vat.aspx" class="round darkpurple">VAT<span class="round">Value added Tax </span></a></li>
   
  <li class="li1"><a href="servicetax.aspx" class="round lightpurple">S.TAX<span class="round">ServiceTAX</span></a></li>
	<li class="li1"><a href="cet.aspx" class="round darkyellow">CET<span class="round">Central Excise Tax</span></a></li>
    <li class="li1"><a href="nri.aspx" class="round lightbrown">NRI<span class="round">NRI Taxation</span></a></li>
     <li class="li1"><a href="tp.aspx" class="round green3">TP<span class="round">TP</span></a></li>
</ul> 

 </div>

       </div> --%>
      <%--  <div class="row">
        <div class="large-12 columns">
           
          <ul class="ul1">
  <li class="li1"><a href="itr1.aspx" class="round darkblue">ITR<span class="round">Income Tax Return.</span></a></li>
  <li class="li1"><a href="tds.aspx" class="round lightblue2">TDS<span class="round">Tax Deductive Source</span></a></li>
	<li class="li1"><a href="vat.aspx" class="round darkpurple">VAT<span class="round">Value added Tax </span></a></li>
   
  <li class="li1"><a href="servicetax.aspx" class="round lightpurple">S.TAX<span class="round">ServiceTAX</span></a></li>
	<li class="li1"><a href="cet.aspx" class="round darkyellow">CET<span class="round">Central Excise Tax</span></a></li>
    <li class="li1"><a href="nri.aspx" class="round lightbrown">NRI<span class="round">NRI Taxation</span></a></li>
     <li class="li1"><a href="tp.aspx" class="round green3">TP<span class="round">TP</span></a></li>
</ul> 

 </div>

       </div> --%>
      
        <div class="row" >
        <div class="large-12 columns" id="options"> 
           
          <ul class="ul1">
  <li class="li1"><a href="pageRedirect.aspx?prj=vt" class="round red"  style="background-color:#e42200;font-family: sans-serif;font-weight:300;">ITR<span class="round">Income Tax Return</span></a></li>
  <li class="li1"><a href="pageRedirect.aspx?prj=tds" class="round blue " style="font-family: sans-serif;font-weight:300;" >TDS<span class="round">Tax Deducted At Source</span></a></li>
	<li class="li1"><a href="Presentation/gst.aspx" class="round yellow" style="font-family: sans-serif;font-weight:300;">GST<span class="round">Goods & Service Tax</span></a></li>
   
  <li class="li1"><a href="pageRedirect.aspx?prj=stax" class="round green" style="font-family: sans-serif;font-weight:300;">S.TAX<span class="round">Service Tax</span></a></li>
	<li class="li1"><a href="cet.aspx" class="round orange" style="font-family: sans-serif;font-weight:300;">CE<span class="round">Central Excise</span></a></li>
    <li class="li1"><a href="nri.aspx" class="round yellow1" style="font-family: sans-serif;font-weight:300;">NRI<span class="round">NRI Taxation</span></a></li>
     <li class="li1"><a href="tp.aspx" class="round pink" style="font-family: sans-serif;font-weight:300;">TP<span class="round">Transfer Pricing</span></a></li>
</ul> 

 </div>
 
       </div> 
  

       <div style="background-color:#E1D4C0">
    <%-- <div class="row text-center" >
     <div class="large-12 columns">
    <h5> <p style=" color:white; font-size:larger">  E-Chartered Account is the only one 
         stop portal with tax compliance solutions for you</p></h5>
     </div>
     </div>--%>
    <!-- First Band (Slider) -->
   <div id="carousel-example-generic" class="carousel slide hide-for-small-only" data-ride="carousel"  >
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
  </ol>
 
  <!-- Wrapper for slides -->
  <div class="carousel-inner" >
    <div class="item active" >
     <div class="item" style="border:0px">
     <div class="row" style="border:0px; width:750px" >
     <div class="well text-center">
   <%--  <div class="row">
     <div class="large-5 columns text-right">  <p class="sliderhaeding" >Your Document Locker </p> 
    
      <p class="slidersubhead" style="text-align:justify; margin-left:105px;" >We keep your tax documents <br />  completely safe and secure with us.</p></div>
     <div class="large-7 columns text-center" >
     <img src="slider%20pics/document%20safe.jpg" style="height:200px" />
     </div>
     </div>--%>
    
 <%-- <table align="center" style="border:0px">
  
  <tr>
  
  <td>
  <p class="sliderhaeding" >Your Document LOCKER </p>
   <p class="slidersubhead" style="text-align:justify; " >We keep your tax documents <br />  completely safe and secure with us.</p>
  </td>
  <td>  <img src="slider%20pics/document%20safe.jpg" style="height:200px" /></td>
  </tr>
  </table>--%>
   
         <img src="slider%20pics/image1.JPG" />
      
 
   
    
     </div>
     </div>
     </div>
      <div class="carousel-caption">
         <%-- <h3>Security</h3>--%>
      </div>
    </div>
    <div class="item">
       
     <div class="row" style="border:0px;">
     <div class="well text-center" style="border:0px">

    <%-- <div class="row">
     <div class="large-7 columns text-right">   <p class="sliderhaeding" style="margin-left:70px"  >We do help our Tax Professionals</p>
    
     
         <p class="slidersubhead" style="margin-left:100px; text-align:justify; margin-left:150px" >We assist tax professional and CAs<br /> serve their clients with our help.</p>
      </div>
     <div class="large-5 columns text-center" >
          <img src="images/assist1.PNG" />
     </div>
     </div>--%>
    <%--  <table align="center" style="border:0px">
  
  <tr>
  
  <td>
  <p class="sliderhaeding" >We do HELP Tax Professionals</p>
   <p class="slidersubhead" style="text-align:justify; " >We assist tax professional and CAs<br /> serve their clients with our help.</p>
  </td>
  <td>    <img src="images/assist1.PNG" /></td>
  </tr>
  </table>--%>
         <img src="slider%20pics/image2.JPG" />

     </div>
     </div>
    

     
    </div>
     <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
      </div>
    <div class="item">
       
     <div class="row" style="border:0px; width:750px">
     <div class="well text-center" style="border:0px">
    <%--  <div class="row">
     <div class="large-5 columns text-right"> 
        <p class="sliderhaeding" > 
     Go green, think green</p>
   <p class="slidersubhead" style="text-align:justify; margin-left:110px"  >Let's start e-tax procedures<br /> instead of paper procedures</p>
   </div>
     <div class="large-7 columns text-center" >
        <img src="images/Think_20green_20logo_20copy%20copy.jpg" />
      </div>
     </div>--%>
     <%-- <table align="center" style="border:0px">
  
  <tr>
  
  <td>
  <p class="sliderhaeding" > GO GREEN, think green</p>
   <p class="slidersubhead" style="text-align:justify; " >Let's start e-tax procedures<br /> instead of paper procedures.</p>
  </td>
  <td>        <img src="images/Think_20green_20logo_20copy%20copy.jpg" /></td>
  </tr>
  </table>--%>
         <img src="slider%20pics/image3.JPG" />
     </div>
    </div>

     
    </div>
     <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
      </div>
      <div class="item">
          
     <div class="row" style="border:0px; width:750px">
     <div class="well text-center" style="border:0px">
    <%-- <div class="row">
     <div class="large-6 columns text-right"> 
        <p class="sliderhaeding">  
    
     LET'S YOU DO IT on your own</p>
     <p class="slidersubhead" style="text-align:justify; margin-left:100px" >Our interface is easy and informative,<br />which let's you do it yourself.</p>
     </div>
     <div class="large-1 columns"></div>
       <div class="large-5 columns text-center" >
           <img src="images/interface.png" />
      </div>
     </div>--%>
   <%--   <table align="center" style="border:0px">
  
  <tr>
  
  <td>
  <p class="sliderhaeding" >LET'S YOU DO IT on your own</p>
   <p class="slidersubhead" style="text-align:justify; " >Our interface is easy and informative,<br />which let's you do it yourself.</p>
  </td>
  <td>      <img src="images/interface.png" /></td>
  </tr>
  </table>--%>
         <img src="slider%20pics/image4.JPG" />
     </div>
     </div>
    

     
    </div>
     <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
      </div>
    <div class="item">
     
     <div class="row" style="border:0px; width:750px">
     <div class="well text-center">
   <%--  <div class="row">
     <div class="large-7 columns text-right"> 
     <div class="row">
     <div class="large-7 columns"></div>
     <div class="large-5  columns text-center">
      <p class="sliderhaeding" > 
     How MAY I HELP YOU</p>
     </div>
       <%--<div class="large-4 columns"></div>--%>
    <%-- </div>
    
   <p class="slidersubhead" style="text-align:justify; margin-left:100px">Our team is readily available with CA support<br /> for any kind of tax procedure assistance.</p>
     </div>
        <div class="large-4 columns text-center" >
          <img src="images/hello.png" />
      </div>
      <div class="large-4 columns"></div>
      </div>--%>
    <%--  <table align="center" style="border:0px">
  
  <tr>
  
  <td>
  <p class="sliderhaeding" > How MAY I HELP YOU ?</p>
   <p class="slidersubhead" style="text-align:justify; " >Our team is readily available with</br> CA support for any kind of tax</br> procedure filing and assistance.</p>
  </td>
  <td>      <img src="images/hello.png" /></td>
  </tr>
  </table>--%>
         <img src="slider%20pics/image5.jpg" />
     </div>
     </div>
 

      <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
      </div>
    </div>
    <div class="item">
     
     <div class="row" style="border:0px; width:750px">
     <div class="well text-center" style="border:0px">
   <%--   <div class="row">
     <div class="large-7 columns text-right">
     <p class="sliderhaeding" style=" text-align:-50px" > 
     We are the Multipurpose E-CAs</p>
      <p class="slidersubhead" style="text-align:justify; margin-left:100px;"  >We provide solutions to many tax procedures <br />(ITR, TDS, Service Tax, VAT, etc.) under one roof.</p></div>
     <div class="large-5 columns">
         <img src="images/corrected.JPG" />
      </div>
      </div>--%>
     <%--  <table align="center" style="border:0px">
  
  <tr>
  
  <td>
  <p class="sliderhaeding" >   We are the Multipurpose E-CAs</p>
   <p class="slidersubhead" style="text-align:justify; " >We provide solutions to many tax </br>procedures (ITR, TDS, Service Tax, VAT,  </br>etc.) under  one roof.</p>
  </td>
  <td>      <img src="images/corrected.JPG" /></td>
  </tr>
  </table>--%>
         <img src="slider%20pics/image6.JPG" />
     </div>
     </div>
 

     
    </div>
     <div class="carousel-caption">
        <%--  <h3>Caption Text</h3>--%>
      </div>
      <%--   <div class="item">
     
     <div class="row" style="border:0px">
     <div class="well text-center" style="border:0px">
           <div class="row">
     <div class="large-7 columns ">
      <p class="sliderhaeding" style="margin-left:50px" > 
     At your assitance Mr. CA</p>
       <p class="slidersubhead" style="text-align:justify; margin-left:120px" >We assist tax professionals and CAs <br />serve their clients with our help.</p></div>
          <div  class="large-5 columns">
              <img src="images/assist1.PNG"  />
          </div>
          </div>
     </div>
     </div>
 

     
    </div>
     <div class="carousel-caption">
     
      </div>--%>
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
   
     
      <div style="background-color:#2B7CAD; color:White">
    <div class="row  text-center"> 
     <div class="large-12 columns">
 <h5>  <p style=" font-size:larger;color:white; padding:10px 10px 0px 10px; ">We <strong style="color:white">help</strong>  people with  <strong style="color:white"> simple, secure and speedy </strong>solutions for TAX problems.</p></h5>  
     </div>
     </div>
     </div>
        <br />
  
   <div class="row hidden-for-small-only" > 
          <div class="large-12 columns">
         
          <h2 class="title" style=" font-size:1.5em; font-family:Cambria;">Our <b style="color:#FF6600">Fees</b> Guide</h2>
          <div class="row">
          <div class="large-8 columns">   <p style="font-size: 18px; color:#4e4e4e; font-family:Calibri;text-align:justify; ">It is completely free, if you are paying your returns with us for the <b style="color:#FF6600">Ist</b> time
         through our portal. For other instances we will charge fee for our services. If any query click on price guide and your query will be answered at earliest.</p></div>
          <div  class="large-4 columns text-right" >  <a href="PriceGuide.aspx" class="button2 orange1" style="height:60px; width:220px; ">Price Guide </a></div>
          </div>
        
        
          </div>
          <hr />
          </div>
         
           <div class="row hidden-for-small-only" >
             
          <div class="large-12 columns">
          <h2 class="title" style=" font-size:1.5em; font-family:Cambria;">We Provide many <b style="color:#FF6600">TAX</b> reliefs under <b style="color:#FF6600">ONE</b> roof</h2>
          <div class="row">
          <div class="large-8 columns"><p style="font-size: 18px;color:#4e4e4e;font-family:Calibri;text-align:justify;">We understand, there are many taxes bothering you. For your convenience we have made ourselves versatile in our services&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          </p></div>
          <div class="large-4 columns text-right">  <a href="Services.aspx" class="button2 orange1" style="height:60px; width:220px;  ">our services</a></div>
          
          </div>
         
       <br />
         </div>
        <hr />
          </div>
    <div class="row hidden-for-small hidden-for-medium">
        <div class="large-12 columns">
            <h2 class="title" style="font-size: 1.5em; font-family: Cambria;">
                Say Bye to TAX <b style="color: #FF6600">PHOBIA</b></h2>
            <div class="row">
                <div class="large-8 columns">
                    <p style="font-size: 18px; color: #4e4e4e; font-family: Calibri; text-align: justify;">
                        Our Tax experts are there for your tax phobias. You wont have to worry, we are there
                        to help you. You can talk to our tax experts right away.</p>
                </div>
                <div class="large-4 columns text-right" style="margin-right: -90px;">
                    <section> <div id="expert_chat_big"></div></section>
                </div>
            </div>
        </div>
    </div>

    <div class="row show-for-medium-only">
            <div class="medium-12 columns">
                <h2 class="title" style="font-size: 1.5em; font-family: Cambria;">
                    Say Bye to TAX <b style="color: #FF6600">PHOBIA</b></h2>
                <div class="row">
                    <div class="medium-8 columns">
                        <p style="font-size: 18px; color: #4e4e4e; font-family: Calibri; text-align: justify;">
                            Our Tax experts are there for your tax phobias. You wont have to worry, we are there
                            to help you. You can talk to our tax experts right away.</p>
                    </div>
                    <div class="medium-4 columns text-right" style="margin-right: 10px;">
                        <section> <div id="LP_DIV_1436508147827"></div></section>
                    </div>
                </div>
            </div>
        </div>
     
   
            <div class="row show-for-small-only" >
          <div class="large-12 columns">
         
          <h2 class="title" style=" font-size:1.5em; font-family:Cambria;">Our <b style="color:#FF6600">Fees</b> Guide</h2>
          <div class="row">
          
          <div  class="large-12 columns text-right" >  <a href="PriceGuide.aspx" class="button2 orange1" style="height:60px; width:220px; ">Price Guide </a></div>
          </div>
        
        
          </div>
          <hr />
          </div>
          <br />
           <div class="row show-for-small-only" >
             
          <div class="large-12 columns">
          <h2 class="title" style=" font-size:1.5em; font-family:Cambria;"> under <b style="color:#FF9900">ONE</b> roof</h2>
          <div class="row">
          
          <div class="large-12 columns text-right">  <a href="Services.aspx" class="button2 orange1" style="height:60px; width:220px;  ">our services</a></div>
          </div>
         
       
         </div>
        <hr />
          </div>
          <br />
         
         <div class="row show-for-small-only" >
             
          <div class="large-12 columns">
          <h2 class="title" style=" font-size:1.5em; font-family:Cambria;">Say Bye to TAX <b style="color:#FF6600">PHOBIA</b></h2>
          <div class="row">
        
          <div class="large-12 columns" style="margin-left:88px"> <div id="LP_DIV_1436431116059"></div></div>
          </div>
         
       
         </div>
       
          </div>
     
       
            <div class="row">
          <div class="large-12 columns">
          <h1></h1>
          <p></p>
          </div>
          </div>
      <!-- Footer -->
    <div style="background-color:#ff6600;">
     <div class="row  text-center" >
     <div class="large-12 columns">
    <h5> <p style=" font-size:larger;color:white; padding:10px 10px 0px 10px;">  E-Chartered Accountants.com is the only one stop portal with tax compliance solutions for you.</p></h5>
     </div>
     </div>
     </div>
      <%-- <div class="large-12 columns" style=" background-image:url(images/patteren.JPG); background-repeat: repeat-x; ">
         &nbsp;
        </div>--%>
      
        <%-- <div class="large-12 columns" style=" background-image:url(images/p3.JPG); background-repeat: repeat-x;" >
                  &nbsp;
        </div>--%>
   <div style="background-color:#2B7CAD; padding-left:10px">
       
      <%--<footer class="row">--%>
   <div class="row" >
   </br></br>
    <%--<div class="large-10 columns">
        <div class="row">
   
       <div class="large-8 columns footer-links">
       <h4 style=" color:#ffffff;  font-family:Cambria; padding-left:10px">About</h4>
        <ul style=" list-style-type:disc; color:#ff6600; font-family:Calibri; padding-left:15px" >
                
               
                    <li><a href="AboutUs.aspx"  style="color:White">E-Chartered Accountants.com</a></li>
                      <li ><a href="ContactUsNew.aspx"  style="color:White">Contact Details</a></li>
                 
                      <li ><a href="Terms_Conditions.aspx"  style="color:White">Terms & Condition</a></li>
                      <li ><a href="PrivacyPolicy.aspx"  style="color:White">Privacy & Policy</a></li>
                        <li ><a href="SiteMap.aspx" style="color:White">Site Map</a></li>
                         <li ><a href="News.aspx" style="color:White">Latest News</a></li>
                       <li ><a href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf" target="_blank"  style="color:White">FAQs</a></li>
                  </ul>
       </div>
            <div class="large-4 columns">
            <h4 style=" color:#ffffff;  font-family:Cambria; padding-left:10px">Have a doubt? Ask here.</h4>
            <div class="row">
            <div class="large-4 columns" style="color:White;font-family:Calibri;">
             Name
            </div>
            <div class="large-8 columns">
            <asp:TextBox ID="txtName" runat="server" Width="230" style="border-radius:3px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Rq1" runat="server" ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            </div>
            <br />
             <div class="row">
            <div class="large-4 columns" style="color:White;font-family:Calibri;">
           Email
            </div>
            <div class="large-8 columns">
            <asp:TextBox ID="txtEmail" runat="server" Width="230" style="border-radius:3px;"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
         
         
            </div>
            </div>
             <br />
             <div class="row">
            <div class="large-4 columns" style="color:White;font-family:Calibri;">
            Subject
            </div>
            <div class="large-8 columns">
            <asp:TextBox ID="txtSubject" runat="server" Width="230" style="border-radius:3px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            </div>
             <br />
             <div class="row" style="margin-top: 10px;">
            <div class="large-4 columns" style="color:White;font-family:Calibri;">
            Comment
            </div>
            <div class="large-7 columns"  style="margin-bottom:10px" >
            <asp:TextBox ID="txtComment" runat="server"  TextMode="MultiLine" style="border-radius:3px; height:75px; "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtComment" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
    
            <div class="large-1 columns"> </div>
            </div>
             <br />
      <div class="row" style="margin-top: 10px;">
            <div class="large-4 columns" style="color:White;font-family:Calibri;">
            Attachment
            </div>
            <div class="large-5 columns"  style="margin-bottom:10px" >
       <asp:FileUpload ID="FUpload1" runat="server" />
            </div>
    <div class="large-2 columns">
    
    </div>
            <div class="large-1 columns"> <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/submit1.PNG" OnClick="ImageButton2_Click" ></asp:ImageButton></div>
            </div>
            </div>
     
         </div>
     </div>--%>
   
        <div class="large-12 columns">
     
          <%--<hr />--%>
          <div class="row">
            <div class="large-3 columns">
              <p style="color:Silver">© 2015 Vatas Infotech Pvt.Ltd.</p>
            </div>
            <div class="large-9 columns text-right socbtn">
              
                <a href="https://www.facebook.com/echarteredaccountants" target="_blank"><img src="images/fb.png" /></a>
                <a href="http://www.twitter.com/ECAccountant" target="_blank"><img src="images/twitter.png" /></a>
                <a href="https://in.linkedin.com/pub/vatas-infotech/b9/264/a82" target="_blank"><img src="images/LINKEDIN1.PNG" /></a>
                <a href="https://plus.google.com/u/0/b/108616341946641442746/108616341946641442746" target="_blank" ><img src="images/google.png" /></a>
             <%-- <ul class="inline-list right">
                
                <li ><a href="home2.aspx" style="color:White">Home</a></li>
                <li><a href="about.aspx"  style="color:White">About us</a></li>
                  <li ><a href="contact.aspx"  style="color:White">Contact us</a></li>
                 
                  <li ><a href="#"  style="color:White">Terms&Condition</a></li>
                  <li ><a href="#"  style="color:White">Privacy&Policy</a></li>
                   <li ><a href="https://incometaxindiaefiling.gov.in/eFiling/Portal/Registration_FAQ.pdf"  style="color:White">FAQs</a></li>
              </ul>--%>
            </div>
          </div>
        </div> 
    <%--  </footer>--%>
      
        </div>
</div>
<%--div shows whatsnew link--%>
<%--<div id="WhatsNew" class="hide-for-small-only">
<a href="#">WhatsNew</a>
</div>--%>


<%--Latest News side Bar - Jaipal --%>

<div id="WhatsNew" style="display:none" >
<div class= "hidden-for-small-only">
<style type="text/css">

    #WhatsNew            
        {
        top:35%;
        left:0;
        position:fixed;
        opacity: 0.5;
        -webkit-transition:0.5s;
        }
    #WhatsNew:hover
    {
        opacity:1.0;
        -webkit-transition:1s;
    }
    
    #divNews
        {
        top:38%;
        left:40px;
        position:fixed;
        display:none;
        }
    </style>
</div>
<div class="show-for-small-only">
<style type="text/css">
    #WhatsNew            
        {
        top:34%;
        left:0;
        position:fixed;
        opacity: 0.5;
        }
    #WhatsNew:hover
    {
        opacity:1.0;
    }
    
    #divNews
        {
        top:38%;
        left:40px;
        position:fixed;
        display:none;
        }
    </style>
</div>
<img src="images/ltstnws.png" alt="Latest New" />
</div>

<div  id="divNews" style="width:200px;height:255px;-webkit-border-radius: 38px;-moz-border-radius: 38px;border-radius: 38px;background-color:#2B7CAD;-webkit-box-shadow: #B3B3B3 4px 4px 4px;-moz-box-shadow: #B3B3B3 4px 4px 4px; box-shadow: #B3B3B3 4px 4px 4px; padding-top:35px; padding-bottom:55px">
<label style="font-weight:bold; color:White; margin-left: 45px; margin-top: -25px; margin-bottom: 10px">New in Taxation</label>

<%--<div >--%>
    <%--<table style="border:0 ; margin-left:42px">
                    <tr>
                    <td bgcolor="#D5D6D4">
                        <asp:Label ID="lblNews" runat="server" Text="New in Taxation"></asp:Label>
                    </td>
                    </tr>
                    </table>--%>
<marquee onmouseout="this.start()" onmouseover="this.stop()"  scrollamount="5" scrolldelay="150"
 direction="up" truespeed="truespeed" loop="-1" width="203" height="175">

<asp:DataList ID="dlst" runat="server" >
    <ItemTemplate>
    <table style=" padding:10px ;margin:0;background-color:#2B7CAD; border-color:#2B7CAD;">
    <tr style="border:none">
   <%-- <td>
    <asp:Label ID="lblSNO" runat="server" ForeColor="White" Text='<%#Eval("SNo") %>'></asp:Label>
    </td>--%>
   <%-- <td>
       <asp:Label ID="Label1" runat="server" BorderColor="#2B7CAD" ForeColor="White" Text='<%#Eval("Service") %>'></asp:Label>
    </td>--%>
    <td>
       <asp:Label ID="Label2" runat="server" BorderColor="#2B7CAD" ForeColor="White" Text='<%#Eval("Date") %>'></asp:Label><span style="color:white">:</span>
          <asp:Label ID="Label3" runat="server" BorderColor="#2B7CAD" ForeColor="White" Text='<%#Eval("Description") %>'></asp:Label>
    </td>
  <%--  <td>
    
    </td>--%>
    </tr>
    </table>
    </ItemTemplate>
    </asp:DataList>
    </marquee>
<a href="#" style="color: #FF6600; font-weight:bold; margin-left:55px">Show More</a></div>
<%--</div>--%>

<div id="dialog" style="display: none">
</div>

<%--Latest News side Bar--%>
</asp:Content>