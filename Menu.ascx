<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Menu" %>
<link href="../Stylesheet/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../sliderengine/jquery.js" type="text/javascript"></script>
<link href="../Stylesheet/StyleSheet2.css" rel="stylesheet" type="text/css" />
<link href="../ITRStylesheet/styles/menu.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.als-1.7.js"></script>

<%--show submenu on click nishu 6/4/2015 --%>
<%--<script type="text/javascript">
    $(document).ready(function () {

        $(document).ready(function () {

            $('.submenu').hide();
            $("li:has(ul)").click(function () {
                $('.submenu').hide();
                $(this).addClass('active').siblings().removeClass('active');

                $('.submenu', this).css(
      "position", "absolute",
	"padding", "0px",
    "display", "block"
   



        )
                $(".main-menu .submenu").hide('fast');
                $("ul", this).slideToggle();
                $("ul", this).css(
            "zIndex", "2005"

            )
                $('.submenu', this).css(
                "float", "left"

                )
                $(".main-menu .submenu").hide('fast');
            });


        });


    });
</script>--%>
<%----nishu -----%>
<script type="text/javascript">
    $(document).ready(function () {


        //                $('.submenu').hide();

        $("#divMenu li:has(ul)").click(function () {
            $('#divMenu a').css(
    "color", "black"
    )

            $("#divMenu a").css(
            "color", "Black"
            )


            $('.submenu').hide();

            $("#divMenu li:has(ul)").css(
            "text-align", "center"

            )

            $("ul", this).toggle('fast');
            $("#divMenu li:has(ul)").css(
            "text-align", "center"

            )
            $("a", this).css(
            "color", "#ef5845"
            )


        });

        //----------

        $("#divMenu li:not(ul)").click(function () {
            $('#divMenu a').css(
    "color", "black"
    )
            $("#divMenu a").css(
            "color", "Black"
            )


            $('.submenu').hide();


            $("#divMenu li:has(ul)").click(function () {
                $('#divMenu a').css(
    "color", "black"
    )


                $('.submenu').hide();


                //                $("ul", this).toggle('fast');
                //                $("li:has(ul)").css(
                //            "text-align", "center"

                //            )
                $("a", this).css(
            "color", "#ef5845"
            )


            });
            $("ul", this).toggle('fast');
            $("li:not(ul)").css(
            "text-align", "center"

            )
            $("a", this).css(
            "color", "#ef5845"
            )


        });

    });
</script>

<script type="text/javascript">
    $(document).ready(function ($) {
        $("#my-als-list").als({
            visible_items: 7,
            scrolling_items: 2,
            orientation: "horizontal",
            circular: "no",
            autoscroll: "no",
            interval: 5000,
            speed: 400,
            easing: "linear",
            direction: "right",
            start_from: 0
        });
    });	
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#divMenu li:has(ul)").click(function () {
            $('.als-viewport').css("height", "150px");
          
            $('als-wrapper').css("height", "150px");
        });

    });

</script>
<style type="text/css">
    .current
    {
    }
    .active
    {
        color: #ef5485;
    }
    #container
    {
        overflow-x: hidden;
        position: relative;
    }
    #parent
    {
        width: 6000px;
    }
    #browser
    {
        float: left;
        width: 800px;
        overflow: hidden;
        white-space: nowrap;
    }
</style>
<script type="text/javascript">
    $('#left').click(function () {
        scroll = $('#divMenu').scrollLeft();
        $('#divMenu').animate({ 'scrollLeft': scroll - 100 }, 1000);
    });
    $('#right').click(function () {
        scroll = $('#divMenu').scrollLeft();
        $('#divMenu').animate({ 'scrollLeft': scroll + 100 }, 1000);
    });
</script>
<br />

<div  id="divMenu" class="row">  

<%--<div class="als-container" id="my-als-list">--%>
 
 <%--<span class="als-prev"><img src="../images/thin_left_arrow_333.png" alt="prev" title="previous" /></span>--%>

 <%-- <div class="als-viewport">--%>
<asp:Literal ID="ltMenu" runat="server">
</asp:Literal>
 <%-- </div> 
  <span class="als-next"><img src="../images/thin_right_arrow_333.png" alt="next" title="next" /></span>
</div>--%>

</div>

<%--<button id="left">Left</button>
<button id="right">Right</button>--%>
