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

    public class InternalServiceB:  IServiceB, IAdmin
    {
        #region IServiceB Members

        string IServiceB.Operation3()
        {
            return "IServiceB.Operation3() invoked.";
        }

        #endregion

        #region IAdmin Members

        string IAdmin.AdminOperation1()
        {
            return "IAdmin.AdminOperation1 invoked.";
        }

        string IAdmin.AdminOperation2()
        {
            return "IAdmin.AdminOperation2 invoked.";
        }

        #endregion
    }

}
