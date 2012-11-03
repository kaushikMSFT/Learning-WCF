// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.ServiceModel;
using System.Security;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;

namespace HelloIndigo
{

    [ServiceContract(Namespace="http://www.thatindigogirl.com/samples/2006/06")]
    public interface IHelloIndigoService
    {
        [OperationContract]
        string HelloIndigo(string s);
    }

    public class HelloIndigoService : IHelloIndigoService
    {
        #region IHelloIndigoService Members

        public string HelloIndigo(string s)
        {
            AuthorizationContext authContext =
            ServiceSecurityContext.Current.AuthorizationContext;

            X509CertificateClaimSet certClaims = null;
            foreach (ClaimSet c in authContext.ClaimSets)
            {
                certClaims = c as X509CertificateClaimSet;
                if (certClaims != null)
                    break;
            }
            if (certClaims == null)
                throw new SecurityException("Access is denied. X509CertificateClaimSet is required.");

            if (!certClaims.ContainsClaim(
            Claim.CreateDnsClaim(s)))
                throw new SecurityException("Access is denied.");
            
            return string.Format("Checked certificate against DNS claim for '{0}' at {1}", s, DateTime.Now);
        }

        #endregion
    }

    
}

