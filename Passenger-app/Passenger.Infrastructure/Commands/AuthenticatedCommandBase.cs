using System;

namespace Passenger.Infrastructure.Commands
{
    public class AuthenticatedCommandBase : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
    }
}