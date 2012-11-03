using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;

namespace Messaging
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=true)]
    class MsmqErrorHandlerAttribute: Attribute, IServiceBehavior, IErrorHandler
    {
        #region IErrorHandler Members

        public bool HandleError(Exception error)
        {
            return false;
        }

        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            Console.WriteLine(error.ToString());
        }

        #endregion


        #region IServiceBehavior Members

        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            
            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                
                dispatcher.ErrorHandlers.Add(this);
            }
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            
        }

        #endregion
    }
}
