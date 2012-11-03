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

namespace GigManager
{
    [ServiceContract(Name = "GigManagerServiceContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06", SessionMode = SessionMode.Required)]
    public interface IGigManagerService
    {
        [OperationContract(Name="SaveGig", Action="http://www.thatindigogirl.com/samples/2006/06/GigManagerServiceContract/SaveGig", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/GigManagerServiceContract/SaveGigResponse")]
        void SaveGig(LinkItem item);

        [OperationContract(Name="GetGig", Action="http://www.thatindigogirl.com/samples/2006/06/GigManagerServiceContract/GetGig", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/GigManagerServiceContract/GetGigResponse")]
        LinkItem GetGig();
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class GigManagerService : IGigManagerService
    {

        private LinkItem m_linkItem;

        #region IGigManager Members

        public void SaveGig(LinkItem item)
        {
            m_linkItem = item;
        }

        public LinkItem GetGig()
        {
            return m_linkItem;
        }

        #endregion
    }
}
