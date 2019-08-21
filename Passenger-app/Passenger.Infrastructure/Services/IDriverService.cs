using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    interface IDriverService
    {
        Task<DriverDto> GetAsync(string name);
    }
}
