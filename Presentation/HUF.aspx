<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HUF.aspx.cs" Inherits="Presentation_HUF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
<%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../mobilemenu2.ascx" TagPrefix="mob1" TagName="menu1" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="~/menu_header.ascx" TagName="menuheader" TagPrefix="header" %>
<!DOCTYPE html >
<html lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta name="author" content="" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Control Panel</title>
    <%--  <link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />--%>
    <%--<script type="text/javascript" src="../scripts/menu.js"></script>--%>
    <%--<link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>
    <%-- <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../js/tab.js" type="text/javascript"></script>
    <script src="../js/Modernizer.min.js" type="text/javascript"></script>--%>
    <%--<link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />--%>
    <%--<script src="../foundation-5.5.0/js/foundation.min.js" type="text/javascript"></script>
    <script src="../css/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    --%>
    <%--<link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
    
        <link href="../StaticStylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />
    <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript" src="Scripts/common.js"></script>
    <!--Master javascript file-->
    <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <!--Master javascript file-->
    <!--master style sheet-->
    <link href="../style_folder/ItrSoftwareCompanyStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnmenu").click(function () {
                $("#divmenu").slideToggle();
            });

        });
    </script>
    <%--   <script type="text/javascript">
       $(function () {
           // Convert to UpperCase/Title Case
       

               $('input').keyup(function () {
                   this.value = this.value.substr(0, 1).toUpperCase() + this.value.substr(1);
                   
              

               });
       });
