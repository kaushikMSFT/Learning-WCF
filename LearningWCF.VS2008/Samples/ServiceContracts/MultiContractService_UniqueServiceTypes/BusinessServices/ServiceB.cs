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

    public class ServiceB:  IServiceB
    {
        #region IServiceB Members

        string IServiceB.Operation3()
        {
            return "IServiceB.Operation3() invoked.";
        }

        #endregion

        
    }

}
