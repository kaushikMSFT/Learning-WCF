// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.ServiceModel;

namespace Host
{


    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IHelloIndigoService
    {
        [OperationContract]
        void SaveThings(ThingCollection collection);

        [OperationContract]
        ThingCollection GetThings();

    }

    public class HelloIndigoService : IHelloIndigoService
    {

        ThingCollection m_things;

        #region IHelloIndigoService Members

        public void SaveThings(ThingCollection collection)
        {
            Console.WriteLine("Saving {0} things.", collection.Count);
            m_things = collection;
        }

        public ThingCollection GetThings()
        {
            Console.WriteLine("Returning {0} things.", m_things.Count);
            return m_things;
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

