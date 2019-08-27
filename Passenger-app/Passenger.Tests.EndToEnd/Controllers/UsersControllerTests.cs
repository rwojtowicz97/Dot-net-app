using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Passenger.Api;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UsersControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public UsersControllerTests()
        {
            _server = new TestServer(new WebHostBuilder().
                    UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        public async Task given_valid_emaill_user_should_exists()
        {
            
        }
    }
}