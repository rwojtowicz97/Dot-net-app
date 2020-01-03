using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class Node
    {
        // New structure:

        public class AddressComponent
        {

        }

        // Old structure:
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
    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Northeast2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Viewport
    {
        public Northeast2 northeast { get; set; }
        public Southwest2 southwest { get; set; }
    }

    public class Geometry
    {
        public Bounds bounds { get; set; }
        public Location location { get; set; }
        public string location_type { get; set; }
        public Viewport viewport { get; set; }
    }

    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string place_id { get; set; }
        public List<string> postcode_localities { get; set; }
        public List<string> types { get; set; }
    }

    public class RootObject
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
}
