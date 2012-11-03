// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
   
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Windows.Forms;


namespace Singleton
{
    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06", SessionMode=SessionMode.Required)]
    public interface ISingletonService
    {
        [OperationContract]
        void IncrementCounter();
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SingletonService : ISingletonService, IDisposable
    {
        Dictionary<string, int> m_counters = new Dictionary<string, int>();

        public SingletonService()
        {
            MessageBox.Show("Constructing singleton object.");
        }
        
        #region ISingletonService Members

        public void IncrementCounter()
        {

            if (!m_counters.ContainsKey(OperationContext.Current.SessionId))
                m_counters.Add(OperationContext.Current.SessionId, 0);

            m_counters[OperationContext.Current.SessionId]++;

            MessageBox.Show(String.Format("Incrementing counter to {0} on session {1}.", m_counters[OperationContext.Current.SessionId], OperationContext.Current.SessionId));
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            MessageBox.Show("Disposing singleton object.");
        }

        #endregion
    }

}
