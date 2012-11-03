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


namespace Host
{
	class Program
	{
		static void Main(string[] args)
		{

            ServiceHost hostA = null;
            ServiceHost hostA2 = null;


            try
            {
                hostA = new ServiceHost(typeof(BusinessServices.ServiceA));
                hostA2 = new ServiceHost(typeof(BusinessServices.ServiceA2));

                hostA.Open();
                hostA2.Open();

                Console.WriteLine();
				Console.WriteLine("Press <ENTER> to terminate Host");
				Console.ReadLine();

            }
            finally
            {
                hostA.Close();
                hostA2.Close();
            }
 

		}
	}
}
