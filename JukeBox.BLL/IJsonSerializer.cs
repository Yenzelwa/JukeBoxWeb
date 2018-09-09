using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JukeBox.BLL
{
    public interface IJsonSerializer : ISerializer, IDeserializer
    {
    }
}
