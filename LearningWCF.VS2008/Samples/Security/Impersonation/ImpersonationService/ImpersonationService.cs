// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
   
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Security.Permissions;

namespace ImpersonationService
{
    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IImpersonationService
    {
        [OperationContract]
        void ImpersonationNotAllowed();
        [OperationContract]
        void ImpersonationAllowed();
        [OperationContract]
        void ImpersonationRequired();
    }
   
    public class ImpersonationService : IImpersonationService
    {
        [OperationBehavior(Impersonation=ImpersonationOption.NotAllowed)]
        public void ImpersonationNotAllowed()
        {
            Console.WriteLine("ImpersonationNowAllowed() called with credentials for {0}.", ServiceSecurityContext.Current.PrimaryIdentity.Name);
            Console.WriteLine("Service running with identity {0}", WindowsIdentity.GetCurrent().Name);
            using (WindowsImpersonationContext ctx = ServiceSecurityContext.Current.WindowsIdentity.Impersonate())
            Console.WriteLine("After manual impersonation: {0}.", WindowsIdentity.GetCurrent().Name);
            Console.WriteLine();

        }
        
        [OperationBehavior(Impersonation=ImpersonationOption.Allowed)]
        public void ImpersonationAllowed()
        {
            Console.WriteLine("ImpersonationAllowed() called with credentials for {0}.", ServiceSecurityContext.Current.PrimaryIdentity.Name);
            Console.WriteLine("Service running with identity {0}", WindowsIdentity.GetCurrent().Name);
            using (WindowsImpersonationContext ctx = ServiceSecurityContext.Current.WindowsIdentity.Impersonate())
            Console.WriteLine("After manual impersonation: {0}.", WindowsIdentity.GetCurrent().Name);


            Console.WriteLine();

        }
        
        [OperationBehavior(Impersonation=ImpersonationOption.Required)]
        public void ImpersonationRequired()
        {
            Console.WriteLine("ImpersonationRequired() called with credentials for {0}.", ServiceSecurityContext.Current.PrimaryIdentity.Name);
            Console.WriteLine("Service running with identity {0}", WindowsIdentity.GetCurrent().Name);
            Console.WriteLine();

        }
    }

}
