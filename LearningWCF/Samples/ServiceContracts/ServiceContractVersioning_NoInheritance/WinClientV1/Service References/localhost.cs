﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinClientV1.localhost
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.thatindigogirl.com/samples/2006/06", ConfigurationName="WinClientV1.localhost.ServiceAContract")]
    public interface ServiceAContract
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.thatindigogirl.com/samples/2006/06/ServiceAContract/Operation1", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/ServiceAContract/Operation1Response" +
            "")]
        string Operation1();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.thatindigogirl.com/samples/2006/06/ServiceAContract/Operation2", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/ServiceAContract/Operation2Response" +
            "")]
        string Operation2();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ServiceAContractChannel : WinClientV1.localhost.ServiceAContract, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class ServiceAContractClient : System.ServiceModel.ClientBase<WinClientV1.localhost.ServiceAContract>, WinClientV1.localhost.ServiceAContract
    {
        
        public ServiceAContractClient()
        {
        }
        
        public ServiceAContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public ServiceAContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public ServiceAContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public ServiceAContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
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
