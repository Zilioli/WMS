var WMSDataAjax;

/*
 * urlController: URL do Controller em que a ação deverá ser executada
 * typeAjax: Tipo do AJAX (POST/GET)
 * voModel: VO que deverá ser passada como parametro para o Controller
 * funcSuccess: Função que deverá ser executada após a execução ser finalizada com sucesso
 * funcError: Função que deverá ser executada após a execução ser finalizada com erro
 * Exemplo de chamada
 * WMSAjax("/Cadastro/SalvarPerfil", "POST", Perfil, "SalvarPerfilSucesso()", "WMSErro(x)");
 */
function WMSAjax(urlController, typeAjax, voModel, funcSuccess, funcError) {

    $.ajax({
        url: urlController,
        data: JSON.stringify(voModel),
        type: typeAjax,
        contentType: 'application/json; charset=utf-8;',
        dataType: 'json',
        success: function (data) {
            eval(funcSuccess + "( " + data + ")");
        },
        error: function (x) {
            alert("opa deu erro");
            eval(funcError);
        }
    });
}

function WMSErro(error) {
    WMSMensagem(error.message, "ERRO", "ERRO");
}

function alerta()
{
    alert('oi');
    $.unblockUI;
}

/*
 * mensagem: Mensagem a ser exibida no alert
 * tipo: tipo da mensagem a ser exibida (SUCESSO, ALERTA, ERRO, INFO)
 * header: Cabeçalho do alerta
 * Exemplo de chamada
 * WMSMensagem("Perfil Salvo", "SUCESSO", "Sucesso");
 */
function WMSMensagem(mensagem, tipo, header, funcOK) {

    $("#icon_alert").removeClass();
    $("#btnOKModal").removeClass();
    $("#alert_message").removeClass();
    $("#blockui").off('click');

    $("#alert_header span").text(header);
    $("#alert_message span").text(mensagem);
   
    if (tipo == "ALERTA") {       
        $("#alert_message").addClass("alert alert-warning alert-dismissable");
        $("#btnOKModal").addClass("btn btn-warning");
        $("#icon_alert").addClass("icon fa fa-warning");
    }
    else if (tipo == "SUCESSO") {       
        $("#alert_message").addClass("alert alert-success alert-dismissable");
        $("#btnOKModal").addClass("btn btn-success");
        $("#icon_alert").addClass("icon fa fa-check");
    }
    else if (tipo == "ERRO") {
        $("#alert_message").addClass("alert alert-danger alert-dismissable");
        $("#btnOKModal").addClass("btn btn-danger");
        $("#icon_alert").addClass("icon fa fa-ban");
    }
    else if (tipo == "INFO") {
        $("#alert_message").addClass("alert alert-info alert-dismissible");
        $("#btnOKModal").addClass("btn btn-info");
        $("#icon_alert").addClass("icon fa fa-info");
    }

    if (funcOK != null) {

        //necessario para o problema do segundo click do blockui
        $('#blockui').click(function () {
            $.unblockUI();
            return false;
        });

        $("#blockui").on('click', "#btnOKModal", function () {
            eval(funcOK);
        });

        $.blockUI({
            message: $("#blockui"),
            centerX: 0
        });           
    }
    else {

        $("#btnOKModal").remove();

        $.blockUI({
            message: $("#blockui"),
            centerX: 0,
            timeout: 2000
        });
    }
}

/*
 * mensagem: Mensagem a ser exibida no alert
 * header: Cabeçalho do alerta
 * funcOK: Função que será chamada quando a ação do componente for confirmada
 * Exemplo de chamada
 * WMSConfirmar("Deseja realmente excluir o Perfil?", "Exclusão de Perfil", "ApagarPerfil(" + idPerfil + ")")
 */
function WMSConfirmar(mensagem, header, funcOK) {
    $("#confirmMessage").html(mensagem);
    $("#confirmHeader").html(header);
    $('#ConfirmModal').modal('show');

    $("#ConfirmModal").on('click', "#actionConfirmModal", function () {
        if (funcOK != null)
            eval(funcOK);
        });
}

function WMSEscondeAlertaModal() {
    $('#AlertaModal').modal('toggle');
}

function WMSEscondeModal() {
    $('#modal').modal('toggle');
    $('#modal').html("");
}

function WMSEscondeConfirm() {
    $('#ConfirmModal').modal('toggle');
}


function WMSLoading() {
    $('#pleaseWaitDialog').modal('show');
}


/*
 * urlController:  URL do Controller em que a ação deverá ser executada
 * Exemplo de chamada
 * WMSCarregarTela("ManutencaoPerfil", {idPerfil:});
 */
function WMSLoadTela(urlController, vo) {
    $('#modal').load(urlController, vo, function () {
        $('#modal').modal();
    })
}

/*
 * idObject: Nome do objeto para adicionar o evento
 * urlController:  URL do Controller em que a ação deverá ser executada
 * Exemplo de chamada
 * WMSCarregarTela_Click("#btnNovo", "ManutencaoPerfil");
 */
function WMSCarregarTela_Click(idObject, urlController, vo) {

    $(idObject).click(function () {
        $('#modal').load(urlController, vo, function () {
            $('#modal').modal();
        });
    });
}

/*
 * voModel:  VO CEP preenchido para consulta
 * funcSuccess: Função que será chamada quando a ação do componente for confirmada
 * Exemplo de chamada
 * WMSConsultarCEP({Cep:05437001}, "RetornoCEP");
 */
function WMSConsultarCEP(voModel,funcSuccess)
{
    WMSAjax("../Util/ConsultarCEP", "POST", voModel, funcSuccess, WMSErro)
}

function WMSCarregaPopUpCEP(idObject,  vo)
{  
    $(idObject).click(function () {
        $('#modal-container-cep').load("../Util/CEP", vo, function () {
                $('#modal-container-cep').modal();
            });
        });   
}


/*
 * Função para sempre deixar os Painels(Modals) centralizados na tela
 */
$(function () {
    function reposition() {
        var modal = $(this),
            dialog = modal.find('.modal-dialog');
        modal.css('display', 'block');

        // Dividing by two centers the modal exactly, but dividing by three 
        // or four works better for larger screens.
        dialog.css("margin-top", Math.max(0, ($(window).height() - dialog.height()) / 2));
    }
    // Reposition when a modal is shown
    $('.modal').on('show.bs.modal', reposition);
    // Reposition when the window is resized
    $(window).on('resize', function () {
        $('.modal:visible').each(reposition);
    });
});