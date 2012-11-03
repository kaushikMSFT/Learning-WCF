// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using PhotoManagerService;

namespace Host
{
    class ErrorHandlerHost:ServiceHost
    {
        public ErrorHandlerHost(Type t):base(t)
        {
            
        }

        
        protected override void InitializeRuntime()
        {
            Console.WriteLine("InitializeRuntime()");

            base.InitializeRuntime();
            foreach (ChannelDispatcher dispatcher in this.ChannelDispatchers)
            {
                dispatcher.ErrorHandlers.Add(new PhotoManagerService.FaultErrorHandler());
            }
           
        }
        protected override void ApplyConfiguration()
        {
            Console.WriteLine("ApplyConfiguration()");
            base.ApplyConfiguration();
        }
        
        protected override void OnOpening()
        {
            Console.WriteLine("OnOpening()");

            base.OnOpening();
            foreach (ChannelDispatcher dispatcher in this.ChannelDispatchers)
            {
                dispatcher.ErrorHandlers.Add(new PhotoManagerService.FaultErrorHandler());
            }

            
        }
    }
}
