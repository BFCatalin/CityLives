$(function () {
    $(".sensor .circle").click(function () { window.location.href = "sensor.html#" + $(this).siblings("h3").text(); });
    $(".sensor h3").click(function () { window.location.href = "sensor.html#" + $(this).text(); });
})