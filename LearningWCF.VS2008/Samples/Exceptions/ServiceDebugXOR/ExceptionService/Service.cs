// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
   
using System;
using System.ServiceModel;

namespace ExceptionService
{

    [ServiceContract()]
    public interface IService
    {
        [OperationContract]
        void ThrowException();

        [OperationContract(IsOneWay=true)]
        void ThrowExceptionOneWay();

    }

    [ServiceBehavior(IncludeExceptionDetailInFaults=false)]
    public class Service : IService
    {
        #region IService Members

        public void ThrowException()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ThrowExceptionOneWay()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }


}

