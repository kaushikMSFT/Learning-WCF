// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.ServiceModel;
using System.Security.Permissions;
using System.Security.Principal;
using System.IdentityModel.Claims;
using System.Collections.Generic;
using System.Security;
using System.Threading;
using ClaimsBasedSecurityComponents;

namespace ClaimsBasedServices
{


    [ServiceContract(Namespace="http://www.thatindigogirl.com/samples/2006/06")]
    public interface ICrudService
    {
        
        [OperationContract]
        string CreateSomething();

        [OperationContract]
        string ReadSomething();

        [OperationContract]
        string UpdateSomething();

        [OperationContract]
        string DeleteSomething();
    }

    public class CrudService: ICrudService
    {

        [ClaimsPrincipalPermissionAttribute(SecurityAction.Demand,RequiredClaimType = ClaimsAuthorizationPolicy.ClaimTypes.Create, Resource=ClaimsAuthorizationPolicy.Resources.Application)]
        string ICrudService.CreateSomething()
        {
            return String.Format("CreateSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        [ClaimsPrincipalPermissionAttribute(SecurityAction.Demand, RequiredClaimType = ClaimsAuthorizationPolicy.ClaimTypes.Read, Resource = ClaimsAuthorizationPolicy.Resources.Application)]
        string ICrudService.ReadSomething()
        {

            return String.Format("ReadSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        [ClaimsPrincipalPermissionAttribute(SecurityAction.Demand,RequiredClaimType = ClaimsAuthorizationPolicy.ClaimTypes.Update, Resource=ClaimsAuthorizationPolicy.Resources.Application)]
        string ICrudService.UpdateSomething()
        {
            return String.Format("UpdateSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        [ClaimsPrincipalPermissionAttribute(SecurityAction.Demand,RequiredClaimType = ClaimsAuthorizationPolicy.ClaimTypes.Delete, Resource=ClaimsAuthorizationPolicy.Resources.Application)]
        string ICrudService.DeleteSomething()
        {
            return String.Format("DeleteSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

    }

}

