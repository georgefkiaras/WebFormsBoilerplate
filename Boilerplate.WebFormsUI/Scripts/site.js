$(document).ready(function () {
    $(window).on("beforeunload", function () {
        $(".ajaxLoader").show();
    });
    $("#modalOpenButton").on("click", function () {
        $('#messageModal').modal('show');
    });
    $("#pageReloadButton").on("click", function () {
        location.href = location.href;
    })
    $(".stationViewButton").on("click", function (event) {
        viewStationModal(event);
    });
    $("#postOpenButton").on("click", function (event) {
        $('#postModal').modal('show');
    });
    $("#submitMessage").on("click", submitMessage);
})

var submitMessage = function () {
    var message = $("#messageBox").val();
    var valuesObj = {}; //new object
    valuesObj.Message = message;
    $(".ajaxLoader").show();
    $.post("api/Message", valuesObj, function (data) {
        $(".ajaxLoader").hide();
        $('#postModal').modal('hide');
        location.href = location.href;
    });
}

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
}