</script>--%>
    <script src="../Presentation/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.ui.min.js" type="text/javascript"></script>
    <%--<link href="../ITRStylesheet/styles/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
    <%-------------------------------java script code fro validate form -------------------------------------------------------------%>
   <%--  <script type="text/javascript">
         function ShowPopup(message) {
             //  alert(message);
             // $(function () {
             // $("#msg").html(message);
             if ($('hdnIsBank').val() != "") {
                 $("#msg").dialog({
                     title: "Assessee Information",


                     buttons: {
                         OK: function () {
                             if (document.getElementById('hdnNew').value == 'false')
                                 window.location = "saveAssessee.aspx?wx=1";
                             else
                                 window.location = "main.aspx";

                         },
                         Close: function () {
                             $(this).dialog('close');
                         }
                     },
                     modal: true
                 });
                 // });
             }
             else {
                 alert('else part');
                 $("#msg2").dialog({
                     title: "Assessee Information",


                     buttons: {
                         OK: function () {

                             window.location = "";


                         },
                         Close: function () {
                             $(this).dialog('close');
                         }
                     },
                     modal: true
                 });
             }
         };
         //          //On UpdatePanel Refresh
         //          var prm = Sys.WebForms.PageRequestManager.getInstance();
         //          if (prm != null) {
         //              prm.add_endRequest(function (sender, e) {
         //                  if (sender._postBackSettings.panelsToUpdate != null) {
         //                      function ShowPopup(message) {
         //                          $(function () {
         //                              $("#msg").html(message);
         //                              $("#msg").dialog({
         //                                  title: "Assessee Information",
         //                                  buttons: {
         //                                      OK: function () {
         //                                          window.location = "Main.aspx"

         //                                      },
         //                                      Close: function () {
         //                                          $(this).dialog('close');
         //                                      }
         //                                  },
         //                                  modal: true
         //                              });
         //                          });
         //                      };

         //                  }
         //              });
         //          };
         
    </script>--%>
       <script type="text/javascript">

           function setBankVal(val) {
               try {
                   if (document.getElementById('txtAccountNumber').value != '' && document.getElementById('txtMICR').value != '' && document.getElementById('txtBankName').value != '') {
                       document.getElementById('hdnIsBank').value = val;
                       //alert(document.getElementById('hdnIsBank').value);
                   }
               }
               catch (e) { alert(e); }
           }

           function ShowPopup(message) {
               //  alert(message);
               // $(function () {
               // $("#msg").html(message);
               //alert(document.getElementById('hdnIsBank').value);
               //if ($('hdnIsBank').val() != "none") {
               //if ($('hdnIsBank').val()!=undefined) {alert('entered');
               if (document.getElementById('hdnIsBank').value != 'none') {
                   $("#msg").dialog({
                       title: "Assessee Information",


                       buttons: {
                           OK: function () {
                               if (document.getElementById('hdnNew').value == 'false')
                                   window.location = "saveAssessee.aspx?wx=1";
                               else if (document.getElementById('hdnNew').value == 'e-exists') {
                                   nextTab('a_Addr', '1');
                                   $(this).dialog('close');
                               }
                               else
                                   window.location = "main.aspx";

                           },
                           Close: function () {
                               $(this).dialog('close');
                           }
                       },
                       modal: true
                   });
                   // });
               }
               else {
                   //alert('else part');
                   $("#msg2").dialog({
                       title: "Assessee Information",


                       buttons: {
                           OK: function () {
                               $(this).dialog('close');
                           },
                           Close: function () {
                               $(this).dialog('close');
                           }
                       },
                       modal: true
                   });
                   //alert('asd');

               }
           };
           //          //On UpdatePanel Refresh
           //          var prm = Sys.WebForms.PageRequestManager.getInstance();
           //          if (prm != null) {
           //              prm.add_endRequest(function (sender, e) {
           //                  if (sender._postBackSettings.panelsToUpdate != null) {
           //                      function ShowPopup(message) {
           //                          $(function () {
           //                              $("#msg").html(message);
           //                              $("#msg").dialog({
           //                                  title: "Assessee Information",
           //                                  buttons: {
           //                                      OK: function () {
           //                                          window.location = "Main.aspx"

           //                                      },
           //                                      Close: function () {
           //                                          $(this).dialog('close');
           //                                      }
           //                                  },
           //                                  modal: true
           //                              });
           //                          });
           //                      };

           //                  }
           //              });
           //          };
         
    </script>
    <script type="text/javascript">
        //$(document).ready(function(){
        //$("#msg1").css("min-height","100%");
        //});

        function ShowErrMsg() {

            $("#msg1").dialog({
                title: "Error Message",
                width: 'auto',
                height: 'auto',
                minHeight: '0',





                modal: true
                //buttons: {
                //Cancel: function () {
                //     $(this).dialog('close');
                //   }
                // }
            });
        }
        function validate() {
            if (document.getElementById('hdnIsBank').value != 'none') {
                var regexp1 = new RegExp("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                var vv_Validation = new Number();
                vv_Validation = 0;
                var varMsg = '';
                //document.getElementById("msg1").style.minHeight = "250px";
                if (document.getElementById('txtLastName').value == '')
                    varMsg += '<tr><td>Last Name Required</td><td> - Personal Details Tab</td></tr>';
                if (document.getElementById('txtFatherName').value == '')
                    varMsg += '<tr><td>Father Name Required</td><td> - Personal Details Tab</td></tr>';
                if (document.getElementById('txtDOB').value == '')
                    varMsg += '<tr><td>Date of Birth Name Required</td><td> - Personal Details Tab</td></tr>';
                if (document.getElementById('txtFlat').value == '')
                    varMsg += '<tr><td>Flat/Floor/Building Name Required</td><td> - Address Tab</td></tr>';
                if (document.getElementById('txtArea').value == '')
                    varMsg += '<tr><td>Area/Locality Required</td><td> - Address Tab</td></tr>';
                if (document.getElementById('txtCity').value == '')
                    varMsg += '<tr><td>City Required</td><td> - Address Tab</td></tr>';
                if (document.getElementById('txtPIN').value == '')
                    varMsg += '<tr><td>PIN Required</td><td> - Address Tab</td></tr>';
                if (document.getElementById('txtMobile1').value == '')
                    varMsg += '<tr><td>Mobile Number 1 Required</td><td> - Address Tab</td></tr>';
                if (document.getElementById('txtEmail').value == '')
                    varMsg += '<tr><td>Email Address Required</td><td> - Address Tab</td></tr>';
                //        if (document.getElementById('txtAccountNumber').value == '')
                //            varMsg += '<tr><td>Account Number Required</td><td> - Bank Details Tab</td></tr>';
                //        if (document.getElementById('txtMICR').value == '')
                //            varMsg += '<tr><td>IFSC Code Required</td><td> - Bank Details Tab</td></tr>';
                else {
                    if (/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/i.test(document.getElementById("txtEmail").value) == false)
                        varMsg += '<tr><td>Invalid Email Address!</td></tr>';

                    if (/\d{12}/i.test(document.getElementById("txtAadhar").value) == false && document.getElementById("txtAadhar").value != '') {
                        varMsg += '<tr><td>Invalid Aadhar No.!</td></tr>';
                    }

                }

                if (varMsg != '') {
                    varMsg = '<table>' + varMsg + '</table>';
                    document.getElementById("msg1").innerHTML = varMsg;
                    //            document.getElementById("msg1").style.height = '700';
                    ShowErrMsg();
                    return false;
                }
                //        if (regexp1.test(document.getElementById("txtEmail").value)) {
                //     
                //            alert("incorrect email");
                //            return false;

                // }
            }
            else {
                //alert('Enter Bank Details');
                ShowPopup('Please Enter Bank Details');
                return false;
            }
        }
    </script>
  <%--  <script type="text/javascript">
        $(document).ready(function () {

            $("#btnInsert").click(function () {
                if (($("#txtSTD").val().length != 0 || $("#txtPhone").val().length) != 0) {
                    if (($("#txtSTD").val().length + $("#txtPhone").val().length) != 10) {

                        alert("Length of std and phone should be 10 digits");
                        var len = ("txtSTD").val().length + ("txtPhone").val().length;
                        alert(len);

                    }
                    else {

                    }
                }
            });
        });

      
    </script>--%>
    <%-- <script type="text/javascript">
        $(document).ready(function () {

            $("#hide").click(function () {
                $("#div1").slideToggle();
            });

        });
    </script>--%>
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 00px;
            margin-bottom: 00px;
        }
        a
        {
            text-decoration: none;
            color: #215DC6;
        }
        
        a:hover
        {
            text-decoration: none;
            color: #40ACF4;
        }
        .style1
        {
            color: #215DC6;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: 12px;
        }
        input[type=text]
        {
            padding: 4px;
        }
    </style>
    <style type="text/css">
        .hrnew
        {
            height: 2px;
            background-image: -webkit-linear-gradient(left, rgba(0, 0, 0, 1), rgba(0, 0, 0, 1), rgba(0, 0, 0, 1));
            border-color: Black;
            opacity: 1.0;
            margin-top: -3px;
        }
    </style>
    <script type="text/javascript">
        function enableIt(id) {
            try {
                //alert(id.id);
                var i = new Number();
                var j = new Number();
                var k = new Number();
                var ddName = new String();
                ddName = id.id.toString();
                ddName = ddName.substring((ddName.length - 1), ddName.length);
                //alert(ddName);
                if (ddName == '2') {
                    i = 11;
                    j = 22;
                    k = 33;
                }
                else if (ddName == '3') {
                    i = 111;
                    j = 222;
                    k = 333;
                }
                else {
                    i = 1;
                    j = 2;
                    k = 3;
                }

                if (id.value == 0) {
                    document.getElementById('txtTrade' + i.toString()).setAttribute('disabled', 'disabled');
                    document.getElementById('txtTrade' + j.toString()).setAttribute('disabled', 'disabled');
                    document.getElementById('txtTrade' + k.toString()).setAttribute('disabled', 'disabled');
                }
                else {
                    document.getElementById('txtTrade' + i.toString()).removeAttribute('disabled');
                    document.getElementById('txtTrade' + j.toString()).removeAttribute('disabled');
                    document.getElementById('txtTrade' + k.toString()).removeAttribute('disabled');
                }
            }
            catch (e) { alert(e); }
        }

        function setNaming(id) {
            try {
                document.getElementById('txtNameRep').value = document.getElementById('txtFirstName').value + ' ' + document.getElementById('txtMiddleName').value + ' ' + document.getElementById('txtLastName').value
                document.getElementById('txtFNameAu').value = document.getElementById('txtFatherName').value;
            }
            catch (e) { alert(e); }
        }

        function setVals() {
            document.getElementById('RegularExpressionValidator2').disabled = 'true';
        }

        //        function SelectSignatory() {
        //            try {
        //                if (document.getElementById('rdoSelf').checked) {
        //                    document.getElementById('txtNameRep').disabled = 'true';
        //                    document.getElementById('txtFNameAu').disabled = 'true';
        //                    document.getElementById('txtPANRep').disabled = 'true';
        //                    document.getElementById('txtDesignationRep').disabled = 'true';
        //                    document.getElementById('RequiredFieldValidator11').disabled = 'true';
        //                }
        //                else {
        //                    document.getElementById('txtNameRep').removeAttribute('disabled');
        //                    document.getElementById('txtFNameAu').removeAttribute('disabled');
        //                    document.getElementById('txtPANRep').removeAttribute('disabled');
        //                    document.getElementById('txtDesignationRep').removeAttribute('disabled');
        //                    document.getElementById('RequiredFieldValidator11').removeAttribute('disabled');
        //                }
        //            }
        //            catch (e) { alert(e); }
        //        }

        function enableDOB() {
            try {
                //                document.getElementById('txtdob_MaskedEditExtender_ClientState').disbaled = 'false'; //.removeAttribute('Enabled');
            }
            catch (e) { alert(e); }
        }
    </script>
    <%-- <script src="../lib/jquery-1.8.3.min.js" type="text/javascript" charset="utf-8"></script>
<script src="../lib/jquery.maskedinput.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $.mask.definitions['~'] = "[+-]";
        $("#txtDOB").mask("99/99/9999", { completed: function () { } });
        $("#phone").mask("(999) 999-9999");
        $("#phoneExt").mask("(999) 999-9999? x99999");
        $("#iphone").mask("+33 999 999 999");
        $("#tin").mask("99-9999999");
        $("#ssn").mask("999-99-9999");
        $("#product").mask("a*-999-a999", { placeholder: " " });
        $("#eyescript").mask("~9.99 ~9.99 999");
        $("#po").mask("PO: aaa-999-***");
        $("#pct").mask("99%");

        $("input").blur(function () {
            $("#info").html("Unmasked value: " + $(this).mask());
        }).dblclick(function () {
            $(this).unmask();
        });
    });
	
