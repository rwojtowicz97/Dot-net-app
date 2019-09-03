using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Commands;

namespace Passenger.Api.Controllers {
    [Route ("[controller]")]
    public class UsersController : ControllerBase {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commmandDispatcher;
        public UsersController (IUserService userService, ICommandDispatcher commandDispatcher)
        {
            _userService = userService;
            _commmandDispatcher = commandDispatcher;
        }

        [HttpGet ("{email}")]
        public async Task<IActionResult> Get(string email) 
            {
                var user = await _userService.GetAsync(email);
                if(user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
          {
            await _commmandDispatcher.DispatchAsync(command);
            
            return Created($"users/{command.Email}", new object());  
          }
    }
}