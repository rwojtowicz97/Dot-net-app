using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class DayliRoute
    {
        public Route Route { get; protected set; }
        public Guid Id { get; protected set; }
        public IEnumerable<PassengerNode> PassengerNodes { get; protected set; }
    
        protected DayliRoute()
        {
        
        }

        public DayliRoute(Route route)
        {
            Id = Guid.NewGuid();
        }


    }
}
