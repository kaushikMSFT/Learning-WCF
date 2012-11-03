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
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Messaging
{
    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IMessagingService
    {
        [OperationContract(IsOneWay=true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void SendMessage(string message);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class MessagingService : IMessagingService
    {

        #region IMessagingService Members

        
        [OperationBehavior(TransactionScopeRequired=true)]
        public void SendMessage(string message)
        {
            Console.WriteLine(String.Format("Message received: '{0}'", message));
        }

        #endregion
    }
}
