using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class Passenger
    {
        public ISet<Node> _nodes = new HashSet<Node>();
        public ISet<PassengerNode> _passengerNodes = new HashSet<PassengerNode>();
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public PassengerNode Address { get; protected set; }
        public IEnumerable<Node> Nodes
        {
            get { return _nodes; }
            set { _nodes = new HashSet<Node>(value); }
        }
        public IEnumerable<PassengerNode> PassengerNodes
        {
            get { return _passengerNodes; }
            set { _passengerNodes = new HashSet<PassengerNode>(value); }
        }
        public DateTime UpdatedAt { get; protected set; }
    
        protected Passenger()
        {

        }

        public Passenger(User user)
        {
            UserId = user.Id;
            Name = user.Username;
        }

        public void AddNode(PassengerNode passengerNode)
        {
            
        }
    }
}
