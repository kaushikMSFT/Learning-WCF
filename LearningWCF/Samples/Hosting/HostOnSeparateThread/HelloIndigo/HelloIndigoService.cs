// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.ServiceModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace HelloIndigo
{

    [ServiceContract(Namespace="http://www.thatindigogirl.com/samples/2006/06")]
    public interface IHelloIndigoService
    {
        [OperationContract(IsOneWay=true)]
        void HelloIndigo(string s);
    }

    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple, UseSynchronizationContext=true)]
    public class HelloIndigoService : IHelloIndigoService
    {
        #region IHelloIndigoService Members

        public void HelloIndigo(string s)
        {
            MessageBox.Show(String.Format("Message from {0} received on thread {1}. Message loop = {2}", s, Thread.CurrentThread.ManagedThreadId, Application.MessageLoop));

        }

        #endregion
    }

}

