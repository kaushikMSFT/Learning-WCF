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
    [XmlSerializerFormat]
    public interface IGigManagerService
    {
        [OperationContract]
        void SaveGig(LinkItemSerializer item);

        [OperationContract]
        LinkItemSerializer GetGig();
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class GigManagerService : IGigManagerService
    {

        private LinkItem m_linkItem;

        #region IGigManager Members

        public void SaveGig(LinkItemSerializer item)
        {
            m_linkItem = item.LinkItem;
        }

        public LinkItemSerializer GetGig()
        {
            return new LinkItemSerializer(m_linkItem);
        }

        #endregion
    }
}
