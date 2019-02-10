(function ($) {
    $(document).ready(function () {
        $('#cssmenu > ul > li > a').click(function () {
            $('#cssmenu li').removeClass('active');
            $(this).closest('li').addClass('active');
            var checkElement = $(this).next();
            if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
                $(this).closest('li').removeClass('active');
                checkElement.slideUp('normal');
            }
            if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
                $('#cssmenu ul ul:visible').slideUp('normal');
                checkElement.slideDown('normal');
            }
            if ($(this).closest('li').find('ul').children().length == 0) {
                return true;
            } else {
                return false;
            }
        });

        $("#btnmenu").click(function () {

            $("#divmenu").slideToggle();
        });
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
        //  
       
    });
})(jQuery);
