//function for remove space between rows of t4 grid
function RemoveT4_Row_Space() {
    $('#GridViewDetails tr').each(function () {
        $(this).find('td').each(function () {
            //alert('hi');
            $(this).css("margin", "0");
            $(this).css("padding", "1px");
        });
    });
}

//Function - Common Message Alert Box

//msg - is used for message which u want to display in popup
//no_of_buttons- specified how many buttons will display in popup
//title-title of popup window
//fn_for_btn1-which function will run when click on button1
//fn_for_btn2-which function will run when click on button2
//fn_for_btn3-which function will run when click on button3
//btn_names-name of the buttons passes in array like['yes','no','cancel']

function alert_custom(msg, no_of_buttons, title, fn_for_btn1, fn_for_btn2, fn_for_btn3, btn_names, height1, top) {
    // $(document).ready(function () {

    var newDiv = $(document.createElement('div'));
    newDiv.html(msg);
    newDiv.css('height', height1);
    var Button1 = btn_names[0];  //assign the name of button1
    var Button2 = btn_names[1];  //assign the name of button2   
    var Button3 = btn_names[2]; //assign the name of button3  

    if (no_of_buttons == 1) {
        newDiv.dialog({

            title: title,
            height: height1.toString(),
          
            buttons: [{
                text: Button1,
                click: function () {
                    (newDiv).dialog('close');
                    // $('#divdisable').css('display', 'none');
                    $('#divdisable').css('display', 'none');
                    fn_for_btn1();


                }
            }

               ]
        });
    }
    else if (no_of_buttons == 2) {
        newDiv.dialog({
            title: title,
            height: height1.toString(),

            buttons: [
    {
        text: Button1,
        click: function ($) {
            (newDiv).dialog('close');
            $('#divdisable').css('display', 'none');
           // $('#divdisable').css('display', 'none');
            fn_for_btn1();


        }
    },
    {
        text: Button2,
        click: function ($) {
            (newDiv).dialog('close');
            $('#divdisable').css('display', 'none');
           // $('#divdisable').css('display', 'none');
            fn_for_btn2();



        }
    }
]
        });
    }
    else if (no_of_buttons == 3) {
        newDiv.dialog({
            title: title,
            height: height1.toString(),
            buttons: [
    {
        text: Button1,
        click: function () {
            (newDiv).dialog('close');
            $('#divdisable').css('display', 'none');
           // $('#divdisable').css('display', 'none');
            fn_for_btn1();


        }
    },
    {
        text: Button2,
        click: function () {
            (newDiv).dialog('close');
           $('#divdisable').css('display', 'none');
            fn_for_btn2();


        }
    },
    {
        text: Button3,
        click: function () {
            (newDiv).dialog('close');
            $('#divdisable').css('display', 'none');
            fn_for_btn3();


        }
    }
]
        });
    }
newDiv.dialog();
$('.ui-dialog').css('top', top.toString());
$('.ui-dialog').css('position', 'fixed');

    return false;
    //  });

}
//function disable background while popup will apper
function disablebackground() {
    if ($('div').hasClass('ui-dialog')) {
        $('#divdisable').css('display', 'block');
    }
    else {
        $('#divdisable').css('display', 'none');
    }
}
//function for remove left and right arrows when there is no tab
function RemovelftrgtArrows() {
    $('#lft').css("display", "none");
    $('#rgt').css("display", "none");
    $('div').removeClass("wrapper");
    $('div').removeClass("arrows");
    $('div').removeClass("numWrap");
    $('div').removeClass("arrows");

}
//function for change color of menu background on click
var MenuState = '';
var MenuMovement = '';
var IsMenuMove = 'true';
function MenuActive() {
    $('#cssmenu >ul>li').click(function () {
        var a = $(this).closest('span').html();
        var lstVal = $(this).html();
        var arrInfo = lstVal.toString().split('<span>');
        //alert(arrInfo[1].replace('</span></a>', ''));
        //document.getElementById('hdnMenuState').value = arrInfo[1].replace('</span></a>', '');
        MenuState = arrInfo[1].replace('</span></a>', '');
        $(this).addClass('active');

    });
}

