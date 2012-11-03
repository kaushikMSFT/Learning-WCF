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

        public static class Resources
        {
            public const string Application = "http://schemas.thatindigogirl.com/samples/2006/06/identity/resources/application";
        }

        public static class ClaimTypes
        {
            public const string Create = "http://schemas.thatindigogirl.com/samples/2006/06/identity/claims/create";
            public const string Read = "http://schemas.thatindigogirl.com/samples/2006/06/identity/claims/read";
            public const string Update = "http://schemas.thatindigogirl.com/samples/2006/06/identity/claims/update";
            public const string Delete = "http://schemas.thatindigogirl.com/samples/2006/06/identity/claims/delete";
        }

        public const string IssuerUri = "http://www.thatindigogirl.com/samples/2006/06/issuer";
        public const string IssuerName = "IPKey"; // owned private key Name/DNS

    }
}
