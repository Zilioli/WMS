function ProcessarJSONCEP(objRes) {
    var HTML_HEADER = "<table class='table table-striped grid-table'><thead><tr>";
    HTML_HEADER += "<th class='grid-header'><div class='grid-header-title'><a href='#'>&nbsp;</a></div></th>";
    HTML_HEADER += "<th class='grid-header'><div class='grid-header-title'><a href='#'>CEP</a></div></th>";
    HTML_HEADER += "<th class='grid-header'><div class='grid-header-title'><a href='#'>Endereço</a></div></th>";
    HTML_HEADER += "<th class='grid-header'><div class='grid-header-title'><a href='#'>Cidade</a></div></th>";
    HTML_HEADER += "<th class='grid-header'><div class='grid-header-title'><a href='#'>Estado</a></div></th>";
    HTML_HEADER += "</tr></thead>";

    var HTML_BODY = "<tbody>";
    var HTML_FOOTER = "</tbody></table>";
    var Selecionar = "";
    var cont = 0;

    $.each(objRes, function (index, item) {
        Selecionar = 'javascript:SelecionarEndereco("' + item.Cep + '")';
        HTML_BODY += "<tr class='grid-row '><td class='grid-cell' data-name=''><a id='btnOK' class='btnEdit'  href='" + Selecionar + "' >&nbsp;<span class='glyphicon glyphicon-ok'></span> </a></td></td>";
        HTML_BODY += "<td class='grid-cell' data-name=''>" + item.Cep + "</td>";
        HTML_BODY += "<td class='grid-cell' data-name=''>" + item.Endereco + "</td>";
        HTML_BODY += "<td class='grid-cell' data-name=''>" + item.Municipio + "</td>";
        HTML_BODY += "<td class='grid-cell' data-name=''>" + item.UF + "</td>";
        HTML_BODY += "</tr>";
        cont++;
    });

    if (cont > 0)
        $("#gridCEP").html(HTML_HEADER + HTML_BODY + HTML_FOOTER);
    else
        $("#gridCEP").html("Nenhum registro encontrado");

    $("#modal-container-cep").find('input[id="txtCEP"]').attr('disabled', false);

}

function SelecionarEndereco(val) {
    $("#modal").find('input[id="txtCEP"]').val(val);
    ConsultarCEP();
    $('#modal-container-cep').modal('toggle');
}

function ConsultarEndereco()
{
    if ($("#modal-container-cep").find('input[id="txtCEP"]').val().length < 10) {
        WMSMensagem("Especifique melhor a consulta", "ALERTA", "Alerta");
        $('#modal-container-cep').modal('toggle');
        return false;
    }
    else if ($("#modal-container-cep").find('input[id="txtCEP"]').attr('disabled') == "disabled") 
        return false;

    $("#modal-container-cep").find('input[id="txtCEP"]').attr('disabled', true);

    $("#gridCEP").html("<div class='overlay' style='vertical-align:central;align:center'><i class='fa fa-refresh fa-spin'>Carregando...</i></div>");

    var CEP = { Endereco: $("#modal-container-cep").find('input[id="txtCEP"]').val() };
    WMSAjax("../Util/ConsultarEndereco", "POST", CEP, "ProcessarJSONCEP", "ERROR_CEP");

}

function ERROR_CEP(Mensagem)
{
    WMSMensagem(Mensagem, "ERRO", "ERRO");
    $("#modal-container-cep").find('input[id="txtCEP"]').attr('disabled', false);

    $("#gridCEP").html("");
}