// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HelloIndigo.HelloIndigoService)))
            {
                host.AddServiceEndpoint(typeof(HelloIndigo.IHelloIndigoService), new NetTcpBinding(), "net.tcp://localhost:9000/HelloIndigo");
                host.Open();

                Console.WriteLine("Press <Enter> to terminate the Host application.");
                Console.WriteLine();
                Console.ReadLine();
            }
        }

    }

}
