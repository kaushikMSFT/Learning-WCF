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
   [ServiceContract(Namespace="http://www.thatindigogirl.com/samples/2006/06",SessionMode=SessionMode.Required)]
   public interface ICounterServiceSession
   {
       [OperationContract(IsOneWay = true)]
      void IncrementCounter();
   }

   [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
   public class CounterServiceSession:ICounterServiceSession, IDisposable
   {
      private int m_counter;

      #region ICounterServiceSession Members

      void ICounterServiceSession.IncrementCounter()
      {
         m_counter++;

         MessageBox.Show(String.Format("Incrementing Session counter to {0} on thread {1}", m_counter, Thread.CurrentThread.GetHashCode()));

      }

      #endregion

      #region IDisposable Members

      void IDisposable.Dispose()
      {
         //MessageBox.Show(String.Format("Disposing Session on thread {0}.", Thread.CurrentThread.GetHashCode()));
      }

      #endregion
   }
}
