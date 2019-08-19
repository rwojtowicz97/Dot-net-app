using Passenger.Passenger.Core.Repositories;
using Passenger.Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public DriverDto Get(string name)
        {
            var driver = _driverRepository.Get(name);
            return new DriverDto
            {
                Name = driver.Name
            };
        }
    }
}
