using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class DayliRoute
    {
        private ISet<PassengerNode> _passengerNodes = new HashSet<PassengerNode>();
        public Route Route { get; protected set; }
        public Guid Id { get; protected set; }
        public IEnumerable<PassengerNode> PassengerNodes { get; protected set; }
    
        public void AddPassengerNode(Passenger passenger, Node node)
        {
            var passengerNode = GetPassengerNode(passenger);
            if(passengerNode != null)
            {
                throw new InvalidOperationException($"Node already exitst for passenger: '{passenger.UserId}'.");
            }
            _passengerNodes.Add(PassengerNode.Create(passenger, node));
        }

        public void RemovePassengerNode(Passenger passenger)
        {
            var passengerNode = GetPassengerNode(passenger);
            if(passengerNode == null)
            {
                return;
            }
            _passengerNodes.Remove(passengerNode);
        }

        public PassengerNode GetPassengerNode(Passenger passenger)
            => _passengerNodes.SingleOrDefault(x => x.Passenger.Id == passenger.UserId);
        protected DayliRoute()
        {
            Id = Guid.NewGuid();
        }

        public DayliRoute(Route route)
        {
            Id = Guid.NewGuid();
        }
    }
}
