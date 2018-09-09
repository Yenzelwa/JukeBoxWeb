using JukeBox.BO.RequestObject;
using JukeBox.BO.ResponseObject;
using JukeBox.BO.ResponseObject.Account;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JukeBox.BLL.Administration
{
   public class Account
    {
        public static async Task<UserModel> ApiLoginClient(UserRequestLogin login)
        {
            var req = new RestRequest("api/admin/login", Method.POST);
            req.RequestFormat = DataFormat.Json;
            req.JsonSerializer = JsonSerializer.Default;
            req.AddBody(login);
            var response = await RestJukeBox.ExecuteAsync<UserResponse>(req);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }

            return response.Data.ResponseObject;
        }

    }
}
