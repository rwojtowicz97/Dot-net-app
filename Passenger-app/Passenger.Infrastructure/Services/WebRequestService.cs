using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public class WebRequestService : IWebRequestService
    {
        
        public static string baseUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        public static string apiKey = "&key=AIzaSyA_y-qtID0FOB17qY6wyacbQUG7aYYL9GQ";
        public void CreateUrl(string street, string city, string zipCode)
        {
            string url = String.Concat(baseUrl, CleanStreet(street), ",+", zipCode, "+", CleanCity(city), apiKey);
            Console.WriteLine(url);
        }
        
        //deleting whitespaces form string
        public string CleanStreet(string street)
        {
            if(string.IsNullOrEmpty(street))
            {
                throw new Exception("Street can't be null or empty.");
            }
            street = street.Trim();
            string cleanStreet = Regex.Replace(street, @" +", "+");
            street = cleanStreet;
            return street;
        }
        
        //deleting whitespaces form string
        public string CleanCity(string city)
        {
            if(string.IsNullOrEmpty(city))
            {
                throw new Exception("City can't be null or empty.");
            }
            city = city.Trim();
            string cleanCity = Regex.Replace(city, @" +", "+");
            city = cleanCity;
            return city;
        }
    }
}