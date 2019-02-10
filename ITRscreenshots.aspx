<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ITRScreenshots.aspx.cs" Inherits="ITRScreenshots" %>

<!DOCTYPE html >
<html class="no-js" lang="en">
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<meta charset="utf-8" />
<head id="Head1" runat="server">
    <title></title>
    <%--<link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
    <%--<script src="js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>--%>
    <%--<script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
      <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>--%>
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <%--<link href="foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />--%>
    <script src="foundation-5.5.0/js/vendor/jquery.js" type="text/javascript"></script>
    <script src="foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
    <%--<script src="sliderengine/jquery.js" type="text/javascript"></script>--%>
    <%--<link href="StaticStylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="StaticStylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />--%>
    <%-- <script src="sliderengine/jquery.js" type="text/javascript"></script>
      <script src="sliderengine/amazingslider.js" type="text/javascript"></script>--%>
    <%--<link href="sliderengine/amazingslider-1.css" rel="stylesheet" type="text/css" />--%>
    <script src="js/modernizr.custom.34978.js" type="text/javascript"></script>
    <script src="js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>
    <%--<script src="sliderengine/initslider-1.js" type="text/javascript"></script>--%>
    <!--master style sheet-->
    <link href="style_folder/StaticStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
</head>
<body>
    <form id="form1" runat="server">
    <div class="row" style="margin-top: 10px">
        <div class="large-8 columns">
        </div>
        <div class="large-4 columns text-right">
        </div>
    </div>
    <br />
    <%------------------show logo and menu on mobile screen -----------------------%>
    <div class="row show-for-small-only ">
        <div class="large-3 columns">
            <img src="images/logo2.PNG" style="width: 240px" alt="logo" />
        </div>
        <div class="large-9 columns ">
            <div class="rmm" data-menu-style="minimal">
                <ul>
                    <li><a href="default.aspx" class="button">Go To</a></li>
                    <li><a href="itrscreenshots.aspx" class="button">Demo to e-filing</a></li>
                    <li><a href="Pricings.aspx" class="button">Price Guide</a></li>
                    <%--<li><a href="#" class="button">Rates and Tables</a></li>--%>
                    <li>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout1_Click"></asp:LinkButton></li>
                </ul>
            </div>
        </div>
    </div>
    <%------------------show logo and menu on medium and large screen ----------%>
    <div class="row hide-for-small-only" style="margin-top: -25px">
        <div class="large-4 columns">
            <a href="Default.aspx">
                <img src="images/logo2.PNG" style="width: 240px" alt="logo" /></a>
        </div>
        <div class="large-8 columns ">
            <ul class="right button-group">
                <li><a href="default.aspx" class="button">Go-To</a>
                    <ul style="background-color: gray; opacity: 0.7; border: 1px solid gray; border: 1px solid gray;
                        border-radius: 10px; padding: 0 10px">
                        <li style="padding-top: 4px;"><a href="../pageRedirect.aspx?prj=tds" style="color: white;">
                            <img src="images/bullet.png" alt="bullet" />&nbsp;&nbsp;&nbsp;Tax Deducted at Source</a> <a href="Presentation/Gst.aspx"
                                style="color: white;">
                                <img src="images/bullet.png" alt="bullet" />&nbsp;&nbsp;&nbsp;Goods & Service Tax</a></li>
                        <li style="padding-top: 2px;"><a href="../pageRedirect.aspx?prj=stax" style="color: white;">
                            <img src="images/bullet.png" alt="bullet" />&nbsp;&nbsp;&nbsp;Service Tax</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="cet.aspx" style="color: white;">
                                <img src="images/bullet.png" alt="bullet" />&nbsp;&nbsp;&nbsp;Central Excise Tax</a></li>
                        <li style="padding-top: 2px; padding-bottom: 2px;"><a href="nri.aspx" style="color: white;">
                            <img src="images/bullet.png" alt="bullet" />&nbsp;&nbsp;&nbsp;NRI Taxation</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a
                                href="tp.aspx" style="color: white;"><img src="images/bullet.png" alt="bullet" />&nbsp;&nbsp;&nbsp;Transfer
                                Pricing</a></li>
                    </ul>
                </li>
                <li><a href="itrscreenshots.aspx" class="button">Demo e-filing</a></li>
                <li><a href="Pricings.aspx" class="button">Price Guide</a></li>
                <%--<li><a href="#" class="button">Rates and Tables</a></li>--%>
                <li>
                    <asp:LinkButton ID="LinkButton2" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout11_Click"></asp:LinkButton></li>
            </ul>
        </div>
        <div style="float: right;">
            <asp:Literal ID="ltWelcome" runat="server"></asp:Literal>
        </div>
    </div>
    <%------------------------------Breadcrump --------------------------------------%>
    <br />
    <div class="row">
        <div class="large-12 columns">
            <a href="Presentation/itr1.aspx">Income Tax Returns</a> > Demo e-filing</span>
        </div>
    </div>
    <div id="carousel-example-generic" class="carousel slide " data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
            <li data-target="#carousel-example-generic" data-slide-to="2"></li>
        </ol>
        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <!--SCREENS-->
            <div class="item active">
                <div class="item" style="border: 0px">
                    <div class="row" style="border: 0px">
                        <div class="text-center" style="font-family: Cambria; font-size: 28px; color: #ef5845;">
                            Home Page
                        </div>
                        <div class="well text-center">
                            <img src="itrscreens/a14.jpg" alt="ScreenShot" />                            
                           <%-- <img src="itrscreens/1.PNG" />--%>
                        </div>
                    </div>
                </div>
                <div class="carousel-caption">
                    <%-- <h3>Security</h3>--%>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="text-center" style="font-family: Cambria; font-size: 28px; color: #ef5845;">
                        ITR Home Page
                    </div>
                    <div class="well text-center">
                        <img src="itrscreens/a15.jpg" alt="ScreenShot" />                        
                        <%--<img src="itrscreens/2.png" />--%>
                    </div>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="text-center" style="font-family: Cambria; font-size: 28px; color: #ef5845;">
                        Login Page
                    </div>
                    <div class="well text-center">
                        <img src="itrscreens/a13.jpg" alt="ScreenShot" />                        
                       <%-- <img src="itrscreens/3.png" />--%>
                    </div>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="well text-center">
                        <img src="itrscreens/a1.jpg" alt="ScreenShot" />                        
                       <%-- <img src="itrscreens/4.png" />--%>
                    </div>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="well text-center">
                        <img src="itrscreens/a3.jpg" alt="ScreenShot" />                        
                       <%-- <img src="itrscreens/5.png" />--%>
                    </div>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="well text-center">  
                        <img src="itrscreens/a4.jpg" alt="ScreenShot" />
                        <%--<img src="itrscreens/6.png" />--%>
                    </div>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="well text-center">
                        <img src="itrscreens/a5.jpg" alt="ScreenShot" />                        
                        <%--<img src="itrscreens/7.png" />--%>
                    </div>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="well text-center">
                        <img src="itrscreens/a6.jpg" alt="ScreenShot" />                        
                        <%--<img src="itrscreens/8.png" />--%>
                    </div>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="well text-center">
                        <img src="itrscreens/a7.jpg" alt="ScreenShot" />                            
                        <%--<img src="itrscreens/9.png" />--%>
                    </div>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="well text-center">
                        <img src="itrscreens/a8.jpg" alt="ScreenShot" />
                        <%--<img src="itrscreens/10.png" />--%>
                    </div>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="well text-center">
                        <img src="itrscreens/a9.jpg" alt="ScreenShot" />
                        <%--<img src="itrscreens/10.png" />--%>
                    </div>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="well text-center">
                        <img src="itrscreens/a10.jpg" alt="ScreenShot" />
                    </div>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="well text-center">
                        <img src="itrscreens/a11.jpg" alt="ScreenShot" />
                    </div>
                </div>
            </div>
            <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="well text-center">
                        <img src="itrscreens/a12.jpg" alt="ScreenShot" />
                    </div>
                </div>
            </div>
         <%--   <div class="item" style="border: 0px">
                <div class="row" style="border: 0px">
                    <div class="well text-center">
                        <img src="itrscreens/14.png" />
                    </div>
                </div>
            </div>--%>
            <%-- <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen12.JPG" />
                    </div>
                </div>
          </div>
          <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen13.JPG" />
                    </div>
                </div>
          </div>
        <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen14.JPG" />
                    </div>
                </div>
          </div>
        <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen15.JPG" />
                    </div>
                </div>
          </div>
        <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen16.JPG" />
                    </div>
                </div>
          </div>
        <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen17.JPG" />
                    </div>
                </div>
          </div>
        <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen18.JPG" />
                    </div>
                </div>
          </div>
          <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen18i.JPG" />
                    </div>
                </div>
          </div>
        <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen19.JPG" />
                    </div>
                </div>
          </div>
        <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen20.JPG" />
                    </div>
                </div>
          </div>
        <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen21.JPG" />
                    </div>
                </div>
          </div>
            <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen22.jpg" />
                    </div>
                </div>
          </div>
          <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/screen23.JPG" />
                    </div>
                </div>
          </div>
            --%>
            <!--      <div class="item" style="border:0px">
                <div class="row" style="border:0px" >
                    <div class="well text-center">
                        <img src="screens1/sample.JPG" />
                    </div>
                </div>
          </div>
    

  -->
        </div>
        <!-- Controls -->
        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span></a><a class="right carousel-control"
                href="#carousel-example-generic" role="button" data-slide="next"><span class="glyphicon glyphicon-chevron-right">
                </span></a>
    </div>
    <!-- Carousel -->
    <!-- Second Band (Image Left with Text) -->
    <%-- <div class="large-12 columns" style=" background-image:url(images/pattern2.JPG); background-repeat: repeat-x; ">
         &nbsp;
        </div>--%>
    </form>
</body>
</html>
