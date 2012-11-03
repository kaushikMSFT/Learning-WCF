// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using BusinessServiceContracts;

namespace BusinessServices
{

    public class InternalServiceB:  IInternalServiceB
    {
        

        #region IInternalServiceB Members

        string IInternalServiceB.Operation4()
        {
            return "IInternalServiceB.Operation4() invoked.";
        }

        string IInternalServiceB.Operation5()
        {
            return "IInternalServiceB.Operation5() invoked.";
        }

        string IInternalServiceB.Operation6()
        {
            return "IInternalServiceB.Operation6() invoked.";

        }

        #endregion
    }

}
