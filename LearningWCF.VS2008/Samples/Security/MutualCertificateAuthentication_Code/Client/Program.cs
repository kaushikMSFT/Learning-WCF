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
            using (localhost.HelloIndigoServiceClient proxy = new Client.localhost.HelloIndigoServiceClient())
            {
                proxy.ClientCredentials.ClientCertificate.SetCertificate(System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser, System.Security.Cryptography.X509Certificates.StoreName.My, System.Security.Cryptography.X509Certificates.X509FindType.FindBySubjectName, "SubjectKey");
                string s = proxy.HelloIndigo("Hello!");
                Console.WriteLine(s);
                Console.ReadLine();
            }


        }
    }
}
