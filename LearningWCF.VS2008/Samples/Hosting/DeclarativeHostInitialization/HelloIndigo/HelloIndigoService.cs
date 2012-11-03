// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.ServiceModel;
using System.Net.Security;

namespace HelloIndigo
{

    [ServiceContract(Name="HelloIndigoContract", Namespace="http://www.thatindigogirl.com/samples/2006/06")]
    public interface IHelloIndigoService
    {
        [OperationContract]
        string HelloIndigo(string inputString);
    }

    public class HelloIndigoService : IHelloIndigoService
    {
        #region IHelloIndigoService Members

        public string HelloIndigo(string inputString)
        {
            Console.WriteLine("HelloIndigoService.HelloIndigo()");
            return inputString;
        }

        #endregion
    }

}

