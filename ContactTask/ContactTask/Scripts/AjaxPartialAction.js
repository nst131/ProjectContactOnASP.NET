$(function () {
    $(`.create`).click(function () {

        $.ajax({
            method: "GET",
            url: "/Home/CreateContact",
        }).done(function (html) {
            $(`#okno`).children().detach();
            $(`#okno`).append(html);
        });
        document.location.href = "#Menu";
    });

    $(`#wrapper`).on(`click`, `.edit`, function (event) {

        event.preventDefault();
        let id = $(this).attr(`data-id`);
        $.ajax({
            method: `GET`,
            url: `/Home/EditContact/${id}`,
        }).done(function (html) {
            $(`#okno`).children().detach();
            $(`#okno`).append(html);
        });
        document.location.href = "#Menu";
    });

    $(`#wrapper`).on(`click`, `.delete`, function (event) {

        event.preventDefault();
        let id = $(this).attr(`data-id`);
        $.ajax({
            method: `GET`,
            url: `/Home/DeleteContact/${id}`,
        }).done(function (html) {
            $(`#okno`).children().detach();
            $(`#okno`).append(html);
        });
        document.location.href = "#Menu";
    });
});