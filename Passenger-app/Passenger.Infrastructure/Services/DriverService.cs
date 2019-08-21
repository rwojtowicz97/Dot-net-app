using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Infrastructure.Mappers;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<DriverDto> GetAsync(string name)
        {
            var driver = await _driverRepository.GetAsync(name);
            return _mapper.Map<Driver, DriverDto>(driver);
        }
    }
}
