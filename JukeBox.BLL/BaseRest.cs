using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JukeBox.BLL
{
   public class BaseRest
    {
        private static bool _ranOnce;
        protected static readonly RestClient client = new RestClient();

        public static void InitializeOnce(string uri)
        {
            //if (_ranOnce) return;
            if (_ranOnce && client.BaseUrl.AbsoluteUri.Contains(uri)) return;
            client.BaseUrl = new Uri(uri);
            client.AddDefaultHeader("Content-Type", "application/json");
            client.AddHandler("application/json", JsonSerializer.Default);
            client.AddHandler("text/json", JsonSerializer.Default);
            client.AddHandler("text/x-json", JsonSerializer.Default);
            client.AddHandler("text/javascript", JsonSerializer.Default);
            client.AddHandler("*+json", JsonSerializer.Default);
            _ranOnce = true;
        }
    }
}
