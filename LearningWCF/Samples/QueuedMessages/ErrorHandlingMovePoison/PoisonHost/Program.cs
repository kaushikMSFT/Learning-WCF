// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace PoisonHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Messaging.MessagingServicePoison)))
            {

                host.Open();

                Console.WriteLine("Poison message handler for MessagingServiceQueue;poison");
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate the host application");
                Console.ReadLine();

            }

        }
    }
}
