using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Commands.Users;

namespace Passenger.Api.Controllers {
    [Route ("[controller]")]
    public class UsersController : ControllerBase {
        private readonly IUserService _userService;
        public UsersController (IUserService userService) {
            _userService = userService;
        }

        [HttpGet ("{email}")]
        public async Task<UserDto> Get(string email) 
            => await _userService.GetAsync(email);

        [HttpGet ("")]
        public async Task Post([FromBody]CreateUser request)
          => await _userService.RegisterAsync(request.Email, request.Username, request.Password);
        
    }
}