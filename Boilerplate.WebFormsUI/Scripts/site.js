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
    $(".stationViewButton").on("click", function (event) {
        viewStationModal(event);
        return false;
    });
})

var viewStationModal = function (event) {
    
    var stationId = $(event.target).attr("data-station-id");
    console.log("viewstation modal", stationId);
    $(".ajaxLoader").show();
    $.get("api/stop/" + stationId, function (data) {
        console.log("viewstation got: ", data);
        $(".ajaxLoader").hide();
        $("#modalStationNameTitle").text(data.Name);
        $("#stationModalId").text(data.Id);
        $("#stationModalLon").text(data.Longitude);
        $("#stationModalLat").text(data.Latitude);
        $("#stationModal").modal('show');
    });
    //prevent asp.net form submission
    //return false;
}