$(document).ready(function () {
    $(window).on("beforeunload", function () {
        $(".ajaxLoader").show();
    });
    $("#modalOpenButton").on("click", function () {
        $('#messageModal').modal('show');
        //prevent asp.net form submission
        return false;
    });
    $("#pageReloadButton").on("click", function () {
        location.href = location.href;
    })
})