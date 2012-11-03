// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Claims;
using System.Security;

namespace ClaimsBasedSecurityComponents
{
    public partial class ClaimsAuthorizationPolicy 
    {

        protected  static List<string> SupportedClaimTypes = new List<string>();
        protected  static List<string> SupportedResources = new List<string>();

        static ClaimsAuthorizationPolicy()
        {
            SupportedClaimTypes.Add(ClaimTypes.Create);
            SupportedClaimTypes.Add(ClaimTypes.Read);
            SupportedClaimTypes.Add(ClaimTypes.Update);
            SupportedClaimTypes.Add(ClaimTypes.Delete);

            SupportedResources.Add(Resources.Application);
        }

        private static bool IsValidClaimType(string s)
        {
            return SupportedClaimTypes.Contains(s);
        }

        private static bool IsValidResource(string s)
        {
            return SupportedResources.Contains(s);
        }

        public static ClaimSet CreateIssuerClaimSet()
        {
            return new DefaultClaimSet(Claim.CreateUriClaim(new Uri(ClaimsAuthorizationPolicy.IssuerUri)), Claim.CreateDnsClaim(ClaimsAuthorizationPolicy.IssuerName), Claim.CreateNameClaim(ClaimsAuthorizationPolicy.IssuerName));
        }

        public static Claim CreateApplicationCreateClaim()
        {
            return new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Create, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty);
        }

        public static Claim CreateApplicationDeleteClaim()
        {
            return new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Delete, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty);
        }

        public static Claim CreateApplicationUpdateClaim()
        {
            return new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Update, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty);
        }

        public static Claim CreateApplicationReadClaim()
        {
            return new Claim(ClaimsAuthorizationPolicy.ClaimTypes.Read, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty);
        }

        public static ClaimSet CreateApplicationClaimSet(params string[] claimTypes)
        {
            List<Claim> claims = new List<Claim>();
            foreach(string s in claimTypes)
            {
                if (!IsValidClaimType(s))
                    throw new SecurityException(string.Format("Invalid claim type provided: {0}", s));

                claims.Add(new Claim(s, ClaimsAuthorizationPolicy.Resources.Application, Rights.PossessProperty));
            }
            
            return new DefaultClaimSet(ClaimsAuthorizationPolicy.CreateIssuerClaimSet(), claims);
        }

        public static ClaimSet CreateClaimSet(string resource, string claimType)
        {
            List<Claim> claims = new List<Claim>();
            
            if (!IsValidResource(resource))
                throw new SecurityException(string.Format("Resource not supported by ClaimsAuthorizationPolicy: {0}", resource));

            if (!IsValidClaimType(claimType))
                throw new SecurityException(string.Format("Claim type not supported by ClaimsAuthorizationPolicy: {0}", claimType));

                claims.Add(new Claim(claimType, resource, Rights.PossessProperty));
                        
            return new DefaultClaimSet(ClaimsAuthorizationPolicy.CreateIssuerClaimSet(), claims);
        }

    }
}
