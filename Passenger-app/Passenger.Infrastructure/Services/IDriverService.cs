using Passenger.Infrastructure.DTO;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService : IService
    {
        Task<DriverDto> GetAsync(string name);
    }
}
