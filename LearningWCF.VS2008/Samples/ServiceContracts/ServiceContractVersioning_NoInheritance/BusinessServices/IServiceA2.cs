// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.ServiceModel;

namespace BusinessServiceContracts
{

    [ServiceContract(Name="ServiceAContract2", Namespace = "http://www.thatindigogirl.com/samples/2006/08")]
    public interface IServiceA2
    {
        [OperationContract]
        string Operation1();
        [OperationContract]
        string Operation2();
        [OperationContract]
        string Operation3();
    }


}

