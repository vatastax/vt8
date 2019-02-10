//function for movement of strip on arrows(left and right) click
$(document).ready(function () {

    var $wrap = $("#numWrap"), $strip = $("#strip"),
            $leftArrow = $(".wrapper > .arrows").first(),
         wrapWidth = $wrap.width() + $leftArrow.width(),
          margin = 10, flag, height1 = $("#strip").height();
    height1 = (height1 / 38);
    //alert(height1);
    if (height1 != 1 && $('#hdnCount').val() == 0) {
        //alert('12');
        $('#lft').css("display", "none");
    }
    else if (height1 == 1 && $('#hdnCount').val() > 0) {
        $('#rgt').css("display", "block");
    }

    $(".wrapper").on("click", "a.arrow", function () {
        var stripPos = $strip.position(); //find position of strip
        var height = $("#strip").height();
        height1 = $("#strip").height();
        height1 = (height1 / 38);
        if (height1 == 1 && parseInt($('#hdnCount').val() == 0)) {
            // alert(height1);
            $('#lft').css("display", "none");
        }
        else {

            $('#lft').css("display", "block");
        }
        if (this.id == "lft") {  //on left arrow click
            // alert($('#hdnCount').val());
            if ($('#hdnCount').val() >= 1) {
                //alert(height1);
                //$('#lft').css("display", "none");
                $('#rgt').css("display", "block");
            }
            else {

                $('#lft').css("display", "none");
            }
            var con;
            height = (height / 38);
            // alert(height);
            if (height > 1 && height < 2) {
                con = -((wrapWidth / 2) * 2);
            }
            if (height >= 2) {
                con = -((wrapWidth / 2) * height);
            } else {
                con = -((wrapWidth / 2));
            }
            //  alert(con);
            //  alert(stripPos.left);
            if (con <= (stripPos.left + wrapWidth) && (stripPos.left < 0)) {
                $strip.css({ "left": stripPos.left + (wrapWidth / 2) }); //move left to strip by half of wrapwidth
            }
            $('#hdnCount').val(parseInt($('#hdnCount').val()) - 1);
            //alert($('#hdnCount').val());
            //}
        } else {//on click on right arrow
            //if ($('#numWrap li').first().position().left < 0) {
            // alert('RIGHT');
            // alert(height1);
            var height1 = $("#strip").height();
            height1 = (height1 / 38);
           // alert('rgt=' + height1);
            if (height1 == 1) {

                $('#rgt').css("display", "none");
                $('#lft').css("display", "block");
                return false;
            }
            else {
                $('#rgt').css("display", "block");
            }
            var con;
            height = (height / 38);


            if (height > 1 && height < 2) {
                con = -((wrapWidth / 2) * 2);
            }
            if (height >= 2) {
                con = ((wrapWidth / 2) * height);
            } else {
                con = ((wrapWidth / 2));
            }
            //alert(height);
           // alert(con);
           // alert(stripPos.left + wrapWidth);
            if (con > (stripPos.left + (wrapWidth / 2)) && (stripPos.left + wrapWidth >= 0)) {
                if (stripPos.left >= ((-425 * height))) {
                    $strip.css({ "left": stripPos.left - (wrapWidth / 2) });
                    // var height1 = $("#strip").height();
                    height1 = $("#strip").height() - 38;
                    // alert(height1);
                    height1 = (height1 / 38);
                    // alert(height1);
                    // if (height1 == 1) {

                    //rgt').css("display", "none");
                    //$('#lft').css("display", "block");
                    //return false;
                    // }
                    //  else {
                    //     $('#rgt').css("display", "block");
                    // }
                }

            }

            // }
            //alert(wrapWidth);
            // alert('jk');
            $('#hdnCount').val(parseInt($('#hdnCount').val()) + 1);
            //alert($('#hdnCount').val());
        }
    });
    //save location of clicked tab
    $('#strip ul li a').hover(function () {
        // alert('hover');
        var pos = $(this).position();
        var stripPos = $strip.position();
        $('#hdnleft').val(pos.left);
        //  alert('hover');
        $('#hdntop').val(pos.top);
        $('#hdntab').val(this.text);
        $('#hdnwidth').val(stripPos.left);
        $('#hdnIndex').val($('a').index(this));
        // alert(this.text);
    });
    //relocate to selected tab on page load
    $('#cbdb-menu_id').find('a').each(function () {
        if (this.text == $('#hdntab').val()) {

            var left = $('#hdnleft').val();
            var top = $('#hdntop').val();
            $strip.css({ "margin-left": (-left + 100) });
            $(this).css({ "margin-left": left })
            $(this).css({ "top": top })
        }
    });
    //on click on tab relocate again
    $('#strip a').click(function () {
        //alert('tab');
        var pos = $(this).position();
        var stripPos = $strip.position();
        $(this).css({ "left": pos.left });
        $(this).css({ "top": pos.top });
        $('#hdnleft').val(pos.left);
        $('#hdntop').val(pos.top);
        $('#hdntab').val(this.text);
        $('#hdnwidth').val(stripPos.left);
        $('#cbdb-menu_id').find('a').each(function () {
            if (this.text == $('#hdntab').val()) {
                var left = $('#hdnleft').val();
                var top = $('#hdntop').val();
                $strip.css({ "margin-left": (left) });
                $(this).css({ "margin-left": left })
                $(this).css({ "top": top })
            }
        });

    });
    if ($('#numWrap li').length < 5) {
        $('#lft').css("display", "none");
        $('#rgt').css("display", "none");
        $('div').removeClass("arrows");
    }
    var strlen = "";
    $('#numWrap').find('a').each(function () {
        strlen = strlen + (this.text);

    });
    // alert(strlen.length);
    if (strlen.length > 100) {
        // alert(strlen.length);
        // alert(strlen);
    }
    if ($('#numWrap li').length == 0) {
        $('#lft').css("display", "none");
        $('#rgt').css("display", "none");
        $('div').removeClass("wrapper");
        $('div').removeClass("arrows");
        $('div').removeClass("numWrap");
        $('div').removeClass("arrows");
    }

});
 