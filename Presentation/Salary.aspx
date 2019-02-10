<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Salary.aspx.cs" Inherits="_Default"
    MaintainScrollPositionOnPostback="true" EnableViewState="true" %>

<%@ Register Src="../SubUserMenu_Employer.ascx" TagName="empmenu" TagPrefix="emp" %>
<%--<%@ Register Src="../SubUserMenu_Asset.ascx" TagName="property" TagPrefix="house" %>--%>
<%--<%@ Register Src="MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>--%>
<%@ Register Src="../UserControls/PopupControl.ascx" TagName="pop" TagPrefix="popup" %>
<%@ Register Src="../UserControls/ImportBalanceSheet.ascx" TagName="ImpBalance" TagPrefix="usr" %>
<%@ Register Src="~/UserControls/header.ascx" TagName="menuheader" TagPrefix="header" %>
<%@ Register Src="~/UserControls/menunew.ascx" TagName="menu" TagPrefix="mm" %>
<%-- Main Menu --%>
<%@ Register Src="~/Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="~/UserControls/FileUploadDirectoryCtrk.ascx" TagPrefix="fileupload"
    TagName="fu" %>
<%@ Register Src="~/UserControls/fileuploadDirCtrl_TDS.ascx" TagPrefix="fileupl_tds"
    TagName="fu" %>
<%@ Register Src="~/UserControls/WebUserControl.ascx" TagPrefix="fileupl_tds2" TagName="fu2" %>
<%--<%@ Register Assembly="DynamicButtons" Namespace="DynamicButtons" TagPrefix="DB" %>--%>
<%@ Register Assembly="DynamicButtons_Service" TagPrefix="DB" Namespace="DynamicButtons_Service" %>

<!DOCTYPE html >
<html class="no-js" lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
    <%--  <script type="text/javascript" src="Scripts/common.js"></script>--%>
    <%--  <script type="text/javascript" src="jquery.min.js"></script>--%>
    <script src="../js/ajax-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
	<script type="text/javascript" src="ButtonControlScripts.js"></script>
    <script src="Scripts/jquery_scripts.js" type="text/javascript"></script>
    <!--jsss-->
    <link href="gridstyle.css" rel="Stylesheet" type="text/css" />
    <title>Control Panel</title>
    <!--Master javascript file-->
    <%--<script src="../js/MasterJScript.js" type="text/javascript"></script>--%>
    <!--Master javascript file-->
    <!--master style sheet-->
    <link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="../foundation-5.5.0/js/foundation/foundation.js" type="text/javascript"></script>
    <link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />
    <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../ITRStylesheet/styles/tabstrip.js" type="text/javascript"></script>
    <%--<link href="../css/box_style.css" rel="stylesheet" type="text/css" />--%>
    <%-- <script src="../js/jquery-1.10.2.js" type="text/javascript"></script>--%>
    <%--    <script src="../Popup/jquery.min.js" type="text/javascript"></script>
    <script src="../Popup/jquery-ui.js" type="text/javascript"></script>
    <link href="../Popup/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
    <%-- Popup Code  --%>
    <%--<script src="../Popup/jquery.min.js" type="text/javascript"></script>
    <script src="../Popup/jquery-ui.js" type="text/javascript"></script>
    <link href="../Popup/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">


        $(document).ready(function () {
            //HideColumn('grdState', '3');
            if ($('#db1_Pnl_DynamicControlContainer').children().length == 0)
                $('#db1_Pnl_DynamicControlContainer').hide();

            $('#db1_Pnl_DynamicControlContainer').children().addClass('radius button')
            $('#db1_Pnl_DynamicControlContainer').removeAttr('style');
            //alert(document.getElementById('db1_Pnl_DynamicControlContainer').hasChildNodes());
            $('#cssmenu ul li').click(function () {
                //                alert('menu clicked');
                //                setTabPosition();
                document.getElementById('hdnsetback').value = '';
            });

            pop(); //To set Grid of popup setings
            CheckRowCheckBoxes(); //Popup Div Function
            Fileupload(); //function to provide event for "My Files" link
            OffautoComplete();

            if (document.getElementById('hdnVType').value != "") {
                // alert('val');
                HighlightSelectedMenu(document.getElementById('hdnVType').value)
                setTabPosition();
            }
            else {
                alert('not find');
                $('#cssmenu >ul>li').first().addClass('active');
            }
            MenuActive();
            Get_Menu_Status_Main();


            //$('#cssmenu >ul>li').first().addClass('active');
            //MenuActive();
            //            Get_Menu_Status();
            setTabPosition();
            //alert_custom('asd', 2, '', '', '', '', ['a', 'b']);
            //alert(document.URL.toString().indexOf('106'));
            if (document.URL.toString().indexOf('106') != -1)
                document.getElementById('ddMenu').style.display = 'none';
            else
                document.getElementById('ddMenu').style.display = 'block';

            $.fn.FunctionRemoveSpacing = function () {
                $('#grdState tr').each(function () {
                    $(this).find('td').each(function () {
                        //alert('hi');
                        $(this).css("margin", "0");
                        $(this).css("padding", "1px");
                        $(this).css("padding-left", "");
                        $(this).css('height', '39px');
                        $('#grdState th').css("padding-left", "");
                    });
                });
            }
            $.fn.FunctionRemoveSpacing();
            $('#Details').css("display", "none");
            $('#Details').slideDown();
            $('#ass').click(function () {
                //alert('1');
                $('#Details').slideToggle();
            });
            $("#divmobmenu").css("display", "none");
            $("#btnmenu").click(function () {
                $("#divmobmenu").slideToggle();
            });

        });

    </script>
    <script type="text/javascript">
        $(document).ready(function (evt) {
            $('#cbdb-menu_id a').each(function () {

                $('#cbdb-menu_id a').removeClass('active_new1');
                $(this).addClass('active_new1');


                $('#cbdb-menu_id a').removeClass('border_bot_new1');
                $(this).addClass('border_bot_new1');

                //                $('#cbdb-menu_id a').css(
                //                    "border-bottom", "1px solid black"
                //                    )

                //                $(this).css(
                //                    "border-bottom", "none",
                //                     "box-shadow", "none"
                //                    )

                evt.preventDefault();



            });
        });

        //for main menu on mobile:

       
    </script>
    <%-- <script type="text/javascript">
        $(document).ready(function ($) {
            //Removehr();
            $("#btnmenu").click(function () {
                $("#divmenu").slideToggle();
            });

        });
    </script>--%>
    <%--    to close validation error box--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#close_val_error').click(function () {
                $('#newdiv').css("display", "none");
            });
        });
    </script>
    <style type="text/css">
        #dd::-webkit-scrollbar-track
        {
            -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3);
            border-radius: 10px;
            background-color: #F5F5F5;
        }
        
        #dd::-webkit-scrollbar
        {
            width: 12px;
            background-color: #F5F5F5;
        }
        
        #dd::-webkit-scrollbar-thumb
        {
            border-radius: 10px;
            -webkit-box-shadow: inset 0 0 6px rgba(0,0,0,.3);
            background-color: #EF5845;
        }
        .cbdb-menu li
        {
            display: block;
            float: left;
            line-height: 1.3;
            list-style: none;
        }
        .amt
        {
            text-align:center;
            
        }
        .cbdb-menu li a
        {
            /* This generators the gradient on top of the solid color */
            color: #ffffff; /*background-color:#E7E1E1;*/
            background-color: #666666;
            float: left; /*background:transparent;*/
            display: block;
            font: bold 13px;
            font-size: 12px;
            margin-bottom: 5px;
            margin-right: 2px;
            font-family: 'Open Sans' , sans-serif;
            outline: none;
            padding: 4px 8px;
            border: 1px solid black;
            text-decoration: none;
            border-radius: 5px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.65);
            -moz-box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.65);
            -webkit-box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.65);
        }
        .cbdb-menu li a:hover
        {
            color: #ef5845;
            font-weight: bold;
        }
        .cbdb-menu_new1 li
        {
            display: block;
            float: left;
            line-height: 35px;
            list-style: none;
            margin: 1px;
            padding: 0;
        }
        .cbdb-menu_new1 li a
        {
            /* This generators the gradient on top of the solid color */
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            background-color: white;
            background: transparent;
            outline: none;
            display: block;
            font: 15px 'open-sans','sans-serif';
            outline: none;
            padding: 5px 15px;
            text-decoration: none; /*text-shadow: 1px 1px 1px rgba(0, 0, 0, 0.4);*/ /*box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.65);
	-moz-box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.65);
	-webkit-box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.65);*/
            margin-bottom: -4px;
            height: 40px;
            color:#494e6b;
        }
        
        .border_bot_new1
        {
            font-weight: bold;
            font-size: 18px;
            border-bottom: none;
            outline: none;
            height: 50px;
        }
        .active_new1
        {
            background-color: #cccccc;
            outline: none;
            height: 40px;
            border-bottom: none;
            box-shadow: none;
            border-bottom: 10px solid white;
            border-left: 1px solid black;
            border-right: 1px solid black;
            border-top: 1px solid rgb(19, 19, 18);
            color: gray;
            outline: none;
        }
    </style>
    <!--tab control css & javascript-sweeta-->
    <%--<script type="text/javascript">
        (document).ready(function () {
            ('a').each(function () {
                (this).click(function (evt) {
                    ('a').removeClass('active');
                    (this).addClass('active');
                    (this).removeClass('blue');
                    (this).removeClass('selected');
                    ('a').css(
                    "border-bottom", "1px solid black"
                    )
                    (this).css(
                    "border-bottom", "none",
                     "box-shadow", "none",
                     "height", "30px"
                    )
                    evt.preventDefault();
                    //                   
                })

            });
        });
        
    </script>--%>
    <link rel="icon" type="image/png" href="../images/fevicon.png" />
    <link rel="shortcut icon" type="image/png" href="../images/fevicon.png" />
    <style type="text/css">
        #hrnew
        {
            height: 1px;
            background-image: -webkit-linear-gradient(left, rgba(0, 0, 0, 1), rgba(0, 0, 0, 1), rgba(0, 0, 0, 1));
            background-image: -moz-linear-gradient(left, rgba(0, 0, 0, 1), rgba(0, 0, 0, 1), rgba(0, 0, 0, 1));
            opacity: 1.0;
            margin-top: -2px;
        }
        .spinner {
    position: fixed;
    top: 30%;
    left: 50%;
    margin-left: -50px; /* half width of the spinner gif */
    margin-top: -30px; /* half height of the spinner gif */
    text-align:center;
    z-index:1234;
    overflow: auto;
    width: 100px; /* width of the spinner gif */
    height: 102px; /*hight of the spinner gif +2px to fix IE8 issue */
}
    </style>
    <script type="text/javascript">

        $.validator.setDefaults({
            submitHandler: function () {
                alert("submitted!");
            }
        });
    </script>
    <%-- Code For Validations in JQuery --%>
    <%--<link href="../css/screen.css" rel="stylesheet" type="text/css" />
  <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/jquery.validate.js" type="text/javascript"></script>
 
    	<script type="text/javascript">
    	   
    	        $.validator.setDefaults({
    	            submitHandler: function () {
    	                alert("submitted!");
    	            }
    	        });
    --%>
    <%--  (document).ready(function () {
    	        // validate the comment form when it is submitted


    	        // validate signup form on keyup and submit
    	            ("#form1").validate({

    	            rules: {
    	                pan: {
    	                    required: true,
    	                    pan: true
    	                }
    	             
    	            }
    	        });
    	    });
	</script>--%>
    <%--
    <script src="../Presentation/jquery.min.js" type="text/javascript"></script>
           <script src="../js/jquery.ui.min.js" type="text/javascript"></script>
  
    <link href="../ITRStylesheet/styles/jquery-ui.css" rel="stylesheet" type="text/css" />--%>
    <%------------------------------Jquery Validation ------------------------------%>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <%--  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdn.ucb.org.br/Scripts/formValidator/js/languages/jquery.validationEngine-en.js"
        charset="utf-8"></script>
    <script type="text/javascript" src="http://cdn.ucb.org.br/Scripts/formValidator/js/jquery.validationEngine.js"
        charset="utf-8"></script>--%>
    <script src="../Validation/jquery.min.js" type="text/javascript"></script>
    <script src="../Validation/jquery.validationEngine-en.js" type="text/javascript"></script>
    <script src="../Validation/jquery.validationEngine.js" type="text/javascript"></script>
    <%--------------function for validating inputs nishu 17/8/2015 ----------------------%>
    <%--<script type="text/javascript">

        $(function ($) {

            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded);
            function PageLoaded(sender, args) {
                //                                ("#btnContinueMaster").click(function () {
                var hdn = $("#hdnValidate").val();
                 //alert('hdn in jquery: ' + hdn);
                if (hdn == "true") {
                    //alert('1');
                    $("#form1").validationEngine('attach', { promptPosition: "topRight" });
                    // alert('loaded');
                    //                                });
                }
                else if (hdn == "false") {
                    $("#form1").validationEngine('hideAll');
                    $("#form1").validationEngine('detach');                    
                    $("#hdnValidate").val("true");
                }
            }

        });
    </script>--%>
    <%---------function for hide error prompts from page nishu 17/8/2015------------------%>
    <script type="text/javascript">
        $(function ($) {

            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded);
            function PageLoaded(sender, args) {
                $("#btnBackMaster").click(function () {
                    $("#hdnValidate").val("false");
                    //alert('hide');
                    $("#form1").validationEngine('detach');
                    $("#form1").validationEngine('hideAll');
                });
            }
        });
    </script>
    <script type="text/javascript">
        function DateFormat(field, rules, i, options) {
            var regex = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
            if (!regex.test(field.val())) {
                return "Please enter date in dd/MM/yyyy format."
            }
        }
        //        function BankAC(field, rules, i, options) {
        //            var regex = [a-zA-Z0-9]([/-]?(((\d*[1-9]\d*)*[a-zA-Z])|(\d*[1-9]\d*[a-zA-Z]*))+)*[0-9]*$|;
        //            if (!regex.test(field.val())) {
        //                return "Please enter valid A/c Number."
        //            }
        //        }
        function pan(field, rules, i, options) {
            var regex = /^[\w]{3}(p|P|c|C|h|H|f|F|a|A|t|T|b|B|l|L|j|J|g|G)[\w][\d]{4}[\w]$/;
            if (!regex.test(field.val())) {
                return "Please enter valid pan."
            }
        }
        function tan(field, rules, i, options) {
            var regex = /^[A-Z]{4}[1-9]{5}[A-Z]$/;
            if (!regex.test(field.val())) {
                return "Please enter valid Tan."
            }
        }
        function trp(field, rules, i, options) {

            var regex = /^([T][0-9]{9}|[0-9]{6})$/;
            if (!regex.test(field.val())) {
                return "Please enter valid TRP Pin."
            }
        }
        function IFSC(field, rules, i, options) {
            var regex = /^[A-Za-z]{4}[0][A-Z0-9]{6}$/;
            if (!regex.test(field.val())) {
                return "Please enter valid IFSC Code."
            }
        }
    </script>
    <%--------------------------------on Continue button click go to next tab  ----------------------------------------------%>
    <%--    <script type="text/javascript">
         (document).ready(function () {
             ('#btnContinueMaster').click(function () {
                 var i = 1;
                 ('#aTab_' + i).trigger("click");
                 i = i + 1;
                 return false;


             });
         });
        </script>--%>
    <%--   <script type="text/javascript">
                  (document).ready(function () {
                      ('#aTab_0').click(function () {
                          ('#btnSaveMasterData').css
                     ("display", "none")
                      });
                  });
         </script>
         <script type="text/javascript">
             (document).ready(function () {
                 ('#aTab_1').click(function () {
                     ('#btnSaveMasterData').css
                     ("display", "none")

                 });
             });
         </script>--%>
    <%--This fn is used to show msg as pop for add/update sucessfully --%>
    <%-- <script type="text/javascript">
     function ShowPopup(message) {
         (function () {
             ("#msg").html(message);
             ("#msg").dialog({
                 title: "Assessee Information",
                 buttons: {
                     OK: function () {
                         window.location = "Main.aspx"

                     },
                     Close: function () {
                         (this).dialog('close');
                     }
                 },
                 modal: true
             });
         });
     };

