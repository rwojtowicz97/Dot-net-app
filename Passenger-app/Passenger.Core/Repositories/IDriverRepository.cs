using Passenger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Passenger.Core.Repositories
{
    public interface IDriverRepository
    {
        Driver Get(Guid userId);
        Driver Get(string name);
        IEnumerable<Driver> GetAll();
        void Add(Driver user);
        void Update(Driver user);
        void Remove(Guid id);
    }
}
