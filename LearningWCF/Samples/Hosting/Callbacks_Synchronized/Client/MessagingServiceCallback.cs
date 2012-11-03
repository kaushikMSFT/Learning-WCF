// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using Client.localhost;
using System.Windows.Forms;
using System.Threading;
using System.ServiceModel;

namespace Client
{
    // default behavior
    //[CallbackBehavior(UseSynchronizationContext=true)]
    class MessagingServiceCallback:IMessagingServiceCallback
    {
        #region IMessagingServiceCallback Members

        public void MessageNotification(string message)
        {
            MessageBox.Show(String.Format("Message '{0}' received on thread {1} : MessageLoop = {2}", message, Thread.CurrentThread.GetHashCode(), Application.MessageLoop), "IMessagingServiceCallback.MessageNotification()");
        }

        #endregion
    }
}
