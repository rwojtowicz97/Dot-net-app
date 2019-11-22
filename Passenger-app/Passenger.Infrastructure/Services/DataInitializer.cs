using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Passenger.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;
        private readonly IDriverRouteService _driverRouteService;
        private readonly ILogger<DataInitializer> _logger;
        public DataInitializer(IUserService userService, IDriverService driverService,
        IDriverRouteService driverRouteService,
         ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _driverService = driverService;
            _driverRouteService = driverRouteService;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            _logger.LogInformation("Initializing data...");
            var tasks = new List<Task>();
            for(var i = 1; i<=10; i++)
            {   
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com",
                            username, "secret1234", "user"));
                _logger.LogInformation($"Created a new user: '{username}'.");
                tasks.Add(_driverService.CreateAsync(userId));
                tasks.Add(_driverService.SetVehicleAsync(userId, "BMW", "i8"));
                _logger.LogInformation($"Adding a new driver for: '{username}'.");
                tasks.Add(_driverRouteService.AddAsync(userId, "Default route", 1,1,2,2));
                tasks.Add(_driverRouteService.AddAsync(userId, "Job route", 3,4,7,8));
                _logger.LogInformation($"Adding route for: '{username}'.");
            }
            
            for(var i = 1; i<=3; i++)
            {   
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                _logger.LogInformation($"Created a new admin: '{username}'.");
                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com",
                             username, "secret1234", "admin"));
            }
            await Task.WhenAll(tasks);
            _logger.LogInformation("Data was Initialized.");
        }
    }
}