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
      [OperationContract]
      int IncrementCounter();


      [OperationContract]
      void ThrowException();

      [OperationContract]
      [FaultContract(typeof(InvalidOperationException))]
      void ThrowFault();
   }

   [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single, ConcurrencyMode=ConcurrencyMode.Single)]
   public class CounterServiceSingle : ICounterServiceSingle, IDisposable
   {
      private int m_counter;

      #region ICounterServiceSingle Members

      int ICounterServiceSingle.IncrementCounter()
      {
         m_counter++;


         MessageBox.Show(String.Format("Incrementing Singleton counter to {0}.\r\nSession Id: {1}", m_counter, OperationContext.Current.SessionId));

         return m_counter;
      }

      #endregion

      public void ThrowException()
      {
          throw new NotImplementedException("The method or operation is not implemented.");
      }

      public void ThrowFault()
      {
          throw new FaultException<InvalidOperationException>(new InvalidOperationException("This is an invalid operation."), "Invalid operation.");
      }
      #region IDisposable Members

      void IDisposable.Dispose()
      {
         //MessageBox.Show(String.Format("Disposing Single on thread {0}.", Thread.CurrentThread.GetHashCode()));
      }

      #endregion
   }
}
