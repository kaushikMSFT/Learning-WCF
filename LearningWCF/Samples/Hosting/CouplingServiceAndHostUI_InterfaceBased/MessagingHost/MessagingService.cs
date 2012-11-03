// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace MessagingHost
{
    public interface IMessagingForm
    {
        void AddMessage(string message);
    }

    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IMessagingService
    {
        [OperationContract]
        string SendMessage(string message);
    }

    public class MessagingService : IMessagingService
    {
        #region IMessagingService Members

        public string SendMessage(string message)
        {
            string s = String.Format("Message '{0}' received at {1}", message, DateTime.Now.ToLongTimeString());

            IMessagingForm messagingForm = null;
            foreach (Form f in Application.OpenForms)
            {
                messagingForm = f as IMessagingForm;
                if (messagingForm != null) break;
            }
            if (messagingForm!=null)
                messagingForm.AddMessage(s);           

            return s;
        }

        #endregion
    }
}

