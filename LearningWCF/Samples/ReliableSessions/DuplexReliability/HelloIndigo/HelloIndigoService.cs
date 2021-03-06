// � 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.ServiceModel;
using System.Threading;

namespace HelloIndigo
{

    [ServiceContract(Namespace="http://www.thatindigogirl.com/samples/2006/06", CallbackContract=typeof(IHelloIndigoServiceCallback))]
    public interface IHelloIndigoService
    {
        [OperationContract(IsOneWay=true)]
        void HelloIndigo(string message);

        [OperationContract]
        void HelloIndigo2(string message);

    }

    public interface IHelloIndigoServiceCallback
    {
        [OperationContract(IsOneWay=true)]
        void HelloIndigoCallback(string message);

        [OperationContract]
        void HelloIndigoCallback2(string message);
        
   }

    [DeliveryRequirements(RequireOrderedDelivery=true)]
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Reentrant)]
    public class HelloIndigoService : IHelloIndigoService
    {
        #region IHelloIndigoService Members

        public void HelloIndigo(string message)
        {
            Console.WriteLine("OperationContext SessionId = {0}", OperationContext.Current.SessionId);

            IHelloIndigoServiceCallback callback = OperationContext.Current.GetCallbackChannel<IHelloIndigoServiceCallback>();
            IContextChannel ctx = callback as IContextChannel;
            Console.WriteLine("CallbackChannel SessionId = {0}", ctx.SessionId);
            callback.HelloIndigoCallback(message);

        }

        public void HelloIndigo2(string message)
        {
            IHelloIndigoServiceCallback callback = OperationContext.Current.GetCallbackChannel<IHelloIndigoServiceCallback>();
            callback.HelloIndigoCallback2(message);

        }
        #endregion
    }

}