var countli_tmp = 0;
var Countli = new Number();
var countli_val = '';
function Get_Menu_Counter() {
    try {
        countli_tmp = 0;
        $('#cssmenu >ul>li').each(function () {
            if ($(this).hasClass('active')) {
                countli_val = countli_tmp;
                $(this).removeClass('active');
            }
            countli_tmp = countli_tmp + 1;
        })
        //alert('countli_val : ' + countli_val);
    }
    catch (e) {
        alert(e);
    }
}

function Get_Menu_Status(val) {
    //    $('#cssmenu >ul>li').each(function () {
    //        
    //        if (MenuMovement == '1') {
    //              //alert('1');
    //            var lstVal = $(this).html();
    //            var arrInfo = lstVal.toString().split('<span>');
    //            // alert(arrInfo[1].replace('</span></a>', ''));
    //            $(this).removeClass('active');
    //             alert('menu status=' + MenuState);
    //            if (arrInfo[1].replace('</span></a>', '') == MenuState) {
    //                //  alert('match');
    //                // $('#cssmenu>ul>li').first().removeClass('active');
    //                $(this).addClass('active');
    //            }
    //            //  MenuMovement = '';
    //            //  MenuState = $(this).val();
    //            // IsMenuMove = 'false';
    //        }

    //    })

    //$('#cssmenu>ul>li').eq((parseInt(countli_val) - 1)).removeClass('active');
    //alert(countli_val);
    $('#cssmenu>ul>li').each(function () {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
        }
    })
    if (val == '1')
        $('#cssmenu>ul>li').eq(parseInt(countli_val) + 1).addClass('active');
    else
        $('#cssmenu>ul>li').eq(parseInt(countli_val) - 1).addClass('active');
}

function Get_Menu_Status_Main() {
    $('#cssmenu >ul>li').each(function () {
        var lstVal = $(this).html();
        var arrInfo = lstVal.toString().split('<span>');
        if (MenuState != '')
            $(this).removeClass('active');
        if (arrInfo[1].replace('</span></a>', '') == MenuState) {
            // $('#cssmenu>ul>li').first().removeClass('active');
            $(this).addClass('active');
        }
        else {
            //$('#cssmenu>ul>li').first().addClass('active');
        }
    });
}
//function remove "+" image from menu
function Removeplusimage_menu() {
    $('#cssmenu > ul > li > a').click(function () {
        $('#cssmenu li').removeClass('active');
        $(this).closest('li').addClass('active');
        var checkElement = $(this).next();
        if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
            //alert('1');
            $(this).closest('li').removeClass('active');
            checkElement.slideUp('normal');
        }
        if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
            // alert('2');
            $('#cssmenu ul ul:visible').slideUp('normal');
            checkElement.slideDown('normal');
        }
        if ($(this).closest('li').find('ul').children().length == 0) {
            //alert('3');
            return true;
        } else {
            // alert('4');
            return false;
        }
    });
}

function Remove() {
    $('#cssmenu>ul>li>a').each(function () {
        if ($(this).closest("li").children("ul").length == 0) {
            $(this).closest("li").removeClass('has-sub');
            // alert('not ul');
        }
        else {
            // $(this).removeClass('has-sub');
            // alert('having ul');
        }
    })
}
//function remove hr conditionally
function Removehr() {
    //alert('hr');
    $(document).ready(function () {
        if ($('.cbdb-menu_new1').length == 0) {
            $('#hrnew').css("display", "none");
            //alert('if');
        }
        else {
            $('#hrnew').css("display", "block");
            //alert('not if');
        }
    });
}

//function for remove arrows in case of no of tabs are less
function RemoveArrows() {
    var $wrap = $("#numWrap"), $strip = $("#strip"),
            $leftArrow = $(".wrapper > .arrows").first(),
         wrapWidth = $wrap.width() + $leftArrow.width(),
          margin = 10, flag, height1 = $("#strip").height();
    height1 = (height1 / 38);
    // alert(height1);
    // alert($('#hdnCount').val());
    if (height1 == 1) {
        //alert('12');
        $('#lft').css("display", "none");
        $('#rgt').css("display", "none");
        $('div').removeClass("arrows");
    }

}

