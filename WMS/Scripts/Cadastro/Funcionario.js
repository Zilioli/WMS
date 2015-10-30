
function SalvarFuncionario() {

  

    var Funcionario = {
        Codigo: "1",
        Nome: "Luiz Leite"
    };
       
     
    WMSAjax("/Cadastro/SalvarFuncionario", "POST", Funcionario, "SalvarFuncionarioSucesso()", "WMSErro(x)");
   
    
}

function SalvarFuncionarioSucesso() {
    
    // WMSMensagem("Funcionário Salvo", "SUCESSO", "Sucesso");
    //WMSMensagem("Funcionário Salvo", "ERRO", "Sucesso", "alerta()");
    //WMSMensagem("Funcionário Salvo", "ALERTA", "Sucesso");    
    //WMSMensagem("Funcionário Salvo", "INFO", "informacao", "alerta()");

}
