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
    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IHelloIndigoService
    {
        [OperationContract(ProtectionLevel=ProtectionLevel.Sign)]
        string HelloIndigo(string inputString);
    }

    public class HelloIndigoService : IHelloIndigoService
    {
        #region IHelloIndigoService Members

        public string HelloIndigo(string inputString)
        {
            
            return inputString;
        }

        #endregion
    }

}

