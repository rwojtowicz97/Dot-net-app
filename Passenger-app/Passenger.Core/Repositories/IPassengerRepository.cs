using System;
using Passenger.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
    using Passenger.Core.Domain;
    public interface IPassengerRepository : IRepository
    {
        Task<Passenger> GetAsync(Guid userId);
        Task<IEnumerable<Passenger>> BrowseAsync();
        Task AddAsync(Passenger passenger);
        Task UpdateAsync(Passenger passenger);
        Task DeleteAsync(Passenger passenger);
    }
}