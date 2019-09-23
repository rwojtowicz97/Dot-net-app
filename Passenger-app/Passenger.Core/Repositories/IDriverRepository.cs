using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
    public interface IDriverRepository : IRepository
    {
        Task<Driver> GetAsync(Guid userId);
        Task<Driver> GetAsync(string name);
        Task<IEnumerable<Driver>> BrowseAsync();
        Task AddAsync(Driver user);
        Task UpdateAsync(Driver user);
        Task RemoveAsync(Guid id);
    }
}
