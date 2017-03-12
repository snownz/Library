var wait = {
    waiting: function (element) {
        element.block({
            message: '<div class="spinner glisteningwindow"><i class="fa fa-spin fa-refresh"></i> Carregando</div>'
        });
    },
    done: function (element) {
        element.unblock();
    }
}

$(document).ready(function () {

    $('[data-toggle="tooltip"]').tooltip();
    loadBooks();
    loadSpecialBooks();
    configureBookButons();

});

function loadBooks(){
    wait.waiting($('#partial-books'));
    $.post(baseUrl + "Books/PartialBooks", null)
    .success(function (data) { $('#partial-books').html(data); wait.done($('#partial-books')); });
}

function loadSpecialBooks() {
    wait.waiting($('#partial-special-books'));
    $.post(baseUrl + "Books/PartialSpecialBooks", null)
    .success(function (data) { $('#partial-special-books').html(data); wait.done($('#partial-special-books')); });
}

function configureBookButons(){
    $("#redirectDashBoard").click(function () {
        window.location.href = baseUrl + "DashBoard"
    });
}