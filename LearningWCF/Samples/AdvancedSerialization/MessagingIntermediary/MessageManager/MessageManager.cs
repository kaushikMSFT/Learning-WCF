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

namespace MessageManager
{

    [ServiceContract(Name = "MessageManagerServiceContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IMessageManagerService
    {
        [OperationContract]
        string SendMessage(string msg);
    }

    public class MessageManagerService : IMessageManagerService
    {

        #region IMessageManagerService Members

        string IMessageManagerService.SendMessage(string msg)
        {
            return string.Format("Message received at {0}: {1}", DateTime.Now, msg);
        }

        #endregion
    }



}