//     function showPopupEvent() {    //for showing popup for Signatory Details - 30-6-15
//         document.getElementById('Button5').click();
//     }
</script>
    --%>
    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btn1").click(function () {
                try {
                    $("#divPop").dialog({
                        title: 'Are You Sure',
                        width: 'auto',
                        height: 'auto',
                        minHeight: '0',
                        modal: true,
                        buttons: { Yes: function () {
                            window.location = "SignatoryDetails.aspx"
                        }
                            //                         ,
                            //                            No: function () {
                            //                                 (this).dialog('close');
                            //                             }
                        }
                    });
                }
                catch (e) { alert(e); }
            });

        });
    </script>
    <%--   <script type="text/javascript">

         (document).ready(function ($) {
             ('#btnSaveMasterData').click(function () {
                 var hv = ("#" + '<%= hdnIsSave.ClientID %>').val();
                 //               alert(hv);
                 if (hv == "Data Saved") {

                     //                   function showmodalpopup($) {
                     ("#popupdiv").dialog({
                         title: "jQuery Popup from Server Side",
                         width: 430,
                         height: 250,
                         modal: true,
                         buttons: { OK: function () {
                             window.location = "Main.aspx"

                         },
                             Close: function () {
                                 (this).dialog('close');
                             }
                         }
                     });
                     //                   };
                 }
                 else {
                     ("#popupdiv").dialog('close');
                     //alert("Data not saved");
                 }
             });
             Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded);
             function PageLoaded(sender, args) {
                 alert('abc');
                 ('#btnSaveMasterData').click(function () {
                     var hv = ("#" + '<%= hdnIsSave.ClientID %>').val();

                     if (hv == "DataSaved") {
                         //                       alert(hv);
                         //                       function showmodalpopup($) {
                         ("#popupdiv").dialog({
                             title: "jQuery Popup from Server Side",
                             width: 430,
                             height: 250,
                             modal: true,
                             buttons: { OK: function () {
                                 window.location = "Main.aspx"

                             },
                                 Close: function () {
                                     (this).dialog('close');
                                 }
                             }
                         });
                         //                       };
                     }
                     else {
                         ("#popupdiv").dialog('close');
                     }
                 });
             }
         });

         function openDialogXML() {
             try {
                 getConstVal(document.getElementById('hdnNameID').value, 1120);
                 document.getElementById('btn1').click();
             }
             catch (e) { alert(e); }
         }
</script>--%>
    <%--<script type="text/javascript">
    (document).ready(function ($) {
        ("[id*=Button5]").live("click", function () {
            ("#dialog_Signatory").dialog({
                title: "Signatory Details",
                
                modal: true
            });
            return false;
        });
    });

    function showPopupEvent() {
        document.getElementById('Button5').click();
    }
</script>--%>
    <%----------------on click on second tab check validation of first tab --------------------------%>
    <%--<script type="text/javascript">
    (document).ready(function () {

        ("#aTab_1").click(function () {

                        var valid = true;
                        var i = 0;
                        ('input[type="text"]').each(function (event) {
                            if ($.trim((this).val()) == '') {
                                valid = false;

                                ('#aTab_0').trigger("click");

                                (this).focus();



                            }
                        });

                        if (valid) {
                            alert('hello');
                        }



                    });
                    var parameter = Sys.WebForms.PageRequestManager.getInstance();

                    parameter.add_endRequest(function () {
                        ("#aTab_1").click(function () {

                            var valid = true;
                            var i = 0;
                            ('input[type="text"]').each(function (event) {
                                if ($.trim((this).val()) == '') {
                                    valid = false;

                                    ('#aTab_0').trigger("click");

                                    (this).focus();



                                }
                            });

                            if (valid) {
                                alert('hello');
                            }



                        });
                    });
        
       
    });
    </script>
    <script type="text/javascript">
        (document).ready(function () {
            ("#aTab_2").click(function () {

                var valid = true;
                var i = 0;
                ('input[type="text"]').each(function (event) {
                    if ($.trim((this).val()) == '') {
                        valid = false;

                        ('#aTab_0').trigger("click");

                        (this).focus();



                    }
                });

                if (valid) {
                    alert('hello');
                }



            });
            var parameter = Sys.WebForms.PageRequestManager.getInstance();

            parameter.add_endRequest(function () {
                ("#aTab_2").click(function () {

                    var valid = true;
                    var i = 0;
                    ('input[type="text"]').each(function (event) {
                        if ($.trim((this).val()) == '') {
                            valid = false;

                            ('#aTab_0').trigger("click");

                            (this).focus();



                        }
                    });

                    if (valid) {
                        alert('hello');
                    }

                });

            });
        });
    </script>
    <script type="text/javascript">
        (document).ready(function () {
            ("#aTab_3").click(function () {

                var valid = true;
                var i = 0;
                ('input[type="text"]').each(function (event) {
                    if ($.trim((this).val()) == '') {
                        valid = false;

                        ('#aTab_2').trigger("click");

                        (this).focus();



                    }
                });

                if (valid) {
                    alert('hello');
                }



            });
        });
    </script>--%>
    <%---------------------Tab index -------------------------%>
    <%-- <script type="text/javascript">
        (document).ready(function (e) {
            (":input").each(function (i) { (this).attr('tabindex', i + 1); });
            alert(i);
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded);
            function PageLoaded(sender, args) {
                (":input").each(function (i) { (this).attr('tabindex', i + 1); });
                alert(i);
            }

        });
    </script>--%>
    <%---------------------Tooltip Grid -------------------------%>
    <link href="../css/tooltip.css" rel="stylesheet" type="text/css" />
    <%--<script type="text/javascript">
       (document).ready(function ($) {
           //alert('asd');

           try {
               var prm = Sys.WebForms.PageRequestManager.getInstance();
               if (prm != null) {
                   prm.add_endRequest(function (sender, e) {
                       if (sender._postBackSettings.panelsToUpdate != null) {

                           ("#<%=grdState.ClientID %>").find("input[type=text][id*=txtAmount]").each(function () {
                               ("#<%=grdState.ClientID %>").find("input[type=text][id*=txtAmount]").onkeypress(function () {
                                   //alert('focus');
                                   try {
                                       (this).focus();
                                   }
                                   catch (e) {
                                       document.write(e.ToString()); // alert(e);
                                   }
                               });
                           });
                       }
                   });
               };
           }
           catch (e) {
               document.write(e.ToString());
               //alert(e);
           }
       });
   </script>--%>
    <script type="text/javascript">
        var IsHideDetail = '';   //Variable to show/hide the detail button
        var val1 = '';
        function loadPage() {//alert(scriptsAll);
            //setTimeout(scriptsAll, 100);     //this function calls the batch of all function those are set in the T00_Rules for the main grid
        }

        function openDialogXML() {
            try {
                getConstVal(document.getElementById('hdnNameID').value, 1120);
                document.getElementById('btn1').click();
            }
            catch (e) { alert(e); }
        }
        //To Show Hide the Detail Button on Dropdown Change (ConstantID)
        function showhideLinkBtn(id) {
            //alert(id);
            try {
                var vv = new String();
                vv = id.id;
                //vv = id;
                vv = vv.substring(0, (vv.length - 4)) + 'btnLink';
                if (id.value == 2 || id.value == 0) {
                    document.getElementById('hdnControlHide').value = vv + '~hide';
                    document.getElementById(vv).style.display = 'none';
                    return false;
                }
                else {
                    document.getElementById(vv).style.display = 'block';
                    document.getElementById('hdnControlHide').value = vv + '~show';
                    return true;
                }
            } catch (e) { alert(e); }
        }

        function showHideRow(id, label_title) {

            try {
                var IfExists = '';
                $(document).ready(function () {
                    $("#grdState tr").each(function () {
                        $(this).children("td:nth-child(2)").each(function () {
                            if ($(this).html().toString().indexOf('>' + label_title) > 0)
                                IfExists = 'true';
                            //alert($(this).html());
                            //alert($(this).attr("id"));
                        });
                        if (IfExists != '') {
                            if ($("#" + id.id).find("option:selected").text() == 'No')
                                $(this).hide();
                            else
                                $(this).show();
                        }
                        IfExists = '';
                        //alert($(this).find("#grdState_ctl13_lblParticulars").text());
                        //$(this).hide();
                    });
                });
                return true;
            } catch (e) { alert(e); }
        }
    </script>
    <script type="text/javascript" src="Scripts/jquery_scripts.js"></script>
    <%--<script type='text/javascript'>       function scriptsAll() { try { alert('scripts all'); showhideLinkBtn(document.getElementById('grdState_ctl12_ddl1')); } catch (e) { alert(e) } }</script>--%>
    <asp:Literal ID="ltScript" runat="server"></asp:Literal>
    <style type="text/css">
        ::-webkit-input-placeholder {
   color: Gray;
}

:-moz-placeholder { /* Firefox 18- */
   color: Gray;  
}

::-moz-placeholder {  /* Firefox 19+ */
   color: Gray;  
}

:-ms-input-placeholder {  
   color: Gray;  
}
.err_cls::-webkit-input-placeholder {
    color:Red;
}
.err_cls::-moz-placeholder { /* Firefox 18- */
   color: Red;  
}