</script>
    --%>
    <%--this fn show validation errors in popup --%>
    <%--<script type="text/javascript">
      function WebForm_OnSubmit() {
          if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
              $("#validation_dialog").dialog({
                  title: "Validation Error!",
                  modal: true,
                  resizable: false,
                  buttons: {
                      Close: function () {
                          $(this).dialog('close');
                          try {
                              alert(document.getElementById('lblMessage').innerHTML);
                          } catch (e) {
                              //alert(e); 
                          }
                          //window.location = 'DisplayForm.aspx';
                      }
                  }
              });
              return false;
          }
          return true;
      }
      //On UpdatePanel Refresh
      var prm = Sys.WebForms.PageRequestManager.getInstance();
      if (prm != null) {
          prm.add_endRequest(function (sender, e) {
              if (sender._postBackSettings.panelsToUpdate != null) {
                  function WebForm_OnSubmit() {
                      if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                          $("#validation_dialog").dialog({
                              title: "Validation Error!",
                              modal: true,
                              resizable: false,
                              buttons: {
                                  Close: function () {
                                      $(this).dialog('close');
                                      try {
                                          alert(document.getElementById('lblMessage').innerHTML);
                                      } catch (e) {
                                          //alert(e); 
                                      }
                                      //window.location = 'DisplayForm.aspx';
                                  }
                              }
                          });
                          return false;
                      }
                      return true;
                  }
              }
          });
      };
</script>--%>
    <%--This fn is used to show msg as pop for add/update sucessfully --%>
    <script type="text/javascript">
       
    </script>
    <script type="text/javascript">


        function nextTab(id, IsVal) {
            var IsValidated = '';
            if (IsVal == '1') {
                if (id == 'a_Addr') {
                    if (document.getElementById('txtLastName').value == '')
                        IsValidated = 'Enter Name</br>';
//                    if (document.getElementById('txtFatherName').value == '')
//                        IsValidated += 'Enter Father Name</br>';
                    if (document.getElementById('txtDOB').value == '')
                        IsValidated += 'Enter Date of Incorporation</br>';
                    if (IsValidated != '') {
                        document.getElementById("msg1").innerHTML = IsValidated;

                        ShowErrMsg();
                    }
                }
                else if (id == 'a_BD') {
                                           
                    if (document.getElementById('txtFlat').value == '')
                        IsValidated = 'Enter Flat/Door/Building</br>';
                    if (document.getElementById('txtArea').value == '')
                        IsValidated += 'Enter Area/Locality</br>';
                    if (document.getElementById('txtCity').value == '')
                        IsValidated += 'Enter City</br>';
                    if (document.getElementById('txtPIN').value == '')
                        IsValidated += 'Enter PIN</br>';
                    if (document.getElementById('txtMobile1').value == '')
                        IsValidated += 'Enter Mobile Number1</br>';
                    if (document.getElementById('txtEmail').value == '')
                        IsValidated += 'Enter Email ID</br>';
                    if ((document.getElementById('txtPIN').value).length < 6)
                        IsValidated += 'Incorrect PIN</br>';
                   
                    if ((document.getElementById('txtMobile1').value).length < 10)
                        IsValidated += 'Incorrect Mobile No.</br>';
                    if (/[\w-\.]+@([\w-]+\.)+[\w-]{2,4}/i.test(document.getElementById('txtEmail').value) == false)
                        IsValidated += '<br> Invalid Email ID';
                    if (IsValidated != '') {
                        document.getElementById("msg1").innerHTML = IsValidated;

                        ShowErrMsg();
                    }
                }
            }

            if (IsValidated == '')
            
                document.getElementById(id).click();
                
            else
            //alert(IsValidated);
            {
            }
        }

    </script>
   
    <script src="../js/ie_compatibility/es5-shim.min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/html5shiv.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/nwmatcher-1.2.5-min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/respond.min.js" type="text/javascript"></script>
    <script src="../js/ie_compatibility/selectivizr-1.0.3b.js" type="text/javascript"></script>
     
