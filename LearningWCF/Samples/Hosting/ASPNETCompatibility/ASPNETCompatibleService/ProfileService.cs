// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
   
using System;
using System.ServiceModel;
using System.Net.Security;
using System.ServiceModel.Activation;
using System.Web;
using System.Globalization;
using System.Threading;

namespace ASPNETCompatibleService
{

    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface IProfileService
    {
        [OperationContract]
        void SetCulturePreference(string culture);

        [OperationContract]
        string GetCulturePreference();
    }
   
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Required)]
    public class ProfileService : IProfileService
    {

        #region IProfileService Members

        public void SetCulturePreference(string culture)
        {
            CultureInfo myCulture = new CultureInfo(culture);
            HttpContext.Current.Profile["Culture"] = culture;
        }

        public string GetCulturePreference()
        {


            CultureInfo myCulture = null;
            string culture =null;
            if (HttpContext.Current.Profile["Culture"] != null)
                culture = HttpContext.Current.Profile["Culture"] as string;

            if (String.IsNullOrEmpty(culture))
            {
                myCulture = Thread.CurrentThread.CurrentUICulture;
                HttpContext.Current.Profile["Culture"] = myCulture.Name;
            }
            else
                myCulture = new CultureInfo(culture);                

            return myCulture.Name;
        }

        #endregion
    }

}

