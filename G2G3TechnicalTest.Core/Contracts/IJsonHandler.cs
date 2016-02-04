using G2G3TechnicalTest.Core.Models;

namespace G2G3TechnicalTest.Core.Contracts
{
    public interface IJsonHandler
    {
        TransportDto Deserialise(string data);
    }
}
