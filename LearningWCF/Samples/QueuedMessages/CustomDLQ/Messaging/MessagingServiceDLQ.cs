// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Messaging
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, AddressFilterMode=AddressFilterMode.Any)]
    public class MessagingServiceDlq: IMessagingService
    {

        #region IMessagingService Members

        [OperationBehavior(TransactionScopeRequired = true)]
        public void SendMessage(string message)
        {
            string s = String.Format("Processing message from dead letter queue: '{0}'.", message);
            Console.WriteLine(s);

            object obj;
            if (OperationContext.Current.IncomingMessageProperties.TryGetValue("MsmqMessageProperty", out obj))
            {
                MsmqMessageProperty msmqProps = obj as MsmqMessageProperty;
                Console.WriteLine("\tAbortCount={0}, MoveCount={1}, DeliveryFailure={2}, DeliveryStatus={3}", msmqProps.AbortCount, msmqProps.MoveCount, msmqProps.DeliveryFailure, msmqProps.DeliveryStatus);
            }

        }

        #endregion
    }
}
