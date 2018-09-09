using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JukeBox.BLL
{
   public class Config
    {
        public static string ApiUserName =>System.Configuration.ConfigurationManager.AppSettings["ApiUserName"];
        public static string ApiPassword => System.Configuration.ConfigurationManager.AppSettings["ApiUserPassword"];
        public static string ApiUrl =>System.Configuration.ConfigurationManager.AppSettings["ApiUrl"];
    }
}
