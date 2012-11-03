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
    public partial class ClaimsAuthorizationPolicy : IAuthorizationPolicy
    {

        protected Guid m_id;
        protected ClaimSet m_issuer;

        public ClaimsAuthorizationPolicy()
        {
            m_id = Guid.NewGuid();
            m_issuer = ClaimsAuthorizationPolicy.CreateIssuerClaimSet();
        }

        #region IAuthorizationPolicy Members

        public virtual bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {

            if (evaluationContext.Properties.ContainsKey("Identities"))
            {
                List<IIdentity> identities = evaluationContext.Properties["Identities"] as List<IIdentity>;
                IIdentity identity = identities[0];

                ClaimSet claims = MapClaims(identity);

                ClaimsPrincipal newPrincipal = new ClaimsPrincipal(identity, claims);
                evaluationContext.Properties["Principal"] = newPrincipal;
                evaluationContext.AddClaimSet(this, claims);
                return true;
            }
            else
                return false;

        }

        protected virtual ClaimSet MapClaims(IIdentity identity)
        {

            List<Claim> listClaims = new List<Claim>();

            if (!identity.IsAuthenticated)
                throw new NotSupportedException("User not authenticated.");

            if (Roles.IsUserInRole(identity.Name, "Administrators"))
            {
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Create, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Delete, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Read, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Update, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
            }
            else if (Roles.IsUserInRole(identity.Name, "Users"))
            {
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Read, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Update, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
            }
            else
            {
                listClaims.Add(new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Read, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
            }

            
            return new DefaultClaimSet(this.m_issuer, listClaims); 
        }

        public virtual ClaimSet Issuer
        {
            get { return m_issuer; }
        }

        #endregion

        #region IAuthorizationComponent Members

        public virtual string Id
        {
            get
            {
                return m_id.ToString();
            }
        }

        #endregion

    }
}
