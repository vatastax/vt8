<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>
<%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/blitzer/jquery-ui.css"
    rel="stylesheet" type="text/css" />--%>
<script type="text/javascript">
    //msg - is used for message which u want to display in popup
    //no_of_buttons- specified how many buttons will display in popup
    //title-title of popup window
    //fn_for_btn1-which function will run when click on button1
    //fn_for_btn2-which function will run when click on button2
    //fn_for_btn3-which function will run when click on button3
    //btn_names-name of the buttons passes in array like['yes','no','cancel']
    function alert_custom(msg, no_of_buttons, title, fn_for_btn1, fn_for_btn2, fn_for_btn3,btn_names) {
        $(document).ready(function () {

            var newDiv = $(document.createElement('div'));
            newDiv.html(msg);
            var Button1 = btn_names[0];  //assign the name of button1
            var Button2 = btn_names[1];  //assign the name of button2   
            var Button3 = btn_names[2]; //assign the name of button3  
            $.noConflict(true);
            if (no_of_buttons == 1) {
                newDiv.dialog({
              
                    title: title,
                    buttons: [{
                        text: Button1,
                        click: function () {
                            fn_for_btn1();
                          
                            (this).dialog('close');
                        }
                    }

               ]
                });
            }
            else if (no_of_buttons == 2) {
                newDiv.dialog({
                    title: title,
                    buttons: [
    {
        text: Button1,
        click: function ($) {
            fn_for_btn1();
         
            (this).dialog('close');
        }
    },
    {
        text: Button2,
        click: function ($) {
            fn_for_btn2();
        
            (this).dialog('close');
        }
    }
]
                });
            }
            else if (no_of_buttons == 3) {
                newDiv.dialog({
                    title: title,
                    buttons: [
    {
        text: Button1,
        click: function () {
            fn_for_btn1();
         
            (this).dialog('close');
        }
    },
    {
        text: Button2,
        click: function () {
            fn_for_btn2();
           
            (this).dialog('close');
        }
    },
    {
        text: Button3,
        click: function () {
            fn_for_btn3();
          
            (this).dialog('close');
        }
    }
]
                });
            }
            newDiv.dialog();
            //            $("#dialog").dialog({
            //                modal: true,
            //                autoOpen: false,
            //                title: 'jquery popup',
            //                width: 300,
            //                height: 150
            //            });
            // document.getElementById('dialog').innerHTML = newDiv.html();
            //document.getElementById('btnShow').click();
            //alert('kk');
            return false;
        });

    }
    $(document).ready(function () {
        $('#btnShow').click(function () {
            alert_custom('hello from jquery', 3, 'jquery title', fnbtn1, fnbtn2, fnbtn3,['yes','no','cancel'])
        });
    });
    
</script>
<script type="text/javascript">
    function fnbtn1() {
        alert('fn for btn1');
       
    }
    function fnbtn2() {
        alert('fn for btn2');
       
    }
    function fnbtn3() {
        alert('fn for btn3');
       
    }
</script>
 <input type="button" id="btnShow" value="Show Popup" />
 Hello to all
 <br />
 <div style="background-color:Red; width:300px; height:400px;">
 testing ...
 </div>
