// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            BindingElementCollection elements = new BindingElementCollection();
            elements.Add(new TransactionFlowBindingElement(TransactionProtocol.WSAtomicTransactionOctober2004));
            elements.Add(new ReliableSessionBindingElement(true));
            elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, Encoding.UTF8));
            elements.Add(new HttpTransportBindingElement());

            CustomBinding binding = new CustomBinding(elements);

            ChannelFactory<IHelloIndigoService> factory = new ChannelFactory<IHelloIndigoService>(binding, "http://localhost:8000/HelloIndigoService");
            IHelloIndigoService proxy = null;

            try
            {
                proxy = factory.CreateChannel();
                {
                    string s = proxy.HelloIndigo("hello");
                    Console.WriteLine(s);
                    Console.ReadLine();
                }

            }
            finally
            {
                
                ICommunicationObject obj = proxy as ICommunicationObject;
                if (obj!=null)
                    obj.Close();
            }
        }
    }
}
