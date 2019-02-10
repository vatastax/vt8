<%@ Page Title="" Language="C#" MasterPageFile="../MasterPage2.master" AutoEventWireup="true" CodeFile="Home3.aspx.cs" Inherits="Home3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="Stylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="sliderengine/jquery.js" type="text/javascript"></script>
      <script src="sliderengine/amazingslider.js" type="text/javascript"></script>
    <link href="sliderengine/amazingslider-1.css" rel="stylesheet" type="text/css" />
    <link href="Stylesheet/buttonstyle.css" rel="stylesheet" type="text/css" />

    <script src="js/modernizr.custom.34978.js" type="text/javascript"></script>

    <script src="sliderengine/initslider-1.js" type="text/javascript"></script>
   <%-- <script type="text/javascript">
        $(function () {

            var $container = $('#buttons'),
					$articles = $container.children('div'),
					timeout;

            $articles.on('mouseenter', function (event) {

                var $article = $(this);
                clearTimeout(timeout);
                timeout = setTimeout(function () {

                    if ($article.hasClass('active')) return false;

                    $articles.not($article.removeClass('blur').addClass('active'))
								 .removeClass('active')
								 .addClass('blur');

                }, 65);

            });

            $container.on('mouseleave', function (event) {

                clearTimeout(timeout);
                $articles.removeClass('active blur');

            });

        });
		</script>	--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <br />
      <div class="row hide-for-small-only heading">
      <div class="large-12 columns text-center">
      <p class="lplh-58" style="text-align: center;">
<span style="color:#052A3C;"><span style="font-size: 36px;"><span style="font-family: open sans;"><strong> Welcome to the new age CA of India</strong></span></span></span>
</p>


      </div>
      </div>
    
        <div class="row text-center">
     <div class="large-12 columns">
 <h5>  <p style="color:Gray; font-size:larger ">We help people with in easy secure and fast deliverables for their tax trouble.</p></h5>  
     </div>
     </div>
     
        
    <!-- Call to Action Panel -->
   
     <div class="row">
              <div class="large-12 columns">
                <div class="row">
                  <!-- Shows -->
                  <div class="large-4 small-6 columns">
       
                    <h4>Quick Links</h4><hr>
       
                    <div class="row">
                      <div class="large-1 column">
                        <img src="http://placehold.it/50x50&text=[img]">
                      </div>
       
                      <div class="large-9 columns">
                        <h5><a href="#">About</a></h5>
                      
                      </div>
                    </div><hr>
       
                    <div class="hide-for-small">
                      <div class="row">
                        <div class="large-1 column">
                          <img src="http://placehold.it/50x50&text=[img]">
                        </div>
       
                        <div class="large-9 columns">
                          <h5 class="subheader"><a href="#">Guide Hub</a></h5>
                        </div>
                      </div><hr>
       
                      <div class="row">
                        <div class="large-1 column">
                          <img src="http://placehold.it/50x50&text=[img]">
                        </div>
       
                        <div class="large-9 columns">
                          <h5 class="subheader"><a href="#">Tax Tools</a></h5>
                        </div>
                      </div><hr>
       
                      <div class="row">
                        <div class="large-1 column">
                          <img src="http://placehold.it/50x50&text=[img]">
                        </div>
       
                        <div class="large-9 columns">
                          <h5 class="subheader"><a href="#">CA Support</a></h5>
                        </div>
                      </div>
                    </div>
                  </div>
                  <!-- End Shows -->
       
       
                  <!-- Image -->
       
                  <div class="large-4 small-6 columns">
                    <img src="images/tax.jpg" style="height:400px">
                  </div>
       
                  <!-- End Image -->
       
       
                  <!-- Feed -->
       
                  <div class="large-4 small-12 columns">
       
                    <h4>Blog</h4><hr>
                    <div class="panel">
                      <h5><a href="#">Post Title 1</a></h5>
       
                      <h6 class="subheader">
                        Risus ligula, aliquam nec fermentum vitae, sollicitudin eget urna. Suspendisse ultrices ornare tempor...
                      </h6>
       
                      <h6><a href="#">Read More »</a></h6>
                    </div>
       
                    <div class="panel hide-for-small">
                      <h5><a href="#">Post Title 2 »</a></h5>
                    </div>
       
                    <div class="panel hide-for-small">
                      <h5><a href="#">Post Title 3 »</a></h5>
                    </div>
       
                    <a href="#" class="right">Go To Blog »</a>
       
                  </div>
       
                  <!-- End Feed -->
       
                </div>
              </div>
            </div>
     
    <!-- End Header and Nav -->
     <!-- Three-up Content Blocks -->
      <div class="row">
        <div class="large-12 columns">
           
          <ul class="ul1">
  <li class="li1"><a href="#" class="round blue">ITR<span class="round">Income Tax Return.</span></a></li>
  <li class="li1"><a href="#" class="round red">VAT<span class="round">Value added Tax </span></a></li>
	<li class="li1"><a href="#" class="round yellow">TDS<span class="round">Tax Deductive Source</span></a></li>
   
  <li class="li1"><a href="#" class="round green">S.TAX<span class="round">ServiceTAX</span></a></li>
	<li class="li1"><a href="#" class="round gray">TDS<span class="round">Tax Deductive Source</span></a></li>
    <li class="li1"><a href="#" class="round red">TDS<span class="round">Tax Deductive Source</span></a></li>
     <li class="li1"><a href="#" class="round black">NRI<span class="round">NRI</span></a></li>
</ul> 

 </div>
       </div> 
       
      
       
     <br />
     <br />
    
      <br />
      <br />
  
          
      <!-- Footer -->
       <div style="background-color:#58ACFA;">
     <div class="row text-center" >
     <div class="large-12 columns">
    <h5> <p style=" color:white; font-size:larger">  E-Chartered Account is the only one stop portal will tax compliance solution for you</p></h5>
     </div>
     </div>
    <!-- First Band (Slider) -->
   
      <div class="row" >
        <div class="large-12 columns">
       <%-- <div id="slider">--%>
                 <div id="amazingslider-wrapper-1" style="display:block;position:relative;max-width:900px;margin:0px auto 56px;">
        <div id="amazingslider-1" style="display:block;position:relative;margin:0 auto;" >
            <ul class="amazingslider-slides" >
                <li><img src="images/how may i help u.bmp" alt="Classic" /></li>
                <li><img src="images/for tax professionals.png" alt="Content" /></li>
                <li><img src="images/lets u do it urself.bmp" alt="ContentBox" /></li>
                <li><img src="images/go green.bmp" alt="Cube" />
                </li>
                <li><img src="images/treasury.bmp" alt="Elegant" />
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
      </div>
      
     
</asp:Content>

