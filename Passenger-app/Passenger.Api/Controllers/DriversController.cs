using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    public class DriversController : ApiControllerBase 
    {
      private readonly IDriverService _driverService;
        public DriversController (ICommandDispatcher commandDispatcher,
         IDriverService driverService) 
            : base(commandDispatcher)
        {
            _driverService = driverService;
        }

         [HttpGet]
         public async Task<IActionResult> Get()
         {
           var drivers = await _driverService.BrowseAsync();

           return Json(drivers);
         }

        [HttpGet ("{userId}")]
        public async Task<IActionResult> Get(Guid userId) 
            {
                var driver = await _driverService.GetAsync(userId);

                return Json(driver);
            }  

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDriver command)
          {
            await CommandDispatcher.DispatchAsync(command);
            
            return Created($"drivers/{command.UserId}", new Object());
          }
    }

}