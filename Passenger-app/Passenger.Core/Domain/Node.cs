using System;

namespace Passenger.Core.Domain
{
    public class Node
    {
        public string Address { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }
    
        protected Node()
        {

        }

        public Node(string address, double longitude, double latitude)
        {
            SetAddress(address);
            SetLongitude(longitude);
            SetLatitude(latitude);
        }

        public static Node Create(string address, double longitude, double latitude)
            => new Node(address, longitude, latitude);
        
        public void SetAddress(string address)
        {
            if(!string.IsNullOrWhiteSpace(address))
            {
                Address = address;
            }
            else
            {
                throw new Exception("Address is invalid.");
            }
        }

        public void SetLatitude(double latitude)
        {
            if(!double.IsNaN(latitude))
            {
                Latitude = latitude;
            }
            else
            {
                throw new Exception("Latitude is not a number.");
            }
        }

        public void SetLongitude(double longitude)
        {
            if(!double.IsNaN(longitude))
            {
                Longitude = longitude;
            }
            else
            {
                throw new Exception("Longitude is not a number.");
            }
        }
    }
}
