function DeleteHs(id) {
    var conRes = window.confirm("Are you sure you want to delete this High Score?");
    if (conRes) {
        ShowLoading();
        $.ajax({
            type: "delete",
            url: "/HighScore/Delete",
            data: { id: id },
            dataType: "JSON",
            success: function (data) {
                if (data.IsDeleted) {
                    var selector = "[data-id='" + data.Id + "']";
                    $(selector).closest("tr").remove();
                } else {
                    alert("Delete unsuccessful.");
                }
                HideLoading();
            },
            fail: function (arg) {
                alert(arg);
                HideLoading();
            }
        });
    }
}

function ShowLoading() {
    $("#loading").removeClass("hidden");
}

function HideLoading() {
    $("#loading").addClass("hidden");
}