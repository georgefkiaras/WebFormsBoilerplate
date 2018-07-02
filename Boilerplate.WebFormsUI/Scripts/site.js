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
    $("#validationErrorButton").on("click", submitValidationError);
    $("#exceptionButton").on("click", submitException);
    $(".fileUploader").on("change", saveFile);
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
    }).fail(function (response) {
        $(".ajaxLoader").hide();
        $("#errorModalMessageBody").text(response.responseText);
        $('#errorModal').modal('show');
        console.log("Message Error: ", response);
    });;
}

var submitValidationError = function () {
    var message = $("#messageBox").val();
    var valuesObj = {}; //new object
    valuesObj.Message = message;
    $(".ajaxLoader").show();
    $.post("api/ValidationError", valuesObj, function (data) {
        //success will never execute
    }).fail(function (response) {
        $(".ajaxLoader").hide();
        $("#errorModalMessageBody").text(response.responseText);
        $('#errorModal').modal('show');
        console.log("Message Error: ", response);
    });;
}

var submitException = function () {
    var message = $("#messageBox").val();
    var valuesObj = {}; //new object
    valuesObj.Message = message;
    $(".ajaxLoader").show();
    $.post("api/Exception", valuesObj, function (data) {
        //success will never execute
    }).fail(function (response) {
        $(".ajaxLoader").hide();
        $("#errorModalMessageBody").text(response.responseText);
        $('#errorModal').modal('show');
        console.log("Message Error: ", response);
    });;
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

var saveFile = function (event) {
    var fileUploadElement = $(event.target).get(0);
    var files = fileUploadElement.files;
    if (files != null && files.length > 0) {
        var file = files[0];
        var fileData = new FormData();
        fileData.append("FileUploadHolder", file);
        $(".ajaxLoader").show();

        var fileUploadAjax = $.ajax({
            type: "POST",
            url: "api/File/",
            contentType: false,
            processData: false,
            data: fileData,
            success: function (response) {
                console.log("File upload success: ", response);
                $(".ajaxLoader").hide();
                //TODO: replace with page refresh
                location.href = location.href;
            },
            error: function (response) {
                console.log("File upload fail: ", response.responseJSON);
                $(".ajaxLoader").hide();
                $("#messageModalHeader").text("Error");
                $("#messageModalBody").text(response.responseJSON.ExceptionMessage);
                $('#messageModal').modal('show');
            }
        });
    }
}