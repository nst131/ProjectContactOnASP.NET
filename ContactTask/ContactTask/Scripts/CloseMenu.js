$(function () {
    $(`#Menu`).click(function () {
        document.location.href = "#";
    });

    $(`#okno`).click(function (event) {
        event.stopPropagation();
    });
});