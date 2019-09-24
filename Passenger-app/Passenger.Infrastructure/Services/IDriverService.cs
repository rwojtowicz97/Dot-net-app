using System;
using Passenger.Infrastructure.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService : IService
    {
        Task<DriverDto> GetAsync(Guid userId);
        Task CreateAsync(Guid userId);
        Task SetVehicleAsync(Guid userId, string brand, string name, int seats);
        Task<IEnumerable<DriverDto>> BrowseAsync();
    }
}
