using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HelloIndigo.HelloIndigoService),new Uri("http://192.168.1.19:8000/HelloIndigo")))
            {
                host.AddServiceEndpoint(typeof(HelloIndigo.IHelloIndigoService), new BasicHttpBinding(), "HelloIndigoService");
                host.Open();
                Console.WriteLine("Press <ENTER> to terminate the service host");
                Console.ReadLine();
            }
        }
    }
}
