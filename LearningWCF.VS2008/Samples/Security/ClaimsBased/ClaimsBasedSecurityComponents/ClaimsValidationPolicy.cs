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
using System.Security;


namespace ClaimsBasedSecurityComponents
{
    public class ClaimsValidationPolicy : IAuthorizationPolicy
    {

        public ClaimsValidationPolicy()
        {
        }

        #region IAuthorizationPolicy Members

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {

            if (evaluationContext.Properties.ContainsKey("Principal"))
            {
                IClaimsPrincipal principal = evaluationContext.Properties["Principal"] as IClaimsPrincipal;
                if (principal == null)
                    throw new SecurityException("Access is denied. IClaimsPrincipal type must be provided.");

                this.AuthorizeCall(principal);
                return true;
            }
            else
                return false;

        }

        private void AuthorizeCall(IClaimsPrincipal principal)
        {
            string action = OperationContext.Current.RequestContext.RequestMessage.Headers.Action;

            ClaimsPrincipalPermission p = null;

            switch (action)
            {
                case "http://www.thatindigogirl.com/samples/2006/06/ICrudService/CreateSomething":
                    p = new ClaimsPrincipalPermission(true, new DefaultClaimSet(ClaimsAuthorizationPolicy.CreateIssuerClaimSet(), ClaimsAuthorizationPolicy.CreateApplicationCreateClaim()));
                    p.CheckClaims(principal);
                    break;
                case "http://www.thatindigogirl.com/samples/2006/06/ICrudService/ReadSomething":
                    p = new ClaimsPrincipalPermission(true, new DefaultClaimSet(ClaimsAuthorizationPolicy.CreateIssuerClaimSet(), ClaimsAuthorizationPolicy.CreateApplicationReadClaim()));
                    p.CheckClaims(principal);
                    break;
                case "http://www.thatindigogirl.com/samples/2006/06/ICrudService/UpdateSomething":
                    p = new ClaimsPrincipalPermission(true, new DefaultClaimSet(ClaimsAuthorizationPolicy.CreateIssuerClaimSet(), ClaimsAuthorizationPolicy.CreateApplicationUpdateClaim()));
                    p.CheckClaims(principal);
                    break;
                case "http://www.thatindigogirl.com/samples/2006/06/ICrudService/DeleteSomething":
                    p = new ClaimsPrincipalPermission(true, new DefaultClaimSet(ClaimsAuthorizationPolicy.CreateIssuerClaimSet(), ClaimsAuthorizationPolicy.CreateApplicationDeleteClaim()));
                    p.CheckClaims(principal);
                    break;
            }

        }

        public ClaimSet Issuer
        {
            get { return null; }
        }

        #endregion

        #region IAuthorizationComponent Members

        public string Id
        {
            get
            {
                return null;
            }
        }

        #endregion

    }
}
