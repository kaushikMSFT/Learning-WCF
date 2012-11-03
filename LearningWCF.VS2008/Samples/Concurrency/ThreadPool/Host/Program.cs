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
using System.Threading;

namespace Host
{
   class Program
   {
      static void Main(string[] args)
      {
         using (ServiceHost host = new ServiceHost(typeof(ThreadInfo.ThreadInfoService)))
         {
            host.Open();

            Console.WriteLine("ThreadPool information...");
            Console.WriteLine();

            int workerThreads;
            int completionPortThreads;
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads); string s = String.Format("ThreadPool.GetAvailableThreads(): \r\n\tworkerThreads: {0}\r\n\tcompletionPortThreads: {1}\r\n\t", workerThreads, completionPortThreads);
            Console.WriteLine(s);
            Console.WriteLine();

            int maxWorkerThreads;
            int maxCompletionPortThreads;
            ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxCompletionPortThreads);
            s = String.Format("ThreadPool.GetMaxThreads(): \r\n\tmaxWorkerThreads: {0}\r\n\tmaxCompletionPortThreads: {1}\r\n\t", maxWorkerThreads, maxCompletionPortThreads);
            Console.WriteLine(s);
            Console.WriteLine();

            int minWorkerThreads;
            int minCompletionPortThreads;
            ThreadPool.GetMinThreads(out minWorkerThreads, out minCompletionPortThreads);
            s = String.Format("ThreadPool.GetMinThreads(): \r\n\tminWorkerThreads: {0}\r\n\tminCompletionPortThreads: {1}\r\n\t", minWorkerThreads, minCompletionPortThreads);
            Console.WriteLine(s);
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate the host application");
            Console.ReadLine();
   
   
         }
      }
   }
}
