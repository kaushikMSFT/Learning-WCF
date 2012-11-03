// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using Client.localhost;
using System.Collections;
using System.Runtime.Serialization;

namespace Client
{
    public class CallbackType : IHelloIndigoServiceCallback
    {

        #region IHelloIndigoServiceCallback Members

        public void Event(EventArgs args)
        {
            CustomEventArgs customArgs = args as CustomEventArgs;
            Console.WriteLine("Received callback with args: {0}", customArgs.ArgValue);

        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            CallbackType c = new CallbackType();
            InstanceContext instance = new InstanceContext(c);
            using (localhost.HelloIndigoServiceClient proxy = new Client.localhost.HelloIndigoServiceClient(instance))
            {
                proxy.HelloIndigo();
                Console.WriteLine("Press <ENTER> to terminate Client");                       Console.ReadLine();         
            }



        }
    }
}
