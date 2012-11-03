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

namespace GigEntry
{
    [ServiceContract(Name = "GigManagerServiceContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IGigManagerService
    {
        [OperationContract]
        void SaveGig(Message requestMessage);

        [OperationContract]
        Message GetGig(Message requestMessage);
    }
}