.err_cls::-moz-placeholder {  /* Firefox 19+ */
   color: Red;  
}

.err_cls::-ms-input-placeholder {  
   color: Red;  
}
    </style>
</head>
<body onload="loadPage();" style="width: 100%; height: 100%;">
    <%--  onunload="HandleClose(0)">--%>
    <form id="form1" runat="server" style="width: 100%; height: 100%;">
    <input type="button" value="click me" id="btn1" style="display: none;" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" ScriptMode="Release">
    </asp:ScriptManager>
    <%--<script type="text/javascript">
        // It is important to place this JavaScript code after ScriptManager1
        var xPos, yPos;
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        function BeginRequestHandler(sender, args) {
            if ($get('pnlGrdState') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPos = $get('pnlGrdState').scrollLeft;
                yPos = $get('pnlGrdState').scrollTop;
            }
        }

        function EndRequestHandler(sender, args) {
            if ($get('pnlGrdState') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('pnlGrdState').scrollLeft = xPos;
                $get('pnlGrdState').scrollTop = yPos;
            }
        }

        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
 </script>--%>
    <script type="text/javascript" language="javascript">
        function setDDLSelection(id) {//alert(id);
            try {
                var e = id;
                //                if (e.options[e.selectedIndex].value != "1")
                //                    document.getElementById('hdnDDListSelection').value = (parseInt(e.options[e.selectedIndex].value) - 1).toString();
                //                else
                //document.getElementById('hdnDDListSelection').value = e.options[e.selectedIndex].value;
                document.getElementById('hdnDDListSelection').value = e.selectedIndex.toString();
                //alert(document.getElementById('hdnDDListSelection').value);
            }
            catch (e) { alert(e); }
        }
        var spinnerElement;
        var xPos, yPos;


        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {

        }
        //following event is being used as the last event after page loaded for updatepanel asynchronous events
        function EndRequestHandler(sender, args) {
            try {
                //To reset the Dynamic Buttons CSS 
                if ($('#db1_Pnl_DynamicControlContainer').children().length == 0)
                    $('#db1_Pnl_DynamicControlContainer').hide();

                $('#db1_Pnl_DynamicControlContainer').children().addClass('radius button')
                $('#db1_Pnl_DynamicControlContainer').removeAttr('style');

                //HideColumn('grdState', '3');
                pop(); //To set Grid of popup setings
                CheckRowCheckBoxes(); //Popup Div Function
                Fileupload();
                hideSpinner();
                MenuActive();
                Get_Menu_Status_Main();   //To Enable Menu Selection State
                $('#cssmenu ul li').click(function () {
                    document.getElementById('hdnsetback').value = '';
                });
                RemoveT4_Row_Space();
                if (document.getElementById('hdnMsg').value != '') {
                    //alert(document.getElementById('hdnMsg').value);
                    alert_custom(document.getElementById('hdnMsg').value, 2, 'Error Message', '', '', '', ['OK', 'Cancel'], 200, 300);
                    document.getElementById('hdnMsg').value = '';
                }

                if (document.getElementById('hdnVType1').value == '49' && document.getElementById('hdnTaxStatus').value == 'TP')
                    document.getElementById('Button16').click();

                //Removehr();
                tab();
                if (ctrlVal != null && ctrlVal != '')
                    document.getElementById(ctrlName).value = ctrlVal;

                if (ctrlToDisable != null && ctrlToDisable != '') {
                    //alert(ctrlToDisable);
                    var arrCtrls = new Array();
                    arrCtrls = ctrlToDisable.split(',');
                    for (var i = 0; i < arrCtrls.length; i++)
                        document.getElementById(arrCtrls[i]).disabled = true;
                }
                try {
                    $.fn.FunctionRemoveSpacing();
                }
                catch (e) { }

                if (document.getElementById("hdnControlHide") != null) {
                    if (document.getElementById("hdnControlHide").value != null) {
                        if (document.getElementById("hdnControlHide").value.toString() != '') {
                            var arrData = document.getElementById("hdnControlHide").value.toString().split('~');
                            if (arrData[1] == 'hide') {
                                if ($(document).find(arrData[0]).length > 0)
                                    document.getElementById(arrData[0]).style.display = 'none';
                            }
                            else
                                document.getElementById(arrData[0]).style.display = 'block';
                        }
                    }
                }
                Remove();
                Removeplusimage_menu();
                Remove();
                RemoveArrows();

                //                $("#btnmenu").click(function () {

                //                    $("#divmenu").slideToggle();
                //                });
                Remove();
                $('#Details').css("display", "block");
                $('#ass').click(function () {
                    $('#Details').slideToggle();
                });
                if ($('#numWrap li').length == 0) {
                    RemovelftrgtArrows();
                }

                //alert(document.getElementById('hdnVType1').value);
                //code to call selected index of ddlSelect when Continue Button is clicked with TAB in VTYPE
                if (document.getElementById('hdnVTypeStatus').value != '') {

                    if (document.getElementById('hdnVType1').value.indexOf('.aspx') != -1) {
                        redirectToMain();
                    }
                    //if (document.getElementById('hdnVType').value.toString().indexOf('_') != -1) {
                    if (document.getElementById('hdnVTypeStatus').value == '1') {
                        if (document.getElementById('hdnVType1').value.indexOf('_') != -1) {
                            btnCont_Click();
                        }
                    }
                    else if (document.getElementById('hdnVTypeStatus').value == '2')
                        btnBack_Click();



                    //}
                    //document.getElementById('ddlSelect').selectedIndex = document.getElementById('ddlSelect').selectedIndex + 1;
                    //alert('pageload _ ' + document.getElementById('hdnVType1').value);
                    //                    if (document.getElementById('hdnVType1').value == '40')
                    //                        MenuState = 'Salary';
                    //                    else if (document.getElementById('hdnVType1').value == '42')
                    //                        MenuState = 'House Property';
                    //                    else if (document.getElementById('hdnVType1').value == '44')
                    //                        MenuState = 'Other Sources';
                    //                    else if (document.getElementById('hdnVType1').value == '46')
                    //                        MenuState = 'Deductions';
                    //                    else if (document.getElementById('hdnVType1').value == '48')
                    //                        MenuState = 'Exempt Income';
                    //                    else if (document.getElementById('hdnVType1').value == '104')
                    //                        MenuState = 'Tax Details';
                    //                    else if (document.getElementById('hdnVType1').value == '15021')
                    //                        MenuState = 'Schedule AL';

                    //                    if (document.getElementById('hdnVType1').value.indexOf('_') == -1) {
                    //                        MenuMovement = '1';
                    //                        Get_Menu_Status();
                    //                    }
                    //                    else
                    //                        MenuMovement = '';

                    //alert('menu state in common ' + MenuState);
                    //                    alert('in cont');

                    //                    SetMenuStatus();
                    //                    MenuMovement = '1';
                    //                    Get_Menu_Status();
                    //alert('continue');
                    //For Continue Back Buttons :
                    if (document.getElementById('hdnVTypeStatus').value == '1') {
                        if (document.getElementById('hdnVType').value == "") {
                            Get_Menu_Status(1);
                        }
                        //HighlightSelectedMenu(document.getElementById('hdnVType').value);
                        setTabPosition();
                        document.getElementById('hdnVTypeStatus').value = '';
                        document.getElementById('hdnsetback').value = '';
                    }
                    else if (document.getElementById('hdnVTypeStatus').value == '2') {
                        Get_Menu_Status(2);
                        document.getElementById('hdnVTypeStatus').value = '';
                        document.getElementById('hdnsetback').value = '2';
                        setTabPosition();
                    }
                    //document.getElementById('hdnVTypeStatus').value = '';
                    //setTabPosition(); //to manage cursor and take it to the first textbox/dropdown control

                    //SetMenuStatus();
                }
                if (document.getElementById('hdnsetback').value == '2') {
                    Get_Menu_Status(2);
                }

                if (typeof IsFormValidate_Float !== 'undefined') {
                    //alert('IsFormValidate_Float');
                    //setCursorFloatgrd();
                }

                if (document.getElementById('hdnCtrlTabIndx').value != '') {

                    //                        document.getElementById(document.getElementById('hdnCtrlTabIndx').value).focus();
                    //alert(document.getElementById(document.getElementById('hdnCtrlTabIndx').value).id);
                    //setTimeout(ctrlFocus, 100);
                }
                document.getElementById('hdnCtrlTabIndx').value = '';


                //$('#btnCont_Inp').click(function () {
                // alert('continue');



                //});
                setfield();

                //alert(document.getElementById('hdnSet_Tab').value);
                //alert('fine up to here3');
                if (document.getElementById('hdnSet_Tab').value == 'true') {
                    setTabPosition();
                    document.getElementById('hdnSet_Tab').value = '';
                }

                if (document.getElementById('hdnVType').value != "") {
                    // alert(document.getElementById('hdnVType').value);
                    HighlightSelectedMenu(document.getElementById('hdnVType').value)
                }
                //alert('end requestr end');

                //Upload Ctrl Popup on Detail Click:
                if (document.getElementById('hdnUploadPnl').value != '') {
                    openDialog2();
                    document.getElementById('hdnUploadPnl').value = '';
                }
                //error code here
            }
            catch (e) { alert('error in EndRequestHandler : ' + e); }
        }

        function ctrlFocus() {
            try {
                if (document.getElementById('hdnCtrlTabIndx').value != '') {
                    var Element = document.activeElement;
                    //get done on / split---should have diff of 1
                    var arr1 = Element.id.toString().split('_');

                    var arr2 = document.getElementById('hdnCtrlTabIndx').value.toString().split('_');
                    var num1 = parseInt(arr1[1].substring(3, arr1[1].toString().length));
                    var num2 = parseInt(arr2[1].substring(3, arr1[1].toString().length));
                    //alert('num1 : ' + num1);
                    if (num1 == (num2 + 1)) {

                    }
                    else {
                        //alert('setting focus');
                        //alert('Element.id : ' + Element.id);
                        //alert(document.getElementById(document.getElementById('hdnCtrlTabIndx').value));
                        document.getElementById(document.getElementById('hdnCtrlTabIndx').value).focus();
                    }
                }
                document.getElementById('hdnCtrlTabIndx').value = '';
            }
            catch (e) { alert(e); }
        }
        function setTabbingIndx(id) {
            //alert('mouse on in : ' + id.id);
            document.getElementById('hdnCtrlTabIndx').value = id.id;
        }

        $.fn.FunctionRemoveSpacing = function () {
            $('#grdState tr').each(function () {
                $(this).find('td').each(function () {
                    //alert('hi');
                    $(this).css("margin", "0");
                    $(this).css("padding", "1px");
                    $(this).css('height', '39px');

                });
            });
        }
        function setScroll() {
            window.scrollTo(1, yPos);
            try {
                if (document.getElementById(document.activeElement.id) != null)
                    document.getElementById(document.activeElement.id).select();
            }
            catch (e) { }
        }

        function hideSpinner() {
            try {
                //alert(document.getElementById(spinnerElement));
                if (document.getElementById(spinnerElement) != null) {
                    document.getElementById(spinnerElement).style.display = 'none';
                }
                $('#spinner').css("display", "none");
                //                var inputs = document.getElementsByTagName("input");
                //                for (var i = 0; i < inputs.length; i++) {
                //                    if (inputs[i].type == 'text')
                //                        document.getElementById(inputs[i].id).removeAttribute('disabled');
                //                    //document.getElementsByTagName('input').disabled = 'disabled';
                //                    //document.getElementById('grdState_ctl02_txtAmount').disabled = 'disabled';  //inputs[i].disabled = 'disabled';
                //                }
                //$('#divFloat').removeClass("overlay");
            }
            catch (e) { alert(e); }
        }

        function showSpinner(id) {
            try {//alert(id.id);
                var inputs = document.getElementsByTagName("input");
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].type == 'text')
                        document.getElementById(inputs[i].id).disabled = 'disabled';
                    //document.getElementsByTagName('input').disabled = 'disabled';
                    //document.getElementById('grdState_ctl02_txtAmount').disabled = 'disabled';  //inputs[i].disabled = 'disabled';
                }
                //                var arr = new Array();
                //                arr = id.id.split('_');
                //                spinnerElement = arr[0] + '_' + arr[1] + '_imgSpinner';
                //                var middleIndx = arr[1].toString().substring(3, 5);
                //                if (parseInt(middleIndx) < 10)
                //                    middleIndx = '0' + (parseInt(middleIndx) + 1).toString();
                //                else
                //                    middleIndx = (parseInt(middleIndx) + 1).toString();
                //                var middleName = arr[1].toString().substring(0, 3);
                //                middleName = middleName.toString() + middleIndx.toString();
                //                //alert(document.getElementById(spinnerElement));
                //                //document.getElementById(spinnerElement).style.display = 'block';
                $("#spinner").show();
                //alert(document.getElementById(arr[0] + '_' + middleName + '_txtAmount').value);
                //document.getElementById(arr[0] + '_' + middleName + '_txtAmount').disabled = true;
                //document.getElementById(arr[0] + '_' + middleName + '_txtDate').disabled = true;

                //nishu : 01/07/2016
                $("#<%=hdnfloat.ClientID%>").val($(id).attr('id'));
            }
            catch (e) {
                alert('error is : ' + e);
            }
        }

        //        function showSpinnerFloat(id) {
        //            try {
        //                var indc = id.id.substring(27, id.id.length);
        //                //alert(indc);
        //                var arr = new Array();
        //                arr = id.id.split('_');
        //                spinnerElement = arr[0] + '_' + arr[1] + '_imgSpinner' + indc;
        //                var middleIndx = arr[2].toString().substring(4, 6);

        //                //                if (parseInt(middleIndx) < 10)
        //                //                    middleIndx = '0' + (parseInt(middleIndx) + 1).toString();
        //                //                else
        //                middleIndx = (parseInt(middleIndx) + 1).toString();

        //                var middleName = arr[2].toString().substring(0, 4);
        //                middleName = middleName.toString() + middleIndx.toString();
        //                document.getElementById(spinnerElement).style.display = 'block';
        //                //alert(document.getElementById(arr[0] + '_' + middleName + '_txtAmount').value);
        //                //alert(arr[0] + '_' + arr[1] + '_' + middleName);// + '_txtAmount' + indc);
        //                document.getElementById(arr[0] + '_' + arr[1] + '_' + middleName).disabled = true;
        //                //document.getElementById(arr[0] + '_' + middleName + '_txtDate' + indc).disabled = true;

        //            }
        //            catch (e) {
        //                middleName = 'ddc'; // arr[2].toString().substring(0, 3);
        //                middleName = middleName.toString() + middleIndx.toString();
        //                //                alert(arr[0] + '_' + arr[1] + '_' + middleName);
        //                //                alert('e');
        //                document.getElementById(arr[0] + '_' + arr[1] + '_' + middleName).disabled = true;
        //               // alert(e);

        //            }
        //        }

        function showSpinnerFloat(id) {
            // $(document).ready(function () {
            //alert('spinner');
            //$('#divFloat').addClass('overlay'); //to change BG to Modal BG
            $("#spinner").show();
            $("#<%=hdnfloat.ClientID%>").val($(id).attr('id'));
            //setTimeout(function () { $('#spinner').css("display", "none"); }, 3000);


            //            $("#spinner").bind("ajaxSend", function () {
            //               
            //                    $(this).show();
            //                }).bind("ajaxStop", function () {
            //                    $(this).hide();
            //                }).bind("ajaxError", function () {
            //                    $(this).hide();
            //                });

            // });

        }

        $(function () {
            var focusedElement;
            $(document).on('focus', 'input', function () {
                if (focusedElement == $(this)) return; //already focused, return so user can now place cursor at specific point in input.
                focusedElement = $(this);
                setTimeout(function () { focusedElement.select(); }, 50); //select all text in any field on focus for easy re-entry. Delay sightly to allow focus to "stick" before selecting.
            });
        });
    </script>
    <asp:HiddenField ID="hdnControlHide" runat="server" />
    <asp:HiddenField ID="hdnScript" runat="server" />
    <asp:HiddenField ID="hdnTheme" runat="server" />
    <asp:HiddenField ID="hdnDDListSelection" runat="server" />
    <asp:HiddenField ID="hdnTabbed" runat="server" />
    <asp:HiddenField ID="hdnTabbedIndx" runat="server" />
    <asp:HiddenField ID="hdnAY" runat="server" />
    <asp:UpdatePanel ID="updHiddens" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnVType" runat="server" />
            <asp:HiddenField ID="hdnVType1" runat="server" />
            <asp:HiddenField ID="hdnVTypeStatus" runat="server" />
            <asp:HiddenField ID="hdnTaxStatus" runat="server" />
            <asp:HiddenField ID="hdnCtrlTabIndx" runat="server" />
            <asp:HiddenField ID="hdnMsg" runat="server" />
            <asp:HiddenField ID="hdnUploadPnl" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hdnProject" runat="server" />
    <asp:HiddenField ID="hdnSpinner" runat="server" />
    <asp:HiddenField ID="hdnNameID" runat="server" />
    <asp:HiddenField ID="hdnTabCount" runat="server" />
    <asp:HiddenField ID="hdnQtr" runat="server" />
    <input type="button" id="btnShow" value="Show Popup" style="display: none" />
    <%if (Session["IsMasterPage"] == null)
      { Session["IsMasterPage"] = "0"; } %>
    <asp:Button ID="btnPopup" runat="server" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlEmpPop"
        TargetControlID="btnPopup" CancelControlID="btnPopClose">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlEmpPop_Control" runat="server" Style="display: none;">
        <table width="500px">
            <tr>
                <td style="width: 90%">
                    <%--<rec:receipt ID="rec1" runat="server" />--%>
                </td>
                <td style="width: 10%">
                    <asp:ImageButton ID="btnPopClose_Control" runat="server" ImageUrl="../Images/windows_close_program.png"
                        Width="30px" Height="30px" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Button ID="btnPop_Control" runat="server" OnClientClick="return false;" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="pnlEmpPop_Control"
        TargetControlID="btnPop_Control" CancelControlID="btnPopClose_Control">
    </ajaxToolkit:ModalPopupExtender>
    <%--<asp:Panel ID="pnlImportDeductee" runat="server" style="display:none;">--%>
    <div class="row" id="pnlImportDeductee" style="display: none;">
        <div class="large-12 columns">
            <%--<IDD:ImpDed ID="impDed1" runat="server" />--%>
        </div>
    </div>
    <asp:Button ID="btnPop_Control_DedImp" runat="server" Text="import ded" Style="display: none;"
        OnClientClick="return false;" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="pp123"
        TargetControlID="btnPop_Control_DedImp" CancelControlID="ImageButton1">
    </ajaxToolkit:ModalPopupExtender>
    <asp:HiddenField ID="hdnGRowSel" runat="server" />
    <%--------------------nishu 14-3-2016 --------------------------%>
    <div class="row show-for-small-only" style="background-color: White; margin-top: -20px">
        <br />
        <div class="small-9 columns">
            <a href="Default.aspx">
                <img src="../images/logo2.png" style="width: 180px; height: auto" /></a>
        </div>
        <div class="small-3 columns text-right">
            <img src="../images/menu1.JPG" id="btnmenu" style="margin-top: 15px; width: 40px;
                height: 40px" />
        </div>
        <%----------------show username on mobile menu --------------------%>
        <div class="row show-for-small-only">
            <br />
            <div class="large-12 columns text-right">
                Welcome <span style="color: Black; font-family: 'Open Sans','sans-serif'; font-size: 15px;
                    font-weight: bold; color: #008CBA; text-transform: capitalize">
                    <asp:Literal ID="ltUser" runat="server" /></span> <a href="logout.aspx">[Logout]
                </a>
            </div>
        </div>
        <%----------------show username on mobile menu --------------------%>
    </div>
    <div class="row hidden-for-large hidden-for-medium" id="divmobmenu">
        <div class="large-12 columns">
            <mob:menu ID="mob1" runat="server" />
        </div>
    </div>
    <div class="row show-for-small-only">
        <div class="large-12 columns ">
            <mob2:mobmenu ID="mobmenu" runat="server" />
        </div>
    </div>
    <header:menuheader ID="header" runat="server" class="show-for-large-only"></header:menuheader>
    <%--  <div class="row show-for-medium-only" id="div1" style="display: none">
            <div class="large-12 columns">
               <mm:menu id="menu2" runat="server"></mm:menu>
            </div>
        </div>--%>
    <div>
        <div class="large-3 medium-3 columns  " style="left: 0; padding: 0;">
            <asp:UpdatePanel ID="Upleft" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <%
              
                //if (Request.QueryString["VType"] != null)
                if (Session["IncomeTax_VType"] != null)
                {                    //if (Request.QueryString["VType"].ToString() != "106")
                    if (Session["IncomeTax_VType"].ToString() != "106")
                    { %>
                    <div id="ass" class=" show-for-large-only " style="background-color: #3f3250; -webkit-border-radius: 10px;
                        -moz-border-radius: 10px; border-radius: 10px; padding: 10px; -moz-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                        -webkit-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                        text-align: center; -webkit-border-radius: 4px; -moz-border-radius: 10px; border-radius: 7px;
                        padding: 5px; -moz-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); -webkit-box-shadow: 0 0 5px rgba(0, 0, 0, 0.6);
                        box-shadow: 0 0 5px rgba(0, 0, 0, 0.6); margin-left: 3px; width: 300px">
                        <span style="color: White">Assessee Details [
                            <asp:LinkButton ID="lbtnEditProf" runat="server" Text="Edit" OnClick="lbtnEditProf_Click"
                                ToolTip="Click this link to Change Current Profile Details" Style="font-size: 13px"
                                ForeColor="White"></asp:LinkButton>]</span>
                    </div>
                    <%}
                } %>
                    <div id="Details" class="hidden-for-small-only" style="font-family: 'Open Sans', sans-serif;">
                        <sub:submenu ID="Submenu2" runat="server" />
                    </div>
                    <div id="ddMenu" style="overflow-y: auto; height: 350px; width: 310px;" class="hide-for-small-only">
                        <mm:menu ID="menu1" runat="server"></mm:menu>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <script type="text/javascript" src="Scripts/common.js"></script>
        </div>
        <div class="large-9 medium-9 columns " style="height: 500px; overflow: auto;">
            <asp:UpdatePanel ID="Upright" runat="server">
                <ContentTemplate>
                    <%-- <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Names="Cambria" CurrentNodeStyle-Font-Bold="true"
                NodeStyle-Font-Bold="false" ForeColor="#333333">
            </asp:SiteMapPath>
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />--%>
                    <%-- <div class="row">
            <div class="large-12 columns"> <div class="cbdb-menu" id="mm" >
              </div></div>
            </div>--%>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                    <asp:HiddenField ID="HiddenField4" runat="server" />
                    <asp:HiddenField ID="HiddenField5" runat="server" />
                    <asp:HiddenField ID="HiddenField6" runat="server" />
                    <asp:HiddenField ID="HiddenField7" runat="server" />
                    <asp:HiddenField ID="HiddenField8" runat="server" />
                    <asp:HiddenField ID="HiddenField9" runat="server" />
                    <asp:HiddenField ID="HiddenField10" runat="server" />
                    <asp:HiddenField ID="HiddenField11" runat="server" />
                    <asp:HiddenField ID="HiddenField12" runat="server" />
                    <asp:HiddenField ID="HiddenField13" runat="server" />
                    <%--  <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                <ProgressTemplate>
                    <img alt="progress" src="../images/progress.png" />
                    Processing...
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="hdnValidations" runat="server" />
                            <asp:HiddenField ID="hdnValidationsAll" runat="server" />
                            <asp:HiddenField ID="hdnValidations_Detail" runat="server" />
                            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetComboData"
                                EnableViewState="false" EnableCaching="false" CacheExpirationPolicy="Sliding"
                                TypeName="Taxation.BusinessLogic.bllScreen" OnSelecting="ObjectDataSource3_Selecting">
                                <SelectParameters>
                                    <asp:Parameter Name="intVtype" Type="Int32" />
                                    <asp:Parameter Name="ITR" Type="String" />
                                    <asp:Parameter Name="AY" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetParticularsByIndex"
                                TypeName="Taxation.BusinessLogic.bllSalary" OnSelecting="ObjectDataSource1_Selecting">
                                <SelectParameters>
                                    <asp:Parameter Name="intIndex" Type="Int32" />
                                    <asp:Parameter Name="intGindex" Type="Int32" />
                                    <asp:Parameter Name="strAssesseeType" Type="String" />
                                    <asp:Parameter Name="strAY" Type="String" />
                                    <asp:Parameter Name="PAN" Type="String" />
                                    <asp:Parameter Name="ReturnPeriod" Type="String" />
                                    <asp:Parameter Name="NameID" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:MultiView ID="mltView" ActiveViewIndex="0" runat="server">
                                <asp:View ID="viewList" runat="server">
                                    <div style="background-color: #494e6b; color: White; padding: 4px" class="hide-for-small-only hide-for-medium">
                                        <asp:Label ID="lblHeading" runat="server" Text="Label" Font-Bold="true" Style="color: white"
                                            Font-Size="20px" ForeColor="White"></asp:Label>
                                        <asp:Label ID="lblHeading_Title" runat="server" Font-Bold="True" Visible="false"></asp:Label>
                                        <asp:Label ID="Label1" runat="server" Text="Label" Style="color: White"></asp:Label>
                                        <asp:LinkButton ID="lbtnChange" runat="server" Text="(Change)" Visible="false" OnClientClick="callPopup();"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="(Change)" Visible="false" OnClientClick="callPopup();"></asp:LinkButton>
                                    </div>
                                    <%-- <div class="row">
                                <div class="large-5 columns medium-5 columns">--%>
                                    <%--  <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>--%>
                                    <%-- </div>
                                <div class="large-3 columns medium-3 columns">--%>
                                    <%--</div>
                                <div class="large-2 columns medium-2 columns">--%>
                                    <%-- </div>
                                <div class="large-2 columns medium-2 columns">--%>
                                    <%-- </div>
                            </div>--%>
                                    <div class="row">
                                        <div class="large-2 columns">
                                            <%if (ViewState["vtype"] != null)
                                          {
                                              if (Convert.ToString(ViewState["vtype"]) == "3002")
                                              {%>
                                        </div>
                                        <div class="large-2 columns">
                                            <asp:Label ID="lblChallanNo" runat="server" Text="Challan Number"></asp:Label>
                                            <asp:DropDownList ID="ddlChallan" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlChallan_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <%--Added by Mudit on 24/08/2015 for displaying Challans Details--%>
                                        <div class="large-2 columns">
                                            <asp:Label ID="lblBSRCode" runat="server" Text="BSR Code"></asp:Label>
                                            <asp:TextBox ID="txtBSRCode" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="large-2 columns">
                                            <asp:Label ID="lblChequeNo" runat="server" Text="Cheque Number"></asp:Label>
                                            <asp:TextBox ID="txtChequeNo" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="large-3 columns">
                                            <asp:Label ID="lblChallanAmt" runat="server" Text="Amount"></asp:Label>
                                            <asp:TextBox ID="txtChallanAmt" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="large-3 columns">
                                            <asp:Label ID="lblConsumedAmt" runat="server" Text="Amount Consumed"></asp:Label>
                                            <asp:TextBox ID="txtConsumedAmt" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="large-3 columns">
                                            <asp:Button ID="btn_Imp" runat="server" OnClick="btn_Imp_Click" Text="Import" CausesValidation="false"
                                                formnovalidate />
                                        </div>
                                        <%}
                                          } %>
                                        <%--------------------------------TILL HERE----------------------------------------------%>
                                    </div>
                                    <div class="row ">
                                        <div class="large-12 medium-12 small-12 columns">
                                            <div class="wrapper">
                                                <div class="arrows">
                                                    <a id="lft" class="arrow" href="#">&#x3008;</a>
                                                </div>
                                                <div style="height:5px;">&nbsp;</div>
                                                <center>
                                                <% if (Session["Project"].ToString() == "tds" && (Session["VType"].ToString() == "3001"))
                                                   { %>
                                                   <span style="color:Black;font-family:'Open Sans','sans-serif';font-size:14px;font-weight:normal;line-height: 20px; color:#494E6B; font-weight:bold;">Whether Book Entry:</span>&nbsp;&nbsp;
                                                <% }%>
                                                <asp:DropDownList ID="ddlSelect" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                                    onkeydown="if(event.keyCode==13) event.keyCode=9" DataSourceID="ObjectDataSource3"
                                                    DataTextField="ComboItems" DataValueField="ID" OnDataBound="ddlSelect_DataBound"
                                                    Width="250px">
                                                </asp:DropDownList>
                                                </center>
                                                <asp:RadioButton ID="btnRadioSimple" runat="server" GroupName="grp1" Text="Simple"
                                                    TabIndex="25" AutoPostBack="True" Checked="True" />
                                                <asp:RadioButton ID="btnRadiodetailed" runat="server" GroupName="grp1" Text="Detailed"
                                                    TabIndex="26" AutoPostBack="True" OnCheckedChanged="btnRadiodetailed_CheckedChanged" />
                                                <div id="numWrap" class="numWrap">
                                                    <div id="strip" class="strip">
                                                        <asp:Literal ID="ltTab" runat="server"></asp:Literal>
                                                    </div>
                                                </div>
                                                <div class="arrows">
                                                    <a id="rgt" class="arrow" href="#">&#x3009;</a>
                                                </div>
                                            </div>
                                            <hr id="hrnew" />
                                        </div>
                                        <asp:UpdatePanel ID="Upgrd" runat="server">
                                            <ContentTemplate>
                                                <%-- <div id="divgrdState" class="row" style="height: 400px; overflow-y: auto">
                                            <asp:Panel ID="pnlGrdState" runat="server" Height="400px">--%>
                                                <%--<div class="large-12 medium-12 columns">--%>
                                                <asp:GridView ID="grdState" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"
                                                    runat="server" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="grdState_SelectedIndexChanged"
                                                    OnRowDataBound="grdState_RowDataBound" PageSize="15" TabIndex="1" OnDataBound="grdState_DataBound"
                                                    Width="100%">
                                                    <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="white" CssClass="border_bot">
                                                    </HeaderStyle>
                                                    <FooterStyle Font-Bold="True" ForeColor="White" BackColor="white" CssClass="border_bot">
                                                    </FooterStyle>
                                                    <PagerStyle BorderStyle="None" BorderColor="White" CssClass="border_bot"></PagerStyle>
                                                    <Columns>
                                                        <asp:BoundField DataField="Serial" HeaderText="Sr.No.">
                                                            <%--ItemStyle-CssClass="border_bot"--%>
                                                            <%--<ItemStyle CssClass="border_bot" />--%>
                                                            <ControlStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol grdstyle" />
                                                            <HeaderStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField ItemStyle-CssClass="border_bot" HeaderText="Particulars" ItemStyle-Width="75%">
                                                            <%--<HeaderTemplate>
                                                    Particulars</HeaderTemplate>--%>
                                                            <ItemTemplate>
                                                                <%-- <div class="<%=class_noo %>" style="width:100%"; background-color: transparent">
                                                                --%>
                                                                <asp:Label ID="lblSerial" runat="server" Text='<%# Eval("Serial") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblParticulars" Font-Bold="False" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Particulars") %>'
                                                                    Style="line-height: 20px"><%# DataBinder.Eval(Container.DataItem, "Particulars") %></asp:Label>
                                                                <%--</div>--%>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="border_bot" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-CssClass="border_bot" HeaderText="Amount" HeaderStyle-CssClass="text-center">
                                                            <%--<HeaderTemplate>
                                                    <span style="float:right;margin-right:10px">Amount</span></HeaderTemplate>--%>
                                                            <ItemTemplate>
                                                                <%--   <div class="<%=class_no %>" style="margin-top: 0px; color: white; float: right">--%>
                                                                <div style="width: 205px;">
                                                                    <%--;float:left; margin: 12px 0px 0px 0px;"--%>
                                                                    <div style="width: 185px; float: left">
                                                                        <asp:Literal ID="ltTooltip" runat="server" Text='<%# Eval("tooltip") %>'></asp:Literal>
                                                                        <asp:TextBox ID="txtAmount" runat="server" Style="text-align: right; background-color: transparent;
                                                                            margin: 0px; width: 185px; padding: 0px; line-height: 20px" AutoPostBack="true"
                                                                            OnTextChanged="TextBox_Change_MainGrid" Visible="true" onmousedown="setTabbingIndx(this);"
                                                                            onCopy="return false" onDrag="return false" onDrop="return false" onPaste="return false"></asp:TextBox>
                                                                        <asp:TextBox ID="txtDate" runat="server" Style="text-align: right; margin: 0px; background-color: transparent;
                                                                            width: 185px; padding: 0px" AutoPostBack="true" Visible="true" OnTextChanged="TextBox_Change_Date"
                                                                            onmousedown="setTabbingIndx(this);"></asp:TextBox>
                                                                        <asp:TextBox ID="txtReadOnly" runat="server" Style="text-align: right; margin: 0px;
                                                                            width: 185px; padding: 0px" OnTextChanged="TextBox_Change_MainGrid" Visible="true"
                                                                            ReadOnly="True" Wrap="False"></asp:TextBox>
                                                                        <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl1_SelectedIndexChanged"
                                                                            onchange="setDDLSelection(this);" class="selectManage" Style="border: 1px solid #cccccc;
                                                                            color: #333333; font-size: 14px; margin-bottom: 4px; margin-top: 4px; width: 185px;
                                                                            background-color: transparent;" onmousedown="setTabbingIndx(this);">
                                                                        </asp:DropDownList>
                                                                        </a>
                                                                        <div id="divErr" runat="server" style="background-color: Red; color: White; padding-left: 6px;
                                                                            display: none;">
                                                                            Invalid Value
                                                                        </div>
                                                                        <%--<asp:Literal ID="ltTooltip2" runat="server"></asp:Literal>--%>
                                                                        <%--<span class="fieldtip">Enter some text!</span>--%>
                                                                        <%--</div>--%>
                                                                    </div>
                                                                    <div style="width: 18px; float: left;">
                                                                        <%--  <a alt='<%# Eval("tooltip") %>' class"tooltipDemo" id="tip_tool" style=" text-decoration:none"/>--%>
                                                                        <%-- for 106 <asp:Image ID="imgSpinner"  runat="server" ImageUrl="~/Presentation/spinner.gif" style="display:none;  transform: translate(140px,0px);;float:left; margin: 12px -28px 0px 10px;" />       for 106                                           --%>
                                                                        <asp:Image ID="imgSpinner" runat="server" ImageUrl="~/Presentation/spinner.gif" Style="display: none;
                                                                            margin: 0; padding: 0; width: 18px; height: 18px" />
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                            <%-- <HeaderStyle CssClass="text-right" />--%>
                                                            <ItemStyle CssClass="border_bot" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-CssClass="border_bot" HeaderText="">
                                                            <%--<HeaderTemplate >
                                                    Details</HeaderTemplate>--%>
                                                            <ItemTemplate>
                                                                <div class="large-2 columns">
                                                                    <asp:LinkButton ID="btnLink" runat="server" OnClick="btnLink_Click" CssClass="imgdetail"></asp:LinkButton>
                                                                    <%--<asp:LinkButton ID="LinkButton1" runat="server">Details2</asp:LinkButton>--%>
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="border_bot" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="C19">
                                                            <ControlStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol grdstyle" />
                                                            <HeaderStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="C1">
                                                            <%--<ControlStyle CssClass="hiddencol" />
                                                                <ItemStyle CssClass="hiddencol grdstyle" />
                                                                <HeaderStyle CssClass="hiddencol" />--%>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="C16" HeaderText="C16">
                                                            <ControlStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol grdstyle" />
                                                            <HeaderStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="KeyCheck" HeaderText="Key">
                                                            <ControlStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol grdstyle" />
                                                            <HeaderStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="C25" HeaderText="C25">
                                                            <ControlStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol grdstyle" />
                                                            <HeaderStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="C40" HeaderText="C40">
                                                            <ControlStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol grdstyle" />
                                                            <HeaderStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="C27" HeaderText="C27">
                                                            <ControlStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol grdstyle" />
                                                            <HeaderStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="C19" HeaderText="C16">
                                                            <ControlStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol grdstyle" />
                                                            <HeaderStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <RowStyle HorizontalAlign="Left" />
                                                    <EditRowStyle BackColor="White" BorderColor="White" />
                                                    <SelectedRowStyle BackColor="#E0E0E0" />
                                                </asp:GridView>
                                                <%--</div>
                                                </asp:Panel>--%>
                                                <%--</div>--%>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                       
                                                <%
                                       if (Request.QueryString["vtype"] != null)
                                       {
                                           if (Request.QueryString["vtype"].ToString() == "104"){
                                                %>
                                                <asp:Button ID="btngetTDS" runat="server" class="button" Height="53px" OnClick="btngetTDS_Click"
                                                    Text="Import Tax Details From Income Tax" Visible="false" />
                                                <%--    </div>--%>
                                                <%}}
                                                if (Session["project"].ToString() == "vt" || Session["project"].ToString() == "stax" || Session["project"].ToString() == "tds" || Session["project"].ToString() == "tds2")
                                           {
                                                %><%--      <div style="text-align:right;">--%>
                                                <%-- <%if (Session["IsMasterPage"] != null)
                                      {
                                          string i = Session["IsMasterPage"].ToString();
                                          if (Session["IsMasterPage"].ToString() != "1" && Session["IsMasterPage"].ToString() != "2")
                                          { %>--%>
                                                <div style="float: right">
                                                    <asp:Button ID="btnBack" runat="server" class="radius button" formnovalidate="" Height="53px"
                                                        OnClick="btnBack_Click" Style="border-radius: 3px;" Text="Back" Visible="false"
                                                        Width="128px" />
                                                    <asp:Button ID="btnContinue" runat="server" class=" radius button" formnovalidate=""
                                                        Height="53px" OnClick="btnContinue_Click" Style="border-radius: 3px;" Text="Continue"
                                                        Visible="false" Width="128px" />
                                                    &nbsp;
                                                </div>
                                                <!-----nishu 4/8/2015 ------>
                                                <%--   <asp:Button ID="btnPDF" runat="server" Text="Generate PDF" OnClick="btnPDF_Click" />--%>
                                                <%-- <%}
                                                 } %>--%>
                                                <%--Added by Mudit For Generic Procedures on 16/06/2015--%>
                                                <p style="float: right; padding: 0px; margin: 0px;">
                                                    <%//if (Session["IsMasterPage"] != null)
                                                  //{
                                                      //if (Session["IsMasterPage"].ToString() == "1" || Session["IsMasterPage"].ToString() == "2")
                                                      //{ 
                                                    %>
                                                    <asp:Button ID="btnView" runat="server" class="radius button" OnClick="btnView_Click"
                                                        Visible="false" Text="View" />
                                                    <asp:Button ID="btnSaveMasterData" runat="server" class="radius button" Height="53px"
                                                        OnClick="btnSaveMasterData_Click" OnClientClick="return moveValNext1();" Style="border-radius: 4px;
                                                        display: none;" Text="Save" />
                                                    <%//}
                                                  //}
                                           }%>
                                                    <asp:Button ID="btnPageMove" runat="server" class="button" Height="53px" OnClick="btnPageMove_Click"
                                                        Style="display: none; border-radius: 4px" Text="Continue" Visible="true" />
                                                    <asp:Button ID="btnBackMaster" runat="server" class="radius button" formnovalidate=""
                                                        Style="display: none;" OnClientClick="btnBack_Click()" Text="Back" Visible="false" />
                                                    <asp:Button ID="btnContinueMaster" runat="server" class="radius button" OnClientClick="btnCont_Click()"
                                                        Visible="false" Text="Continue master" />
                                                    
                                                     <div class="row">
                                                    <div class="large-12 columns">
                                                    <asp:UpdatePanel ID="updDB" runat="server">
                                                    <ContentTemplate>
                                                       
                                                            <input id="btnBack_Inp" runat="server" type="button" class="radius button" value="Back"
                                                        onclick="setVTypeStatus(2);" style="width: 128px; float:left" />
                                                         <% if (Session["project"].ToString() == "tds" && (Session["ITR"].ToString() == "14" || Session["ITR"].ToString() == "15" || Session["ITR"].ToString() == "16" || Session["ITR"].ToString() == "17"))
                                       { %><%-- <div class="row">--%><%-- <div class="large-6 columns"></div>--%>
                                        
                                                <%-- <p style="text-align:right">--%>
                                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnDetails" runat="server" Class=" radius button" formnovalidate=""
                                                    Height="53px" OnClick="btnDetails_Click" Text="View Details" Width="150px" />
                                                <%--<input type="button" class="button" value="Create File" onclick="showPopup_Control(1);return false;" Height="53px"   />--%>
                                                <%--<asp:Button ID="btnCreateFile" runat="server" Text="Create File" Visible="true" OnClick="btnCreateFile_Click" class="button" formnovalidate/>--%>
                                                <asp:Button ID="btnSaveToMydatabase1" runat="server" class=" radius button" formvalidate=""
                                                    Height="53px" OnClick="btnSaveToMydatabase1_Click" OnClientClick="javascript:ConfirmOnSave(grdState);"
                                                    Text="Save And Clear" Visible="true" Width="150px" />
                                                <asp:Button ID="btnSaveToMydatabase12" runat="server" class=" radius button" formvalidate=""
                                                    Height="53px" OnClick="btnSaveToMydatabase12_Click" OnClientClick="javascript:ConfirmOnSave(grdState);"
                                                    Text="Save" Visible="true" Width="150px" />
                                                   
                                                <%} %>
                                                        <input id="btnCont_Inp" runat="server" type="button" class="radius button" value="Continue"
                                                        onclick="setVTypeStatus(1);" style="width: 128px; float:right;" />

                                                       <center> 
                                            <DB:DynamicButtons_Service ID="db1" runat="server" Page_ID="100" Page_ModuleID="100" style="padding:0px 2px 0px 2px"  />
                                                               </center>  
                                                    <asp:Button ID="btnNewCont" runat="server" CssClass="radius button" Text="Real Continue"
                                                        OnClientClick="setVTypeStatus();" Visible="false" />
                                                    <asp:Button ID="btnErrPopup" runat="server" Style="display: none;" />
                                                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender5" runat="server" BackgroundCssClass="ModalPopupBG"
                                                        CancelControlID="Button14" DynamicServicePath="" Enabled="True" PopupControlID="PanelErr106"
                                                        TargetControlID="btnErrPopup">
                                                    </ajaxToolkit:ModalPopupExtender>
                                                                <%--<DB:DynamicButtons_Service ID="db1" runat="server" />--%>
                                                                <div style="display: none">
                                                                    <asp:Button ID="btnSubmit_pop" runat="server" Text=" OK " />
                                                                </div>
                                                           
                                                    </ContentTemplate>                                                    
                                                </asp:UpdatePanel>
                                                   </div>
                                                   </div>

                                                </p>
                                                <%-- </div>--%><%--<%} %>--%>
                                            </div>
                                        </div>
                                </asp:View>
                                <asp:View ID="viewCountryDetail" runat="server">
                                    <div class="row">
                                        <div class="large-12 columns panel text-center">
                                            State Detail
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-5 columns">
                                            <asp:Label ID="lblStateName" runat="server" Text="State Name :" AssociatedControlID="txtStateName"></asp:Label>
                                        </div>
                                        <div class="large-7 columns">
                                            <asp:TextBox ID="txtStateName" runat="server" TabIndex="1"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-5 columns">
                                            <asp:Label ID="lblCountryName" runat="server" Text="Country Name :" AssociatedControlID="txtCountryName"></asp:Label>
                                        </div>
                                        <div class="large-7 columns">
                                            <asp:TextBox ID="txtCountryName" runat="server" Style="vertical-align: middle; text-align: left"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-5 columns">
                                            <asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="False" TabIndex="9"
                                                CausesValidation="true" ValidationGroup="Save" class="button" Height="53px" Width="162px">
                                            </asp:Button>
                                        </div>
                                        <div class="large-7 columns">
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CausesValidation="False"
                                                UseSubmitBehavior="False" TabIndex="10" class="button" Height="53px" Width="162px">
                                            </asp:Button>&nbsp;<asp:Button ID="btnGoBack" runat="server" Text="Go Back" CausesValidation="False"
                                                UseSubmitBehavior="False" TabIndex="11" class="button" Height="53px" Width="162px">
                                            </asp:Button>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-5 columns">
                                        </div>
                                        <div class="large-7 columns">
                                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Enter State Name"
                                                ControlToValidate="txtStateName" Display="None" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCountryName"
                                                Display="None" ErrorMessage="Enter Country Name" TabIndex="5" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                            <asp:ValidationSummary ID="vlsUserGrp" runat="server" ValidationGroup="Save"></asp:ValidationSummary>
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="viewMessage" runat="server">
                                    <div class="row">
                                        <div class="large-12 columns panel">
                                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-12 columns">
                                            <asp:Button ID="btnGoBackM" TabIndex="10" runat="server" UseSubmitBehavior="False"
                                                Text="Go Back" CausesValidation="False" Height="53px" Width="162px"></asp:Button>
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="ViewDetails" runat="server">
                                    <div class="row">
                                        <div class="large-12 columns">
                                            <asp:Label ID="lblSubHeading" runat="server" Font-Bold="True" Text="Label" Style="color: #e14658;
                                                text-decoration: underline"></asp:Label>
                                        </div>
                                        <hr style="border: 2px solid black; margin-top: 4px" />
                                    </div>
                                    <div class="row">
                                        <div class="large-12 columns" style="height: 350px; overflow-y: auto">
                                            <asp:GridView ID="GridViewDetails" AutoGenerateColumns="False" CssClass="small" SkinID="grdstateskin"
                                                AllowSorting="True" AllowPaging="True" runat="server" PageSize="20" DataSourceID="ObjectDataSource2"
                                                OnRowDataBound="GridViewDetails_RowDataBound" OnSelectedIndexChanged="GridViewDetails_SelectedIndexChanged"
                                                Width="100%">
                                                <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6492C3"></HeaderStyle>
                                                <FooterStyle Font-Bold="True" ForeColor="White" BackColor="#6492C3"></FooterStyle>
                                                <Columns>
                                                    <asp:BoundField DataField="Serial" ItemStyle-HorizontalAlign="Center" HeaderText="SNo." />
                                                    <asp:BoundField DataField="Particular" HeaderText="Particulars" />
                                                    <asp:TemplateField>
                                                        <HeaderStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlYesNo" AutoPostBack="true" OnSelectedIndexChanged="DOYesNo"
                                                                runat="server" Style="width: 200px">
                                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="amt"
                                                        HeaderText="Amount">
                                                        <%-- <HeaderTemplate>
                                                       </HeaderTemplate>--%>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtAmount" runat="server" AutoPostBack="true" OnTextChanged="TextBox_Change"
                                                                ToolTip='<%# Eval("tooltip") %>' onkeydown="if(event.keyCode==13) event.keyCode=9"
                                                                Style="text-align: right;"></asp:TextBox>
                                                            <%--width: 200px--%>
                                                            <asp:DropDownList ID="dd1" runat="server" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged">
                                                                <%--   Style="width: 185px;"--%>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="C11" HeaderText="C11">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SubConstID">
                                                        <%-- <ControlStyle CssClass="hiddencol" />
                                                <ItemStyle CssClass="hiddencol" />
                                                <HeaderStyle CssClass="hiddencol" />--%>
                                                    </asp:BoundField>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <EditRowStyle BackColor="White" BorderColor="White" />
                                                <SelectedRowStyle BackColor="#E0E0E0" />
                                            </asp:GridView>
                                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OnSelecting="ObjectDataSource2_Selecting"
                                                SelectMethod="GetParticulars" TypeName="Taxation.BusinessLogic.bllT4">
                                                <SelectParameters>
                                                    <asp:Parameter Name="intIndex" Type="Int32" />
                                                    <asp:Parameter Name="yn" Type="Int32" />
                                                    <asp:Parameter Name="AYear" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                        <div class="row">
                                            <div class="large-12 columns">
                                            <% if (ViewState["ConstID"].ToString() != "3026")
                                               { %>
                                                <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="Button2_Click" class="button"
                                                    Height="53px" Width="162px"></asp:Button>
                                                    <%} %>
                                                <asp:Button ID="Button3" runat="server" Text="Remove" Visible="False" class="button"
                                                    Height="53px" Width="162px" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="Button4_Click" class="button"
                                                    Height="53px" Width="162px" />
                                            </div>
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="ViewFloatingGrid" runat="server">
                                    <div class="row">
                                        <div class="large-12 columns panel" style="border: none; background-color: transparent">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Style="color: #EF5845; text-decoration: underline;"
                                                Text="Label"></asp:Label>
                                            <hr style="border: 2px solid black; margin-top: 4px" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-12 columns" style="overflow-x: auto; overflow-y: auto; max-height: 430px;">
                                            <asp:GridView ID="GridViewFlaoting" AutoGenerateColumns="False" CssClass="small"
                                                AllowSorting="True" AllowPaging="True" PageSize="10" runat="server" DataSourceID="ObjectDataSource4"
                                                OnDataBound="GridViewFlaoting_DataBound" OnRowDataBound="GridViewFlaoting_RowDataBound"
                                                Width="100%">
                                                <HeaderStyle Font-Bold="True" ForeColor="White"></HeaderStyle>
                                                <FooterStyle Font-Bold="True" ForeColor="White" BackColor="#6492C3"></FooterStyle>
                                                <Columns>
                                                    <asp:BoundField DataField="Gorder" HeaderText="#" ItemStyle-HorizontalAlign="Center"
                                                        ControlStyle-CssClass="hiddencol" />
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C2</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC2" runat="server" AutoPostBack="true" Text='<%# Bind("Col2") %>'
                                                                OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC2" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner2" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C3
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC3" runat="server" Text='<%# Bind("Col3") %>'
                                                                AutoPostBack="true" OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC3" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner3" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C4</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC4" runat="server" AutoPostBack="True" Text='<%# Bind("Col4") %>'
                                                                OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC4" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner4" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                            <%--<div id="divErr_Float" runat="server" style="background-color:Red; color:White; padding-left:6px; " >
                                                            Invalid Value
                                                        </div>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C5</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC5" runat="server" AutoPostBack="True" Text='<%# Bind("Col5") %>'
                                                                OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC5" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner5" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C6</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC6" runat="server" AutoPostBack="True" Text='<%# Bind("Col6") %>'
                                                                OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC6" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner6" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C7</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC7" runat="server" AutoPostBack="True" Text='<%# Bind("Col7") %>'
                                                                OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC7" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner7" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C8</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC8" runat="server" AutoPostBack="True" Text='<%# Bind("Col8") %>'
                                                                OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC8" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner8" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C9</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC9" runat="server" AutoPostBack="True" Text='<%# Bind("Col9") %>'
                                                                OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC9" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner9" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C10</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC10" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col10") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC10" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner10" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C11</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC11" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col11") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC11" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner11" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C12</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC12" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col12") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC12" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner12" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C13</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC13" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col13") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC13" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner13" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C14</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC14" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col14") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC14" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner14" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C15</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC15" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col15") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC15" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner15" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C16</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC16" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col16") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC16" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner16" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C17</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC17" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col17") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC17" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner17" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C18</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC18" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col18") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC18" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner18" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C19</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC19" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col19") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC19" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner19" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C20</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC20" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col20") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC20" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner20" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C21</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC21" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col21") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC21" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner21" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C22</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC22" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col22") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC22" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner22" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C23</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC23" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col23") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC23" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner23" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C24</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC24" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col24") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC24" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner24" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C25</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC25" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col25") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC25" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner25" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C26</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC26" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col26") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC26" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner26" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C27</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC27" runat="server" AutoPostBack="True"
                                                                Text='<%# Bind("Col27") %>' OnTextChanged="txt_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC27" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner27" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            C28</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox onfocus="sel(this);" ID="txtC28" runat="server" AutoPostBack="True"></asp:TextBox>
                                                            <asp:DropDownList ID="ddC28" runat="server" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="ddC2_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Image ID="imgSpinner28" runat="server" ImageUrl="~/Presentation/spinner.gif"
                                                                Style="display: none; transform: translate(80px,30px);" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <EditRowStyle BackColor="White" BorderColor="White" />
                                                <SelectedRowStyle BackColor="#E0E0E0" />
                                            </asp:GridView>
                                            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetFlaotingHeaders"
                                                TypeName="Taxation.BusinessLogic.bllFloating" OnSelecting="ObjectDataSource4_Selecting"
                                                DataObjectTypeName="Taxation.DataEntity.denFloating" InsertMethod="InsertFloatGridData"
                                                OnInserting="ObjectDataSource4_Inserting">
                                                <SelectParameters>
                                                    <asp:Parameter Name="strnameID" Type="String" />
                                                    <asp:Parameter Name="intC16" Type="Int32" />
                                                    <asp:Parameter Name="intconstID" Type="Int32" />
                                                    <asp:Parameter Name="intSelection" Type="Int32" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                    </div>
                                    <div class="row text-right">
                                        <div class="large-12 columns">
                                            <asp:Button ID="btnInsertFloatGrid" runat="server" OnClick="btnInsertFloatGrid_Click"
                                                OnClientClick="return moveVal_Float();" Text="ADD" class="radius button" Height="53px"
                                                Width="128px" />
                                            <%--</div>
                                
                                <div class="large-4 columns">--%>
                                            <asp:Button ID="btnDels" runat="server" Text="DELETE" class="radius button" formnovalidate
                                                Height="53px" Width="128px" />
                                            <ajaxToolkit:ModalPopupExtender ID="btnDels_ModalPopupExtender" runat="server" CancelControlID="btnClose"
                                                DynamicServicePath="" Enabled="True" PopupControlID="pnlRemove" TargetControlID="btnDels"
                                                BackgroundCssClass="ModalPopupBG">
                                            </ajaxToolkit:ModalPopupExtender>
                                            <%--</div>
                                <div class="large-4 columns">--%>
                                            <asp:Button ID="btnOKFloatGrid" runat="server" Text="OK" OnClick="Button2_Click"
                                                OnClientClick="return moveVal_Float();" class="radius button" Height="53px" Width="128px">
                                            </asp:Button>
                                        </div>
                                        <%--  <div class="large-3 columns">
                                    <asp:Button ID="Button6" runat="server" Text="Cancel" class="button" OnClick="Button4_Click"
                                        Height="53px" Width="162px"  />
                                </div>--%>
                                    </div>
                                </asp:View>
                                <asp:View ID="AssetGrid" runat="server">
                                    <div class="row">
                                        <div class="large-12 columns panel">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Asset List"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-12 columns">
                                            <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OnSelecting="ObjectDataSource5_Selecting"
                                                SelectMethod="GetAssetList" TypeName="Taxation.BusinessLogic.bllSalary">
                                                <SelectParameters>
                                                    <asp:Parameter Name="NameID" Type="String" />
                                                    <asp:Parameter Name="VType" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-12 columns">
                                            <asp:GridView ID="grdAssetDetails" AutoGenerateColumns="False" CssClass="small" AllowSorting="True"
                                                AllowPaging="True" runat="server" PageSize="20" DataSourceID="ObjectDataSource5"
                                                Width="100%">
                                                <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6492C3"></HeaderStyle>
                                                <FooterStyle Font-Bold="True" ForeColor="White" BackColor="#6492C3"></FooterStyle>
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Title
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="lnkAssetGid" Text='<% #Bind("AssetName") %>' OnClick="lnkAssetGid_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PurchaseDate" HeaderText="Amount" />
                                                    <%--<asp:BoundField DataField="PurchaseCost" HeaderText="PurchaseCost" />
                                            <asp:BoundField DataField="PurchaseExp" HeaderText="PurchaseExp" />
                                            <asp:BoundField DataField="SaleID" HeaderText="SaleID" />
                                            <asp:BoundField DataField="AssetID" HeaderText="AssetID" />--%>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <EditRowStyle BackColor="White" BorderColor="White" />
                                                <SelectedRowStyle BackColor="#E0E0E0" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-4 columns">
                                            <asp:Button ID="Button1" runat="server" Text="OK" OnClick="Button2_Click" class="button">
                                            </asp:Button>
                                        </div>
                                        <div class="large-4 columns">
                                            <asp:Button ID="btnAddAsset" runat="server" OnClick="btnAddAsset_Click" Text="Add Asset"
                                                class="button" />
                                        </div>
                                        <div class="large-4 columns">
                                            <asp:Button ID="Button4" runat="server" Text="Simple" OnClick="Button4_Click" class="button" />
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="ViewAssetType" runat="server">
                                    <div class="row">
                                        <div class="large-12 columns panel">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Asset Details"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-4 columns">
                                        </div>
                                        <div class="large-4 columns">
                                            <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" SelectMethod="GetHousePropertyData"
                                                TypeName="Taxation.BusinessLogic.bllSalary" OnSelecting="ObjectDataSource7_Selecting">
                                                <SelectParameters>
                                                    <asp:Parameter Name="ComboParameter" Type="Int32" />
                                                    <asp:Parameter Name="ChkBoxParameter" Type="Int32" />
                                                    <asp:Parameter Name="SaleID" Type="Int32" />
                                                    <asp:Parameter Name="AY" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                        <div class="large-4 columns">
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-4 columns">
                                        </div>
                                        <div class="large-4 columns">
                                            <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" SelectMethod="getDataByAssetID"
                                                TypeName="Taxation.BusinessLogic.bllSalary" OnSelecting="ObjectDataSource6_Selecting">
                                                <SelectParameters>
                                                    <asp:Parameter Name="SaleID" Type="Int32" />
                                                    <asp:Parameter Name="GIndex" Type="Int32" />
                                                    <asp:Parameter Name="AY" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                        <div class="large-4 columns">
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-7 columns">
                                            <asp:Label ID="lblIncome" runat="server" Text="Choose Type of Income" Visible="False"></asp:Label>
                                        </div>
                                        <div class="large-3 columns">
                                            <asp:DropDownList ID="ddlHP" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlHP_SelectedIndexChanged"
                                                Visible="False">
                                                <asp:ListItem Selected>Sale</asp:ListItem>
                                                <asp:ListItem>Compulsary Acquisition</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="large-2 columns">
                                            <asp:CheckBox ID="chkCompensation" runat="server" Text="Is Enhanced Compensation?"
                                                Visible="False" OnCheckedChanged="chkCompensation_CheckedChanged" AutoPostBack="True" />
                                            <asp:LinkButton ID="btnlnkLogout3" runat="server" Font-Bold="True" ForeColor="#C00000"
                                                OnClick="LinkButton1_Click1">Logout</asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-12 columns">
                                            <asp:GridView ID="GridAssetType" AutoGenerateColumns="False" CssClass="small" AllowSorting="True"
                                                AllowPaging="True" runat="server" DataSourceID="ObjectDataSource6" OnSelectedIndexChanged="grdState_SelectedIndexChanged"
                                                OnRowDataBound="grdState_RowDataBound" PageSize="20" TabIndex="1">
                                                <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6492C3"></HeaderStyle>
                                                <FooterStyle Font-Bold="True" ForeColor="White" BackColor="#6492C3"></FooterStyle>
                                                <Columns>
                                                    <asp:BoundField DataField="Serial" HeaderText="Serial" />
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Particulars</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblParticulars" Font-Bold="False" runat="server"><%# DataBinder.Eval(Container.DataItem, "Particulars") %></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Amount</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtAmount" runat="server" Style="text-align: right" AutoPostBack="true"
                                                                OnTextChanged="TextBox_Change_MainGrid" Visible="true"></asp:TextBox>
                                                            <asp:TextBox ID="txtDate" runat="server" Style="text-align: right" AutoPostBack="true"
                                                                OnTextChanged="TextBox_Change_Date" Visible="true"></asp:TextBox>
                                                            <asp:TextBox ID="txtReadOnly" runat="server" Style="text-align: right" OnTextChanged="TextBox_Change_MainGrid"
                                                                Visible="true" ReadOnly="True" Wrap="False"></asp:TextBox>&nbsp;<br />
                                                            <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl1_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnLink" runat="server" OnClick="btnLink_Click">Details</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="C19">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="C1" HeaderText="C1">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="C16" HeaderText="C16">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="KeyCheck" HeaderText="Key">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="C25" HeaderText="C25">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="C40" HeaderText="C40">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <EditRowStyle BackColor="White" BorderColor="White" />
                                                <SelectedRowStyle BackColor="#E0E0E0" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-4 columns">
                                            <asp:RadioButton ID="btnRdoCGains10" runat="server" GroupName="grp2" Text="10 %" />
                                        </div>
                                        <div class="large-6 columns">
                                            <asp:RadioButton ID="btnRdoCGains20" runat="server" GroupName="grp2" Text="20 %" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-4 columns">
                                            <asp:Button ID="Button2" runat="server" Text="OK" OnClick="Button2_Click"></asp:Button>
                                        </div>
                                        <div class="large-4 columns">
                                            <asp:Button ID="Button7" runat="server" OnClick="btnAddAsset_Click" Text="Add Asset" />
                                        </div>
                                        <div class="large-4 columns">
                                            <asp:Button ID="Button8" runat="server" Text="Simple" OnClick="Button4_Click" /></div>
                                    </div>
                                </asp:View>
                                <asp:View ID="viewDetails2" runat="server">
                                    <div class="row">
                                        <div class="large-12 columns panel">
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-12 columns">
                                            <asp:GridView ID="gvDetails2" AutoGenerateColumns="False" CssClass="small" AllowSorting="True"
                                                AllowPaging="True" runat="server" PageSize="20" DataSourceID="ObjectDataSource2"
                                                OnRowDataBound="gvDetails2_RowDataBound" Width="100%">
                                                <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6492C3"></HeaderStyle>
                                                <FooterStyle Font-Bold="True" ForeColor="White" BackColor="#6492C3"></FooterStyle>
                                                <Columns>
                                                    <asp:BoundField DataField="Serial" HeaderText="Serial" />
                                                    <asp:BoundField DataField="Particular" HeaderText="Particulars" />
                                                    <asp:TemplateField>
                                                        <HeaderStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlYesNo" AutoPostBack="true" OnSelectedIndexChanged="DOYesNo"
                                                                runat="server" Width="185px">
                                                                <asp:ListItem Text="----" Value="-1"></asp:ListItem>
                                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            Amount</HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtAmount" runat="server" AutoPostBack="true" OnTextChanged="TextBox_Change"
                                                                onkeydown="if(event.keyCode==13) event.keyCode=9" onkeypress="return isNumericKeyStroke();"
                                                                Style="text-align: right" Width="185px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="C11" HeaderText="C11">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="C12" HeaderText="C12">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="C13" HeaderText="C13">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="C14" HeaderText="C14">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="C15" HeaderText="C15">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="C35" HeaderText="C15">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="C36" HeaderText="C15">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="C37" HeaderText="C15">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="C38" HeaderText="C15">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SubConstID" HeaderText="SubConstID">
                                                        <ControlStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                        <HeaderStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <RowStyle HorizontalAlign="Left" />
                                                <EditRowStyle BackColor="White" BorderColor="White" />
                                                <SelectedRowStyle BackColor="#E0E0E0" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-12 columns">
                                            <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" OnSelecting="ObjectDataSource2_Selecting"
                                                SelectMethod="GetParticulars" TypeName="Taxation.BusinessLogic.bllT4">
                                                <SelectParameters>
                                                    <asp:Parameter Name="intIndex" Type="Int32" />
                                                    <asp:Parameter Name="yn" Type="Int32" />
                                                    <asp:Parameter Name="AYear" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-4 columns">
                                            <asp:Button ID="Button9" runat="server" Text="OK" OnClick="Button2_Click" class="button">
                                            </asp:Button></div>
                                        <div class="large-4 columns">
                                            <asp:Button ID="Button10" runat="server" Text="Remove" Visible="False" class="button" /></div>
                                        <div class="large-4 columns">
                                            <asp:Button ID="Button11" runat="server" Text="Cancel" OnClick="Button4_Click" class="button" /></div>
                                    </div>
                                </asp:View>
                                <asp:View ID="viewTDSList" runat="server">
                                    <div class="row">
                                        <div class="large-12 columns panel">
                                            <a>
                                                <asp:Literal ID="ltTDSHeading" runat="server" Text="Challan Listing"></asp:Literal>
                                            </a>
                                        </div>
                                        <div class="row">
                                            <div class="large-5 columns">
                                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:DropDownList ID="ddTDSList" runat="server" onchange="setDDSelection(this);">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="large-3 columns">
                                            </div>
                                            <div class="large-2 columns">
                                            </div>
                                            <div class="large-2 columns">
                                            </div>
                                        </div>
                                        <%--<div class="large-12 columns panel" style="overflow: auto;">
                                    <asp:UpdatePanel ID="too" runat="server">
                                        <ContentTemplate>
                                            <cc1:DynamicControl ID="dny_Grd_Returns2" runat="server" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>--%>
                                    </div>
                                </asp:View>
                                <asp:View ID="ViewControls" runat="server">
                                    <div class="row">
                                        <div class="large-12 columns panel">
                                            <a>
                                                <asp:Literal ID="Literal1" runat="server" Text="Challan Listing"></asp:Literal>
                                            </a>
                                        </div>
                                        <div class="large-12 columns panel">
                                            <%--<imp:import ID="imp1" runat="server" />--%>
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="ViewEmpty" runat="server">
                                    <div class="row">
                                        <br />
                                        <br />
                                        <div class="large-12 columns panel" style="font-size: larger; font-weight: bold;">
                                            <center>
                                            <span style="color: Red;">INCORRECT URL!!!</span>
                                            <br />
                                            Please check the URL as this is the Wrong URL!!!</center>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="large-12 columns panel">
                                        </div>
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender4" runat="server" CancelControlID="btnClose"
                                OkControlID="btnOk" TargetControlID="btnDels" PopupControlID="PnlRemove" Drag="true"
                                BackgroundCssClass="ModalPopupBG">
                            </ajaxToolkit:ModalPopupExtender>
                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender6" runat="server" CancelControlID="Button6"
                                DynamicServicePath="" Enabled="True" PopupControlID="pnlChallan" TargetControlID="Button16"
                                BackgroundCssClass="ModalPopupBG">
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Button ID="Button16" runat="server" Text="Remove" class="button" formnovalidate
                                Height="53px" Width="162px" Style="border-radius: 3px; display: none;" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="grdState" EventName="RowDataBound" />
                        </Triggers>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="divPop" style="display: none">
        <p>
            You have <span id="divAmt"></span>. Do you want to proceed?</p>
        <asp:Label ID="Label8" runat="server" ForeColor="Red" Font-Bold="True" Text="You have 25000 amount payable. Do you want to proceed? "
            Visible="False"></asp:Label>
        <div style="display: none">
            <asp:Button ID="Button12" runat="server" Text=" Yes " />
            &nbsp;
            <asp:Button ID="Button13" runat="server" Text=" No " />
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hdnIsPostback" />
    <asp:HiddenField ID="hdnIsSave" runat="server" />
    <%------ div for pin err msg -------------------%>
    <div id="divErrMsg" style="display: none">
        Value Should Be Numeric !!</div>
    <%------ div for confirmation msg -------------------%>
    <div id="divValidate" style="display: none">
        Are you sure you want to remove the selected record?</div>
    <%------ div for max limit -------------------%>
    <div id="divMaxlimit" style="display: none">
        This Field Value should be of 7 digits</div>
    <%----- nishu 8/8/2015----%>
    <div id="divDate" style="display: none">
        Date Cannot be greater than Today</div>
    <%--  <div id="divDate2" style="display:none">Date cannot be smaller than</div>--%>
    <div id="divDate3" style="display: none">
        Invalid date</div>
    <asp:Panel ID="pnlRemove" runat="server" Style="display: none; border: 0px solid #a6c9e2;
        height: 180px; background-color: White;">
        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
                <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix"
                    style="border-radius: 0px">
                    <span class="ui-dialog-title" style="font-size: 20px">Confirmation</span>
                </div>
                <p style="padding: 20px">
                    Are You sure want to delete entry?</p>
                <p style="text-align: center">
                    <asp:Button ID="btnYes" runat="server" Text="Yes" class="button radius" OnClick="btnDels_Click"
                        formnovalidate />
                    <asp:Button ID="btnClose1" runat="server" Text="No" class="button radius" /></p>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Panel ID="PanelErr106" runat="server" Style="display: none; border: 0px solid #a6c9e2;
        background-color: White;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix"
                    style="border-radius: 0px">
                    <span class="ui-dialog-title" style="font-size: 20px">Error!!!!!</span>
                </div>
                <p style="padding: 20px">
                    Please Fill all the required/valid details</p>
                <%-- <div id="Err106" ></div>--%>
                <%-- <p style=" text-align:center"><asp:Button ID="Button6" runat="server" Text="Yes" class="button radius" OnClick="btnDels_Click" formnovalidate    />--%>
                <p style="text-align: center">
                    <asp:Button ID="Button14" runat="server" Text="Close" class="button radius" OnClientClick="return false;" /></p>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Panel ID="pnlChallan" runat="server" Style="display: none; border: 0px solid #a6c9e2;
        height: 180px; background-color: White;">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix"
                    style="border-radius: 0px">
                    <span class="ui-dialog-title" style="font-size: 20px">Confirmation</span>
                </div>
                <p style="padding: 20px">
                    Please Select an Action to Resume Further</p>
                <p style="text-align: center">
                    <asp:Button ID="btnPDF" runat="server" class="button radius" formnovalidate="" Height="53px"
                        OnClientClick="javascript:window.open('ChallanPDF.aspx');" Style="border-radius: 3px;"
                        Text="Print Challan" />
                    <a href="https://onlineservices.tin.egov-nsdl.com/etaxnew/tdsnontds.jsp" class="button radius"
                        target="_blank" style="cursor: pointer; text-decoration: none;">Online Deposit</a>
                    <%--<asp:Button ID="Button15" runat="server" Text="Online Deposit" class="button radius" PostBackUrl="https://onlineservices.tin.egov-nsdl.com/etaxnew/tdsnontds.jsp" formnovalidate />--%>
                    <asp:Button ID="Button6" runat="server" Text="Remind Me Later" class="button radius" /></p>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <%-------Add hidden field for jquery erroe message nishu 17/8/2015 ---------------%>
    <asp:HiddenField ID="hdnValidate" runat="server" Value="true" />
    <div id="div106" style="display: none">
        Invalid data</div>
    <%----show popup msg on 106 nishu 22//8/2015 ------%>
    <div id="msg" style="display: none">
    </div>
    <%----validation error box - jaipal------%>
    <div class="hide-for-small-only hide-for-medium-only">
        <div id="newdiv" style="border: 2px solid black; border-radius: 10px; box-shadow: #b3b3b3 4px 4px 4px;
            padding-bottom: 260px; padding-top: 8px; position: fixed; padding-left: 8px;
            background-color: white; width: 240px; height: 0px; left: 83.5%; top: 40%; display: none">
            <span style="font-family: sans-serif; color: #ef5845; font-weight: bold">VALIDATION
                ERRORS
                <img src="../images/cross.jpg" alt="close" id="close_val_error" style="height: 20px;
                    float: right; padding-right: 10px; cursor: pointer" />
                <hr style="margin-top: 2px; border: 1px solid gray; width: 220px;" />
            </span>
            <div id="val_errors">
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidClientField" runat="server" Value="0" />
    <div class="row" id="Div1" style="display: none;">
        <div class="large-12 columns">
            <%--<IDD:ImpDed ID="impDed1" runat="server" />--%>
        </div>
    </div>
    <div id="spinner" class="spinner" style="display: none;">
        <center>
    <img id="img-spinner" src="ajax-loader.gif" alt="Loading"/>

    </center>
    </div>
    <asp:HiddenField ID="HiddenField14" runat="server" />
    <%--    </asp:UpdatePanel>--%>
    <asp:HiddenField ID="hdnleft" runat="server" Value="0" />
    <asp:HiddenField ID="hdntop" runat="server" Value="0" />
    <asp:HiddenField ID="hdntab" runat="server" Value="0" />
    <asp:HiddenField ID="hdnwidth" runat="server" Value="0" />
    <asp:HiddenField ID="hdnIndex" runat="server" Value="0" />
    <asp:HiddenField ID="hdnCount" runat="server" Value="0" />
    <%-- Following Button is to use for download files from dynamic buttons and we need to use it as .Net do not allow to download file from within Update Panel --%>
    <%-- <div class="hide-for-small-only hide-for-medium-only">
        <menu:side ID="Sidemenu" runat="server" />
    </div>   --%>
    <%--  <div class="hide-for-small-only hide-for-medium-only">
        <menu1:side1 ID="Side1" runat="server" />
    </div>   --%>
    <%-- <footer class="row">
        <div class="large-12 columns">--%>
    
    <%--  </div>
    </footer>--%>
    <%--<div id="popup_Files" style="display:none;" >
