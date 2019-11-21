﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Core.Domain
{
    public class Route
    {
        public string Name { get; protected set;}
        public Node StartNode { get; protected set; }
        public Node EndNode { get; protected set; }
        public IEnumerable<Route> Routes { get; protected set; }
    
        protected Route()
        {
            
        }

        protected Route(string name, Node start, Node end)
        {
            Name = name;
            StartNode = start;
            EndNode = end;
        }

        public static Route Create(string name, Node start, Node end)
            => new Route(name, start, end);
    }
}
