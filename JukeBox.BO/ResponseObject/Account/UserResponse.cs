using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JukeBox.BO.ResponseObject.Account
{
   public class UserResponse
    {
        public UserModel ResponseObject { get; set; }
        public int ResponseType { get; set; }
        public string ResponseMessage { get; set; }
    }
}
