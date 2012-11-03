// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using BusinessServiceContracts;

namespace BusinessServiceContracts
{
    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IInternalServiceB
    {
        [OperationContract]
        string Operation4();
        [OperationContract]
        string Operation5();
        [OperationContract]
        string Operation6();
    }

}
