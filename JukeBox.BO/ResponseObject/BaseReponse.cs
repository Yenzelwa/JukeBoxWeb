using JukeBox.BO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JukeBox.BO.ResponseObject
{
   public class BaseReponse
    {
        public class BaseResponse<T> where T : class
        {
            public T ResponseObject { get; set; }

            public string ResponseMessage { get; set; }

            public ResponseType ResponseType { get; set; }
        }
    }
}
