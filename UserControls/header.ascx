<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="Presentation_header" %>
<%-- <link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
 <script src="../foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>--%>
<%-- <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>--%>
<%--      <script src="../Popup/jquery.min.js" type="text/javascript"></script>
    <script src="../Popup/jquery-ui.js" type="text/javascript"></script>
    <link href="../Popup/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
      <script type="text/javascript">
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
             // alert('logout');
              if ((window.location.href.indexOf("IncomeTax") > -1) || window.location.href.indexOf("Profile") > -1) {
                  //             alert("your url contains the name salary");
                  //            }
                  var hdnValue = document.getElementById('<%= hdnProject.ClientID%>').value;
                  if (hdnValue == "vt") {
//                      $.noConflict(true);
                      $("#popupdiv").dialog({
                          title: "Error Message",
                          width: '450px',
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
           background-color:rgba(60, 63, 83, 0.62);
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
           border-color: rgba(60, 63, 83, 0.62);
           
       }
       .top-barheader {
  overflow: hidden;
  height: 83px;
  line-height: 83px;

  background: #e6e9f0;
  margin-bottom: 0;
  width:100%;background: -webkit-linear-gradient(left, rgba(255,0,0,0), #1F1D1D); /* For Safari 5.1 to 6.0 */
    background: -o-linear-gradient(right, rgba(255,0,0,0), #1F1D1D); /* For Opera 11.1 to 12.0 */
    background: -moz-linear-gradient(right, rgba(255,0,0,0), #1F1D1D); /* For Firefox 3.6 to 15 */
    background: linear-gradient(to right, rgba(255,0,0,0), #1F1D1D); /* Standard syntax (must be last) */ }
  .logo
  {
      width:20%;
      float:left;
      height:83px;
  }
  .top-barrgt
  {width:80%;
   float:left;

   height:83px;
  
  }
    </style>
<%-- <div class="top-barheader hide-for-small-only" style="background-image:url('../images/header_img.jpg')"
   >
 <div class="logo">
 <a href="#">
    <img  src="../images/logo2.PNG" style="width:240px; height:auto" alt="eCA" />
  </a>
 </div>
 <div class="top-barrgt">


<p style="font-family:'Open Sans','sans-serif';color:#F4F2F2">
          
                   
     </p>
      
 </div>


 </div>--%>
  <div style="height:3px; background-color:#e14658"  class="hidden-for-small-only"></div>
 <div style="height:5px; background-color:white"  class="hidden-for-small-only"></div>
 <div style="width:100%; height:83px; " class="hidden-for-small-only">

 <div style="width:20%; height:83px; float:left">
 <a href="../Default.aspx">
    <img  src="../images/logo2.PNG" style="width:240px; height:auto" alt="logo" />
  </a>
 </div> 
 <div style="width:60%; height:83px; float:left">
 <div style=" text-align:right  ">
      <img src="../images/toll5.jpg" style=" width: 136px;
    padding: 5px;" alt="tollfree" /></div>
      </div>
 <div style="width:20%; height:83px; float:left">
<%-- <div style="width:30%;" >

 </div>
 <div style="width:50%;" >--%>
  
 <div style=" text-align:right  "><span style="font-family:'Open Sans','sans-serif';color:#6B6267;font:13px Open Sans,sans-serif; padding:0">Welcome</span>  <asp:Label ID="lblUser" runat="server" Font-Bold="true" style="color:rgba(25, 185, 154, 0.97);  text-transform:capitalize; padding:0"></asp:Label>   <img src="../Presentation/male3.jpg" /></div>
 <div style="  text-align:right "> <a href="#" onclick="redirectMain();" style="color:rgba(25, 185, 154, 0.97);font:13px Open Sans,sans-serif">[Logout] </a>
            <a id="btn_open" href="#" style="color:rgba(25, 185, 154, 0.97);font:13px Open Sans,sans-serif">[Change Password]</a></div>
<%--</div>--%>
   
 </div> 


 </div>
<div style="height:2px;"></div>
    <asp:HiddenField ID="hdnProject" runat="server" value="vt" />
     <div  id="popupdiv" style="display: none">
 <p>
 All Your Data will be lost for the current Assessee. Do you want to save it anyway before leaving?
 </p>
 </div>
    <div class="modal" style="position:fixed"> 
       <div class="modal-header" style="padding: 15px;">
       <h2><a class="close-modal" href="#">&times;</a></h2>
        <h3>Change Password </h3> 
    </div>
       
       <div class="modal-body">
       
          <iframe style=" width:100%; height: 350px; border-style: none;overflow:hidden" id="ifrm" src="../Presentation/ChangePwd.aspx" runat="server"></iframe>
        </div>
                
        </div>