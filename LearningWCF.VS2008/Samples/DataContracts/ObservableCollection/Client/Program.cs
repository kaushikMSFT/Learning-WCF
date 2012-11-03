// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using Client.localhost;
using System.Collections;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (localhost.HelloIndigoServiceClient proxy = new Client.localhost.HelloIndigoServiceClient())
            {

                ThingCollection things = new ThingCollection();
                Thing thing1 = new Thing();
                thing1.Name = "Thing1";
                thing1.Description = "I am Thing1";
                Thing thing2 = new Thing();
                thing2.Name = "Thing2";
                thing2.Description = "I am Thing2";

                things.Add(thing1);
                things.Add(thing2);
                proxy.SaveThings(things);

                things = proxy.GetThings();

            }

            Console.WriteLine("Press <ENTER> to terminate Client.");
            Console.ReadLine();
        }
    }
}
