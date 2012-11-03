// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Windows.Forms;
using System.Threading;

namespace Counters
{
   [ServiceContract(Namespace="http://www.thatindigogirl.com/samples/2006/06")]
   public interface ICounterServiceSingle
   {
       [OperationContract(IsOneWay = true)]
      void IncrementCounter();
   }

   [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
   public class CounterServiceSingle : ICounterServiceSingle, IDisposable
   {
      private int m_counter;

      #region ICounterServiceSingle Members

      void ICounterServiceSingle.IncrementCounter()
      {
         m_counter++;

         MessageBox.Show(String.Format("Incrementing Singleton counter to {0} on thread {1}", m_counter, Thread.CurrentThread.GetHashCode()));

      }

      #endregion

      #region IDisposable Members

      void IDisposable.Dispose()
      {
         //MessageBox.Show(String.Format("Disposing Single on thread {0}.", Thread.CurrentThread.GetHashCode()));
      }

      #endregion
   }
}
