// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.IdentityModel.Selectors;
using System.Security;

namespace PasswordValidator
{
    public class CustomPasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            // TODO: look up the user in a custom security database
            if (password != "p@ssw0rd")
                throw new SecurityException("Access denied.");

            return;
        }
    }
}
