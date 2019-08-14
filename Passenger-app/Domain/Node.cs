using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Domain
{
    public class Node
    {
        public string Address { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }
    }
}
