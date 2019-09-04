using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.Api;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class ControllerTestBase
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;
        protected ControllerTestBase()
        {
            Server = new TestServer(new WebHostBuilder().
                    UseStartup<Startup>());
            Client = Server.CreateClient();
        }
        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            //Content type: application/json
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}