using Passenger.Domain;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Repositories
{    
    public class InMemoryDriverRepository : IDriverRepository
    {
        private ISet<Driver> _drivers = new HashSet<Driver>();
        public void Add(Driver user)
            => _drivers.Add(user);

        public Driver Get(string name)
            => _drivers.Single(x => x.Name == name);
        public Driver Get(Guid userId)
            => _drivers.Single(x => x.UserId == userId);

        public IEnumerable<Driver> GetAll()
            => _drivers;

        public void Remove(Guid userId)
        {
            var driver = Get(userId);
            _drivers.Remove(driver);
        }
        public void Update(Driver user)
        {
            throw new NotImplementedException();
        }
    }
}
