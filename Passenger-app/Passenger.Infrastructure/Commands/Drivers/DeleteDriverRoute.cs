using System;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class DeleteDriverRoute : ICommand
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        
    }
}