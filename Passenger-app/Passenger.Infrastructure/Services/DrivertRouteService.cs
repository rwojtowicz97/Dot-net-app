using System;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Repositories;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.Services
{
    public class DrivertRouteService : IDrivertRouteService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        public DrivertRouteService(IDriverRepository driverRepository,
                IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(Guid userId, string name, double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if(driver == null)
            {
                throw new Exception($"Driver with user id: '{userId}' doesnt exists.");
            }
            var start = Node.Create("Start address", startLongitude, startLatitude);
            
        }

        public async Task DeleteAsync(Guid userId, string name)
        {
            throw new NotImplementedException();
        }
    }
}