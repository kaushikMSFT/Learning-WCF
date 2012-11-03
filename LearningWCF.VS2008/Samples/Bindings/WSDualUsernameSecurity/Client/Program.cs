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
                b.ClientBaseAddress=new Uri("http://localhost:8100");
                
                // Enter valid windows credentials here
                Console.WriteLine();
                Console.Write("Enter username:");
                string username = Console.ReadLine();
                Console.Write("Enter password:");
                string password = Console.ReadLine();

                proxy.ClientCredentials.UserName.UserName=username;
                proxy.ClientCredentials.UserName.Password=password;

                Console.WriteLine();
                Console.WriteLine("Calling HelloIndigo() - one-way");
                proxy.HelloIndigo("Hello from client.");
                Console.WriteLine("Returned from HelloIndigo()");


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
        }

        public void HelloIndigoCallback2(string message)
        {
            Console.WriteLine("HelloIndigoCallback2 on thread {0} - not one-way", Thread.CurrentThread.GetHashCode());
            
        }

        #endregion
    }
}
