// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
   
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            localhost.FaultExceptionServiceClient proxy = new Client.localhost.FaultExceptionServiceClient();

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Calling proxy.ThrowSimpleFault()");
                Console.WriteLine("");
                Console.ResetColor();

                proxy.ThrowSimpleFault();

            }
            catch (FaultException fe)
            {

                Console.WriteLine(fe.GetType().ToString());
                Console.WriteLine("ERROR: {0}", fe.Message);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.GetType().ToString());
                Console.WriteLine("ERROR: {0}", ex.Message);
           }

           Console.WriteLine();

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Calling proxy.ThrowMessageFault()");
                Console.ResetColor();

                proxy.ThrowMessageFault();

            }
            catch (FaultException fe)
            {

                Console.WriteLine(fe.GetType().ToString());
                Console.WriteLine("ERROR: {0}", fe.Message);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.GetType().ToString());
                Console.WriteLine("ERROR:  {0}", ex.Message);
            }

            Console.WriteLine();

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Calling proxy.ThrowFaultException()");
                Console.ResetColor();

                proxy.ThrowFaultException();
            }
            catch (FaultException fe)
            {

                Console.WriteLine(fe.GetType().ToString());
                Console.WriteLine("ERROR: {0}", fe.Message);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.GetType().ToString());
                Console.WriteLine("ERROR:  {0}", ex.Message);
            }


            proxy.Close();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press <ENTER> to terminate Client.");
            Console.ReadLine();
        }
    }
}
