$(document).ready(function () {
    $(window).on("beforeunload", function () {
        $(".ajaxLoader").show();
    });
    //$(window).on("load", function () {
    //    $("body").fadeIn("fast");
    //});
})