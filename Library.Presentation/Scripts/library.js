var library = {
    showModal: function (title, body, event, acaobotao, keepModal, idModal) {
        if (idModal == "" || idModal == undefined || idModal == null)
        {
            idModal = "basicModal";
        }
        $('#' + idModal).on('show.bs.modal', function (event) {
            var modal = $(this);
            modal.find('.modal-title').html(title);
            $('.modal-body').html(body);
            $('.modal-body').css("min-height", "100px");
            var $botao = modal.find("button").last();
            $botao.unbind('click');
            $botao.bind('click', acaobotao);
            if (!keepModal) {
                modal.find('.btn.red').bind('click', function () {
                    $('#' + idModal).modal('hide');
                });
            }
        });
        $('#' + idModal).modal('show');
    }
    ,hideModal: function (idModal) {
        if (idModal == "" || idModal == undefined || idModal == null) {
            idModal = "basicModal";
        }
        $('#' + idModal).modal('hide');
    }
    ,configureMessage: function (messageType, message) {
        toastr.options.closeButton = false;
        toastr.remove();
        toastr.options.showMethod = 'slideDown';
        toastr.clear;
        toastr.options.positionClass = 'toast-top-center';
        toastr[messageType](message);
    }
    ,blockUi: function (element) {
        element.block({
            message: '<div class="spinner glisteningwindow"><i class="fa fa-spin fa-refresh"></i> Aguarde</div>'
        });
    }
    ,unBlockUi: function (element) {
        element.unblock();
    }
    ,setActiveMenu: function (menuIds) {

        $.each(menuIds, function (index, menu) {
            $("#" + menu).addClass("active");
        });
    }
    ,formSubmit: function () {
        try
        {
            $(".ajax-form").submit(function () {
                $form = $(this);
                var $blockElement = $('.page-content-wrapper');
                library.blockUi($blockElement);
                $.ajax({
                    url: $form.attr("action")
                    , data: $form.serialize()
                    , type: "POST"
                    , dataType: "Json"
                }).done(function (data) {
                    library.configureMessage(data.returnType, data.message);
                    if (data.returnUrl != "" && data.returnType == "success")
                    {
                        setTimeout(function () {
                            document.location.href = data.redirectToUrl;
                        }, 1500);
                    }
                    library.showErrorMessages(data.errors);
                }).fail(function () {
                    library.configureMessage("warning", "Ocorreu um erro ao processar a solicitação");
                }).always(function () {
                    library.unBlockUi($blockElement);
                    return false;
                });
                return false;
            });
        }
        catch (e) {
            console.log(e);
            return false;
        }
    }
    ,select2: function () {
        var selectList = $(".select2");
        $.each(selectList, function (index, obj) {
            var $select = $(obj);
            if ($select.attr("dataajax") == undefined || $select.attr("dataajax") != "true") {
                $select.select2({ placeholder: "Selecione um item", allowClear: true });
            }
            else {
                
                $select.select2({
                    placeholder: "Selecione um item",
                    allowClear: true,
                    ajax: {
                        url: baseUrl + $select.attr("dataurl"),
                        dataType: 'json',
                        type: 'post',
                        delay: 250,
                        data: function (params) {
                            return {
                                search: params.term, // search term
                                page: params.page,
                                id:$select.attr("data-id")
                            };
                        },
                        results: function (data) {
                            return data;
                        },
                        cache: true
                    },
                    escapeMarkup: function (markup) { return markup; }, // let our custom formatter work
                    minimumInputLength: 3,
                    language: "pt-BR"
                });
            }
        });
    }
    /*
    Initialize CheckRadio Plugin 
    event: event to trigger when Change
           the function shall wait for two parameters
            checked - boolean indication whether is checked or not
            value - the element value
    */
    ,checkRadio: function (event, element) {
        if ($('.checkradios').length > 0) {
            $('.checkradios').checkradios({
                checkbox: {
                    iconClass: 'fa fa-check'
                },
                radio: {
                    iconClass: 'fa fa-circle'
                }
                , onChange: function (checked, $element, $realElement) {
                    if (event != null)
                        event(checked, $realElement.val());
                }
            });
        }
    }
    ,completeZeros: function (length, value) {
        var retorno = "";
        var valueString = value.toString();

        if (valueString.length < length) {
            for (var i = valueString.length; i < length; i++) {
                retorno += "0";
            }
        }
        else {
            return retorno = valueString;
        }
        return retorno + valueString;
    }
    ,mascaraValor: function () {
        $(".valor").unbind('keypress');
        $(".valor").keypress(function (e) {

            var objTextBox = $(this);

            if (objTextBox.attr("readonly") != "readonly") {

                var SeparadorMilesimo = ".";
                var SeparadorDecimal = ",";
                var sep = 0;
                var key = '';
                var i = j = 0;
                var len = len2 = 0;
                var strCheck = '0123456789';
                var aux = aux2 = '';

                if (objTextBox.val().length > 14) return false;
                var whichCode = (window.Event) ? e.which : e.keyCode;
                if ((whichCode == 13) || (whichCode == 0) || (whichCode == 8))
                    return true;

                key = String.fromCharCode(whichCode); // Valor para o código da Chave
                if (strCheck.indexOf(key) == -1) return false; // Chave inválida
                len = objTextBox.val().length;
                for (i = 0; i < len; i++)
                    if ((objTextBox.val().charAt(i) != '0') && (objTextBox.val().charAt(i) != SeparadorDecimal)) break;
                aux = '';
                for (; i < len; i++)
                    if (strCheck.indexOf(objTextBox.val().charAt(i)) != -1) aux += objTextBox.val().charAt(i);
                aux += key;
                len = aux.length;
                if (len == 0) objTextBox.val('');
                if (len == 1) objTextBox.val('0' + SeparadorDecimal + '0' + aux);
                if (len == 2) objTextBox.val('0' + SeparadorDecimal + aux);
                if (len > 2) {
                    aux2 = '';
                    for (j = 0, i = len - 3; i >= 0; i--) {
                        if (j == 3) {
                            aux2 += SeparadorMilesimo;
                            j = 0;
                        }
                        aux2 += aux.charAt(i);
                        j++;
                    }
                    objTextBox.val('');
                    var tempValue = "";
                    len2 = aux2.length;
                    for (i = len2 - 1; i >= 0; i--)
                        tempValue += aux2.charAt(i);
                    tempValue += SeparadorDecimal + aux.substr(len - 2, len);

                    objTextBox.val(tempValue);
                }
                return false;
            }
        });
    }
    ,formataMoeda: function (valor) {

        var inteiro = null, decimal = null, c = null, j = null;
        var aux = new Array();

        if (valor != null)
            valor = valor.toFixed(2);

        valor = "" + valor;
        c = valor.indexOf(".", 0);
        //encontrou o ponto na string
        if (c > 0) {
            //separa as partes em inteiro e decimal
            inteiro = valor.substring(0, c);
            decimal = valor.substring(c + 1, valor.length);
        } else {
            decimal = "0";
            inteiro = valor;
        }

        //pega a parte inteiro de 3 em 3 partes
        for (j = inteiro.length, c = 0; j > 0; j -= 3, c++) {
            aux[c] = inteiro.substring(j - 3, j);
        }

        //percorre a string acrescentando os pontos
        inteiro = "";
        for (c = aux.length - 1; c >= 0; c--) {
            inteiro += aux[c] + '.';
        }
        //retirando o ultimo ponto e finalizando a parte inteiro

        inteiro = inteiro.substring(0, inteiro.length - 1);

        if (decimal.length === 1) {
            decimal += "0";
        }

        decimal = parseInt(decimal);

        if (isNaN(decimal)) {
            decimal = "00";
        } else {
            decimal = "" + decimal;
            if (decimal.length === 1) {
                decimal = "0" + decimal;
            }
        }
        valor = inteiro + "," + decimal;
        return valor;

    }
    ,mascaraData: function () {
        if ($(".datetime").length > 0)
            $(".datetime").mask("99/99/9999");
    }
    ,datePicker: function () {
        $(".has-datepicker").datepicker({
            format: 'dd/mm/yyyy'
            , language: 'pt-BR'
            , autoclose: true
        });
    }
    ,onlyNumber: function () {
        $(".inteiro").keypress(function (event) {
            if (event.which != 8 && isNaN(String.fromCharCode(event.which))) {
                event.preventDefault(); //stop character from entering input
            }
        });
    }
    ,deleteObject: function (url, id, table) {
        var data = { id: id };
        library.blockUi($('body'));
        $.ajax({
            url: url,
            method: "POST",
            data: data
        }).done(function (data) {
            var type = data.type;
            if (data.type == "" || data.type == undefined) {
                type = data.returnType;
            }
            library.configureMessage(type, data.mensagem);
            table.ajax.reload();
            library.unBlockUi($('body'));
        }).fail(function () {
            library.configureMessage("error", "Ocorreu um erro ao processar sua solicitação!");
            library.unBlockUi($('body'));
        });
    }
    ,initializaComponents: function () {
        try
        {
            $(".cnpj").mask("99.999.999/9999-99");
            $(".cpf").mask("999.999.999-99");
            $(".telefone").mask("(99)9999-9999");
            $(".celular").mask("(99)99999-9999");
            $(".cep").mask("99.999-999");

            library.select2();
            library.checkRadio();
            library.mascaraValor();
            library.mascaraData();
            library.datePicker();
            library.onlyNumber();
        }
        catch (e)
        {
            console.log(e);
        }
    }
    ,exportFile: function (fileType) {
        var busca = "";
        var $busca = $("input[type=search]");

        if ($busca != null) {
            busca = $busca.val();
        }

        window.open(deleteUrl + "/ExportList/" + fileType + "?busca=" + busca);
        return false;
    }
    ,preencheEndereco: function (data) {
        $("#Logradouro").val(data.Logradouro);
        $("#Bairro").val(data.Bairro);
        $("#Cidade").val(data.Cidade);
        $("#Uf").val(data.IDUf).trigger("change");
    }
    ,showErrorMessages: function (listMessages) {
        $(".field-validation-error").remove();
        $.each(listMessages, function (key, message) {
            var $campo = $("#" + message.Key);
            if (!$campo.hasClass("select2"))
            {
                $campo.parent().addClass("has-error");
                $campo.focus(function () {
                    $(this).parent().removeClass("has-error");
                    $campo.parent().find("span.field-validation-error").remove();
                });
            }
            else
            {
                var $select = $campo.parent().addClass('has-error');
                $select.click(function () {
                    $(this).removeClass("has-error");
                    $campo.parent().find("span.field-validation-error").remove();
                });
            }
            $campo.parent().append('<span class="field-validation-error text-danger" data-valmsg-for="' + message.Key + '" data-valmsg-replace="true">' + message.Value + '</span>')
        });
    }
    ,tileClick: function () {
        $(".tile").click(function () {
            var $obj = $(this);
            document.location.href = $obj.attr("data-url");
        });
    }
    ,scrollTo: function (el, offeset) {
        var pos = (el && $(el).width() > 0) ? el.offset().top : 0;
        if (el) {
            if ($('body').hasClass('page-header-fixed')) {
                pos = pos - $('.page-header').height();
            }
            pos = pos + (offeset ? offeset : -1 * el.height());
        }

        $('html,body').animate({
            scrollTop: pos
        }, 'slow');
    }
}
$(document).ready(function () {
    function logout() {
        $btLogout = $("#btLogout");
        var form = $("#logoutForm");

        $btLogout.click(function () {
            form.submit();
        });
    }
    logout();
    library.tileClick();
    library.formSubmit();
    library.initializaComponents();
});

