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

            localhost.ServiceClient proxy = new localhost.ServiceClient();

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Calling proxy.ThrowException()");
                Console.WriteLine("");
                Console.ResetColor();

                proxy.ThrowException();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.GetType().ToString());
                Console.WriteLine("ERROR: {0}", ex.Message);
           }

           Console.WriteLine();
           Console.WriteLine("Proxy state after exception: {0}", proxy.State);
           Console.WriteLine();

            if (proxy.State == CommunicationState.Faulted)
                proxy = new localhost.ServiceClient();

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Calling proxy.ThrowExceptionOneWay()");
                Console.ResetColor();

                proxy.ThrowExceptionOneWay();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.GetType().ToString());
                Console.WriteLine("ERROR:  {0}", ex.Message);
            }


            Console.WriteLine();
            Console.WriteLine("Proxy state after exception: {0}", proxy.State);
            Console.WriteLine();


            try
            {
                proxy.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.GetType().ToString());
                Console.WriteLine("ERROR:  {0}", ex.Message);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press <ENTER> to terminate Client.");
            Console.ReadLine();
        }
    }
}
