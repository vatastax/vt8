<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html >

<html class="no-js" lang="en">
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
<head runat="server">
    <title></title>
    <link href="foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
     <script src="sliderengine/jquery.js" type="text/javascript"></script>
      <script src="sliderengine/amazingslider.js" type="text/javascript"></script>
    <link href="sliderengine/amazingslider-1.css" rel="stylesheet" type="text/css" />
   
    <script src="sliderengine/initslider-1.js" type="text/javascript"></script>
   
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <div class="row">
    <div class="large-4 columns">
        <img src="images/download.png" />
    </div>
    <div class="large-8 columns">
    </div>
    </div>
    <br />
     <!-- Navigation -->
     <div class="row">
     <div class="large-12 columns">
     <nav class="top-bar" data-topbar>
          <ul class="title-area">
            <!-- Title Area -->
            <li class="name">
              <h1>
                <a href="#">
              
                </a>
              </h1>
            </li>
            <li class="toggle-topbar menu-icon"><a href="#"><span>menu</span></a></li>
          </ul>
       
          <section class="top-bar-section">
            <!-- Right Nav Section -->
            <ul class="left">
              <li class="divider"></li>
              <li class="has-dropdown">
                <a href="#">Personal</a>
                <ul class="dropdown">
                  <li><label>Section Name</label></li>
                  <li class="has-dropdown">
                    <a href="#" class="">Has Dropdown, Level 1</a>
                    <ul class="dropdown">
                      <li><a href="#">Dropdown Options</a></li>
                      <li><a href="#">Dropdown Options</a></li>
                      <li><a href="#">Level 2</a></li>
                      <li><a href="#">Subdropdown Option</a></li>
                      <li><a href="#">Subdropdown Option</a></li>
                      <li><a href="#">Subdropdown Option</a></li>
                    </ul>
                  </li>
                  <li><a href="#">Dropdown Option</a></li>
                  <li><a href="#">Dropdown Option</a></li>
                  <li class="divider"></li>
                  <li><label>Section Name</label></li>
                  <li><a href="#">Dropdown Option</a></li>
                  <li><a href="#">Dropdown Option</a></li>
                  <li><a href="#">Dropdown Option</a></li>
                  <li class="divider"></li>
                  <li><a href="#">See all →</a></li>
                </ul>
              </li>
              <li class="divider"></li>
                <li class="has-dropdown">
                <a href="#">Corporate</a>
                <ul class="dropdown">
                  <li><a href="#">Dropdown Option</a></li>
                  <li><a href="#">Dropdown Option</a></li>
                  <li><a href="#">Dropdown Option</a></li>
                  <li class="divider"></li>
                  <li><a href="#">See all →</a></li>
                </ul>
              </li>
                <li class="divider"></li>
              <li><a href="#">AboutUs</a></li>
              <li class="divider"></li>
              <li><a href="#">ContactUs</a> </li>
             <li class="divider"></li>
              <li class="divider"></li>
              <li><a href="#">Login</a> </li>
             <li class="divider"></li>
            </ul>
            <div class="right item">
          
       <input id="Text1" type="text" /><%--<img src="images/search.jpg" style="width:20px" />--%>  &nbsp;
            </div>
          </section>
        </nav>
     </div>
     </div>
        <br />
       
        <!-- End Top Bar -->
       
        <div class="row">
          <div class="large-12 columns">
       
          <!-- Content Slider -->
       
            <div class="row">
              <div class="large-12 hide-for-small">
       
               <%-- <div id="featured" data-orbit>--%>
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
                   <%-- <img src="http://placehold.it/1200x500&text=Slide Image 1" alt="slide image">--%>
                    <%--<img src="http://placehold.it/1200x500&text=Slide Image 2" alt="slide image">
                    <img src="http://placehold.it/1200x500&text=Slide Image 3" alt="slide image">--%>
                 <%-- </div>--%>
       
            </div>
     
       
          <!-- End Content Slider -->
       
          <!-- Mobile Header -->
       
            <div class="row">
              <div class="large-12 columns show-for-small">
       
                <img src="http://placehold.it/1200x700&text=Mobile Header">
       
              </div>
            </div><br>
       
          <!-- End Mobile Header -->
       
       
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
       
          <!-- End Content -->
       
       
          <!-- Footer -->
       
            <footer class="row">
              <div class="large-12 columns"><hr>
                  <div class="row">
       
                    <div class="large-6 columns">
                        <p>© Copyright no one at all. Go to town.</p>
                    </div>
       
                    <div class="large-6 small-12 columns">
                        <ul class="inline-list right">
                          <li><a href="#">Personal</a></li>
                          <li><a href="#">Corporate</a></li>
                          <li><a href="#">AboutUs</a></li>
                          <li><a href="#">ContactUs</a></li>
                          <li><a href="#">Login</a></li>
                        </ul>
                    </div>
       
                  </div>
              </div>
            </footer>
       
          <!-- End Footer -->
       
          </div>
        </div>
       
        <script>
            document.write('<script src=js/vendor/' +
        ('__proto__' in {} ? 'zepto' : 'jquery') +
        '.js><\/script>')
        </script>
        <script src="js/foundation.min.js"></script>
        <script>
            $(document).foundation();
        </script>
      <!-- End Footer -->
    
    </form>
</body>
</html>
