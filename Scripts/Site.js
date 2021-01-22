$(document).ready(function () {
    $("#btnShow").mousedown(function () {
        $("#Password").attr("type", "text");
    });
    $("#btnShow").mousedown(function () {
        $("#ConfirmPassword").attr("type", "text");
    });
    $("#btnShow").mousedown(function () {
        $("#txtPassword").attr("type", "text");
    });



    $("#btnShow").on("mouseleave", function () {
        $("#txtPassword").attr("type", "password");
    });
    $("#btnShow").on("mouseleave", function () {
        $("#ConfirmPassword").attr("type", "password");
    });
    $("#btnShow").on("mouseleave", function () {
        $("#ConfirmPassword").attr("type", "password");
    });
   });