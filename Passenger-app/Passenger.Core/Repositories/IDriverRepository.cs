using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
    public interface IDriverRepository
    {
        Task<Driver> GetAsync(Guid userId);
        Task<IEnumerable<Driver>> GetAllAsync();
        Task Add(Driver user);
        Task Update(Driver user);
        Task Remove(Guid id);
    }
}
