<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_header.ascx.cs" Inherits="menu_header" %>
<link href="../Stylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../sliderengine/jquery.js" type="text/javascript"></script>
<script src="../sliderengine/amazingslider.js" type="text/javascript"></script>
<link href="../sliderengine/amazingslider-1.css" rel="stylesheet" type="text/css" />
<link href="../Stylesheet/buttonstyle.css" rel="stylesheet" type="text/css" />
<script src="../js/modernizr.custom.34978.js" type="text/javascript"></script>
<script src="../sliderengine/initslider-1.js" type="text/javascript"></script>
<link href="../Stylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />

<link href="css/colorbox.css" rel="stylesheet" type="text/css" />

        <style type="text/css">
    .modal-backdrop {
           
           display: none;
       }
       .modal {
           width: 350px;
           top: 10%;
           left:25%;
           z-index: 1020;
           background-color: #FFF;
           border-radius: 6px;
           display: none;
       }
       .modal-header {
           background-color:#EB5739;
           color: #FFF;
           border-top-right-radius: 5px;
           border-top-left-radius: 5px;
       }
       .modal-header h3 
       {
           color:White;
           margin: 0;
           text-align:Left;
             font-size: 20px;
           line-height: 10px;
           
       }
       .modal-header h2 .close-modal {
           float: right;
           text-decoration: none;
           color: #FFF;
           margin-top:-15px;
       }
       .modal-footer 
       {
           
           background-color: #F1F1F1;
           padding: 0 10px 0 10px;
           line-height: 40px;
           text-align: right;
           border-bottom-right-radius: 5px;
           border-bottom-left-radius: 5px;
           border-top: solid 1px #CCC;
       }
       .modal-body {
           
           border-style: solid;
           border-top: none;
           border-color: rgb(235, 87, 57);
           
       }
    </style>
     
<script src="js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
      <script src="../Popup/jquery.min.js" type="text/javascript"></script>
    <script src="../Popup/jquery-ui.js" type="text/javascript"></script>
    <link href="../Popup/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            modalPosition();
            $(window).resize(function () {
                modalPosition();
            });
            $('#btn_open').click(function (e) {
                $('.modal').addClass('.modal-backdrop').fadeIn('fast');
                e.preventDefault();
            });
            $('.close-modal').click(function (e) {
                $('.modal').removeClass('.modal-backdrop').fadeOut('fast');
            });
        });
        function modalPosition() {
            var width = $('.modal').width();
            var pageWidth = $(window).width();
            var x = (pageWidth / 2) - (width / 2);
            $('.modal').css({ left: x + "px" });
        }

        function redirectMain() {
        //nishu 8/3/2015 show on itr salary page only
            if (window.location.href.indexOf("Salary") > -1) {
                //                alert("your url contains the name salary");
                //            }
                var hdnValue = document.getElementById('<%= hdnProject.ClientID%>').value;
                if (hdnValue == "vt") {
                    $("#popupdiv").dialog({
                        title: "Error Message",
                        width: 'auto',
                        height: 'auto',
                        minHeight: '0',
                        modal: true,
                        buttons: { Yes: function () {
                            window.location = "saveAssessee.aspx?wx=1&lg=1"

                        },
                            No: function () {
                                //$(this).dialog('close');
                                window.location = "saveAssessee.aspx?lg=1"
                            },
                            Cancel: function () {
                                $(this).dialog('close');
                            }
                        }
                    });
                    //            if (confirm('All Your Data will be lost for the current Assessee. Do you want to save it anyway before leaving?')) {
                    //                window.location = 'saveAssessee.aspx?wx=1&lg=1';
                    //            }
                    //            else {
                    //                window.location = 'saveAssessee.aspx?lg=1';
                    //            }
                }
                else {
                    window.location = "saveAssessee.aspx?lg=1";
                }
            }
           
            else {
                window.location = "saveAssessee.aspx?lg=1";
            }
        }
    </script>
<br class="clearit" />
<div class="row" style="height:60px;margin-top: -18px;">
    <div class="large-4 columns" style="background-color: white; color: black; height: 80px;
        vertical-align: top;">
          <a href="../Default.aspx">
        <img  src="../images/logo2.PNG" style="width:240px; height:auto" alt="eCA" />
        </a>
    </div>
      <div class="large-5 columns text-right">
      <img src="../images/toll5.jpg" style="width: 136px;
    height: 64px;
    padding-left: 7px; padding-right:7px; padding-top:17px" /></div>
    <div class="large-3 columns text-right">
   
    <img src="male3.jpg"  height="25px" />
    <br />
        Welcome
        <asp:Label ID="lblUser" runat="server" Font-Bold="true" style="color:rgba(25, 185, 154, 0.97);  text-transform:capitalize; font-size:18px"></asp:Label>
        <p>
        
       <%-- <img src="female3.png" height="25px" />--%>
        
            <%--<a href="../Presentation/logout.aspx">[Logout] </a>--%>
            <a href="#" onclick="redirectMain();" style="color:rgba(25, 185, 154, 0.97); font-size:12px">[Logout] </a>
            <a id="btn_open" href="#" style="color:rgba(25, 185, 154, 0.97); font-size:12px">[Change Password]</a>
                   
        </p>
       <div class="modal" style="position:fixed"> 
       <div class="modal-header" style="padding: 15px;">
       <h2><a class="close-modal" href="#">&times;</a></h2>
        <h3>Change Password </h3> 
    </div>
       
       <div class="modal-body">
       
          <iframe style=" width:100%; height: 350px; border-style: none;overflow:hidden" id="ifrm" src="../Presentation/ChangePwd.aspx" runat="server"></iframe>
        </div>
                
        </div>
    </div>
</div>
 <div  id="popupdiv" style="display: none">
 <p>
 All Your Data will be lost for the current Assessee. Do you want to save it anyway before leaving?
 </p>
 </div>
 <div  id="popup_Pricing" style="display: none">
 <p>
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
          <li class="cta-button "><a class="button radius" href="#">Enroll Now</a></li>
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
           
          <li class="cta-button "><a class="button radius" href="PersonalInfo.aspx">Enroll Now</a></li>
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
        <li class="cta-button"><a class="button radius" href="PersonalInfo.aspx">Enroll Now</a></li>
      </ul>
    </div>
  </div>
 </p>
 </div>

<%--<div class="row" id="menuwrapper" style="background-color: #1569C7;">
    <div class="large-12 columns " id="p7menubar">
        <asp:Literal ID="ltMenu" runat="server">
        </asp:Literal>
    </div>
</div>--%>
<br class="clearit" />
<asp:HiddenField ID="hdnProject" runat="server" value="vt" />
