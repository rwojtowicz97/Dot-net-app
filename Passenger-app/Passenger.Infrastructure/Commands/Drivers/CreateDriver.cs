using System;
namespace Passenger.Infrastructure.Commands.Drivers
{
    public class CreateDriver : AuthenticatedCommandBase
    {
        public DriverVechicle Vechicle { get; set; }

        public class DriverVechicle
        {
            public string Name { get; protected set; }
            public string Brand { get; protected set; }
        }
    }
}