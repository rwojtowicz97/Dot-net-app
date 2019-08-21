using System;
using System.Collections.Generic;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Route> Routes {get; set;}
        public IEnumerable<DayliRoute> DayliRoutes{get; set;}
    }
}
