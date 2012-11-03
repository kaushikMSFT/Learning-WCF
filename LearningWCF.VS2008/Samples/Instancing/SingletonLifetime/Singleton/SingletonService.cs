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
    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06", SessionMode=SessionMode.NotAllowed)]
    public interface ISingletonService
    {
        [OperationContract]
        void IncrementCounter();
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SingletonService : ISingletonService, IDisposable
    {
        int m_counter;

        public SingletonService()
        {
            m_counter = 0;
            MessageBox.Show("Constructing singleton object.");
        }
        
        #region ISingletonService Members

        public void IncrementCounter()
        {
            m_counter++;
            MessageBox.Show(m_counter.ToString());
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
