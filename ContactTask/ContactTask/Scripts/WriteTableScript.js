$(function () {
    async function WriteTable() {
        let responseColumns = await fetch(`/GetColumnsName`, { method: `GET`, headers: { "Accept": "application/json" } });
        let arrayColumns = await responseColumns.json();

        let responceData = await fetch(`/Contact`, { method: `GET`, headers: { "Accept": "application/json" } });
        let arrayData = await responceData.json();

        let itemTitle = $(`<div class="title line"><div>`);
        $(`#wrapper`).append(itemTitle);
        $(itemTitle).children().detach();
        arrayColumns.push(`Action`);
        for (var i = 0; i < arrayColumns.length; i++) {
            $(`.title`).append(`<div>${arrayColumns[i]}<div>`);
        }

        if (arrayData != undefined) {
            for (var i = 0; i < arrayData.length; i++) {
                let itemRow = $(`<div class="line"><div>`)
                $(`#wrapper`).append(itemRow);
                $(itemRow).children().detach();
                for (var item in arrayData[i]) {
                    if (item == "Id") {
                        continue;
                    }
                    $(itemRow).append(`<div>${arrayData[i][item]}<div>`);
                }
                $(itemRow).append(`<div><a href="#" class="edit" data-id=${arrayData[i]["Id"]}>Edit<a><div>
                            <div><a href="#" class="delete" data-id=${arrayData[i]["Id"]}>Delete<a><div>`);
            }
        }

        $(`.spinner-border`).css(`visibility`, `hidden`);
    }

    WriteTable();
});