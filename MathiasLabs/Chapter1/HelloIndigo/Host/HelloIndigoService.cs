using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Host
{
    // NOTE: If you change the class name "HelloIndigoservice" here, you must also update the reference to "HelloIndigoservice" in App.config.
    public class HelloIndigoService : IHelloIndigoService
    {
        public string HelloIndigo()
        {
            return "Hello Indigo";
        }
    }
}
