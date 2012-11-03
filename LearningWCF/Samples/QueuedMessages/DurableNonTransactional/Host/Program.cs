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
using System.Messaging;

namespace Host
{
   class Program
   {
      static void Main(string[] args)
      {
         using (ServiceHost host = new ServiceHost(typeof(Messaging.MessagingService)))
         {

             string queueName = ".\\private$\\MessagingServiceNoTransQueue";
             if (!MessageQueue.Exists(queueName))
                 MessageQueue.Create(queueName, false);

            host.Open();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate the host application");
            Console.ReadLine();
   
   
         }
      }
   }
}
