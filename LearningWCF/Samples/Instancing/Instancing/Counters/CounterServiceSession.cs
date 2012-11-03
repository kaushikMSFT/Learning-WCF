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
      [OperationContract]
      int IncrementCounter();
   }

   [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
   public class CounterServiceSession:ICounterServiceSession
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

   }
}