</head>
<body onload="P7_ExpMenu()" class="no-js">
    <form id="form1" runat="server" role="form">
    <asp:HiddenField ID="hdnAY" runat="server" />
    <asp:HiddenField ID="hdnNew" runat="server" />
    <br />
    <div class="row show-for-small-only ">
        <div class="small-6 columns" style="vertical-align: top;">
            <a href="Default.aspx">
                <img src="../images/logo2.PNG" style="width: 220px; height: 83px" />
            </a>
        </div>
        <div class="small-6 columns text-right">
            Welcome <span style="font-weight: bold">
                <asp:Literal ID="ltUser" runat="server">   </asp:Literal></span>
            <br />
            <a href="logout.aspx">[Logout] </a>
        </div>
    </div>
    <%-------------header ----------------%>
    <div class="row hide-for-small-only" style="margin-top: -20px;">
        <div class="large-12 columns">
            <%--Add by nishu for header 11/4/2015 --%>
            <header:menuheader ID="header1" runat="server" />
        </div>
    </div>
    <div class="row">
        
        <div class="large-12 columns">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true"
                NodeStyle-Font-Bold="false" ForeColor="#333333">
            </asp:SiteMapPath>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
    </div>
    
    <div class="row show-for-medium-only">
        <div class="large-12 columns  ">
            <mob3:mediummenu ID="Mediummenu1" runat="server" />
        </div>
    </div>
    <div class="row hidden-for-large hidden-for-medium" id="divmenu" style="display: none">
        <div class="large-12 columns">
            <%
                if (Session["ay"] != null)
                {
            %>
            <mob:menu ID="mob1" runat="server" />
            <%
                }
                else
                {
            %>
            <mob1:menu1 ID="mob11" runat="server" />
            <%
    }
            %>
        </div>
    </div>
    <div class="row show-for-small-only">
        <div class="large-12 columns">
      <%--      <mob2:mobmenu ID="mobmenu" runat="server" />--%>
            <%--<img src="../images/details.JPG" />--%>
        </div>
    </div>
   <%-- <div class="row hidden-for-large hidden-for-medium" id="div1" style="display: none">
        <div class="large-12 columns">
            <sub:submenu ID="Submenu1" runat="server" />
        </div>
    </div>--%>
    <%--  <div class="row">
        <div class="large-12 columns hide-for-large hide-for-medium">
            <div id="hide" class="button">
                Check Assessess Details</div>
        </div>
    </div>--%>
    <%-- <div class="row hidden-for-large hidden-for-medium" id="div1" style="display: none">
        <div class="large-12 columns">
            <sub:submenu ID="Submenu2" runat="server" />
        </div>
    </div>--%>
    <div class="container-fluid">
        <div class="row">
            <%-- <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3 hide-for-small">
                <sub:submenu ID="Submenu1" runat="server" />
            </div>--%>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>
               
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <%--  <div class="row hide-for-small-only">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <p class="bg-primary"><asp:Label ID="lblHeading" runat="server" 
                                                Text="Assessee Details" class="bg-primary"></asp:Label></p>
        </div>
        </div>--%>
                        <div class="row  hide-for-small-only">
                            <div class="large-12 columns">
                                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Assessee Details" style="    border-top-right-radius: 10px;    background-color: white;    background: transparent;    outline: none;    text-decoration: underline;    margin-bottom: -4px;    color: rgb(236, 88, 58);    font-size: 16px;    font-family: 'Open Sans','sans-serif';"></asp:Label>                                &nbsp;
                                <asp:Label ID="lblAssesseeType" runat="server" Text="Label" Width="66px" Visible="false"></asp:Label></div>
                            <%--  <div class="large-6 columns">
                                <asp:Label ID="Label3" runat="server" Text="Pan Number" Font-Bold="true"></asp:Label>&nbsp;
                                <asp:Label ID="lblPan" runat="server" Text="Label" Style="text-transform: uppercase;"></asp:Label>
                            </div>--%>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                <div class="container-fluid">
                    <ul class="nav nav-tabs" role="tablist" id="mytab">
                        <li class="active"><a id="a_PD" href="#SectionA" data-toggle="tab" style="outline: 0;">Personal Details</a></li>
                        <li><a id="a_Addr" href="#sectionB" data-toggle="tab" click="show();" style="outline: 0;">Address</a></li>
                        <li><a id="a_BD" href="#sectionc" data-toggle="tab" style="outline: 0;">Bank Details</a></li>
                      <%--  <li><a href="#sectiond" data-toggle="tab">Other Information</a></li>--%>
                        <%-- <li><a href="#sectione" data-toggle="tab">Authorised Signatory</a></li>--%>
                    </ul>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getStates"
                        TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getStates"
                        TypeName="Taxation.BusinessLogic.bllStates"></asp:ObjectDataSource>
                </div>
                <hr class="hrnew" />
                <br />
                <div class="tab-content">
                    <div id="SectionA" class="tab-pane fade in active">
                        <div class="row">
                            <div class="large-3 columns">
                               <%-- <asp:Label ID="Label4" runat="server" Text="Salute"></asp:Label><span style="color: red">*</span>--%>
                                <asp:Label ID="Label5" runat="server" Text="Name"></asp:Label><span style="color: Red">*</span>
                            </div>
                            <div class="large-3 columns">
                               <%-- <asp:DropDownList ID="ddlSalute" runat="server">
                                    <asp:ListItem>Mr.</asp:ListItem>
                                    <asp:ListItem>Mrs.</asp:ListItem>
                                    <asp:ListItem>Miss.</asp:ListItem>
                                </asp:DropDownList>--%>
                                  <asp:TextBox ID="txtLastName" runat="server" Style="text-transform: capitalize;" required
                                    class="form-control" placeholder="Name" MaxLength="75"></asp:TextBox>
                            </div>
                            <div class="large-3 columns">
                              <%--  <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>--%>
                                <asp:Label ID="Label9" runat="server" Text="Date of Incorporation"></asp:Label><span style="color: red">*</span>
                                 
                              </div>
                            <div class="large-3 columns">
                            <asp:TextBox ID="txtDOB" runat="server" Width="230px" Height="34px" onfocus="enableDOB();" required
                                    MaxLength="12" placeholder="DD/MM/YYYY" onchange="javascript:validateAY_DOB(this, true);"></asp:TextBox>
                                <div id="errorOrganizer1" style="color: Red">
                                 <asp:MaskedEditExtender ID="txtdob_MaskedEditExtender" runat="server" Century="2000"
                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                    CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" UserDateFormat="DayMonthYear" Mask="99/99/9999" MaskType="Date"
                                    TargetControlID="txtDOB">
                                </asp:MaskedEditExtender>
                               <%-- <asp:TextBox ID="txtFirstName" runat="server" class="form-control" placeholder="First Name"
                                    Style="text-transform: capitalize;" MaxLength="25" onchange="setNaming(this);"></asp:TextBox>--%></div>
                        </div>
                        </div>
                        
                        <div class="row">
                            <div class="large-3 columns">
                               <%-- <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name"></asp:Label>--%>
                                 <asp:Label ID="Label10" runat="server" Text="Residential Status"></asp:Label><span
                                    style="color: Red">*</span>
                            </div>
                            <div class="large-3 columns">
                               <%-- <asp:TextBox ID="txtMiddleName" runat="server" Style="text-transform: capitalize;"
                                    class="form-control" placeholder="Middle Name" MaxLength="25"></asp:TextBox>--%>
                                  <asp:DropDownList ID="ddlResStatus" runat="server">
                                    <asp:ListItem>Resident</asp:ListItem>
                                    <asp:ListItem>Non-Resident</asp:ListItem>
                                    <asp:ListItem>Not-Ordinarily Resident</asp:ListItem>
                                </asp:DropDownList>  
                            </div>
                         
                            <div class="large-3 columns">
                               <asp:Label ID="Label11" runat="server" Text="AO Code/Area Code"></asp:Label>
                            </div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtWard" runat="server" class="form-control" MaxLength="75" Height="34px"
                                    placeholder="AO Code/Area Code"></asp:TextBox> 
                                <%--<asp:RequiredFieldValidator  ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                                    ErrorMessage="Enter Last Name (Personal Details)" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                     <%--   <br />--%>
                        <div class="row">
                            <div class="large-3 columns">
                              <%--  <asp:Label ID="Label8" runat="server" Text="Father's Name"></asp:Label><span style="color: red">*</span>--%>
                           
                            </div>
                            <div class="large-3 columns">
                             <%--   <asp:TextBox ID="txtFatherName" runat="server" Style="text-transform: capitalize;" required
                                    class="form-control" placeholder="Father's Name" MaxLength="125" onchange="setNaming(this);"></asp:TextBox>--%>
                                <%--<asp:RequiredFieldValidator  ID="RequiredFieldValidator111" runat="server" ControlToValidate="txtFatherName"
                                    ErrorMessage="Enter Father Name (Personal Details)" Display="None"></asp:RequiredFieldValidator>--%>

                                    
                            </div>
                            <div class="large-3 columns">
                              
                            </div>
                            <div class="large-3 columns">
                                
                                </div>
                                <%--<asp:RequiredFieldValidator  ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDOB"
                                    ErrorMessage="Enter D.O.B (Personal Details)" Display="None" ></asp:RequiredFieldValidator>--%>
                                <%--                                         <asp:CustomValidator ID="CustomValidatorDOB" runat="server" ErrorMessage="Date should not be after 31/03/2015 for A.Y.2015-16" onservervalidate="cusCustom_ServerValidate" ControlToValidate="txtDOB" Display="None"></asp:CustomValidator>--%>
                               
                            </div>
                               <p style="text-align:right;">
                        <input type="button" value="Next" class="radius button" onclick="nextTab('a_Addr','1');" />
                        </p>
                        </div>
                       <%-- <br />
                        <div class="row">
                            <div class="large-3 columns">
                              </div>
                            <div class="large-3 columns">
                               
                            </div>
                            <div class="large-3 columns">
                                
                            </div>
                            <div class="large-3 columns">
                              </div>
                        </div>--%>
                       <%-- <div class="row">
                            <div class="large-3 columns">--%>
                              <%--  Enter your Aadhar No.--%>
                          <%--  </div>
                            <div class="large-3 columns">--%>
                             <%--   <asp:TextBox ID="txtAadhar" runat="server" Width="230px" placeholder="Aadhar No."
                                    MaxLength="12"></asp:TextBox>--%>
                                <%--<asp:RegularExpressionValidator ID="rdDt" runat="server" ValidationExpression="
                                --%><%--</div>
                            <div class="large-3 columns">
                            </div>
                            <div class="large-3 columns">
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns">
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-4 columns">
                            </div>
                            <div class="large-4 columns">
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                        <br />
                        <div class="row" id="divAadhar" runat="server">
                            <div class="large-4 columns">
                            </div>
                            <div class="large-4 columns">
                            </div>
                            <div class="large-4 columns">
                            </div>
                        </div>
                     
                    </div>--%>
                    <div id="sectionB" class="tab-pane fade">
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label2" runat="server" Text="Flat/Door/Building"></asp:Label><span
                                    style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtFlat" runat="server" Style="text-transform: capitalize;" placeholder="Flat/Door/Building"
                                    Width="231px" Height="34px" MaxLength="50"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFlat"
                                    ErrorMessage="Enter Flat/Door/Block No. (Address Tab)" Display="None"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="large-3 columns">
                                <asp:Label ID="Label18" runat="server" Text="Name of Premises"></asp:Label></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtPremises" runat="server" Width="231px" Height="34px" placeholder="Premises"
                                    MaxLength="50"></asp:TextBox></div>
                        </div>
                        
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label19" runat="server" Text="Road/Street"></asp:Label></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtRoad" runat="server" Width="231px" Style="text-transform: capitalize;"
                                    Height="34px" placeholder="Road/Street" MaxLength="50"></asp:TextBox></div>
                            <div class="large-3 columns">
                                <asp:Label ID="Label25" runat="server" Style="text-transform: capitalize;" Text="Area/Locality"></asp:Label><span
                                    style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtArea" runat="server" class="form-control" placeholder="Area/Locality"
                                    MaxLength="50"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator  ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtArea"
                                    ErrorMessage="Enter Area (Address Tab)" Display="None"></asp:RequiredFieldValidator>--%></div>
                        </div>
                        
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label30" runat="server" Text="Town/City/District"></asp:Label><span
                                    style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtCity" runat="server" Style="text-transform: capitalize;" class="form-control"
                                    placeholder="City" MaxLength="50"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator  ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity"
                                    ErrorMessage="Enter City (Address Tab)" Display="None"></asp:RequiredFieldValidator>--%></div>
                            <div class="large-3 columns">
                                <asp:Label ID="Label31" runat="server" Text="State"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:DropDownList ID="ddlState" runat="server" DataTextField="StateName" DataValueField="StateCode">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label40" runat="server" Text="Country"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:DropDownList ID="ddlCountry" runat="server" DataTextField="Country_Name" DataValueField="CountryId">
                                </asp:DropDownList>
                            </div>
                            <div class="large-3 columns">
                                <asp:Label ID="Label32" runat="server" Text="Pin Code"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtPIN" runat="server" class="form-control" placeholder="Pin Code"
                                    MaxLength="6" onchange="javascript:removeZeroes(this);validatePIN(this)"></asp:TextBox>
                                      <div id="Divpin" style="color: Red"  ></div>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                    TargetControlID="txtPIN" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <%--<asp:RequiredFieldValidator  ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPIN"
                                    ErrorMessage="Enter PIN (Address Tab)" Display="None"></asp:RequiredFieldValidator>--%>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid PIN" ControlToValidate="txtPIN" ValidationExpression="[1-9]{1}[0-9]{5}"></asp:RegularExpressionValidator>--%>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label14" runat="server" Text="STD Code"></asp:Label></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtSTD" runat="server" class="form-control" placeholder="STD Code"
                                    MaxLength="5" onchange="removeZeroes(this);setPhoneLength(this);" ></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    TargetControlID="txtSTD" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="First digit should not be zero" ControlToValidate="txtSTD" ValidationExpression="[1-9]{1}[0-9]{1,5}"></asp:RegularExpressionValidator>--%>
                            </div>
                            <div class="large-3 columns">
                                <asp:Label ID="Label33" runat="server" Text="Phone"></asp:Label></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="Phone"
                                    MaxLength="10" onchange="getPhoneLength(this)"></asp:TextBox>
                                      <div id="divStd" style="color:red" ></div>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    TargetControlID="txtPhone" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label38" runat="server" Text="Mobile No.1"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtMobile1" runat="server" class="form-control" placeholder="Mobile Number1"
                                    MaxLength="10" onchange="javacsript:ValidMobileNo(this)"></asp:TextBox>
                                    <div id="DivMob" style="color:Red"></div>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please enter valid Mobile1"
                                 ControlToValidate="txtMobile1" ValidationExpression="[1-9]{1}[0-9]{9}"></asp:RegularExpressionValidator>--%>
                                <%--<asp:RequiredFieldValidator  ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMobile1"
                                    ErrorMessage="Enter Mobile1 (Address Tab)" Display="None"></asp:RequiredFieldValidator>--%>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    TargetControlID="txtMobile1" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                            <div class="large-3 columns">
                                <asp:Label ID="Label39" runat="server" Text="Mobile No.2"></asp:Label></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtMobile2" runat="server" class="form-control" placeholder="Mobile Number2"
                                    MaxLength="10" onchange="javacsript:ValidMobileNo2(this)"></asp:TextBox>
                                    <div id="DivMob2" style="color:Red"></div>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please enter valid Mobile2"
                                 ControlToValidate="txtMobile2" ValidationExpression="[1-9]{1}[0-9]{5}"></asp:RegularExpressionValidator>--%>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    TargetControlID="txtMobile2" FilterType="Numbers">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="large-3 columns">
                                <asp:Label ID="Label12" runat="server" Text="E-Mail ID"></asp:Label><span style="color: Red">*</span></div>
                            <div class="large-3 columns">
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="E-Mail ID"
                                    MaxLength="125" Style="text-transform: lowercase"></asp:TextBox>
                                <div id="EmailError" style="color: Red">
                                </div>
                                <%--<asp:RequiredFieldValidator  ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="Enter Email-ID (Address Tab)" Display="None"></asp:RequiredFieldValidator>--%>
                                <%--<asp:RegularExpressionValidator ID="txtEmalValidation" runat="server" ControlToValidate="txtEmail" 
                                    ErrorMessage="Incorrect Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
                            </div>
                            <div class="large-3 columns">
                            </div>
                            <div class="large-3 columns">
                            </div>
                        </div>
                        <p style="text-align:right;">
                        <input type="button" value="Back" class="radius button" onclick="nextTab('a_PD','0');" style="font-weight:bold" />
                        <input type="button" value="Next" class="radius button" onclick="nextTab('a_BD','1');" style="font-weight:bold" />
                        </p>
                    </div>
                    <div id="sectionc" class="tab-pane fade">
                        <asp:UpdatePanel ID="upBank" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="large-4 columns">
                                        <asp:Label ID="lblBankName" runat="server" Text="Name of Bank"></asp:Label><span
                                            style="color: Red">*</span>
                                    </div>
                                    <div class="large-4 columns">
                                        <asp:TextBox ID="txtBankName" runat="server" class="form-control" placeholder="Name of Bank"
                                            MaxLength="125" oncahnge="setUpper(this)" required></asp:TextBox></div>
                                    <div class="large-4 columns">
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="large-4 columns">
                                        <asp:Label ID="lblBranchAddress" runat="server" Text="Address of Branch"></asp:Label>
                                    </div>
                                    <div class="large-4 columns">
                                        <asp:TextBox ID="txtBranchAddress" runat="server" class="form-control" placeholder="Address of Branch"
                                            MaxLength="125"></asp:TextBox></div>
                                    <div class="large-4 columns">
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="large-4 columns">
                                        <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number"></asp:Label><span
                                            style="color: Red">*</span>
                                    </div>
                                    <div class="large-4 columns">
                                        <asp:TextBox ID="txtAccountNumber" runat="server" class="form-control" placeholder="Account Number"
                                            MaxLength="20" ValidationGroup="gg" required onchange="javascript:ValidBankAccNo(this)"></asp:TextBox>
                                            <div id="DivBank" style="color:Red"></div>
                                        <%--<asp:RequiredFieldValidator  ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAccountNumber"
                                    ErrorMessage="Enter Account No (Bank Tab)" Display="None" ValidationGroup="gg">
                                </asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator ID="txtAccountNumberValid" runat="server" ControlToValidate="txtAccountNumber" ValidationExpression="[a-zA-Z0-9]([/-]?(((\d*[1-9]\d*)*[a-zA-Z])|(\d*[1-9]\d*[a-zA-Z]*))+)*[0-9]*" ErrorMessage="Invalid Account Number" ValidationGroup="gg"></asp:RegularExpressionValidator>--%>
                                    </div>
                                    <div class="large-4 columns">
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="large-4 columns">
                                        <asp:Label ID="lblAccountType" runat="server" Text="Account Type"></asp:Label><span
                                            style="color: Red">*</span>
                                    </div>
                                    <div class="large-4 columns">
                                        <asp:DropDownList ID="ddlAccountType" runat="server" class="form-control">
                                            <asp:ListItem Text="Savings" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Current" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="large-4 columns">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="large-4 columns">
                                        <asp:Label ID="lblMICR" runat="server" Text="IFSC Code"></asp:Label>&nbsp;<a href="http://www.bankifsccode.com"
                                            target="_blank" style="font-size: 13px">(Know your IFSC Code)</a><span style="color: Red">*</span>
                                    </div>
                                    <div class="large-4 columns">
                                        <asp:TextBox ID="txtMICR" runat="server" class="form-control" Placeholder="IFSC Code"
                                            MaxLength="11" required onchange="javascript:setUpper(this);validateIFSC(this);"></asp:TextBox>
                                              <div id="DivIFSC" style="color: Red"></div>
                                        <%--<asp:RequiredFieldValidator ID="req11" runat="server" ControlToValidate="txtMICR"
                                    ErrorMessage="Enter IFSC Code (Bank Tab)" Display="None" ValidationGroup="gg">
                                </asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator ID="txtMICRValid" runat="server" ControlToValidate="txtMICR" ErrorMessage="Incorrect IFSC Code" ValidationExpression="[A-Za-z]{4}[0][A-Z0-9]{6}" ValidationGroup="gg"></asp:RegularExpressionValidator>--%>
                                    </div>
                                    <div class="large-4 columns">
                                    </div>
                                </div>
                                
                                <div class="row" style="margin-bottom:10px">
                                    <div class="large-4 columns">
                                    </div>
                                    <div class="large-8 columns">
                                        <%--<asp:ImageButton ID="" runat="server" ImageUrl="~/images/addbtn.PNG" ToolTip="Add another bank detail"  />--%>
                                        
                                        <asp:Button ID="btnAdd" runat="server" Text="Add Account" style="font-weight:bold;background-color: transparent;border: rgb(0, 140, 186) 3px solid;border-radius:3px" Font-Bold="true" OnClientClick="setBankVal('Bank');"
                                            OnClick="btnAdd_Click" ValidationGroup="gg" />
                                    </div>
                                    
                                </div>
                                
                                <div class="row">
                                    <div class="large-12 columns">
                                        <asp:GridView ID="grdBank" runat="server" AutoGenerateColumns="false" OnRowCommand="grdBank_RowCommand"
                                            OnRowEditing="grdBank_RowEditing" OnRowCancelingEdit="grdBank_RowCancelingEdit">
                                            <Columns>
                                                <asp:BoundField DataField="BankID" HeaderText="Bank ID" HeaderStyle-BackColor="Gray"
                                                    ReadOnly="true" />
                                                <asp:BoundField DataField="BankName" HeaderText="Name of Bank" HeaderStyle-BackColor="Gray"
                                                    ReadOnly="true" />
                                                <asp:BoundField DataField="Address" HeaderText="Address of Branch" HeaderStyle-BackColor="Gray"
                                                    ReadOnly="true" />
                                                <asp:BoundField DataField="AccountNo" HeaderText="Account Number" HeaderStyle-BackColor="Gray"
                                                    ReadOnly="true" />
                                                <asp:BoundField DataField="AccountType" HeaderText="Account Type" HeaderStyle-BackColor="Gray"
                                                    ReadOnly="true" />
                                                <asp:BoundField DataField="IFSCCode" HeaderText="IFSC Code" HeaderStyle-BackColor="Gray"
                                                    ReadOnly="true" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CommandArgument='<%#Eval("BankID") %>'
                                                            ValidationGroup="kk"><img src="../images/edit%20new.png" alt="edit" height="25px" /></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="Gray" />
                                                    <HeaderTemplate>
                                                        Edit
                                                    </HeaderTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Del" CommandArgument='<%#Eval("BankID") %>'
                                                            ValidationGroup="kk"><img src="../images/deletenew.png" alt="edit" height="25px" /></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="Gray" />
                                                    <HeaderTemplate>
                                                        Delete
                                                    </HeaderTemplate>
                                                </asp:TemplateField>
                                                <%--    <asp:TemplateField>
                              <EditItemTemplate>
                              <asp:TextBox ID="txtBank1" runat="server" Text='<%#("Name of Bank") %>'></asp:TextBox>
                              
                              </EditItemTemplate>
                              <EditItemTemplate>
                               <asp:TextBox ID="txtBranch1" runat="server" Text='<%#("Address of Branch") %>'></asp:TextBox>
                              </EditItemTemplate>
                               <EditItemTemplate>
                               <asp:TextBox ID="txtAccount1" runat="server" Text='<%#("Account Number") %>'></asp:TextBox>
                              </EditItemTemplate>
                               <EditItemTemplate>
                               <asp:TextBox ID="txtAccountType1" runat="server" Text='<%#("Account Type") %>'></asp:TextBox>
                              </EditItemTemplate>
                               <EditItemTemplate>
                               <asp:TextBox ID="txtIFSC1" runat="server" Text='<%#("IFSC Code") %>'></asp:TextBox>
                              </EditItemTemplate>
                              </asp:TemplateField>--%>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <%--<p style="text-align:right;">--%>
                              
                                </ContentTemplate>
                            <%--<Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnInsert" EventName="Click" />
                            </Triggers>--%>
                        </asp:UpdatePanel>
                        <p style="text-align:right"><input type="button" value="Back" class="radius button" onclick="nextTab('a_Addr','0');" style="font-weight:bold" />
                                <asp:Button ID="btnInsert" runat="server" Text="Save" OnClientClick="return validate();"
                                    OnClick="Button1_Click1" class="radius button" Font-Bold="true" formnovalidate />
                          <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="radius button" style="font-weight:bold" /></p>
                          
                              
                                     <%--<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlPopup" TargetControlID="btnInsert" BackgroundCssClass="modalBackground" CancelControlID="btnClose">
    </ajaxToolkit:ModalPopupExtender>--%>
                                <%--</p>--%>
                                <div class="row" style="display: none">
                                    <div class="large-4 columns">
                                        <asp:Label ID="lblESC" runat="server" Text="ECS (Y/N)"></asp:Label>
                                    </div>
                                    <div class="large-4 columns">
                                        <asp:DropDownList ID="ddlESC" runat="server" class="form-control">
                                            <asp:ListItem Selected="True">Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="large-4 columns">
                                    </div>
                                </div>
                                <div class="row" style="display: none">
                                    <div class="large-4 columns">
                                        <asp:Label ID="lblRefund" runat="server" Text="Refund Method"></asp:Label>
                                    </div>
                                    <div class="large-4 columns">
                                        <asp:DropDownList ID="ddlRefund" runat="server" class="form-control">
                                            <asp:ListItem>By Cheque</asp:ListItem>
                                            <asp:ListItem Selected="True">Direct Deposit</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="large-4 columns">
                                    </div>
                                </div>
                            
                    </div>
                    <br />
             <%--       <div id="sectiond" class="tab-pane fade">




