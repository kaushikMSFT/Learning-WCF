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
         using (ServiceHost host = new ServiceHost(typeof(Counters.CountersService)))
         {

             NetTcpBinding netTcpTx = new NetTcpBinding();
             netTcpTx.TransactionFlow = true;
             netTcpTx.TransactionProtocol = TransactionProtocol.WSAtomicTransactionOctober2004;

             NetTcpBinding netTcpTxRM = new NetTcpBinding(SecurityMode.Transport, true);
             netTcpTxRM.TransactionFlow = true;
             netTcpTxRM.TransactionProtocol = TransactionProtocol.WSAtomicTransactionOctober2004;
             

             NetNamedPipeBinding netPipeTx = new NetNamedPipeBinding();
             netPipeTx.TransactionFlow = true;
             netPipeTx.TransactionProtocol = TransactionProtocol.WSAtomicTransactionOctober2004;

             WSHttpBinding wsHttpTx = new WSHttpBinding();
             wsHttpTx.TransactionFlow = true;

             WSHttpBinding wsHttpTxRM = new WSHttpBinding(SecurityMode.Message, true);
             wsHttpTxRM.TransactionFlow = true;

             CustomBinding wsHttpCustomTx = new CustomBinding();
             wsHttpCustomTx.Elements.Add(new TransactionFlowBindingElement(TransactionProtocol.WSAtomicTransactionOctober2004));
             wsHttpCustomTx.Elements.Add(new TextMessageEncodingBindingElement());
             wsHttpCustomTx.Elements.Add(new HttpTransportBindingElement());

             host.AddServiceEndpoint(typeof(Counters.ICountersService), netTcpTx, "netTcpTx");
             host.AddServiceEndpoint(typeof(Counters.ICountersService), netTcpTxRM, "netTcpTxRM");
             host.AddServiceEndpoint(typeof(Counters.ICountersService), netPipeTx, "netPipeTx");
             host.AddServiceEndpoint(typeof(Counters.ICountersService), wsHttpTx, "wsHttpTx");
             host.AddServiceEndpoint(typeof(Counters.ICountersService), wsHttpTxRM, "wsHttpTxRM");
             host.AddServiceEndpoint(typeof(Counters.ICountersService), wsHttpCustomTx, "wsHttpCustomTx");

            host.Open();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate the host application");
            Console.ReadLine();
  
         }
      }
   }
}