//maintain position of tab after postback in salary.aspx
function tab() {

    var $wrap = $("#numWrap"), $strip = $("#strip"),
                $leftArrow = $(".wrapper > .arrows").first(),
                wrapWidth = $wrap.width(),
                margin = 10, left = 0; //declare variables for divs in which tabs are placed
    $strip.on("click", ".numberItem", function () { select($(this)); });
    $(".wrapper").on("click", "a.arrow", function () { //wrapper is div with left and right arrows alongwith tabs
        var stripPos = $strip.position(); //strip is innerdiv of wrapper
        var height = $("#strip").height(); //find height of strip div 
        if (this.id == "lft") { //if left arrow is clicked
            if ($('#hdnCount').val() == 1) { //hdncount is a variable which is increment on right arrow click and decrement on left arrow click
                // //alert(height1);
                $('#lft').css("display", "none"); //hide left arrow if data is not avaible on left side
                $('#rgt').css("display", "block"); //hide right arrow if data is not avaible on right side
            }
            else {
                //  //alert('jj');
                $('#lft').css("display", "block"); //if hdncount is larger than one

            }
            if ($('#hdnCount').val() < 0) {
                $('#hdnCount').val(0);
            }
            var con;
            height = (height / 38); //becoz one scroll height is 38 so find the no. of scroll
            // //alert(height);
            if (height > 1 && height < 2) {
                con = -((wrapWidth / 2) * 2);  //find the scrolling of strip
            }
            if (height >= 2) {
                con = -((wrapWidth / 2) * height); //wrapwidth is wrapper width
            } else {
                con = -((wrapWidth / 2));
            }

            var mov = stripPos.left + wrapWidth;
            if (((stripPos.left + wrapWidth) > 0 && (stripPos.left + wrapWidth) < 1)) {
                mov = -1;
            }
            var condition = ((wrapWidth * 2) / height);
            if (condition < 887 && condition > 885) {
                // //alert('gh');
                condition = 888;
            }
            // //alert('condition=' + condition);
            if (con <= (stripPos.left + wrapWidth) && (stripPos.left < condition)) { //condition for stopping left click if no data is available on left side
                if ($strip.width() - $wrap.width() > 0) {
                    $strip.css({ "left": (stripPos.left + (wrapWidth / 2)) });
                }
            }
            // }
            $('#hdnCount').val(parseInt($('#hdnCount').val()) - 1); //decrement of hdncount on click on left arrow 
        } else {
            var height1 = $("#strip").height();
            height1 = (height1 / 38);
            //alert('height1=' + height1);
            var con;
            height = (height / 38);
            if (height > 1 && height < 2) {
                con = -((wrapWidth / 2) * 2);

            }
            if (height > 2) {
                ////alert('GH');
                con = ((wrapWidth / 2) * height);
            } else {
                con = ((wrapWidth / 2));
            }

            if ((parseInt(con + left) >= parseInt(wrapWidth / 2))) {
                if (stripPos.left == -425.5) {
                    stripPos.left = -427;
                }
                ////alert('height1=' + height);
                //alert('hdncount=' + $('#hdnCount').val());
                if (height1 == 1 || height == 1) {
                    // //alert('1');

                    $('#rgt').css("display", "none");
                    $('#lft').css("display", "block");
                }
                else {
                    if (stripPos.left >= ((-425 * height) - 1)) {
                        $strip.css({ "left": parseFloat(stripPos.left) - parseFloat(wrapWidth / 2) });
                        height1 = $("#strip").height() - 38;
                        height1 = (height1 / 38);
                        $('#rgt').css("display", "block");
                        if (height1 == 1 && $('#hdnCount').val() == 0) {
                            //alert('height1=' + height1);
                            //alert('hdncount=' + $('#hdnCount').val());
                            $('#rgt').css("display", "none");
                            $('#lft').css("display", "block");
                            // //alert('2');
                            // //alert($('#hdnCount').val());
                        }
                        else {
                            $('#rgt').css("display", "block");
                            // //alert('3');
                        }
                    }
                }
            }

            $('#hdnCount').val(parseInt($('#hdnCount').val()) + 1);
        }
    });
    $('#strip ul li a').hover(function () {  //on hover of tab store its left and top position in hiddenvariable
        var stripPos = $strip.position();
        var pos = $(this).position();
        $(this).css({ "left": pos.left });
        $(this).css({ "top": pos.top });
        //   //alert(pos.left);
        $('#hdnleft').val(pos.left);
        $('#hdntop').val(pos.top);
        $('#hdntab').val(this.text);
        $('#hdnwidth').val(stripPos.left);

    });

    var arr = jQuery.makeArray($('#strip ul li a'));

    var flag = 0;
    var width = 0;
    $('#cbdb-menu_id').find('a').each(function () {
        if ($('#hdntab').val() != null) {
            if (this.text == $('#hdntab').val()) {

                flag = 1;
            }
        }
        if (flag != 1) {
            //width = $(this).innerWidth() + width;
            width = ($(this).width() + 32) + width;
        }
        if ($('#hdntab').val() != null) {
            if (this.text == $('#hdntab').val()) {
            }
            var height1 = $("#strip").height();
            height1 = (height1 / 38);
            // //alert(height1);
            if (height1 != 1 && $('#hdnCount').val() == 0) {
                ////alert('12');
                $('#lft').css("display", "none");
                ////alert('1');
            }
            else if (height1 == 1 && $('#hdnCount').val() > 0) {
                $('#rgt').css("display", "block");
            }
            var left = $('#hdnleft').val();
            var top = $('#hdntop').val();
            var left1 = $('#hdnwidth').val();
            //  var r = $('#<%= hdnIndex.ClientID %>').val();
            if (parseInt(left1) == 0 && $('#hdnCount').val() == 0) { //if tab's position in first scroll
                //$strip.css({ "margin-left": (-756 + left) });
                var num = -(parseFloat(width));
                ////alert('left=0');
                // //alert('width=' + width);
                $strip.css({ "margin-left": left1 });
                $(this).css({ "left": num })
                $(this).css({ "top": top })
                // //alert('case1');
                //alert('1');

            }
            else if (parseInt(left1) == 0 && $('#hdnCount').val() > 0) {//if in not in first scroll
                // //alert('tt');
                var $wrap = $("#numWrap");
                var $p = $("#Strip");
                var wrapWidth = $p.width() - $wrap.width();
                var p = (wrapWidth / 2);
                p = (parseFloat(p)) + "px";
                if ($('#hdnCount').val() > 2) { //second scroll
                    p = parseFloat(p) * 3;
                    p = (parseFloat(p)) + "px";
                    // alert('2');

                }
                else if ($('#hdnCount').val() > 1) { //first scroll
                    p = (wrapWidth / 2);
                    p = parseFloat(p) * 2;
                    p = (parseFloat(p)) + "px";
                    //alert('3');

                }
                else {
                    p = 0;
                    //alert(p);
                }
                // //alert('p=' + p);
                // alert(p);
                // alert($('#hdnCount').val());
                $strip.css({ "margin-left": p }); //finally apply css for margin-left
                $(this).css({ "left": width })
                $(this).css({ "top": top })
            }

            else {

                var num = -(parseFloat(left1) + parseFloat(width));
                // var num = -(width);
                if (num != NaN)
                    if ($('#hdnCount').val() > 2 && left1 > -(width / 2)) {
                        left1 = left1 * 3;
                        //alert('4');
                        //alert('left1=' + left1);
                        //alert('(width / 2)' + (width / 2));

                    }
                    else if ($('#hdnCount').val() > 1 && left1 > -(width / 2)) {
                        left1 = left1 * 2;
                        ////alert('5');


                    }


                if ($('#hdnCount').val() < 1 && left1 > (width / 2)) {
                    left1 = 0;
                    ////alert('6');


                    ////alert('case7');
                }
                else if ($('#hdnCount').val() < 2 && left1 > (width / 2)) {
                    left1 = -parseFloat(left1);
                    ////alert('case8');
                    // //alert('7');

                }
                else if ($('#hdnCount').val() < 3 && left1 > (width / 2)) {
                    left1 = -parseFloat(left1);
                    ////alert('case9');
                    ////alert('8');

                }
                else if ($('#hdnCount').val() > 2 && left1 < -(width / 2)) {
                    left1 = left1;
                    ////alert('case10');
                    ////alert('9');

                }

                var p = left1 + "px";
                $strip.css({ "margin-left": p });
                $(this).css({ "left": width })
                $(this).css({ "top": top })
            }
        }
    });

}
function SetMenuStatus() {
    var a = $(this).closest('span').html();
    var lstVal = $(this).html();
    //alert(lstVal);
    if (lstVal != null) {
        var arrInfo = lstVal.toString().split('<span>');
        //alert(arrInfo[1].replace('</span></a>', ''));
        //document.getElementById('hdnMenuState').value = arrInfo[1].replace('</span></a>', '');
        MenuState = arrInfo[1].replace('</span></a>', '');
        $(this).addClass('active');
    }
}
//function for set tab at first textbox of grid
function setTabPosition() {
    try {
        var arrTextBoxes = [];
        var v = $("#grdState tr").find("input[type=text][id*=txtAmount]").first().attr('id');
        var v1 = $("#grdState tr").find("select").first().attr('id');
        if (v == 'grdState_ctl02_txtAmount') {
            $('input:text:first').focus();
            //setTabbingIndx(v)
            // $('#hdnCtrlTabIndx').val('grdState_ctl02_txtAmount');
            //alert($('#hdnCtrlTabIndx').val());
        }
        else if (v1 == 'grdState_ctl02_ddl1') {
            $('#grdState_ctl02_ddl1').focus();
            // alert('dropdown');
            //$("#grdState_ctl02_ddl1").val($("#grdState_ct102_ddl1 option:first").val());
            //$('#hdnCtrlTabIndx').val('grdState_ctl02_ddl1');
            //setTabbingIndx(v1
            // alert($('#hdnCtrlTabIndx').val());
        }
        else {
            $("#grdState").find("input[type=text][id*=txtAmount]").each(function () {
                $(this).focus();
                // alert('else');
                //$('#hdnCtrlTabIndx').val(this);
                // alert($('#hdnCtrlTabIndx').val());
                //setTabbingIndx(this)
                return false;
            })

        }
    }
    catch (e) { alert(e) }
}
//for off the autocomplete of control on form
function OffautoComplete() {
    $('#form1').on('focus', ':input', function () {
        $(this).attr('autocomplete', 'off');
    });
}

