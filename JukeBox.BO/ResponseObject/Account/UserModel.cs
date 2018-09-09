using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JukeBox.BO.ResponseObject.Account
{
   public class UserModel
    {

        public int UserId { get; set; }
        public BasicInfo basic { get; set; }
        public AccessTokenModel AccessToken { get; set; }

        //   public List<RoleUserMap> RoleUserMaps { get; set; }

        public class RoleUserMap
        {

            public int? RoleUserMapId { get; set; }
            public int? UserId { get; set; }
            public short? RoleId { get; set; }
        }
        public class BasicInfo

        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool Enabled { get; set; }
            public string EmailAddress { get; set; }
            public string CellPhone { get; set; }
            public short? CompanyId { get; set; }
        }
        public class AccessTokenModel
        {
            public string Type { get; set; }
            public string Token { get; set; }
            public DateTime? ExpiryDateTimeUTC { get; set; }
        }
    }
}
