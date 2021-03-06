﻿using System;
using Passenger.Infrastructure.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService : IService
    {
        Task<DriverDetailsDto> GetAsync(Guid userId);
        Task CreateAsync(Guid userId);
        Task SetVehicle(Guid userId, string brand, string name);
        Task SetVehicle(string username, string brand, string name);
        Task<IEnumerable<DriverDto>> BrowseAsync();
        Task DeleteAsync(Guid userId);
    }
}
