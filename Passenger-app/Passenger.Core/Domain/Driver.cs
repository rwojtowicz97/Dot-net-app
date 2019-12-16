using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        public ISet<Route> _routes = new HashSet<Route>();
        private ISet<DayliRoute> _dayliRoutes = new HashSet<DayliRoute>();
        public Guid UserId { get; protected set; }
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes 
        { 
            get { return _routes; } 
            set { _routes = new HashSet<Route>(value); } 
        }
        public IEnumerable<DayliRoute> DayliRoutes
        { 
            get { return _dayliRoutes; } 
            set { _dayliRoutes = new HashSet<DayliRoute>(value); } 
        }
        public DateTime UpdatedAt { get; protected set; }

        protected Driver()
        {

        }

        public Driver(User user)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            Name = user.Username;
        }

        public void SetVehicle(Vehicle vehicle)
        {
            if(vehicle == null)
            {
                throw new Exception($"Vehicle is null");
            }
            Vehicle = vehicle;
            UpdatedAt =  DateTime.UtcNow;
        }

        public void AddRoute(string name, Node start, Node end, double distance)
        {
            var route = Routes.SingleOrDefault(x => x.Name == name);
            if(route != null)
            {
                throw new Exception($"Route with '{name}' already exists for diver: {Name}.");
            }
            if(distance <= 0)
            {
                throw new Exception($"Distance can't be less or equal 0.");
            }
            _routes.Add(Route.Create(name, start, end, distance));
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeleteRoute(string name)
        {
            var route = Routes.SingleOrDefault(x => x.Name == name);
            if(route == null)
            {
                throw new Exception($"Route with '{name}' doesn't exists for driver {Name}.");
            }
            _routes.Remove(route);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
