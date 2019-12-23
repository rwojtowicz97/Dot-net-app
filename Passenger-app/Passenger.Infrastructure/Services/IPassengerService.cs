using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IPassengerService : IService
    {
        Task<PassengerDetailsDto> GetAsync(Guid userId);
        Task CreateAsync(Guid userId);
        Task<IEnumerable<PassengerDto>> BrowseAsync();
        Task DeleteAsync(Guid userId);
    }
}