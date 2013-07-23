$(document).ready(function () {
    var cus_dropdown_sel = $('ul#navigationBar li').find('.subPanel').parent();
    $(cus_dropdown_sel).mouseenter(
        function () {
            var index = $('ul#navigationBar li').index(this);

            $(this).addClass('dropdownHover');
            $(this).children('.subPanel').fadeIn(1);

            if (index == 18) {
                $(this).children('.subPanel').css('width', $(this).width() + 88);
            }
            else {
                $(this).children('.subPanel').css('width', $(this).width() + 12);
            }

            $(this).children('.subPanel').css('margin-left', '30px');
            $(this).children('.subPanel').css('z-index', '2');
        }).mouseleave(
        function () {
            $(this).removeClass('dropdownHover');
            $(this).children('.subPanel').fadeOut(60);
        });
});