using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class VehicleProvider : IVehicleProvider
    {
        private readonly IMemoryCache _cache;
        private readonly static string CacheKey = "vehicles";
        private static readonly IDictionary<string, IEnumerable<VehicleDetails>> availableVehicles = 
            new Dictionary<string, IEnumerable<VehicleDetails>>
            {
                ["Audi"] = new List<VehicleDetails>
                {
                    new VehicleDetails("RS8", 5)
                },
                ["BMW"] = new List<VehicleDetails>
                {
                    new VehicleDetails("i8", 3),
                    new VehicleDetails("E36", 5)
                },
                ["Ford"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Fiesta", 5)
                },
                ["Skoda"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Fabia", 5),
                    new VehicleDetails("Rapid", 5)
                },
                ["Volkswagen"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Passat", 5)
                }
            };
        public VehicleProvider(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<IEnumerable<VehicleDTO>> BrowseAsync()
        {
            var vehicles = _cache.Get<IEnumerable<VehicleDTO>>(CacheKey);
            if(vehicles == null)
            {
                vehicles = await GetAllAsync();
                _cache.Set(CacheKey, vehicles);
            }
            return vehicles;
        }

        public async Task<Vehicle> GetAsync(string brand, string name)
        {
            if(!availableVehicles.Contains(brand))
            {
                throw new Exception($"Vehicle brand: '{brand}' is not avaible.");
            }
            var vehicles = availableVehicles[brand];
            var vehicle = vehicles.SingleOrDefault(x => x.Name == name);
            if(vehicle == null)
            {
                throw new Exception($"Vechicle: '{name}' for brand '{brand}' is not avaible.");
            }
            
        }

        public async Task<IEnumerable<VehicleDTO>> GetAllAsync()
            => await Task.FromResult(availableVehicles.GroupBy(x => x.Key)
                .SelectMany(g => g.SelectMany(v => v.Value.Select(c => new VehicleDTO
                {
                    Brand = v.Key,
                    Name = c.Name,
                    Seats = c.Seats
                }))));

        private class VehicleDetails
        {
            public string Name {get;}
            public int Seats {get;}

            public VehicleDetails(string name, int seats)
            {
                Name = name;
                Seats = seats;
            }
        }
    }
}