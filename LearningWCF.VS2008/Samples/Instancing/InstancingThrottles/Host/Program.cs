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

namespace Host
{
   class Program
   {
      static void Main(string[] args)
      {
         using (ServiceHost hostA = new ServiceHost(typeof(Counters.CounterServicePerCall)))
         using (ServiceHost hostB = new ServiceHost(typeof(Counters.CounterServiceSession)))
         using (ServiceHost hostC = new ServiceHost(typeof(Counters.CounterServiceSingle)))
         {

            hostA.Open();
            hostB.Open();
            hostC.Open();


            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate the host application");
            Console.ReadLine();
   
   
         }
      }
   }
}
