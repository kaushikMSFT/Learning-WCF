// © 2005-2006 Michele Leroux Bustamante. All rights reserved 
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

             string queueName = ".\\private$\\MessagingServiceQueue";
             if (!MessageQueue.Exists(queueName))
                 MessageQueue.Create(queueName, true);
             
             host.Faulted +=new EventHandler(host_Faulted);
            host.Open();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate the host application");
            Console.ReadLine();
   
   
         }
      }

       static void host_Faulted(object sender, EventArgs e)
       {
            Console.WriteLine("ServiceHost faulted...will need to be restarted.");
       }
   }
}
