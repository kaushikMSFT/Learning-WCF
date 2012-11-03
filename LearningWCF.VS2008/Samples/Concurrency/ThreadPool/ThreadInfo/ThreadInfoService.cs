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

namespace ThreadInfo
{
   [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
   public interface IThreadInfoService
   {
      [OperationContract]
      string GetThreadInfo();
   }

   public class ThreadInfoService : IThreadInfoService, IDisposable
   {
      #region IDisposable Members

      void IDisposable.Dispose()
      {
         Console.WriteLine(String.Format("Disposing on thread {0}.", Thread.CurrentThread.GetHashCode()));
      }

      #endregion
      
      #region IThreadInfoService Members

      string IThreadInfoService.GetThreadInfo()
      {

         int workerThreads;
         int completionPortThreads;
         ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads); 
         
         string s = String.Format("ThreadPool.GetAvailableThreads(): \r\n\tworkerThreads: {0}\r\n\tcompletionPortThreads: {1}\r\n\t", workerThreads, completionPortThreads);
         Console.WriteLine(s);
         Console.WriteLine();

         s = String.Format("IThreadInfoService.GetThreadInfo() called on thread {0}. \r\n\tIsThreadPoolThread: {1}\r\n\tIsBackground: {2}\r\n\t", Thread.CurrentThread.GetHashCode(), Thread.CurrentThread.IsThreadPoolThread, Thread.CurrentThread.IsBackground);
         Console.WriteLine(s);

         return s;
      }

      #endregion
   }
}
