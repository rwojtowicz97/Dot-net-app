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
    
    public class UsersController : ApiControllerBase 
    {
        private readonly IUserService _userService;
        public UsersController (IUserService userService,
             ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
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
            await CommandDispatcher.DispatchAsync(command);
            
            return Created($"users/{command.Email}", new object());  
          }
    }
}