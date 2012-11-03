// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;

namespace FaultExceptions
{

    [ServiceContract()]
    public interface IFaultExceptionService
    {
        [OperationContract]
        [FaultContract(typeof(InvalidOperationException))]
        void ThrowSimpleFault();

        [OperationContract]
        [FaultContract(typeof(InvalidOperationException))]
        void ThrowMessageFault();

        [OperationContract()]
        [FaultContract(typeof(InvalidOperationException))]
        void ThrowFaultException();

    }

    public class FaultExceptionService : IFaultExceptionService
    {


        #region IService Members

        public void ThrowSimpleFault()
        {

            throw new FaultException("An invalid operation has occurred.");
        }

        public void ThrowMessageFault()
        {
            InvalidOperationException error = new InvalidOperationException("An invalid operation has occurred.");

            MessageFault mfault = MessageFault.CreateFault(new FaultCode("Server", new FaultCode(String.Format("Server.{0}", error.GetType().Name))), new FaultReason(error.Message), error);

            FaultException fe = FaultException.CreateFault(mfault, typeof(InvalidOperationException));

            throw fe;
        }

        public void ThrowFaultException()
        {
            FaultException<InvalidOperationException> fe = new FaultException<InvalidOperationException>(new InvalidOperationException("An invalid operation has occured."), "Invalid operation.", new FaultCode("Server", new FaultCode(String.Format("Server.{0}", typeof(NotImplementedException)))));
            throw fe;
        }

        #endregion
    }

    
}

