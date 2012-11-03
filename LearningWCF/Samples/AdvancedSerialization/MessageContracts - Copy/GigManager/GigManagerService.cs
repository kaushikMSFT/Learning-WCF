// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using ContentTypes;
using System.ServiceModel.Channels;

namespace GigManager
{
    [ServiceContract(Name = "GigManagerServiceContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06", SessionMode = SessionMode.Required)]
    public interface IGigManagerService
    {
        [OperationContract]
        SaveGigResponse SaveGig(SaveGigRequest requestMessage);

        [OperationContract]
        GetGigResponse GetGig(Message requestMessage);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ValidateMustUnderstand=false)]
    public class GigManagerService : IGigManagerService
    {

        private LinkItem m_linkItem;

        #region IGigManager Members

        public SaveGigResponse SaveGig(SaveGigRequest requestMessage)
        {
            m_linkItem = requestMessage.Item;
            return new SaveGigResponse();
        }

        public GetGigResponse GetGig(Message requestMessage)
        {
            string ns = null;
            foreach (MessageHeader h in requestMessage.Headers)
            {
                if (h.Name == "LicenseKey")
                    ns = h.Namespace;
            }

            int index = requestMessage.Headers.FindHeader("LicenseKey", "http://www.thatindigogirl.com/samples/2006/06");
            MessageHeaderInfo header = requestMessage.Headers[index];
            


//            if (requestMessage.LicenseKey != "XXX") 
  //              throw new FaultException("Invalid license key.");

            return new GetGigResponse(m_linkItem);
        }

        #endregion
    }
}
