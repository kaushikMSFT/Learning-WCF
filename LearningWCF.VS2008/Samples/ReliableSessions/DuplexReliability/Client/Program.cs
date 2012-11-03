// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using Client.localhost;
using System.Threading;
using System.ServiceModel;

namespace Client
{
    class Program: IHelloIndigoServiceCallback
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Client running on thread {0}", Thread.CurrentThread.GetHashCode());
            Console.WriteLine();
            
            Program p = new Program();
            InstanceContext context = new InstanceContext(p);
            using (localhost.HelloIndigoServiceClient proxy = new HelloIndigoServiceClient(context))
            {
                WSDualHttpBinding b = proxy.Endpoint.Binding as WSDualHttpBinding;
                if (b!=null)
                    b.ClientBaseAddress=new Uri("http://localhost:8100");


                Console.WriteLine("Calling HelloIndigo() - one-way");
                proxy.HelloIndigo("Hello from client.");
                Console.WriteLine("Returned from HelloIndigo()");

                Console.WriteLine("Client SessionId = {0}", proxy.InnerChannel.SessionId);     

                Console.WriteLine("Calling HelloIndigo2() - not one-way");
                proxy.HelloIndigo2("Hello from client.");
                Console.WriteLine("Returned from HelloIndigo2()");

                Console.ReadLine();
            }
            Console.ReadLine();

        }

        #region IHelloIndigoServiceCallback Members

        public void HelloIndigoCallback(string message)
        {
            Console.WriteLine("HelloIndigoCallback on thread {0} - one-way", Thread.CurrentThread.GetHashCode());
            Console.WriteLine("Client Callback SessionId = {0}", OperationContext.Current.SessionId);
        }

        public void HelloIndigoCallback2(string message)
        {
            Console.WriteLine("HelloIndigoCallback2 on thread {0} - not one-way", Thread.CurrentThread.GetHashCode());
            Console.WriteLine("Client Callback SessionId = {0}", OperationContext.Current.SessionId);     
        }

        #endregion
    }
}
