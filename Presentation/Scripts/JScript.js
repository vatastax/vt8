//for change control grid look
function pageLoad(sender, args) {
    (function ($) {
        // $("#ControlGrid table").addClass("responsive");
//        $(".VGrid td:nth-child(3)").hide();
//        $(".VGrid th:nth-child(3)").hide();

//        $("#VGrid1_GV_VGrid1 td:nth-child(3)").hide();
//        $("#VGrid1_GV_VGrid1 th:nth-child(3)").hide();
        $('#dny_Grd_ITRInfo_Dynamic_Gridview').find('input[type="submit"]').addClass('button');
        $('#dny_Grd_ITRInfo_Dynamic_Gridview').find('input[type="submit"]').addClass('radius');
        $('#dny_Grd_ITRInfo_Dynamic_Gridview').find('input[type="submit"]').removeAttr('style');
        $('#dny_Grd_ITRInfo_Dynamic_Gridview').find('input[type="submit"]').css('background-color', '#e14658');
        $('#dny_Grd_ITRInfo_Dynamic_Gridview').find('input[type="submit"]').css('width', '130px');
        $('#dny_Grd_ITRInfo_Dynamic_Gridview').find('input[type="submit"]').css('padding', '10px');
        $('#dny_Grd_ITRInfo_Dynamic_Gridview').find('input[type="submit"]').css('margin-left', '420px');
        $('#dny_Grd_ITRInfo_Dynamic_Gridview').find('input[type="submit"]').css('font-weight', 'bold');
        $("#ControlGrid table").css(
{ "margin": "0", "padding": "0", "border": "solid 1px #ddd" }
)
        $("#ControlGrid table th").css(
        { "color": "white", "background-color": "#494e6b", "height": "37px" }

        )
        //vatasgrid style
        $(".VGrid table").css(
{ "margin": "0", "padding": "0", "border": "solid 1px #ddd" }
)
        $(".VGrid table th").css(
        { "color": "white", "background-color": "#494e6b", "height": "37px" }

        )
        $(".VGrid table ").css(
        { "width": "100%" }

        )
        //on hover of vgrid
        $(".VGrid table tr ").mouseenter(function () {
            $(this).css({ "background-color": "rgba(25, 185, 154, 0.36)" })
        });

        $("#VGrid1 table").css(
{ "margin": "0", "padding": "0", "border": "solid 1px #ddd" }
)
        $("#VGrid1 table th").css(
        { "color": "white", "background-color": "#494e6b", "height": "37px" }

        )
        $("#VGrid1 table ").css(
        { "width": "100%" }

        )
        //on hover of vgrid
        $("#VGrid1 table tr ").mouseenter(function () {
            $(this).css({ "background-color": "rgba(25, 185, 154, 0.36)" })
        });



        if ($("#hdnRegularCorrection").val() == "Correction") {
            //                $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
            //                $("#ControlGrid table tr:odd").css("background-color", "White");

            for (var i = 0; i < $("#ControlGrid table tr").length; i++) {
                if ($("#hdnFiller").val() == "M") {
                    //alert("A");
                    $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
                    $("#ControlGrid table tr:odd").css("background-color", "White");
                }
                else if ($("#hdnFiller").val() == "U") {
                    //alert("B");
                    //$("#ControlGrid table tr:even").css("background-color", "Green");
                    $("#ControlGrid table tr").css("background-color", "Red");
                }
                else if ($("#ControlGrid table").find("tr:eq(" + i + ")").find("td:eq(11)").text() == "0") {
                    //alert("C");
                    try {
                        $("#ControlGrid table tr:eq(" + i + ")").find("td:eq(2)").css("background-color", "Red");
                    }
                    catch (e) {
                        //alert(e);
                    }
                    //alert($("#ControlGrid table tr").length);
                    //alert(i);
                }
                else {
                    //alert("D");
                    $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
                    $("#ControlGrid table tr:odd").css("background-color", "White");
                }
            }
        }
        else {
            //alert("else1");
            $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
            $("#ControlGrid table tr:odd").css("background-color", "White");
        }
        $('#dny_Grd_ITRInfo_Dynamic_Gridview').css(
          { "width": "100%" }
          )
//        $('#dny_Grd_ITRInfo_Dynamic_Gridview_ctl03_Btn_Cancel_Search').css(
//            { "border-radius": "3", "top": "-3", "left": "2", "background-color": "#007095", "color": "White" }
//            )
//        $('#dny_Grd_ITRInfo$Dynamic_Gridview$ctl12$Btn_Cancel_Search').css(
//            { "border-radius": "3", "top": "-3", "left": "2", "background-color": "#007095", "color": "White" }
//            )
        $("#ControlGrid table input[type=text]").css(
        "border", "1px solid rgba(177, 224, 215, 0.61)"
        )
        //  $("table").addclass('responsive');
    })(jQuery);
    //on partial page load
    if (args.get_isPartialLoad()) {
        // $("#ControlGrid table").addClass("responsive");
        $("#ControlGrid table").css(
{ "margin": "0", "padding": "0", "border": "solid 1px #ddd" }
)
        $("#ControlGrid table th").css(
        { "color": "white", "background-color": "#494e6b", "height": "37px" }

        )
        //        $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
        //                $("#ControlGrid table tr:odd").css("background-color", "White");
        if ($("#hdnRegularCorrection").val() == "Correction") {
            //                $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
            //                $("#ControlGrid table tr:odd").css("background-color", "White");

            for (var i = 0; i < $("#ControlGrid table tr").length; i++) {
                if ($("#hdnFiller").val() == "M") {
                    //alert("E");
                    $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
                    $("#ControlGrid table tr:odd").css("background-color", "White");
                }
                else if ($("#hdnFiller").val() == "U") {
                    //alert("F");
                    //$("#ControlGrid table tr:even").css("background-color", "Green");
                    $("#ControlGrid table tr").css("background-color", "Red");
                }
                else if ($("#ControlGrid table").find("tr:eq(" + i + ")").find("td:eq(11)").text() == "0") {
                    //alert("G");
                    $("#ControlGrid table").Find("tr:eq(" + i + ")").find("td:eq(11)").css("background-color", "Red");
                }
                else {
                    //alert("H");
                    $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
                    $("#ControlGrid table tr:odd").css("background-color", "White");
                }
            }
        }
        else {
            //alert("else2");
            $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
            $("#ControlGrid table tr:odd").css("background-color", "White");
        }

        $('#dny_Grd_ITRInfo_Dynamic_Gridview').css(
          { "width": "100%" }
          )
//        $('#dny_Grd_ITRInfo_Dynamic_Gridview_ctl03_Btn_Cancel_Search').css(
//            { "border-radius": "3", "top": "-3", "left": "2", "background-color": "#007095", "color": "White" }
//            )
//        $('#dny_Grd_ITRInfo$Dynamic_Gridview$ctl12$Btn_Cancel_Search').css(
//            { "border-radius": "3", "top": "-3", "left": "2", "background-color": "#007095", "color": "White" }
//            )
        //  $("table").addclass('responsive');
        $("#ControlGrid table input[type=text]").css(
        "border", "1px solid rgba(177, 224, 215, 0.61)"
        )
    }
    $(document).ready(function ($) {
        // $("#ControlGrid table").addClass("responsive");
        $("#ControlGrid table").css(
{ "margin": "0", "padding": "0", "border": "solid 1px #ddd" }
)
        $("#ControlGrid table th").css(
        { "color": "white", "background-color": "#494e6b", "height": "37px" }

        )
        // $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
        // $("#ControlGrid table tr:odd").css("background-color", "White");
        if ($("#hdnRegularCorrection").val() == "Correction") {
            //                $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
            //                $("#ControlGrid table tr:odd").css("background-color", "White");

            for (var i = 0; i < $("#ControlGrid table tr").length; i++) {
                if ($("#hdnFiller").val() == "M") {
                    //alert("I");
                    $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
                    $("#ControlGrid table tr:odd").css("background-color", "White");
                }
                else if ($("#hdnFiller").val() == "U") {
                    //alert("J");
                    //$("#ControlGrid table tr:even").css("background-color", "Green");
                    $("#ControlGrid table tr").css("background-color", "Red");
                }
                else if ($("#ControlGrid table").find("tr:eq(" + i + ")").find("td:eq(11)").text() == "0") {
                    //alert("K");
                    $("#ControlGrid table").Find("tr:eq(" + i + ")").find("td:eq(11)").css("background-color", "Red");
                }
                else {
                    //alert("L");
                    $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
                    $("#ControlGrid table tr:odd").css("background-color", "White");
                }
            }
        }
        else {
            //alert("else3");
            $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
            $("#ControlGrid table tr:odd").css("background-color", "White");
        }
        $('#dny_Grd_ITRInfo_Dynamic_Gridview').css(
          { "width": "100%" }
          )
//        $('#dny_Grd_ITRInfo_Dynamic_Gridview_ctl03_Btn_Cancel_Search').css(
//            { "border-radius": "3", "top": "-3", "left": "2", "background-color": "#007095", "color": "White" }
//            )
//        $('#dny_Grd_ITRInfo$Dynamic_Gridview$ctl12$Btn_Cancel_Search').css(
//            { "border-radius": "3", "top": "-3", "left": "2", "background-color": "#007095", "color": "White" }
//            )

        $("#ControlGrid table input[type=text]").css(
        "border", "1px solid rgba(177, 224, 215, 0.61)"

        )

    });




}
//for change control grid look

