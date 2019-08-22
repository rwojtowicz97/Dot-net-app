using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public Vehicle vehicle { get; protected set; }
        public IEnumerable<Route> Routes { get; protected set; }
        public IEnumerable<DayliRoute> DayliRoutes { get; protected set; }

        protected Driver()
        {

        }

        public Driver(string name)
        {
            SetName(name);
            UserId = Guid.NewGuid();
        }

        public void SetName(string name)
        {
            if(!string.IsNullOrWhiteSpace(name))
            {
                Name = name;

            }
            else 
            {
                throw new Exception("Name is invalid.");
            }
        }
    }
}
