    $(document).ready(function () {
    $(".date").each(function (index) {
        $(this).data("init", $(this).text())
    })
    $("#homepage").click(function () {
    $("#categogories a").css("color", "#008000")
    $("#blogroll a").css("color", "yellow")
    let curSize = $("#sidebar h2").css("font-size")
    let newSize = parseInt(curSize) - 2;
    $("#sidebar h2").css("font-size", newSize + 'px')
    $("#search-text").css("border", "black 2px solid").css("background", "cornflowerblue").css("color", "yellow")
})
    $(".comments").hover(function () {
    $(".post").has(this).css("background", "#90ee90")
}, function () {
    $(".post").has(this).removeAttr("style")
})
    $(".date").click(function () {
    $(this).text("Скрыто");
})
    $("#blog").click(function () {
    $(".post:nth-child(2n) a").remove()
})
    $("#about").click(function () {
    $(".date").css("color", "purple");
    $(".date").filter(function () {return $(this).text() == "Скрыто"}).each(function (index) {$(this).text($(this).data("init"))}).removeAttr("style")
})
    let curSize = $("#special .entry p > span:first-child").css("font-size")
    let newSize = parseInt(curSize) * 2
    $("#special .entry p > span:first-child").css("font-size", newSize + 'px').css("font-weight", "bold")
    $("#special .entry p span").css("color", "red")
    $(".post:last .more").click(function () {
    $(".post:last table tr:nth-child(even)").css("background", "#ffffe0")
    $(".post:last table td").css("padding", "5px").css("font-size", "10px")
    $(".post:last table tr:first").css("background", "yellow").css("font-weight", "bold")
    $(".post:last table tr:first td").css("font-size", "14px")
    $(".post:last table tr").css("outline", "2px dashed gray").css("outline-offset", "-4px")
    $(".post:last table td:last-child").each(function (index) {$(this).text(index + 1)})
    $(".post:last table tr:nth-child(n+2) td:first-child").css("color", "green")
})
    $("#search-submit").click(function () {
    $("#search-text").val(parseInt($("#sidebar table tr:first td:first").text()) *
    parseInt($("#sidebar table tr:last td:last").text()) -
    parseInt($("#sidebar table tr:first td:last").text()) *
    parseInt($("#sidebar table tr:last td:first").text()))
    return false
})
    $("#menu li:last a").click(function () {
    let curSize = $("#footer p").css("font-size")
    let newSize = parseInt(curSize) * 2
    $("#footer p").css("font-size", newSize + 'px').css("color", "yellow")
})
    $("#photos").click(function () {
    $(".post:nth-child(odd) .entry").html("<img class=\"entry-photo\" src=\"images/fortask.jpg\">")
    $(".entry-photo").click(function () {
    $(this).css("display", "none")
})
})
})
