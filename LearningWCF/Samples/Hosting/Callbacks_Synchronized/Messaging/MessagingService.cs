// � 2007 Michele Leroux Bustamante. All rights reserved 
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

namespace Messaging
{
    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06", CallbackContract=typeof(IMessagingServiceCallback))]
    public interface IMessagingService
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);
    }

    public interface IMessagingServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageNotification(string message);
    }

    // default behavior
    //[ServiceBehavior(UseSynchronizationContext=true)]
    public class MessagingService : IMessagingService
    {
        #region IMessagingService Members

        public void SendMessage(string message)
        {
            IMessagingServiceCallback callback = OperationContext.Current.GetCallbackChannel<IMessagingServiceCallback>();

            MessageBox.Show(String.Format("Message '{0}' received on thread {1} : MessageLoop = {2}", message, Thread.CurrentThread.GetHashCode(), Application.MessageLoop), "MessagingService.SendMessage()");

            callback.MessageNotification(string.Format("MessagingService received message at {0}", DateTime.Now.ToLongTimeString()));
        }

        #endregion
    }


}
