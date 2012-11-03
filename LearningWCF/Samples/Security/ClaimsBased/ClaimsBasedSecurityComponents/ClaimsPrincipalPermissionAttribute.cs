// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Security.Permissions;
using System.IdentityModel.Claims;

namespace ClaimsBasedSecurityComponents
{

    /// <summary>
    /// Example for extending the ClaimsPrincipalPermissionAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class CreateClaimAttribute: ClaimsPrincipalPermissionAttribute
    {

        public CreateClaimAttribute(SecurityAction action)
            : base(action)
        {
            this.Authenticated=true;
            this.RequiredClaimType = ClaimsAuthorizationPolicy.ClaimTypes.Create;
            this.Resource=ClaimsAuthorizationPolicy.Resources.Application;
        }

    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ClaimsPrincipalPermissionAttribute : CodeAccessSecurityAttribute
    {

        private bool m_isAuthenticated;
        private string m_requiredClaimType;
        private string m_resource;

        public ClaimsPrincipalPermissionAttribute(SecurityAction action)
            : base(action)
        {
            this.m_isAuthenticated = true;
        }

        public string RequiredClaimType
        {
            get
            {
                return this.m_requiredClaimType;
            }
            set
            {
                this.m_requiredClaimType = value;
            }
        }


        public string Resource
        {
            get
            {
                return this.m_resource;
            }
            set
            {
                this.m_resource = value;
            }
        }

        public bool Authenticated
        {
            get { return m_isAuthenticated; }
            set { m_isAuthenticated = value; }
        }

        public override System.Security.IPermission CreatePermission()
        {
            if (this.Unrestricted)
                return new ClaimsPrincipalPermission(PermissionState.Unrestricted);

            ClaimSet cs = ClaimsAuthorizationPolicy.CreateClaimSet(this.m_resource, this.m_requiredClaimType);
            return new ClaimsPrincipalPermission(this.m_isAuthenticated, cs);
        }
        
    }
}
