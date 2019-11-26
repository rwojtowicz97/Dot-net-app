using Passenger.Infrastructure.Commands.Drivers.Models;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class DeleteDriver : AuthenticatedCommandBase
    {
        public DriverVehicle Vehicle { get; set; }
    }
}