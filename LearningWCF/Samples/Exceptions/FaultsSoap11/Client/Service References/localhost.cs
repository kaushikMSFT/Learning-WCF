﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.312
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.localhost
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Client.localhost.IFaultExceptionService")]
    public interface IFaultExceptionService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFaultExceptionService/ThrowSimpleFault", ReplyAction="http://tempuri.org/IFaultExceptionService/ThrowSimpleFaultResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.InvalidOperationException), Action="http://tempuri.org/IFaultExceptionService/ThrowSimpleFaultInvalidOperationExcepti" +
            "onFault", Name="InvalidOperationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void ThrowSimpleFault();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFaultExceptionService/ThrowMessageFault", ReplyAction="http://tempuri.org/IFaultExceptionService/ThrowMessageFaultResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.InvalidOperationException), Action="http://tempuri.org/IFaultExceptionService/ThrowMessageFaultInvalidOperationExcept" +
            "ionFault", Name="InvalidOperationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void ThrowMessageFault();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFaultExceptionService/ThrowFaultException", ReplyAction="http://tempuri.org/IFaultExceptionService/ThrowFaultExceptionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.InvalidOperationException), Action="http://tempuri.org/IFaultExceptionService/ThrowFaultExceptionInvalidOperationExce" +
            "ptionFault", Name="InvalidOperationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void ThrowFaultException();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IFaultExceptionServiceChannel : Client.localhost.IFaultExceptionService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class FaultExceptionServiceClient : System.ServiceModel.ClientBase<Client.localhost.IFaultExceptionService>, Client.localhost.IFaultExceptionService
    {
        
        public FaultExceptionServiceClient()
        {
        }
        
        public FaultExceptionServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public FaultExceptionServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public FaultExceptionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public FaultExceptionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public void ThrowSimpleFault()
        {
            base.Channel.ThrowSimpleFault();
        }
        
        public void ThrowMessageFault()
        {
            base.Channel.ThrowMessageFault();
        }
        
        public void ThrowFaultException()
        {
            base.Channel.ThrowFaultException();
        }
    }
}
