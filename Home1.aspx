<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home1.aspx.cs" Inherits="Home1" %>

<!DOCTYPE html >

<html class="no-js" lang="en">
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
<head runat="server">
    <title>Home</title>
    
    <script src="foundation-5.5.0/jquery.min.js" type="text/javascript"></script>
     <link href="foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
    <link href="Stylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="sliderengine/jquery.js" type="text/javascript"></script>
      <script src="sliderengine/amazingslider.js" type="text/javascript"></script>
    <link href="sliderengine/amazingslider-1.css" rel="stylesheet" type="text/css" />
   

    <script src="js/modernizr.custom.34978.js" type="text/javascript"></script>

    <script src="sliderengine/initslider-1.js" type="text/javascript"></script>
    	
   <%-- <script type="text/javascript">
        $(document).ready(function () {
            $('.btn').hover(function () {
                $(this).css("cursor", "pointer");
              
                $(this).animate({ height: "200px" }, 'slow');

            }, function () {
                $(this).animate({ width: "330px",height:"130px" }, 'slow');

            });
        });
</script>--%>
<%--  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>--%>
<script type="text/javascript">
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
		</script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="row">
        <div class="large-3 columns">
          <h1>
              <img src="images/download.png" /></h1>
        </div>
        <div class="large-9 columns">
          <ul class="right button-group">
         
          <li><a href="About.aspx" class="button">About Us</a></li>
          <li><a href="contact.aspx" class="button">Contact Us</a></li>
           <li><a href="#" class="button">Login</a></li>
          </ul>
         </div>
       </div>
      <br />
      <div class="row hide-for-small-only heading">
      <div class="large-12 columns">
    <p style="font-size:xx-large">All Under One Roof</p> 
      </div>
      </div>
    <!-- End Header and Nav -->
     <!-- Three-up Content Blocks -->
      <div class="row" id="buttons">
        <div class="large-4 columns">
           
          <a href="#" class="btn blue"> Income Tax Return </a></div>
          <div class="large-4 columns">
  <a href="#" class="btn green">  Tax Deductive Source  </a></div>
 <div class="large-4 columns"> <a href="#" class="btn purple">  Value Added Tax  </a></div>

 </div>
        
        <div class="row" id="buttons1">
        <div class="large-6 columns">
         
  <a href="#" class="btn orange">Orange Button</a></div>
<div class="large-6 columns"> <a href="#" class="btn yellow">Yellow Button</a>
        </div>
        </div>
    
      
        </div>
     <br />
    <!-- First Band (Slider) -->
     
      <div class="row">
        <div class="large-12 columns">
        <div id="slider">
                 <div id="amazingslider-wrapper-1" style="display:block;position:relative;max-width:900px;margin:0px auto 56px;">
        <div id="amazingslider-1" style="display:block;position:relative;margin:0 auto;" >
            <ul class="amazingslider-slides" >
                <li><img src="images/Classic.png" alt="Classic" /></li>
                <li><img src="images/Content.png" alt="Content" /></li>
                <li><img src="images/ContentBox.png" alt="ContentBox" /></li>
                <li><img src="images/Cube.png" alt="Cube" />
                </li>
                <li><img src="images/Elegant.png" alt="Elegant" />
                </li>
                 <li><img src="images/Events.png" alt="Events" />
                </li>
                 <li><img src="images/FeatureList.png" alt="FeatureList" />
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
 
           
        <div class="amazingslider-engine"><a href="http://amazingslider.com" title="Responsive jQuery Image Slideshow">Responsive jQuery Image Slideshow</a></div>
        </div>
    </div>
          
        </div>
        
        <hr />
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
                        <h6 class="subheader show-for-small">Doors at 00:00pm</h6>
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
                    <img src="http://placehold.it/300x465&text=Image">
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
             <div class="row">
        <div class="large-12 columns">
        
          <div class="panel">
            <h4>Get in touch!</h4>
                
            <div class="row">
              <div class="large-9 columns">
                <p>We'd love to hear from you, you attractive person you.</p>
              </div>
              <div class="large-3 columns">
                <a href="#" class="radius button right">Contact Us</a>
              </div>
            </div>
          </div>
          
        </div>
      </div>
      <!-- Footer -->
      
      <footer class="row">
        <div class="large-12 columns">
          <hr />
          <div class="row">
            <div class="large-6 columns">
              <p>© Copyright to vatas infotech.</p>
            </div>
            <div class="large-6 columns">
              <ul class="inline-list right">
                
                <li><a href="#">Home</a></li>
                <li><a href="#">Aboutus</a></li>
                  <li><a href="#">Contactus</a></li>
              </ul>
            </div>
          </div>
        </div> 
      </footer>
    
    </form>
</body>
</html>
