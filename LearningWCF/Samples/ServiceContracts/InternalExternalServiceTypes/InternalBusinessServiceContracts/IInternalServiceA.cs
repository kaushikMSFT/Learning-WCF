// � 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.ServiceModel;
using BusinessServiceContracts;

namespace BusinessServiceContracts
{
    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IInternalServiceA
    {
        [OperationContract]
        string Operation1();
        [OperationContract]
        string Operation2();
        [OperationContract]
        string Operation3();
    }


}

