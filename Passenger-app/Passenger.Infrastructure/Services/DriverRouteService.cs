using System;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Repositories;
using Passenger.Core.Domain;
using Passenger.Infrastructure.Extensions;

namespace Passenger.Infrastructure.Services
{
    public class DriverRouteService : IDriverRouteService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IRouteManager _routeManager;
        private readonly IMapper _mapper;
        public DriverRouteService(IDriverRepository driverRepository, IRouteManager routeManager,
                IMapper mapper)
        {
            _driverRepository = driverRepository;
            _routeManager = routeManager;
            _mapper = mapper;
        }
        public async Task AddAsync(Guid userId, string name, double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);
            var StartAddress = await _routeManager.GetAddressAsync(startLatitude, startLongitude);
            var EndAddress = await _routeManager.GetAddressAsync(endLatitude, endLongitude);
            var startNode = Node.Create("Start address", startLongitude, startLatitude);
            var endNode = Node.Create("End address", endLongitude, endLatitude);
            var distance = _routeManager.CalculateDistance(startLatitude, startLongitude, endLatitude, endLongitude);
            driver.AddRoute(name, startNode, endNode, distance);
            await _driverRepository.UpdateAsync(driver);
            
        }

        public async Task DeleteAsync(Guid userId, string name)
        {
            var driver = await _driverRepository.GetOrFailAsync(userId);
            driver.DeleteRoute(name);
            await _driverRepository.UpdateAsync(driver);
        }
    }
}