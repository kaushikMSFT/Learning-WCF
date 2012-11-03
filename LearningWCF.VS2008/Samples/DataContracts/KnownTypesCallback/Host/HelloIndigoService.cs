// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
   
using System;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Host
{

    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IHelloIndigoServiceCallback
    {
        [OperationContract(IsOneWay=true)]
        void Event(EventArgs args);
    }

    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06", CallbackContract=typeof(IHelloIndigoServiceCallback))]
    public interface IHelloIndigoService
    {
        [OperationContract(IsOneWay = true)]
        void HelloIndigo();
    }

    [DataContract(Namespace = "http://schemas.thatindigogirl.com/samples/2006/06")]
    public class CustomEventArgs : EventArgs
    {
        [DataMember]
        public string ArgValue;
    }

    public class HelloIndigoService : IHelloIndigoService
    {
        #region IHelloIndigoService Members

        public void HelloIndigo()
        {

            Console.WriteLine("Invoking callback");

            CustomEventArgs args = new CustomEventArgs();
            args.ArgValue = "Callback argument";

            IHelloIndigoServiceCallback callback = OperationContext.Current.GetCallbackChannel<IHelloIndigoServiceCallback>();
            callback.Event(args);
        }

        #endregion
    }

    internal class MyServiceHost
    {
        internal static ServiceHost myServiceHost = null;

        internal static void StartService()
        {
            // Instantiate new ServiceHost 
            myServiceHost = new ServiceHost(typeof(HelloIndigoService));
            myServiceHost.Open();
        }

        internal static void StopService()
        {
            // Call StopService from your shutdown logic (i.e. dispose method)
            if (myServiceHost.State != CommunicationState.Closed)
                myServiceHost.Close();
        }
    }
}