<div class="row">
<div class="large-6 columns">
 <asp:Label ID="Label24" runat="server" Text="Business Nature"></asp:Label>
</div>
<div class="large-6 columns">
<asp:DropDownList ID="ddlBNHUF" runat="server" Height="38px" Width="200px">
                                                            <asp:ListItem>Manufacturing</asp:ListItem>
                                                            <asp:ListItem>Trading</asp:ListItem>
                                                            <asp:ListItem>Manufacturing-cum-Trading</asp:ListItem>
                                                            <asp:ListItem>Services</asp:ListItem>
                                                            <asp:ListItem>Profession</asp:ListItem>
                                                            <asp:ListItem>Other</asp:ListItem>
                                                        </asp:DropDownList>
</div>
</div>

<div class="row">
<div class="large-6 columns">
<asp:Label ID="Label23" runat="server" Text="AO Code/Area Code" ></asp:Label>
</div>
<div class="large-6 columns">
<asp:TextBox ID="txtWardHUF" runat="server" Height="38px" Width="200px"></asp:TextBox>
</div>
</div>
<br />
<div class="row">
<div class="large-6 columns">
     <asp:CheckBox ID="CheckBox3" runat="server" Text="Change in Jurisdiction" />
</div>
<div class="large-6 columns">
 <asp:CheckBox ID="CheckBox4" runat="server" Text="Is there a permanent establishment in India"
                                                             />
