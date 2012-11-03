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
using System.ServiceModel.Channels;
using System.Diagnostics;

namespace MessagingIntermediary
{
    [ServiceContract(Name = "IntermediaryServiceContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IIntermediaryService
    {
        [OperationContract(Action = "*", ReplyAction = "*")]
        Message ProcessMessage(Message requestMessage);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AddressFilterMode=AddressFilterMode.Any)]
    public class IntermediaryService : IIntermediaryService
    {

        #region IIntermediaryService Members

        public Message ProcessMessage(Message requestMessage)
        {

            ChannelFactory<IIntermediaryService> factory = new ChannelFactory<IIntermediaryService>("client");
            IIntermediaryService proxy = factory.CreateChannel();
            

            IClientChannel clientChannel = proxy as IClientChannel;
            Console.WriteLine(String.Format("Request received at {0}, to {1}", DateTime.Now, clientChannel.RemoteAddress.Uri.AbsoluteUri));
            
            
            Message responseMessage = proxy.ProcessMessage(requestMessage);

            Console.WriteLine(String.Format("Reply received at {0}", DateTime.Now));
            Console.WriteLine();
            return responseMessage;
        }

        #endregion
    }
}
