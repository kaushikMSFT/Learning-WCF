// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
   
using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            using (localhost.SecureServiceContractClient proxy = new Client.localhost.SecureServiceContractClient())
            {
                
                proxy.ClientCredentials.UserName.UserName = "Admin";
                proxy.ClientCredentials.UserName.Password = "p@ssw0rd";

                string s = proxy.AdminOperation();
                Console.WriteLine(s);

                s = proxy.UserOperation();
                Console.WriteLine(s);

                s = proxy.GuestOperation();
                Console.WriteLine(s);

            }
            Console.ReadLine();

        }
    }
}
