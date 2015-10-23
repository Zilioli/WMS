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
        success: function (response) {
            eval(funcSuccess);
        },
        error: function (x) {
            eval(funcError);
        }
    });
}

function WMSErro(error) {
    WMSMensagem(error.message, "ERRO", "ERRO");
}

/*
 * mensagem: Mensagem a ser exibida no alert
 * tipo: tipo da mensagem a ser exibida (SUCESSO, ALERTA, ERRO, INFO)
 * header: Cabeçalho do alerta
 * Exemplo de chamada
 * WMSMensagem("Perfil Salvo", "SUCESSO", "Sucesso");
 */
function WMSMensagem(mensagem, tipo, header, funcOK) {

    $("#alert_class").removeClass();
    $("#btnOKModal").removeClass();

    if (tipo == "ALERTA")
    {
        $("#btnOKModal").addClass("btn btn-warning");
        $("#alert_class").addClass("alert alert-warning alert-dismissable");
    }
    else if (tipo == "SUCESSO")
    {
        $("#alert_class").addClass("alert alert-success alert-dismissable");
        $("#btnOKModal").addClass("btn btn-success");
    }
    else if (tipo == "ERRO")
    {
        $("#alert_class").addClass("alert alert-danger alert-dismissable");
        $("#btnOKModal").addClass("btn btn-danger");
    }
    else if (tipo == "INFO")
    {
        $("#alert_class").addClass("alert alert-info alert-dismissable");
        $("#btnOKModal").addClass("btn btn-info");
    }

    $("#alert_header").html(header);
    $("#alert_message").html(mensagem);
    $('#AlertaModal').modal('show');

    if (funcOK != null) {
        $("#AlertaModal").on('click', "#btnOKModal", function () {
            eval(funcOK);
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
function WMSConfirmar(mensagem, header,funcOK)
{
    $("#confirmMessage").html(mensagem);
    $("#confirmHeader").html(header);
    $('#ConfirmModal').modal('show');

    $("#ConfirmModal").on('click', "#actionConfirmModal", function () {
        if(funcOK != null)
            eval(funcOK);
        });
}

function WMSEscondeAlertaModal()
{
    $('#AlertaModal').modal('toggle');
}

function WMSEscondeModal() {
    $('#modal').modal('toggle');
    $('#modal').html("");
}

function WMSEscondeConfirm()
{
    $('#ConfirmModal').modal('toggle');
}


function WMSLoading()
{
    $('#pleaseWaitDialog').modal('show');
}


/*
 * urlController:  URL do Controller em que a ação deverá ser executada
 * Exemplo de chamada
 * WMSCarregarTela("ManutencaoPerfil", {idPerfil:});
 */
function WMSLoadTela(urlController, vo)
{
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

