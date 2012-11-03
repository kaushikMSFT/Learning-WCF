// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.IdentityModel.Claims;

namespace ClaimsBasedSecurityComponents
{

    public interface IClaimsPrincipal
    {
        ClaimSet Claims { get;}
        ClaimSet Issuer { get;}

        bool HasRequiredClaims(ClaimSet requiredClaims);
    }

    public class ClaimsPrincipal : IClaimsPrincipal, IPrincipal
    {
        private ClaimSet m_claims;
        private IIdentity m_identity;

        public ClaimsPrincipal(IIdentity identity, ClaimSet claims)
        {

            this.m_identity = identity;
            this.m_claims = claims;
        }

        #region IClaimSetPrincipal Members

        ClaimSet IClaimsPrincipal.Issuer
        {
            get { return this.m_claims.Issuer; }
        }

        /// <summary>
        /// Make sure the issuer matches at least one claim.
        /// Make sure that the claims are provided.
        /// </summary>
        /// <param name="requiredClaims"></param>
        /// <returns></returns>
        bool IClaimsPrincipal.HasRequiredClaims(ClaimSet requiredClaims)
        {
            bool hasClaims = true;
            bool issuerMatch = false;

            // check at least one claim matches the issuer
            foreach (Claim c in requiredClaims.Issuer)
            {
                if (this.m_claims.Issuer.ContainsClaim(c))
                {
                    issuerMatch=true;
                    break;
                }
            }

            // check all required claims are present
            if (issuerMatch) 
            {
                foreach (Claim c in requiredClaims)
                {
                    if (!this.m_claims.ContainsClaim(c))
                    {
                        hasClaims = false;
                        break;
                    }
                }
            }

            return issuerMatch && hasClaims;
        }

        ClaimSet IClaimsPrincipal.Claims
        {
            get { return this.m_claims; }
        }

        #endregion

        #region IPrincipal Members

        IIdentity IPrincipal.Identity
        {
            get
            {
                return this.m_identity;
            }
        }

        bool IPrincipal.IsInRole(string role)
        {
            throw new NotSupportedException("ClaimsPrincipal does not implement role-based security checks.");
        }

        #endregion
    }

}
