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
    loadBooks();
    loadAuthor();
    loadCompany();
    loadLang();
});

function loadBooks(){
    wait.waiting($('#partialBook'));
    $.post(baseUrl + "Books/ListAll", null)
    .success(function (data) { $('#partialBook').html(data); wait.done($('#partialBook')); configureButtons(); });
}

function loadAuthor() {
    wait.waiting($('#partialAuthor'));
    $.post(baseUrl + "Author/ListAll", null)
    .success(function (data) { $('#partialAuthor').html(data); wait.done($('#partialAuthor')); configureButtons(); });
}

function loadCompany() {
    wait.waiting($('#partialCompany'));
    $.post(baseUrl + "Company/ListAll", null)
    .success(function (data) { $('#partialCompany').html(data); wait.done($('#partialCompany')); configureButtons(); });
}

function loadLang() {
    wait.waiting($('#partialLanguage'));
    $.post(baseUrl + "Language/ListAll", null)
    .success(function (data) { $('#partialLanguage').html(data); wait.done($('#partialLanguage')); configureButtons(); });
}

function configureButtons() {

    $('a[data-type="New"]').unbind("click");
    $('a[data-type="New"]').click(function () {

        var controller = $(this).attr("data-controller");
        var action = "Vizualise";

        $.post(baseUrl + controller + "/" + action, null)
        .done(function (data) {
            library.showModal('Novo', data, null, function () { }, false, "formModal");
        }).fail(function () {
            library.configureMessage("warning", "Ocorreu um erro ao processar a solicitação");
        });
    });

    $('a[data-type="Update"]').unbind("click");
    $('a[data-type="Update"]').click(function () {
        var controller = $(this).attr("data-controller");
        var action = "Vizualise";
        var id = $(this).attr("data-id");

        $.post(baseUrl + controller + "/" + action, { id: id })
        .done(function (data) {
            library.showModal('Alterar ', data, null, function () { }, false, "formModal");
        }).fail(function () {
            library.configureMessage("warning", "Ocorreu um erro ao processar a solicitação");
        });
    });

    $('a[data-type="Delete"]').unbind("click");
    $('a[data-type="Delete"]').click(function () {
        var controller = $(this).attr("data-controller");
        var action = "Delete";
        var id = $(this).attr("data-id");

        $.post(baseUrl + controller + "/" + action, {id : id})
        .done(function (data) {
            library.configureMessage("success", "Registro deletado com Sucesso");
            loadBooks();
            loadAuthor();
            loadCompany();
            loadLang();
        }).fail(function () {
            library.configureMessage("warning", "Registro não pode ser apagado");
        });
    });

    $('a[data-type="txtList"]').unbind("keyup");
    $('a[data-type="txtList"]').keyup(function (e) {
        console.log("pesquisa");
        if (!pressed && e.keyCode == 13) {
            var controller = $(this).attr("data-controller");
            var action = "ListAll";
            var search = $(this).val();
            var container = $(this).attr("data-container");

            $.post(baseUrl + controller + "/" + action, { search: search })
            .done(function (data) {
                $("#" + container).html(data);
            });
        }
    });

    $('a[data-type="pageList"]').unbind("click");
    $('a[data-type="pageList"]').click(function () {
        console.log("pagina");
       var controller = $(this).attr("data-controller");
            var action = "ListAll";
            var search = $("input[name='" + $(this).attr("data-search") + "']").val();
            var page = $(this).attr("data-page");
            var container = $(this).attr("data-container");

        $.post(baseUrl + controller + "/" + action, { search: search, page: page, action : true })
            .done(function (data) {
                $("#" + container).html(data);
            });
    });
}

function ConfigureForms(){
    $('form[data-type="frm"]').unbind("submit");
    $('form[data-type="frm"]').submit(function (e) {
        var controller = $(this).attr("data-controller");
        var action = "";
        if ($(this).attr("data-new") == 'True') {
            action = "New";
        }
        else{
            action = "Update";
        }

        token = $('input[name="__RequestVerificationToken"]').val();

        var data = { model: $(this).serializeArray(), __RequestVerificationToken: token };
        console.log($(this).serializeArray());

        $.post(baseUrl + controller + "/" + action, data)
        .done(function (data) {
            library.configureMessage("success", "Registro Incluido com Sucesso!");
            loadBooks();
            loadAuthor();
            loadCompany();
            loadLang();
            $("#formModal").modal('hide');
        }).fail(function () {
            library.configureMessage("warning", "Ocorreu um erro ao processar a solicitação");
        });

        e.preventDefault();
        return false;
    });
}