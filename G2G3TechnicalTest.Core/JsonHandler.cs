using G2G3TechnicalTest.Core.Contracts;
using G2G3TechnicalTest.Core.Models;
using Newtonsoft.Json;

namespace G2G3TechnicalTest.Core
{
    public class JsonHandler : IJsonHandler
    {
        public TransportDto Deserialise(string data)
        {
            return JsonConvert.DeserializeObject<TransportDto>(data);
        }
    }
}
