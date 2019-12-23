using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Passenger.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;
        private readonly IPassengerService _passengerService;
        private readonly IDriverRouteService _driverRouteService;
        private readonly ILogger<DataInitializer> _logger;
        public DataInitializer(IUserService userService, IDriverService driverService,
        IPassengerService passengerService, IDriverRouteService driverRouteService,
         ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _driverService = driverService;
            _passengerService = passengerService;
            _driverRouteService = driverRouteService;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            var users = await _userService.BrowseAsync();
            var drivers = await _driverService.BrowseAsync();
            if(users.Any() && drivers.Any())
            {
                return;
            }
            _logger.LogInformation("Initializing data...");
            for(var i = 1; i<=10; i++)
            {   
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                await _userService.RegisterAsync(userId, $"{username}@test.com",
                            username, "secret1234", "user");
                _logger.LogInformation($"Created a new user: '{username}'.");
                await _driverService.CreateAsync(userId);
                await _driverService.SetVehicle(userId, "BMW", "i8");
                _logger.LogInformation($"Adding a new driver for: '{username}'.");
                await _driverRouteService.AddAsync(userId, "Default route", 1,1,2,2);
                await _driverRouteService.AddAsync(userId, "Job route", 3,4,7,8);
                _logger.LogInformation($"Adding route for: '{username}'.");
            }

            for(var i = 1; i<=3; i++)
            {   
                var userId = Guid.NewGuid();
                var username = $"userPassenger{i}";
                await _userService.RegisterAsync(userId, $"{username}@test.com",
                            username, "secret1234", "user");
                _logger.LogInformation($"Created a new user: '{username}'.");
                await _passengerService.CreateAsync(userId);
                _logger.LogInformation($"Adding a new passenger for: '{username}'.");
            }
            
            for(var i = 1; i<=3; i++)
            {   
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                _logger.LogInformation($"Created a new admin: '{username}'.");
                await _userService.RegisterAsync(userId, $"{username}@test.com",
                             username, "secret1234", "admin");
            }
            _logger.LogInformation("Data was Initialized.");
        }
    }
}