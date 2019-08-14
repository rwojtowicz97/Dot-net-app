using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Domain
{
  public class PassengerNode
  {
        public Node Node { get; protected set; }
        public Passenger Passenger { get; protected set; }
  }
}