function setCursorFloatgrd() {
    $(document).ready(function () {
        var Firsttxt = $('#GridViewFlaoting tr').last().find('input[type=text]').first().attr('id');
        if (Firsttxt != null) {
            document.getElementById(Firsttxt).focus();
        }
    });
}
function Cursor_FloatGrid(id) {
    //    try {
    //alert('ggg');
    //alert(id);
    $("#GridViewFlaoting td").each(function () {
        try {
            //alert(id);
            if ($(this).find("input[type=text]").attr('id') == id) {
                // alert('matched');
                // $(id).focusout(function () {
                // alert('gg');
                var dropdown = $(this).next().find("select").attr('id');
                if (dropdown != undefined) {
                    //var arrdropdown = dropdown.split("_");
                    // alert('dropdown');
                    $(dropdown).focus();
                    document.getElementById(dropdown).focus();

                }
                else {
                    // alert('not matched');
                    var txt = $(this).next().find("input[type=text]").attr('id');
                    setTimeout(function () {
                        $(txt).focus();
                    }, 1000);
                    var txt1 = txt.split('_');
                    document.getElementById(txt).focus();
                    // $(":focus").css("background-color", "yellow");

                    //   $(txt).css("backgroundcolor", "red");
                    // alert('id : ' + txt);

                    //alert('textbox');
                }

                //});
            }
            else if ($(this).find("select").attr('id') == id) {
                //  alert('matched1');
                var dropdown = $(this).next().find("select").attr('id');
                if (dropdown != undefined) {
                    //var arrdropdown = dropdown.split("_");
                    // alert('dropdown');
                    $(dropdown).focus();
                    document.getElementById(dropdown).focus();


                }
                else {
                    // alert('not matched1');
                    var txt = $(this).next().find("input[type=text]").attr('id');

                    $(txt).focus();
                    document.getElementById(txt).focus();
                }
            }
        }
        catch (e) {
            alert(e);
        }
    })
}
//fn for set positioning of cursor in textboxes of grids and continue button
function Cursor_FloatGrid(id, grdid) {
    //alert(id);
    var gridtd = "";
    var grid = "#" + grdid + " tr";
    if (grdid == 'grdState') {
        gridtd = "#" + grdid + " tr";
    }
    else if (grdid == 'GridViewFlaoting') {
        gridtd = "#" + grdid + " td";
    }
    var lasttxt = $(grid).last().find('input[type=text]').last().attr('id');
    $(gridtd).each(function () {
        try {
            if ($(this).find("input[type=text]").attr('id') == id) {
                var dropdown = $(this).next().find("select").attr('id');
                if (dropdown != undefined) {
                   // alert('dropdown');
                    $(dropdown).focus();
                    document.getElementById(dropdown).focus();
                }
                else {
                    var txt = $(this).next().find("input[type=text]").attr('id');
                    //alert('textbox');
                    if (txt != undefined) {
                        //alert('');
                        document.getElementById(txt).focus();
                    }
                    else {
                        document.getElementById('btnCont_Inp').focus();
                    }
                }

            }
            else if ($(this).find("select").attr('id') == id) {

                var dropdown = $(this).next().find("select").attr('id');
                if (dropdown != undefined) {
                   // alert('dropdown1');
                    $(dropdown).focus();
                    document.getElementById(dropdown).focus();
                }
                else {
                    var txt = $(this).next().find("input[type=text]").attr('id');

                    if (txt != undefined) {
                        //alert(txt);
                       // alert('textbox1');
                        $(txt).focus();
                        document.getElementById(txt).focus();
                    }
                    else {
                        //alert('btn');
                        document.getElementById('btnCont_Inp').focus();
                    }
                }
            }
            else {
            }
        }
        catch (e) {
            // alert(e);
        }
    })
}
//set field for click on menu for calling settabgrid function
function setfield() {
    $('#cssmenu li a').click(function () {
        document.getElementById('hdnSet_Tab').value = 'true';
    });
}
function openDialog() {
    //alert('in func');
    setTimeout(openDialog2, 100);
}
function openDialog2() {
    if (jQuery.isReady) {
        $(document).ready(function () {
            $('#aFiles2').click();
        });
    }
    else
        setTimeout(openDialog2, 100);
}