<asp:UpdatePanel ID="upd22FU" runat="server">
<ContentTemplate>
<fileupload:fu ID="fu1" runat="server" />
</ContentTemplate>
</asp:UpdatePanel>

</div>--%>
    <%-- Code to show Popup to upload/download files from Job Directory --%>
    <div id="popupdiv1" style="width: auto; display: none; min-height: 0px; height: 62.04px;
        position: absolute; top: 15%; left: 25%; width: 52%; height: 52%; padding: 16px;
        background-color: white; z-index: 1002;" class="ui-dialog-content ui-widget-content ui-corner-all">
        <%--  <div class="ui-dialog ui-widget ui-widget-content ui-corner-all">--%>
        <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix"
            style="padding: .2em 1em; position: relative;">
            <span class="ui-dialog-title" style="font-weight: bold; font-size: 19px;">Upload Files
                &nbsp;<span style="color: white; font-size: 12px;">(Extensions allowed: pdf,jpg,gif,png,doc,docx,xls,xlsx,xml,csv,txt,zip,rar)</span></span><a
                    id="close" href="#"><span style="font-weight: bold; font-size: 19px;">X</span></a>
        </div>
        <asp:Panel ID="pnlUCtrls" runat="server">
        </asp:Panel>
        <asp:UpdatePanel ID="updpnl22" runat="server">
        </asp:UpdatePanel>
        <p>
            <% if (Session["Project"].ToString() == "vt")
    {  %>
            <fileupload:fu ID="fu1" runat="server" />
            <%  }
    else if (Session["Project"].ToString() == "tds" || Session["Project"].ToString() == "tds2")
    {
            %>
            <fileupl_tds:fu ID="fu2" runat="server" />
            <%} %>
        </p>
        <%--</div>--%>
    </div>
    <div id="BlackContent" style="display: none; background-color: #101010; filter: alpha(opacity=70);
        opacity: .30; width: 100%; height: 800px; z-index: 400; position: absolute; top: 0;
        left: 0;">
    </div>
    <asp:HiddenField ID="hdnfloat" runat="server" />
    <asp:HiddenField ID="hdnSet_Tab" runat="server" />
    <asp:HiddenField ID="hdnsetback" runat="server" />
    </form>    
</body>
</html>
