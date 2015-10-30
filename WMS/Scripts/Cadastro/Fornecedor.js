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

function EditarFornecedor(pidFornecedor) {
    WMSLoadTela("ManutencaoFornecedor", { idFornecedor: pidFornecedor });
}

function ExcluirFornecedor(idFornecedor) {
    WMSConfirmar("Deseja realmente excluir o Fornecedor?", "Exclusão de Fornecedor", "ApagarFornecedor(" + idFornecedor+ ")")
}

function ApagarFornecedor(idFornecedor) {
    ExcluirSucesso();
    return;
}

function ExcluirSucesso() {
    WMSEscondeConfirm();
    WMSMensagem("Fornecedor excluído", "SUCESSO", "Sucesso", "window.location = 'Fornecedor';");
    return;
}