function Fileupload() {
    $(document).ready(function () {
        $('#aFiles2').click(function () {
            //                document.getElementById('hdnAysn').value = 'true';
            $('#popupdiv1').css("display", "block");
            $('#BlackContent').css("display", "block");
        });
        $('#aFiles3').click(function () {
            //                document.getElementById('hdnAysn').value = 'true';
            $('#popupdiv1').css("display", "block");
            $('#BlackContent').css("display", "block");
        });
        $('#close').click(function () {
            $('#popupdiv1').css("display", "none");
            $('#BlackContent').css("display", "none");
            //                document.getElementById('hdnAysn').value = 'false';
        });
    });
}

function pop() {

    var grid = $("#fu1_gvDetails > tbody > tr").length;
    if (grid > 0) {
        $('#btnbuttons').css("display", "block");
        $('#hh').css("display", "block");
        $('#divmsg').css("display", "none");

        $('#fu1_gvDetails th').each(function () {
            $(this).css("margin", "0");
            $(this).css("padding", "3px");
        });
        $('#fu1_gvDetails').find('th').eq(0).css("padding-top", "15px");
        $('#fu1_gvDetails tr').each(function () {
            $(this).find('td').each(function () {
                //alert('hi');
                $(this).css("margin", "0");
                $(this).css("padding", "3px");
                //$(this).css("padding-left", "");
                //$('#grdState th').css("padding-left", "");
            });
        });
        $('#fu1_btn_Download').css("background-color", "#e54658");
        $('#fu1_btn_Download').css("border", "#e54658");
        $('#fu1_btn_Download').css("border-radius", "5px");
        $('#fu1_btn_Download').css("color", "white");
        $('#fu1_btn_Download').css("width", "120px");
        $('#fu1_btn_CloseDownload').css("background-color", "#e54658");
        $('#fu1_btn_CloseDownload').css("border", "#e54658");
        $('#fu1_btn_CloseDownload').css("border-radius", "5px");
        $('#fu1_btn_CloseDownload').css("color", "white");
    }

    grid = $("#fu2_gvDetails > tbody > tr").length;
    if (grid > 0) {
        $('#btnbuttons').css("display", "block");
        $('#hh').css("display", "block");
        $('#divmsg').css("display", "none");

        $('#fu2_gvDetails th').each(function () {
            $(this).css("margin", "0");
            $(this).css("padding", "3px");
        });
        $('#fu2_gvDetails').find('th').eq(0).css("padding-top", "15px");
        $('#fu2_gvDetails tr').each(function () {
            $(this).find('td').each(function () {
                //alert('hi');
                $(this).css("margin", "0");
                $(this).css("padding", "3px");
                //$(this).css("padding-left", "");
                //$('#grdState th').css("padding-left", "");
            });
        });
        $('#fu2_btn_Download').css("background-color", "#e54658");
        $('#fu2_btn_Download').css("border", "#e54658");
        $('#fu2_btn_Download').css("border-radius", "5px");
        $('#fu2_btn_Download').css("color", "white");
        $('#fu2_btn_Download').css("width", "120px");
        $('#fu2_btn_CloseDownload').css("background-color", "#e54658");
        $('#fu2_btn_CloseDownload').css("border", "#e54658");
        $('#fu2_btn_CloseDownload').css("border-radius", "5px");
        $('#fu2_btn_CloseDownload').css("color", "white");
    }
}
function CheckRowCheckBoxes() {
    $("[id*=chkSelectHeader]").live("click", function () {
        var chkHeader = $(this);
        var grid = $(this).closest("table");
        $("input[type=checkbox]", grid).each(function () {
            if (chkHeader.is(":checked")) {
                $(this).attr("checked", "checked");
                $("td", $(this).closest("tr")).addClass("selected");
            } else {
                $(this).removeAttr("checked");
                $("td", $(this).closest("tr")).removeClass("selected");
            }
        });
    });
    $("[id*=chkRow]").live("click", function () {
        var grid = $(this).closest("table");
        var chkHeader = $("[id*=chkHeader]", grid);
        if (!$(this).is(":checked")) {
            $("td", $(this).closest("tr")).removeClass("selected");
            chkHeader.removeAttr("checked");
        } else {
            $("td", $(this).closest("tr")).addClass("selected");
            if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                chkHeader.attr("checked", "checked");
            }
        }
    });
}
//function for highlight menu according to vtype
function HighlightSelectedMenu(val) {
    try {
        //alert('ggg');

        $('#cssmenu ul li').each(function () {
            $(this).removeClass('active');
            var Vtype = $(this).find('a').attr('onclick');
            // alert(Vtype);
            if (Vtype != undefined) {
                if (Vtype.indexOf('_') > -1) {
                    var V = Vtype.split('_');
                    Vtype = V[0];
                }
                // alert('Vtype='+Vtype);
                var VtypeInfo = Vtype.toString().split('(');
                //alert('vtype='+VtypeInfo[1].slice(0, -2));
                // alert('val=' + val);
                if (val.indexOf('_') > -1) {
                    var valInfo = val.split('_');
                    val = valInfo[0];
                }
                if (val == VtypeInfo[1].slice(0, -2)) {
                    //alert('matched');
                    $(this).addClass('active');
                }
            }
        })
    }
    catch (e) {
        alert(e);
    }
}
//hide column on the basis of if textbox and dropdown not appear 
function HideColumn(GrdName, Column) {
    try {
        var flag = 0;
        var textVal = "", inputName = "", formData = "";
        //        alert(GrdName);
        $('#' + GrdName + ' tr').each(function () {
            $(this).find("td input:text,td select").each(function () {
                textVal = this.value;
                inputName = $(this).attr("name");
                formData += '&' + inputName + '=' + textVal;
            });

        })
        if (inputName == "") {
            var header = GrdName + " tr th:nth-child(" + Column + ")";
            $('#' + header).css('display', 'none');
        }
        // alert(textVal);
        // alert(inputName);
    }
    catch (e) {
        alert(e);
    }
}
function HideColumn1(GrdName, Column) {
    try {

        var header = GrdName + " tr th:nth-child(" + Column + ")";
        $('#' + header).css('display', 'none');
        $('#' + GrdName + ' tr').each(function () {
            var hiide = $(this).find("td").eq(parseInt(Column) - 1);
            (hiide).css('display', 'none');
        })
    }


    catch (e) {
        alert(e);
    }
}