using System.Collections.Generic;

namespace Passenger.Infrastructure.DTO
{
    public class PassengerDetailsDto
    {
        public IEnumerable<NodeDto> Nodes { get; set; }
    }
}