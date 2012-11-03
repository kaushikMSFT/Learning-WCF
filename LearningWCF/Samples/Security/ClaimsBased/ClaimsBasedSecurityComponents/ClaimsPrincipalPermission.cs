// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Threading;
using System.IdentityModel.Claims;
using System.Security.Permissions;
using System.Security.Principal;

namespace ClaimsBasedSecurityComponents
{
    public class ClaimsPrincipalPermission : IPermission, IUnrestrictedPermission
    {
        private ClaimSet m_requiredClaims;
        private bool m_isAuthenticated;
        private bool m_isUnrestricted;

        public bool IsAuthenticated
        {
            get { return m_isAuthenticated; }
        }

        public ClaimSet Issuer
        {
            get { return ((this.m_requiredClaims==null)?null : this.m_requiredClaims.Issuer); }
        }

        public ClaimSet RequiredClaims
        {
            get { return this.m_requiredClaims; }
        }

        public ClaimsPrincipalPermission(PermissionState state)
        {
            this.m_isUnrestricted = (state == PermissionState.Unrestricted);
        }

        public ClaimsPrincipalPermission(bool isAuthenticated, ClaimSet requiredClaims)
        {
            this.m_isAuthenticated = isAuthenticated;
            this.m_requiredClaims=requiredClaims;
        }

        public override bool Equals(object obj)
        {
            IPermission p = obj as IPermission;

            if (obj!=null && p==null)
            {
                return false;
            }
            if (!this.IsSubsetOf(p))
            {
                return false;
            }
            if (p!=null && !p.IsSubsetOf(this))
            {
                return false;
            }
            return true;

        }

        public override int GetHashCode()
        {
            int hashCode = this.m_isAuthenticated.GetHashCode();
            hashCode+=this.m_requiredClaims.GetHashCode();
            hashCode+=this.m_isUnrestricted.GetHashCode();

            return hashCode;
        }

        #region IPermission Members

        /// <summary>
        /// Make a copy of this permission and return it.
        /// </summary>
        /// <returns></returns>
        public IPermission Copy()
        {
            if (this.m_isUnrestricted)
                return new ClaimsPrincipalPermission(PermissionState.Unrestricted);
            else 
                return new ClaimsPrincipalPermission(this.m_isAuthenticated, this.m_requiredClaims);
        }

        /// <summary>
        /// If IsAuthenticated was set on the permission, 
        ///   check the thread's principal is authenticated
        /// If Claims WERE NOT provided, don't check them
        /// If Claims WERE provided, check the thread's principal 
        ///   make sure it is an IClaimsPrincipal
        ///   check for an issuer match, 
        ///   check that required claims are present
        /// </summary>
        /// <param name="principal"></param>
        public void CheckClaims(IClaimsPrincipal principal)
        {
            IPrincipal p = principal as IPrincipal;

            if (this.m_isAuthenticated && !p.Identity.IsAuthenticated)
            {
                throw new SecurityException("Access is denied. Security principal is not authenticated.");
            }

            if (this.m_requiredClaims==null)
            {
                return;
            }

            if (!principal.HasRequiredClaims(this.m_requiredClaims))
                throw new SecurityException("Access is denied. Security principal does not satisfy required claims.");

        }

        /// <summary>
        /// Thrown a SecurityException if the permissions required are
        /// not satisfied by the current thread's principal.
        /// </summary>
        public void Demand()
        {
            IClaimsPrincipal p = Thread.CurrentPrincipal as IClaimsPrincipal;

            if (p == null)
                throw new SecurityException("Access is denied. Security principal should be a IClaimSetPrincipal type.");

            this.CheckClaims(p);

        }

