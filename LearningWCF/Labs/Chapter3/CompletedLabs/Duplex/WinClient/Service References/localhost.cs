﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinClient.localhost
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.thatindigogirl.com/samples/2006/06", ConfigurationName="WinClient.localhost.HelloIndigoContract", CallbackContract=typeof(WinClient.localhost.HelloIndigoContractCallback))]
    public interface HelloIndigoContract
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.thatindigogirl.com/samples/2006/06/HelloIndigoContract/HelloIndigo", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/HelloIndigoContract/HelloIndigoResp" +
            "onse")]
        void HelloIndigo(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface HelloIndigoContractCallback
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.thatindigogirl.com/samples/2006/06/HelloIndigoContract/HelloIndigoCall" +
            "back", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/HelloIndigoContract/HelloIndigoCall" +
            "backResponse")]
        void HelloIndigoCallback(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface HelloIndigoContractChannel : WinClient.localhost.HelloIndigoContract, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class HelloIndigoContractClient : System.ServiceModel.DuplexClientBase<WinClient.localhost.HelloIndigoContract>, WinClient.localhost.HelloIndigoContract
    {
        
        public HelloIndigoContractClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance)
        {
        }
        
        public HelloIndigoContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName)
        {
        }
        
        public HelloIndigoContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress)
        {
        }
        
        public HelloIndigoContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress)
        {
        }
        
        public HelloIndigoContractClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress)
        {
        }
        
        public void HelloIndigo(string message)
        {
            base.Channel.HelloIndigo(message);
        }
    }
}
