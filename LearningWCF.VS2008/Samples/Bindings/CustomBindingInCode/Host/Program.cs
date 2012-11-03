// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HelloIndigo.HelloIndigoService), new Uri("http://localhost:8000")))
            {

                BindingElementCollection elements = new BindingElementCollection();
                elements.Add(new TransactionFlowBindingElement(TransactionProtocol.WSAtomicTransactionOctober2004));
                elements.Add(new ReliableSessionBindingElement(true));
                    elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, Encoding.UTF8));
                elements.Add(new HttpTransportBindingElement());

                CustomBinding binding = new CustomBinding(elements);

                host.AddServiceEndpoint(typeof(HelloIndigo.IHelloIndigoService), binding, "HelloIndigoService");

                host.Open();


                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate the host application");
                Console.ReadLine();
   
            }
        }
    }
}
