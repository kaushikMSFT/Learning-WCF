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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.thatindigogirl.com/samples/2006/06", ConfigurationName="Client.localhost.IMessagingService")]
    public interface IMessagingService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.thatindigogirl.com/samples/2006/06/IMessagingService/SendMessage", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/IMessagingService/SendMessageRespon" +
            "se")]
        string SendMessage(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IMessagingServiceChannel : Client.localhost.IMessagingService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class MessagingServiceClient : System.ServiceModel.ClientBase<Client.localhost.IMessagingService>, Client.localhost.IMessagingService
    {
        
        public MessagingServiceClient()
        {
        }
        
        public MessagingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public MessagingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public MessagingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public MessagingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public string SendMessage(string message)
        {
            return base.Channel.SendMessage(message);
        }
    }
}