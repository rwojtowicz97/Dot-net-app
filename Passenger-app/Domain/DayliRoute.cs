using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Domain
{
    public class DayliRoute
    {
        public Route Route { get; protected set; }
        public Guid ID { get; protected set; }
        public IEnumerable<PassengerNode> PassengerNodes { get; protected set; }
    }
}
