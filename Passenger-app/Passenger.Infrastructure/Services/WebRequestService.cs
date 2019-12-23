using System;
using System.Net;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public class WebRequestService : IWebRequestService
    {
        
        public static string baseUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        public static string address = "Kołodzieja,+80180+gdansk";
        public static string apiKey = "&key=AIzaSyA_y-qtID0FOB17qY6wyacbQUG7aYYL9GQ";
        static string url = String.Concat(baseUrl, address, apiKey);
        WebRequest request = WebRequest.Create(url);

        public void CreateUrl()
            => Console.WriteLine(url);
        
    }
}