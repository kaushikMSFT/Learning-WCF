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

            AuthorizationContext authContext = ServiceSecurityContext.Current.AuthorizationContext;
  
            ClaimSet issuerClaimSet = null;
            foreach (ClaimSet cs in authContext.ClaimSets)
            {
                Claim issuerClaim = Claim.CreateNameClaim("http://www.thatindigogirl.com/samples/2006/06/issuer");
                
                if (cs.Issuer.ContainsClaim(issuerClaim))
                    issuerClaimSet=cs;
            }
           
                if (issuerClaimSet==null)
                    throw new SecurityException("Access is denied. No claims were provided from the expected issuer.");

                Claim c = new Claim("http://schemas.thatindigogirl.com/samples/2006/06/identity/claims/create","http://schemas.thatindigogirl.com/samples/2006/06/identity/resources/application", Rights.PossessProperty);

                if (!issuerClaimSet.ContainsClaim(c))
                    throw new SecurityException("Access is denied. Required claims not satisfied.");

                return String.Format("CreateSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        string ICrudService.ReadSomething()
        {
            AuthorizationContext authContext = ServiceSecurityContext.Current.AuthorizationContext;
  
            ClaimSet issuerClaimSet = null;
            foreach (ClaimSet cs in authContext.ClaimSets)
            {
                Claim issuerClaim = Claim.CreateNameClaim("http://www.thatindigogirl.com/samples/2006/06/issuer");
                
                if (cs.Issuer.ContainsClaim(issuerClaim))
                    issuerClaimSet=cs;
            }
           
                if (issuerClaimSet==null)
                    throw new SecurityException("Access is denied. No claims were provided from the expected issuer.");

                Claim c = new Claim("http://schemas.thatindigogirl.com/samples/2006/06/identity/claims/read","http://schemas.thatindigogirl.com/samples/2006/06/identity/resources/application", Rights.PossessProperty);

                if (!issuerClaimSet.ContainsClaim(c))
                    throw new SecurityException("Access is denied. Required claims not satisfied.");
            
            return String.Format("ReadSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        string ICrudService.UpdateSomething()
        {
            AuthorizationContext authContext = ServiceSecurityContext.Current.AuthorizationContext;
  
            ClaimSet issuerClaimSet = null;
            foreach (ClaimSet cs in authContext.ClaimSets)
            {
                Claim issuerClaim = Claim.CreateNameClaim("http://www.thatindigogirl.com/samples/2006/06/issuer");
                
                if (cs.Issuer.ContainsClaim(issuerClaim))
                    issuerClaimSet=cs;
            }
           
                if (issuerClaimSet==null)
                    throw new SecurityException("Access is denied. No claims were provided from the expected issuer.");

                Claim c = new Claim("http://schemas.thatindigogirl.com/samples/2006/06/identity/claims/update","http://schemas.thatindigogirl.com/samples/2006/06/identity/resources/application", Rights.PossessProperty);

                if (!issuerClaimSet.ContainsClaim(c))
                    throw new SecurityException("Access is denied. Required claims not satisfied.");

            return String.Format("UpdateSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        string ICrudService.DeleteSomething()
        {
            AuthorizationContext authContext = ServiceSecurityContext.Current.AuthorizationContext;
  
            ClaimSet issuerClaimSet = null;
            foreach (ClaimSet cs in authContext.ClaimSets)
            {
                Claim issuerClaim = Claim.CreateNameClaim("http://www.thatindigogirl.com/samples/2006/06/issuer");
                
                if (cs.Issuer.ContainsClaim(issuerClaim))
                    issuerClaimSet=cs;
            }
           
                if (issuerClaimSet==null)
                    throw new SecurityException("Access is denied. No claims were provided from the expected issuer.");

                Claim c = new Claim("http://schemas.thatindigogirl.com/samples/2006/06/identity/claims/delete","http://schemas.thatindigogirl.com/samples/2006/06/identity/resources/application", Rights.PossessProperty);

                if (!issuerClaimSet.ContainsClaim(c))
                    throw new SecurityException("Access is denied. Required claims not satisfied.");

            return String.Format("DeleteSomething() called by user {0}", System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

    }

}

