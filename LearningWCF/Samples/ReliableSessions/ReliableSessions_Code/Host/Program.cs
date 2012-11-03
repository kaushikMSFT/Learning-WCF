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

namespace Host
{
   class Program
   {
      static void Main(string[] args)
      {
         using (ServiceHost host = new ServiceHost(typeof(Messaging.MessagingService)))
         {

             NetTcpBinding netTcp = new NetTcpBinding();
             netTcp.ReliableSession.Enabled=true;
             netTcp.ReliableSession.InactivityTimeout = new TimeSpan(0, 10, 0);
             netTcp.ReliableSession.Ordered = true;

             WSHttpBinding wsHttp = new WSHttpBinding(SecurityMode.None, true);

             WSHttpBinding wsHttpSecure = new WSHttpBinding(SecurityMode.Message, true);

             CustomBinding netPipeCustom = new CustomBinding(new ReliableSessionBindingElement(), new BinaryMessageEncodingBindingElement(), new NamedPipeTransportBindingElement());
             
            CustomBinding netTcpCustom = new CustomBinding(new ReliableSessionBindingElement(), new BinaryMessageEncodingBindingElement(), new TcpTransportBindingElement());

            CustomBinding wsHttpCustom = new CustomBinding(new ReliableSessionBindingElement(), new TextMessageEncodingBindingElement(), new HttpTransportBindingElement());
             
             host.AddServiceEndpoint(typeof(Messaging.IMessagingService), netTcp, "netTcpRM");
             host.AddServiceEndpoint(typeof(Messaging.IMessagingService), wsHttp, "wsHttpRM");
             host.AddServiceEndpoint(typeof(Messaging.IMessagingService), wsHttpSecure, "wsHttpSecureRM");
             host.AddServiceEndpoint(typeof(Messaging.IMessagingService), netTcpCustom, "netTcpCustomRM");
             host.AddServiceEndpoint(typeof(Messaging.IMessagingService), netPipeCustom, "netPipeCustomRM");
             host.AddServiceEndpoint(typeof(Messaging.IMessagingService), wsHttpCustom, "wsHttpCustomRM");

            host.Open();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate the host application");
            Console.ReadLine();
   
   
         }
      }
   }
}
