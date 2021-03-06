// � 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            // NOTE: with ProtectionLevel setting on the service contract, Open() will fail
            // Bindings must provide the required protection level for operation requirements
            using (ServiceHost host = new ServiceHost(typeof(HelloIndigo.HelloIndigoService)))
            {
                host.Open();

                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate the host application");
                Console.ReadLine();
   
            }
        }
    }
}
