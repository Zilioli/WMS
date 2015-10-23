﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WMS.wcfCadastro {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcfCadastro.ICadastro")]
    public interface ICadastro {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICadastro/ManutencaoPerfil", ReplyAction="http://tempuri.org/ICadastro/ManutencaoPerfilResponse")]
        bool ManutencaoPerfil(string pACAO, string pJSONPerfil);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICadastro/ManutencaoPerfil", ReplyAction="http://tempuri.org/ICadastro/ManutencaoPerfilResponse")]
        System.Threading.Tasks.Task<bool> ManutencaoPerfilAsync(string pACAO, string pJSONPerfil);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICadastro/ListarPerfil", ReplyAction="http://tempuri.org/ICadastro/ListarPerfilResponse")]
        string ListarPerfil(string pJSONPerfil);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICadastro/ListarPerfil", ReplyAction="http://tempuri.org/ICadastro/ListarPerfilResponse")]
        System.Threading.Tasks.Task<string> ListarPerfilAsync(string pJSONPerfil);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICadastro/ListarFornecedor", ReplyAction="http://tempuri.org/ICadastro/ListarFornecedorResponse")]
        string ListarFornecedor(string pJSONFornecedor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICadastro/ListarFornecedor", ReplyAction="http://tempuri.org/ICadastro/ListarFornecedorResponse")]
        System.Threading.Tasks.Task<string> ListarFornecedorAsync(string pJSONFornecedor);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICadastroChannel : WMS.wcfCadastro.ICadastro, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CadastroClient : System.ServiceModel.ClientBase<WMS.wcfCadastro.ICadastro>, WMS.wcfCadastro.ICadastro {
        
        public CadastroClient() {
        }
        
        public CadastroClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CadastroClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CadastroClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CadastroClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ManutencaoPerfil(string pACAO, string pJSONPerfil) {
            return base.Channel.ManutencaoPerfil(pACAO, pJSONPerfil);
        }
        
        public System.Threading.Tasks.Task<bool> ManutencaoPerfilAsync(string pACAO, string pJSONPerfil) {
            return base.Channel.ManutencaoPerfilAsync(pACAO, pJSONPerfil);
        }
        
        public string ListarPerfil(string pJSONPerfil) {
            return base.Channel.ListarPerfil(pJSONPerfil);
        }
        
        public System.Threading.Tasks.Task<string> ListarPerfilAsync(string pJSONPerfil) {
            return base.Channel.ListarPerfilAsync(pJSONPerfil);
        }
        
        public string ListarFornecedor(string pJSONFornecedor) {
            return base.Channel.ListarFornecedor(pJSONFornecedor);
        }
        
        public System.Threading.Tasks.Task<string> ListarFornecedorAsync(string pJSONFornecedor) {
            return base.Channel.ListarFornecedorAsync(pJSONFornecedor);
        }
    }
}
