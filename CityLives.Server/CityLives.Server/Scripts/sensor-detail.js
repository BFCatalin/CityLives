$(function () {
    var title = window.location.hash;
    $(".title").html(title != "" ? title.substring(1) : "Sensor");
})