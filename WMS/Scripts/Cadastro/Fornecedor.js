function CarregarTela() {
    WMSCarregarTela_Click("#btnNovo", "ManutencaoFornecedor");
}

function ConsultarCEP()
{
    var CEP =
        {
            Cep: $('#txtCEP').val()
        };

    WMSConsultarCEP(CEP, "RetornoCEP");
}

function RetornoCEP(objCEP)
{
    $('#txtBairro').val(objCEP.Bairro);
    $('#txtEndereco').val(objCEP.Endereco);
    $('#txtMunicipio').val(objCEP.Municipio);
    $('#txtEstado').val(objCEP.Estado);
}