        /// <summary>
        /// Return a new permission with the intersection of claims.
        /// Issuer must be an exact match.
        /// Intersecting claims are added to a new ClaimSet by the same issuer.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public IPermission Intersect(IPermission target)
        {
            if (target == null)
                return null;

            ClaimsPrincipalPermission perm = target as ClaimsPrincipalPermission;
            if (perm == null)
                return null;

            if (this.IsUnrestricted())
                return target.Copy();

            if (perm.IsUnrestricted())
                return this.Copy();

            if (this.m_isAuthenticated != perm.IsAuthenticated)
                return null;

            if (!IsExactIssuerMatch(perm.Issuer)) return null;
            
            List<Claim> claims = new List<Claim>();
            foreach (Claim c in this.m_requiredClaims)
            {
                if (perm.RequiredClaims.ContainsClaim(c))
                {
                    claims.Add(c);
                }
                
            }

            // it is assumed that the issuers are identical from the call
            // to IsExactIssuerMatch() above
            ClaimsPrincipalPermission newPerm = new ClaimsPrincipalPermission(this.m_isAuthenticated, new DefaultClaimSet(this.m_requiredClaims.Issuer, claims));
            return newPerm;

        }

        /// <summary>
        /// It is important that when performing a check that two permissions
        /// are a subset, or to perform union or intersection of two permissions
        /// that the issuers provided are an exact match by claimset 
        /// to reduce confusion.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        protected bool IsExactIssuerMatch(ClaimSet target)
        {
            bool issuerMatch = true;
            foreach (Claim c in target)
            {
                if (!this.m_requiredClaims.Issuer.ContainsClaim(c))
                {
                    issuerMatch = false;
                    break;
                }
            }

            return issuerMatch;
        }

        /// <summary>
        /// Is the permission provided a subset of this permission?
        /// Issuer must be an exact match.
        /// Claims in this permission must all be contained in target.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool IsSubsetOf(IPermission target)
        {

            if (target == null)
                return false;

            ClaimsPrincipalPermission perm = target as ClaimsPrincipalPermission;
            if (perm == null)
                return false;

            if (perm.IsUnrestricted())
                return true;
            
            if (this.IsUnrestricted())
                return false;

            if (this.m_isAuthenticated != perm.IsAuthenticated)
                return false;

            if (!IsExactIssuerMatch(perm.Issuer)) return false;

            bool isSubsetOf = false;
            foreach (Claim c in this.m_requiredClaims)
            {
                if (!perm.RequiredClaims.ContainsClaim(c))
                {
                    isSubsetOf=false;
                    break;
                }
                
            }
        
            return isSubsetOf;

        }

        /// <summary>
        /// Return a new permission with the union of this and the permission 
        /// provided.
        /// IsAuthenticated must match.
        /// Issuer must be an exact match.
        /// All claims added to a new ClaimSet with the same Issuer.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public IPermission Union(IPermission target)
        {
            if (target == null)
                return null;

            ClaimsPrincipalPermission perm = target as ClaimsPrincipalPermission;
            if (perm == null)
                return null;

            if (perm.IsUnrestricted()|| this.IsUnrestricted())
                return new ClaimsPrincipalPermission(PermissionState.Unrestricted);

            if (this.m_isAuthenticated != perm.IsAuthenticated)
                return null;

            if (!IsExactIssuerMatch(perm.Issuer)) return null;

            List<Claim> claims = new List<Claim>();
            foreach(Claim c in this.m_requiredClaims)
                claims.Add(c);

            foreach (Claim c in perm.RequiredClaims)
            {
                if (!this.m_requiredClaims.ContainsClaim(c))
                {
                    claims.Add(c);
                }
            }

            // it is assumed that the issuers are identical from the call
            // to IsExactIssuerMatch() above
            ClaimsPrincipalPermission newPerm = new ClaimsPrincipalPermission(this.m_isAuthenticated, new DefaultClaimSet(this.m_requiredClaims.Issuer, claims));
            return newPerm;

        }

        #endregion

        #region ISecurityEncodable Members

        public void FromXml(SecurityElement e)
        {
            throw new NotSupportedException("ClaimsPrincipalPermission cannot be loaded from XML.");
        }

        public SecurityElement ToXml()
        {
            throw new NotSupportedException("ClaimsPrincipalPermission cannot be saved to XML.");
        }

        #endregion

        #region IUnrestrictedPermission Members

        public bool IsUnrestricted()
        {
            return this.m_isUnrestricted;
        }

        #endregion
    }
}
