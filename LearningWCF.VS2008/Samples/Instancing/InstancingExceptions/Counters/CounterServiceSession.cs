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
   [ServiceContract(Namespace="http://www.thatindigogirl.com/samples/2006/06", SessionMode=SessionMode.Required)]
   public interface ICounterServiceSession
   {
      [OperationContract]
      int IncrementCounter();


      [OperationContract]
      void ThrowException();

      [OperationContract]
      [FaultContract(typeof(InvalidOperationException))]
      void ThrowFault();
   }

   [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
   public class CounterServiceSession:ICounterServiceSession, IDisposable
   {
      private int m_counter;

      #region ICounterServiceSession Members

      int ICounterServiceSession.IncrementCounter()
      {
         m_counter++;

         MessageBox.Show(String.Format("Incrementing Session counter to {0}.\r\nSession Id: {1}", m_counter, OperationContext.Current.SessionId));
         return m_counter;
      }

      #endregion

      public void ThrowException()
      {
          throw new NotImplementedException("The method or operation is not implemented.");
      }

      public void ThrowFault()
      {
          //throw new FaultException("The method or operation is not implemented.");
          //throw new FaultException<InvalidOperationException>(new InvalidOperationException("This is an invalid operation."), "Invalid operation.");
          throw new FaultException<NotImplementedException>(new NotImplementedException("Not implemented."), "Not implemented.");
      }
      #region IDisposable Members

      void IDisposable.Dispose()
      {
         //MessageBox.Show(String.Format("Disposing Session on thread {0}.", Thread.CurrentThread.GetHashCode()));
      }

      #endregion
   }
}
