// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.ServiceModel;
using BusinessServiceContracts;

namespace BusinessServices
{

    public class ServiceA2 : IServiceA2
    {

        public string Operation1()
        {
            return "IServiceA2.Operation1() invoked.";
        }

        public string Operation2()
        {
            return "IServiceA2.Operation2() invoked.";
        }

        public string Operation3()
        {
            return "IServiceA2.Operation3() invoked.";
        }

    }

}

