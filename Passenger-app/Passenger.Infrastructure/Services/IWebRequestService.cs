using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IWebRequestService : IService
    {
        string CleanStreet(string street);
        string CleanCity(string city);
        void CreateUrl(string street, string city, string zipCode);
    }
}