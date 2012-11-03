// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Policy;
using System.IdentityModel.Claims;
using System.Security.Principal;
using System.ServiceModel;
using System.Threading;
using System.Web.Security;


namespace ClaimsBasedSecurityComponents
{
    public partial class SAMLClaimsAuthorizationPolicy : ClaimsAuthorizationPolicy
    {

        public SAMLClaimsAuthorizationPolicy(): base()
        {
        }

        public override bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            
            ClaimSet principalClaimSet = null;

            foreach (ClaimSet cs in evaluationContext.ClaimSets)
            {
                if (cs.Issuer.ContainsClaim(Claim.CreateDnsClaim("IPKey")))
                {
                    principalClaimSet = cs;        
                }
            }

            if (principalClaimSet != null)
            {
                ClaimsPrincipal newPrincipal = new ClaimsPrincipal(new GenericIdentity("IPKey"), principalClaimSet);
                evaluationContext.Properties["Principal"] = newPrincipal;
                return true;
            }
            else 
                return false;

        }


    }
}
