using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JukeBox.BLL
{
   public class Cache
    {
        static MemoryCache memCache = MemoryCache.Default;


        public static string GetIpFromDomain(string domain)
        {
            if (string.IsNullOrEmpty(domain))
            {
                return "";
            }
            Uri myUri = new Uri(domain);
            return myUri.Authority.ToString();
        }

        public static string GetSyXSessionToken()
        {
            var sessionToken = HttpContext.Current.Application["SyXSessionToken"]?.ToString();
            return sessionToken;
        }
        public static int GetSyxUserId()
        {
            var userId = Convert.ToInt32(HttpContext.Current.Application["SyxUserId"]);
            return userId;
        }

        public static byte GetSyxBranchId()
        {
            var branchId = Convert.ToByte(HttpContext.Current.Application["SyxBranchId"]);
            return branchId;
        }

        public static byte GetSyxHoldingCompanyId()
        {
            var holdingCompanyId = Convert.ToByte(HttpContext.Current.Application["SyxHoldingCompanyId"]);
            return holdingCompanyId;
        }

        public static byte GetSyxCompanyId()
        {
            var companyId = Convert.ToByte(HttpContext.Current.Application["SyxCompanyId"]);
            return companyId;
        }

  

      
    }

    public static class CacheKey
    {
        public static string Setting { get { return "Setting"; } }
        public static string ApiUser { get { return "ApiUser"; } }
        public static string PlatformUser { get { return "PlatformUser"; } }

    }
}

