﻿using System.Collections;
using Passenger.Core.Domain;
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
        public async Task AddAsync(Driver driver)
        {
            _drivers.Add(driver);
            await Task.CompletedTask;
        }

        public async Task<Driver> GetAsync(Guid userId)
            => await Task.FromResult(_drivers.SingleOrDefault(x => x.UserId == userId));

        public async Task<IEnumerable<Driver>> BrowseAsync()
            => await Task.FromResult(_drivers);

        public async Task RemoveAsync(Guid userId)
        {
            var driver = await GetAsync(userId);
            _drivers.Remove(driver);
            await Task.CompletedTask;
        }
        public async Task UpdateAsync(Driver driver)
            => await Task.CompletedTask;
    }
}
