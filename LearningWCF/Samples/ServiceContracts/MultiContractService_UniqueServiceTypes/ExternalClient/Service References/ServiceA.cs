﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExternalClient.ServiceA
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.thatindigogirl.com/samples/2006/06", ConfigurationName="ExternalClient.ServiceA.IServiceA")]
    public interface IServiceA
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.thatindigogirl.com/samples/2006/06/IServiceA/Operation1", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/IServiceA/Operation1Response")]
        string Operation1();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.thatindigogirl.com/samples/2006/06/IServiceA/Operation2", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/IServiceA/Operation2Response")]
        string Operation2();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IServiceAChannel : ExternalClient.ServiceA.IServiceA, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class ServiceAClient : System.ServiceModel.ClientBase<ExternalClient.ServiceA.IServiceA>, ExternalClient.ServiceA.IServiceA
    {
        
        public ServiceAClient()
        {
        }
        
        public ServiceAClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public ServiceAClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public ServiceAClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public ServiceAClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public string Operation1()
        {
            return base.Channel.Operation1();
        }
        
        public string Operation2()
        {
            return base.Channel.Operation2();
        }
    }
}
