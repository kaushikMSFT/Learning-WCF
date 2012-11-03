// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ServiceModel;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Client running on thread {0}", Thread.CurrentThread.GetHashCode());
            Console.WriteLine();
            
            CallbackType cb = new CallbackType();
            InstanceContext context = new InstanceContext(cb);

            WSDualHttpBinding binding = new WSDualHttpBinding();
            binding.ClientBaseAddress=new Uri("http://localhost:8100");

            DuplexChannelFactory<IHelloIndigoService> factory = new DuplexChannelFactory<IHelloIndigoService>(context, binding, new EndpointAddress("http://localhost:8000/wsDual"));
            IHelloIndigoService proxy = factory.CreateChannel();

            try
            {

                Console.WriteLine("Calling HelloIndigo() - one-way");
                proxy.HelloIndigo("Hello from client.");
                Console.WriteLine("Returned from HelloIndigo()");

                Console.WriteLine("Calling HelloIndigo() - not one-way");
                proxy.HelloIndigo2("Hello from client.");
                Console.WriteLine("Returned from HelloIndigo()");

                Console.ReadLine();
            }
            finally
            {
                ICommunicationObject obj = proxy as ICommunicationObject;
                obj.Close();
            }
        }

    }
}
