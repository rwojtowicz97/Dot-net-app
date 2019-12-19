using System;

namespace Passenger.Infrastructure.DTO
{
    public class PassengerDto
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public NodeDto Node { get; protected set; }
    }
}