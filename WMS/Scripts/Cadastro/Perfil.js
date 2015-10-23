var var_idPerfil;

function SalvarPerfil() {

    var Perfil = {
        idPerfil: $('#txtIdPerfil').val(),
        desPerfil: $('#txtDesPerfil').val()
    };

    WMSAjax("/Cadastro/SalvarPerfil", "POST", Perfil, "SalvarPerfilSucesso()", "WMSErro(x)");
}

function ApagarPerfil(idPerfilAux)
{
    var Perfil = {
        idPerfil: idPerfilAux,
        desPerfil: null
    };
 
    WMSAjax("/Cadastro/DeletarPerfil", "POST", Perfil, "ExcluirSucesso()", "WMSErro(x)");
    return;
}

function SalvarPerfilSucesso()
{
    WMSEscondeModal();
    WMSMensagem("Perfil Salvo", "SUCESSO", "Sucesso", "ListarPerfil()");
}

function ListarPerfil()
{
   
    var Perfil = {
        idPerfil: -1,
        desPerfil: null
    };

    window.location = "Perfil";
    return;
}

function ExcluirSucesso()
{
    WMSEscondeConfirm();
    WMSMensagem("Perfil excluído", "SUCESSO", "Sucesso", "window.location = 'Perfil';");
    return;
}


function CarregarTela()
{
    WMSCarregarTela_Click("#btnNovo", "ManutencaoPerfil");
}

function EditarPerfil(pidPerfil)
{
    WMSLoadTela("ManutencaoPerfil", { idPerfil: pidPerfil });
}

function ExcluirPerfil(idPerfil)
{
    WMSConfirmar("Deseja realmente excluir o Perfil?", "Exclusão de Perfil", "ApagarPerfil(" + idPerfil + ")")
}