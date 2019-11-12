using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using System;
using System.Collections.Generic;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVehicleProvider _vehicleProvider;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IUserRepository userRepository
        , IVehicleProvider vehicleProvider, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
            _vehicleProvider = vehicleProvider;
            _mapper = mapper;
        }

        public async Task<DriverDetailsDto> GetAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);
            
            return _mapper.Map<Driver, DriverDetailsDto>(driver);
        }

        public async Task<IEnumerable<DriverDto>> BrowseAsync()
        {
            var drivers = await _driverRepository.BrowseAsync();

            return _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverDto>>(drivers);
        }

        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);

            if(user == null)
            {
                throw new Exception($"User with id: {userId} was not found.");
            }

            var driver = await _driverRepository.GetAsync(userId);

            if(driver != null)
            {
                 throw new Exception($"Driver with id: {userId} already exists.");
            }

            driver = new Driver(user);
            await  _driverRepository.AddAsync(driver);
        }

        public async Task SetVehicleAsync(Guid userId, string brand, string name)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if(driver == null)
            {
                throw new Exception($"Driver with user id: '{userId}' was not found.");
            }
            var vehicleDetails = await _vehicleProvider.GetAsync(brand, name);
            var vehicle = Vehicle.Create(name, brand, vehicleDetails.Seats);
            driver.SetVehicle(vehicle);
        }
    }
}
