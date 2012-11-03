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

    public class InternalServiceA : IInternalServiceA
    {


        #region IInternalServiceA Members

        string IInternalServiceA.Operation1()
        {
            return "IInternalServiceA.Operation1() invoked.";
        }

        string IInternalServiceA.Operation2()
        {
            return "IInternalServiceA.Operation2() invoked.";

        }

        string IInternalServiceA.Operation3()
        {
            return "IInternalServiceA.Operation3() invoked.";

        }

        #endregion



    }

}

