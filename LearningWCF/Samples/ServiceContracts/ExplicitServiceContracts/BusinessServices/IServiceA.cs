// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.ServiceModel;

namespace BusinessServices
{

    [ServiceContract(Name="ServiceAContract", Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IServiceA
    {
        [OperationContract(Name="Operation1", Action="http://www.thatindigogirl.com/samples/2006/06/ServiceAContract/Operation1", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/ServiceAContract/Operation1Response")]
        string Operation1();

        [OperationContract(Name="Operation2", Action="http://www.thatindigogirl.com/samples/2006/06/ServiceAContract/Operation2", ReplyAction="http://www.thatindigogirl.com/samples/2006/06/ServiceAContract/Operation2Response")]
        string Operation2();
    }

}

