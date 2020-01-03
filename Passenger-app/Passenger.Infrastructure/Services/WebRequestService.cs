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
            string url = String.Concat(baseUrl, CleanString(street), ",+", zipCode, "+", CleanString(city), apiKey);
            Console.WriteLine(url);
        }
        
        public string CleanString(string example)
        {
            if(string.IsNullOrEmpty(example))
            {
                throw new Exception("String can't be null or empty");
            }
            example = example.Trim();
            string cleanString = Regex.Replace(example, @" +", "+");
            example = cleanString;
            return example;
        }
    }
}