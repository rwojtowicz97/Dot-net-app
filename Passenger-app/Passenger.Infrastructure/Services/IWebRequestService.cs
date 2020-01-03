using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IWebRequestService : IService
    {
        string CleanString(string example);
        void CreateUrl(string street, string city, string zipCode);
    }
}