</div>
</div>
                  

<div class="row">
                          
                                <div class="large-3 columns">
                                    Nature of Business:
                                </div>
                                <div class="large-3 columns">
                                    TradeName:
                                </div>
                                <div class="large-3 columns">
                                    TradeName:
                                </div>
                                <div class="large-3 columns">
                                    TradeName:
                                </div>
                            </div>
                     
                        <div class="row">
                           
                                <div class="large-3 columns">
                                    <asp:DropDownList ID="ddBusiness" runat="server" onchange="enableIt(this);" Width="171px">
                                    </asp:DropDownList>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade1" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade2" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade3" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                           
                        </div>
                        <div class="row">
                           
                                <br />
                                <div class="large-3 columns">
                                    <asp:DropDownList ID="ddBusiness2" runat="server" onchange="enableIt(this);" Width="171px">
                                    </asp:DropDownList>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade11" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade22" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade33" runat="server" disabled="disabled"></asp:TextBox>
                              
                            </div>
                        </div>
                        <div class="row">
                            
                                <br />
                                <div class="large-3 columns">
                                    <asp:DropDownList ID="ddBusiness3" runat="server" onchange="enableIt(this);" Width="171px">
                                    </asp:DropDownList>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade111" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade222" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade333" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                         
                        </div>
