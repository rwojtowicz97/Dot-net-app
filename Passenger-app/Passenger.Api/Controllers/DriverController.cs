using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;

namespace Passenger.Api.Controllers
{
    public class DriverController : ApiControllerBase 
    {
        public DriverController (ICommandDispatcher commandDispatcher) 
            : base(commandDispatcher)
        {
            
        }

        // [HttpGet("{email}")]
        // public async Task<IActionResult> Get(string email)
        // {
          
        // }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDriver command)
          {
            await CommandDispatcher.DispatchAsync(command);
            
            return NoContent();
          }
    }

}