$(document).ready(function ($) {
    //$("#ControlGrid table").addClass("responsive");
    $("#ControlGrid table").css(
{ "margin": "0", "padding": "0", "border": "solid 1px #ddd" }
)
    $("#ControlGrid table th").css(
        { "color": "black", "background-color": "#c1dbfa", "height": "37px" }

        )
    //$("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
    //    $("#ControlGrid table tr:odd").css("background-color", "White");
    if ($("#hdnRegularCorrection").val() == "Correction") {
        //                $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
        //                $("#ControlGrid table tr:odd").css("background-color", "White");

        for (var i = 0; i < $("#ContolGrid table tr").length; i++) {
            if ($("#hdnFiller").val() == "M") {
                //alert("M");
                $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
                $("#ControlGrid table tr:odd").css("background-color", "White");
            }
            else if ($("#hdnFiller").val() == "U") {
                //alert("N");
                //$("#ControlGrid table tr:even").css("background-color", "Green");
                $("#ControlGrid table tr").css("background-color", "Red");
            }
            else if ($("#ControlGrid table").find("tr:eq(" + i + ")").find("td:eq(11)").text() == "0") {
                //alert("O");
                $("#ControlGrid table").Find("tr:eq(" + i + ")").find("td:eq(11)").css("background-color", "Red");
            }
            else {
                //alert("P");
                $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
                $("#ControlGrid table tr:odd").css("background-color", "White");
            }
        }
    }
    else {
        //alert("else4");
        $("#ControlGrid table tr:even").css("background-color", "#F9F9F9");
        $("#ControlGrid table tr:odd").css("background-color", "White");
    }

    $('#dny_Grd_ITRInfo_Dynamic_Gridview').css(
          { "width": "100%" }
          )
    $('#dny_Grd_ITRInfo_Dynamic_Gridview_ctl03_Btn_Cancel_Search').css(
            { "border-radius": "3", "top": "-3", "left": "2", "background-color": "#007095", "color": "White" }
            )
    $('#dny_Grd_ITRInfo$Dynamic_Gridview$ctl12$Btn_Cancel_Search').css(
            { "border-radius": "3", "top": "-3", "left": "2", "background-color": "#007095", "color": "White" }
            )
    $("#ControlGrid table").parent().addClass('responsive');
    $("#ControlGrid table input[type=text]").css(
        "border", "1px solid #ef5845"
        )
});
  