</div>--%>
                    <%--<div id="sectiond" class="tab-pane fade">
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="Label49" runat="server" Text="TAN"></asp:Label></div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtTAN" runat="server"  Placeholder="TAN" Width="313px" Height="34px" style="text-transform:uppercase"></asp:TextBox>
                                <asp:RegularExpressionValidator ErrorMessage="Invalid TAN" ControlToValidate="txtTAN" ValidationExpression="[A-Z][A-Z][A-Z][A-Z]\d\d\d\d\d[A-Z]" 
                                    runat="server" />
                            </div>
                             <div class="large-4 columns"></div>
                        </div>
                       
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="Label13" runat="server" Text="Type of Assessee"></asp:Label></div>
                            <div class="large-4 columns">                            
                                <asp:DropDownList ID="ddlAssesseeType" runat="server" >
                                    <asp:ListItem>Individual</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                             <div class="large-4 columns"></div>
                        </div>
                     
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="Label10" runat="server" Text="Residential Status" ></asp:Label><span style="color:Red">*</span></div>
                            <div class="large-4 columns">
                                <asp:DropDownList ID="ddlResStatus" runat="server" >
                                    <asp:ListItem>Resident</asp:ListItem>
                                    <asp:ListItem>Non-Resident</asp:ListItem>
                                    <asp:ListItem>Not-Ordinarily Resident</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                             <div class="large-4 columns"></div>
                        </div>                      
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="Label11" runat="server" Text="AO Code/Area Code" ></asp:Label></div>
                            <div class="large-4 columns">
                                <asp:TextBox ID="txtWard" runat="server" class="form-control" Width="313px" MaxLength="75" Height="34px" placeholder="AO Code/Area Code"></asp:TextBox>
                            </div>
                             <div class="large-4 columns"></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-4 columns">
                                <asp:Label ID="Label7" runat="server" Text="Business Nature"></asp:Label></div>
                            <div class="large-4 columns">
                                <asp:DropDownList ID="ddlBussNature" runat="server">
                                    <asp:ListItem>Manufacturing</asp:ListItem>
                                    <asp:ListItem>Trading</asp:ListItem>
                                    <asp:ListItem>Manufacturing-cum-Trading</asp:ListItem>
                                    <asp:ListItem>Services</asp:ListItem>
                                    <asp:ListItem>Profession</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                             <div class="large-4 columns"></div>
                        </div>
                        <br />
                        <asp:UpdatePanel ID="uppnl" runat="server">
                        <ContentTemplate>
                          <div class="row">
                       <div class="large-4 columns">
                       Do you have Aadhar Card???
                       </div>
                       <div class="large-4 columns">
                       <asp:DropDownList ID="ddlAadhar" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAadhar_SelectionChanged">
                       <asp:ListItem>No</asp:ListItem>
                       <asp:ListItem>Yes</asp:ListItem>
                       </asp:DropDownList>
                       </div>
                       <div class="large-4 columns">
                       </div>
                       </div>
                       <br />
                       <div class="row" id="divAadhar" runat="server" visible="false">
                       <div class="large-4 columns">
                       Enter your Aadhar No.
                       </div>
                       <div class="large-4 columns">
                       <asp:TextBox ID="txtAadhar" runat="server" Width="313px"></asp:TextBox>
                       </div>
                       <div class="large-4 columns"></div>
                       </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                     
                        <div class="row" style="display:none">
                            <div class="large-4 columns" class="checkbox">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Change in Jurisdiction" /></div>
                            <div class="large-4 columns" class="checkbox">
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="Is there a permanent establishment in India" /></div>
                                <div class="large-4 columns"></div>
                        </div>
                        <br />
                     <%--   <div class="row">
                            <div class="large-6 columns">
                                No. Of Dependents:</div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtNoOfDependents" runat="server" class="form-control">
                                </asp:TextBox></div>
                        </div>
                        <div class="row">
                            
                                <div class="large-3 columns">
                                    Nature of Business:
                                </div>
                                <div class="large-3 columns">
                                    TradeName:
                                </div>
                                <div class="large-3 columns">
                                    TradeName:
                                </div>
                                <div class="large-3 columns">
                                    TradeName:
                                </div>
                        
                        </div>
                        <div class="row">
                          
                                <br />
                               
                                <div class="large-3 columns">
                                    <asp:DropDownList ID="ddBusiness" runat="server" onchange="enableIt(this);" Width="179px">
                                    </asp:DropDownList>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade1" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade2" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade3" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                          
                        </div>
                        <div class="row">
                         
                                <br />
                                <div class="large-3 columns">
                                    <asp:DropDownList ID="ddBusiness2" runat="server" onchange="enableIt(this);" Width="179px">
                                    </asp:DropDownList>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade11" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade22" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade33" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                  </div>
                        <div class="row">
                          
                                <br />
                                <div class="large-3 columns">
                                    <asp:DropDownList ID="ddBusiness3" runat="server" onchange="enableIt(this);" Width="179px">
                                    </asp:DropDownList>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade111" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade222" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                                <div class="large-3 columns">
                                    <asp:TextBox ID="txtTrade333" runat="server" disabled="disabled"></asp:TextBox>
                                </div>
                          
                        </div>
                    </div>--%>
                    <div id="sectione" class="tab-pane fade">
                        <asp:UpdatePanel ID="updatepanel_SectionE" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="large-4 columns">
                                        <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label><span style="color: Red">*</span></div>
                                    <%--<asp:RadioButton ID="rdoRepresentative" runat="server" GroupName="grpSignatory" Text="Representative"
                                    onchange="SelectSignatory();" />--%>
                                    <div class="large-4 columns">
                                        <%--<asp:RadioButton ID="rdoSelf" runat="server" GroupName="grpSignatory" Text="Self"
                                    onchange="SelectSignatory();" />--%>
                                        <asp:DropDownList ID="ddSignType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddSignType_SelectedIndexChanged">
                                            <asp:ListItem Text="Self" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Representative" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="large-4 columns">
                                    </div>
                                </div>
                                <br />
                                <div class="row" id="pnlRepresentative">
                                    <div class="large-4 columns">
                                        <asp:Label ID="Label6" runat="server" Text="Name"></asp:Label><span style="color: Red">*</span></div>
                                    <div class="large-4 columns">
                                        <asp:TextBox ID="txtNameRep" runat="server" Class="form-control" placeholder="Name"
                                            MaxLength="125" Enabled="false"></asp:TextBox>
                                        <%--  <asp:RequiredFieldValidator  ID="RQ1" runat="server" ControlToValidate="txtNameRep" ErrorMessage="Please fill your name in Authorised Signatory"></asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="large-4 columns">
                                    </div>
                                </div>
                                <div class="row" id="pnlAuthorised">
                                    <div class="large-4 columns">
                                        <asp:Label ID="Label26" runat="server" Text="Father Name"></asp:Label><span style="color: Red">*</span></div>
                                    <div class="large-4 columns">
                                        <asp:TextBox ID="txtFNameAu" runat="server" class="form-control" placeholder="Father Name"
                                            MaxLength="125" Enabled="false"></asp:TextBox>
                                        <%--   <asp:RequiredFieldValidator  ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtFNameAu" ErrorMessage="Please fill father name in Authorised Signatory" Display="None"></asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="large-4 columns">
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="large-4 columns">
                                        <asp:Label ID="Label15" runat="server" Text="PAN"></asp:Label></div>
                                    <div class="large-4 columns">
                                        <asp:TextBox ID="txtPANRep" runat="server" class="form-control" placeholder="PAN"
                                            Style="text-transform: uppercase" Enabled="false"></asp:TextBox>
                                        <%--<asp:RegularExpressionValidator ID="txtPANRepvalid" runat="server" ControlToValidate="txtPANRep" ErrorMessage="Please Fill Correct PAN" ValidationExpression="^[\w]{3}(p|P|c|C|h|H|f|F|a|A|t|T|b|B|l|L|j|J|g|G)[\w][\d]{4}[\w]$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                    <div class="large-4 columns">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="large-4 columns">
                                        <asp:Label ID="Label16" runat="server" Text="Designation"></asp:Label></div>
                                    <div class="large-4 columns">
                                        <asp:TextBox ID="txtDesignationRep" runat="server" class="form-control" placeholder="Designation"
                                            MaxLength="25" Enabled="false"></asp:TextBox></div>
                                    <div class="large-4 columns">
                                    </div>
                                </div>
                                <%-- <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label17" runat="server" Text="Place"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtPlaceRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label20" runat="server" Text="Flat"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtFlatRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label21" runat="server" Text="Premises"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtPremisesRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label22" runat="server" Text="Road"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtRoadRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label27" runat="server" Text="Area"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtAreaRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label29" runat="server" Text="City"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtCityRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label23" runat="server" Text="State"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:DropDownList ID="ddlStatesRep" runat="server" DataSourceID="ObjectDataSource2"
                                    DataTextField="StateName" DataValueField="StateCode" class="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label34" runat="server" Text="PIN"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtPINRep" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label24" runat="server" Text="Name"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtNameAu" runat="server" Class="form-control"></asp:TextBox></div>
                        </div>--%>
                                <br />
                                <br />
                                <%--    <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label28" runat="server" Text="Designation"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtDesignationAu" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label35" runat="server" Text="Place"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtPlaceAu" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label36" runat="server" Text="Date of Filing"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtDateAu" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label37" runat="server" Text="Ward/Circle/CIT"></asp:Label></div>
                            <div class="large-6 columns">
                                <asp:TextBox ID="txtWardAu" runat="server" class="form-control"></asp:TextBox></div>
                        </div>
                        <br />--%>
                                <%--</div>--%>
                                <div class="container">
                                    <div class="row">
                                        <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                                            <div id="validation_dialog" style="display: none">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                            <%--given id to div for popup nishu7/4/2014 --%>
                                            <div id="msg" style="display:none; max-height:80px; height:300px">
                                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True" Text="Label"
                                                    Visible="False"></asp:Label>
                                                <div style="display: none">
                                                    <asp:Button ID="btnSubmit_pop" runat="server" Text=" OK " />
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="container">
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 ">
                                <%--<asp:Button ID="Button1" runat="server" Text="Next" OnClientClick="nextTab();" class="radius button" Font-Bold="true" formnovalidate />--%>
                                
                                
                            </div>
                        </div>
                    </div>
                </div>
                <%--add footer nishu 10/4/2015 --%>
                <div class="row">
                    <div class="large-12 columns">
                    <hr />
                        
                            � 2015 Vatas Infotech Pvt.Ltd.
                    </div>
                </div>
                <%--        <div class="hide-for-small-only hide-for-medium-only" >
   <menu:side ID="Sidemenu" runat="server"  />
   </div>--%>
                <%--div for showing popup --%>
                <%--  <div id="dialog"></div>--%>
                <%-- <asp:VaidationSummary ID="VS" runat="server" ValidationGroup="gg" DisplayMode="SingleParagraph" ShowMessageBox="true" />--%>
                <div id="msg1" style="display: none;">
                 <asp:Panel ID="pnlPopup" runat="server">
                 <p>Information Added/Updated Sucessfully</p>
                  <asp:Button ID="btnClose" runat="server" Text="Cancel" CssClass="radius button"
                     Style="left: -66px; border-radius: 4px" />
                 </asp:Panel>
                </div>
                <div id="msg2" style="display:none">
                <p>Please Enter Bank Details </p>
                </div>
                <asp:HiddenField ID="hdnIsBank" runat="server" Value="" />
    </form>
</body>
</html>