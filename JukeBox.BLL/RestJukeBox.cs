using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JukeBox.BLL
{
    class RestJukeBox : BaseRest
    {
        public static IRestResponse<T> Execute<T>(IRestRequest request) where T : new()
        {
            InitializeOnce(Config.ApiUrl);

            //Ignore bad certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback = AcceptAllCertifications;

            return client.Execute<T>(request);
        }

        public static async Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request) where T : new()
        {
            InitializeOnce(Config.ApiUrl);

            //ignore bad certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback = AcceptAllCertifications;

            return await client.ExecuteTaskAsync<T>(request);
        }


        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}


