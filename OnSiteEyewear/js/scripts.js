$(document).ready(function () {
    $("#slideshow").css("overflow", "hidden");
    $("#slideshow-nav").css("visibility", "visible");
    $("#slideshow-nav a[href=#fotd1]").addClass("active");

    $("#slideshow-nav").localScroll({
        target: '#slideshow', axis: 'x'
    });

    $("#slideshow-nav a").click(function () {
        $("#slideshow ul").css("margin-bottom", "12");
        $("#slideshow-nav a").removeClass("active");
        $(this).addClass("active");
    });
});
