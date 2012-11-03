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
using System.IdentityModel.Policy;

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

       string ICrudService.CreateSomething()
        {

           CheckClaims(ClaimsAuthorizationPolicy.ClaimTypes.Create, ClaimsAuthorizationPolicy.Resources.Application);

            return String.Format("CreateSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }


        string ICrudService.ReadSomething()
        {
           CheckClaims(ClaimsAuthorizationPolicy.ClaimTypes.Read, ClaimsAuthorizationPolicy.Resources.Application);

            return String.Format("ReadSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        string ICrudService.UpdateSomething()
        {
           CheckClaims(ClaimsAuthorizationPolicy.ClaimTypes.Update, ClaimsAuthorizationPolicy.Resources.Application);

            return String.Format("UpdateSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        string ICrudService.DeleteSomething()
        {
           CheckClaims(ClaimsAuthorizationPolicy.ClaimTypes.Delete, ClaimsAuthorizationPolicy.Resources.Application);

            return String.Format("DeleteSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }


        private void CheckClaims(string claimType, string resource)
        {
            IClaimsPrincipal claimsPrincipal = Thread.CurrentPrincipal as IClaimsPrincipal;

            if (claimsPrincipal == null)
                throw new SecurityException("Access is denied. Security principal should be a IClaimsPrincipal type.");
           
            Claim issuerName = Claim.CreateNameClaim(ClaimsAuthorizationPolicy.IssuerName);
           List<Claim> issuerClaims = new List<Claim>();
           issuerClaims.Add(issuerName);
        
        List<Claim> requiredClaims = new List<Claim>();
        requiredClaims.Add(new Claim(claimType, resource, Rights.PossessProperty));
            
            DefaultClaimSet claimSet = new DefaultClaimSet(new DefaultClaimSet(issuerClaims), requiredClaims);

           if (!claimsPrincipal.HasRequiredClaims(claimSet))
                throw new SecurityException("Access is denied. Security principal does not satisfy required claims.");

        }

    }
}

