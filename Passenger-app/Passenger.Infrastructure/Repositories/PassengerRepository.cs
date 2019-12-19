using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Passenger.Core.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Passenger.Infrastructure.Repositories
{
    //You shouldn't name class like a namespace :)
    using Passenger.Core.Domain;
    public class PassengerRepository : IPassengerRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;
        public PassengerRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Passenger> GetAsync(Guid userId)
            => await Passengers.AsQueryable().FirstOrDefaultAsync(x => x.UserId == userId);
        public async Task<IEnumerable<Passenger>> BrowseAsync()
            => await Passengers.AsQueryable().ToListAsync();
        public async Task AddAsync(Passenger passenger)
            => await Passengers.InsertOneAsync(passenger);
        public async Task DeleteAsync(Passenger passenger)
            => await Passengers.DeleteOneAsync(x => x.UserId == passenger.UserId);
        public async Task UpdateAsync(Passenger passenger)
            => await Passengers.ReplaceOneAsync(x => x.UserId == passenger.UserId, passenger);
        private IMongoCollection<Passenger> Passengers => _database.GetCollection<Passenger>("Passengers");
    }
}