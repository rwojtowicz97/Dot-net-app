using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IWebRequestService : IService
    {
        void CreateUrl();
    }
}